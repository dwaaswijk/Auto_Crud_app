# Auto API – ASP.NET Core Web API met Entity Framework Core

Dit project is een CRUD Web API gemaakt in **ASP.NET Core**, met ondersteuning voor een **1-op-veel-relatie** tussen Automerken (parent) en Autotypes (child). De API gebruikt **Entity Framework Core** met **code-first migrations** en **SQL Server** als database.

## 📁 Projectstructuur

```bash
Controllers/
    AutomerkenController.cs
    AutotypesController.cs
    
DTOs/
    AutomerkDto.cs
    CreateAutomerkDto.cs
    AutotypeDto.cs
    CreateAutotypeDto.cs
    
Models/
    Automerk.cs
    Autotype.cs
    
Data/
    AutoContext.cs

Tests/
  CompleteFunctionalityTest.http
    
Migrations/
    initial.cs
    
Program.cs
Appsettings.json
```

Hoe run ik het project?

0. clone het project(neem aan dat je dat al hebt gedaan als je dit leest)
1. verander de database connectie string in appsettings.json
2. ```bash 
   dotnet ef database update
3. ```bash
   dotnet run
   
4 test hem nu via de swagger omgeving of via het http bestand!
