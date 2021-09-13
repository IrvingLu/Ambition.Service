#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Src/NMS.RTIS.Web/NMS.RTIS.Web.csproj", "Src/NMS.RTIS.Web/"]
COPY ["Src/NMS.RTIS.Infrastructure/NMS.RTIS.Infrastructure.csproj", "Src/NMS.RTIS.Infrastructure/"]
COPY ["Src/NMS.RTIS.Domain/NMS.RTIS.Domain.csproj", "Src/NMS.RTIS.Domain/"]
COPY ["Src/NMS.RTIS.Core/NMS.RTIS.Core.csproj", "Src/NMS.RTIS.Core/"]
RUN dotnet restore "Src/NMS.RTIS.Web/NMS.RTIS.Web.csproj"
COPY . .
WORKDIR "/src/Src/NMS.RTIS.Web"
RUN dotnet build "NMS.RTIS.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NMS.RTIS.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NMS.RTIS.Web.dll"]