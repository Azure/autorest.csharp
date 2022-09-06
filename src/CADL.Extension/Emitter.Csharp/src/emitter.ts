// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
    getDoc,
    getServiceNamespace,
    getServiceNamespaceString,
    getServiceTitle,
    getServiceVersion,
    getSummary,
    ModelType,
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
// import {
//     getLongRunningStates,
//     getPagedResult
// } from "@azure-tools/cadl-azure-core"
import { getExtensions } from "@cadl-lang/openapi";
import { CodeModel } from "./type/CodeModel.js";
import { InputClient } from "./type/InputClient.js";

import { stringifyRefs, PreserveType } from "json-serialize-refs";
import { InputOperation } from "./type/InputOperation.js";
import { RequestMethod, parseHttpRequestMethod } from "./type/RequestMethod.js";
import { BodyMediaType } from "./type/BodyMediaType.js";
import { InputParameter } from "./type/InputParameter.js";
import {
    InputEnumType,
    InputModelType,
    InputPrimitiveType,
    InputType
} from "./type/InputType.js";
import { RequestLocation, requestLocationMap } from "./type/RequestLocation.js";
import { OperationResponse } from "./type/OperationResponse.js";
import { getDefaultValue, getInputType } from "./lib/model.js";
import { InputOperationParameterKind } from "./type/InputOperationParameterKind.js";
import { resolveServers } from "./lib/cadlServer.js";
import {
    convenienceApiKey,
    getExternalDocs,
    getOperationId
} from "./lib/decorators.js";
import { InputAuth } from "./type/InputAuth.js";
import { InputApiKeyAuth } from "./type/InputApiKeyAuth.js";
import { InputOAuth2Auth } from "./type/InputOAuth2Auth.js";
import { getConsumes, getProduces } from "@cadl-lang/rest";
import { InputTypeKind } from "./type/InputTypeKind.js";
import { InputConstant } from "./type/InputConstant.js";

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

    // const apiVersions: string[] = [];
    // apiVersions.push(version);
    let apiVersions: Set<string> = new Set<string>();
    apiVersions.add(version);
    const apiVersionParam: InputParameter = {
        Name: "apiVersion",
        NameInRequest: "api-version",
        Description: "",
        Type: {
            Name: "String",
            Kind: InputTypeKind.String,
            IsNullable: false
        } as InputPrimitiveType,
        Location: RequestLocation.Query,
        IsRequired: true,
        IsApiVersion: true,
        IsContentType: false,
        IsEndpoint: false,
        IsResourceParameter: false,
        SkipUrlEncoding: false,
        Explode: false,
        Kind: InputOperationParameterKind.Client,
        // DefaultValue:
        // apiVersions.size === 1
        //         ? ({
        //               Type: {
        //                 Name: "String",
        //                 Kind: InputTypeKind.String,
        //                 IsNullable: false
        //               } as InputPrimitiveType,
        //               Value: version
        //           } as InputConstant)
        //         : undefined
    };
    const namespace =
        getServiceNamespaceString(program)?.toLowerCase() || "client";
    const authentication = getAuthentication(program, serviceNamespaceType);
    let auth = undefined;
    if (authentication) {
        auth = processServiceAuthentication(authentication);
    }
    const consumes = getConsumes(program, serviceNamespaceType);
    let contentTypeParameter = undefined;
    if (consumes && consumes.length > 0) {
        contentTypeParameter = createContentTypeOrAcceptParameter(
            consumes,
            "contentType",
            "Content-Type"
        );
    }
    const produces = getProduces(program, serviceNamespaceType);
    let acceptParameter = undefined;
    if (produces && produces.length > 0) {
        acceptParameter = createContentTypeOrAcceptParameter(
            produces,
            "Accept",
            "Accept"
        );
    }
    const modelMap = new Map<string, InputModelType>();
    const enumMap = new Map<string, InputEnumType>();
    try {
        const [routes] = getAllRoutes(program);
        console.log("routes:" + routes.length);
        const clients: InputClient[] = [];
        //create endpoint parameter from servers
        let endPointParam = undefined;
        let url: string = "";
        if (servers !== undefined) {
            const cadlServers = resolveServers(program, servers);
            if (cadlServers.length > 0) {
                /* choose the first server as endpoint. */
                url = cadlServers[0].url;
                endPointParam = cadlServers[0].parameters[0];
            }
        }

        const hasNoConvenienceApiDecorators = routes.every(
            (u) => !getExtensions(program, u.operation).has(convenienceApiKey)
        );

        for (const operation of routes) {
            console.log(JSON.stringify(operation.path));
            if (!isSupportedOperation(program, operation)) continue;
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
                url,
                endPointParam,
                modelMap,
                enumMap,
                hasNoConvenienceApiDecorators
            );
            if (
                contentTypeParameter &&
                op.Parameters.some(
                    (value) => value.Location === RequestLocation.Body
                ) &&
                !op.Parameters.some((value) => value.IsContentType === true)
            ) {
                op.Parameters.push(contentTypeParameter);
                op.RequestMediaTypes = consumes;
            }
            if (
                acceptParameter &&
                !op.Parameters.some(
                    (value) =>
                        value.Location === RequestLocation.Header &&
                        value.NameInRequest.toLowerCase() === "accept"
                )
            )
                op.Parameters.push(acceptParameter);
            
            // if (!op.Parameters.some((value) => value.IsApiVersion)) {
            //     op.Parameters.push(apiVersionParam);
            // }
            const apiVersion = op.Parameters.find(value => value.IsApiVersion);
            if (apiVersion) {
                apiVersions.add(apiVersion.DefaultValue?.Value);
                if (apiVersions.size > 1) {
                    apiVersion.Kind = InputOperationParameterKind.Constant;
                }
            } else {
                op.Parameters.push(apiVersionParam);
            }
            client.Operations.push(op);
        }
        if (apiVersions.size > 1) {
            apiVersionParam.Kind = InputOperationParameterKind.Constant;
        }

        const clientModel = {
            Name: namespace,
            Description: description,
            ApiVersions: Array.from(apiVersions.values()),
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

function createContentTypeOrAcceptParameter(
    mediaTypes: string[],
    name: string,
    nameInRequest: string
): InputParameter {
    const isContentType: boolean =
        nameInRequest.toLowerCase() === "content-type";
    const inputType: InputType = {
        Name: "String",
        Kind: InputTypeKind.String,
        IsNullable: false
    } as InputPrimitiveType;
    return {
        Name: name,
        NameInRequest: nameInRequest,
        Type: inputType,
        Location: RequestLocation.Header,
        IsApiVersion: false,
        IsResourceParameter: false,
        IsContentType: isContentType,
        IsRequired: true,
        IsEndpoint: false,
        SkipUrlEncoding: false,
        Explode: false,
        Kind: InputOperationParameterKind.Constant,
        DefaultValue:
            mediaTypes.length === 1
                ? ({
                      Type: inputType,
                      Value: mediaTypes[0]
                  } as InputConstant)
                : undefined
    } as InputParameter;
}

function processServiceAuthentication(
    authentication: ServiceAuthentication
): InputAuth {
    const auth = {} as InputAuth;
    let scopes: Set<string> | undefined;

    for (const option of authentication.options) {
        for (const schema of option.schemes) {
            switch (schema.type) {
                case "apiKey":
                    auth.ApiKey = { Name: schema.name } as InputApiKeyAuth;
                    break;
                case "oauth2":
                    for (const flow of schema.flows) {
                        if (flow.scopes) {
                            scopes ??= new Set<string>();
                            for (const scope of flow.scopes) {
                                scopes.add(scope);
                            }
                        }
                    }
                    break;
                default:
                    throw new Error("Not supported authentication.");
            }
        }
    }

    if (scopes) {
        auth.OAuth2 = {
            Scopes: Array.from(scopes.values())
        } as InputOAuth2Auth;
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
    uri: string,
    endpoint: InputParameter | undefined = undefined,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>,
    hasNoConvenienceApiDecorators: boolean
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

    const mediaTypes: string[] = [];
    const contentTypeParameter = parameters.find(
        (value) => value.IsContentType
    );
    if (contentTypeParameter) {
        mediaTypes.push(contentTypeParameter.DefaultValue?.Value);
    }
    const requestMethod = parseHttpRequestMethod(verb);
    const generateConvenienceMethod =
        requestMethod !== RequestMethod.PATCH &&
        (hasNoConvenienceApiDecorators ||
            getExtensions(program, op).get(convenienceApiKey));

    return {
        Name: op.name,
        Summary: summary,
        Description: desc,
        Parameters: parameters,
        Responses: responses,
        HttpMethod: requestMethod,
        RequestBodyMediaType: BodyMediaType.Json,
        Uri: uri,
        Path: fullPath,
        ExternalDocsUrl: externalDocs?.url,
        RequestMediaTypes: mediaTypes.length > 0 ? mediaTypes : undefined,
        BufferResponse: false,
        GenerateConvenienceMethod: generateConvenienceMethod
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
        let defaultValue = undefined;
        const value = getDefaultValue(cadlType);
        if (value) {
            defaultValue = {
                Type: inputType,
                Value: value
            } as InputConstant;
        }
        const requestLocation = requestLocationMap[location];
        const isApiVersion: boolean = requestLocation === RequestLocation.Query && name.toLocaleLowerCase() === "api-version";
        const isContentType: boolean =
            requestLocation === RequestLocation.Header &&
            name.toLowerCase() === "content-type";
        const kind: InputOperationParameterKind = isContentType
            ? InputOperationParameterKind.Constant
            : (isApiVersion ? InputOperationParameterKind.Client : InputOperationParameterKind.Method);
        return {
            Name: param.name,
            NameInRequest: name,
            Description: getDoc(program, param),
            Type: inputType,
            Location: requestLocation,
            DefaultValue: defaultValue,
            IsRequired: !param.optional,
            IsApiVersion: isApiVersion,
            IsResourceParameter: false,
            IsContentType: isContentType,
            IsEndpoint: false,
            SkipUrlEncoding: false, //TODO: retrieve out value from extension
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
            SkipUrlEncoding: false,
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

function isLroOperation(program: Program, op: OperationDetails) {
    // for (const res of op.responses) {
    //     if (res.responses[0]?.body) {
    //         if (res.responses[0].body.type as ModelType) {
    //             const lroMetadata = getLongRunningStates(program, res.responses[0]?.body.type as ModelType);
    //         }
    //     }
    // }
    
    return false;
}
function isPagingOperation(program: Program, op: OperationDetails) {
    // const pagingMetadata = getPagedResult(program, op.operation);
    return false;
}
function isSupportedOperation(program: Program, op: OperationDetails) {
    if (isLroOperation(program, op) || isPagingOperation(program, op)) return false;
    return true;
}
class ErrorTypeFoundError extends Error {
    constructor() {
        super("Error type found in evaluated Cadl output");
    }
}
