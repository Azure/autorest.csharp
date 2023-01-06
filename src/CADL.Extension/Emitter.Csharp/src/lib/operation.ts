// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { getDeprecated, getDoc, getServiceNamespace, getSummary, isErrorModel, Model, ModelProperty, Operation, Program } from "@cadl-lang/compiler";
import { getResourceOperation, ResourceOperation } from "@cadl-lang/rest";
import { HttpOperation, getHeaderFieldName, HttpOperationParameter, HttpOperationResponse } from "@cadl-lang/rest/http";
import { OperationFinalStateVia } from "../type/OperationFinalStateVia.js";
import { OperationLongRunning } from "../type/OperationLongRunning.js";
import { OperationResponse } from "../type/OperationResponse";
import { getOperationLink, isFinalLocation } from "@azure-tools/cadl-azure-core";
import { getConvenienceAPIName, isApiVersion } from "@azure-tools/cadl-dpg";
import { BodyMediaType } from "../type/BodyMediaType.js";
import { HttpResponseHeader } from "../type/HttpResponseHeader.js";
import { InputConstant } from "../type/InputConstant.js";
import { InputOperation } from "../type/InputOperation.js";
import { InputOperationParameterKind } from "../type/InputOperationParameterKind.js";
import { InputParameter } from "../type/InputParameter.js";
import { InputModelType, InputEnumType, InputType } from "../type/InputType.js";
import { OperationPaging } from "../type/OperationPaging.js";
import { requestLocationMap, RequestLocation } from "../type/RequestLocation.js";
import { parseHttpRequestMethod, RequestMethod } from "../type/RequestMethod.js";
import { getExternalDocs, getOperationId, hasDecorator } from "./decorators.js";
import { getEffectiveSchemaType, getInputType, getDefaultValue } from "./model.js";

export function loadOperation(
    program: Program,
    operation: HttpOperation,
    uri: string,
    urlParameters: InputParameter[] | undefined = undefined,
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
        getConvenienceAPIName(program, op) !== undefined;
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

    return {
        Name: op.name,
        ResourceName: resourceOperation?.resourceType.name ?? getOperationGroupName(program, op),
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
            FinalStateVia: getOperationFinalStateVia(op),
            FinalResponse: finalResponse
        } as OperationLongRunning;
    }

    function getOperationFinalStateVia(op: HttpOperation) : OperationFinalStateVia
    {
        let finalStateVia = OperationFinalStateVia.Location;
        for (const response of op.responses) {
            for (const content of response.responses) {
                for (const key in content.headers) {
                    const header = content.headers[key];
                    if (isFinalLocation(program, header)) {
                        const headerFieldName = getHeaderFieldName(program, header);
                        switch (headerFieldName) {
                            case "Operation-Location":
                                finalStateVia = OperationFinalStateVia.OperationLocation;
                                break;
                            case "Location":
                            default:
                                finalStateVia = OperationFinalStateVia.Location;
                        };
                    };
                };
            };
        };
        return finalStateVia;
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

    function isLroOperation(program: Program, op: Operation) {
        return getOperationLink(program, op, "polling") !== undefined;
    }
}


