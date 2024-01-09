// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
    SdkClient,
    listClients,
    listOperationGroups,
    listOperationsInOperationGroup,
    SdkOperationGroup,
    SdkContext
} from "@azure-tools/typespec-client-generator-core";
import {
    EmitContext,
    listServices,
    Service,
    getDoc,
    getNamespaceFullName,
    Operation,
    ignoreDiagnostics,
    NoTarget,
    Namespace,
    Interface,
    getLocationContext
} from "@typespec/compiler";
import {
    getAuthentication,
    getServers,
    HttpOperation,
    getAllHttpServices,
    getHttpOperation
} from "@typespec/http";
import { getVersions } from "@typespec/versioning";
import { NetEmitterOptions, resolveOptions } from "../options.js";
import { CodeModel } from "../type/codeModel.js";
import { InputConstant } from "../type/inputConstant.js";
import { InputOperationParameterKind } from "../type/inputOperationParameterKind.js";
import { InputParameter } from "../type/inputParameter.js";
import {
    InputEnumType,
    InputModelType,
    InputPrimitiveType
} from "../type/inputType.js";
import { InputTypeKind } from "../type/inputTypeKind.js";
import { RequestLocation } from "../type/requestLocation.js";
import { getExternalDocs } from "./decorators.js";
import { processServiceAuthentication } from "./serviceAuthentication.js";
import { resolveServers } from "./typespecServer.js";
import { InputClient } from "../type/inputClient.js";
import { ClientKind } from "../type/clientKind.js";
import { InputOperation } from "../type/inputOperation.js";
import { getUsages, navigateModels } from "./model.js";
import { Usage } from "../type/usage.js";
import { loadOperation } from "./operation.js";
import { logger } from "./logger.js";
import { $lib } from "../emitter.js";
import { createContentTypeOrAcceptParameter } from "./utils.js";

export function createModel(
    sdkContext: SdkContext<NetEmitterOptions>
): CodeModel {
    const services = listServices(sdkContext.emitContext.program);
    if (services.length === 0) {
        services.push({
            type: sdkContext.emitContext.program.getGlobalNamespaceType()
        });
    }

    // TODO: support multiple service. Current only chose the first service.
    const service = services[0];
    const serviceNamespaceType = service.type;
    if (serviceNamespaceType === undefined) {
        throw Error("Can not emit yaml for a namespace that doesn't exist.");
    }

    return createModelForService(sdkContext, service);
}

