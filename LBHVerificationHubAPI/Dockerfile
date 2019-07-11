
FROM microsoft/dotnet:latest
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

ENV CORECLR_ENABLE_PROFILING=1 \
  CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A} \
  CORECLR_NEWRELIC_HOME=./newrelic \
  CORECLR_PROFILER_PATH=./newrelic/libNewRelicProfiler.so \
  NEW_RELIC_LICENSE_KEY="${NEW_RELIC_LICENSE_KEY}" \
  NEW_RELIC_APP_NAME="${NEW_RELIC_APP_NAME}"

COPY newrelic ./newrelic

#COPY VHub.pem /etc/ssl/certs/VHub.pem

CMD ASPNETCORE_URLS=http://+:${PORT:-80} dotnet ./out/LBHVerificationHubAPI.dll

ARG CLEAR_CORE_CERTIFICATE

RUN cd /etc/ssl/certs
RUN echo ${CLEAR_CORE_CERTIFICATE}
RUN echo ${CLEAR_CORE_CERTIFICATE} > VHub.pem

EXPOSE ${PORT:-80}