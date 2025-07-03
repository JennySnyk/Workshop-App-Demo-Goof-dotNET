# Use a specific, known-vulnerable version of the .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0.400-alpine3.16

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0.8-alpine3.16
WORKDIR /app
COPY --from=0 /app/out .
ENTRYPOINT ["dotnet", "Workshop-App-Demo-Goof-dotNET.dll"]
