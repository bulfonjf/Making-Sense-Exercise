# Making-Sense-Exercise
Repository for the exercise of Making Sense

## How to test the web api?

You can run the WebAPI project (e.g: from visual studio code) with the following commands:
- dotnet restore .\src\WebAPI\WebAPI.csproj (optional)
- dotnet build .\src\WebAPI\WebAPI.csproj
- dotnet run -p .\src\WebAPI\WebAPI.csproj
- Use the postman collection to get, create or delete a blog.
  
## IDP
The IDP is an Identity Data provider. You can run it with these commands:
- dotnet restore .\src\IDP\IDP.csproj (optional)
- dotnet build .\src\IDP\IDP.csproj
- dotnet run -p .\src\IDP\IDP.csproj
- Navigate to https://localhost:5001 with a browser