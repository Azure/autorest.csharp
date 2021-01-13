# <img align="center" src="../images/logo.png">  Initializing Your C# Client

The first step to using your generated client in code is to import and initialize your client. Our SDKs are modelled such
that the client is the main point of access to the generated code.

## Initializing and Authenticating Your Client

You can use your client if you import the namespace you specified when generating (under flag `--namespace`). For the sake of this example,
let's say the namespace is `Azure.Pets` and your client is `PetsClient`. You could then access the client if you import the namespace.

```csharp
using Azure.Pets;
using Azure.Core;
using Azure.Core.Pipeline;

string endpoint = "http://localhost:3000";
var client = new PetsClient(endpoint);
```

When generating your client in [ARM][arm] mode, we have defaults for `clientDiagnostics`, `pipeline`, and `endpoint`. We also add a parameter `tokenCredential` of type
[`TokenCredential`][token_credential], where you pass in an OAuth token. We always recommend
using a [credential type][identity_credentials] obtained from the [`Azure.Identity`][azure_identity] for AAD authentication. For this example,
we use the most common [`DefaultAzureCredential`][default_azure_credential].

```csharp
using Azure.Pets;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;

string endpoint = "http://localhost:3000";
var credential = new DefaultAzureCredential()
var client = new PetsClient(endpoint, credential);
```

You can also pass in [client options][client_options] through the `options` parameter. This is used for exposing various
common client options, like policies for [diagnostics][diagnostics], [retry][retry], and [transport][transport].
Finally, you can define client parameters in swagger, so these parameters would also be passed in at initialization time.

<!-- LINKS -->
[arm]: https://docs.microsoft.com/en-us/azure/azure-resource-manager/management/control-plane-and-data-plane#control-plane
[http_pipeline]: https://docs.microsoft.com/en-us/dotnet/api/azure.core.pipeline.httppipeline?view=azure-dotnet
[token_credential]: https://docs.microsoft.com/en-us/dotnet/api/azure.core.tokencredential?view=azure-dotnet
[azure_identity]: https://docs.microsoft.com/en-us/dotnet/api/azure.identity?view=azure-dotnet
[identity_credentials]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity#credential-classes
[default_azure_credential]: https://docs.microsoft.com/en-us/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[client_options]: https://docs.microsoft.com/en-us/dotnet/api/azure.core.clientoptions?view=azure-dotnet
[diagnostics]: https://docs.microsoft.com/en-us/dotnet/api/azure.core.clientoptions.diagnostics?view=azure-dotnet#Azure_Core_ClientOptions_Diagnostics
[retry]: https://docs.microsoft.com/en-us/dotnet/api/azure.core.clientoptions.retry?view=azure-dotnet#Azure_Core_ClientOptions_Retry
[transport]: https://docs.microsoft.com/en-us/dotnet/api/azure.core.clientoptions.transport?view=azure-dotnet#Azure_Core_ClientOptions_Transport