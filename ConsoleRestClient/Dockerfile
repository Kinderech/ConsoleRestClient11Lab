FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ConsoleRestClient/ConsoleRestClient.csproj", "ConsoleRestClient/"]
RUN dotnet restore "ConsoleRestClient/ConsoleRestClient.csproj"
COPY . .
WORKDIR "/src/ConsoleRestClient"
RUN dotnet build "ConsoleRestClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsoleRestClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleRestClient.dll"]
