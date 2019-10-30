#!/bin/bash -xe

OUTPUT_PATH=${ENV_OUTPUT_PATH}
NAMESPACE=${ENV_NAMESPACE}
INPUT_PATH=./input/swagger.yml

mkdir input
curl -o $INPUT_PATH ${ENV_YML_FILE_URL}

autorest --use=/app --csharp --output-folder=$OUTPUT_PATH --namespace=$NAMESPACE --input-file=$INPUT_PATH

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
dotnet add $OUTPUT_PATH/$NAMESPACE.csproj package Microsoft.Rest.ClientRuntime -v 2.3.12
dotnet add $OUTPUT_PATH/$NAMESPACE.csproj package Agoda.Frameworks.Http.AutoRestExt -v 2.0.71
rm $OUTPUT_PATH/Class1.cs

dotnet pack $OUTPUT_PATH/$NAMESPACE.csproj -p:PackageVersion=$ENV_VERSION

# dotnet nuget push -s https://bk-lib-nuget.agodadev.io/api/symbols

dotnet nuget push $OUTPUT_PATH/bin/Debug/$NAMESPACE.$ENV_VERSION.nupkg -k $ENV_KEY -s https://bk-lib-nuget.agodadev.io/api/odata

