using ChoiceNote.WebAPI.Data;
using ChoiceNote.WebAPI.Data.Repositories;
using ChoiceNote.WebAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL 用の DbContext/接続文字列 を登録
builder.Services.AddDbContext<ChoiceNoteDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string not found."))
);

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
