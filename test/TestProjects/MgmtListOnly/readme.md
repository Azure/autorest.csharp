# MgmtParent
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/mgmtListOnly.json
namespace: MgmtListOnly
operation-group-to-resource-type:
    FakeBars: Microsoft.Fake/fakes/availabilitySetChild
    ResponseNotCalledValues: Microsoft.Fake/fakes/ResponseNotCalledValues
    ResponseNotCalledValueNoPages: Microsoft.Fake/fakes/responseNotCalledValueNoPages
    FakeFeatures: Microsoft.Fake/fakesFeatures
    FakeNonPageableFeatures: Microsoft.Fake/fakesNonPageableFeatures
    ApiKeys: Microsoft.Fake/apiKeys
    ChildWithPosts: Microsoft.Fake/fakes/childWithPost
    Usages: Microsoft.Fake/locations/usages
    NonPageableUsages: Microsoft.Fake/locations/nonPageableUsages
    ResourceGroupFeatures: Microsoft.Fake/locations/resourceGroupFeatures
    ResourceGroupNonPageableFeatures: Microsoft.Fake/locations/resourceGroupNonPageableFeatures
    Keys: Microsoft.Fake/publishers/versions/getKeys
operation-group-to-resource:
    ApiKeys: NonResource
    ChildWithPosts: NonResource
    Keys: NonResource
operation-group-to-parent:
    FakeBars: Microsoft.Fake/fakes
    ResponseNotCalledValues: Microsoft.Fake/fakes
    ResponseNotCalledValueNoPages: Microsoft.Fake/fakes
    FakeFeatures: subscriptions
    FakeNonPageableFeatures: subscriptions
    ApiKeys: subscriptions
    ChildWithPosts: Microsoft.Fake/fakes
    Usages: subscriptions
    NonPageableUsages: subscriptions
    ResourceGroupFeatures: resourceGroups
    ResourceGroupNonPageableFeatures: resourceGroups
    Keys: resourceGroups
```
