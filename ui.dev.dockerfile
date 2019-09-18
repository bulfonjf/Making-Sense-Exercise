# Build Stage
FROM mcr.microsoft.com/dotnet/core/sdk as build-env

WORKDIR /client
COPY . .
RUN dotnet restore src/UI/Client.csproj
RUN dotnet publish src/UI/Client.csproj -o /publish -c Release

# Runtime Image Stage
FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /publish
COPY --from=build-env /publish .

WORKDIR /publish
ENTRYPOINT ["dotnet", "Client.dll"]