FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /App

# Copy everything
COPY ./ ./
#COPY ["EatonAPI", "EatonAPI"]
#COPY ["EatonAPI.Database", "EatonAPI.Database"]

# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out   

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTPP_PORT=8080

WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "EatonAPI.dll"]
