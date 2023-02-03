// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
    createCadlLibrary,
    getDeprecated,
    getDoc,
    getServiceNamespace,
    getServiceNamespaceString,
    getServiceTitle,
    getServiceVersion,
    getSummary,
    ignoreDiagnostics,
    isErrorModel,
    JSONSchemaType,
    Model,
    ModelProperty,
    Operation,
    Program,
    resolvePath
} from "@cadl-lang/compiler";
import {
    getAllHttpServices,
    getAuthentication,
    getHttpOperation,
    getServers,
    HttpOperation,
    HttpOperationParameter,
    HttpOperationResponse,
    ServiceAuthentication
} from "@cadl-lang/rest/http";
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
    getInputType,
    getUsages
} from "./lib/model.js";
import { InputOperationParameterKind } from "./type/InputOperationParameterKind.js";
import { resolveServers } from "./lib/cadlServer.js";
import {
    getExternalDocs,
    getOperationId,
    hasDecorator
} from "./lib/decorators.js";
import { InputAuth } from "./type/InputAuth.js";
import { InputApiKeyAuth } from "./type/InputApiKeyAuth.js";
import { InputOAuth2Auth } from "./type/InputOAuth2Auth.js";
import { getResourceOperation, ResourceOperation } from "@cadl-lang/rest";
import { InputTypeKind } from "./type/InputTypeKind.js";
import { InputConstant } from "./type/InputConstant.js";
import { Usage } from "./type/Usage.js";
import { HttpResponseHeader } from "./type/HttpResponseHeader.js";
import { OperationPaging } from "./type/OperationPaging.js";
import { OperationLongRunning } from "./type/OperationLongRunning.js";
import { OperationFinalStateVia } from "./type/OperationFinalStateVia.js";
import { getOperationLink } from "@azure-tools/cadl-azure-core";
import fs from "fs";
import path from "node:path";
import { Configuration } from "./type/Configuration.js";
import { dllFilePath } from "@autorest/csharp";
import { execSync } from "child_process";
import {
    Client,
    createDpgContext,
    getConvenienceAPIName,
    isApiVersion,
    isOperationGroup,
    listClients,
    listOperationGroups,
    listOperationsInOperationGroup,
    OperationGroup,
    shouldGenerateConvenient,
    shouldGenerateProtocol
} from "@azure-tools/cadl-dpg";
import { ClientKind } from "./type/ClientKind.js";
import { getVersions } from "@cadl-lang/versioning";
import { EmitContext } from "@cadl-lang/compiler/*";
import { capitalize } from "./lib/utils.js";

export interface NetEmitterOptions {
    outputFile?: string;
    logFile?: string;
    namespace?: string;
    "library-name"?: string;
    "single-top-level-client"?: boolean;
    skipSDKGeneration?: boolean;
    generateConvenienceAPI?: boolean; //workaround for cadl-ranch project
    "unreferenced-types-handling"?:
        | "removeOrInternalize"
        | "internalize"
        | "keepAll";
    "new-project"?: boolean;
    csharpGeneratorPath?: string;
    "clear-output-folder"?: boolean;
    "save-inputs"?: boolean;
    "model-namespace"?: boolean;
    "generate-protocol-methods"?: boolean;
    "generate-convenience-methods"?: boolean;
    "package-name"?: string;
}

const defaultOptions = {
    outputFile: "cadl.json",
    logFile: "log.json",
    skipSDKGeneration: false,
    "new-project": false,
    csharpGeneratorPath: dllFilePath,
    "clear-output-folder": false,
    "save-inputs": false
};

