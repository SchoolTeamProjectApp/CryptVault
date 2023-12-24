# CrypVault
### ASP.NET MVC Web application for password and card managment.

| |Team|
|:---:|:---:|
|<img style="width: 50px; border-radius: 50%;" src="https://github.com/Dzhanel.png">|[Dzhanel Mehmed](https://github.com/Dzhanel)|
|<img style="width: 50px; border-radius: 50%;" src="https://github.com/GospodinChem.png">|[Daniel Chemshirov](https://github.com/GospodinChem)|
|<img style="width: 50px; border-radius: 50%;" src="https://github.com/Nokraker.png">|[Ivaylo Vulkov](https://github.com/Nokraker)|
|<img style="width: 50px; border-radius: 50%;" src="https://github.com/GeorgiStoyanov05.png">|[Georgi Stoyanov](https://github.com/GeorgiStoyanov05)|


# Setup
To start the project you will need to setup your `connection string` and run the `migrations`.
There is several ways you can do that. Two of them are:
 - within Visual Studio
 - with .NET Core CLI (cross-platform option).
### Visual Studio
Add **YOUR** SQL Server connection string to secrets.json (Right-click on CryptVault.Web -> Manage User Secrets) 
```json
  "ConnectionStrings": {
    "DefaultConnection": "<Connection string>"
  }
```
then run the migrations with `Update-Database` in the Package Manager Console.

### .NET Core CLI
Add connection string to secrets.json:
```
dotnet user-secrets set ConnectionStrings:DefaultConnection "<Connection string>"
```
Run the migrations:
```
dotnet ef database update
```
---