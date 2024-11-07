FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY . .

RUN dotnet restore "booking-app/booking-app.csproj"
RUN dotnet restore "booking-app-tests/booking-app-tests.csproj"

RUN dotnet build "booking-app-tests/booking-app-tests.csproj" -c Release
RUN dotnet test "booking-app-tests/booking-app-tests.csproj" --verbosity normal

RUN dotnet publish "booking-app/booking-app.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final

WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "booking-app.dll"]