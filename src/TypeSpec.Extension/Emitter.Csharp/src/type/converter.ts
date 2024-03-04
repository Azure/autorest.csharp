import {
    SdkContext,
    SdkEnumType,
    SdkEnumValueType
} from "@azure-tools/typespec-client-generator-core";
import { InputEnumType } from "./inputType.js";
import { Enum } from "@typespec/compiler";
import { InputTypeKind } from "./inputTypeKind.js";
import { getFullNamespaceString } from "../lib/utils.js";
import { InputEnumTypeValue } from "./inputEnumTypeValue.js";
import { setUsage } from "../lib/model.js";

export function fromSdkEnumType(
    enumType: SdkEnumType,
    context: SdkContext,
    enums: Map<string, InputEnumType>,
    addToCollection: boolean = true
): InputEnumType {
    let inputEnumType = enums.get(enumType.name);
    if (inputEnumType === undefined) {
        const enumValueType =
            enumType.valueType.kind === "float32" ? "Float32" : "String";
        const newInputEnumType: InputEnumType = {
            Kind: InputTypeKind.Enum,
            Name: enumType.name,
            EnumValueType: enumType.valueType.kind,
            AllowedValues: enumType.values.map((v) => fromSdkEnumValueType(v)),
            Namespace: getFullNamespaceString(
                (enumType.__raw! as Enum).namespace
            ),
            Accessibility: enumType.access,
            Deprecated: enumType.deprecation,
            Description: enumType.description,
            IsExtensible: enumType.isFixed ? false : true,
            IsNullable: enumType.nullable,
            Usage: "None"
        };
        setUsage(context, enumType.__raw! as Enum, newInputEnumType);
        if (addToCollection) enums.set(enumType.name, newInputEnumType);
        inputEnumType = newInputEnumType;
    }
    inputEnumType.IsNullable = enumType.nullable; // TO-DO: https://github.com/Azure/autorest.csharp/issues/4314
    return inputEnumType;
}

export function fromSdkEnumValueType(
    enumValueType: SdkEnumValueType
): InputEnumTypeValue {
    return {
        Name: enumValueType.name,
        Value: enumValueType.value,
        Description: enumValueType.description
    } as InputEnumTypeValue;
}
