

### Service API versions

The client library targets the latest service API version by default. A client instance accepts an optional service API version parameter from its options to specify which API version service to communicate.

#### Select a service API version

You have the flexibility to explicitly select a supported service API version when instantiating a client by configuring its associated options. This ensures that the client can communicate with services using the specified API version.

For example,

```C# Snippet:Create<YourService>ClientForSpecificApiVersion
Uri endpoint = new Uri("<your endpoint>");
DefaultAzureCredential credential = new DefaultAzureCredential();
<YourService>ClientOptions options = new <YourService>ClientOptions(<YourService>ClientOptions.ServiceVersion.<API Version>)
var client = new <YourService>Client(endpoint, credential, options);
```

When selecting an API version, it's important to verify that there are no breaking changes compared to the latest API version. If there are significant differences, API calls may fail due to incompatibility.

Always ensure that the chosen API version is fully supported and operational for your specific use case and that it aligns with the service's versioning policy.