# Usando a imagem oficial do .NET 8 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos do projeto e restaura as dependências
COPY *.csproj .
RUN dotnet restore

# Copia todos os arquivos e compila a aplicação
COPY . .
RUN dotnet publish -c Release -o out

# Usando a imagem oficial do .NET 8 ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Configura o ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "Knight.API.dll"]