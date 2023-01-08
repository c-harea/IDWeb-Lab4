FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Rocky/. ./Rocky/
COPY Rocky.UnitTests/. ./Rocky.UnitTests/
RUN dotnet restore

# copy everything else and build app

WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./

#EXPOSE 5000

ENTRYPOINT ["dotnet", "Rocky.dll"]