FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1️⃣ Copiamos la solución
COPY BarberFlow.sln .

# 2️⃣ Copiamos los csproj (IMPORTANTE)
COPY BarberFlow.Api/*.csproj BarberFlow.Api/
COPY BarberFlow.Domain/*.csproj BarberFlow.Domain/
COPY BarberFlow.Application/*.csproj BarberFlow.Application/
COPY BarberFlow.Infrastructure/*.csproj BarberFlow.Infrastructure/

# 3️⃣ Restore (ya funciona, porque los csproj existen)
RUN dotnet restore BarberFlow.sln

# 4️⃣ Copiamos el resto del código
COPY . .

# 5️⃣ Publish
RUN dotnet publish BarberFlow.Api/BarberFlow.Api.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BarberFlow.Api.dll"]
