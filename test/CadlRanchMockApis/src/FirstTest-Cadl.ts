import { passOnSuccess, ScenarioMockApi, mockapi, json } from "@azure-tools/cadl-ranch-api";

/**
 * Test mock server for `FirstTest-cadl` test project.
 */
export const Scenarios: Record<string, ScenarioMockApi> = {};

Scenarios.FirstTestCadl_CreateLiteral = passOnSuccess([
  mockapi.post("/literal", (req) => {
    req.expect.bodyEquals({
        name: "test",
        requiredUnion: "test",
        requiredBadDescription: "abc",
        requiredLiteralString: "accept",
        requiredLiteralInt: 123,
        requiredLiteralDouble: 1.23,
        requiredLiteralBool: false,
        optionalLiteralString: "reject",
        optionalLiteralInt: 456,
        optionalLiteralDouble: 4.56,
        optionalLiteralBool: true,
    });
    return {
      status: 200,
      body: json({
        name: "literal",
        requiredUnion: "union",
        requiredBadDescription: "def",
        // below are useless
        requiredLiteralString: "reject",
        requiredLiteralInt: 12345,
        requiredLiteralDouble: 123.45,
        requiredLiteralBool: true,
        optionalLiteralString: "accept",
        optionalLiteralInt: 12345,
        optionalLiteralDouble: 123.45,
        optionalLiteralBool: false,
      })
    };
  }),
]);
