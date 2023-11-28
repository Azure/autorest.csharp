## Service Client Constrctors

Scope: This document only applies to DPG libraries.

There will be two **public** client constructors in a generated service client:

**One primary public constructor with:**
- `endpoint` parameter (no matter it is required or optional).
- All the user defined **required** client parameters.
- A `ClientOptions` parameter.

**One secondary public constructor with:**
- All the user defined **required** client parameters (without the `ClientOptions` parameter and **optional** paramters).

The secondary public constructor calls the primary public constructor underneath with default values of `endpoint` (if any) and `ClientOptions`.

For example, user defines required parameters `Uri endpoint` and `AzureKeyCredential credential`, then the generated public constructors are:

```C#
public ServiceClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new ServiceClientOptions()) {}

public ServiceClient(Uri endpoint, AzureKeyCredential credential, ServiceClientOptions options) {}
```

Usually, all the client parameters are required. But if user defines some additional optional client parameters, all the optional client parameters will go to `ClientOptions`, except `endpoint`.

For example, user defines an optional parameter `string optional`. The `ClientOptions` will have a new property as

```C#
public partial class ServiceClientOptions : ClientOptions
{
    /* Other irrelevant lines*/

    public string Optional { get; set; }
}
```

The signature of the public constructors will not change, but its implementation will change to
```C#
public ServiceClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new ServiceClientOptions()) {}

public ServiceClient(Uri endpoint, AzureKeyCredential credential, ServiceClientOptions options)
{
    /* Other irrelevant lines*/

    _optional = options.Optional;
}
```

If the user defined optional client parameters contain `endpoint`, it will still be in the client constructor, not going to `ClientOptions`. For example, if user defines an optional parameter `string optional`, an optional `endpoint` with default value `"http://localhost:3000"`, and a required parameter `AzureKeyCredential credential`, the generated public constructors are:

```C#
public ServiceClient(AzureKeyCredential credential) : this(new Uri("http://localhost:3000"), credential, new ServiceClientOptions()) {}

public ServiceClient(Uri endpoint, AzureKeyCredential credential, ServiceClientOptions options)
{
    /* Other irrelevant lines*/

    _optional = options.Optional;
}

public partial class ServiceClientOptions : ClientOptions
{
    /* Other irrelevant lines*/

    public string Optional { get; set; }
}
```