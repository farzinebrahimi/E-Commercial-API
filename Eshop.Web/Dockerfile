# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ../*.sln .

RUN mkdir mbShop.Web \
          mbShop.Data \
          mbShop.Application\

COPY mbShop.Web/mbShop.Web.csproj ./mbShop.Web/
COPY mbShop.Data/*.csproj ./mbShop.Data/
COPY mbShop.Application/*.csproj ./mbShop.Application/

RUN dotnet restore *.sln

COPY .. .

WORKDIR /src/mbShop.Web
RUN dotnet publish "mbShop.Web.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5000
EXPOSE 5010

ENTRYPOINT ["dotnet", "mbShop.Web.dll"]
