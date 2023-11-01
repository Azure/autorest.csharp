// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { getLroMetadata } from "@azure-tools/typespec-azure-core";
import {
    createSdkContext,
    isApiVersion,
    shouldGenerateConvenient,
    shouldGenerateProtocol,
    SdkContext,
    getAccess,
    isInternal
} from "@azure-tools/typespec-client-generator-core";
import {
    EmitContext,
    getDeprecated,
    getDoc,
    getSummary,
    isErrorModel,
    Model,
    ModelProperty,
    Namespace,
    Operation
} from "@typespec/compiler";
import { getResourceOperation, ResourceOperation } from "@typespec/rest";
import {
    HttpOperation,
    HttpOperationParameter,
    HttpOperationResponse
} from "@typespec/http";
import { NetEmitterOptions } from "../options.js";
import { BodyMediaType, typeToBodyMediaType } from "../type/bodyMediaType.js";
import { collectionFormatToDelimMap } from "../type/collectionFormat.js";
import { HttpResponseHeader } from "../type/httpResponseHeader.js";
import { InputConstant } from "../type/inputConstant.js";
import { InputOperation } from "../type/inputOperation.js";
import { InputOperationParameterKind } from "../type/inputOperationParameterKind.js";
import { InputParameter } from "../type/inputParameter.js";
import {
    InputEnumType,
    InputListType,
    InputModelType,
    InputType,
    isInputLiteralType,
    isInputUnionType
} from "../type/inputType.js";
import { convertLroFinalStateVia } from "../type/operationFinalStateVia.js";
import { OperationLongRunning } from "../type/operationLongRunning.js";
import { OperationPaging } from "../type/operationPaging.js";
import { OperationResponse } from "../type/operationResponse.js";
import {
    RequestLocation,
    requestLocationMap
} from "../type/requestLocation.js";
import {
    parseHttpRequestMethod,
    RequestMethod
} from "../type/requestMethod.js";
import { getExternalDocs, getOperationId, hasDecorator } from "./decorators.js";
import { logger } from "./logger.js";
import {
    getDefaultValue,
    getEffectiveSchemaType,
    getFormattedType,
    getInputType
} from "./model.js";
import { capitalize, getProjectedNameForCsharp, getTypeName } from "./utils.js";

