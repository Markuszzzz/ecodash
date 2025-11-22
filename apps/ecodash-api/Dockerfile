# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopier csproj først og restore (bedre cache)
COPY Ecodash.Api.csproj .
RUN dotnet restore Ecodash.Api.csproj

# Kopier resten av koden
COPY . .
RUN dotnet publish Ecodash.Api.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Ecodash.Api.dll"]