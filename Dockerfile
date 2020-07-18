#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["aspnet-core-api/aspnet-core-api.csproj", "aspnet-core-api/"]
COPY ["Api.Entities/Api.Entities.csproj", "Api.Entities/"]
COPY ["Api.Services/Api.Services.csproj", "Api.Services/"]
COPY ["Api.Repository/Api.Repository.csproj", "Api.Repository/"]
RUN dotnet restore "aspnet-core-api/aspnet-core-api.csproj"
COPY . .
WORKDIR "/src/aspnet-core-api"
RUN dotnet build "aspnet-core-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "aspnet-core-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "aspnet-core-api.dll"]