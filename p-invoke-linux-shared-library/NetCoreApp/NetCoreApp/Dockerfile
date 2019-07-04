FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY . .
RUN dotnet restore "NetCoreApp/NetCoreApp.csproj"
WORKDIR "/src/NetCoreApp"
RUN dotnet build "NetCoreApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NetCoreApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetCoreApp.dll"]