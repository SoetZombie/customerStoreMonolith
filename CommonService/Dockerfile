FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CommonService/CommonService.csproj", "CommonService/"]
RUN dotnet restore "CommonService/CommonService.csproj"
COPY . .
WORKDIR "/src/CommonService"
RUN dotnet build "CommonService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommonService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommonService.dll"]
