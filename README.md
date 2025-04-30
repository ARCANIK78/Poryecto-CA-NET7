# Proyecto: Clean Architecture con .NET 9.0

Este proyecto aplica el patrón de arquitectura limpia (Clean Architecture) utilizando .NET 9.0. La solución está dividida en las capas típicas de este enfoque:

- **Domain**
- **Application**
- **Infrastructure**
- **Web.API**

---

## 🚀 Tecnologías utilizadas

- [.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Clean Architecture
- Swagger (Swashbuckle)

---

## ⚙️ Comandos utilizados para crear el proyecto

```bash
# Crear capas como Class Library
dotnet new classlib -o Domain -f net9.0
dotnet new classlib -o Application -f net9.0
dotnet new classlib -o Infrastructure -f net9.0

# Crear el proyecto Web API
dotnet new webapi -o Web.API -f net9.0

# Referencias entre capas
dotnet add Application/Application.csproj reference Domain/Domain.csproj
dotnet add Infrastructure/Infrastructure.csproj reference Domain/Domain.csproj
dotnet add Infrastructure/Infrastructure.csproj reference Application/Application.csproj
dotnet add Web.API/Web.API.csproj reference Application/Application.csproj Infrastructure/Infrastructure.csproj

dotnet sln add Web.API/Web.API.csproj 
dotnet sln add Application/Application.csproj
dotnet sln add Infrastructure/Infrastructure.csproj
dotnet sln add Domain/Domain.csproj
## Swagger para documentación de la API
dotnet add "Web.API/Web.API.csproj" package Swashbuckle.AspNetCore

# Asegúrate de registrar Swagger en Program.cs:
builder.Services.AddSwaggerGen();
app.UseSwagger();
app.UseSwaggerUI();

#  Cómo ejecutar la aplicación
dotnet build
dotnet run --project Web.API
