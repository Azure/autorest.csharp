// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
    ArrayType,
    EnumMemberType,
    EnumType,
    getDoc,
    getFormat,
    getFriendlyName,
    getIntrinsicModelName,
    getVisibility,
    isIntrinsic,
    ModelType,
    ModelTypeProperty,
    Program,
    Type
} from "@cadl-lang/compiler";
import {
    getHeaderFieldName,
    getPathParamName,
    getQueryParamName,
    isStatusCode
} from "@cadl-lang/rest/http";
import { InputEnumTypeValue } from "../type/InputEnumTypeValue.js";
import { InputModelProperty } from "../type/InputModelProperty.js";
import {
    InputEnumType,
    InputListType,
    InputModelType,
    InputPrimitiveType,
    InputType
} from "../type/InputType.js";
import { InputTypeKind } from "../type/InputTypeKind.js";
/**
 * Map calType to csharp InputTypeKind
 */
export function mapCalTypeToCsharpInputTypeKind(
    program: Program,
    cadlType: Type
): InputTypeKind {
    const format = getFormat(program, cadlType);
    const kind = cadlType.kind;
    switch (kind) {
        case "Model":
            const name = cadlType.name;
            switch (name) {
                case "bytes":
                    return InputTypeKind.Bytes;
                case "int8":
                    return InputTypeKind.Int32;
                case "int16":
                    return InputTypeKind.Int32;
                case "int32":
                    return InputTypeKind.Int32;
                case "int64":
                    return InputTypeKind.Int64;
                case "safeint":
                    return InputTypeKind.Int64;
                case "uint8":
                    return InputTypeKind.Int32;
                case "uint16":
                    return InputTypeKind.Int32;
                case "uint32":
                    return InputTypeKind.Int32;
                case "uint64":
                    return InputTypeKind.Int64;
                case "float32":
                    return InputTypeKind.Float32;
                case "float64":
                    return InputTypeKind.Float64;
                case "string":
                    return InputTypeKind.String;
                case "boolean":
                    return InputTypeKind.Boolean;
                case "plainDate":
                    return InputTypeKind.DateTime;
                case "zonedDateTime":
                    return InputTypeKind.DateTime;
                case "plainTime":
                    return InputTypeKind.Time;
                case "duration":
                    return InputTypeKind.String;
                case "Map":
                    return InputTypeKind.Dictionary;
                default:
                    return InputTypeKind.Model;
            }
        case "ModelProperty":
            return InputTypeKind.Object;
        case "Enum":
            return InputTypeKind.Enum;
        case "Array":
            return InputTypeKind.List;
        case "String":
            if (format === "date") return InputTypeKind.DateTime;
            if (format === "uri") return InputTypeKind.Uri;
            return InputTypeKind.String;
        default:
            return InputTypeKind.UnKnownKind;
    }
}

/**
 * Map cadl intrinsic model to c# model name
 * @param cadlType
 */
export function mapCadlIntrinsicModelToCsharpModel(
    program: Program,
    cadlType: ModelType
): string | undefined {
    if (!isIntrinsic(program, cadlType)) {
        return undefined;
    }
    //const name = getIntrinsicModelName(program, cadlType);
    const name = cadlType.name;
    switch (name) {
        case "bytes":
            return "Bytes";
        case "int8":
            return "Byte";
        case "int16":
            return "Int16";
        case "int32":
            return "Int32";
        case "int64":
            return "Int64";
        case "safeint":
            return "Int64";
        case "uint8":
            return "Byte";
        case "uint16":
            return "UInt16";
        case "uint32":
            return "UInt32";
        case "uint64":
            return "UInt64";
        case "float64":
            return "double";
        case "float32":
            return "float";
        case "string":
            return "string";
        case "boolean":
            return "bool";
        case "plainDate":
            return "DateTime";
        case "zonedDateTime":
            return "DateTime";
        case "plainTime":
            return "TimeSpan";
        case "duration":
            return "TimeSpan";
        case "Map":
            // We assert on valType because Map types always have a type
            return "Dictionary";
        default:
            return "UnKnownType";
    }
}

/**
 * If type is an anonymous model, tries to find a named model that has the same
 * set of properties when non-schema properties are excluded.
 */
