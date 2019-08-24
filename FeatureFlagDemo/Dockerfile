FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["FeatureFlagDemo/FeatureFlagDemo.csproj", "FeatureFlagDemo/"]
RUN dotnet restore "FeatureFlagDemo/FeatureFlagDemo.csproj"
COPY . .
WORKDIR "/src/FeatureFlagDemo"
RUN dotnet build "FeatureFlagDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FeatureFlagDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FeatureFlagDemo.dll"]