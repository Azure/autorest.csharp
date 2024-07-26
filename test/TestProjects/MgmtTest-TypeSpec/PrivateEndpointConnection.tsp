using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace MgmtTest;

#suppress "@azure-tools/typespec-providerhub-controller/no-resource-operations" "Expected for private links"
model PrivateLinkResource is ProxyResource<PrivateLinkResourceProperties> {
  ...PrivateLinkResourceParameter;
}

@armResourceOperations(PrivateLinkResource)
interface PrivateLinks {
  /** list private links on the given resource */
  listByMongoCluster is ArmResourceListByParent<PrivateLinkResource>;
}
