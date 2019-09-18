# Build Stage
FROM mcr.microsoft.com/dotnet/core/sdk as build-env

WORKDIR /client
COPY ./src .
RUN dotnet restore IDP/IDP.csproj
RUN dotnet publish IDP/IDP.csproj -o /publish -c Release

# Runtime Image Stage
FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /publish
COPY --from=build-env /publish .

WORKDIR /publish
ENTRYPOINT ["dotnet", "IDP.dll"]