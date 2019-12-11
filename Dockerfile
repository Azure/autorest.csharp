FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env

# Replace shell with bash so we can source files
RUN rm /bin/sh && ln -s /bin/bash /bin/sh

ENV HTTP_PROXY=http://hk-agcprx-2000.corpdmz.agoda.local:8080 \
    HTTPS_PROXY=http://hk-agcprx-2000.corpdmz.agoda.local:8080 \
    NO_PROXY="localhost,127.0.0.0/8,10.0.0.0/8,169.0.0.0/8,172.16.0.0/12,192.168.0.0/16,.local,*.agodadev.io, smapi_mock, kafka" \
	http_proxy=http://hk-agcprx-2000.corpdmz.agoda.local:8080 \
    https_proxy=http://hk-agcprx-2000.corpdmz.agoda.local:8080 \
    no_proxy="localhost,127.0.0.0/8,10.0.0.0/8,169.0.0.0/8,172.16.0.0/12,192.168.0.0/16,.local,*.agodadev.io, smapi_mock, kafka"

RUN apt-get update && apt-get install -y curl libunwind8 libunwind-dev 

# Set debconf to run non-interactively
RUN echo 'debconf debconf/frontend select Noninteractive' | debconf-set-selections

# Install base dependencies
RUN apt-get update && apt-get install -y -q --no-install-recommends \
        apt-transport-https \
        build-essential \
        ca-certificates \
        curl \
        git \
        libssl-dev \
        wget \
    && rm -rf /var/lib/apt/lists/*

ENV NVM_DIR /usr/local/nvm
ENV NODE_VERSION 10.15.0

# # Install nvm with node and npm
RUN curl https://raw.githubusercontent.com/creationix/nvm/v0.24.0/install.sh | bash \
    && . $NVM_DIR/nvm.sh \
    && nvm install $NODE_VERSION \
    && nvm alias default $NODE_VERSION \
    && nvm use default \
    && nvm \
    && node -v \

ENV NODE_PATH $NVM_DIR/versions/node/v$NODE_VERSION/lib/node_modules
ENV PATH $NVM_DIR/versions/node/v$NODE_VERSION/bin:$PATH

RUN npm config set strict-ssl false
RUN node -v
RUN npm install npm@6.12.0 -g
RUN npm install -g autorest
RUN npm i -g eol-converter-cli

COPY package.json /tmp/package.json
RUN cd /tmp && npm install
RUN mkdir -p /app && cp -a /tmp/node_modules /app/

RUN apt-get update && apt-get install -y locales && rm -rf /var/lib/apt/lists/* \
	&& localedef -i en_US -c -f UTF-8 -A /usr/share/locale/locale.alias en_US.UTF-8
ENV LANG en_US.utf8

WORKDIR /app

COPY ./src/*.csproj ./

COPY . ./
RUN dotnet sln remove "agoda.csharp.client.test/agoda.csharp.client.test.csproj"
RUN dotnet restore
RUN dotnet build
COPY README.md /app/README.md

RUN mkdir -p /output
