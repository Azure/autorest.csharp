// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { getDoc, Program, Type } from "@cadl-lang/compiler";
import { http } from "@cadl-lang/rest/*";
import { InputConstant } from "../type/InputConstant";
import { InputOperationParameterKind } from "../type/InputOperationParameterKind.js";
import { InputParameter } from "../type/InputParameter.js";
import { InputPrimitiveType, InputType } from "../type/InputType.js";
import { InputTypeKind } from "../type/InputTypeKind.js";
import { RequestLocation } from "../type/RequestLocation.js";

export interface CadlServer {
    url: string;
    description?: string;
    parameters: InputParameter[];
}

function getDefaultValue(type: Type): any {
    switch (type.kind) {
        case "String":
            return type.value;
        case "Number":
            return type.value;
        case "Boolean":
            return type.value;
        case "Tuple":
            return type.values.map(getDefaultValue);
        default:
            return undefined;
    }
}

export function resolveServers(
    program: Program,
    servers: http.HttpServer[]
): CadlServer[] {
    return servers.map((server) => {
        const parameters: InputParameter[] = [];
        for (const [name, prop] of server.parameters) {
            // if (!validateValidServerVariable(program, prop)) {
            //   continue;
            // }

            let defaultValue = undefined;
            const value = prop.default ? getDefaultValue(prop.default) : "";
            if (value) {
                defaultValue = {
                    Value: value,
                    Type: {
                        Name: "Uri",
                        Kind: InputTypeKind.Uri,
                        IsNullable: false
                    } as InputPrimitiveType
                } as InputConstant;
            }
            const variable: InputParameter = {
                Name: name,
                NameInRequest: name,
                Description: getDoc(program, prop),
                Type: {
                    Name: "Uri",
                    Kind: InputTypeKind.Uri,
                    IsNullable: false
                } as InputPrimitiveType,
                Location: RequestLocation.Uri,
                IsApiVersion: false,
                IsResourceParameter: false,
                IsContentType: false,
                IsRequired: true,
                IsEndpoint: true,
                SkipUrlEncoding: false,
                Explode: false,
                Kind: InputOperationParameterKind.Client,
                DefaultValue: defaultValue
            };

            parameters.push(variable);
        }
        /* add default server. */
        if (server.url && server.url.startsWith('http') && parameters.length == 0) {
            const variable: InputParameter = {
                Name: "localhost",
                NameInRequest: "localhost",
                Description: server.description,
                Type: {
                    Name: "Uri",
                    Kind: InputTypeKind.Uri,
                    IsNullable: false
                } as InputPrimitiveType,
                Location: RequestLocation.Uri,
                IsApiVersion: false,
                IsResourceParameter: false,
                IsContentType: false,
                IsRequired: true,
                IsEndpoint: true,
                SkipUrlEncoding: false,
                Explode: false,
                Kind: InputOperationParameterKind.Client,
                DefaultValue: {
                    Value: server.url,
                    Type: {
                        Name: "Uri",
                        Kind: InputTypeKind.Uri,
                        IsNullable: false
                    } as InputPrimitiveType
                } as InputConstant
            };

            parameters.push(variable);
        }
        return {
            url: server.url,
            description: server.description,
            parameters
        };
    });
}
