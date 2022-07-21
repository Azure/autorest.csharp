// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { getDoc, Program, Type } from "@cadl-lang/compiler";
import { http } from "@cadl-lang/rest/*";
import { InputConstant } from "../type/InputConstant";
import { InputOperationParameterKind } from "../type/InputOperationParameterKind.js";
import { InputParameter } from "../type/InputParameter.js";
import { InputType } from "../type/InputType.js";
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

            const endPointParam: InputParameter = {
                Name: "Endpoint",
                NameInRequest: "Endpoint",
                Description: "",
                Type: new InputType("Uri", InputTypeKind.Uri, false),
                Location: RequestLocation.Uri,
                IsApiVersion: false,
                IsResourceParameter: false,
                IsContentType: false,
                IsRequired: true,
                IsEndpoint: true,
                SkipUrlEncoding: false,
                Explode: false,
                Kind: InputOperationParameterKind.Client
            };
            let defaultValue = undefined;
            const value = prop.default ? getDefaultValue(prop.default) : "";
            if (value) {
                defaultValue = {
                    Value: value,
                    Type: new InputType("Uri", InputTypeKind.Uri, false)
                } as InputConstant;
            }
            const variable: InputParameter = {
                Name: name,
                NameInRequest: name,
                Description: getDoc(program, prop),
                Type: new InputType("Uri", InputTypeKind.Uri, false),
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

            // if (prop.type.kind === "Enum") {
            //   variable.enum = getSchemaForEnum(prop.type).enum;
            // } else if (prop.type.kind === "Union") {
            //   variable.enum = getSchemaForUnion(prop.type).enum;
            // } else if (prop.type.kind === "String") {
            //   variable.enum = [prop.type.value];
            // }
            //parameters[name] = variable;
            parameters.push(variable);
        }
        return {
            url: server.url,
            description: server.description,
            parameters
        };
    });
}