const NetEmitterOptionsSchema: JSONSchemaType<NetEmitterOptions> = {
    type: "object",
    additionalProperties: false,
    properties: {
        outputFile: { type: "string", nullable: true },
        logFile: { type: "string", nullable: true },
        namespace: { type: "string", nullable: true },
        "library-name": { type: "string", nullable: true },
        "single-top-level-client": { type: "boolean", nullable: true },
        skipSDKGeneration: { type: "boolean", default: false, nullable: true },
        generateConvenienceAPI: { type: "boolean", nullable: true },
        "unreferenced-types-handling": {
            type: "string",
            enum: ["removeOrInternalize", "internalize", "keepAll"],
            nullable: true
        },
        "new-project": { type: "boolean", nullable: true },
        csharpGeneratorPath: {
            type: "string",
            default: dllFilePath,
            nullable: true
        },
        "clear-output-folder": { type: "boolean", nullable: true },
        "save-inputs": { type: "boolean", nullable: true },
        "model-namespace": { type: "boolean", nullable: true },
        "generate-protocol-methods": { type: "boolean", nullable: true },
        "generate-convenience-methods": { type: "boolean", nullable: true },
        "package-name": { type: "string", nullable: true }
    },
    required: []
};

export const $lib = createCadlLibrary({
    name: "cadl-csharp",
    diagnostics: {},
    emitter: {
        options: NetEmitterOptionsSchema
    }
});

export async function $onEmit(context: EmitContext<NetEmitterOptions>) {
    const program: Program = context.program;
    const emitterOptions = context.options;
    const emitterOutputDir = context.emitterOutputDir;
    const resolvedOptions = { ...defaultOptions, ...emitterOptions };
    const outputFolder = resolvePath(emitterOutputDir ?? "./cadl-output");
    const options: NetEmitterOptions = {
        outputFile: resolvePath(outputFolder, resolvedOptions.outputFile),
        logFile: resolvePath(
            emitterOutputDir ?? "./cadl-output",
            resolvedOptions.logFile
        ),
        skipSDKGeneration: resolvedOptions.skipSDKGeneration,
        generateConvenienceAPI: resolvedOptions.generateConvenienceAPI ?? false,
        "unreferenced-types-handling":
            resolvedOptions["unreferenced-types-handling"],
        "new-project": resolvedOptions["new-project"],
        csharpGeneratorPath: resolvedOptions.csharpGeneratorPath,
        "clear-output-folder": resolvedOptions["clear-output-folder"],
        "save-inputs": resolvedOptions["save-inputs"],
        "model-namespace": resolvedOptions["model-namespace"]
    };

    if (!program.compilerOptions.noEmit && !program.hasError()) {
        // Write out the dotnet model to the output path
        const namespace = getServiceNamespaceString(program) || "";

        const root = createModel(context, options.generateConvenienceAPI);
        // await program.host.writeFile(outPath, prettierOutput(JSON.stringify(root, null, 2)));
        if (root) {
            const generatedFolder = resolvePath(outputFolder, "Generated");

            //resolve shared folders based on generator path override
            const resolvedSharedFolders: string[] = [];
            const sharedFolders = [
                resolvePath(
                    options.csharpGeneratorPath ?? dllFilePath,
                    "..",
                    "Generator.Shared"
                ),
                resolvePath(
                    options.csharpGeneratorPath ?? dllFilePath,
                    "..",
                    "Azure.Core.Shared"
                )
            ];
            for (const sharedFolder of sharedFolders) {
                resolvedSharedFolders.push(
                    path
                        .relative(generatedFolder, sharedFolder)
                        .replaceAll("\\", "/")
                );
            }

            if (!fs.existsSync(generatedFolder)) {
                fs.mkdirSync(generatedFolder, { recursive: true });
            }

            await program.host.writeFile(
                resolvePath(generatedFolder, "cadl.json"),
                prettierOutput(
                    stringifyRefs(root, null, 1, PreserveType.Objects)
                )
            );

            //emit configuration.json
            const configurations = {
                OutputFolder: ".",
                Namespace: resolvedOptions.namespace ?? namespace,
                LibraryName: resolvedOptions["library-name"] ?? null,
                SharedSourceFolders: resolvedSharedFolders ?? [],
                SingleTopLevelClient:
                    resolvedOptions["single-top-level-client"],
                "unreferenced-types-handling":
                    options["unreferenced-types-handling"],
                "model-namespace": resolvedOptions["model-namespace"]
            } as Configuration;

            await program.host.writeFile(
                resolvePath(generatedFolder, "Configuration.json"),
                prettierOutput(JSON.stringify(configurations, null, 2))
            );

            if (options.skipSDKGeneration !== true) {
                const newProjectOption = options["new-project"]
                    ? "--new-project"
                    : "";
                const command = `dotnet --roll-forward Major ${resolvePath(
                    options.csharpGeneratorPath ?? dllFilePath
                )} --project-path ${outputFolder} ${newProjectOption} --clear-output-folder ${
                    options["clear-output-folder"]
                }`;
                console.info(command);

                try {
                    execSync(command, { stdio: "inherit" });
                } catch (error: any) {
                    if (error.message) console.log(error.message);
                    if (error.stderr) console.error(error.stderr);
                    if (error.stdout) console.log(error.stdout);

                    throw error;
                }
            }

            if (!options["save-inputs"]) {
                // delete
                deleteFile(resolvePath(generatedFolder, "cadl.json"));
                deleteFile(resolvePath(generatedFolder, "Configuration.json"));
            }
        }
    }
}