export function createModelForService(
    sdkContext: SdkContext<NetEmitterOptions>,
    service: Service
): CodeModel {
    const emitterOptions = resolveOptions(sdkContext.emitContext);
    const program = sdkContext.emitContext.program;
    const serviceNamespaceType = service.type;

    const apiVersions: Set<string> | undefined = new Set<string>();
    let defaultApiVersion: string | undefined = undefined;
    const versions = getVersions(program, service.type)[1]?.getVersions();
    if (versions && versions.length > 0) {
        for (const ver of versions) {
            apiVersions.add(ver.value);
        }
        defaultApiVersion = versions[versions.length - 1].value;
    }
    const defaultApiVersionConstant: InputConstant | undefined =
        defaultApiVersion
            ? {
                  Type: {
                      Name: "String",
                      Kind: InputTypeKind.String,
                      IsNullable: false
                  } as InputPrimitiveType,
                  Value: defaultApiVersion
              }
            : undefined;

    const description = getDoc(program, serviceNamespaceType);
    const externalDocs = getExternalDocs(sdkContext, serviceNamespaceType);

    const servers = getServers(program, serviceNamespaceType);
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

    const clients: InputClient[] = [];
    const dpgClients = emitterOptions.branded
        ? listClients(sdkContext)
        : listClientsByNamespace(
              sdkContext.emitContext,
              sdkContext.emitContext.program.getGlobalNamespaceType()
          );
    for (const client of dpgClients) {
        clients.push(emitClient(client));
        addChildClients(sdkContext.emitContext, client, clients);
    }

    for (const client of clients) {
        for (const op of client.Operations) {
            const apiVersionIndex = op.Parameters.findIndex(
                (value: InputParameter) => value.IsApiVersion
            );
            if (apiVersionIndex === -1) {
                continue;
            }
            const apiVersionInOperation = op.Parameters[apiVersionIndex];
            if (defaultApiVersionConstant !== undefined) {
                if (!apiVersionInOperation.DefaultValue?.Value) {
                    apiVersionInOperation.DefaultValue =
                        defaultApiVersionConstant;
                }
            } else {
                apiVersionInOperation.Kind = InputOperationParameterKind.Method;
            }
        }
    }

    navigateModels(sdkContext, serviceNamespaceType, modelMap, enumMap);

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

    function addChildClients(
        context: EmitContext<NetEmitterOptions>,
        client: SdkClient | DotnetSdkOperationGroup,
        clients: InputClient[]
    ) {
        if (emitterOptions.branded) {
            const dpgOperationGroups = listOperationGroups(
                sdkContext,
                client as SdkClient
            );
            for (const dpgGroup of dpgOperationGroups) {
                var dotnetOperationGroup = {
                    ...dpgGroup,
                    name: dpgGroup.type.name
                };
                var subClient = emitClient(dotnetOperationGroup, client);
                clients.push(subClient);
                addChildClients(context, dotnetOperationGroup, clients);
            }
        } else {
            const dpgOperationGroups = listOperationGroupsByClient(
                context,
                client
            );
            for (const dpgGroup of dpgOperationGroups) {
                clients.push(emitClient(dpgGroup, client));
                addChildClients(context, dpgGroup, clients);
            }
        }
    }

    function getClientName(
        client: SdkClient | DotnetSdkOperationGroup
    ): string {
        if (emitterOptions.branded) {
            return client.kind === ClientKind.SdkClient
                ? client.name
                : client.type.name;
        } else {
            return client.kind === ClientKind.SdkClient
                ? `${client.name}Client`
                : client.name === "Models"
                ? "ModelsOps"
                : client.name; //quick fix for reserved namespace need something more robust
        }
    }

    function emitClient(
        client: SdkClient | DotnetSdkOperationGroup,
        parent?: SdkClient | DotnetSdkOperationGroup
    ): InputClient {
        const operations = emitterOptions.branded
            ? listOperationsInOperationGroup(sdkContext, client)
            : listOperations(sdkContext.emitContext, client);
        let clientDesc = "";
        if (operations.length > 0) {
            const container = ignoreDiagnostics(
                getHttpOperation(program, operations[0])
            ).container;
            clientDesc = getDoc(program, container) ?? "";
        }

        const inputClient = {
            Name: getClientName(client),
            Description: clientDesc,
            Operations: [],
            Protocol: {},
            Creatable: client.kind === ClientKind.SdkClient,
            Parent: parent === undefined ? undefined : getClientName(parent)
        } as InputClient;
        for (const op of operations) {
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
}

function setUsage(
    usages: { inputs: string[]; outputs: string[]; roundTrips: string[] },
    models: Map<string, InputModelType | InputEnumType>
) {
    for (const [name, m] of models) {
        if (m.Usage !== undefined && m.Usage !== Usage.None) continue;
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

function processNamespace(
    context: EmitContext<NetEmitterOptions>,
    clients: SdkClient[],
    root: Namespace,
    prefix: string,
    level: number
) {
    if (level > 0) {
        return;
    }

    const name = level > 1 ? prefix + root.name : root.name;

    const contextType = getLocationContext(context.program, root).type;
    if (contextType !== "project" && contextType !== "synthetic") {
        return;
    }

    if (contextType === "project") {
        clients.push({
            kind: "SdkClient",
            name: name,
            service: root,
            type: root,
            arm: false
        } as SdkClient);
    }

    for (const ns of root.namespaces) {
        processNamespace(context, clients, ns[1], name, level + 1);
    }

    for (const i of root.interfaces) {
        processInterface(context, clients, i[1], name, level + 1);
    }
}

function processInterface(
    context: EmitContext<NetEmitterOptions>,
    clients: SdkClient[],
    i: Interface,
    prefix: string,
    level: number
) {
    if (level > 0) {
        return;
    }

    const name = level > 1 ? prefix + i.name : i.name;
    if (i.operations.size > 0) {
        clients.push({
            kind: ClientKind.SdkClient,
            name: name,
            service: i.namespace,
            type: i,
            arm: false
        } as SdkClient);
    }
}

function listClientsByNamespace(
    context: EmitContext<NetEmitterOptions>,
    ns: Namespace
): SdkClient[] {
    var clients: SdkClient[] = [];
    //we start with -1 because there is a synthetic namespace created with no name to contain both the project namespaces and the compiler namespaces like TypeSpec
    processNamespace(context, clients, ns, "", -1);
    return clients;
}

function listOperationGroupsByClient(
    context: EmitContext<NetEmitterOptions>,
    client: SdkClient | DotnetSdkOperationGroup
): DotnetSdkOperationGroup[] {
    var operationGroups: DotnetSdkOperationGroup[] = [];
    //we start with -1 because there is a synthetic namespace created with no name to contain both the project namespaces and the compiler namespaces like TypeSpec
    const prefix = client.kind === ClientKind.SdkClient ? "" : client.name;
    if ("namespaces" in client.type) {
        for (const ns of client.type.namespaces) {
            addChild(context, operationGroups, ns[1], prefix);
        }

        for (const i of client.type.interfaces) {
            addChild(context, operationGroups, i[1], prefix);
        }
    }
    return operationGroups;
}

function addChild(
    context: EmitContext<NetEmitterOptions>,
    operationGroups: DotnetSdkOperationGroup[],
    type: Interface | Namespace,
    prefix: string
) {
    const name = `${prefix}${type.name}`;
    operationGroups.push({
        kind: ClientKind.SdkOperationGroup,
        type: type,
        name: name
    } as DotnetSdkOperationGroup);
}

interface DotnetSdkOperationGroup extends SdkOperationGroup {
    name: string;
}

function listOperations(
    context: EmitContext<NetEmitterOptions>,
    client: SdkClient | DotnetSdkOperationGroup
): Operation[] {
    const operations: Operation[] = [];

    for (const operation of client.type.operations) {
        operations.push(operation[1]);
    }

    return operations;
}
