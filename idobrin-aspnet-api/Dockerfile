FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5271
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["idobrin-aspnet-api/idobrin-aspnet-api.csproj", "idobrin-aspnet-api/"]
RUN dotnet restore "idobrin-aspnet-api/idobrin-aspnet-api.csproj"
COPY . .
WORKDIR "/src/idobrin-aspnet-api"
RUN dotnet build "./idobrin-aspnet-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./idobrin-aspnet-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "idobrin-aspnet-api.dll"]
