# Render セットアップ

## Render 設定

- Create new Project
  - Project name: choice-memo
  - Environment name: Production
- Settings
  - Region: Singapore
  - Instance Type: Free(0.1CPU 512MB)
  - Root Directory: (空欄)
  - Dockerfile Path: ./Dockerfile
  - Docker Build Context Directory: .

## デプロイ設定

- GitHub と接続してリモートプッシュで自動デプロイ

## UptimeRobot 設定

- UptimeRobot の Monitor interval を 10h に設定
  - Render のフリープランは 15 分アクセスがないとスリープする
  - スリープを防ぐと同時に監視設定をする
