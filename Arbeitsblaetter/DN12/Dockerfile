FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DN12/DN12.csproj", "DN12/"]
RUN dotnet restore "DN12/DN12.csproj"
COPY . .
WORKDIR "/src/DN12"
RUN dotnet build "DN12.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DN12.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DN12.dll"]
