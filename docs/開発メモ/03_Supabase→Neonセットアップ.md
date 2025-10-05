# Supabase→Neon セットアップ

## Supabase セットアップ

- New Project
  - Project name: choice-note
  - Region: Singapore(Tokyo も選べるけど Render に合わせた)
- 接続文字列
  - メニューバーの「Connect」
  - Type: .NET
  - Render は IPv6 対応していないので Transaction pooler を使用
- [断続的エラー](./100_Supabase接続エラー.md)により断念

## Neon セットアップ

- New Project
  - Postgres version: 17
  - Cloud service provider: AWS (Azure は Region が少ない)
  - Region: Singapore (Japan はない)
  - Enable Neon Auth: 一旦オフ (後から Enable できる)
- 接続文字列取得
  - Dashboard の「Connect」
  - .NET 選択
  - Connections String を使用
