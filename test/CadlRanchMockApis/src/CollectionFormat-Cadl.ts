import { passOnSuccess, ScenarioMockApi, mockapi, json } from "@azure-tools/cadl-ranch-api";

export const Scenarios: Record<string, ScenarioMockApi> = {};

const options = ["value1", "value2", "value3"];
const thing = {
    name: "collectionFormat"
};
Scenarios.CollectionFormat_CsvQuery = passOnSuccess(
    mockapi.get("/csvQuery", (req) => {
        req.expect.containsQueryParam("options", "value1,value2,value3");
        console.log(req.query["options"]);
        return {
            status: 200,
            body: json(thing),
          };
    }),
);

Scenarios.CollectionFormat_MultiQuery = passOnSuccess(
    mockapi.get("/multiQuery", (req) => {
        if (req.query.options.length !== 3) {
            throw new Error("Query parameter 'options' should exploded as 3 query parameters.");
        }
        if (JSON.stringify(["value1", "value2", "value3"]) !== JSON.stringify(req.query.options)) {
            throw new Error("Query parameter 'options' is not correct.")
        }
        return {
            status: 200,
            body: json(thing),
          };
    }),
);

Scenarios.CollectionFormat_NoFormatQuery = passOnSuccess(
    mockapi.get("/noFormatQuery", (req) => {
        if (req.query.options.length !== 3) {
            throw new Error("Query parameter 'options' should exploded as 3 query parameters.");
        }
        if (JSON.stringify(["value1", "value2", "value3"]) !== JSON.stringify(req.query.options)) {
            throw new Error("Query parameter 'options' is not correct.")
        }
        return {
            status: 200,
            body: json(thing),
          };
    }),
);

Scenarios.CollectionFormat_CsvHeader = passOnSuccess(
    mockapi.get("/csvHeader", (req) => {
        req.expect.containsHeader("options", "value1,value2,value3");
        return {
            status: 200,
            body: json(thing),
          };
    }),
);

Scenarios.CollectionFormat_NoFormateHeader = passOnSuccess(
    mockapi.get("/noFormatHeader", (req) => {
        req.expect.containsHeader("options", "value1,value2,value3");
        return {
            status: 200,
            body: json(thing),
          };
    }),
);


