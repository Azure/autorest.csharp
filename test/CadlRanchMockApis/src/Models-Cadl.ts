import {
    passOnSuccess,
    ScenarioMockApi,
    mockapi,
    json,
} from "@azure-tools/cadl-ranch-api";

/**
 * Test mock server for `Models-cadl` test project.
 */
export const Scenarios: Record<string, ScenarioMockApi> = {};

Scenarios.ModelsCald_InputToRoundTripPrimitive = passOnSuccess([
    mockapi.get("/inputToRoundTripPrimitive", (req) => {
        req.expect.bodyEquals({
            requiredString: "test",
            requiredInt: 1,
            requiredModel: {},
            requiredIntCollection: [],
            requiredStringCollection: [],
            requiredModelCollection: [],
            requiredModelRecord: {},
            requiredCollectionWithNullableFloatElement: [12.3],
        });
        return {
            status: 200,
            body: json({
                requiredString: "test",
                requiredInt: 123,
                requiredInt64: 123456,
                requiredSafeInt: 1234567,
                requiredFloat: 12.3,
                required_Double: 123.456,
                requiredBoolean: true,
                requiredDateTimeOffset: "2023-02-14Z02:08:47",
                requiredTimeSpan: "P1DT2H59M59S",
                requiredCollectionWithNullableFloatElement: [null, 12.3],
            }),
        };
    }),
]);

Scenarios.ModelsCald_InputToRoundTripOptional = passOnSuccess([
    mockapi.get("/inputToRoundTripOptional", (req) => {
        req.expect.bodyEquals({
            optionalPlainDate: "2023-02-14",
            optionalPlainTime: "1.02:59:59",
        });
        return {
            status: 200,
            body: json({
                optionalCollectionWithNullableIntElement: [null, 123],
            }),
        };
    }),
]);
Scenarios.ModelsCald_InputToRoundTripReadOnly = passOnSuccess([
    mockapi.get("/inputToRoundTripReadOnly", (req) => {
        req.expect.bodyEquals({
            requiredString: "test",
            requiredInt: 2,
            requiredModel: { requiredCollection: [] },
            requiredIntCollection: [1, 2],
            requiredStringCollection: ["a"],
            requiredModelCollection: [],
            requiredModelRecord: {},
            requiredCollectionWithNullableFloatElement: [],
        });
        return {
            status: 200,
            body: json({
                requiredReadonlyString: "test",
                requiredReadonlyInt: 12,
                optionalReadonlyInt: 11,
                requiredReadonlyModel: { requiredCollection: [] },
                requiredReadonlyFixedStringEnum: "1",
                requiredReadonlyExtensibleEnum: "3",
                optionalReadonlyFixedStringEnum: "2",
                optionalReadonlyExtensibleEnum: "1",
                requiredReadonlyStringList: ["abc"],
                requiredReadonlyIntList: [],
                requiredReadOnlyModelCollection: [],
                requiredReadOnlyIntRecord: { test: 1 },
                requiredStringRecord: { test: "1" },
                requiredReadOnlyModelRecord: {},
                optionalReadonlyStringList: [],
                optionalReadOnlyModelCollection: [],
                optionalReadOnlyStringRecord: {},
                optionalModelRecord: { test: { requiredCollection: [] } },
                requiredCollectionWithNullableIntElement: [null, 123],
                optionalCollectionWithNullableBooleanElement: [
                    null,
                    false,
                    true,
                ],
            }),
        };
    }),
]);
