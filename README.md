# Poryecto-CA-NET7
# Comandos usados en este proyecto
--dotnet new classlib -o Domain -f net9.0
--dotnet new classlib -o Application -f net9.0
--dotnet new classlib -o Infrastructure -f net9.0
--dotnet new webapi -o Web.API -f net9.0
--dotnet add Application/Application.csproj reference Domain/Domain.csproj
--dotnet add Infrastructure/Infrastructure.csproj reference Domain/Domain.csproj
--dotnet add Infrastructure/Infrastructure.csproj reference Application/Application.csproj
--dotnet add Web.API/Web.API.csproj reference Application/Application.csproj Infrastructure/Infrastructure.csproj
--dotnet sln add Web.API/Web.API.csproj 
--dotnet sln add Application/Application.csproj
--dotnet sln add Infrastructure/Infrastructure.csproj
--dotnet sln add Domain/Domain.csproj
--dotnet build
--dotnet run -p Web.API #para correr el api
--dotnet add "Web.API/Web.API.csproj" package Swashbuckle.AspNetCore  #opcion para tener UseSwagger
# ejepmlo para acceder a la api http://localhost:5255/Swagger/index.html

