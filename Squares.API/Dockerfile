FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Squares.API/Squares.API.csproj", "Squares.API/"]
RUN dotnet restore "Squares.API/Squares.API.csproj"
COPY . .
WORKDIR "/src/Squares.API"
RUN dotnet build "Squares.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Squares.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Squares.API.dll"]
