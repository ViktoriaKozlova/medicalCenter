FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["medical Center/medical Center.csproj", "medical Center/"]
RUN dotnet restore "medical Center/medical Center.csproj"
COPY . .
WORKDIR "/src/medical Center"
RUN dotnet build "medical Center.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "medical Center.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "medical Center.dll"]
