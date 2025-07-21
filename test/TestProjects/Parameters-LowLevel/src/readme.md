# Parameters-Lowlevel
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: Parameters-Lowlevel
require: $(this-folder)/../../../../readme.md
input-file: $(this-folder)/Parameters.json
namespace: Azure.ParametersLowlevel
use-model-reader-writer: true
security: AzureKey
security-header-name: Fake-Subscription-Key
```
