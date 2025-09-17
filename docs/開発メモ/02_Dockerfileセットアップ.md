# Docker セットアップ

## ローカル

- Dockerfile 作成
- docker build & run

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

- 起動確認
  - [localhost](http://localhost:8080/weatherforecast)

## Render.com

- Settings
  - Region: Singapore
  - Instance Type: Free(0.1CPU 512MB)
  - Root Directory: (空欄)
  - Dockerfile Path: ./Dockerfile
