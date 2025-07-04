// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
    AccessFlags,
    DecoratorInfo,
    SdkBuiltInKinds,
    UsageFlags
} from "@azure-tools/typespec-client-generator-core";
import { CodeModel, InputClient } from "@typespec/http-client-csharp";

/*
 * This function transforms the code model for backward compatibility to avoid massive code on autorest.csharp's csharp part.
 * @param codeModel - The code model to transform
 * @returns The transformed code model
 */
export function transformCodeModel(codeModel: CodeModel): CodeModel {
    // Transform the code model if needed
    // iterates all the constants appearing in models, and replace its valueType with a created enum type
    for (const model of codeModel.models) {
        for (const property of model.properties) {
            // we do not do this for discriminator
            if (property.kind === "property" && property.discriminator) {
                continue;
            }
            const propertyType = property.type;
            if (propertyType.kind === "constant") {
                const constantType = property.type as InputLiteralType;
                // we convert the valueType to an enum when it is not a boolean.
                if (constantType.valueType.kind !== "boolean") {
                    const enumType: InputEnumType = {
                        kind: "enum",
                        name: constantType.name,
                        crossLanguageDefinitionId: "",
                        valueType: constantType.valueType as any,
                        values: [],
                        isFixed: false,
                        isFlags: false,
                        usage: model.usage,
                        access: model.access,
                        namespace: model.namespace,
                        decorators: constantType.decorators
                    };
                    const enumValue: InputEnumValueType = {
                        kind: "enumvalue",
                        name:
                            constantType.value === null
                                ? "Null"
                                : constantType.value.toString(),
                        value: constantType.value as string | number,
                        valueType: constantType.valueType as any,
                        enumType: enumType
                    };
                    enumType.values.push(enumValue);
                    codeModel.enums.push(enumType);
                    constantType.valueType = enumType;
                }
            }
        }
    }
    // fix the endpoint parameter in client to always be a url
    for (const client of codeModel.clients) {
        fixEndpointParameter(client);
    }
    return codeModel;

    function fixEndpointParameter(client: InputClient) {
        if (client.parameters) {
            for (const param of client.parameters) {
                if (param.isEndpoint && param.type.kind === "string") {
                    param.type = {
                        kind: "url",
                        name: "url",
                        crossLanguageDefinitionId: "TypeSpec.url"
                    };
                }
            }
        }
        if (client.children) {
            for (const child of client.children) {
                fixEndpointParameter(child);
            }
        }
    }
}

interface DecoratedType {
    decorators?: DecoratorInfo[];
}

interface InputTypeBase extends DecoratedType {
    kind: string;
    summary?: string;
    doc?: string;
    deprecation?: string;
}

export interface InputPrimitiveType extends InputTypeBase {
    kind: SdkBuiltInKinds;
    name: string;
    encode?: string; // In TCGC this is required, and when there is no encoding, it just has the same value as kind
    crossLanguageDefinitionId: string;
    baseType?: InputPrimitiveType;
}

export interface InputLiteralType extends InputTypeBase {
    kind: "constant";
    name: string;
    access?: AccessFlags;
    usage: UsageFlags;
    namespace: string;
    valueType: InputPrimitiveType | InputEnumType; // this is different from the definition in http-client-csharp, we added `InputEnumType` here for backward compatibility.
    value: string | number | boolean | null;
}

export interface InputEnumType extends InputTypeBase {
    kind: "enum";
    name: string;
    crossLanguageDefinitionId: string;
    valueType: InputPrimitiveType;
    values: InputEnumValueType[];
    isFixed: boolean;
    isFlags: boolean;
    usage: UsageFlags;
    access?: AccessFlags;
    namespace: string;
}

export interface InputEnumValueType extends InputTypeBase {
    kind: "enumvalue";
    name: string;
    value: string | number;
    enumType: InputEnumType;
    valueType: InputPrimitiveType;
}
