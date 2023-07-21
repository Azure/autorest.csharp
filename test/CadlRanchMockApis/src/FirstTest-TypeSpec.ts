import { passOnSuccess, ScenarioMockApi, mockapi, json } from "@azure-tools/cadl-ranch-api";

/**
 * Test mock server for `FirstTest-TypeSpec` test project.
 */
export const Scenarios: Record<string, ScenarioMockApi> = {};

Scenarios.FirstTest_CreateLiteral = passOnSuccess([
  mockapi.post("/literal", (req) => {
    req.expect.bodyEquals({
        name: "test",
        requiredUnion: "test",
        requiredBadDescription: "abc",
        requiredLiteralString: "accept",
        requiredLiteralInt: 123,
        requiredLiteralFloat: 1.23,
        requiredLiteralBool: false,
        optionalLiteralString: "reject",
        optionalLiteralInt: 456,
        optionalLiteralFloat: 4.56,
        optionalLiteralBool: true,
        requiredNullableList: []
    });
    return {
      status: 200,
      body: json({
        name: "literal",
        requiredUnion: "union",
        requiredBadDescription: "def",
        // below are intentionally different from the request, to mimic the case that the library could handle the case if server returns different values from the client values
        requiredLiteralString: "reject",
        requiredLiteralInt: 12345,
        requiredLiteralFloat: 123.45,
        requiredLiteralBool: true,
        optionalLiteralString: "accept",
        optionalLiteralInt: 12345,
        optionalLiteralFloat: 123.45,
        optionalLiteralBool: false,
        requiredNullableList: []
      })
    };
  }),
]);
