// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
    Enum,
    EnumMember,
    getDoc,
    getEffectiveModelType,
    getFormat,
    getFriendlyName,
    getIntrinsicModelName,
    getKnownValues,
    getVisibility,
    isIntrinsic,
    Model,
    ModelProperty,
    Namespace,
    NeverType,
    Program,
    Type
} from "@cadl-lang/compiler";
import { getDiscriminator } from "@cadl-lang/rest";
import {
    getHeaderFieldName,
    getPathParamName,
    getQueryParamName,
    isStatusCode
} from "@cadl-lang/rest/http";
import { InputEnumTypeValue } from "../type/InputEnumTypeValue.js";
import { InputModelProperty } from "../type/InputModelProperty.js";
import {
    InputDictionaryType,
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
export function mapCadlTypeToCSharpInputTypeKind(
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
                    return InputTypeKind.BinaryData;
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
                    return InputTypeKind.Duration;
                case "Map":
                    return InputTypeKind.Dictionary;
                default:
                    return InputTypeKind.Model;
            }
        case "ModelProperty":
            return InputTypeKind.Object;
        case "Enum":
            return InputTypeKind.Enum;
        case "Number":
            return InputTypeKind.Int32;
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
    cadlType: Model
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
export function getEffectiveSchemaType(program: Program, type: Type): Type {
    let target = type;
    if (type.kind === "Model" && !type.name) {
        const effective = getEffectiveModelType(program,
            type,
            isSchemaProperty
        );
        if (effective.name) {
            target = effective;
        }
    }

    return target;

    /**
     * A "schema property" here is a property that is emitted to OpenAPI schema.
     *
     * Headers, parameters, status codes are not schema properties even they are
     * represented as properties in Cadl.
     */
    function isSchemaProperty(property: ModelProperty) {
        const headerInfo = getHeaderFieldName(program, property);
        const queryInfo = getQueryParamName(program, property);
        const pathInfo = getPathParamName(program, property);
        const statusCodeinfo = isStatusCode(program, property);
        return !(headerInfo || queryInfo || pathInfo || statusCodeinfo);
    }
}

export function getDefaultValue(type: Type): any {
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
export function isNeverType(type: Type): type is NeverType {
    return type.kind === "Intrinsic" && type.name === "never";
}

export function getInputType(
    program: Program,
    type: Type,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
): InputType {
    if (type.kind === "Model") {
        return getInputModelType(type);
    } else if (
        type.kind === "String" ||
        type.kind === "Number" ||
        type.kind === "Boolean"
    ) {
        // For literal types, we just want to emit them directly as well.
        const builtInKind: InputTypeKind = mapCadlTypeToCSharpInputTypeKind(
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
    } else {
        return {
            Name: InputTypeKind.UnKnownKind,
            IsNullable: false
        } as InputType;
    }

    function getInputModelType(m: Model): InputType {
        const intrinsicName = getIntrinsicModelName(program, m);
        if (intrinsicName && intrinsicName === "string") {
            const values = getKnownValues(program, m);
            if (values) {
                return getInputModelForExtensibleEnum(m, values);
            }
        }

        /* Array and Map Type. */
        if (m.indexer) {
            if (!isNeverType(m.indexer.key)) {
                const name = getIntrinsicModelName(program, m.indexer.key);
                if (m.indexer.value) {
                    if (name === "integer") {
                        return getInputTypeForArray(m.indexer.value);
                    } else {
                        return getInputTypeForMap(
                            m.indexer.key,
                            m.indexer.value
                        );
                    }
                }
            }
        }

        if (m.name === intrinsicName) {
            // if the model is one of the Cadl Intrinsic type.
            // it's a base Cadl "primitive" that corresponds directly to an c# data type.
            // In such cases, we don't want to emit a ref and instead just
            // emit the base type directly.
            return {
                Name: mapCadlIntrinsicModelToCsharpModel(program, m) ?? m.name,
                Kind: mapCadlTypeToCSharpInputTypeKind(program, m),
                IsNullable: false
            } as InputPrimitiveType;
        } else {
            return getInputModelForModel(m);
        }
    }

    function getInputModelForExtensibleEnum(
        m: Model,
        e: Enum
    ): InputEnumType {
        let extensibleEnum = enums.get(m.name);
        if (!extensibleEnum) {
            const innerEnum: InputEnumType = getInputTypeForEnum(e, false);
            if (!innerEnum) {
                throw new Error(
                    `Extensible enum type '${e.name}' has no values defined.`
                );
            }
            extensibleEnum = {
                Name: m.name,
                Namespace: getFullNamespaceString(e.namespace),
                Accessibility: undefined, //TODO: need to add accessibility
                Description: getDoc(program, m),
                EnumValueType: innerEnum.EnumValueType,
                AllowedValues: innerEnum.AllowedValues,
                IsExtensible: true,
                IsNullable: false
            } as InputEnumType;
            enums.set(m.name, extensibleEnum);
        }
        return extensibleEnum;
    }

    function getInputTypeForEnum(
        e: Enum,
        addToCollection: boolean = true
    ): InputEnumType {
        let enumType = enums.get(e.name);
        if (!enumType) {
            if (e.members.size == 0) {
                throw new Error(
                    `Enum type '${e.name}' doesn't define any values.`
                );
            }
            const allowValues: InputEnumTypeValue[] = [];
            const enumValueType = enumMemberType(e.members.entries().next().value);

            for (const key of e.members.keys()) {
                const option = e.members.get(key);
                if (!option) {
                    throw Error(`No member value for $key`);
                }
                if (enumValueType !== enumMemberType(option)) {
                    throw new Error("The enum member value type is not consistent.");
                }
                const member = {
                    Name: key,
                    Value: option.value ?? option?.name,
                    Description: getDoc(program, option),
                } as InputEnumTypeValue;
                allowValues.push(member);
            }

            enumType = {
                Name: e.name,
                Namespace: getFullNamespaceString(e.namespace),
                Accessibility: undefined, //TODO: need to add accessibility
                Description: getDoc(program, e) ?? "",
                EnumValueType: enumValueType,
                AllowedValues: allowValues,
                IsExtensible: false,
                IsNullable: false
            } as InputEnumType;
            if (addToCollection) enums.set(e.name, enumType);
        }
        return enumType;

        function enumMemberType(member: EnumMember): string {
            if (typeof member.value === "number") {
                return "Int32";
            }
            return "String";
        }
    }

    function getInputTypeForArray(elementType: Type): InputListType {
        return {
            Name: "Array",
            ElementType: getInputType(program, elementType, models, enums),
            IsNullable: false
        } as InputListType;
    }

    function getInputTypeForMap(key: Type, value: Type): InputDictionaryType {
        return {
            Name: "Dictionary",
            KeyType: getInputType(program, key, models, enums),
            ValueType: getInputType(program, value, models, enums),
            IsNullable: false
        } as InputDictionaryType;
    }

    function getInputModelForModel(m: Model): InputModelType {
        m = getEffectiveSchemaType(program, m) as Model;
        const name = getFriendlyName(program, m) ?? m.name;
        let model = models.get(name);
        if (!model) {
            const baseModel = getInputModelBaseType(m.baseModel);
            const properties: InputModelProperty[] = [];

            model = {
                Name: name,
                Namespace: getFullNamespaceString(m.namespace),
                Description: getDoc(program, m),
                IsNullable: false,
                DiscriminatorPropertyName: getDiscriminator(program, m)
                    ?.propertyName,
                DiscriminatorValue: getDiscriminatorValue(m, baseModel),
                BaseModel: baseModel,
                Properties: properties // Properties should be the last assigned to model
            } as InputModelType;

            models.set(name, model);

            // Resolve properties after model is added to the map to resolve possible circular dependencies
            addModelProperties(
                m.properties,
                properties,
                baseModel?.DiscriminatorPropertyName
            );

            // Temporary part. Derived types may not be referenced directly by any operation
            // We should be able to remove it when https://github.com/Azure/cadl-azure/issues/1733 is closed
            if (model.DiscriminatorPropertyName && m.derivedModels) {
                for (const dm of m.derivedModels) {
                    getInputType(program, dm, models, enums);
                }
            }
        }

        return model;
    }

    function getDiscriminatorValue(
        m: Model,
        baseModel?: InputModelType
    ): string | undefined {
        const discriminatorPropertyName = baseModel?.DiscriminatorPropertyName;

        if (discriminatorPropertyName) {
            const discriminatorProperty = m.properties.get(
                discriminatorPropertyName
            );
            if (discriminatorProperty?.type.kind === "String") {
                return discriminatorProperty.type.value;
            }
        }

        return undefined;
    }

    function addModelProperties(
        inputProperties: Map<string, ModelProperty>,
        outputProperties: InputModelProperty[],
        discriminatorPropertyName?: string
    ): void {
        inputProperties.forEach((value: ModelProperty, key: string) => {
            if (value.name !== discriminatorPropertyName) {
                const vis = getVisibility(program, value);
                let isReadOnly: boolean = false;
                if (vis && vis.includes("read") && vis.length === 1) {
                    isReadOnly = true;
                }
                const inputProp = {
                    Name: value.name,
                    SerializedName: value.name,
                    Description: "",
                    Type: getInputType(program, value.type, models, enums),
                    IsRequired: !value.optional,
                    IsReadOnly: isReadOnly,
                    IsDiscriminator: false
                };
                outputProperties.push(inputProp);
            }
        });
    }

    function getInputModelBaseType(m?: Model): InputModelType | undefined {
        if (!m) {
            return undefined;
        }

        // Arrays and dictionaries can't be a base type
        if (m.indexer) {
            return undefined;
        }

        // Cadl "primitive" types can't be base types for models
        const intrinsicName = getIntrinsicModelName(program, m);
        if (intrinsicName) {
            return undefined;
        }

        return getInputModelForModel(m);
    }

    function getFullNamespaceString(namespace: Namespace | undefined): string {
        if (!namespace || !namespace.name) {
            return "";
        }

        let namespaceString: string = namespace.name;
        let current: Namespace | undefined = namespace.namespace;
        while (current && current.name) {
            namespaceString = `${current.name}.${namespaceString}`;
            current = current.namespace;
        }
        return namespaceString;
    }
}
