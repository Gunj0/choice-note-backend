# ビルドステージ
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# csproj をコピーして restore
COPY *.csproj .
RUN dotnet restore

# 残りのソースをコピーして publish
COPY . .
RUN dotnet publish -c Release -o out

# 実行ステージ
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "ChoiceNote.WebAPI.dll"]
