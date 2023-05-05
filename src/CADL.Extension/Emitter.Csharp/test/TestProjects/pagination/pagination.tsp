import "@typespec/rest";
import "@typespec/http";
import "@typespec/versioning";
import "@typespec/openapi";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using TypeSpec.Versioning;
using Azure.Core;
using OpenAPI;

//
// ** Service description **
//

// TODO: Use `Uri` type when available: https://github.com/microsoft/cadl/issues/654
@service(
    {
        title: "Pagination Service",
        version: "2022-05-13"
    }
)
@useDependency(Azure.Core.Versions.v1_0_Preview_1)
@server(
  "{pagnationUri}",
  "Pagination Service",
  {
    pagnationUri: string,
  }
)
@useAuth(OAuth2Auth<[AuthFlow]>)
namespace Pagination;

model AuthFlow {
    type: OAuth2FlowType.clientCredentials;
    tokenUrl: "https://pagnation.azure.com/token";
    refreshUrl: "https://pagination.azure.com/refresh";
    scopes: [
        "https://pagination.azure.com/.default"
    ]
}

//
// ** Parameter descriptions **
//

@resource("transactions")
model LedgerEntry {
  @doc("Contents of the ledger entry.")
  contents: string;

  @visibility("read")
  collectionId: string;

  @key
  @visibility("read")
  // @doc("A unique identifier for the state of the ledger. If returned as part of a LedgerEntry, it indicates the state from which the entry was read.")
  transactionId: string;
}

@route("/app")
namespace Pagination {

  @summary("Gets ledger entries from a collection corresponding to a range.")
  @doc("A collection id may optionally be specified. Only entries in the specified (or default) collection will be returned.")
  op ListLedgerEntries is Azure.Core.ResourceList<LedgerEntry>;
  
}