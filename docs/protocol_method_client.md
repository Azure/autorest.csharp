A client with protocol methods, often known informally as a "Low Level Client", is generated from autorest.csharp the same as other clients are. 

However a handful of configuration changes are needed to get started.

1. Create a standard "high level" project [as documented](csharp_generate).

2. Add the following key to the readme.md or autorest.md configuration file:

```yaml
low-level-client: true
```

3. Define the authentication in configuration 

As clients with protocol methods generate constructors directly, any authentication needs to be defined in the configuration file.

There are two forms of supported authentication: `AzureKeyCredential` (AzureKey) and `TokenCredential` (AADToken).

It is valid to define one, both, or neither (for the rare unauthenticated client use case).


Just Key Credential:
```yaml
security: AzureKey
security-header-name: Your-Subscription-Key
```

Just Token Credential:
```yaml
security: AADToken
security-scopes: https://yourendpoint.azure.com/.default
```

Both Credentials:
```yaml
security: AADToken;AzureKey
security-header-name: Your-Subscription-Key
security-scopes: https://yourendpoint.azure.com/.default
```

`credential-header-name` and `credential-scopes` need to be filled to the service specific values. 

4. Try the generated code.

Read the [user documentation for clients with protocol methods](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/ProtocolMethods.md) and give it a try.

The standard [customizations](https://github.com/Azure/autorest.csharp#customizing-the-generated-code) that are applicable (example: don't involve models) work just the same.


<!-- LINKS -->
[csharp_generate]: ./generate/readme.md
[1128]: https://github.com/Azure/autorest.csharp/pull/1128
[1221]: https://github.com/Azure/autorest.csharp/issues/1221
