# Build Stage
FROM mcr.microsoft.com/dotnet/core/sdk as build-env

WORKDIR /client
COPY ./src .
RUN dotnet restore UI/Client.csproj
RUN dotnet publish UI/Client.csproj -o /UI/publish -c Release

# Runtime Image Stage
FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /publish
COPY --from=build-env /publish .

WORKDIR /UI/publish
ENTRYPOINT ["dotnet", "Client.dll"]