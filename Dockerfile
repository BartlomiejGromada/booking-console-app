FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
# COPY ["booking-app.csproj", "./"]

COPY . .
RUN dotnet restore "booking-app.csproj"
RUN dotnet restore "./booking-app-tests/booking-app-tests.csproj"

RUN dotnet build "booking-app.csproj" -c $configuration -o /app/build

RUN dotnet test "./booking-app-tests/booking-app-tests.csproj" --no-build --verbosity normal

WORKDIR "/src/."

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "booking-app.csproj" -c $configuration -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "booking-app.dll"]
