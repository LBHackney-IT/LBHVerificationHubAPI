FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out


COPY newrelic ./newrelic

CMD ASPNETCORE_URLS=http://+:${PORT:-3000} dotnet ./out/LBHVerificationHubAPI.dll
EXPOSE ${PORT:-3000}