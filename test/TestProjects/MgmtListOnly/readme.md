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
    ResourceGroupFeatures: Microsoft.Compute/locations/resourceGroupFeatures
    ResourceGroupNonPageableFeatures: Microsoft.Compute/locations/resourceGroupNonPageableFeatures
    Keys: Microsoft.Compute/publishers/versions/getKeys
operation-group-to-resource:
    ApiKeys: NonResource
    ChildWithPosts: NonResource
    Keys: NonResource
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
    ResourceGroupFeatures: resourceGroups
    ResourceGroupNonPageableFeatures: resourceGroups
    Keys: resourceGroups
```
