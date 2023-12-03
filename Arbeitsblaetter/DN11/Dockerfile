FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DN11/DN11.csproj", "DN11/"]
RUN dotnet restore "DN11/DN11.csproj"
COPY . .
WORKDIR "/src/DN11"
RUN dotnet build "DN11.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DN11.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DN11.dll"]
