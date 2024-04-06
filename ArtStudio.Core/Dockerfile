FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ArtStudio.Core/ArtStudio.Core.csproj", "ArtStudio.Core/"]
RUN dotnet restore "ArtStudio.Core/ArtStudio.Core.csproj"
COPY . .
WORKDIR "/src/ArtStudio.Core"
RUN dotnet build "ArtStudio.Core.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ArtStudio.Core.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArtStudio.Core.dll"]
