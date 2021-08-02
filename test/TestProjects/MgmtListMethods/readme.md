# MgmtParent
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/mgmtListMethods.json
namespace: MgmtListMethods
operation-group-to-resource-type:
  OneResources: Microsoft.Fake/oneResources
  SecondResources: Microsoft.Fake/fakes/secondResources
  SubFakes: Microsoft.Fake/fakes/subFakes
  SharedGalleries: Microsoft.Compute/locations/sharedGalleries
  Quotas: Microsoft.Fake/locations/updateQuotas
  Features: Microsoft.Fake/locations/features
operation-group-to-resource:
  SharedGalleries: SharedGallery
  Quotas: NonResource
  Features: NonResource
operation-group-to-parent:
  OneResources: resourceGroups
  SecondResources: Microsoft.Fake/fakes
  SubFakes: Microsoft.Fake/fakes
  SharedGalleries: subscriptions
  Quotas: subscriptions
  Features: subscriptions
operation-group-is-extension: OneResources;SecondResources
```
