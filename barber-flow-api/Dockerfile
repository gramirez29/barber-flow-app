FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Barber.Flow.sln .
COPY Barber.Flow.Api ./Barber.Flow.Api
COPY Barber.Flow.Domain ./Barber.Flow.Domain
COPY Barber.Flow.Application ./Barber.Flow.Application
COPY Barber.Flow.Infrastructure ./Barber.Flow.Infrastructure

RUN dotnet restore Barber.Flow.sln

RUN dotnet publish Barber.Flow.Api/Barber.Flow.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Barber.Flow.Api.dll"]
