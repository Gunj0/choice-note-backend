# Docker セットアップ

- docker build & run

```zsh
% docker build -t choice_note .
% docker run -it --rm -p 8080:8080 --name choice_note choice_note
```

- 起動確認
  - [localhost]http://localhost:8080/weatherforecast)
