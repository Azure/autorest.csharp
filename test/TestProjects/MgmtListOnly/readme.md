# MgmtParent
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/mgmtListOnly.json
namespace: MgmtListOnly
operation-group-to-resource-type:
    AvailabilitySetChild: Microsoft.Compute/availabilitySets/availabilitySetChild
operation-group-to-parent:
    AvailabilitySetChild: AvailabilitySets
```
