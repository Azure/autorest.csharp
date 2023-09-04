// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
    SdkClient,
    createSdkContext,
    listClients,
    listOperationGroups,
    listOperationsInOperationGroup,
    SdkOperationGroup,
    SdkContext,
    getAllModels
} from "@azure-tools/typespec-client-generator-core";
import {
    EmitContext,
    listServices,
    Service,
    getDoc,
    getNamespaceFullName,
    Operation,
    ignoreDiagnostics,
    NoTarget
} from "@typespec/compiler";
import {
    getAuthentication,
    getServers,
    HttpOperation,
    getAllHttpServices,
    getHttpOperation
} from "@typespec/http";
import { getVersions } from "@typespec/versioning";
import { NetEmitterOptions } from "../options.js";
import { CodeModel } from "../type/codeModel.js";
import { InputConstant } from "../type/inputConstant.js";
import { InputOperationParameterKind } from "../type/inputOperationParameterKind.js";
import { InputParameter } from "../type/inputParameter.js";
import {
    InputEnumType,
    InputModelType,
    InputPrimitiveType,
    InputType
} from "../type/inputType.js";
import { InputTypeKind } from "../type/inputTypeKind.js";
import { RequestLocation } from "../type/requestLocation.js";
import { getExternalDocs } from "./decorators.js";
import { processServiceAuthentication } from "./serviceAuthentication.js";
import { resolveServers } from "./typespecServer.js";
import { InputClient } from "../type/inputClient.js";
import { ClientKind } from "../type/clientKind.js";
import { InputOperation } from "../type/inputOperation.js";
import { getOperationLink } from "@azure-tools/typespec-azure-core";
import { getUsages } from "./model.js";
import { Usage } from "../type/usage.js";
import { loadOperation } from "./operation.js";
import { mockApiVersion } from "../constants.js";
import { logger } from "./logger.js";
import { $lib } from "../emitter.js";

export function createModel(
    context: EmitContext<NetEmitterOptions>
): CodeModel {
    const services = listServices(context.program);
    if (services.length === 0) {
        services.push({ type: context.program.getGlobalNamespaceType() });
    }

    // TODO: support multiple service. Current only chose the first service.
    const service = services[0];
    const serviceNamespaceType = service.type;
    if (serviceNamespaceType === undefined) {
        throw Error("Can not emit yaml for a namespace that doesn't exist.");
    }

    return createModelForService(context, service);
}

export function createModelForService(
    context: EmitContext<NetEmitterOptions>,
    service: Service
): CodeModel {
    const program = context.program;
    const sdkContext = createSdkContext(context);
    const title = service.title;
    const serviceNamespaceType = service.type;
    const apiVersions: Set<string> = new Set<string>();
    let version = service.version;
    if (version && version !== mockApiVersion) {
        apiVersions.add(version);
    }
    const versions = getVersions(program, service.type)[1]?.getVersions();
    if (versions) {
        for (const ver of versions) {
            apiVersions.add(ver.value);
        }
        version = versions[versions.length - 1].value; //default version
    }

    if (apiVersions.size === 0) {
        $lib.reportDiagnostic(program, {
            code: "No-APIVersion",
            format: { service: service.type.name },
            target: NoTarget
        });
    }
    const description = getDoc(program, serviceNamespaceType);
    const externalDocs = getExternalDocs(sdkContext, serviceNamespaceType);

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
    const namespace = getNamespaceFullName(serviceNamespaceType) || "client";
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

    //create endpoint parameter from servers
    if (servers !== undefined) {
        const typespecServers = resolveServers(
            sdkContext,
            servers,
            modelMap,
            enumMap
        );
        if (typespecServers.length > 0) {
            /* choose the first server as endpoint. */
            url = typespecServers[0].url;
            urlParameters = typespecServers[0].parameters;
        }
    }
    const [services] = getAllHttpServices(program);
    const routes = services[0].operations;
    if (routes.length === 0) {
        $lib.reportDiagnostic(program, {
            code: "No-Route",
            format: { service: services[0].namespace.name },
            target: NoTarget
        });
    }
    logger.info("routes:" + routes.length);

    lroMonitorOperations = getAllLroMonitorOperations(routes, sdkContext);
    const clients: InputClient[] = [];
    const dpgClients = listClients(sdkContext);

    if (!sdkContext.operationModelsMap) {
        getAllModels(sdkContext);
    }
    for (const client of dpgClients) {
        clients.push(emitClient(client));
        const dpgOperationGroups = listOperationGroups(sdkContext, client);
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
                const apiVersionInOperation = op.Parameters[apiVersionIndex];
                if (!apiVersionInOperation.DefaultValue?.Value) {
                    apiVersionInOperation.DefaultValue =
                        apiVersionParam.DefaultValue;
                }
                /**
                 * replace to the global apiVersion parameter if the apiVersion defined in the operation is the same as the global service apiVersion parameter.
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
                    apiVersionInOperation.Location === apiVersionParam.Location
                ) {
                    op.Parameters[apiVersionIndex] = apiVersionParam;
                }
            } else {
                op.Parameters.push(apiVersionParam);
            }
        }
    }

    const usages = getUsages(sdkContext, convenienceOperations, modelMap);
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

    function emitClient(
        client: SdkClient | SdkOperationGroup,
        parent?: SdkClient
    ): InputClient {
        const operations = listOperationsInOperationGroup(sdkContext, client);
        let clientDesc = "";
        if (operations.length > 0) {
            const container = ignoreDiagnostics(
                getHttpOperation(program, operations[0])
            ).container;
            clientDesc = getDoc(program, container) ?? "";
        }

        const inputClient = {
            Name:
                client.kind === ClientKind.SdkClient
                    ? client.name
                    : client.type.name,
            Description: clientDesc,
            Operations: [],
            Protocol: {},
            Creatable: client.kind === ClientKind.SdkClient,
            Parent: parent?.name
        } as InputClient;
        for (const op of operations) {
            if (lroMonitorOperations.has(op)) continue;
            const httpOperation = ignoreDiagnostics(
                getHttpOperation(program, op)
            );
            const inputOperation: InputOperation = loadOperation(
                sdkContext,
                httpOperation,
                url,
                urlParameters,
                serviceNamespaceType,
                modelMap,
                enumMap
            );

            applyDefaultContentTypeAndAcceptParameter(inputOperation);
            inputClient.Operations.push(inputOperation);
            if (inputOperation.GenerateConvenienceMethod)
                convenienceOperations.push(httpOperation);
        }
        return inputClient;
    }

    function getAllLroMonitorOperations(
        routes: HttpOperation[],
        context: SdkContext
    ): Set<Operation> {
        const lroMonitorOperations = new Set<Operation>();
        for (const operation of routes) {
            const operationLink = getOperationLink(
                context.program,
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
