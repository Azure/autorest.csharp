FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env

ENV HTTP_PROXY=http://hk-agcprx-2000.corpdmz.agoda.local:8080 \
    HTTPS_PROXY=http://hk-agcprx-2000.corpdmz.agoda.local:8080 \
    NO_PROXY="localhost,127.0.0.0/8,10.0.0.0/8,169.0.0.0/8,172.16.0.0/12,192.168.0.0/16,.local,*.agodadev.io, smapi_mock, kafka" \
	http_proxy=http://hk-agcprx-2000.corpdmz.agoda.local:8080 \
    https_proxy=http://hk-agcprx-2000.corpdmz.agoda.local:8080 \
    no_proxy="localhost,127.0.0.0/8,10.0.0.0/8,169.0.0.0/8,172.16.0.0/12,192.168.0.0/16,.local,*.agodadev.io, smapi_mock, kafka"

RUN apt-get update && apt-get install -y curl libunwind8 libunwind-dev 

# NodeJS
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash - && \
	apt-get update && apt-get install -y nodejs && \
	npm install npm@latest -g

RUN npm install -g autorest

COPY package.json /tmp/package.json
RUN cd /tmp && npm install
RUN mkdir -p /app && cp -a /tmp/node_modules /app/

WORKDIR /app

COPY ./src/*.csproj ./

COPY . ./
RUN dotnet sln remove "agoda.csharp.client.test/agoda.csharp.client.test.csproj"
RUN dotnet restore
RUN dotnet build
COPY build/autorestRunner.json /app/package.json
COPY README.md /app/README.md

RUN mkdir -p /output

