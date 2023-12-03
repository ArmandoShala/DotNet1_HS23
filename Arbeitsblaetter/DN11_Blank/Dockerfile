FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DN11_Blank/DN11_Blank.csproj", "DN11_Blank/"]
RUN dotnet restore "DN11_Blank/DN11_Blank.csproj"
COPY . .
WORKDIR "/src/DN11_Blank"
RUN dotnet build "DN11_Blank.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DN11_Blank.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DN11_Blank.dll"]
