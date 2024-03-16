# How to run
## Install requirements
```
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL // not needed?
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet tool install --global dotnet-ef // needed? if used 'dotnet ef' yes...
dotnet add package Microsoft.EntityFrameworkCore.Design
```

## Init db
Create initial migration.
```
dotnet ef migrations add InitialCreate
```

Do the migration.
```
dotnet ef database update
```