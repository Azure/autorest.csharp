# Resolving Ambiguous Methods In LowLevel

This test project focuses on testing the generator's capability to resolve ambiguous methods in low level.

The scenario is that when growing a DPG client into an exsiting HLC client, there could be ambiguous methods between existing client and the DPG client to generate. The generator should have the capability to detect and resolve some ambiguous caes automatically.

See MethodAmbiguityResolver.cs for details.


## Structure

- The two clients under the root folder simulate existing HLC clients by providing "GA'ed" convenience APIs we don't want to change
- The two clients under `Generated` folder are the LLC codes.

### AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
require: $(this-folder)/../../../readme.md
input-file:
- $(this-folder)/AmbiguousMethods.json
- $(this-folder)/UnambiguousMethods.json
security: AzureKey
security-header-name: Fake-Subscription-Key
```
