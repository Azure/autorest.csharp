# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: KeyVault
require: 
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/954bf4ebc679ba55a6cacb39dbdacdbb956359f2/specification/keyvault/resource-manager/readme.md
- $(this-folder)/../../../../readme.md
clear-output-folder: true
namespace: Azure.ResourceManager.KeyVault
modelerfour:
  lenient-model-deduplication: true
model-namespace: false
payload-flattening-threshold: 2
operation-group-to-resource-type:
    PrivateLinkResources: Microsoft.KeyVault/vaults/privateLinkResources
    MHSMPrivateLinkResources: Microsoft.KeyVault/managedHSMs/privateLinkResources
    DeletedVaults: Microsoft.KeyVault/deletedVaults
operation-group-to-resource:
    Vaults: Vault
    DeletedVaults: DeletedVault
operation-group-to-parent:
   DeletedVaults: subscriptions
directive:
    - from: swagger-document
      where: $.paths
      transform: delete $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}/accessPolicies/{operationKind}']
    - from: swagger-document
      where: $.definitions
      transform: delete $['VaultAccessPolicyParameters']
    - from: swagger-document
      where: $.definitions
      transform: delete $['VaultAccessPolicyProperties']
    - from: swagger-document
      where: $.paths
      transform: delete $['/subscriptions/{subscriptionId}/resources']
    - from: swagger-document
      where: $['definitions']['Sku']['properties']['family']
      transform: delete $['x-ms-client-default']
    - from: swagger-document
      where: $['definitions']['ManagedHsmSku']['properties']['family']
      transform: delete $['x-ms-client-default']
    - from: swagger-document
      where: $['paths']['/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedVaults']['get']
      transform: $.operationId = 'DeletedVaults_ListBySubscription'
    - from: swagger-document
      where: $['paths']['/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}']['get']
      transform: $.operationId = 'DeletedVaults_Get'
    - from: swagger-document
      where: $['paths']['/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}/purge']['post']
      transform: $.operationId = 'DeletedVaults_Purge'
    # TODO: the VirtualNetworkRule failed in [Test]TestProjectTests.ValidateRequiredParamsInCtor, need to invesitigate codegen issue on this
    - from: keyvault.json
      where: $.definitions.VirtualNetworkRule.required
      transform: $ = []
    - from: swagger-document
      where: $.paths
      transform: delete $['/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedManagedHSMs']
    - from: swagger-document
      where: $.paths
      transform: delete $['/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedVaults']
list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}
- /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}
```