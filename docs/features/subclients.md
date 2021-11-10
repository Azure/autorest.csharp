## Operation groups

autorest requires each operation in swagger file to define a unique string parameter `operationId` (this is different from [official OpenAPI specification](https://swagger.io/docs/specification/paths-and-operations/#operationId)). If parameter value contains underscore, then part after underscore will be treated as operation name, and part before underscore will be treated as the name of the operation group to which this operation belongs. Otherwise, operation will be attributed to the group without a name::

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

For each operation group, **autorest.csharp** generates individual client type called using `$"{operationGroups.language.default.name}Client"` format when group has a name or `$"{language.default.name}Client"` format when group name is empty.

```cs
public partial class NamedGroupClient
{
    public virtual async Task<Response> Op1Async(RequestContext options = null);
    public virtual Response Op1(RequestContext options = null);
}
```
```cs
public partial class MyServiceClient
{
    public virtual async Task<Response> Op2Async(RequestContext options = null);
    public virtual Response Op2(RequestContext options = null);
}
```

## Client hierarchy

Each client can be made a subclient of another client (without circular dependency) using `CodeGenClientAttribute.ParentClient` parameter. Since `CodeGenClientAttribute` is applied to the client type, user will explicitly specify new client type name. According to [guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-subclients), type should have a name without "Client" suffix and an internal constructor. **autorest.csharp** will add a factory method to the type, specified in `ParentClient`.

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

## Single top-level client

With multiple service clients it may be better to group them all under one top-level client to simplify discoverability. With configuration setting `--single-top-level-client=true`, **autorest.csharp** generates top level client for operation group that has empty name, and all clients for named operation groups become its subclients. Generated subclients are called using `$"{operationGroups.language.default.name}"` format if all operation group names have at least two words. If any of the named operation groups have one word name, `$"{language.default.name}{operationGroups.language.default.name}"` format will be used. 

```cs
public partial class MyServiceClient
{
    public virtual async Task<Response> Op2Async(RequestContext options = null);
    public virtual Response Op2(RequestContext options = null);

    public virtual NamedGroup GetNamedGroup();
}
```
```cs
public partial class NamedGroup
{
    public virtual async Task<Response> Op1Async(RequestContext options = null);
    public virtual Response Op1(RequestContext options = null);
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

## Resource clients [NOT IMPLEMENTED, DESIGN ONLY]

Operations inside one operation group may contain methods bound to a specific resource. When some of the operations have path parameter with  `"x-ms-parameter-resource-name": true`, operation group has non-empty name and client for that operation group is a subclient (either `--single-top-level-client=true` or `CodeGenClientAttribute.ParentClient` is set), **autorest.csharp** generates public get-only property initialized from subclient internal constructor to preserve value for said parameter and uses it for all operation in the operation group that have that parameter in their path. For all operations in the operation group that don't have said parameter, it is assumed that they aren't bound to a specific value of resource, hence **autorest.csharp** generates methods for these operations in parent client rather than in subclient. 

```js
"paths": {
  "/collections/{collectionName}": {
    "get": {
      "operationId": "Collections_GetCollection",
      "parameters": [
        {
          "$ref": "#/parameters/CollectionName"
        }
      ]
    },
    "put": {
      "operationId": "Collections_CreateOrUpdateCollection",
      "parameters": [
        {
          "$ref": "#/parameters/CollectionName"
        }
      ]
    }
  },
  "/collections": {
    "get": {
      "operationId": "Collections_GetCollections"
    }
  }
},
"parameters": { 
  "CollectionName": {
    "name": "collectionName",
    "in": "path",
    "required": true,
    "type": "string",
    "x-ms-parameter-resource-name": true
  }
}
```

```cs
public partial class PurviewAccountsClient
{
    public virtual AsyncPageable<BinaryData> GetCollectionsAsync(string skipToken = null, RequestContext options = null);
    public virtual Pageable<BinaryData> GetCollections(string skipToken = null, RequestContext options = null);

    public virtual PurviewAccountCollections GetPurviewAccountCollections(string collectionName)
}
```

```cs
public partial class PurviewAccountCollections
{
    public string CollectionName { get; }

    public virtual async Task<Response> GetCollectionAsync(RequestContext options = null);
    public virtual Response GetCollection(RequestContext options = null);

    public virtual async Task<Response> CreateOrUpdateCollectionAsync(RequestContent content, RequestContext options = null);
    public virtual Response CreateOrUpdateCollection(RequestContent content, RequestContext options = null);
}
```

If more than one parameter is marked with `"x-ms-parameter-resource-name": true`, then `autorest` will report an error.