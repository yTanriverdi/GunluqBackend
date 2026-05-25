FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Gunluq-WebAPI/Gunluq-WebAPI.csproj", "Gunluq-WebAPI/"]

RUN dotnet restore "Gunluq-WebAPI/Gunluq-WebAPI.csproj"

COPY . .

WORKDIR "/src/Gunluq-WebAPI"

RUN dotnet build "Gunluq-WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "Gunluq-WebAPI.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Gunluq-WebAPI.dll"]