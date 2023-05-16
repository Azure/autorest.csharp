// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { isFixed } from "@azure-tools/typespec-azure-core";
import {
    Enum,
    EnumMember,
    getDoc,
    getDeprecated,
    getEffectiveModelType,
    getFormat,
    getFriendlyName,
    getKnownValues,
    getVisibility,
    Model,
    ModelProperty,
    Namespace,
    NeverType,
    Operation,
    Program,
    resolveUsages,
    Type,
    UsageFlags,
    getDiscriminator,
    IntrinsicType,
    isVoidType,
    isArrayModelType,
    isRecordModelType,
    Scalar,
    Union,
    getProjectedNames,
    $format
} from "@typespec/compiler";
import { getResourceOperation } from "@typespec/rest";
import {
    getHeaderFieldName,
    getPathParamName,
    getQueryParamName,
    HttpOperation,
    isStatusCode
} from "@typespec/http";
import {
    projectedNameClientKey,
    projectedNameCSharpKey,
    projectedNameJsonKey
} from "../constants.js";
import { InputEnumTypeValue } from "../type/inputEnumTypeValue.js";
import { InputModelProperty } from "../type/inputModelProperty.js";
import {
    InputDictionaryType,
    InputEnumType,
    InputListType,
    InputLiteralType,
    InputModelType,
    InputPrimitiveType,
    InputType,
    InputUnionType,
    InputNullType,
    InputIntrinsicType,
    InputUnknownType
} from "../type/inputType.js";
import { InputTypeKind } from "../type/inputTypeKind.js";
import { Usage } from "../type/usage.js";
import { logger } from "./logger.js";
import {
    SdkContext,
    getSdkSimpleType,
    isInternal
} from "@azure-tools/typespec-client-generator-core";
import { capitalize, getNameForTemplate } from "./utils.js";
/**
 * Map calType to csharp InputTypeKind
 */
export function mapCadlTypeToCSharpInputTypeKind(
    context: SdkContext,
    cadlType: Type,
    format?: string
): InputTypeKind {
    const kind = cadlType.kind;
    switch (kind) {
        case "Model":
            return getCSharpInputTypeKindByIntrinsicModelName(
                cadlType.name,
                format
            );
        case "ModelProperty":
            return InputTypeKind.Object;
        case "Enum":
            return InputTypeKind.Enum;
        case "Number":
            let numberValue = cadlType.value;
            if (numberValue % 1 === 0) {
                return InputTypeKind.Int32;
            }
            return InputTypeKind.Float64;
        case "Boolean":
            return InputTypeKind.Boolean;
        case "String":
            if (format === "date") return InputTypeKind.DateTime;
            if (format === "uri") return InputTypeKind.Uri;
            return InputTypeKind.String;
        default:
            return InputTypeKind.UnKnownKind;
    }
}

function getCSharpInputTypeKindByIntrinsicModelName(
    name: string,
    format?: string
): InputTypeKind {
    switch (name) {
        case "bytes":
            return InputTypeKind.Bytes;
        case "int8":
            return InputTypeKind.SByte;
        case "unit8":
            return InputTypeKind.Byte;
        case "int32":
            return InputTypeKind.Int32;
        case "int64":
            return InputTypeKind.Int64;
        case "float32":
            return InputTypeKind.Float32;
        case "float64":
            return InputTypeKind.Float64;
        case "string":
            switch (format?.toLowerCase()) {
                case "date":
                    return InputTypeKind.DateTime;
                case "uri":
                case "url":
                    return InputTypeKind.Uri;
                case "uuid":
                    return InputTypeKind.Guid;
                default:
                    return InputTypeKind.String;
            }
        case "boolean":
            return InputTypeKind.Boolean;
        case "date":
            return InputTypeKind.Date;
        case "datetime":
            return InputTypeKind.DateTime;
        case "time":
            return InputTypeKind.Time;
        case "duration":
            return InputTypeKind.DurationISO8601;
        default:
            return InputTypeKind.Object;
    }
}

/**
 * If type is an anonymous model, tries to find a named model that has the same
 * set of properties when non-schema properties are excluded.
 */
export function getEffectiveSchemaType(context: SdkContext, type: Type): Type {
    let target = type;
    if (type.kind === "Model" && !type.name) {
        const effective = getEffectiveModelType(
            context.program,
            type,
            isSchemaPropertyInternal
        );
        if (effective.name) {
            target = effective;
        }
    }

    return target;

    function isSchemaPropertyInternal(property: ModelProperty) {
        return isSchemaProperty(context, property);
    }
}

