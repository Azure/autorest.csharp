// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
    getDoc,
    getServiceNamespace,
    getServiceNamespaceString,
    getServiceTitle,
    getServiceVersion,
    getSummary,
    Program,
    resolvePath
} from "@cadl-lang/compiler";
import {
    getAllRoutes,
    getServers,
    HttpOperationParameter,
    HttpOperationResponse,
    OperationDetails
} from "@cadl-lang/rest/http";
import { CodeModel } from "./type/CodeModel";
import { InputClient } from "./type/InputClient";
import { dump } from "js-yaml";

import { stringifyRefs, PreserveType } from "json-serialize-refs";
import { InputOperation } from "./type/InputOperation.js";
import { parseHttpRequestMethod } from "./type/RequestMethod.js";
import { BodyMediaType } from "./type/BodyMediaType.js";
import { InputParameter } from "./type/InputParameter.js";
import { InputType } from "./type/InputType.js";
import { InputTypeKind } from "./type/InputTypeKind.js";
import { RequestLocation, requestLocationMap } from "./type/RequestLocation.js";
import { OperationResponse } from "./type/OperationResponse.js";
import { getInputType } from "./lib/model.js";
import { InputOperationParameterKind } from "./type/InputOperationParameterKind.js";
import { resolveServers } from "./lib/cadlServer.js";
import { getExternalDocs } from "./lib/decorators.js";

export interface NetEmitterOptions {
    outputFile: string;
    logFile: string;
}

const defaultOptions = {
    outputFile: "cadl.json",
    logFile: "log.json"
};

export async function $onEmit(
    program: Program,
    emitterOptions: NetEmitterOptions
) {
    const resolvedOptions = { ...defaultOptions, ...emitterOptions };
    const options: NetEmitterOptions = {
        outputFile: resolvePath(
            program.compilerOptions.outputPath ?? "./cadl-output",
            resolvedOptions.outputFile
        ),
        logFile: resolvePath(
            program.compilerOptions.outputPath ?? "./cadl-output",
            resolvedOptions.logFile
        )
    };
    const version: string = "";
    if (!program.compilerOptions.noEmit && !program.hasError()) {
        // Write out the dotnet model to the output path
        const namespace =
            getServiceNamespaceString(program)?.toLowerCase() || "";
        const outPath =
            version.trim().length > 0
                ? resolvePath(
                      options.outputFile?.replace(".json", `.${version}.json`)
                  )
                : resolvePath(options.outputFile);

        const root = createModel(program);
        // await program.host.writeFile(outPath, prettierOutput(JSON.stringify(root, null, 2)));
        if (root !== undefined) {
            await program.host.writeFile(
                outPath,
                prettierOutput(
                    stringifyRefs(root, null, 1, PreserveType.Objects)
                )
            );
            const yamlOutPath = resolvePath(
                options.outputFile?.replace(".json", `.yaml`)
            );
            await program.host.writeFile(yamlOutPath, dump(root));
        }
    }
}

function prettierOutput(output: string) {
    return output + "\n";
}
function getClient(
    clients: InputClient[],
    clientName: string
): InputClient | undefined {
    for (const client of clients) {
        if (client.Name === clientName) return client;
    }

    return undefined;
}

