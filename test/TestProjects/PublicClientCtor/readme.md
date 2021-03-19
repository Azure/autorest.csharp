# PublicClientCtor
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: PublicClientCtor
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/PublicClientCtor.json
namespace: Azure.PublicClientCtor
credential-types: TokenCredential;AzureKeyCredential
credential-header-name: fake-key
credential-scopes: https://fakeendpoint.azure.com/.default;https://dummyendpoint.azure.com/.default
```
