#!/bin/bash -xe

dotnet new %Namespace%
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

dotnet add package Agoda.RoundRobin -v 1.2.24
dotnet add package Newtonsoft.Json -v 11.0.2
dotnet add package Microsoft.Rest.ClientRuntime -v 2.3.12
dotnet add package Agoda.Frameworks.Http.AutoRestExt -v 2.0.44

dotnet pack

# dotnet nuget push -s https://bk-lib-nuget.agodadev.io/api/symbols