function deleteFile(filePath: string) {
    fs.unlink(filePath, (err) => {
        if (err) {
            console.log(`stderr: ${err}`);
        }

        console.log(`File ${filePath} is deleted.`);
    });
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

function createModel(
    context: EmitContext<NetEmitterOptions>,
    generateConvenienceAPI: boolean = false
): any {
    const program = context.program;
    const serviceNamespaceType = getServiceNamespace(program);
    if (!serviceNamespaceType) {
        return;
    }
    const title = getServiceTitle(program);
    const apiVersions: Set<string> = new Set<string>();
    let version = getServiceVersion(program);
    if (version !== "0000-00-00") {
        apiVersions.add(version);
    }

    const versions = getVersions(
        program,
        serviceNamespaceType
    )[1]?.getVersions();
    if (versions) {
        for (const ver of versions) {
            apiVersions.add(ver.value);
        }
        version = versions[versions.length - 1].value; //default version
    }

    if (apiVersions.size === 0) {
        throw "No Api-Version Provided";
    }
    const description = getDoc(program, serviceNamespaceType);
    const externalDocs = getExternalDocs(program, serviceNamespaceType);

    const servers = getServers(program, serviceNamespaceType);
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
    const namespace = getServiceNamespaceString(program) || "client";
    const authentication = getAuthentication(program, serviceNamespaceType);
    let auth = undefined;
    if (authentication) {
        auth = processServiceAuthentication(authentication);
    }

    const modelMap = new Map<string, InputModelType>();
    const enumMap = new Map<string, InputEnumType>();
    let urlParameters: InputParameter[] | undefined = undefined;
    let url: string = "";
    const convenienceOperations: HttpOperation[] = [];
    let lroMonitorOperations: Set<Operation>;
    try {
        //create endpoint parameter from servers
        if (servers !== undefined) {
            const cadlServers = resolveServers(
                program,
                servers,
                modelMap,
                enumMap
            );
            if (cadlServers.length > 0) {
                /* choose the first server as endpoint. */
                url = cadlServers[0].url;
                urlParameters = cadlServers[0].parameters;
            }
        }
        const [services] = getAllHttpServices(program);
        const routes = services[0].operations;
        if (routes.length === 0) {
            throw `No Route for service ${services[0].namespace.name}`;
        }
        console.log("routes:" + routes.length);

        lroMonitorOperations = getAllLroMonitorOperations(routes, program);
        const clients: InputClient[] = [];
        const dpgClients = listClients(program);
        for (const client of dpgClients) {
            clients.push(emitClient(client));
            const dpgOperationGroups = listOperationGroups(program, client);
            for (const dpgGroup of dpgOperationGroups) {
                clients.push(emitClient(dpgGroup, client));
            }
        }

        for (const client of clients) {
            for (const op of client.Operations) {
                const apiVersionIndex = op.Parameters.findIndex(
                    (value) => value.IsApiVersion
                );
                if (apiVersionIndex !== -1) {
                    const apiVersionInOperation =
                        op.Parameters[apiVersionIndex];
                    if (!apiVersionInOperation.DefaultValue?.Value) {
                        apiVersionInOperation.DefaultValue =
                            apiVersionParam.DefaultValue;
                    }
                    /**
                     * replace to the global apiVerison parameter if the apiVersion defined in the operation is the same as the global service apiVersion parameter.
                     * Three checkpoints:
                     * the parameter is query parameter,
                     * it is client parameter
                     * it does not has default value, or the default value is included in the global service apiVersion.
                     */
                    if (
                        apiVersions.has(
                            apiVersionInOperation.DefaultValue?.Value
                        ) &&
                        apiVersionInOperation.Kind ===
                            InputOperationParameterKind.Client &&
                        apiVersionInOperation.Location ===
                            apiVersionParam.Location
                    ) {
                        op.Parameters[apiVersionIndex] = apiVersionParam;
                    }
                } else {
                    op.Parameters.push(apiVersionParam);
                }
            }
        }

        const usages = getUsages(program, convenienceOperations);
        setUsage(usages, modelMap);
        setUsage(usages, enumMap);

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

    function emitClient(
        client: Client | OperationGroup,
        parent?: Client
    ): InputClient {
        const operations = listOperationsInOperationGroup(program, client);
        let clientDesc = "";
        if (operations.length > 0) {
            const container = ignoreDiagnostics(
                getHttpOperation(program, operations[0])
            ).container;
            clientDesc = getDoc(program, container) ?? "";
        }

        const inputClient = {
            Name:
                client.kind === ClientKind.DpgClient
                    ? client.name
                    : client.type.name,
            Description: clientDesc,
            Operations: [],
            Protocol: {},
            Creatable: client.kind === ClientKind.DpgClient,
            Parent: parent?.name
        } as InputClient;
        for (const op of operations) {
            if (lroMonitorOperations.has(op)) continue;
            const httpOperation = ignoreDiagnostics(
                getHttpOperation(program, op)
            );
            const inputOperation: InputOperation = loadOperation(
                context,
                httpOperation,
                url,
                urlParameters,
                modelMap,
                enumMap
            );

            applyDefaultContentTypeAndAcceptParameter(inputOperation);
            inputClient.Operations.push(inputOperation);
            if (
                inputOperation.GenerateConvenienceMethod ||
                generateConvenienceAPI
            )
                convenienceOperations.push(httpOperation);
        }
        return inputClient;
    }

    function getAllLroMonitorOperations(
        routes: HttpOperation[],
        program: Program
    ): Set<Operation> {
        const lroMonitorOperations = new Set<Operation>();
        for (const operation of routes) {
            const operationLink = getOperationLink(
                program,
                operation.operation,
                "polling"
            );
            if (operationLink !== undefined) {
                lroMonitorOperations.add(operationLink.linkedOperation);
            }
        }
        return lroMonitorOperations;
    }
}

function setUsage(
    usages: { inputs: string[]; outputs: string[]; roundTrips: string[] },
    models: Map<string, InputModelType | InputEnumType>
) {
    for (const [name, m] of models) {
        if (usages.inputs.includes(name)) {
            m.Usage = Usage.Input;
        } else if (usages.outputs.includes(name)) {
            m.Usage = Usage.Output;
        } else if (usages.roundTrips.includes(name)) {
            m.Usage = Usage.RoundTrip;
        } else {
            m.Usage = Usage.None;
        }
    }
}

function applyDefaultContentTypeAndAcceptParameter(
    operation: InputOperation
): void {
    const defaultValue: string = "application/json";
    if (
        operation.Parameters.some(
            (value) => value.Location === RequestLocation.Body
        ) &&
        !operation.Parameters.some((value) => value.IsContentType === true)
    ) {
        operation.Parameters.push(
            createContentTypeOrAcceptParameter(
                [defaultValue],
                "contentType",
                "Content-Type"
            )
        );
        operation.RequestMediaTypes = [defaultValue];
    }

    if (
        !operation.Parameters.some(
            (value) =>
                value.Location === RequestLocation.Header &&
                value.NameInRequest.toLowerCase() === "accept"
        )
    ) {
        operation.Parameters.push(
            createContentTypeOrAcceptParameter(
                [defaultValue],
                "accept",
                "Accept"
            )
        );
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
    context: EmitContext<NetEmitterOptions>,
    operation: HttpOperation,
    uri: string,
    urlParameters: InputParameter[] | undefined = undefined,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
): InputOperation {
    const program = context.program;
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
    if (urlParameters) {
        for (const param of urlParameters) {
            parameters.push(param);
        }
    }
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
                if (effectiveBodyType.name !== "") {
                    parameters.push(
                        loadBodyParameter(program, effectiveBodyType)
                    );
                } else {
                    effectiveBodyType.name = `${capitalize(op.name)}Request`;
                    let bodyParameter = loadBodyParameter(
                        program,
                        effectiveBodyType
                    );
                    bodyParameter.Kind = InputOperationParameterKind.Spread;
                    parameters.push(bodyParameter);
                }
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
    const generateProtocol: boolean = shouldGenerateProtocol(
        createDpgContext(context),
        op
    );
    const generateConvenience: boolean =
        requestMethod !== RequestMethod.PATCH &&
        (shouldGenerateConvenient(createDpgContext(context), op) ||
            getConvenienceAPIName(program, op) !== undefined);

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
        ResourceName:
            resourceOperation?.resourceType.name ??
            getOperationGroupName(program, op),
        Summary: summary,
        Deprecated: getDeprecated(program, op),
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
        LongRunning: loadOperationLongRunning(
            program,
            operation,
            resourceOperation
        ),
        Paging: paging,
        GenerateProtocolMethod: generateProtocol,
        GenerateConvenienceMethod: generateConvenience
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
        const isApiVer: boolean = isApiVersion(program, parameter);
        const isContentType: boolean =
            requestLocation === RequestLocation.Header &&
            name.toLowerCase() === "content-type";
        const kind: InputOperationParameterKind = isContentType
            ? InputOperationParameterKind.Constant
            : isApiVer
            ? defaultValue
                ? InputOperationParameterKind.Constant
                : InputOperationParameterKind.Client
            : InputOperationParameterKind.Method;
        return {
            Name: param.name,
            NameInRequest: name,
            Description: getDoc(program, param),
            Type: inputType,
            Location: requestLocation,
            DefaultValue: defaultValue,
            IsRequired: !param.optional,
            IsApiVersion: isApiVer,
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
            Headers: responseHeaders,
            IsErrorResponse: isErrorModel(program, response.type)
        } as OperationResponse;
    }

    function loadOperationLongRunning(
        program: Program,
        op: HttpOperation,
        resourceOperation?: ResourceOperation
    ): OperationLongRunning | undefined {
        if (!isLroOperation(program, op.operation)) return undefined;

        const finalResponse = loadLongRunningFinalResponse(
            program,
            op,
            resourceOperation
        );
        if (finalResponse === undefined) return undefined;

        return {
            FinalStateVia: OperationFinalStateVia.Location, // data plane only supports `location`
            FinalResponse: finalResponse
        } as OperationLongRunning;
    }

    function loadLongRunningFinalResponse(
        program: Program,
        op: HttpOperation,
        resourceOperation?: ResourceOperation
    ): OperationResponse | undefined {
        let finalResponse: any | undefined;
        for (const response of op.responses) {
            if (response.statusCode === "200") {
                finalResponse = response;
                break;
            }
            if (response.statusCode === "204") {
                finalResponse = response;
            }
        }

        if (finalResponse !== undefined) {
            return loadOperationResponse(
                program,
                finalResponse,
                resourceOperation
            );
        }

        return loadOperationResponse(
            program,
            op.responses[0],
            resourceOperation
        );
    }

    function isLroOperation(program: Program, op: Operation) {
        return getOperationLink(program, op, "polling") !== undefined;
    }
}

class ErrorTypeFoundError extends Error {
    constructor() {
        super("Error type found in evaluated Cadl output");
    }
}
