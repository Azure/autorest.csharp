import { passOnSuccess, ScenarioMockApi, mockapi, json, MockApi } from "@azure-tools/cadl-ranch-api";

export const Scenarios: Record<string, ScenarioMockApi> = {};

const dog = {
  name: "dog",
  age: 12,
};

Scenarios.PetStore_CreatePet = passOnSuccess(
  mockapi.post("/pets", (req) => {
    req.expect.bodyEquals(dog);
    return {
      status: 200,
      body: json(dog),
    };
  }),
);
