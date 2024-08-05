import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

#suppress "@azure-tools/typespec-providerhub-controller/no-resource-operations" "Expected for private links"
model PrivateLinkResource is ProxyResource<PrivateLinkResourceProperties> {
  ...PrivateLinkResourceParameter;
}

@armResourceOperations(PrivateLinkResource)
interface PrivateLinks {
  /** list private links on the given resource */
  @clientName("GetAllPrivateLinkResources")
  listByMongoCluster is ArmResourceListByParent<PrivateLinkResource>;
}
