FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["RabbitPlatform.Web/RabbitPlatform.Web.csproj", "RabbitPlatform.Web/"]
COPY ["DependencyInjection/DependencyInjection.csproj", "DependencyInjection/"]
COPY ["RabbitPlatform.Data/RabbitPlatform.Data.csproj", "RabbitPlatform.Data/"]
COPY ["RabbitPlatform.Core/RabbitPlatform.Core.csproj", "RabbitPlatform.Core/"]
COPY ["RabbitPlatform.Application/RabbitPlatform.Application.csproj", "RabbitPlatform.Application/"]
COPY ["RabbitPlatform.Repository/RabbitPlatform.Repository.csproj", "RabbitPlatform.Repository/"]
COPY ["RabbitPlatform.Domain/RabbitPlatform.Domain.csproj", "RabbitPlatform.Domain/"]
RUN dotnet restore "RabbitPlatform.Web/RabbitPlatform.Web.csproj"
COPY . .
WORKDIR "/src/RabbitPlatform.Web"
RUN dotnet build "RabbitPlatform.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RabbitPlatform.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RabbitPlatform.Web.dll"]