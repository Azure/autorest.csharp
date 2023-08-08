# Unit testing and mocking with the Azure Resource Manager SDK for .Net

## Understand the design of Azure Resource Manager SDKs

TODO -- put a link of the fundamental concepts of Azure Resource Manager here.

For fundamental concepts of Azure Resource Manager SDKs, see [Key Concepts of Azure Resource Manager SDKs](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#key-concepts).

The hierarchy of resource client is made by introducing extension methods into the SDK, if the resource and its parent exist in different SDKs.
For instance, in `Azure.ResourceManager.Compute` namespace, the parent resource of `VirtualMachineResource` is `ResourceGroupResource`, therefore we could get the `VirtualMachineCollection` on an instance of `ResourceGroupResource` using
```csharp
VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();
```

This is achieved by the extension method in the `Azure.ResourceManager.Compute` namespace:
```csharp
namespace Azure.ResourceManager.Compute
{
    public static partial class ComputeExtensions
    {
        public static VirtualMachineCollection GetVirtualMachines(this ResourceGroupResource resourceGroup)
        {
            // implementation
        }
    }
}
```

This introduces challenges of unit testing and mocking, because the extension methods are static methods, and the extension methods are not virtual therefore they cannot be mocked.

For those virtual methods (not extension methods), to mock them, you just need to take the usual techniques of mocking virtual methods, for details, please see [Unit testing and mocking with the Azure SDK for .Net](https://learn.microsoft.com/en-us/dotnet/azure/sdk/unit-testing-mocking?tabs=csharp).
In this document, we focus on how to unit test and mock those extension methods.

## Unit testing and mocking extension methods

In the implementation of Azure Resource Manager SDKs, the extension methods are implemented using the same pattern.

1. A "mocking extension" type is introduced for the extended type of the extension method.
2. The implementation of the extension method will always be as simple as calling the method on the "mocking extension" type with the same name and same parameter list except for the `this` parameter of the extension method.

For instance, the extension method `GetVirtualMachines` on `ResourceGroupResource` is implemented as:
```csharp
namespace Azure.ResourceManager.Compute
{
    public static partial class ComputeExtensions
    {
        private static ComputeResourceGroupMockingExtension GetComputeResourceGroupMockingExtension(ArmResource resource)
        {
            return resource.GetCachedClient(client => new ComputeResourceGroupMockingExtension(client, resource.Id));
        }

        public static VirtualMachineCollection GetVirtualMachines(this ResourceGroupResource resourceGroup)
        {
            return GetComputeResourceGroupMockingExtension(resourceGroup).GetVirtualMachines();
        }
    }
}
```
and the method on the "mocking extension" type with the same name and same parameter list is an instance method, and it is guaranteed to be virtual.

Using this pattern, we implement every extension method using two virtual methods and both of them are mockable.

The first virtual method is the `GetCachedClient` on `ArmResource` and `ArmClient`, this method is used to get the `MockingExtension` instance from the extended type.

The second virtual method is the method on the "mocking extension" type with the same name and same parameter list except for the `this` parameter of the extension method.

There is a universal naming pattern across all the Azure Resource Manager SDKs for the "mocking extension" type:

1. Find the extended type of the extension method, in the above example, it is `ResourceGroupResource`.
2. Trim the `Resource` suffix off it and get the "Resource Name", in the above example, it becomes `ResourceGroup`. One exception is that when the extended type is `ArmResource`, please just keep `ArmResource` without trimming it.
3. Find the namespace of the extension method, in the above example, it is `Azure.ResourceManager.Compute`.
4. Remove the `Azure.ResourceManager` from the namespace above, and get the "RP Name", in the above example, it is `Compute`.
5. Now we get the name of the mocking extension type using this pattern: `{RP Name}{Resource Name}MockingExtension`. In the above extension, the name of the mocking extension type is: `ComputeResourceGroupMockingExtension`.
6. The mocking extension type is always in the `Mocking` sub-namespace of the extension method. In the above example, the mocking extension type is in the `Azure.ResourceManager.Compute.Mocking` namespace.

Once we find the mocking extension type, we can mock the extension method by mocking the two virtual methods mentioned above.

## Results {.tabset}

### Non-library

To create a test client instance using C# without a mocking library, inherit from the client type and override methods you're calling in your code with an implementation that returns a set of test objects. Most clients contain both synchronous and asynchronous methods for operations; override only the one your application code is calling.

```csharp
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;

namespace UnitTestingSampleApp.NonLibrary;

public sealed class MockResourceGroupResource : ResourceGroupResource
{
    public override T GetCachedClient<T>(Func<ArmClient, T> ctor) where T : class
    {
        if (typeof(ComputeResourceGroupMockingExtension).IsAssignable(typeof(T)))
            return new MockComputeResourceGroupMockingExtension();
        return base.GetCachedClient(ctor);
    }
}

public sealed class MockComputeResourceGroupMockingExtension : ComputeResourceGroupMockingExtension
{
    public override VirtualMachineCollection GetVirtualMachines()
    {
        return new MockVirtualMachineCollection();
    }
}

public sealed class MockVirtualMachineCollection : VirtualMachineCollection
{
    // override the method you would like to mock on VirtualMachineCollection here
}
```

### Moq

```csharp
Mock<ResourceGroupResource> rgMock = new Mock<ResourceGroupResource>();
Mock<ComputeResourceGroupMockingExtension> rgMockingExtensionMock = new Mock<ComputeResourceGroupMockingExtension>();
Mock<VirtualMachineCollection> vmCollectionMock = new Mock<VirtualMachineCollection>();
// mock the GetCachedClient method
rgMock.Setup(rg => rg.GetCachedClient(It.IsAny<Func<ArmClient, ComputeResourceGroupMockingExtension>>()))
    .Returns(rgMockingExtensionMock);
// mock the actual method
rgMockingExtensionMock.Setup(rg => rg.GetVirtualMachines())
    .Returns(vmCollectionMock.Object);
// mock the method you would like to use on VirtualMachineCollection

ResourceGroupResource rg = rgMock.Object;
// call your methods as usual
```