function getEffectiveSchemaType(program: Program, type: Type): Type {
    if (type.kind === "Model" && !type.name) {
        const effective = program.checker.getEffectiveModelType(
            type,
            isSchemaProperty
        );
        if (effective.name) {
            return effective;
        }
    }
    return type;

    /**
     * A "schema property" here is a property that is emitted to OpenAPI schema.
     *
     * Headers, parameters, status codes are not schema properties even they are
     * represented as properties in Cadl.
     */
    function isSchemaProperty(property: ModelTypeProperty) {
        const headerInfo = getHeaderFieldName(program, property);
        const queryInfo = getQueryParamName(program, property);
        const pathInfo = getPathParamName(program, property);
        const statusCodeinfo = isStatusCode(program, property);
        return !(headerInfo || queryInfo || pathInfo || statusCodeinfo);
    }
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

export function getInputType(
    program: Program,
    type: Type,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
): InputType {
    if (type.kind === "Model") {
        return getInputModelType(program, type);
    } else if (
        type.kind === "String" ||
        type.kind === "Number" ||
        type.kind === "Boolean"
    ) {
        // For literal types, we just want to emit them directly as well.
        const builtInKind: InputTypeKind = mapCalTypeToCsharpInputTypeKind(
            program,
            type
        );
        return {
            Name: type.kind,
            Kind: builtInKind,
            IsNullable: false
        } as InputPrimitiveType;
    } else if (type.kind === "Enum") {
        return getInputTypeForEnum(type);
    } else if (type.kind === "Array") {
        return getInputTypeForArray(program, type);
    } else {
        return {
            Name: InputTypeKind.UnKnownKind,
            IsNullable: false
        } as InputType;
    }

    function getInputModelType(program: Program, m: ModelType): InputType {
        if (m.name === getIntrinsicModelName(program, m)) {
            // if the model is one of the Cadl Intrinsic type.
            // it's a base Cadl "primitive" that corresponds directly to an c# data type.
            // In such cases, we don't want to emit a ref and instead just
            // emit the base type directly.
            return {
                Name: mapCadlIntrinsicModelToCsharpModel(program, m) ?? m.name,
                Kind: mapCalTypeToCsharpInputTypeKind(program, m),
                IsNullable: false
            } as InputPrimitiveType;
        } else {
            m = getEffectiveSchemaType(program, m) as ModelType;
            const name = getFriendlyName(program, m) ?? m.name;
            let model = models.get(name);
            if (!model) {
                // Get properties of the model.
                const properties: InputModelProperty[] = [];
                m.properties.forEach(
                    (value: ModelTypeProperty, key: string) => {
                        // console.log(key, value);
                        const vis = getVisibility(program, value);
                        let isReadOnly: boolean = false;
                        if (vis && vis.includes("read") && vis.length == 1) {
                            isReadOnly = true;
                        }
                        const inputProp = {
                            Name: value.name,
                            SerializedName: value.name,
                            Description: "",
                            Type: getInputType(
                                program,
                                value.type,
                                models,
                                enums
                            ),
                            IsRequired: !value.optional,
                            IsReadOnly: isReadOnly, //TODO: get the require and readonly value from cadl.
                            IsDiscriminator: false
                        };
                        properties.push(inputProp);
                    }
                );

                model = {
                    Name: name,
                    IsNullable: false,
                    Properties: properties
                } as InputModelType;

                models.set(name, model);
            }

            return model;
        }
    }

    function getInputTypeForEnum(e: EnumType): InputType {
        let enumType = enums.get(e.name);
        if (!enumType) {
            if (e.members.length == 0) {
                return {
                    Name: InputTypeKind.UnKnownKind,
                    IsNullable: false
                } as InputType;
            }
            const allowValues: InputEnumTypeValue[] = [];
            const enumValueType = enumMemberType(e.members[0]);

            for (const option of e.members) {
                if (enumValueType.Kind !== enumMemberType(option).Kind) {
                    // TODO: add error handler
                    continue;
                }

                const member = {
                    Name: option.name,
                    Value: option.value
                } as InputEnumTypeValue;

                allowValues.push(member);
            }
            //TODO: need to figure out if it is extensible or not.
            const isExtensible: boolean = false;
            enumType = {
                Name: e.name,
                EnumValueType: enumValueType,
                AllowedValues: allowValues,
                IsExtensible: isExtensible,
                IsNullable: false
            } as InputEnumType;
            enums.set(e.name, enumType);
        }
        return enumType;

        function enumMemberType(member: EnumMemberType): string {
            if (typeof member.value === "number") {
                return "Int32";
            }
            return "String";
        }
    }

    function getInputTypeForArray(
        program: Program,
        arr: ArrayType
    ): InputListType {
        const elementType = arr.elementType;
        return {
            Name: "Array",
            ElementType: getInputType(program, elementType, models, enums),
            IsNullable: false
        } as InputListType;
    }
}
