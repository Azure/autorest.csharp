# TenantOnly
## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
title: TenantOnly
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/TenantOnly.json
namespace: Azure.TenantOnly
mgmt-debug:
  show-request-path: true
```
