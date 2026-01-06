
# Booking API

Простое REST API для управления бронированием комнат с разграничением ролей:  
- **Администратор** может создавать, удалять и просматривать комнаты.  
- **Пользователь** может бронировать свободные комнаты и получать информацию о бронировании.

Реализовано с использованием:
- .NET 8 Web API
- Entity Framework Core
- PostgreSQL (запускается в Docker)
- Слоистая архитектура (Domain, Application, Infrastructure, API)

---

## Технологии

- **Backend**: C#, ASP.NET Core 8
- **ORM**: Entity Framework Core + Npgsql (PostgreSQL provider)
- **База данных**: PostgreSQL в Docker-контейнере
- **Архитектура**: Clean/Onion-inspired layered architecture
- **Тестирование API**: Thunder Client (VS Code)

---

## Быстрый запуск

### 1. Клонировать репозиторий
```bash
git clone https://github.com/Virgindevil/booking-api.git
cd booking-api
```

### 2. Запустить PostgreSQL в Docker
```bash
docker-compose up -d
```

> Требуется установленный [Docker Desktop](https://www.docker.com/products/docker-desktop/).

### 3. Применить миграции
```bash
dotnet ef database update --project BookingApi.Infrastructure --startup-project BookingApi.Api
```

> Убедитесь, что установлен глобальный инструмент `dotnet-ef`:  
> ```bash
> dotnet tool install --global dotnet-ef
> ```

### 4. Запустить API
```bash
dotnet run --project BookingApi.Api
```

Сервер будет доступен по адресу: `http://localhost:5156`

### 5. Протестировать API
Рекомендуется использовать [Thunder Client](https://www.thunderclient.com/) (расширение для VS Code).

Примеры запросов:
- `POST /api/admin/rooms` — создать комнату
- `POST /api/bookings` — забронировать комнату
- `GET /api/bookings/{id}` — получить бронирование

> Нельзя забронировать комнату, которая уже занята.

---

## Структура проекта

```
BookingApi/
├── BookingApi.Api/          # Presentation Layer (Web API)
├── BookingApi.Application/  # Application Layer (сервисы, DTO)
├── BookingApi.Domain/       # Domain Layer (сущности)
├── BookingApi.Infrastructure/ # Infrastructure (EF Core, репозитории)
├── docker-compose.yml       # PostgreSQL в Docker
└── BookingApi.sln           # Решение
```

---

## Тестирование

Проект не содержит автоматических тестов, но логика легко тестируется вручную через Thunder Client или curl.

---

## Примечания

- Нет аутентификации — идентификатор пользователя передаётся в теле запроса (`userId`).
- Бронирование проверяется только по факту наличия записи в таблице (без учёта дат).
- Для продакшена необходимо добавить валидацию, обработку ошибок, JWT и проверку временных интервалов.

---

## Автор

Разработано **[Virgindevil](https://github.com/Virgindevil)**  
Для учебных целей и портфолио.
