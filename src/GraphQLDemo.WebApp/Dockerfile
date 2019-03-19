FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["src/GraphQLDemo.WebApp/GraphQLDemo.WebApp.csproj", "src/GraphQLDemo.WebApp/"]
RUN dotnet restore "src/GraphQLDemo.WebApp/GraphQLDemo.WebApp.csproj"
COPY . .
WORKDIR "/src/src/GraphQLDemo.WebApp"
RUN dotnet build "GraphQLDemo.WebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GraphQLDemo.WebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GraphQLDemo.WebApp.dll"]