# ビルドステージ
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

# csproj をコピーして restore
COPY . ./
RUN dotnet restore
RUN dotnet publish -c release -o out

# 実行ステージ
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /source
COPY --from=build /source/out .
ENTRYPOINT ["dotnet", "ChoiceNote.WebAPI.dll"]
