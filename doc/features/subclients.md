## Operation groups

autorest requires each operation in swagger file to define a unique string parameter `operationId` (this is different from [official OpenAPI specification](https://swagger.io/docs/specification/paths-and-operations/#operationId). If parameter value contains underscore, then part after underscore will be treated as operation name, and part before underscore will be treated as the name of the operation group to which this operation belong. Otherwise, operation will be belong to the group without a name:

```js
  "paths": {
    "/namedgroup/op": {
      "get": {
        "operationId": "NamedGroup_Op1",
      }
    },
    "/nogroup/op": {
      "get": {
        "operationId": "Op2",
      }
    }
  }
```

```yaml
operationGroups:
  - !OperationGroup 
    $key: NamedGroup
    operations:
      - !Operation 
        language: !Languages 
          default:
            name: Op1
    language: !Languages 
      default:
        name: NamedGroup
  - !OperationGroup 
    $key: ''
    operations:
      - !Operation 
        language: !Languages 
          default:
            name: Op2
    language: !Languages 
      default:
        name: ''
language: !Languages 
  default:
    name: MyService
```

For each operation group, **autorest.csharp** generates individual client type called `$"{OperationGroup.language.default.name}Client"` format when group has a name or `$"{Language.Default.Name}Client"` format when group name is empty.

```cs
public partial class NamedGroupClient
{
    public virtual async Task<Response> Op1Async(RequestOptions options = null);
    public virtual Response Op1(RequestOptions options = null);
}
```
```cs
public partial class MyServiceClient
{
    public virtual async Task<Response> Op2Async(RequestOptions options = null);
    public virtual Response Op2(RequestOptions options = null);
}
```

## Client hierarchy

Each client can be made a subclient of another client (without circular dependency) using `CodeGenClientAttribute.ParentClient` parameter. Since `CodeGenClientAttribute` is applied to the client type, user will explicitly specify new client type name. According to [guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-subclients), type should have a name without "Client" suffix. **autorest.csharp** will add a factory method to the type, specified in `ParentClient`.

```cs
[CodeGenClient("CollectionsClient", ParentClient = typeof(PurviewAccountsClient), ForcePublicConstructors = true)]
public partial class PurviewAccountCollections { }
```

```cs
public partial class PurviewAccountsClient
{
    public virtual PurviewAccountCollections GetCollectionsClient(string collectionName)
    {
        if (collectionName == null)
        {
            throw new ArgumentNullException(nameof(collectionName));
        }

        return new PurviewAccountCollections(_clientDiagnostics, _pipeline, _tokenCredential, _endpoint, collectionName, _apiVersion);
    }
}
```

## Subclient caching

When subclient can be instantiated using only fields from parent client, its instance can be cached to avoid additional allocations

```cs
private volatile PurviewAccountResourceSetRules _cachedPurviewAccountResourceSetRules;

public virtual PurviewAccountResourceSetRules GetResourceSetRulesClient()
{
    return _cachedPurviewAccountResourceSetRules ??= new PurviewAccountResourceSetRules(_clientDiagnostics, _pipeline, _tokenCredential, _endpoint, _apiVersion);
}
```

## Single top-level client [NOT IMPLEMENTED, DESIGN ONLY]

With multiple service clients it may be better to group them all under one top-level client to simplify discoverability. With configuration setting `--single-top-level-client=true`, **autorest.csharp** generates top level client for operation group that has empty name, and all clients for named operation groups become its subclients:

```cs
public partial class MyServiceClient
{
    public virtual async Task<Response> Op2Async(RequestOptions options = null);
    public virtual Response Op2(RequestOptions options = null);

    public virtual NamedGroup GetNamedGroup();
}
```
```cs
public partial class NamedGroup
{
    public virtual async Task<Response> Op1Async(RequestOptions options = null);
    public virtual Response Op1(RequestOptions options = null);
}
```

If all operations have a named group, top level client becomes a factory that instantiates subclients but doesn't provide any service methods:

```cs
public class DeviceUpdateClient {
    public virtual DeviceUpdateDeployments GetDeviceUpdateDeployments();
    public virtual DeviceUpdateDevices GetDeviceUpdateDevices();
    public virtual DeviceUpdateDiagnostics GetDiagnosticsClient();
    public virtual DeviceUpdateUpdates GetDeviceUpdateUpdates();
}
```