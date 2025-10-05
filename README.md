# Choice Note のバックエンドサービス

## 起動方法

- Docker コンテナ起動

```zsh
% docker compose up
```

- DB マイグレーション

```zsh
% dotnet ef database update --project ./ChoiceNote.WebAPI
```

- デバッグ起動
  - `F5`
