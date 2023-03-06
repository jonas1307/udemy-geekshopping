#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GeekShopping.ProductAPI/GeekShopping.ProductAPI.csproj", "GeekShopping.ProductAPI/"]
RUN dotnet restore "GeekShopping.ProductAPI/GeekShopping.ProductAPI.csproj"
COPY . .
WORKDIR "/src/GeekShopping.ProductAPI"
RUN dotnet build "GeekShopping.ProductAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeekShopping.ProductAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeekShopping.ProductAPI.dll"]