export function loadOperation(
    context: EmitContext<NetEmitterOptions>,
    operation: HttpOperation,
    uri: string,
    urlParameters: InputParameter[] | undefined = undefined,
    serviceNamespaceType: Namespace,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
): InputOperation {
    const program = context.program;
    const sdkContext = createSdkContext(context);
    const {
        path: fullPath,
        operation: op,
        verb,
        parameters: typespecParameters
    } = operation;
    logger.info(`load operation: ${op.name}, path:${fullPath} `);
    const resourceOperation = getResourceOperation(program, op);
    const desc = getDoc(program, op);
    const summary = getSummary(program, op);
    const externalDocs = getExternalDocs(sdkContext, op);

    const parameters: InputParameter[] = [];
    if (urlParameters) {
        for (const param of urlParameters) {
            parameters.push(param);
        }
    }
    for (const p of typespecParameters.parameters) {
        parameters.push(loadOperationParameter(sdkContext, p));
    }

    if (typespecParameters.body?.parameter) {
        parameters.push(
            loadBodyParameter(sdkContext, typespecParameters.body?.parameter)
        );
    } else if (typespecParameters.body?.type) {
        if (resourceOperation) {
            parameters.push(
                loadBodyParameter(sdkContext, resourceOperation.resourceType)
            );
        } else {
            const effectiveBodyType = getEffectiveSchemaType(
                sdkContext,
                typespecParameters.body.type
            );
            if (effectiveBodyType.kind === "Model") {
                if (effectiveBodyType.name !== "") {
                    parameters.push(
                        loadBodyParameter(sdkContext, effectiveBodyType)
                    );
                } else {
                    effectiveBodyType.name = `${capitalize(op.name)}Request`;
                    let bodyParameter = loadBodyParameter(
                        sdkContext,
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
            sdkContext,
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
        if (isInputLiteralType(contentTypeParameter.Type)) {
            mediaTypes.push(contentTypeParameter.DefaultValue?.Value);
        } else if (isInputUnionType(contentTypeParameter.Type)) {
            const mediaTypeValues =
                contentTypeParameter.Type.UnionItemTypes.map((item) =>
                    isInputLiteralType(item) ? item.Value : undefined
                );
            if (mediaTypeValues.some((item) => item === undefined)) {
                throw "Media type of content type should be string.";
            }
            mediaTypes.push(...mediaTypeValues);
        }
    }
    const requestMethod = parseHttpRequestMethod(verb);
    const generateProtocol: boolean = shouldGenerateProtocol(sdkContext, op);
    const generateConvenience: boolean =
        requestMethod !== RequestMethod.PATCH &&
        shouldGenerateConvenient(sdkContext, op);

    /* handle lro */
    /* handle paging. */
    let paging: OperationPaging | undefined = undefined;
    for (const res of operation.responses) {
        const body = res.responses[0]?.body;
        if (body?.type) {
            const bodyType = getEffectiveSchemaType(sdkContext, body.type);
            if (
                bodyType.kind === "Model" &&
                hasDecorator(bodyType, "$pagedResult")
            ) {
                const itemsProperty = Array.from(
                    bodyType.properties.values()
                ).find((it) => hasDecorator(it, "$items"));
                const nextLinkProperty = Array.from(
                    bodyType.properties.values()
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
        Name: getTypeName(sdkContext, op),
        ResourceName:
            resourceOperation?.resourceType.name ??
            getOperationGroupName(sdkContext, op, serviceNamespaceType),
        Summary: summary,
        Deprecated: getDeprecated(program, op),
        Description: desc,
        Accessibility: isInternal(sdkContext, op)
            ? "internal"
            : getAccess(sdkContext, op),
        Parameters: parameters,
        Responses: responses,
        HttpMethod: requestMethod,
        RequestBodyMediaType: typeToBodyMediaType(
            typespecParameters.body?.type
        ),
        Uri: uri,
        Path: fullPath,
        ExternalDocsUrl: externalDocs?.url,
        RequestMediaTypes: mediaTypes.length > 0 ? mediaTypes : undefined,
        BufferResponse: true,
        LongRunning: loadLongRunningOperation(
            sdkContext,
            operation,
            resourceOperation
        ),
        Paging: paging,
        GenerateProtocolMethod: generateProtocol,
        GenerateConvenienceMethod: generateConvenience
    } as InputOperation;

    function loadOperationParameter(
        context: SdkContext,
        parameter: HttpOperationParameter
    ): InputParameter {
        const { type: location, name, param } = parameter;
        const format = parameter.type === "path" ? undefined : parameter.format;
        const typespecType = param.type;
        const inputType: InputType = getInputType(
            context,
            getFormattedType(program, param),
            models,
            enums
        );
        let defaultValue = undefined;
        const value = getDefaultValue(typespecType);
        if (value) {
            defaultValue = {
                Type: inputType,
                Value: value
            } as InputConstant;
        }
        const requestLocation = requestLocationMap[location];
        const isApiVer: boolean = isApiVersion(sdkContext, parameter);
        const isContentType: boolean =
            requestLocation === RequestLocation.Header &&
            name.toLowerCase() === "content-type";
        const kind: InputOperationParameterKind =
            isContentType || inputType.Name === "Literal"
                ? InputOperationParameterKind.Constant
                : isApiVer
                ? defaultValue
                    ? InputOperationParameterKind.Constant
                    : InputOperationParameterKind.Client
                : InputOperationParameterKind.Method;
        return {
            Name: getTypeName(sdkContext, param),
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
            Explode:
                (inputType as InputListType).ElementType && format === "multi"
                    ? true
                    : false,
            Kind: kind,
            ArraySerializationDelimiter: format
                ? collectionFormatToDelimMap[format]
                : undefined
        } as InputParameter;
    }

    function loadBodyParameter(
        context: SdkContext,
        body: ModelProperty | Model
    ): InputParameter {
        const type = body.kind === "Model" ? body : body.type;
        const inputType: InputType = getInputType(
            context,
            getFormattedType(program, body),
            models,
            enums
        );
        const requestLocation = RequestLocation.Body;
        const kind: InputOperationParameterKind =
            InputOperationParameterKind.Method;
        return {
            Name: getTypeName(sdkContext, body),
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
        context: SdkContext,
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
                    context,
                    getFormattedType(program, resourceOperation.resourceType),
                    models,
                    enums
                );
            } else {
                const typespecType = getEffectiveSchemaType(context, body.type);
                const inputType: InputType = getInputType(
                    context,
                    getFormattedType(program, typespecType),
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
                        context,
                        getFormattedType(program, headers[key].type),
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

    function loadLongRunningOperation(
        context: SdkContext,
        op: HttpOperation,
        resourceOperation?: ResourceOperation
    ): OperationLongRunning | undefined {
        const metadata = getLroMetadata(program, op.operation);
        if (metadata === undefined) {
            return undefined;
        }

        var bodyType = undefined;
        if (op.verb !== "delete") {
            const formattedType = getFormattedType(
                program,
                // TODO: we should check `logicalPath` or other ways to determine body type,
                // after https://github.com/Azure/typespec-azure/issues/3725 is fixed
                op.verb === "post"
                    ? metadata.envelopeResult
                    : metadata.logicalResult
            );
            bodyType = getInputType(context, formattedType, models, enums);
        }

        return {
            FinalStateVia: convertLroFinalStateVia(metadata.finalStateVia),
            FinalResponse: {
                // in swagger, we allow delete to return some meaningful body content
                // for now, let assume we don't allow return type
                StatusCodes: op.verb === "delete" ? [204] : [200],
                BodyType: bodyType,
                BodyMediaType: BodyMediaType.Json
            } as OperationResponse,
            ResultPath:
                metadata.logicalPath ??
                // TODO: roll back changes when `logicalPath` can be definitive
                // https://github.com/Azure/typespec-azure/issues/3725
                (metadata.envelopeResult != metadata.logicalResult &&
                op.verb === "post"
                    ? "result" // actually `result` is the only allowed path for now
                    : undefined)
        } as OperationLongRunning;
    }
}

function getOperationGroupName(
    context: SdkContext,
    operation: Operation,
    serviceNamespaceType: Namespace
): string {
    const explicitOperationId = getOperationId(context, operation);
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
            context.program.checker.getGlobalNamespaceType() ??
            serviceNamespaceType;
    }

    if (namespace) return namespace.name;
    else return "";
}
