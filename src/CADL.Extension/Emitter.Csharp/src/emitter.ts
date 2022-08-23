// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
    getDoc,
    getServiceNamespace,
    getServiceNamespaceString,
    getServiceTitle,
    getServiceVersion,
    getSummary,
    ModelTypeProperty,
    OperationType,
    Program,
    resolvePath
} from "@cadl-lang/compiler";
import {
    getAllRoutes,
    getAuthentication,
    getServers,
    HttpOperationParameter,
    HttpOperationResponse,
    OperationDetails,
    ServiceAuthentication
} from "@cadl-lang/rest/http";
import { CodeModel } from "./type/CodeModel.js";
import { InputClient } from "./type/InputClient.js";

import { stringifyRefs, PreserveType } from "json-serialize-refs";
import { InputOperation } from "./type/InputOperation.js";
import { parseHttpRequestMethod } from "./type/RequestMethod.js";
import { BodyMediaType } from "./type/BodyMediaType.js";
import { InputParameter } from "./type/InputParameter.js";
import { InputEnumType, InputModelType, InputType } from "./type/InputType.js";
import { RequestLocation, requestLocationMap } from "./type/RequestLocation.js";
import { OperationResponse } from "./type/OperationResponse.js";
import { getInputType } from "./lib/model.js";
import { InputOperationParameterKind } from "./type/InputOperationParameterKind.js";
import { resolveServers } from "./lib/cadlServer.js";
import { getExternalDocs, getOperationId } from "./lib/decorators.js";
import { InputAuth } from "./type/InputAuth.js";
import { InputOAuth2Auth } from "./type/InputOAuth2Auth.js";

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
        if (root) {
            await program.host.writeFile(
                outPath,
                prettierOutput(
                    stringifyRefs(root, null, 1, PreserveType.Objects)
                )
            );
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
    const authentication = getAuthentication(program, serviceNamespaceType);
    let auth = undefined;
    if (authentication) {
        auth = processServiceAuthentication(authentication);
    }
    const modelMap = new Map<string, InputModelType>();
    const enumMap = new Map<string, InputEnumType>();
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
        for (const operation of routes) {
            console.log(JSON.stringify(operation.path));
            if (!isSupportedOperation(operation)) continue;
            const groupName: string = getOperationGroupName(
                program,
                operation.operation
            );
            let client = getClient(clients, groupName);
            if (!client) {
                const container = operation.container;
                const clientDesc = getDoc(program, container);
                const clientSummary = getSummary(program, container);
                client = {
                    Name: groupName,
                    Description: clientDesc,
                    Operations: [],
                    Protocol: {}
                } as InputClient;
                clients.push(client);
            }
            const op: InputOperation = loadOperation(
                program,
                operation,
                endPointParam,
                modelMap,
                enumMap
            );
            client.Operations.push(op);
        }

        const clientModel = {
            Name: namespace,
            Description: description,
            ApiVersions: apiVersions,
            Enums: Array.from(enumMap.values()),
            Models: Array.from(modelMap.values()),
            Clients: clients,
            Auth: auth
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

function processServiceAuthentication(
    authentication: ServiceAuthentication
): InputAuth {
    const auth = {} as InputAuth;
    for (const option of authentication.options) {
        for (const schema of option.schemes) {
            switch (schema.type) {
                case "apiKey":
                    auth.ApiKey = schema.name;
                    break;
                case "oauth2":
                    let scopes: string[] = [];
                    for (const flow of schema.flows) {
                        switch (flow.type) {
                            case "clientCredentials":
                                scopes = scopes.concat(flow.scopes);
                                break;
                            default:
                                throw new Error(
                                    "Not Supported Authentication."
                                );
                        }
                    }
                    auth.OAuth2 = {
                        Scopes: scopes
                    } as InputOAuth2Auth;
                    break;
                default:
                    throw new Error("Not supported authentication.");
            }
        }
    }
    return auth;
}

function getOperationGroupName(
    program: Program,
    operation: OperationType
): string {
    const explicitOperationId = getOperationId(program, operation);
    if (explicitOperationId) {
        const ids: string[] = explicitOperationId.split("_");
        if (ids.length > 1) {
            return ids.slice(0, -2).join("_");
        }
    }

    if (operation.interface) {
        return operation.interface.name;
    }
    let namespace = operation.namespace;
    if (!namespace) {
        namespace =
            program.checker.getGlobalNamespaceType() ??
            getServiceNamespace(program);
    }

    if (namespace) return namespace.name;
    else return "";
}

function loadOperation(
    program: Program,
    operation: OperationDetails,
    endpoint: InputParameter | undefined = undefined,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
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
    if (endpoint) parameters.push(endpoint);
    for (const p of cadlParameters.parameters) {
        parameters.push(loadOperationParameter(program, p));
    }

    const bodyType = cadlParameters.bodyType;
    const bodyParam = cadlParameters.bodyParameter;

    if (bodyType && bodyParam) {
        parameters.push(loadBodyParameter(program, bodyParam));
    }

    const responses: OperationResponse[] = [];
    for (const res of operation.responses) {
        const operationResponse = loadOperationResponse(program, res);
        if (operationResponse) {
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

    function loadOperationParameter(
        program: Program,
        parameter: HttpOperationParameter
    ): InputParameter {
        const { type: location, name, param } = parameter;
        const cadlType = param.type;
        const inputType: InputType = getInputType(
            program,
            cadlType,
            models,
            enums
        );
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

    function loadBodyParameter(
        program: Program,
        body: ModelTypeProperty
    ): InputParameter {
        const { type, name, model: cadlType } = body;
        const inputType: InputType = getInputType(program, type, models, enums);
        const requestLocation = RequestLocation.Body;
        const kind: InputOperationParameterKind =
            InputOperationParameterKind.Method;
        return {
            Name: name,
            NameInRequest: name,
            Description: getDoc(program, body),
            Type: inputType,
            Location: requestLocation,
            IsRequired: !body.optional,
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
        if (!response.statusCode || response.statusCode === "*") {
            return undefined;
        }
        const status: number[] = [];
        status.push(Number(response.statusCode));
        const body = response.responses[0]?.body;
        let type: InputType | undefined = undefined;
        if (body?.type) {
            const cadlType = body.type;
            const inputType: InputType = getInputType(
                program,
                cadlType,
                models,
                enums
            );
            type = inputType;
        }

        return {
            StatusCodes: status,
            BodyType: type,
            BodyMediaType: BodyMediaType.Json
        } as OperationResponse;
    }
}

function isLROOperation(op: OperationDetails) {
    return false;
}
function isPagingOperation(op: OperationDetails) {
    return false;
}
function isSupportedOperation(op: OperationDetails) {
    if (isLROOperation(op) || isPagingOperation(op)) return false;
    return true;
}
class ErrorTypeFoundError extends Error {
    constructor() {
        super("Error type found in evaluated Cadl output");
    }
}
