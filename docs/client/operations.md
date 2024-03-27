# <img align="center" src="../images/logo.png">  Calling Operations with Your C# Client

AutoRest provides both synchronous and asynchronous method overloads for each service operation.
Depending on your swagger definition, operations can be accessed through operation groups (TODO: link to swagger docs) on the client,
or directly on the client.

## Operation Group vs No Operation Group

If your swagger defines an operation group for your operation (for example, in [this][operation_group_example] swagger, the operation `list`
is part of operation group `application`), you would access the operation through the client for that operation group, which in this case
would be `ApplicationClient.List(...)`.

If there's no operation group, as in [this][mixin_example] case, you would access the operation directly from the main client
itself, i.e. `PetsClient.GetDog()`. Our responses are returned as responses of `T`. To access the value, we call `.Value` on the response object or use the implicit conversion from `Response<T>` to `T`.

## Regular Operations

### Sync Operations

We will be using the [example swagger][pets_swagger] in our main docs repo. After [initializing][initializing] our client, we
call our operation like this:

```csharp
using Azure.Pets;
using Azure.Core;
using Azure.Core.Pipeline;

var client = new PetsClient(endpoint);

// Option #1 - Explicit response use
Response<Dog> dogOperation = client.GetDog();
Dog dog = dogOperation.Value;

// Option #2 - Implicit response use
Dog doc = client.GetDog();
```

### Async Operations

We can also use our client to call async operations, and these operations are all suffixed with `Async`. Following the [example above](#sync-operations "Sync Operations"),
our call to `GetDogAsync` looks like this:

```csharp
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Pets;
using Azure.Core;
using Azure.Core.Pipeline;

var client = new PetsClient(endpoint);

// Option #1 - Explicit response use
Response<Dog> dogResponse = await client.GetDogAsync();
Dog dog = dogResponse.Value;

// Option #2 - Implicit response use
Dog dog = await client.GetDogAsync();
```

## Long Running Operations

Long-running operations are operations which consist of an initial request sent to the service to start an operation, followed by polling the service at intervals to determine whether the operation has completed or failed, and if it has succeeded, to get the result.

In concurrence with our [.NET guidelines][poller_guidelines], all long running operations are prefixed with `Start`, to signify the starting of a long running operation.

For our example, we will use the long running operation generated from [this][polling_paging_swagger] swagger. Let's say we generated this swagger with namespace `Azure.Lro`.

### Sync Long Running Operations

By default, our sync long running operations return an operation. You can check if the operation has completed, and continually update status.

```csharp
using System;
using System.Threading;
using Azure.Lro;
using Azure.Lro.Models;
using Azure.Core;
using Azure.Core.Pipeline;

const string endpoint = "http://localhost:3000";
var client = new PollingPagingExampleClient(endpoint);

var product = new Product
{
    Id = 1,
    Name = "My Polling Example"
};
var pollingOperation = client.StartBasicPolling(product);

while (!pollingOperation.HasCompleted)
{
    Thread.Sleep(2000);
    pollingOperation.UpdateStatus();
};

var outputProduct = pollingOperation.Value;
```

### Async Long Running Operations

Our async long running operations are even easier to use, all that's required is to call `WaitForCompletionAsync()` on the
returned operation.

```csharp
using System;
using System.Threading;
using Azure.Lro;
using Azure.Lro.Models;
using Azure.Core;
using Azure.Core.Pipeline;

var client = new PollingPagingExampleClient(endpoint);

var product = new Product
{
    Id = 1,
    Name = "My Polling Example"
};
var outputProduct = (await client.StartBasicPolling(product).WaitForCompletionAsync()).Value;
```

## Paging Operations

A paging operation pages through lists of data, returning an iterator for the items. Network calls get made when users start iterating through the output, not when the operation
is initially called.

For our example, we will use the paging operation generated from [this][polling_paging_swagger] swagger. Let's say we generated this swagger with namespace `Azure.Paging`.

### Sync Paging Operations

By default, our sync paging operations return a [`Pageable`][pageable] object. The initial call to the function returns
the pager, but doesn't make any network calls. Instead, calls are made when users start iterating, with each network call returning a page of data.

```csharp
using Azure.Paging;
using Azure.Core;
using Azure.Core.Pipeline;

var client = new PollingPagingExampleClient(endpoint);

var pageable = client.BasicPaging();

foreach (var item in pageable) {
    ...
}
```

### Async Paging Operations

The async paging operations are a similar concept to the [sync ones](#sync-paging-operations "Sync Paging Operations"), this time returning an [`AsyncPageable`][async_pageable]
object. Since network calls aren't
made until starting to page, our generated operation is synchronous, and there's no need to wait the initial call to the function. Since network calls are made when iterating,
we have to do async looping.

```csharp
using System;
using System.Threading;
using Azure.Paging;
using Azure.Core;
using Azure.Core.Pipeline;

const string endpoint = "http://localhost:3000";
var client = new PollingPagingExampleClient(endpoint);

var pageableAsync = client.BasicPagingAsync();

await foreach (var item in pageableAsync)
{
    ...
}
```

## Advanced: LRO + paging

We also support generating a long running paging operation. In this case, we return a poller operation for the initial call, and the final value from the poller is
a pager that pages through the final lists of data.


<!-- LINKS -->
[operation_group_example]: https://github.com/Azure/azure-rest-api-specs/blob/master/specification/batch/data-plane/Microsoft.Batch/stable/2020-09-01.12.0/BatchService.json#L64
[mixin_example]: https://github.com/Azure/autorest/blob/main/docs/openapi/examples/pets.json#L15
[poller_guidelines]: https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning
[pageable]: https://docs.microsoft.com/en-us/dotnet/api/azure.pageable-1?view=azure-dotnet
[async_pageable]: https://docs.microsoft.com/en-us/dotnet/api/azure.asyncpageable-1?view=azure-dotnet
[pets_swagger]: https://github.com/Azure/autorest/blob/master/docs/openapi/examples/pets.json
[initializing]: ./initializing.md
[polling_paging_swagger]: https://github.com/Azure/autorest/blob/master/docs/openapi/examples/pollingPaging.json
