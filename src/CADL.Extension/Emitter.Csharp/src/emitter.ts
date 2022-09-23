// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
    DecoratedType,
    getDoc,
    getServiceNamespace,
    getServiceNamespaceString,
    getServiceTitle,
    getServiceVersion,
    getSummary,
    Model,
    ModelProperty,
    Operation,
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
import { getExtensions } from "@cadl-lang/openapi";
import { CodeModel } from "./type/CodeModel.js";
import { InputClient } from "./type/InputClient.js";

import { stringifyRefs, PreserveType } from "json-serialize-refs";
import { InputOperation, Paging } from "./type/InputOperation.js";
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
import {
    getDefaultValue,
    getEffectiveSchemaType,
    getInputType
} from "./lib/model.js";
import { InputOperationParameterKind } from "./type/InputOperationParameterKind.js";
import { resolveServers } from "./lib/cadlServer.js";
import {
    convenienceApiKey,
    getExternalDocs,
    getOperationId,
    hasDecorator
} from "./lib/decorators.js";
import { InputAuth } from "./type/InputAuth.js";
import { InputApiKeyAuth } from "./type/InputApiKeyAuth.js";
import { InputOAuth2Auth } from "./type/InputOAuth2Auth.js";
import {
    getConsumes,
    getProduces,
    getResourceOperation,
    ResourceOperation
} from "@cadl-lang/rest";
import { InputTypeKind } from "./type/InputTypeKind.js";
import { InputConstant } from "./type/InputConstant.js";
import { HttpResponseHeader } from "./type/HttpResponseHeader.js";
import { OperationPaging } from "./type/OperationPaging.js";

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

    const apiVersions: Set<string> = new Set<string>();
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
        DefaultValue: {
            Type: {
                Name: "String",
                Kind: InputTypeKind.String,
                IsNullable: false
            } as InputPrimitiveType,
            Value: version
        } as InputConstant
    };
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
        let url: string = "";
        if (servers !== undefined) {
            const cadlServers = resolveServers(program, servers);
            if (cadlServers.length > 0) {
                /* choose the first server as endpoint. */
                url = cadlServers[0].url;
                endPointParam = cadlServers[0].parameters[0];
            }
        }

        for (const operation of routes) {
            console.log(JSON.stringify(operation.path));
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
                enumMap
            );

            applyDefaultContentTypeAndAcceptParameter(op);

            const apiVersionInOperation = op.Parameters.find(
                (value) => value.IsApiVersion
            );
            if (apiVersionInOperation) {
                if (apiVersionInOperation.DefaultValue?.Value) {
                    apiVersions.add(apiVersionInOperation.DefaultValue.Value);
                }
            }
            client.Operations.push(op);
        }
        if (apiVersions.size > 1) {
            apiVersionParam.Kind = InputOperationParameterKind.Constant;
        }
        for (const client of clients) {
            for (const op of client.Operations) {
                const apiVersionInOperation = op.Parameters.find(
                    (value) => value.IsApiVersion
                );
                if (apiVersionInOperation) {
                    if (apiVersions.size > 1) {
                        apiVersionInOperation.Kind =
                            InputOperationParameterKind.Constant;
                    }
                    if (!apiVersionInOperation.DefaultValue) {
                        apiVersionInOperation.DefaultValue =
                            apiVersionParam.DefaultValue;
                    }
                } else {
                    op.Parameters.push(apiVersionParam);
                }
            }
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

function applyDefaultContentTypeAndAcceptParameter(operation: InputOperation): void {
    const defaultValue: string = "application/json";
    if (operation.Parameters.some(value => value.Location === RequestLocation.Body)
        && !operation.Parameters.some(value => value.IsContentType === true)) {
        operation.Parameters.push(createContentTypeOrAcceptParameter([defaultValue], "contentType", "Content-Type"));
        operation.RequestMediaTypes = [defaultValue];
    }

    if (!operation.Parameters.some(
        value =>
            value.Location === RequestLocation.Header &&
            value.NameInRequest.toLowerCase() === "accept")) {
        operation.Parameters.push(createContentTypeOrAcceptParameter([defaultValue], "accept", "Accept"))
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
                                scopes.add(scope.value);
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

function getOperationGroupName(program: Program, operation: Operation): string {
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
    enums: Map<string, InputEnumType>
): InputOperation {
    const {
        path: fullPath,
        operation: op,
        verb,
        parameters: cadlParameters
    } = operation;
    console.log(`load operation: ${op.name}, path:${fullPath} `);
    const resourceOperation = getResourceOperation(program, op);
    const desc = getDoc(program, op);
    const summary = getSummary(program, op);
    const externalDocs = getExternalDocs(program, op);

    const parameters: InputParameter[] = [];
    if (endpoint) parameters.push(endpoint);
    for (const p of cadlParameters.parameters) {
        parameters.push(loadOperationParameter(program, p));
    }

    if (cadlParameters.bodyParameter) {
        parameters.push(
            loadBodyParameter(program, cadlParameters.bodyParameter)
        );
    } else if (cadlParameters.bodyType) {
        if (resourceOperation) {
            parameters.push(
                loadBodyParameter(program, resourceOperation.resourceType)
            );
        } else {
            const effectiveBodyType = getEffectiveSchemaType(
                program,
                cadlParameters.bodyType
            );
            if (effectiveBodyType.kind === "Model") {
                parameters.push(loadBodyParameter(program, effectiveBodyType));
            }
        }
    }

    const responses: OperationResponse[] = [];
    for (const res of operation.responses) {
        const operationResponse = loadOperationResponse(
            program,
            res,
            resourceOperation
        );
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
    const convenienceApiDecorator: boolean =
        getExtensions(program, op).get(convenienceApiKey) ?? false;
    const generateConvenienceMethod: boolean =
        requestMethod !== RequestMethod.PATCH && convenienceApiDecorator;

    /* handle lro */
    /* handle paging. */
    let paging: OperationPaging | undefined = undefined;
    for (const res of operation.responses) {
        const body = res.responses[0]?.body;
        if (body?.type) {
            if (
                body.type.kind === "Model" &&
                hasDecorator(body?.type, "$pagedResult")
            ) {
                const itemsProperty = Array.from(
                    body.type.properties.values()
                ).find((it) => hasDecorator(it, "$items"));
                const nextLinkProperty = Array.from(
                    body.type.properties.values()
                ).find((it) => hasDecorator(it, "$nextLink"));
                paging = {
                    NextLinkName: nextLinkProperty?.name,
                    ItemName: itemsProperty?.name
                } as OperationPaging;
            }
        }
    }
    /* TODO: handle lro */

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
        BufferResponse: true,
        Paging: paging,
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
        const isApiVersion: boolean =
            requestLocation === RequestLocation.Query &&
            name.toLocaleLowerCase() === "api-version";
        const isContentType: boolean =
            requestLocation === RequestLocation.Header &&
            name.toLowerCase() === "content-type";
        const kind: InputOperationParameterKind = isContentType
            ? InputOperationParameterKind.Constant
            : isApiVersion
                ? InputOperationParameterKind.Client
                : InputOperationParameterKind.Method;
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
        body: ModelProperty | Model
    ): InputParameter {
        const type = body.kind === "Model" ? body : body.type;
        const inputType: InputType = getInputType(program, type, models, enums);
        const requestLocation = RequestLocation.Body;
        const kind: InputOperationParameterKind =
            InputOperationParameterKind.Method;
        return {
            Name: body.name,
            NameInRequest: body.name,
            Description: getDoc(program, body),
            Type: inputType,
            Location: requestLocation,
            IsRequired: body.kind === "Model" ? true : !body.optional,
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
        response: HttpOperationResponse,
        resourceOperation?: ResourceOperation
    ): OperationResponse | undefined {
        if (!response.statusCode || response.statusCode === "*") {
            return undefined;
        }
        const status: number[] = [];
        status.push(Number(response.statusCode));
        //TODO: what to do if more than 1 response?
        const body = response.responses[0]?.body;

        let type: InputType | undefined = undefined;
        if (body?.type) {
            if (resourceOperation && resourceOperation.operation !== "list") {
                type = getInputType(
                    program,
                    resourceOperation.resourceType,
                    models,
                    enums
                );
            } else {
                const cadlType = getEffectiveSchemaType(program, body.type);
                const inputType: InputType = getInputType(
                    program,
                    cadlType,
                    models,
                    enums
                );
                type = inputType;
            }
        }

        const headers = response.responses[0]?.headers;
        const responseHeaders: HttpResponseHeader[] = [];
        if (headers) {
            for (const key of Object.keys(headers)) {
                responseHeaders.push({
                    Name: key,
                    NameInResponse: headers[key].name,
                    Description: getDoc(program, headers[key]) ?? "",
                    Type: getInputType(
                        program,
                        headers[key].type,
                        models,
                        enums
                    )
                } as HttpResponseHeader);
            }
        }

        return {
            StatusCodes: status,
            BodyType: type,
            BodyMediaType: BodyMediaType.Json,
            Headers: responseHeaders
        } as OperationResponse;
    }
}

class ErrorTypeFoundError extends Error {
    constructor() {
        super("Error type found in evaluated Cadl output");
    }
}
