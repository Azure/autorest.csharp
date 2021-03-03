
# Agoda-autorest

This is the autorest extension for agoda which uses the roundrobin client.
The [AutoRest](https://github.com/Azure/autorest) tool generates client libraries for accessing RESTful web services.

### Usage
#### Test on Local
- Clone this repo
- Modify docker-compose.yml to
```yaml
version: "3"

services:
  autorest-gen: 
    ### Following commented out lines are helpful for local testing
    ### Build image from local docker file
    build: .
    ### Get generated code to local to view .cs and .nupkg file
    ### you can change .nupkg to .zip to view generated .dll file inside the package
    volumes:
      - C:/xxxxxxxxxxx/output:/app/output
      - C:/xxxxxxxxxxx/input:/app/input
    environment: 
      #ENV_YML_FILE_URL: ${SWAGGER_URL}
      ENV_OUTPUT_PATH: "/app/output"
      #ENV_NAMESPACE: ${NAMESPACE} 
      #ENV_VERSION: ${VERSION}
      #ENV_NUGET_KEY: ${NUGET_KEY}
      #ENV_SHOULD_PUSH_NUGET: ${SHOULD_UPLOAD_TO_NUGET} 
      #ENV_USE_DATETIMEOFFSET: ${USE_DATETIMEOFFSET}
      #ENV_USE_OPENAPI_V3: ${USE_USE_OPENAPI_V3}
      # To test on local
      ENV_YML_FILE_URL: "url to swagger.json/yaml"
      ENV_NAMESPACE: YourNamespace
      ENV_VERSION: 2.0.25
      ENV_NUGET_KEY: ""
      ENV_SHOULD_PUSH_NUGET: "false"
      ENV_USE_DATETIMEOFFSET: "false"
    command: /app/build/create-project.sh
```
- run docker-compose up --build
- check the result at the location you set in the volume
