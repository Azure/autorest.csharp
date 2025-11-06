import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

@resource("testReadonlyRequireds")
model TestReadonlyRequired is TrackedResource<TestReadonlyRequiredProperties> {
    ...ResourceNameParameter<TestReadonlyRequired, SegmentName = "testReadonlyRequireds">;
}

model TestReadonlyRequiredProperties {
    /** Required property */
    a: string;

    /** Optional property */
    b?: string;

    /** Required readonly property - should NOT be in public constructor */
    @visibility(Lifecycle.Read)
    c: string;

    /** Optional readonly property */
    @visibility(Lifecycle.Read)
    d?: string;
}

@armResourceOperations
interface TestReadonlyRequireds {
    get is ArmResourceRead<TestReadonlyRequired>;
}
