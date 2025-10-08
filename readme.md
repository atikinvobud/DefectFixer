Клонировать репозиторий:
```
git clone https://github.com/atikinvobud/DefectFixer
```
Для запуска бэкенда:
```
cd Backend
dotnet run
```

Для запуска фронтенда:
```
cd Frontend
npm install
npm run dev
```

Также в папке Backend нужно создать .env файл со следующей структурой
```
DatabaseConnection = postgresconnection
MONGO_CONNECTION_STRING=mongodb://localhost:27017
MONGO_DATABASE=Your_Mongo_Database
JwtSettings__SecretKey =Your_Secret_Key
JwtSettings__Issuer =Your_Issuer
JwtSettings__Audience =Your_Audience
EmailSettings__Address =Your_Email
EmailSettings__Password =Your_Password
```

Проект работает на 2 портах:
```
Порт 5020 для Бэкенда
Порт 5173: Фронтенд
```
В проекте используется PostgresSQL как реляционная база данных, MongoDb для хранения картинок и отчетов, Redis lkz хранения кода для смены пароля.