#!/bin/bash -xe

OUTPUT_PATH=/src/output
NAMESPACE=${CLIENT_NAMESPACE}
INPUT_PATH=/src/input/swagger.yaml
SWAGGER_FILE=${SPEC_FILE}

if [ -z "$SWAGGER_FILE" ]; then
  SWAGGER_FILE=/src/input/swagger.json
fi

mkdir -p input
rm -rf input/*
rm -rf $OUTPUT_PATH/*

if [[ $SWAGGER_FILE == http* ]]; then
echo "Im downloading the swagger spec from a remote Url $SWAGGER_FILE to local path $INPUT_PATH"
  curl --insecure -o $INPUT_PATH $SWAGGER_FILE
else
  INPUT_PATH=$SWAGGER_FILE
  echo "Im setting spec $INPUT_PATH to lcoal path $SWAGGER_FILE"
fi

eolConverter "/src/input/swagger.yaml"

if [ "$USE_OPENAPI_V3" = "true" ]; then
  if [ "$USE_DATETIMEOFFSET" = "true" ]; then
    autorest --v3 --use=/app --csharp --output-folder=$OUTPUT_PATH --namespace=$NAMESPACE --input-file=$INPUT_PATH --add-credentials --use-datetimeoffset --version=3.0.6274
  else
    autorest --v3 --use=/app --csharp --output-folder=$OUTPUT_PATH --namespace=$NAMESPACE --input-file=$INPUT_PATH --add-credentials --version=3.0.6274
  fi
else
  if [ "$USE_DATETIMEOFFSET" = "true" ]; then
    autorest --use=/app --csharp --output-folder=$OUTPUT_PATH --namespace=$NAMESPACE --input-file=$INPUT_PATH --add-credentials --use-datetimeoffset --legacy
  else
    autorest --use=/app --csharp --output-folder=$OUTPUT_PATH --namespace=$NAMESPACE --input-file=$INPUT_PATH --add-credentials --legacy
  fi
fi

dotnet new classlib -n $NAMESPACE -o $OUTPUT_PATH
cat >NuGet.config <<EOL
<?xml version="1.0" encoding="utf-8"?><configuration><activePackageSource>
<add key="All" value="(Aggregate source)" />
  </activePackageSource>
  <packageRestore>
    <add key="enabled" value="true" />
    <add key="automatic" value="True" />
  </packageRestore>
  <solution>
    <add key="disableSourceControlIntegration" value="true" />
  </solution>
  <packageSources>
    <add key="Klondike" value="https://hk-lib-nuget.agodadev.io/api/odata" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
  <packageSourceCredentials>
  </packageSourceCredentials>
</configuration>
EOL

dotnet add $OUTPUT_PATH/$NAMESPACE.csproj package Newtonsoft.Json -v 11.0.2
dotnet add $OUTPUT_PATH/$NAMESPACE.csproj package Microsoft.Rest.ClientRuntime -v 2.3.21
dotnet add $OUTPUT_PATH/$NAMESPACE.csproj package Agoda.Frameworks.Http -v 3.0.75

rm $OUTPUT_PATH/Class1.cs

dotnet pack $OUTPUT_PATH/$NAMESPACE.csproj -p:PackageVersion=$VERSION

if [ "$SHOULD_PUSH_NUGET" = "false" ]; then
  echo "Nuget is not pushed because SHOULD_PUSH_NUGET is set to $SHOULD_PUSH_NUGET , clean up will not run"
else
  dotnet nuget push $OUTPUT_PATH/bin/Debug/$NAMESPACE.$VERSION.nupkg -k $NUGET_KEY -s https://hk-lib-nuget.agodadev.io/api/odata
  rm -rf /src/output
  rm -rf /src/input
fi

