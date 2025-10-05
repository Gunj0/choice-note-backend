using ChoiceNote.WebAPI.Data;
using ChoiceNote.WebAPI.Data.Repositories;
using ChoiceNote.WebAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext を PostgreSQL 用に登録
// Scoped ライフタイムでリクエストごとに新しい DbContext インスタンスを使用する
builder.Services.AddDbContext<ChoiceNoteDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string not found."),
        npgsqlOptions =>
        {
            npgsqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5, // 最大リトライ回数
                maxRetryDelay: TimeSpan.FromSeconds(30), // リトライ間隔の最大値
                errorCodesToAdd: null); // 追加でリトライ対象にするエラーコード
        })
);

// CORS ポリシーの設定
// Next.jsのSSRからのリクエストにはCORS設定不要

// コントローラの追加
builder.Services.AddControllers();

// DI コンテナにサービスを登録
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();

// ビルド
var app = builder.Build();

// HTTPS リダイレクトを有効化
app.UseHttpsRedirection();

// コントローラの自動マッピング
app.MapControllers();

// アプリケーションの実行
app.Run();
