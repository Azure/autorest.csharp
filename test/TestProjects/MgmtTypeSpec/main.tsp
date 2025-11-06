
import "@azure-tools/typespec-azure-resource-manager";
import "./PrivateEndpointConnection.tsp";
import "./foo.tsp";
import "./readonlyRequired.tsp";

using TypeSpec.Versioning;
using Azure.ResourceManager;

@armProviderNamespace
@service(#{
  title: "MgmtTestClient",
})
@versioned(Versions)
@armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
namespace MgmtTypeSpec;

interface Operations extends Azure.ResourceManager.Operations {}

/** The available API versions. */
enum Versions {
    /** Azure Cosmos DB for Mongo vCore clusters api version 2024-03-01-preview. */
    v2024_05_01: "2024-05-01",
  }
