FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /Api

# Copy everything
COPY . .
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o obj

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /Api
COPY --from=build-env /Api/obj .
ENTRYPOINT ["dotnet", "Knight.API.dll"]
EXPOSE 5002