# Azure.ResourceManager.MachineLearning
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../readme.md
input-file: $(this-folder)/machineLearningServices.json
namespace: Azure.ResourceManager.MachineLearning
model-namespace: false
public-clients: false
head-as-boolean: false
payload-flattening-threshold: 2
modelerfour:
  lenient-model-deduplication: true
operation-group-to-resource-type:
  Operations: Microsoft.MachineLearningServices/operations
  WorkspaceFeatures: Microsoft.MachineLearningServices/workspaces/features
  Usages: Microsoft.MachineLearningServices/locations/usages
  VirtualMachineSizes: Microsoft.MachineLearningServices/locations/vmSizes
  Quotas: Microsoft.MachineLearningServices/locations/quotas
  Workspace: Microsoft.MachineLearningServices/workspaces/skus
  PrivateLinkResources: Microsoft.MachineLearningServices/workspaces/privateLinkResources
  Notebooks: Microsoft.MachineLearningServices/workspaces
  StorageAccount: NonResourceMicrosoft.MachineLearningServices/workspaces/listStorageAccountKeys
operation-group-to-resource:
  Operations: NonResource
  WorkspaceFeatures: ListAmlUserFeatureResult
  Usages: NonResource
  VirtualMachineSizes: NonResource
  Quotas: NonResource
  Workspace: SkuListResult
  PrivateLinkResources: PrivateLinkResourceListResult
  Notebooks: NonResource
  StorageAccount: NonResource
  MachineLearningCompute: ComputeResource
operation-group-to-parent:
  Usages: Locations
  VirtualMachineSizes: Locations
  Quotas: Locations
  Notebooks: Workspaces
  StorageAccount: Workspaces
directive:
  - from: swagger-document
    where: $.definitions.ComputeNodesInformation.properties
    transform: delete $.nextLink;
    reason: Duplicated "nextLink" property defined in schema 'AmlComputeNodesInformation' and 'ComputeNodesInformation'
```
