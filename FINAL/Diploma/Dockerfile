FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY Diploma.sln ./
COPY WebApi/*.csproj ./WebApi/
COPY Application/*.csproj ./Application/
COPY Domen/*.csproj ./Domen/
COPY Persistence/*.csproj ./Persistence/
COPY UnitTests/*.csproj ./UnitTests/

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_URLS=http://*:80
ENV ASPNETCORE_ENVIRONMENT=Development

USER 1000

WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "WebApi.dll"]