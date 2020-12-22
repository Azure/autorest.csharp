# <img align="center" src="../images/logo.png">  Generating C# Clients Outside of the azure-sdk-for-net Repo

You can run AutoRest outside of the [`azure-sdk-for-net`][azure_sdk_for_net] repo as well, there just aren't as many customizations possible.

1. Add the `http://azuresdkartifacts.blob.core.windows.net/azure-sdk-tools/index.json` feed to your NuGet.config:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="Azure SDK Tools" value="https://azuresdkartifacts.blob.core.windows.net/azure-sdk-tools/index.json" protocolVersion="3" />
  </packageSources>
</configuration>
```

2. Add a package reference to `AutoRest.CSharp` version `1.0.0-alpha.20201013.3` or later:

```xml
<PackageReference Include="AutoRest.CSharp" Version="1.0.0-alpha.20201013.3" />
```

3. Add an `autorest.md` configuration file pointing to your swagger file. You want this file to reside on the same level you want your `Generated` code folder to reside.

~~~ markdown
``` yaml
input-file:
- $(this-folder)/swagger.json
# - http://example.com/swagger.json
```
~~~

Or reference an existing configuration file:
~~~ markdown
``` yaml
require: http://example.com/readme.md
```
~~~

4. Run `dotnet build /t:GenerateCode` in the directory that contains your `.csproj` file.

<!-- LINKS -->
[azure_sdk_for_net]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk