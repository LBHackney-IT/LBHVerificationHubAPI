FROM microsoft/dotnet:2.2-sdk

# disable microsoft telemetry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

WORKDIR /app

# Copy csproj and restore as distinct layers

COPY ./LBHVerificationHubAPI.sln ./
COPY ./LBHVerificationHubAPI/LBHVerificationHubAPI.csproj ./LBHVerificationHubAPI/
COPY ./LBHVerificationHubAPITest/LBHVerificationHubAPITest.csproj ./LBHVerificationHubAPITest/

RUN dotnet restore ./LBHVerificationHubAPI/LBHVerificationHubAPI.csproj
RUN dotnet restore ./LBHVerificationHubAPITest/LBHVerificationHubAPITest.csproj

# Copy everything else and build
COPY . .
RUN dotnet build -c debug -o out ./LBHVerificationHubAPITest/LBHVerificationHubAPITest.csproj

CMD dotnet test ./LBHVerificationHubAPITest/LBHVerificationHubAPITest.csproj