function createModel(program: Program): any {
    const serviceNamespaceType = getServiceNamespace(program);
    if (!serviceNamespaceType) {
        return;
    }
    const title = getServiceTitle(program);
    const version = getServiceVersion(program);
    if (version === "0000-00-00") {
        console.error("No API-Version provided.");
        return;
    }
    const description = getDoc(program, serviceNamespaceType);
    const externalDocs = getExternalDocs(program, serviceNamespaceType);

    const servers = getServers(program, serviceNamespaceType);

    const apiVersions: string[] = [];
    apiVersions.push(version);
    const namespace =
        getServiceNamespaceString(program)?.toLowerCase() || "client";
    try {
        const [routes] = getAllRoutes(program);
        console.log("routes:" + routes.length);
        const clients: InputClient[] = [];

        //create endpoint parameter from servers
        let endPointParam = undefined;
        if (servers !== undefined) {
            const calServers = resolveServers(program, servers);
            if (calServers.length > 0) {
                /* choose the first server as endpoint. */
                endPointParam = calServers[0].parameters[0];
            }
        }

        const apiVersionParam: InputParameter = {
            Name: "apiVersion",
            NameInRequest: "apiVersion",
            Description: "",
            Type: new InputType("string", InputTypeKind.String, false),
            Location: RequestLocation.Query,
            IsRequired: true,
            IsApiVersion: true,
            IsContentType: false,
            IsEndpoint: false,
            IsResourceParameter: false,
            SkipUrlEncoding: false,
            Explode: false,
            Kind: InputOperationParameterKind.Client
        };
        for (const operation of routes) {
            console.log(JSON.stringify(operation.path));
            const groupName: string = operation.groupName;
            let client = getClient(clients, groupName);
            if (client === undefined) {
                const container = operation.container;
                const clientDes = getDoc(program, container);
                const clientSummary = getSummary(program, container);
                client = {
                    Name: groupName,
                    Operations: [],
                    Protocol: {}
                } as InputClient;
                clients.push(client);
            }
            const op: InputOperation = loadOperation(
                program,
                operation,
                endPointParam,
                apiVersionParam
            );
            client.Operations.push(op);
        }

        const clientModel = {
            Name: namespace,
            Description: description,
            ApiVersions: apiVersions,
            Clients: clients,
            Auth: {}
        } as CodeModel;
        return clientModel;
    } catch (err) {
        if (err instanceof ErrorTypeFoundError) {
            return;
        } else {
            throw err;
        }
    }
}

function loadOperationParameter(
    program: Program,
    parameter: HttpOperationParameter
): InputParameter {
    const { type: location, name, param } = parameter;
    const cadlType = param.type;
    const inputType: InputType = getInputType(program, cadlType);
    const requestLocation = requestLocationMap[location];
    const kind: InputOperationParameterKind =
        InputOperationParameterKind.Method;
    return {
        Name: name,
        NameInRequest: name,
        Description: getDoc(program, param),
        Type: inputType,
        Location: requestLocation,
        IsRequired: !param.optional,
        IsApiVersion: false,
        IsResourceParameter: false,
        IsContentType: false,
        IsEndpoint: false,
        SkipUrlEncoding: true,
        Explode: false,
        Kind: kind
    } as InputParameter;
}

function loadOperationResponse(
    program: Program,
    response: HttpOperationResponse
): OperationResponse | undefined {
    if (response.statusCode === undefined || response.statusCode === "*") {
        return undefined;
    }
    const status: number[] = [];
    status.push(Number(response.statusCode));
    const body = response.responses[0].body;
    let type: InputType | undefined = undefined;
    if (body !== undefined) {
        if (body.type !== undefined) {
            const cadlType = body.type;
            const inputType: InputType = getInputType(program, cadlType);
            type = inputType;
        }
    }

    return {
        StatusCodes: status,
        BodyType: type,
        BodyMediaType: BodyMediaType.Json
    } as OperationResponse;
}
function loadOperation(
    program: Program,
    operation: OperationDetails,
    endpoint: InputParameter | undefined = undefined,
    apiVersion: InputParameter | undefined = undefined
): InputOperation {
    const {
        path: fullPath,
        operation: op,
        verb,
        parameters: cadlParameters
    } = operation;
    console.log(`load operation: ${op.name}, path:${fullPath} `);
    const desc = getDoc(program, op);
    const summary = getSummary(program, op);
    const externalDocs = getExternalDocs(program, op);

    const parameters: InputParameter[] = [];
    if (endpoint !== undefined) parameters.push(endpoint);
    if (apiVersion !== undefined) parameters.push(apiVersion);

    for (const p of cadlParameters.parameters) {
        parameters.push(loadOperationParameter(program, p));
    }

    const responses: OperationResponse[] = [];
    for (const res of operation.responses) {
        const operationResponse = loadOperationResponse(program, res);
        if (operationResponse !== undefined) {
            responses.push(operationResponse);
        }
    }

    return {
        Name: op.name,
        Summary: summary,
        Description: desc,
        Parameters: parameters,
        Responses: responses,
        HttpMethod: parseHttpRequestMethod(verb),
        RequestBodyMediaType: BodyMediaType.Json,
        Uri:
            endpoint !== undefined && endpoint.Name !== ""
                ? `{${endpoint.Name}}/`
                : "",
        Path: fullPath,
        ExternalDocsUrl: externalDocs?.url,
        BufferResponse: false
    } as InputOperation;
}

class ErrorTypeFoundError extends Error {
    constructor() {
        super("Error type found in evaluated Cadl output");
    }
}
