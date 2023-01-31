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
        requiredLiteralString: "accept",
        requiredLiteralInt: 123,
        requiredLiteralDouble: 1.23,
        requiredLiteralBool: false,
    });
    return {
      status: 200,
      body: json({
        name: "literal",
        requiredUnion: "union",
        requiredLiteralString: "accept",
        // below are useless
        requiredLiteralInt: 12345,
        requiredLiteralDouble: 123.45,
        requiredLiteralBool: true,
      })
    };
  }),
]);
