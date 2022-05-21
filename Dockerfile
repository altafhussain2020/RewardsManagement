FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RewardsManagement.csproj", "./"]
RUN dotnet restore "RewardsManagement.csproj"
COPY . .
RUN dotnet publish "RewardsManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "RewardsManagement.dll"]