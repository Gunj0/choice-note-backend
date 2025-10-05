# Docker セットアップ

## Dockerfile 作成

- [# Docker コンテナーで ASP.NET Core アプリを実行する](https://learn.microsoft.com/ja-jp/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-9.0)

## docker build & run

```zsh
# docker build . : 指定パスのDockerfileからDocker Image作成
# -t: イメージ名:タグ名
choice-note-backend % docker build -t choice-note:latest .

# docker run choice-note: Image名からコンテナ作成&コマンド実行
# -i: 標準入力を開いた状態にする
# -t: 疑似端末を割り当てる
# -d: バックグラウンド実行
# --rm: ビルド時の一時コンテナを削除する
# -p: ポートマッピング(ローカル:コンテナ内)
# -name: コンテナ名
choice-note-backend % docker run -d --rm -p 8888:8080 --name choice-note-backend choice-note

# docker ps -a: コンテナ一覧を表示
% docker ps -a
```

## 起動確認

- [localhost](http://localhost:8080/weatherforecast)

## docker-compose 作成

```yml
services:
  choice-note:
    # Dockerfileからイメージをビルド
    build: .
    # Docker起動時に常に再起動するように設定
    restart: always
    container_name: choice-note
    ports:
      - 8080:8080
    environment:
      ASPNETCORE_ENVIRONMENT: Development
```
