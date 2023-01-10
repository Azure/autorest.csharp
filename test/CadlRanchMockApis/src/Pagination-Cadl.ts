import { passOnSuccess, ScenarioMockApi, mockapi, json, MockApi } from "@azure-tools/cadl-ranch-api";

export const Scenarios: Record<string, ScenarioMockApi> = {};

Scenarios.Pagination_UsingCustomPageTemplate = passOnSuccess([
  mockapi.get("/app/transactions", (req) => {
    return {
      status: 200,
      body: json({
        value: [{ contents: "contents", collectionId: "collection", transactionId: "transaction" }],
        nextLink: req.baseUrl + "/app/transactions/2",
      }),
    };
  }),
  mockapi.get("/app/transactions/2", (req) => {
    return {
      status: 200,
      body: json({
        value: [{ contents: "contents2", collectionId: "collection2", transactionId: "transaction2" }],
      }),
    };
  }),
]);

Scenarios.Pagination_UsingPageTemplate = passOnSuccess([
  mockapi.get("/app/adp/transactions", (req) => {
    return {
      status: 200,
      body: json({
        value: [{ contents: "contents", collectionId: "collection", transactionId: "transaction" }],
        nextLink: req.baseUrl + "/app/adp/transactions/2",
      }),
    };
  }),
  mockapi.get("/app/adp/transactions/2", (req) => {
    return {
      status: 200,
      body: json({
        value: [{ contents: "contents2", collectionId: "collection2", transactionId: "transaction2" }],
      }),
    };
  }),
])