/**
 * A "schema property" here is a property that is emitted to OpenAPI schema.
 *
 * Headers, parameters, status codes are not schema properties even they are
 * represented as properties in Cadl.
 */
function isSchemaProperty(context: SdkContext, property: ModelProperty) {
    const program = context.program;
    const headerInfo = getHeaderFieldName(program, property);
    const queryInfo = getQueryParamName(program, property);
    const pathInfo = getPathParamName(program, property);
    const statusCodeinfo = isStatusCode(program, property);
    return !(headerInfo || queryInfo || pathInfo || statusCodeinfo);
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
    context: SdkContext,
    type: Type,
    format: string | undefined,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
): InputType {
    logger.debug(`getInputType for kind: ${type.kind}`);
    const program = context.program;
    if (type.kind === "Model") {
        return getInputModelType(type);
    } else if (
        type.kind === "String" ||
        type.kind === "Number" ||
        type.kind === "Boolean"
    ) {
        // For literal types, we just want to emit them directly as well.
        const builtInKind: InputTypeKind = mapCadlTypeToCSharpInputTypeKind(
            context,
            type,
            format
        );
        const valueType = {
            Name: type.kind,
            Kind: builtInKind,
            IsNullable: false
        } as InputPrimitiveType;

        return {
            Name: "Literal",
            LiteralValueType: valueType,
            Value: getDefaultValue(type),
            IsNullable: false
        } as InputLiteralType;
    } else if (type.kind === "Enum") {
        return getInputTypeForEnum(type);
    } else if (type.kind === "EnumMember") {
        return getInputTypeForEnum(type.enum);
    } else if (type.kind === "Intrinsic") {
        return getInputModelForIntrinsicType(type);
    } else if (type.kind === "Scalar") {
        let effectiveType = type;
        while (!program.checker.isStdType(effectiveType)) {
            if (type.baseScalar) {
                effectiveType = type.baseScalar;
            } else {
                break;
            }
        }
        const intrinsicName = effectiveType.name;
        switch (intrinsicName) {
            case "string":
                const values = getKnownValues(program, type);
                if (values) {
                    return getInputModelForEnumByKnowValues(type, values);
                }
            // if the model is one of the Cadl Intrinsic type.
            // it's a base Cadl "primitive" that corresponds directly to an c# data type.
            // In such cases, we don't want to emit a ref and instead just
            // emit the base type directly.
            default:
                const sdkType = getSdkSimpleType(context, type);
                return {
                    Name: type.name,
                    Kind: getCSharpInputTypeKindByIntrinsicModelName(
                        sdkType.kind,
                        sdkType.format ?? format
                    ),
                    IsNullable: false
                } as InputPrimitiveType;
        }
    } else if (type.kind === "Union") {
        return getInputTypeForUnion(type);
    } else {
        throw new Error(`Unsupported type ${type.kind}`);
    }

    function getInputModelType(m: Model): InputType {
        /* Array and Map Type. */
        if (!isNeverType(m)) {
            if (isArrayModelType(program, m)) {
                return getInputTypeForArray(m.indexer.value);
            } else if (isRecordModelType(program, m)) {
                return getInputTypeForMap(m.indexer.key, m.indexer.value);
            }
        }
        return getInputModelForModel(m);
    }

    function getInputModelForEnumByKnowValues(
        m: Model | Scalar,
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
                Deprecated: getDeprecated(program, m),
                Description: getDoc(program, m),
                EnumValueType: innerEnum.EnumValueType,
                AllowedValues: innerEnum.AllowedValues,
                IsExtensible: !isFixed(program, e),
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
            if (e.members.size === 0) {
                throw new Error(
                    `Enum type '${e.name}' doesn't define any values.`
                );
            }
            const allowValues: InputEnumTypeValue[] = [];
            const enumValueType = enumMemberType(
                e.members.entries().next().value[1]
            );

            for (const key of e.members.keys()) {
                const option = e.members.get(key);
                if (!option) {
                    throw Error(`No member value for $key`);
                }
                if (enumValueType !== enumMemberType(option)) {
                    throw new Error(
                        "The enum member value type is not consistent."
                    );
                }
                const member = {
                    Name: key,
                    Value: option.value ?? option?.name,
                    Description: getDoc(program, option)
                } as InputEnumTypeValue;
                allowValues.push(member);
            }

            enumType = {
                Name: e.name,
                Namespace: getFullNamespaceString(e.namespace),
                Accessibility: undefined, //TODO: need to add accessibility
                Deprecated: getDeprecated(program, e),
                Description: getDoc(program, e) ?? "",
                EnumValueType: enumValueType,
                AllowedValues: allowValues,
                IsExtensible: !isFixed(program, e),
                IsNullable: false
            } as InputEnumType;
            if (addToCollection) enums.set(e.name, enumType);
        }
        return enumType;

        function enumMemberType(member: EnumMember): string {
            if (typeof member.value === "number") {
                return "Float32";
            }
            return "String";
        }
    }

    function getInputTypeForArray(elementType: Type): InputListType {
        return {
            Name: "Array",
            ElementType: getInputType(
                context,
                elementType,
                getFormat(program, elementType),
                models,
                enums
            ),
            IsNullable: false
        } as InputListType;
    }

    function getInputTypeForMap(key: Type, value: Type): InputDictionaryType {
        return {
            Name: "Dictionary",
            KeyType: getInputType(
                context,
                key,
                getFormat(program, key),
                models,
                enums
            ),
            ValueType: getInputType(
                context,
                value,
                getFormat(program, value),
                models,
                enums
            ),
            IsNullable: false
        } as InputDictionaryType;
    }

    function getInputModelForModel(m: Model): InputModelType {
        m = getEffectiveSchemaType(context, m) as Model;
        const name = getFriendlyName(program, m) ?? getNameForTemplate(m);
        let model = models.get(name);
        if (!model) {
            const baseModel = getInputModelBaseType(m.baseModel);
            const properties: InputModelProperty[] = [];

            model = {
                Name: name,
                Namespace: getFullNamespaceString(m.namespace),
                Accessibility: isInternal(context, m) ? "internal" : undefined,
                Deprecated: getDeprecated(program, m),
                Description: getDoc(program, m),
                IsNullable: false,
                DiscriminatorPropertyName: getDiscriminator(program, m)
                    ?.propertyName,
                DiscriminatorValue: getDiscriminatorValue(m, baseModel),
                BaseModel: baseModel,
                Usage: Usage.None,
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
                    getInputType(
                        context,
                        dm,
                        getFormat(program, dm),
                        models,
                        enums
                    );
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
            if (
                value.name !== discriminatorPropertyName &&
                isSchemaProperty(context, value)
            ) {
                const vis = getVisibility(program, value);
                let isReadOnly: boolean = false;
                if (vis && vis.includes("read") && vis.length === 1) {
                    isReadOnly = true;
                }
                if (isNeverType(value.type) || isVoidType(value.type)) return;
                const projectedNamesMap = getProjectedNames(program, value);
                const name =
                    projectedNamesMap?.get(projectedNameCSharpKey) ??
                    projectedNamesMap?.get(projectedNameClientKey) ??
                    value.name;
                const serializedName =
                    projectedNamesMap?.get(projectedNameJsonKey) ?? value.name;
                const inputType = getInputType(
                    context,
                    value.type,
                    getFormat(program, value),
                    models,
                    enums
                );
                const inputProp = {
                    Name: name,
                    SerializedName: serializedName,
                    Description: getDoc(program, value) ?? "",
                    Type: inputType,
                    IsRequired: !value.optional,
                    IsReadOnly: isReadOnly,
                    IsDiscriminator: false
                } as InputModelProperty;
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
        if (program.checker.isStdType(m)) {
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

    function getInputModelForIntrinsicType(type: IntrinsicType): InputType {
        switch (type.name) {
            case "unknown":
                return {
                    Name: "Intrinsic",
                    Kind: "unknown",
                    IsNullable: false
                } as InputUnknownType;
            case "null":
                return {
                    Name: "Intrinsic",
                    Kind: "null",
                    IsNullable: false
                } as InputNullType;
            default:
                throw new Error(`Unsupported type ${type.name}`);
        }
    }

    function getInputTypeForUnion(union: Union): InputType {
        let ItemTypes: InputType[] = [];
        const variants = Array.from(union.variants.values());

        let hasNullType = false;
        for (const variant of variants) {
            const inputType = getInputType(
                context,
                variant.type,
                getFormat(program, variant.type),
                models,
                enums
            );
            if (
                inputType.Name === "Intrinsic" &&
                (inputType as InputIntrinsicType).Kind === "null"
            ) {
                hasNullType = true;
                continue;
            }
            ItemTypes.push(inputType);
        }

        if (hasNullType) {
            ItemTypes = ItemTypes.map((i) => {
                i.IsNullable = true;
                return i;
            });
        }

        return ItemTypes.length > 1
            ? ({
                  Name: "Union",
                  UnionItemTypes: ItemTypes,
                  IsNullable: false
              } as InputUnionType)
            : ItemTypes[0];
    }
}

export function getUsages(
    context: SdkContext,
    ops?: HttpOperation[]
): { inputs: string[]; outputs: string[]; roundTrips: string[] } {
    const program = context.program;
    const result: {
        inputs: string[];
        outputs: string[];
        roundTrips: string[];
    } = { inputs: [], outputs: [], roundTrips: [] };
    if (!ops) {
        return result;
    }

    const operations: Operation[] = ops.map((op) => op.operation);
    const usages = resolveUsages(operations);
    const usagesMap: Map<string, UsageFlags> = new Map<string, UsageFlags>();
    for (const type of usages.types) {
        let typeName = "";
        if ("name" in type) typeName = type.name ?? "";
        let effectiveType = type;
        if (type.kind === "Model") {
            effectiveType = getEffectiveSchemaType(context, type) as Model;
            typeName =
                getFriendlyName(program, effectiveType) ?? effectiveType.name;
        }
        const affectTypes: string[] = [];
        if (typeName !== "") {
            affectTypes.push(typeName);
            if (
                effectiveType.kind === "Model" &&
                effectiveType.templateMapper?.args
            ) {
                for (const arg of effectiveType.templateMapper.args) {
                    if (
                        arg.kind === "Model" &&
                        "name" in arg &&
                        arg.name !== ""
                    ) {
                        affectTypes.push(
                            getFriendlyName(program, arg) ?? arg.name
                        );
                    }
                }
            }
        }

        for (const name of affectTypes) {
            let value = usagesMap.get(name);
            if (!value) value = UsageFlags.None;
            if (usages.isUsedAs(type, UsageFlags.Input))
                value = value | UsageFlags.Input;
            if (usages.isUsedAs(type, UsageFlags.Output))
                value = value | UsageFlags.Output;
            usagesMap.set(name, value);
        }
    }

    for (const op of ops) {
        const resourceOperation = getResourceOperation(program, op.operation);
        if (!op.parameters.bodyParameter && op.parameters.bodyType) {
            let bodyTypeName = "";
            if (resourceOperation) {
                /* handle resource operation. */
                bodyTypeName = resourceOperation.resourceType.name;
            } else {
                /* handle spread. */
                const effectiveBodyType = getEffectiveSchemaType(
                    context,
                    op.parameters.bodyType
                );
                if (effectiveBodyType.kind === "Model") {
                    if (effectiveBodyType.name !== "") {
                        bodyTypeName =
                            getFriendlyName(program, effectiveBodyType) ??
                            effectiveBodyType.name;
                    } else {
                        bodyTypeName = `${capitalize(
                            op.operation.name
                        )}Request`;
                    }
                }
            }
            appendUsage(bodyTypeName, UsageFlags.Input);
        }
        /* handle response type usage. */
        for (const res of op.responses) {
            const resBody = res.responses[0]?.body;
            if (resBody?.type) {
                let returnType = "";
                if (
                    resourceOperation &&
                    resourceOperation.operation !== "list"
                ) {
                    returnType = resourceOperation.resourceType.name;
                } else {
                    const effectiveReturnType = getEffectiveSchemaType(
                        context,
                        resBody.type
                    );
                    if (
                        effectiveReturnType.kind === "Model" &&
                        effectiveReturnType.name !== ""
                    ) {
                        returnType =
                            getFriendlyName(program, effectiveReturnType) ??
                            effectiveReturnType.name;
                    }
                }
                appendUsage(returnType, UsageFlags.Output);
            }
        }
    }

    for (const [key, value] of usagesMap) {
        if (value === (UsageFlags.Input | UsageFlags.Output)) {
            result.roundTrips.push(key);
        } else if (value === UsageFlags.Input) {
            result.inputs.push(key);
        } else if (value === UsageFlags.Output) {
            result.outputs.push(key);
        }
    }
    return result;

    function appendUsage(name: string, flag: UsageFlags) {
        let value = usagesMap.get(name);
        if (!value) value = flag;
        else value = value | flag;
        usagesMap.set(name, value);
    }
}
