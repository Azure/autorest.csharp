#!/bin/bash -xe

OUTPUT_PATH=${ENV_OUTPUT_PATH}
NAMESPACE=${ENV_NAMESPACE}
INPUT_PATH=./input/swagger.yaml

mkdir -p input
rm -rf input/*
rm -rf $OUTPUT_PATH/*
curl -o $INPUT_PATH --insecure ${ENV_YML_FILE_URL}

eolConverter "./input/swagger.yaml"

if [ "$ENV_USE_OPENAPI_V3" = "true" ]; then
  if [ "$ENV_USE_DATETIMEOFFSET" = "true" ]; then
    autorest --v3 --use=/app --csharp --output-folder=$OUTPUT_PATH --namespace=$NAMESPACE --input-file=$INPUT_PATH --add-credentials --use-datetimeoffset --version=3.0.6274
  else
    autorest --v3 --use=/app --csharp --output-folder=$OUTPUT_PATH --namespace=$NAMESPACE --input-file=$INPUT_PATH --add-credentials --version=3.0.6274
  fi
else
  if [ "$ENV_USE_DATETIMEOFFSET" = "true" ]; then
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
    <add key="Klondike" value="https://bk-lib-nuget.agodadev.io/api/odata" />
    <add key="Agoda NuGet" value="http://repo.hkg.sdlc.agoda.local/artifactory/api/nuget/agoda-nuget" />
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

dotnet pack $OUTPUT_PATH/$NAMESPACE.csproj -p:PackageVersion=$ENV_VERSION

if [ "$ENV_SHOULD_PUSH_NUGET" = "true" ]; then
  dotnet nuget push $OUTPUT_PATH/bin/Debug/$NAMESPACE.$ENV_VERSION.nupkg -k $ENV_NUGET_KEY -s https://hk-lib-nuget.agodadev.io/api/odata
else
  echo "Nuget is not pushed because ENV_SHOULD_PUSH_NUGET is set to $ENV_SHOULD_PUSH_NUGET"
fi
