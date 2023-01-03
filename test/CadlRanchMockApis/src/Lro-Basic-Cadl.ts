import { passOnSuccess, ScenarioMockApi, mockapi, json, MockApi } from "@azure-tools/cadl-ranch-api";

/**
 * Test mock server for `lro-basic-cadl` test project.
 */
export const Scenarios: Record<string, ScenarioMockApi> = {};

const projectCreationRequest = {
  description: "foo",
  name: "bar"
};

const projectUpdateRequest = {
  description: "test",
  name: "test"
};

const projectUpdateResponse = {
  id: "123",
  description: "test",
  name: "test"
};

const pollingSuccessResponse = {
  status: "Succeeded"
};

Scenarios.LroBasic_CreateProject = passOnSuccess([
  mockapi.post("/projects", (req) => {
    req.expect.bodyEquals(projectCreationRequest);
    return {
      status: 201,
      headers: { "operation-location": `${req.baseUrl}/lro/post/polling`},
      body: json("On going...")
    };
  }),
  mockapi.get("/lro/post/polling", (req) => {
    return {
      status: 200,
      body: json(pollingSuccessResponse),
    };
  })
]);

Scenarios.LroBasic_UpdateProject = passOnSuccess([
  mockapi.put("/projects/123", (req) => {
    req.expect.bodyEquals(projectUpdateRequest);
    return {
      status: 201,
      headers: { "operation-location": `${req.baseUrl}/lro/put/polling`},
      body: json("On going...")
    };
  }),
  mockapi.get("/lro/put/polling", (req) => {
    return {
      status: 200,
      body: json(pollingSuccessResponse),
    };
  }),
  mockapi.get("/projects/123", (req) => {
    return {
      status: 200,
      body: json(projectUpdateResponse),
    };
  })
]);

Scenarios.LroBasic_GetLroPaginationProjects = passOnSuccess([
  mockapi.get("/lro/pagination/projects", (req) => {
    return {
      status: 200,
      headers: { "operation-location": `${req.baseUrl}/lro/pagination/polling` },
      body: json("On going...")
    };
  }),
  mockapi.get("/lro/pagination/polling", (req) => {
    return {
      status: 200,
      body: json({
        status: "Succeeded",
        resourceLocation: `${req.baseUrl}/lro/pagination/results`
      })
    };
  }),
  mockapi.get("/lro/pagination/results", (req) => {
    return {
      status: 200,
      body: json({
        status: "Succeeded",
        value: [{
            id: "1",
            name: "name1",
            description: "description1"
        },{
            id: "2",
            name: "name2",
            description: "description2"
        }],
        nextLink: `${req.baseUrl}/lro/pagination/results/next`
      }),
    };
  }),
  mockapi.get("/lro/pagination/results/next", (req) => {
    return {
      status: 200,
      body: json({
        value: [{
          id: "3",
          name: "name3",
          description: "description3"
        }]
      }),
    };
  })
]);
