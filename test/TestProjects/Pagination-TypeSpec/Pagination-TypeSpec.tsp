import "@typespec/rest";
import "@typespec/http";
import "@typespec/versioning";
import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using TypeSpec.Versioning;
using Azure.Core;
using Azure.Core.Traits;
using Azure.ClientGenerator.Core;

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

// @doc("A unique identifier for the state of the ledger. If returned as part of a LedgerEntry, it indicates the state from which the entry was read.")
// model TransactionId is string;

// model CollectionIdParameter {
//   @query
//   @doc("The collection id.")
//   collectionId?: string;
// }

//
// ** Model descriptions **
//

// @resource("collections")
// @doc("Identifier for collections.")
// model Collection {
//   @key
//   collectionId: string;
// }

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

@doc("Paginated ledger entries")
@pagedResult
model PagedLedgerEntries {
  @doc("Array of ledger entries")
  @items
  entries: LedgerEntry[];

  @doc("Path to retrieve next page of ledger entries")
  @nextLink
  customNextLink?: ResourceLocation<LedgerEntry>;
}

@doc("List {name} resources", TResource)
op CustomResourceList<
  TResource extends object,
  TCustom extends Foundations.CustomizationFields = {}
> is Foundations.ResourceList<
  TResource,
  Foundations.CustomParameters<TCustom>,
  Page<TResource>
>;

// // TODO: No way to set "x-ms-enum.name" right now
// @doc("Represents an assignable role.")
// @knownValues(LedgerUserRoleKV)
// model LedgerUserRole is string {};

@doc("User roles")
enum LedgerUserRoleKV {
  Administrator,
  Contributor,
  Reader,
}

// @resource("users")
// @doc("Details about a Confidential ledger user.")
// model LedgerUser {
//   @key
//   @doc("The user id, either an AAD object ID or certificate fingerprint.")
//   @extension("x-ms-skip-url-encoding", true)
//   userId: string;

//   @doc("The user's assigned role.")
//   assignedRole: LedgerUserRole;
// }

// model ReceiptContents {
//   // Elided for now
// }

// // TODO: No way to set "x-ms-enum.name" right now
// @doc("State of a ledger query.")
// @knownValues(LedgerQueryStateKV)
// model LedgerQueryState is string {};

// enum LedgerQueryStateKV {
//   Loading,
//   Ready,
// }

// @doc("A receipt certifying the transaction at the specified id.")
// model TransactionReceipt {
//   receipt: ReceiptContents;
//   state: LedgerQueryState;
//   transactionId: string;
// }

// // TODO: No way to set "x-ms-enum.name" right now
// @doc("Represents the state of the transaction.")
// @knownValues(TransactionStateKV)
// model TransactionState is string {};

// enum TransactionStateKV {
//   Committed,
//   Pending,
// }

// @doc("Response returned to a query for the transaction status.")
// model TransactionStatus {
//   state: TransactionState;
//   transactionId: string;
// }


@doc("Type for input model body")
model ListLedgerEntryInputBody {
  @doc("Required string")
  requiredString: string;

  @doc("Required int")
  requiredInt: int32;
}

@doc("Input model for the ListPaginationLedgerEntries")
model ListLedgerEntryInput {
  @doc("Body parameter")
  @body bodyInput: ListLedgerEntryInputBody;
}

@doc("Text Blocklist.")
@resource("text/blocklists")
model TextBlocklist {
  @doc("Text blocklist name. Only supports the following characters: 0-9  A-Z  a-z  -  .  _  ~")
  @key("blocklistName")
  @visibility("read", "create", "query")
  @maxLength(64)
  blocklistName: string;

  @doc("Text blocklist description.")
  @maxLength(1024)
  description?: string;
}

@doc("Item in TextBlocklist.")
@resource("blockItems")
@parentResource(TextBlocklist)
model TextBlockItem {
  @doc("Block Item Id. It will be uuid.")
  @key("blockItemId")
  @visibility("read", "create", "query")
  @maxLength(64)
  blockItemId: string;

  @doc("Block item description.")
  @maxLength(1024)
  description?: string;

  @doc("Block item content.")
  @maxLength(128)
  text: string;
}

enum Interval {
  @doc("5 seconds, available only if test run duration is less than 10 minutes")
  PT5S,
  @doc("10 seconds, available only if test run duration is less than 10 minutes")
  PT10S,
  @doc("1 minute") PT1M,
  @doc("5 minutes, available only if test run duration is greater than 1 minute")
  PT5M,
  @doc("1 hour, available only if test run duration is greater than 1 minute")
  PT1H,
}

model MetricDimensions {
  @doc("The interval (i.e. timegrain) of the query.")
  @query
  interval?: Interval;

  @doc("Metric name")
  @query
  metricName?: string;

  @doc("Metric namespace to query metric definitions for.")
  @query
  metricNamespace: string;

  @doc("""
  The timespan of the query. It is a string with the following format
  'startDateTime_ISO/endDateTime_ISO'.
  """)
  @query
  timespan?: string;
};

@resource("values")
@parentResource(Dimension)
model DimensionValueList {
  @key
  value: string[];
}

@resource("metric-dimensions")
@parentResource(TestRuns)
model Dimension {
  @key
  @doc("Dimension name")
  @path("name")
  @visibility("query")
  name: string;
}

@doc("Load test run model")
@resource("test-runs")
model TestRuns {
  // FIXME: is testRunId optional or required in the response? Resource key and path params cannot be optional
  @key
  @path
  @doc("Unique test run name as identifier")
  @visibility("read")
  testRunId: string;
}

//
// ** Operations **
//

@route("/app")
namespace Pagination {
  @summary("Gets ledger entries from a collection corresponding to a range.")
  @doc("A collection id may optionally be specified. Only entries in the specified (or default) collection will be returned.")
  op ListPaginationLedgerEntries is Azure.Core.Foundations.ResourceList<LedgerEntry, ListLedgerEntryInput, PagedLedgerEntries>;
}

interface AdditionalParameter {  
  @summary("List the dimension values for the given metric dimension name.")
  @doc("List the dimension values for the given metric dimension name.")
  ListMetricDimensionValues is Azure.Core.ResourceList<
    DimensionValueList, QueryParametersTrait<MetricDimensions>
  >;
}

@route("/adp")
interface UseFoundationsResourceList {
  @doc("List upload detail for the discovery resource.")
  list is CustomResourceList<LedgerEntry>;  
}

interface TwoTypesItem {
  @summary("Get All Text Blocklists")
  @doc("Get all text blocklists details.")
  listTextBlocklists is Azure.Core.ResourceList<TextBlocklist>;

  @summary("Get All BlockItems By blocklistName")
  @doc("Get all blockItems in a text blocklist")
  listTextBlocklistItems is Azure.Core.ResourceList<
    TextBlockItem,
    ListQueryParametersTrait<StandardListQueryParameters>
  >;
}
