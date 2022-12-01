import { passOnSuccess, ScenarioMockApi, mockapi, json, MockApi } from "@azure-tools/cadl-ranch-api";

export const Scenarios: Record<string, ScenarioMockApi> = {};

Scenarios.DeleteAPetById = passOnSuccess(
  mockapi.delete("/pets/1", () => {
    return {
      status: 200,
    };
  }),
);

