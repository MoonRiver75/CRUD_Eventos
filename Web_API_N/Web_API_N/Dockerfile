# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://+:80

# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Web_API_N/Web_API_N.csproj", "Web_API_N/"]
RUN dotnet restore "Web_API_N/Web_API_N.csproj"
COPY . .
WORKDIR "/src/Web_API_N"
RUN dotnet build "Web_API_N.csproj" -c Release -o /app/build

# Etapa de publicación
FROM build AS publish
RUN dotnet publish "Web_API_N.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ConnectionStrings__DefaultConnection="Server=sqlserver;Database=EventDetailDB;User=sa;Password=nortenas!;TrustServerCertificate=True;"

# Health check (super importante 💖)
HEALTHCHECK --interval=30s --timeout=3s \
  CMD curl -f http://localhost/health || exit 1

ENTRYPOINT ["dotnet", "Web_API_N.dll"]