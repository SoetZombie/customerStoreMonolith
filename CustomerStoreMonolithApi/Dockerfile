FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CustomerStoreMonolithApi/CustomerStoreMonolithApi.csproj", "CustomerStoreMonolithApi/"]
RUN dotnet restore "CustomerStoreMonolithApi/CustomerStoreMonolithApi.csproj"
COPY . .
WORKDIR "/src/CustomerStoreMonolithApi"
RUN dotnet build "CustomerStoreMonolithApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerStoreMonolithApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerStoreMonolithApi.dll"]
