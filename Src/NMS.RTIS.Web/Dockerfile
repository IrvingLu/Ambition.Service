#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Project/NMS.RTIS.Web/NMS.RTIS.Web.csproj", "Project/NMS.RTIS.Web/"]
COPY ["Project/NMS.RTIS.Web.Application/NMS.RTIS.Web.Appliccation.csproj", "Project/NMS.RTIS.Web.Application/"]
COPY ["Project/Project.Infrastructure/Project.Infrastructure.csproj", "Project/Project.Infrastructure/"]
COPY ["Project/NMS.RTIS.Core/NMS.RTIS.Core.csproj", "Project/NMS.RTIS.Core/"]
COPY ["Project/Project.Domain/Project.Domain.csproj", "Project/Project.Domain/"]
RUN dotnet restore "Project/NMS.RTIS.Web/NMS.RTIS.Web.csproj"
COPY . .
WORKDIR "/src/Project/NMS.RTIS.Web"
RUN dotnet build "NMS.RTIS.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NMS.RTIS.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NMS.RTIS.Web.dll"]