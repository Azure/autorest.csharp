## Service Client Constrctors

Scope: This document only applies to DPG services.

There will be two **public** client constructors in a generated service client. One primary public constructor with all the user defined client parameters plus `ClientOptions`, and one secondary public constructor with all the user defined **required** client parameters. The secondary public constructor calls the primary public constructor underneath.

For example, user defines required parameters `Uri endpoint` and `AzureKeyCredential credential`, then the generated public constructors are:

```C#
public ServiceClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new ServiceClientOptions()) {}

public ServiceClient(Uri endpoint, AzureKeyCredential credential, ServiceClientOptions options) {}
```

Normally, all the client parameters are required. But if user defines some additional optional client parameters, all the optional client parameters will go to `ClientOptions`, except `endpoint`.

For example, user defines an optional parameter `string optional`. The `ClientOptions` will have a new property as

```C#
public partial class ServiceClientOptions : ClientOptions
{
    ...

    public string Optional { get; set; }
}
```

The signature of the public constructors will keep the same, but its implementation will become to
```C#
public ServiceClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new ServiceClientOptions()) {}

public ServiceClient(Uri endpoint, AzureKeyCredential credential, ServiceClientOptions options)
{
    ...
    _optional = options.Optional;
}
```

If the optional client parameters user defines contains `endpoint`, it will still be in the client constructor, not going to `ClientOptions`. For example, user defines an optional parameter `string optional`, an optional `endpoint` with default value `"http://localhost:3000"`, and a required parameter `AzureKeyCredential credential`, the generated public constructors are:

```C#
public ServiceClient(AzureKeyCredential credential) : this(new Uri("http://localhost:3000"), credential, new ServiceClientOptions()) {}

public ServiceClient(Uri endpoint, AzureKeyCredential credential, ServiceClientOptions options)
{
    ...
    _optional = options.Optional;
}

public partial class ServiceClientOptions : ClientOptions
{
    ...

    public string Optional { get; set; }
}
```