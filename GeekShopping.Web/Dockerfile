#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GeekShopping.Web/GeekShopping.Web.csproj", "GeekShopping.Web/"]
RUN dotnet restore "GeekShopping.Web/GeekShopping.Web.csproj"
COPY . .
WORKDIR "/src/GeekShopping.Web"
RUN dotnet build "GeekShopping.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeekShopping.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeekShopping.Web.dll"]