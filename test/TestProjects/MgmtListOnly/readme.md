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
    ResponseNotCalledValue: Microsoft.Compute/availabilitySets/responseNotCalledValue
    ResponseNotCalledValueNoPage: Microsoft.Compute/availabilitySets/responseNotCalledValueNoPage
    AvailabilitySetFeatures: Microsoft.Compute/availabilitySetsFeatures
    AvailabilitySetsNonPageableFeatures: Microsoft.Compute/availabilitySetsNonPageableFeatures
    ApiKeys: Microsoft.Compute/apiKeys
    ChildWithPosts: Microsoft.Compute/availabilitySets/childWithPost
    Usages: Microsoft.Compute/locations/usages
    NonPageableUsages: Microsoft.Compute/locations/nonPageableUsages
operation-group-to-resource:
    ApiKeys: NonResource
    ChildWithPosts: NonResource
operation-group-to-parent:
    AvailabilitySetChild: AvailabilitySets
    ResponseNotCalledValue: AvailabilitySets
    ResponseNotCalledValueNoPage: AvailabilitySets
    AvailabilitySetFeatures: subscriptions
    AvailabilitySetsNonPageableFeatures: subscriptions
    ApiKeys: subscriptions
    ChildWithPosts: AvailabilitySets
    Usages: subscriptions
    NonPageableUsages: subscriptions
```
