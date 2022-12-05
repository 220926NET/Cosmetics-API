#build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

WORKDIR /source

COPY ./ECommerce.API .

RUN dotnet restore "./ECommerce.API.sln"

RUN dotnet publish "./ECommerce.API.sln" -c release -o /app --no-restore

#Serve stage

FROM  mcr.microsoft.com/dotnet/sdk:6.0-focal

WORKDIR /app

COPY --from=build /app ./

EXPOSE 5000

ENV \
    ASPNETCORE_URLS=http://+:5000 \
    ASPNETCORE_HTTP_PORT=http://+:5000
    
ENTRYPOINT ["dotnet", "ECommerce.API.dll"]