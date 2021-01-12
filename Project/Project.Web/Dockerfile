#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Project/Project.Web/Project.Web.csproj", "Project/Project.Web/"]
COPY ["Project/Project.Web.Application/Project.Web.Appliccation.csproj", "Project/Project.Web.Application/"]
COPY ["Project/Project.Infrastructure/Project.Infrastructure.csproj", "Project/Project.Infrastructure/"]
COPY ["Project/Project.Core/Project.Core.csproj", "Project/Project.Core/"]
COPY ["Project/Project.Domain/Project.Domain.csproj", "Project/Project.Domain/"]
RUN dotnet restore "Project/Project.Web/Project.Web.csproj"
COPY . .
WORKDIR "/src/Project/Project.Web"
RUN dotnet build "Project.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project.Web.dll"]