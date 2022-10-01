#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["host/InstaRent.Cart.HttpApi.Host/InstaRent.Cart.HttpApi.Host.csproj", "host/InstaRent.Cart.HttpApi.Host/"]
COPY ["src/InstaRent.Cart.HttpApi/InstaRent.Cart.HttpApi.csproj", "src/InstaRent.Cart.HttpApi/"]
COPY ["src/InstaRent.Cart.Application.Contracts/InstaRent.Cart.Application.Contracts.csproj", "src/InstaRent.Cart.Application.Contracts/"]
COPY ["src/InstaRent.Cart.Domain.Shared/InstaRent.Cart.Domain.Shared.csproj", "src/InstaRent.Cart.Domain.Shared/"]
COPY ["src/InstaRent.Cart.Application/InstaRent.Cart.Application.csproj", "src/InstaRent.Cart.Application/"]
COPY ["src/InstaRent.Cart.Domain/InstaRent.Cart.Domain.csproj", "src/InstaRent.Cart.Domain/"]
COPY ["host/InstaRent.Cart.Host.Shared/InstaRent.Cart.Host.Shared.csproj", "host/InstaRent.Cart.Host.Shared/"]
RUN dotnet restore "host/InstaRent.Cart.HttpApi.Host/InstaRent.Cart.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/host/InstaRent.Cart.HttpApi.Host"
RUN dotnet build "InstaRent.Cart.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InstaRent.Cart.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstaRent.Cart.HttpApi.Host.dll"]