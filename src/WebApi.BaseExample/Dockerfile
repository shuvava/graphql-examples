FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/WebApi.BaseExample/WebApi.BaseExample.csproj", "src/WebApi.BaseExample/"]
RUN dotnet restore "src/WebApi.BaseExample/WebApi.BaseExample.csproj"
COPY . .
WORKDIR "/src/src/WebApi.BaseExample"
RUN dotnet build "WebApi.BaseExample.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApi.BaseExample.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApi.BaseExample.dll"]