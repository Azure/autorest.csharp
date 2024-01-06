import "@typespec/rest";
import "@typespec/http";
import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";

@service({
    title: "Validation for MRW",
    version: "0.1.0",
})
@doc("This is a typespec project to validation the model reader writer functionalities.")
@server(
    "{endpoint}",
    "Endpoint Service",
    {
        endpoint: string,
    }
)
namespace ModelReaderWriterValidationTypeSpec;

using TypeSpec.Http;
using Azure.ClientGenerator.Core;
using Azure.Core;

@doc("The model to change to struct.")
model ModelAsStruct {
    @doc("The id property.")
    id: int32;
}

@route("/api/ModelAsStruct")
@convenientAPI(true)
op op1(@body body: ModelAsStruct): ModelAsStruct;

model ModelWithPersistableOnly {
    @doc("The name.")
    name?: string;

    @doc("The fields property.")
    fields?: string[];

    @doc("The nullable property.")
    nullProperty?: int32;

    @doc("The key value pairs property.")
    keyValuePairs?: Record<string>;

    @doc("The x property.")
    @visibility("read")
    xProperty: int32;
}

@route("/api/ModelWithPersistableOnly")
@convenientAPI(true)
op op2(@body body: ModelWithPersistableOnly): ModelWithPersistableOnly;

@doc("The BaseModel in the discriminated set")
@discriminator("kind")
model BaseModel {
    @doc("The kind")
    kind: string;

    @doc("The name property.")
    name?: string;
}

@doc("The ModelX in the discriminated set")
model ModelX extends BaseModel {
    kind: "X";

    @doc("Optional list.")
    fields?: string[];

    @doc("Nullable integer.")
    nullProperty?: int32;

    @doc("Optional dictionary.")
    keyValuePairs?: Record<string>;

    @doc("The XProperty property.")
    @visibility("read")
    xProperty: int32;
}

@doc("The ModelY in the discriminated set")
model ModelY extends BaseModel {
    kind: "Y";

    @doc("The YProperty property.")
    @visibility("read")
    yProperty: string;
}

@route("/api/DiscriminatedSet")
@convenientAPI(true)
op op3(@body body: BaseModel): BaseModel;
