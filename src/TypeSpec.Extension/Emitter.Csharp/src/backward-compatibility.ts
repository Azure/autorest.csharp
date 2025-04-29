// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { AccessFlags, DecoratorInfo, SdkBuiltInKinds, UsageFlags } from "@azure-tools/typespec-client-generator-core";
import { CodeModel } from "@typespec/http-client-csharp";

/*
* This function transforms the code model for backward compatibility to avoid massive code on autorest.csharp's csharp part.
 * @param codeModel - The code model to transform
 * @returns The transformed code model
 */
export function transformCodeModel(
    codeModel: CodeModel
): CodeModel {
    // Transform the code model if needed
    // iterates all the constants, and replace its valueType with a created enum type
    // TODO -- we only change the constants in models to an enum type
    const convertedEnums: InputEnumType[] = [];
    for (const constant of codeModel.constants) {
        // we convert the valueType to an enum when it is not a boolean.
        if (constant.valueType.kind !== "boolean") {
            const enumType: InputEnumType = {
                kind: "enum",
                name: constant.name,
                crossLanguageDefinitionId: "",
                valueType: constant.valueType,
                values: [],
                isFixed: false,
                isFlags: false,
                usage: constant.usage,
                access: constant.access,
                namespace: constant.namespace,
            };
            const enumValue : InputEnumValueType = {
                kind: "enumvalue",
                name: constant.value === null ? "Null" : constant.value.toString(),
                value: constant.value as string | number,
                valueType: constant.valueType,
                enumType: enumType
            };
            enumType.values.push(enumValue);
            convertedEnums.push(enumType);
            codeModel.enums.push(enumType);
            constant.valueType = enumType as any;
        }
    }
    // TODO -- convert enumvalue in property types to be constant type.
    return {
        ...codeModel,
        constants: undefined,
    } as unknown as CodeModel;
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
