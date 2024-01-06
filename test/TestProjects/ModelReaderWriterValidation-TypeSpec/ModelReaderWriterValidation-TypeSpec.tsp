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

@doc("The tracked resource data")
model TrackedResourceData {
    @doc("The id property.")
    @visibility("read")
    id: string;

    @doc("The name property.")
    @visibility("read")
    name: string;

    @doc("The resource type.")
    @visibility("read")
    resourceType: string;

    @doc("The location property.")
    location: string;

    @doc("The tags property.")
    tags?: Record<string>;
}

@doc("The availability set data")
model AvailabilitySetData extends TrackedResourceData {
    @doc("The sku.")
    sku?: ComputeSku;
    
    @doc("The properties property.")
    properties?: AvailabilitySetProperties;
}

@doc("The availability set properties")
model AvailabilitySetProperties {
    @doc("The virtual machines.")
    virtualMachines?: WritableSubResource[];

    @doc("The platform fault domain count property.")
    platformFaultDomainCount?: int32;

    @doc("The platform update domain count property.")
    platformUpdateDomainCount?: int32;
}

model ComputeSku {
    @doc("The sku name.")
    name?: string;

    @doc("Specifies the tier of virtual machines in a scale set.&lt;br /&gt;&lt;br /&gt; Possible Values:&lt;br /&gt;&lt;br /&gt; **Standard**&lt;br /&gt;&lt;br /&gt; **Basic**.")
    tier?: string;
    
    @doc("Specifies the number of virtual machines in the scale set.")
    capacity?: int64;
}

@doc("The writable sub resource")
model WritableSubResource {
    @doc("The resource id")
    id?: string;
}

@route("/api/AvailabilitySet")
@convenientAPI(true)
op op4(@body body: AvailabilitySetData): AvailabilitySetData;
