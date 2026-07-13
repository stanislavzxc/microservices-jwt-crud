FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["microservices_jwt_crud.csproj", "./"]

RUN dotnet restore "microservices_jwt_crud.csproj"

COPY . .

RUN dotnet publish "microservices_jwt_crud.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

CMD ["dotnet", "microservices_jwt_crud.dll"]
