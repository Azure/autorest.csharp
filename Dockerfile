FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env

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
RUN mkdir -p /tmp/out
RUN dotnet publish -c Release -o /tmp/out
COPY build/autorestRunner.json /tmp/out/package.json
COPY README.md /tmp/out/README.md
RUN autorest --use=/tmp/out --csharp --input-file=./swagger/swagger.json --output-folder=./agoda.csharp.client.test/Client --namespace=Agoda.Csharp.Client.Test

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 

RUN apt-get update && apt-get install -y curl libunwind8 
# NodeJS
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash - && \
        apt-get update && apt-get install -y nodejs && \
        npm install npm@latest -g

RUN npm install -g autorest 

RUN mkdir /app
WORKDIR /app
COPY --from=build-env /tmp/out .
RUN sed -ir 's/\/tmp\/out/\/app/gi' /app/package.json
ENTRYPOINT ["autorest", "--use=/app"]
# ENTRYPOINT tail -f /dev/null

