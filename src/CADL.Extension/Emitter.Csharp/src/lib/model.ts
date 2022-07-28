// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
    getFormat,
    getFriendlyName,
    getIntrinsicModelName,
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
import { InputType } from "../type/InputType.js";
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

export function getInputType(program: Program, type: Type): InputType {
    const builtInKind: InputTypeKind = mapCalTypeToCsharpInputTypeKind(
        program,
        type
    );
    if (type.kind === "Model") {
        if (type.name === getIntrinsicModelName(program, type)) {
            // if the model is one of the Cadl Intrinsic type.
            // it's a base Cadl "primitive" that corresponds directly to an c# data type.
            // In such cases, we don't want to emit a ref and instead just
            // emit the base type directly.
            return new InputType(
                mapCadlIntrinsicModelToCsharpModel(program, type) ?? type.name,
                builtInKind,
                false
            );
        } else {
            type = getEffectiveSchemaType(program, type) as ModelType;
            const name = getFriendlyName(program, type) ?? type.name;
            return new InputType(name, builtInKind, false);
        }
    }

    if (
        type.kind === "String" ||
        type.kind === "Number" ||
        type.kind === "Boolean"
    ) {
        // For literal types, we just want to emit them directly as well.
        return new InputType(type.kind, builtInKind, false);
    }

    return new InputType(type.kind, InputTypeKind.UnKnownKind, false);
}
