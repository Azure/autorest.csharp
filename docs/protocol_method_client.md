A client with protocol methods, often known informally as a "Low Level Client", is generated from autorest.csharp the same as other clients are. 

However a handful of configuration changes are needed to get started.

1. Create a standard "high level" project [as documented](csharp_generate).

2. Add the following key to the readme.md or autorest.md configuration file:

```yaml
low-level-client: true
```

3. Define the authentication in configuration 

As clients with protocol methods generate constructors directly, currently authentication needs to be defined in the configuration file.

This may change if [the PR for authentication properties in swagger](1128) lands or [more generic constructors](1221) are figured out.

To do this, first one of two supported credential-types needed to be defined in the readme.md or autorest.md file:

Just Key Credential:
```yaml
credential-types: AzureKeyCredential
credential-header-name: Your-Subscription-Key
```

Just Token Credential:
```yaml
credential-types: TokenCredential
credential-scopes: https://yourendpoint.azure.com/.default
```

Both Credentials:
```yaml
credential-types: TokenCredential;AzureKeyCredential
credential-header-name: Your-Subscription-Key
credential-scopes: https://yourendpoint.azure.com/.default
```

`credential-header-name` and `credential-scopes` need to be filled to the service specific values. 

4. Try the generated code.

Read the [user documentation for clients with protocol methods](protocol_method_user_doc) and give it a try.

The standard [customizations](customizations) that are applicable (example: don't involve models) work just the same.


<!-- LINKS -->
[csharp_generate]: ./generate/readme.md
[1128]: https://github.com/Azure/autorest.csharp/pull/1128
[1221]: https://github.com/Azure/autorest.csharp/issues/1221
[protocol_method_user_doc]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/ProtocolMethods.md
[customizations]: https://github.com/Azure/autorest.csharp#customizing-the-generated-code