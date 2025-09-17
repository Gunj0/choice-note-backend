# Docker コンテナーで ASP.NET Core アプリを実行する
# https://learn.microsoft.com/ja-jp/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-9.0

# buildステージ
## dotnet/sdk: CLI, Debug, 単体テスト用の .NET SDK イメージ
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
## コンテナ内の作業ディレクトリを指定
WORKDIR /source
## Dockerfile 階層のファイル全て→作業ディレクトリにコピー
COPY . .
## 依存関係の復元
RUN dotnet restore
## out フォルダに release ビルドした DLL 等を出力
RUN dotnet publish -c release -o out
## 確認用
# RUN ls -la out

# アプリ実行ステージ
## dotnet/aspnet: 軽量な ASP.NET Core ランタイムイメージ
FROM mcr.microsoft.com/dotnet/aspnet:9.0
## コンテナ内の作業ディレクトリを指定
WORKDIR /source
## build ステージで publish したDLL等をカレントにコピー
COPY --from=build /source/out .
## コンテナのデフォルトの起動コマンドを指定
ENTRYPOINT ["dotnet", "ChoiceNote.WebAPI.dll"]
