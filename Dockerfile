FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app 
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GroceryShop.API/GroceryShop.API.csproj", "GroceryShop.API/"]
RUN dotnet restore "GroceryShop.API/GroceryShop.API.csproj"
COPY . . 
WORKDIR "/src/GroceryShop.API"
RUN dotnet build "./GroceryShop.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GroceryShop.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GroceryShop.API.dll"]