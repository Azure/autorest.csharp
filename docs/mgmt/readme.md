# Management plane SDK generator - how it works and its corresponding configurations

- [Understanding the Resource Hierarchy in Management Plane SDK](#resource-hierarchy-in-management-plane-sdk)
- [How does the Generator Generate the Hierarchies](#how-does-the-generator-build-hierarchical-structure-of-resources)
- [Management Plane Configurations](#management-plane-configurations)
    - [Change the Resource Data](#change-resource-data)
    - [Change the Resource Name](#change-resource-name)
    - [Change the Criteria of ARM Resources](#change-the-criteria-of-arm-resources)
    - [Change the Resource Type](#change-the-resource-type)
    - [Mark a Request Path is a Non-Resource](#mark-a-request-path-is-a-non-resource)
    - [Change Parent of Request Paths](#change-parent-of-request-paths)
    - [Change Singleton Resources](#change-singleton-resources)
    - [Change the Name of Operations](#change-the-name-of-operations)
    - [List Exception](#list-exception)
    - [Scope Resources](#scope-resources)
    - [SDK Polishing Configurations](#sdk-polishing-configurations)
    - [Management Debug Options](#management-debug-options)

## Resource hierarchy in management plane SDK

For the basic management plane SDK concepts, please refer the detailed document [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/README.md#key-concepts) first.

A resource is usually represented by three classes in the generated SDK: a `[Resource]Data` class, a `[Resource]Resource` class, and a `[Resource]Collection` class.

### `[Resource]Data` class

This class represents the "model" of the resource, and it corresponds to a model definition in the swagger, usually with the same name by trimming the word `Data` off.

### `[Resource]Resource` class

This class represents the a full resource client object which contains a `Data` property exposing the details as a `[Resource]Data` type.

### `[Resource]Collection` class

This class contains operations for a resource collection that belongs to a specific parent resource. It provides most of the logical collection operations.

| Collection Behavior | Collection Method |
| :--- | :--- |
| Iterate/List | `GetAll()` |
| Index | `Get(string name)` |
| Add | `CreateOrUpdate(string name, [Resource]Data data)` |
| Contains | `Exists(string name)` |
| TryGet | `GetIfExists(string name)` |

The `[Resource]Collection` class is designed to implement `IEnumerable<[Resource]Resource>` and `IAsyncEnumerable<[Resource]Resource>` interfaces.
The implementation method `IEnumerable<[Resource]Resource>.GetEnumerator()` calls `GetAll().GetEnumerator()`, therefore all the `[Resource]Collection` class must have a `GetAll()` method with no required parameters, otherwise the generator throws an exception complaining about this.

```csharp
public partial class AvailabilitySetCollection : ArmCollection, IEnumerable<AvailabilitySetResource>, IAsyncEnumerable<AvailabilitySetResource>
{
    IEnumerator<AvailabilitySetResource> IEnumerable<AvailabilitySetResource>.GetEnumerator()
    {
        return GetAll().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetAll().GetEnumerator();
    }

    IAsyncEnumerator<AvailabilitySetResource> IAsyncEnumerable<AvailabilitySetResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
    {
        return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
    }
}
```

In addition, ARM has several rules about "List" operations of resources:
- [R4014 NestedResourcesMustHaveListOperation](https://github.com/Azure/azure-rest-api-specs/blob/main/documentation/openapi-authoring-automated-guidelines.md#r4015-nestedresourcesmusthavelistoperation)
- [R4016 TopLevelResourcesListByResourceGroup](https://github.com/Azure/azure-rest-api-specs/blob/main/documentation/openapi-authoring-automated-guidelines.md#r4016)
- [R4017 TopLevelResourcesListBySubscription](https://github.com/Azure/azure-rest-api-specs/blob/main/documentation/openapi-authoring-automated-guidelines.md#r4017)

In rare cases, this rule is violated and a `list-exception` configuration is required to temporarily solve this. Please see [List exception](#list-exception) section for details.

The parent resource of this resource carries all the methods to get its child resources by returning its corresponding collection. For instance, on the resource of `VirtualNetworkResource`, you should find a method `GetSubnets` which returns a `SubnetCollection` to represent a collection of `SubnetResource`:
```csharp
public partial class VirtualNetworkResource : ArmResource
{
    public virtual SubnetCollection GetSubnets()
    {
        /* ... */
    }
}
```

For the cases that the parent resource is not in the same RP, the "get child resource method" is put in an extension class. For instance, the parent resource of `VirtualNetworkResource` is the resource group, and you should find an extension method of `ResourceGroupResource` in the `Azure.ResourceManager.Network` package returning `VirtualNetworkCollection` like this:
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

The management .Net SDK generates the resources with hierarchy, therefore the code generator makes quite a few modification on the code model input from the `modelerfour`. To better recognize the hierarchical structure of resources, the code generator generates everything from the point of view of request paths, instead of operation groups. Therefore quite a few new configurations are introduced to tweak the behavior how the generator identifies the resource classes as well as the hierarchy.

The management generator first goes through all the operations and categorize them by resources, then calculate hierarchical structures on them.

The management generator does not categorize the operations by operation groups, instead, it categorizes the operations by "operation sets". An operation set is a set of operations with the same request path. For instance, all the operations under the request path `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{name}` assemble into an operation set.

An operation set is marked as a resource, only when the following conditions meet:

1. The request path has even segments starting from the last `providers` segment. For instance, `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{name}` meets this requirement, but `/{scope}/providers/Microsoft.Authorization/policyAssignments` does not.
1. The operation set must have a GET request.
1. The schema of `200` response of the GET request is compatible to ARM's resource definition - it must have `id`, `type` and `name` (all of them are strings).

If all the above conditions are met, this operation set is marked as a "resource" by management generator, and the schema of the `200` response of the GET request is its corresponding `ResourceData`.

There are multiple ways to tweak the criteria of identifying resources, please see [change the criteria of ARM resources](#change-the-criteria-of-arm-resources) and [change resource data](#change-resource-data) section.

The name of a resource usually is derived from the name of the resource data, but with some exceptions. Please see [change resource name](#change-resource-name) for more details.

If a request path is incorrectly marked as a resource, you could use a configuration to make it non-resource again. Please see [mark a request path is non-resource](#mark-a-request-path-is-a-non-resource) section.

## How does the generator build hierarchical structure of resources

After the management generator goes through all the resources, it is ready to build the hierarchy of resources.

Despite the package `Azure.ResourceManager` is also mostly generated by the same generator, the generator has 5 built-in resources as parent fallbacks when the parent of a resource is not in this RP (The most common case of this is the `ResourceGroup` which is a parent of a lot of resources):

1. `Azure.ResourceManager.Tenant`
1. `Azure.ResourceManager.Subscription`
1. `Azure.ResourceManager.ResourceGroup`
1. `Azure.ResourceManager.ManagementGroup`
1. `Azure.ResourceManager.ArmResource`

For each operation set, the management generator tries to find its parent, by going through all the existing resources to see if the request path of another resource is the prefix of this operation set. After going through all of the resources, we should get a list of candidates of resources that can be the parent or grand parent of this operation set, it takes the longest path as its direct parent. If none found, the generator tries the 5 built-in resources in this order:
1. `ResourceGroup`
1. `Subscription`
1. `ManagementGroup`
1. `ArmResource`
1. `Tenant`
Please note that the path of `Tenant` is `/` which makes it could be a parent of any resource.

Now every operation set (and it corresponds to a resource) has a parent and only has one parent, the resource hierarchy is built.

There is a way to change the hierarchical structure of resources by the configuration, please see [change the parent of request paths](#change-parent-of-request-paths) section.

### Resource types and expanded resources

Every `[Resource]Resource` class has a public static field for its resource type, like:
```csharp
public partial class AvailabilitySetResource : ArmResource
{
    /// <summary> Gets the resource type for the operations. </summary>
    public static readonly ResourceType ResourceType = "Microsoft.Compute/availabilitySets";
}
```

Once an operation set is marked as a resource, the generator is able to determine its resource type. In general, the resource type of a resource is calculated in this way:

1. Take everything after the last `providers` segment. Anything before the last `providers` segment is regarded as the `scope` of this resource. For instance, for request path `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{groupName}/hosts/{hostName}`, we get `providers/Microsoft.Compute/hostGroups/{groupName}/hosts/{hostName}`
1. Take the provider namespace as the namespace of the resource type, in this case, we get `Microsoft.Compute`, and we have `hostGroups/{groupName}/hosts/{hostName}` left.
1. Take all the segments with even indices in whatever left in last step. In this case, we get `hostGroups` and `hosts`.
1. Put them all together and we get the resource type of this resource, `Microsoft.Compute/hostGroups/hosts`.

In the design of .Net management SDK, one resource must only have one constant resource type, therefore the generator checks if the resource type which it calculates is a constant, if the resource type is not a constant, it means that the swagger might be using one request path to represent a set of similar resources with different resource types. If this happens, the generator tries to expand the resource types into multiple constant resource types.

For instance, if the above procedure is applied on this request path `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}`, it produces the resource type `Microsoft.Network/dnsZones/{recordType}` which contains a variable in it and is not a constant. If this happens, the generator tries to expand it into multiple constant resource types. This requires the variables in the resulted resource type to be an enum type, if this condition is not met, the generator throws exceptions for you to resolve by adding configuration/directives.

We have some ways to change the resource type of a resource, please see [change the resource type](#change-the-resource-type) section.

### Singleton resources

Some resources are recognized as singleton resources automatically by the generator, for instance, a request path `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccount/{accountName}/blobServices/default` is a singleton resource with the name `default` and its parent is `StorageAccountResource`.

The generator marks a resource as a singleton, when its request path subtracted by the request path of its parent is a constant. For example, the resource with request path `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccount/{accountName}/blobServices/default` has a parent of `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccount/{accountName}`, if you subtract them, you should get `blobServices/default` which is a constant, therefore the resource `BlobServiceResource` is a singleton resource.

When a resource is marked as a singleton resource, it does not have its corresponding `[Resource]Collection` class, only has the `[Resource]Resource` class and the `[Resource]Data` class. The method to get a singleton resource on its parent is called as `Get[Resource]` in singular form, like

```csharp
public partial class StorageAccountResource : ArmResource
{
    public virtual BlobServiceResource GetBlobService()
    {
        /* ... */
    }
}
```

If you want to change the behavior how the generator identifies singleton resources, please see [change singleton resources](#change-singleton-resources) section.

## Management plane configurations

The configurations for management plane generator should be written in the `readme.md` file or `autorest.md` file that generates the SDK. You could take [this file](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/compute/Azure.ResourceManager.Compute/src/autorest.md) as an example.

### Change resource data

The configuration `request-path-to-resource-data` is a dictionary, its key is a request path, and the corresponding value is a schema name.

This configuration has two functionalities:
1. If the request path is not a resource, the generator marks it as a resource.
1. The corresponding resource data is set to be the schema specified by the value.

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

The generated code has a resource `DatabaseAccountResource`, `DatabaseAccountCollection`, and `DatabaseAccountData`. And if you want to assign another schema in these request as a resource data, you could add this configuration:
```yaml
request-path-to-resource-data:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}: DatabaseAccountCreateUpdateParameters
```

As a result, the resource now names after the new resource data, and now you should have `DatabaseAccountCreateUpdateParametersResource`, `DatabaseAccountCreateUpdateParametersCollection`, and `DatabaseAccountCreateUpdateParametersData`.

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
This request path looks like a resource, but unfortunately its corresponding schema `SharedGallery` does not have all the three properties required by a resource, `id`, `type` and `name`. Since this is a non-resource, this operation is generated into the extension class, like this:
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
```yaml
request-path-to-resource-data:
  /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/sharedGalleries/{galleryUniqueName}: SharedGallery
```
to mark it as a resource, and assign the schema `SharedGallery` as its resource data. In this way, you should get the `SharedGalleryResource`, `SharedGalleryCollection` and `SharedGalleryData` (which is the model generated from schema `SharedGallery`) like normal resources. In this way, the Id of this non-resource is automatically constructed by the SDK using its own request path.

</details>

### Change resource name

In most cases, a resource class shares the same name as the resource data class, and you should have a triplet of `[Resource]Resource`, `[Resource]Collection`, and `[Resource]Data`.

But if the RP is complicated, there might be multiple resources sharing the same resource data schema. If this happens, the generator has multiple strategies to generate unique names for all those resources in order to make sure the generated code could properly compile. These auto-generated names might not be ideal, and you might need the `request-path-to-resource-name` configuration to customize the resource names.

For instance, we have a resource `AvailabilitySetResource`, `AvailabilitySetCollection` and `AvailabilitySetData`. If we add this configuration:
```yaml
request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{name}: Something
```
Now you should have `SomethingResource` instead of `AvailabilitySetResource`, `SomethingCollection` instead of `AvailabilitySetCollection`, but still have the original resource data `AvailabilitySetData` because this configuration only change the corresponding resource name and the collection name (if it has a collection).

### Change the criteria of ARM resources

By default, a resource requires its schema to meet ARM's resource criteria that the model must have `id`, `type` and `name`. You can use the `resource-model-requires-type` and `resource-model-requires-name` configuration to loose this criteria.

For instance

```yaml
resource-model-requires-type: false
```

This configuration globally changes the criteria of a resource model to only require `id` and `name`.

### Change the resource type

The resource type is usually automatically calculated by its request path, but there are situations that the resource type cannot be calculated or not correctly calculated. In this case, you need to use the `request-path-to-resource-type` configuration to assign a resource type to the resource.

<details>

For instance, if we have the `AvailabilitySetResource` class
```csharp
public partial class AvailabilitySetResource : ArmResource
{
    /// <summary> Gets the resource type for the operations. </summary>
    public static readonly ResourceType ResourceType = "Microsoft.Compute/availabilitySets";
}
```
and if we have this configuration
```yaml
request-path-to-resource-type:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{name}: Microsoft.Compute/availabilitysets
```
Then you should have the following changes in `AvailabilitySetResource` class
```diff
public partial class AvailabilitySetResource : ArmResource
{
    /// <summary> Gets the resource type for the operations. </summary>
-   public static readonly ResourceType ResourceType = "Microsoft.Compute/availabilitySets";
+   public static readonly ResourceType ResourceType = "Microsoft.Compute/availabilitysets";
}
```

</details>

There are also some special request paths which is not possible to derive resource type from, for instance, `/{linkId}`. When this happens, the generator throws exception and require the user to provide a `request-path-to-resource-type` for it, or mark it as a non-resource using `request-path-is-non-resource` configuration. Please see [mark a request path is non-resource](#mark-a-request-path-is-a-non-resource) section.

### Mark a request path is a non-resource

By default the generator marks all the request paths that meet the criteria as resources. If there is a path you suppose it should be pure data instead of an ARM resource, you can use the `request-path-is-non-resource` configuration.

For instance,

```yaml
request-path-is-non-resource:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{name}
```

This configuration marks the availability set request paths as a non-resource, therefore the operations of non-resources append to their corresponding parent.

### Change parent of request paths

By default, the generator automatically finds the parent of a request path, and append the operations of a non-resource to their corresponding parents.

You can manually assign the parent of an operation using the configuration `request-path-to-parent` which is a dictionary from the request path of you want to change, to the request path you want to be the new parent. 

For instance, `Subnet` is the child resource of `VirtualNetwork`, and `VirtualNetwork` is the child resource of `ResourceGroupResource`, you can easily see this in their paths:
- Subnet: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}`
- VirtualNetwork: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}`

And you should have these in the generated code:
```csharp
public partial static class NetworkExtensions
{
    public static VirtualNetworkCollection GetVirtualNetworks()
    {
        /* ... */
    }
}

public partial class VirtualNetworkResource : ArmResource
{
    /// <summary> Gets the resource type for the operations. </summary>
    public static readonly ResourceType ResourceType = "Microsoft.Network/virtualNetworks";

    public virtual SubnetCollection GetSubnets()
    {
        /* ... */
    }
}

public partial class SubnetResource: ArmResource
{
    /// <summary> Gets the resource type for the operations. </summary>
    public static readonly ResourceType ResourceType = "Microsoft.Network/virtualNetworks/subnets";    
}
```
if you manually assign the parent of subnet to resource group, using the following configuration:
```yaml
request-path-to-parent:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
```
You should have the following changes which shows that now the parent of resource `SubnetResource` is `ResourceGroupResource`:
```diff
public partial static class NetworkExtensions
{
    public static VirtualNetworkCollection GetVirtualNetworks()
    {
        /* ... */
    }

+   public virtual SubnetCollection GetSubnets()
+   {
+       /* ... */
+   }
}

public partial class VirtualNetworkResource : ArmResource
{
    /// <summary> Gets the resource type for the operations. </summary>
    public static readonly ResourceType ResourceType = "Microsoft.Network/virtualNetworks";

-   public virtual SubnetCollection GetSubnets()
-   {
-       /* ... */
-   }
}

public partial class SubnetResource: ArmResource
{
    /// <summary> Gets the resource type for the operations. </summary>
    public static readonly ResourceType ResourceType = "Microsoft.Network/virtualNetworks/subnets";    
}
```

### Change singleton resources

Some resources are automatically recognized as singleton resources. If a resource is generated as a singleton resource, it does not have a corresponding collection class.

By default the generator makes a resource as a singleton, if it finds the extra part of its request path comparing to its parent is a constant.

Sometimes, you might need to manually make a resource singleton due to some issues in the swagger, you need to add the corresponding entries into the `request-path-to-singleton-resource` configuration. This configuration is a map from the request path to the extra segments of the resource identifier of the singleton resource.

For instance, for some reasons, the resource `ManagementPolicy` has the following path
```
/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}
```
Its name here `{managementPolicyName}` is an extensible enum type, despite it only has one value `default` right now. This is probably a mistake because it is not really extensible. But the generator cannot identify this because the name of this resource is not a constant, it generates this like a normal resource with a collection, like this:
```csharp
public partial class StorageAccountResource : ArmResource
{
    /// <summary> Gets the resource type for the operations. </summary>
    public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts";

    public virtual ManagementPolicyCollection GetManagementPolicies()
    {
        return new ManagementPolicyCollection(Client, Id);
    }
}
public partial class ManagementPolicyResource : ArmResource
{
    /// <summary> Gets the resource type for the operations. </summary>
    public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts/managementPolicies";
}

public partial class ManagementPolicyCollection : ArmCollection
{
    /* ... */
}
```
if you want to correct this, you could try the following configuration:
```yaml
request-path-to-singleton-resource:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}: managementPolicies/default
```
This marks the resource with path of `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}` as singleton resource, and its `Id` is its parent's Id appending `managementPolicies/default`. This produces the following diff:
```diff
public partial class StorageAccountResource : ArmResource
{
    /// <summary> Gets the resource type for the operations. </summary>
    public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts";

-   public virtual ManagementPolicyCollection GetManagementPolicies()
+   public virtual ManagementPolicyResource GetManagementPolicy()
    {
-       return new ManagementPolicyCollection(Client, Id);
+       return new ManagementPolicyResource(Client, new ResourceIdentifier(Id.ToString() + "managementPolicies/default"));
    }
}
public partial class ManagementPolicyResource : ArmResource
{
    /// <summary> Gets the resource type for the operations. </summary>
    public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts/managementPolicies";
}

-public partial class ManagementPolicyCollection : ArmCollection
-{
-   /* ... */
-}
```

### Change the name of operations

We provide a new configuration `override-operation-name` to assign new names to operations, which is a dictionary from the operationId of the operation to its new name.

For instance, originally, a `VirtualMachineResource` has a method `Start` which means to power on the machine, to align with the method `PowerOff`, we could use the following configuration:
```yaml
override-operation-name:
  VirtualMachines_Start: PowerOn
```
and get the following changes in the generated code:
```diff
public partial class VirtualMachineResource : ArmResource
{
-   public virtual async Task<ArmOperation> StartAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
+   public virtual async Task<ArmOperation> PowerOnAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
}
```

### List exception

If the generator finds a case that a collection class does not have a `GetAll` method, the following error message is thrown:
```
fatal   | The ResourceCollection AvailabilitySetCollection (RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}) does not have a GetAll method
```

When this happens, first we need to make sure if the swagger has a corresponding `List` operation for your resource. This should be a `GET` operation returns a collection of the resource data of your resource.

If there is no such operation, we need to double think if this is really a resource or it should be a singleton resource. You can use the `request-path-is-non-resource` configuration to mark it as a non-resource (see [Mark a request path is a non-resource](#mark-a-request-path-is-a-non-resource) section for details), or use the `request-path-to-singleton-resource` configuration to mark it as a singleton-resource (see [Change singleton resources](#change-singleton-resources) section for details).

If there is such an operation, but it is not automatically recognized by the generator, you can use the following combination of configurations to put it inside the collection class as a `GetAll` method:
```yaml
request-path-to-parent:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
override-operation-name:
  AvailabilitySets_List: GetAll
operation-positions:
  AvailabilitySets_List: collection
```

If all the above efforts are not met, you need to use the `list-exception` configuration to temporarily disable this check for this collection class:
```yaml
list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}
```

### Scope resources

Some resources are scope resources, which means that these resources can be created under different scopes, like subscriptions, resource groups, management groups, etc. In the swagger, we currently do not have an extension which assigns which type of resources can be the scope of this resource, therefore we add a configuration in our generator `request-path-to-scope-resource-types` for this new information.

By default, the generator recognizes the first parameter in request path as a scope parameter if the parameter has `x-ms-skip-url-encoding: true` on it, and the generator generates the resource assuming the scope can be anything. For instance, if we have a request path like `/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}` and you should have a resource generated like this:
```csharp
public partial class DeploymentResource : ArmResource
{
    /* ... */
}

public partial class DeploymentCollection : ArmCollection, IEnumerable<DeploymentResource>, IAsyncEnumerable<DeploymentResource>
{
    /* ... */
}

public partial class DeploymentData
{
    /* ... */
}
```
and since it is a scope resource without any configuration, its parent is anything, and you should have the following extension method:
```csharp
public static partial class ResourcesExtension
{
    public static DeploymentCollection GetDeployments(this ArmClient client, ResourceIdentifier scope)
    {
        /* ... */
    }
}
```
If you would like to generate an extension method for this scope resource, you need to add this configuration `generate-arm-resource-extensions` by adding the request path of this scope resource:
```yaml
generate-arm-resource-extensions:
- /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
```
And you will see this change in the generated code:
```diff
public static partial class ResourcesExtension
{
    public static DeploymentCollection GetDeployments(this ArmClient client, ResourceIdentifier scope)
    {
        /* ... */
    }
+
+   public static DeploymentCollection GetDeployments(this ArmResource armResource)
+   {
+       /* ... */
+   }
}
```

To assign specific resource types to this scope, you can use the following configuration:

```yaml
request-path-to-scope-resource-types:
  /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}:
    - subscriptions
    - resourceGroups
    - managementGroups
```

After we applied this configuration, you should have the following changes:
```diff
public static partial class ResourcesExtension
{
-   public static DeploymentCollection GetDeployments(this ArmResource armResource)
-   {
-       /* ... */
-   }
+   public static DeploymentCollection GetDeployments(this SubscriptionResource subscription)
+   {
+       /* ... */
+   }
+   public static DeploymentCollection GetDeployments(this ResourceGroupResource resourceGroup)
+   {
+       /* ... */
+   }
+   public static DeploymentCollection GetDeployments(this ManagementGroupResource managementGroup)
+   {
+       /* ... */
+   }
}
```

In some cases, we might have a resource that extends another resource from another RP. For instance this resource in `guestconfiguration` RP: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}` extends another resource virtual machine in the `compute` RP.

By default, because the generator will never find the `VirtualMachineResource` when generating this SDK, the parent resource of this `VmGuestConfigurationResource` will be `ResourceGroupResource`.
```csharp
public static partial class GuestConfigurationExtensions
{
    public static VmGuestConfigurationCollection GetVmGuestConfigurations(this ResourceGroupResource resourceGroup, string vmName)
    {
        /* ... */
    }
}
```

To show the relationship between resources across different RPs, we could convert it into a scope resource by using the following configuration:
```yaml
parameterized-scopes:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
```
This configuration registers the listed request paths as resources the generator could recognize even if they might not exist in the current context. After applying this configuration, the generated code will have the following changes:
```diff
public static partial class GuestConfigurationExtensions
{
-   public static VmGuestConfigurationCollection GetVmGuestConfigurations(this ResourceGroupResource resourceGroup, string vmName)
-   {
-       /* ... */
-   }
+   public static VmGuestConfigurationCollection GetVmGuestConfigurations(this ArmClient client, ResourceIdentifier scope)
+   {
+       if (!scope.ResourceType.Equals("Microsoft.Compute/virtualMachines"))
+           throw new InvalidOperationException(string.Format("Invalid resource type {0} expected Microsoft.Compute/virtualMachines", scope.ResourceType));
+       /* ... */
+   }
}
```

This configuration works fine with the configuration introduced above:
```yaml
generate-arm-resource-extensions:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}
```
and this is how the generated code would change:
```diff
public static partial class GuestConfigurationExtensions
{
    public static VmGuestConfigurationCollection GetVmGuestConfigurations(this ArmClient client, ResourceIdentifier scope)
    {
        if (!scope.ResourceType.Equals("Microsoft.Compute/virtualMachines"))
            throw new InvalidOperationException(string.Format("Invalid resource type {0} expected Microsoft.Compute/virtualMachines", scope.ResourceType));
        /* ... */
    }
+
+   public static VmGuestConfigurationCollection GetVmGuestConfigurations(this ArmResource armResource)
+   {
+       /* ... */
+   }
}
```

### SDK polishing configurations

During the SDK review, we would like to make some polish to our generated SDK according to the review comments, for instance, changing names of types, properties, making type of properties more specific, etc. To achieve these, you will need the SDK polishing configurations.

Please see [this document](./polishing.md) for full details of the SDK polishing configurations.

### Management debug options

A debug configuration is also introduced to show some extra information in the generated code. Usage:

```yaml
mgmt-debug:
  suppress-list-exception: true
```

The configuration `suppress-list-exception` suppresses all the exceptions about the collection class without a `GetAll` method.

### Directives from AutoRest core module

The directives brought by AutoRest core module works fine with all the configuration above. Please refer [this document](https://github.com/Azure/autorest/blob/main/docs/generate/directives.md) for more details and usages.
