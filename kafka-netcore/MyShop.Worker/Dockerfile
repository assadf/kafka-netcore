#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MyShop.Worker/MyShop.Worker.csproj", "MyShop.Worker/"]
RUN dotnet restore "MyShop.Worker/MyShop.Worker.csproj"
COPY . .
WORKDIR "/src/MyShop.Worker"
RUN dotnet build "MyShop.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyShop.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyShop.Worker.dll"]