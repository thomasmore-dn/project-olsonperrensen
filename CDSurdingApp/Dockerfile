# build: docker build --rm -t api:latest .
# run: docker run --rm -p 8000:5000 ` -e DOTNET_URLS=http://+:5000 api
# Building the project
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./CDSurdingAPI/CDSurdingAPI.csproj" --disable-parallel
RUN dotnet publish "./CDSurdingAPI/CDSurdingAPI.csproj" -c release -o /app --no-restore


# Serving the project
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 7085

ENTRYPOINT [ "dotnet","CDSurdingAPI.dll" ]