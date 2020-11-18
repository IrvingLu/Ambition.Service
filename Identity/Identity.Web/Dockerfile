#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Identity/Identity.Web/Identity.Web.csproj", "Identity/Identity.Web/"]
COPY ["Identity/Identity.Infrastructure/Identity.Infrastructure.csproj", "Identity/Identity.Infrastructure/"]
COPY ["Identity/Identity.Core/Identity.Core.csproj", "Identity/Identity.Core/"]
RUN dotnet restore "Identity/Identity.Web/Identity.Web.csproj"
COPY . .
WORKDIR "/src/Identity/Identity.Web"
RUN dotnet build "Identity.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.Web.dll"]