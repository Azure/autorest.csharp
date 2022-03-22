# Management plane SDK generator - how it works and its corresponding configurations

## Resource hierarchy in management plane SDK

For the basic management plane SDK concepts, please refer the detailed document [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/README.md#key-concepts) first.

A resource is usually represented by three classes in the generated SDK: a `[Resource]Data` class, a `[Resource]Resource` class, and a `[Resource]Collection` class.

### `[Resource]Data` class

This class represents the "model" of the resource, and it corresponds to a model definition in the swagger, usually with the same name by trimming the word `Data` off.

### `[Resource]Resource` class

This class represents the a full resource client object which contains a `Data` property exposing the details as a `[Resource]Data` type.

### `[Resource]Collection` class

This class represents the operations you can perform on a collection of resources belonging to a specific parent resource. This object provides most of the logical collection operations.

| Collection Behavior | Collection Method |
| :--- | :--- |
| Iterate/List | GetAll() |
| Index | Get(string name) |
| Add | CreateOrUpdate(string name, [Resource]Data data) |
| Contains | Exists(string name) |
| TryGet | GetIfExists(string name) |

The `[Resource]Collection` class is designed to implement `IEnumerable<[Resource]Resource>` and `IAsyncEnumerable<[Resource]Resource>` interfaces, therefore the `GetAll()` method with no required parameters are required on this class for the generator. In rare cases, this rule is violated and a `list-exception` configuration will be required to temporarily solve this. See see [list exception](#list-exception) section for details.

The parent resource of this resource will carry all the methods to get its child resources by returning its corresponding collection. For instance, on the resource of `VirtualNetworkResource`, you will find a method `GetSubnets` which returns a `SubnetCollection` to represent a collection of `SubnetResource`:
```csharp
public partial class VirtualNetworkResource : ArmResource
{
    public virtual SubnetCollection GetSubnets()
    {
        /* ... */
    }
}
```

For the cases that the parent resource is not in the same RP, the "get child resource method" will be put in an extension class. For instance, the parent resource of `VirtualNetworkResource` is the resource group, and you will find an extension method of `ResourceGroupResource` in the `Azure.ResourceManager.Network` package returning `VirtualNetworkCollection` like this:
```csharp
public static partial class NetworkExtensions
{
    public static VirtualNetworkCollection GetVirtualNetworks(this ResourceGroupResource resourceGroup)
    {
        /* ... */
    }
}
```

## How does the generator identify a resource

The management .Net SDK generates the resources with hierarchy, therefore the code generator makes quite a few modification on the code model input from the `modelerfour`. To better recognize the hierarchical structure of resources, the the code generator will generate everything from the point of view of request paths, instead of operation groups. Therefore quite a few new configurations are introduced to tweak the behavior how the generator identifies the resource classes as well as the hierarchy.

The management generator will first go through all the operations and categorize them by resources, then calculate hierarchical structures on them.

The management generator does not categorize the operations by operation groups, instead, it categorizes the operations by "operation sets". An operation set is a set of operations with the same request path. For instance, all the operations under the request path `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{name}` will be an operation set.

An operation set is marked as a resource, only when the following conditions meet:

1. The request path has even segments starting from the last `providers` segment. For instance, `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{name}` meets this requirement, but `/{scope}/providers/Microsoft.Authorization/policyAssignments` does not.
1. The operation set must have a GET request.
1. The schema of `200` response of the GET request is compatible to ARM's resource definition - it must have `id`, `type` and `name` (all of them are strings).

If all the above conditions are met, this operation set will be marked as a "resource" by management generator, and the schema of the `200` response of the GET request will be its corresponding `ResourceData`.

We have multiple ways to tweak the criteria of identifying resources, please see [change resource data](#change-resource-data) section.

The name of a resource usually is derived from the name of the resource data, but with some exceptions. Please see [change resource name](#change-resource-name) for more details.

// TODO -- add more links here

## How does the generator build hierarchical structure of resources

After the management generator goes through all the resources, it is ready to build the hierarchy of resources.

Despite the package `Azure.ResourceManager` is also mostly generated by the same generator, the generator has 5 built-in resources as parent fallbacks when the parent of a resource is not in this RP (The most common case of this is the `ResourceGroup` which is a parent of a lot of resources):

1. `Azure.ResourceManager.Tenant`
1. `Azure.ResourceManager.Subscription`
1. `Azure.ResourceManager.ResourceGroup`
1. `Azure.ResourceManager.ManagementGroup`
1. `Azure.ResourceManager.ArmResource`

For each operation set, the management generator will try to find its parent, by going through all the existing resources to see if the request path of another resource is the prefix of this operation set. After going through all of the resources, we should get a list of candidates of resources that can be the parent or grand parent of this operation set, it will take the longest path as its direct parent. If none found, the generator will try the 5 built-in resources in this order:
1. `ResourceGroup`
1. `Subscription`
1. `ManagementGroup`
1. `ArmResource`
1. `Tenant`

Now every operation set (and it corresponds to a resource) will have a parent and only have one parent, the resource hierarchy has been built.

### Resource types and expanded resources

Once an operation set is marked as a resource, resource type is able to calculate. In general, the resource type of a resource is calculated in this way:

1. Take everything after the last `providers` segment. Anything before the last `providers` segment will be regarded as the `scope` of this resource. For instance, for request path `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{groupName}/hosts/{hostName}`, we get `providers/Microsoft.Compute/hostGroups/{groupName}/hosts/{hostName}`
1. Take the provider namespace as the namespace of the resource type, in this case, we get `Microsoft.Compute`, and we have `hostGroups/{groupName}/hosts/{hostName}` left.
1. Take all the segments with even indices in whatever left in last step. In this case, we get `hostGroups` and `hosts`.
1. Put them all together and we get the resource type of this resource, `Microsoft.Compute/hostGroups/hosts`.

In the design of .Net management SDK, one resource must only have one constant resource type, therefore the generator will check if the resource type which it calculates is a constant, if the resource type is not a constant, it means that the swagger might be using one request path to represent a set of similar resources with different resource types. If this happens, the generator will try to expand the resource types into multiple constant resource types.

For instance, if the above procedure is applied on this request path `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}`, it produces the resource type `Microsoft.Network/dnsZones/{recordType}` which contains a variable in it and is not a constant. If this happens, the generator will try to expand it into multiple constant resource types. This requires the variables in the resulted resource type to be an enum type, if this condition is not met, the generator will throw exceptions for you to resolve by adding configuration/directives.

We have some ways to change the resource type of a resource, please see [changing the resource type](Changing-the-resource-type) section.

### Singleton resources

Some resources are recognized as singleton resources automatically by the generator, for instance, a request path `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccount/{accountName}/blobServices/default` is a singleton resource with the name `default` and its parent is `StorageAccount`.

The generator will mark a resource as a singleton, when its request path subtracted by the request path of its parent is a constant. For example, the resource with request path `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccount/{accountName}/blobServices/default` has a parent of `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccount/{accountName}`, if you subtract them, you will get `blobServices/default` which is a constant, therefore the resource `BlobService` is a singleton resource.

When a resource is marked as a singleton resource, it will not have its corresponding `[Resource]Collection` class, only have `[Resource]Resource` class and `[Resource]Data` class. The method to get a singleton resource on its parent will be called as `Get[Resource]` in singular form, like

```csharp
public partial class StorageAccount : ArmResource
{
    public virtual BlobServiceResource GetBlobService()
    {
        /* ... */
    }
}
```

If you want to change the behavior how the generator identifies singleton resources, please see [Singleton resources](Singleton-resources) section

## Management plane configurations

### Change resource data

The configuration `request-path-to-resource-data` is a dictionary, its key is a request path, and the corresponding value is a schema name.

This configuration has two functionalities:
1. If the request path is not a resource, the generator will mark it as a resource.
1. The corresponding resource data will be the schema specified by the value.

#### Change the resource data to another schema

<details>

For instance, if we have this swagger:

```json
"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}": {
    "get": {
        "operationId": "DatabaseAccounts_Get",
        "parameters": [
            {
                "$ref": "../../../../../common-types/resource-management/v1/types.json#/parameters/SubscriptionIdParameter"
            },
            {
                "$ref": "../../../../../common-types/resource-management/v1/types.json#/parameters/ResourceGroupNameParameter"
            },
            {
                "$ref": "#/parameters/accountNameParameter"
            },
            {
                "$ref": "../../../../../common-types/resource-management/v1/types.json#/parameters/ApiVersionParameter"
            }
        ],
        "responses": {
            "200": {
                "description": "The database account properties were retrieved successfully.",
                "schema": {
                    "$ref": "#/definitions/DatabaseAccount"
                }
            }
        }
    },
    "put": {
        "operationId": "DatabaseAccounts_CreateOrUpdate",
        "x-ms-long-running-operation": true,
        "parameters": [
            {
                "$ref": "../../../../../common-types/resource-management/v1/types.json#/parameters/SubscriptionIdParameter"
            },
            {
                "$ref": "../../../../../common-types/resource-management/v1/types.json#/parameters/ResourceGroupNameParameter"
            },
            {
                "$ref": "#/parameters/accountNameParameter"
            },
            {
                "$ref": "../../../../../common-types/resource-management/v1/types.json#/parameters/ApiVersionParameter"
            },
            {
                "name": "createUpdateParameters",
                "in": "body",
                "required": true,
                "schema": {
                    "$ref": "#/definitions/DatabaseAccountCreateUpdateParameters"
                },
                "description": "The parameters to provide for the current database account."
            }
        ],
        "responses": {
            "200": {
                "description": "The database account create or update operation will complete asynchronously.",
                "schema": {
                    "$ref": "#/definitions/DatabaseAccount"
                }
            }
        }
    },
    "delete": {
        "operationId": "DatabaseAccounts_Delete",
        "x-ms-long-running-operation": true,
        "parameters": [
            {
                "$ref": "../../../../../common-types/resource-management/v1/types.json#/parameters/SubscriptionIdParameter"
            },
            {
                "$ref": "../../../../../common-types/resource-management/v1/types.json#/parameters/ResourceGroupNameParameter"
            },
            {
                "$ref": "#/parameters/accountNameParameter"
            },
            {
                "$ref": "../../../../../common-types/resource-management/v1/types.json#/parameters/ApiVersionParameter"
            }
        ],
        "responses": {
            "202": {
                "description": "The database account delete operation will complete asynchronously."
            },
            "204": {
                "description": "The specified account does not exist in the subscription."
            }
        }
    }
}
```

The generated code will have a resource `DatabaseAccountResource`, `DatabaseAccountCollection`, and `DatabaseAccountData`. And if you want to assign another schema in these request as a resource data, you could add this configuration:
```
request-path-to-resource-data:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}: DatabaseAccountCreateUpdateParameters
```

As a result, the resource will name after the new resource data, and now you will have `DatabaseAccountCreateUpdateParametersResource`, `DatabaseAccountCreateUpdateParametersCollection`, and `DatabaseAccountCreateUpdateParametersData`.

</details>

#### Change a non-resource data to be a resource

<details>

You can mark a non-resource request path as a resource, for instance, if we have this swagger:

```json
"/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}": {
    "get": {
    "operationId": "SharedGalleries_Get",
    "description": "Get a shared gallery by subscription id or tenant id.",
    "parameters": [
        {
            "$ref": "#/parameters/SubscriptionIdParameter"
        },
        {
            "$ref": "#/parameters/LocationNameParameter"
        },
        {
            "name": "galleryUniqueName",
            "in": "path",
            "required": true,
            "type": "string",
            "description": "The unique name of the Shared Gallery."
        },
        {
            "$ref": "#/parameters/ApiVersionParameter"
        }
    ],
    "responses": {
        "200": {
            "description": "OK",
            "schema": {
                "$ref": "#/definitions/SharedGallery"
            }
        },
        "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
                "$ref": "#/definitions/CloudError"
            }
        }
    }
}
```
This request path looks like a resource, but unfortunately its corresponding schema `SharedGallery` does not have all the three properties required by a resource, `id`, `type` and `name`. Since this is a non-resource, this operation will be generated into the extension class, like this:
```csharp
public static partial class ComputeExtensions
{
    public static Response<SharedGallery> GetSharedGallery(this ResourceGroupResource resourceGroup, string location, string galleryUniqueName, CancellationToken cancellationToken = default)
    {
        /* ... */
    }
}
```

But we still could add the `request-path-to-resource-data` configuration:
```
request-path-to-resource-data:
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}: SharedGallery
```
to mark it as a resource, and assign the schema `SharedGallery` as its resource data. In this way, we will get the `SharedGalleryResource`, `SharedGalleryCollection` and `SharedGalleryData` (which is the model generated from schema `SharedGallery`) like normal resources. In this way, the Id of this non-resource will be automatically constructed by the SDK using its own request path.

</details>

### Change resource name

In most cases, a resource class will share the same name as the resource data class, and you will have the triplet of `[Resource]Resource`, `[Resource]Collection`, and `[Resource]Data`.

But if the RP is complicated, there might be multiple resources sharing the same resource data schema. If this happens, the generator has multiple strategies to generate unique names for all those resources in order to make sure the generated code could properly compile. These auto-generated names might not be ideal, and you might need the `request-path-to-resource-name` configuration to customize the resource names.

For instance, we have a resource `AvailabilitySetResource`, `AvailabilitySetCollection` and `AvailabilitySetData`. If we add this configuration:
```
request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{name}: Something
```
Now you will have `SomethingResource` instead of `AvailabilitySetResource`, `SomethingCollection` instead of `AvailabilitySetCollection`, but still have the original resource data `AvailabilitySetData` because this configuration only change the corresponding resource name and the collection name (if it has a collection).

### Changing the criteria of ARM resources

// TODO -- need to revise this

By default, we will only mark a request path as resource, if its schema meets ARM's resource criteria, the model must have `id`, `type` and `name`. You can use the `resource-model-requires-type` and `resource-model-requires-name` configuration to loose this criteria.

For instance

```
resource-model-requires-type: false
```

This configuration will globally change the criteria of a resource model to only have `id` and `name`.

### Changing the resource type

The .Net management plane SDK requires a resource to have its own resource type, and the generator will automatically calculate the corresponding resource type from the request path of that resource. There are situations that the resource type cannot be calculated, in this case, you need to use the `request-path-to-resource-type` configuration to assign a resource type to the resource. For instance

```
request-path-to-resource-type:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{name}: Microsoft.Compute/virtualNetworks
```

This will change the resource type of the `AvailabilitySet` from the default `Microsoft.Compute/availabilitySets` to `Microsoft.Compute/virtualNetworks`.

### Mark a request path is a non-resource

By default the generator will mark all the request paths that meet the criteria as resources. If there is a path you suppose it should be pure data instead of an ARM resource, you can use the `request-path-is-non-resource` configuration.

For instance,

```
request-path-is-non-resource:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{name}
```

This configuration will mark the availability set request paths as a non-resource. The operations of non-resources will append to their corresponding parent.

### Changing parent of the request paths

By default, the generator will automatically find the parent of a request path, and append the operations of a non-resource to their corresponding parents.

You can manually assign the parent of an operation using the configuration `request-path-to-parent` which is a dictionary from the request path of you want to change, to the request path you want to be the new parent. For instance

```
request-path-to-parent:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
```

This configuration will change the parent of `ManagementPolicy` from its default parent `StorageAccount` to the new parent `ResourceGroup`.

### Singleton resources

Some resources are automatically recognized as singleton resources. If a resource is generated as a singleton resource, it will not have a corresponding collection class.

By default the generator will make a resource as a singleton, if it finds the extra part of its request path comparing to its parent is a constant.

Sometimes, you might need to manually make a resource singleton due to some issues in the swagger, you need to add the corresponding entries into the `request-path-to-singleton-resource` configuration. This configuration is a map from the request path to the extra segments of the resource identifier of the singleton resource.

For instance,
```
request-path-to-singleton-resource:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}: managementPolicies/default
```

This will mark the resource with path of `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}` as singleton resource, and its ID will be its parent's ID appending `managementPolicies/default`.

### Changing the name of operations

We provide a new configuration `override-operation-name` to assign new names to operations, which is a dictionary from the operationId of the operation to its new name. For instance,

```
override-operation-name:
  RecordSets_ListByDnsZone: GetRecordSets
  RecordSets_ListAllByDnsZone: GetAllRecordSets
```

### Resource collection should have a `GetAll` method

From .Net convention, a resource collection class needs to implement the `IEnumerable<>` interface since the name of them ends with the word `Collection`. This will require resource collection classes to have a `GetAll` method to provider the `Enumerator` to the caller. If there is a collection without `GetAll` method, the generator will throw an error.

If you are sure this collection really do not have a `GetAll` method and want to proceed the generation, you can add the corresponding request path of the resource collection which can be found in the error message, to the `list-exception` configuration, like

```
list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{name}
```

### Scope resources

Some resources are scope resources, which means that these resources can be created under different scopes, like subscriptions, resource groups, management groups, etc. In the swagger, we currently do not have an extension which assigns which type of resources can be the scope of this resource, therefore we add a configuration in our generator `request-path-to-scope-resource-types` for this new information.

By default, the generator will recognize the first parameter in request path as a scope parameter if the parameter has `x-ms-skip-url-encoding: true` on it, and the generator will generate the resource assuming the scope can be anything. To assign specific resource types to this scope, you can use the following configuration:

```
request-path-to-scope-resource-types:
  /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}:
    - subscriptions
    - resourceGroups
    - managementGroups
    - tenant
```

This configuration add the constraint that the scope can only be subscription, resource group, management group or tenant. Other resources cannot be the scope of this resource `Deployment`.

### Management debug options

A debug configuration is also introduced to show some extra information in the generated code. Usage:

```
mgmt-debug:
  show-request-path: true
  suppress-list-exception: true
```

The configuration `show-request-path` will add comments in front of every operation with the request path and operation Id, which is useful when you are making customization to the generated SDK.

The configuration `suppress-list-exception` will suppress all the exceptions about the collection class without a `GetAll` method.
