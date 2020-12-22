# <img align="center" src="../images/logo.png">  Troubleshooting

## Error Handling

Our generated clients raise an [`Azure.RequestFailedException`][request_failed_exception] when they encounter a failed service call.
The exception type provides a Status property with an HTTP status code an an ErrorCode property with a service-specific error code.

A very basic form of error handling looks like this

```csharp
try
{
    KeyVaultSecret secret = client.GetSecret("NonexistentSecret");
}
// handle exception with status code 404
catch (RequestFailedException e)
{
    // handle not found error
    Console.WriteLine("ErrorCode " + e.ErrorCode);
}
```

You can also catch errors with more granularity, i.e. just catching an error with a `404` status code.

```csharp
try
{
    KeyVaultSecret secret = client.GetSecret("NonexistentSecret");
}
// handle exception with status code 404
catch (RequestFailedException e)  when (e.Status == 404)
{
    // handle not found error
    Console.WriteLine("ErrorCode " + e.ErrorCode);
}
```


## Logging

Our generated SDKs produce various log messages that include information about:

* Requests and responses
* Authentication attempts
* Retries

See our [logging sample][logging_sample] for set up.

<!-- LINKS -->
[logging_sample]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md#logging