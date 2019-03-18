FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/WebApi.BaseExample/WebApi.BaseExample.csproj src/WebApi.BaseExample/
COPY src/StarWars.Repository.Mock/StarWars.Repository.Mock.csproj src/StarWars.Repository.Mock/
COPY src/StarWars.Models/StarWars.Models.csproj src/StarWars.Models/
COPY src/StarWars.Repository.EF6/StarWars.Repository.EF6.csproj src/StarWars.Repository.EF6/
COPY src/StarWars.Implementation/StarWars.Implementation.csproj src/StarWars.Implementation/
RUN dotnet restore src/WebApi.BaseExample/WebApi.BaseExample.csproj
COPY . .
WORKDIR /src/src/WebApi.BaseExample
RUN dotnet build WebApi.BaseExample.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WebApi.BaseExample.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApi.BaseExample.dll"]
