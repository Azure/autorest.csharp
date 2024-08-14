import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

@resource("foos")
model Foo is TrackedResource<FooProperties> {
    ...ResourceNameParameter<Foo, SegmentName = "foos">;

    ...ExtendedLocationProperty;
}

model FooProperties {
    /** the service url */
    serviceUrl?: url;

    /** something */
    something?: string;
}

@armResourceOperations
interface Foos {
    createOrUpdate is ArmResourceCreateOrUpdateAsync<Foo>;

    get is ArmResourceRead<Foo>;
    
    delete is ArmResourceDeleteWithoutOkAsync<Foo>;

    list is ArmResourceListByParent<Foo>;
}
