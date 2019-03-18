FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
# in corporate network use to fic ssl proxy cret error >>>>
RUN echo | openssl s_client -showcerts -servername api.nuget.org -connect api.nuget.org:443 2>/dev/null | awk '/-----BEGIN CERTIFICATE-----/, /-----END CERTIFICATE-----/' >> /usr/local/share/ca-certificates/ca-certificates.crt
RUN update-ca-certificates
# <<<< in corporate network use to fic ssl proxy cret error
# COPY src/WebApi.BaseExample/WebApi.BaseExample.csproj src/WebApi.BaseExample/
# COPY src/StarWars.Repository.Mock/StarWars.Repository.Mock.csproj src/StarWars.Repository.Mock/
# COPY src/StarWars.Models/StarWars.Models.csproj src/StarWars.Models/
# COPY src/StarWars.Repository.EF6/StarWars.Repository.EF6.csproj src/StarWars.Repository.EF6/
# COPY src/StarWars.Implementation/StarWars.Implementation.csproj src/StarWars.Implementation/
# RUN dotnet restore src/WebApi.BaseExample/WebApi.BaseExample.csproj
# COPY . .
# RUN dotnet build WebApi.BaseExample.csproj -c Release -o /app
COPY ./src/ /app/src/
COPY ./*.sln /app/
COPY ./Directory.Build.props /app/
COPY ./nuget.config /app/
WORKDIR /app/src/WebApi.BaseExample
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out


FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "WebApi.BaseExample.dll"]
