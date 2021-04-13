# TenantOnly
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: BodyAndPath
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/BodyAndPath.json
low-level-client: true
credential-types: AzureKeyCredential
credential-header-name: Fake-Subscription-Key
```
