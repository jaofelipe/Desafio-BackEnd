FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DesafioBackEnd.csproj", "./"]
RUN dotnet restore "./DesafioBackEnd.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DesafioBackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioBackEnd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioBackEnd.dll"]