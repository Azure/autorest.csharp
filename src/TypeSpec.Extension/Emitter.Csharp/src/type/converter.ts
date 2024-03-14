import {
    IntrinsicType,
    Program,
    UsageFlags,
    getDeprecated,
    getDiscriminator,
    Type,
    DateTimeKnownEncoding,
    Model,
    Enum,
    DurationKnownEncoding,
    getFormat
} from "@typespec/compiler";
import { Usage } from "./usage.js";
import {
    SdkType,
    SdkModelPropertyType,
    SdkBodyModelPropertyType,
    SdkModelType,
    SdkEnumType,
    SdkEnumValueType,
    SdkDictionaryType,
    SdkConstantType,
    SdkBuiltInType,
    SdkArrayType,
    SdkDatetimeType,
    SdkUnionType,
    SdkBuiltInKinds,
    SdkContext,
    SdkTupleType,
    SdkDurationType
} from "@azure-tools/typespec-client-generator-core";
import {
    InputDictionaryType,
    InputEnumType,
    InputIntrinsicType,
    InputListType,
    InputLiteralType,
    InputModelType,
    InputPrimitiveType,
    InputType,
    InputUnionType
} from "./inputType.js";
import { InputModelProperty } from "./inputModelProperty.js";
import { Visibility } from "@typespec/http";
import { InputEnumTypeValue } from "./inputEnumTypeValue.js";
import {
    getCSharpInputTypeKindByPrimitiveModelName,
    mapTypeSpecTypeToCSharpInputTypeKind,
    setUsage
} from "../lib/model.js";
import { InputTypeKind } from "./inputTypeKind.js";
import { getFullNamespaceString } from "../lib/utils.js";
import { InputPrimitiveTypeKind } from "./inputPrimitiveTypeKind.js";
import { LiteralTypeContext } from "./literalTypeContext.js";
import { InputIntrinsicTypeKind } from "./inputIntrinsicTypeKind.js";
import { logger } from "../lib/logger.js";

function fromSdkType(
    sdkType: SdkType,
    context: SdkContext,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>,
    literalTypeContext?: LiteralTypeContext
): InputType {
    if (sdkType.kind === "model")
        return fromSdkModelType(sdkType, context, models, enums);
    if (sdkType.kind === "enum")
        return fromSdkEnumType(sdkType, context, enums);
    if (sdkType.kind === "enumvalue")
        return fromSdkEnumType(sdkType.enumType, context, enums);
    if (sdkType.kind === "dict")
        return fromSdkDictionaryType(sdkType, context, models, enums);
    if (sdkType.kind === "array")
        return fromSdkArrayType(sdkType, context, models, enums);
    if (sdkType.kind === "constant")
        return fromSdkConstantType(sdkType, enums, literalTypeContext);
    if (sdkType.kind === "union")
        return fromUnionType(sdkType, context, models, enums);
    if (sdkType.kind === "utcDateTime") return fromSdkDatetimeType(sdkType);
    if (sdkType.kind === "duration")
        return fromSdkDurationType(sdkType as SdkDurationType);
    if (sdkType.kind === "bytes")
        return fromBytesType(sdkType as SdkBuiltInType);
    if (sdkType.kind === "string")
        return fromStringType(context.program, sdkType);
    // TODO: offsetDateTime
    if (sdkType.kind === "tuple") return fromTupleType(sdkType);
    if (sdkType.__raw?.kind === "Scalar") return fromScalarType(sdkType);
    // this happens for discriminator type, normally all other primitive types should be handled in scalar above
    // TODO: can we improve the type in TCGC around discriminator
    if (sdkType.__raw?.kind === "Intrinsic") return fromIntrinsicType(sdkType);
    if (isSdkBuiltInType(sdkType.kind))
        return fromSdkBuiltInType(sdkType as SdkBuiltInType);
    return {} as InputType;
}

export function fromSdkModelType(
    modelType: SdkModelType,
    context: SdkContext,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
): InputModelType {
    var modelTypeName = getModelName(modelType);
    let inputModelType = models.get(modelTypeName);
    if (!inputModelType) {
        inputModelType = {
            Kind: InputTypeKind.Model,
            Name: modelTypeName,
            Namespace: getFullNamespaceString(
                (modelType.__raw as Model).namespace
            ),
            Accessibility: modelType.access,
            Deprecated: modelType.deprecation,
            Description: modelType.description,
            IsNullable: modelType.nullable,
            DiscriminatorPropertyName: getDiscriminator(
                context.program,
                modelType.__raw!
            )?.propertyName, // TO-DO: SdkModelType lacks of DiscriminatorPropertyName
            DiscriminatorValue: modelType.discriminatorValue,
            Usage: fromUsageFlags(modelType.usage)
        } as InputModelType;

        models.set(modelTypeName, inputModelType);

        inputModelType.BaseModel = modelType.baseModel
            ? fromSdkModelType(modelType.baseModel, context, models, enums)
            : undefined;

        // TODO: can we fix the resolving reference issue in csharp?
        // https://github.com/Azure/autorest.csharp/issues/4136
        // if (modelType.discriminatedSubtypes) {
        //     inputModelType.DerivedModels = Object.values(
        //         modelType.discriminatedSubtypes
        //     ).map((m) => fromSdkModelType(m, program, models, enums));
        // }

        inputModelType.InheritedDictionaryType = modelType.additionalProperties
            ? ({
                  Kind: InputTypeKind.Dictionary,
                  Name: InputTypeKind.Dictionary,
                  KeyType: {
                      Kind: InputTypeKind.Primitive,
                      Name: InputPrimitiveTypeKind.String,
                      IsNullable: false
                  } as InputPrimitiveType,
                  ValueType: fromSdkType(
                      modelType.additionalProperties,
                      context,
                      models,
                      enums
                  ),
                  IsNullable: false
              } as InputDictionaryType)
            : undefined;
        inputModelType.Properties = modelType.properties
            .filter(
                (p) =>
                    !(p as SdkBodyModelPropertyType).discriminator ||
                    !hasDiscriminator(modelType.baseModel)
            )
            .map((p) =>
                fromSdkModelPropertyType(p, context, models, enums, {
                    ModelName: inputModelType?.Name,
                    Namespace: inputModelType?.Namespace
                } as LiteralTypeContext)
            );

        const index = inputModelType.Properties.findIndex(
            (p) => p.IsDiscriminator
        );
        if (index !== 0 && index !== -1) {
            const discriminator = inputModelType.Properties.splice(index, 1)[0];
            inputModelType.Properties.unshift(discriminator);
        }
    }

    return inputModelType;
}

// TODO: remove this after TCGC provide utility to generate templated model
function getModelName(model: SdkModelType): string {
    var name = model.generatedName || model.name;
    var rawModel = model.__raw! as Model;
    if (
        name !== "" &&
        rawModel.templateMapper &&
        rawModel.templateMapper.args
    ) {
        return (
            name +
            rawModel.templateMapper.args
                .map((it) => (it as Model).name)
                .join("")
        );
    }

    return name;
}

function hasDiscriminator(model?: SdkModelType): boolean {
    if (model == null) return false;

    if (
        model!.properties.some((p) => {
            return (p as SdkBodyModelPropertyType).discriminator;
        })
    )
        return true;
    return hasDiscriminator(model!.baseModel);
}

export function fromSdkEnumType(
    enumType: SdkEnumType,
    context: SdkContext,
    enums: Map<string, InputEnumType>,
    addToCollection: boolean = true
): InputEnumType {
    let enumName = enumType.generatedName || enumType.name;
    let inputEnumType = enums.get(enumName);
    if (inputEnumType === undefined) {
        const newInputEnumType: InputEnumType = {
            Kind: InputTypeKind.Enum,
            Name: enumName,
            EnumValueType: fromScalarType(enumType.valueType).Name,
            AllowedValues: enumType.values.map((v) => fromSdkEnumValueType(v)),
            Namespace: getFullNamespaceString(
                (enumType.__raw! as Enum).namespace
            ),
            Accessibility: enumType.access,
            Deprecated: enumType.deprecation,
            Description: enumType.description,
            IsExtensible: enumType.isFixed ? false : true,
            IsNullable: enumType.nullable,
            Usage: fromUsageFlags(enumType.usage)
        };
        setUsage(context, enumType.__raw! as Enum, newInputEnumType);
        if (addToCollection) enums.set(enumName, newInputEnumType);
        inputEnumType = newInputEnumType;
    }
    inputEnumType.IsNullable = enumType.nullable; // TO-DO: https://github.com/Azure/autorest.csharp/issues/4314
    return inputEnumType;
}

function fromSdkDatetimeType(
    dateTimeType: SdkDatetimeType
): InputPrimitiveType {
    function fromDateTimeKnownEncoding(
        encoding: DateTimeKnownEncoding
    ): InputPrimitiveTypeKind {
        switch (encoding) {
            case "rfc3339":
                return InputPrimitiveTypeKind.DateTimeRFC3339;
            case "rfc7231":
                return InputPrimitiveTypeKind.DateTimeRFC7231;
            case "unixTimestamp":
                return InputPrimitiveTypeKind.DateTimeUnix;
        }
    }
    return {
        Kind: InputTypeKind.Primitive,
        Name: fromDateTimeKnownEncoding(dateTimeType.encode),
        IsNullable: dateTimeType.nullable
    } as InputPrimitiveType;
}

function fromSdkDurationType(
    durationType: SdkDurationType
): InputPrimitiveType {
    function fromDurationKnownEncoding(
        encode: DurationKnownEncoding,
        wireType: SdkBuiltInType
    ): InputPrimitiveTypeKind {
        switch (encode) {
            case "ISO8601":
                return InputPrimitiveTypeKind.DurationISO8601;
            case "seconds":
                if (wireType.kind === "float" || wireType.kind === "float32") {
                    return InputPrimitiveTypeKind.DurationSecondsFloat;
                }
                return InputPrimitiveTypeKind.DurationSeconds;
            default:
                logger.warn(
                    `invalid encode '${encode}' and wireType '${wireType.kind}' for duration.`
                );
                return InputPrimitiveTypeKind.DurationISO8601;
        }
    }
    return {
        Kind: InputTypeKind.Primitive,
        Name: fromDurationKnownEncoding(
            durationType.encode,
            durationType.wireType
        ),
        IsNullable: durationType.nullable
    } as InputPrimitiveType;
}

function fromTupleType(tupleType: SdkTupleType): InputIntrinsicType {
    return {
        Kind: InputTypeKind.Intrinsic,
        Name: InputIntrinsicTypeKind.Unknown,
        IsNullable: tupleType.nullable
    } as InputIntrinsicType;
}

function fromBytesType(bytesType: SdkBuiltInType): InputPrimitiveType {
    function fromBytesEncoding(encode: string): InputPrimitiveTypeKind {
        switch (encode) {
            case undefined:
            case "base64":
                return InputPrimitiveTypeKind.Bytes;
            case "base64url":
                return InputPrimitiveTypeKind.BytesBase64Url;
            default:
                logger.warn(`invalid encode ${encode} for bytes.`);
                return InputPrimitiveTypeKind.Bytes;
        }
    }

    return {
        Kind: InputTypeKind.Primitive,
        Name: fromBytesEncoding(bytesType.encode),
        IsNullable: bytesType.nullable
    };
}

function fromStringType(program: Program, stringType: SdkType): InputPrimitiveType {
    function fromStringFormat(rawStringType?: Type): InputPrimitiveTypeKind {
        if (!rawStringType)
            return InputPrimitiveTypeKind.String;

        const format = getFormat(program, rawStringType);
        switch (format) {
            case "date":
                // TODO: remove
                return InputPrimitiveTypeKind.DateTime;
            case "uri":
            case "url":
                return InputPrimitiveTypeKind.Uri;
            case "uuid":
                return InputPrimitiveTypeKind.Guid;
            default:
                if (format) {
                    logger.warn(`Invalid string format '${format}'`);
                }
                return InputPrimitiveTypeKind.String;
        }
    }

    return {
        Kind: InputTypeKind.Primitive,
        Name: fromStringFormat(stringType.__raw),
        IsNullable: stringType.nullable
    };
}

export function fromSdkBuiltInType(builtInType: SdkBuiltInType): InputType {
    const builtInKind: InputPrimitiveTypeKind =
        mapTypeSpecTypeToCSharpInputTypeKind(
            builtInType.__raw!,
            builtInType.kind,
            undefined // To-Do: type incompatable
        );
    return {
        Kind: InputTypeKind.Primitive,
        Name: builtInKind,
        IsNullable: false
    } as InputPrimitiveType;
}

function fromScalarType(scalarType: SdkType): InputPrimitiveType {
    return {
        Kind: InputTypeKind.Primitive,
        Name: getCSharpInputTypeKindByPrimitiveModelName(
            scalarType.kind,
            scalarType.kind,
            undefined // To-DO: encode not compatible
        ),
        IsNullable: scalarType.nullable
    };
}

function fromIntrinsicType(scalarType: SdkType): InputIntrinsicType {
    const name = (scalarType.__raw! as IntrinsicType).name;
    return {
        Kind: InputTypeKind.Intrinsic,
        Name: getCSharpInputTypeKindByIntrinsic(
            scalarType.__raw! as IntrinsicType
        ),
        IsNullable: false
    };
}

export function fromUnionType(
    union: SdkUnionType,
    context: SdkContext,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
): InputUnionType | InputType {
    let itemTypes: InputType[] = [];
    for (const value of union.values) {
        const inputType = fromSdkType(value, context, models, enums);
        itemTypes.push(inputType);
    }

    return itemTypes.length > 1
        ? {
              Kind: InputTypeKind.Union,
              Name: InputTypeKind.Union,
              UnionItemTypes: itemTypes,
              IsNullable: false
          }
        : itemTypes[0];
}

function fromSdkConstantType(
    constantType: SdkConstantType,
    enums: Map<string, InputEnumType>,
    literalTypeContext?: LiteralTypeContext
): InputLiteralType {
    return {
        Kind: InputTypeKind.Literal,
        Name: InputTypeKind.Literal,
        LiteralValueType:
            constantType.valueType.kind === "boolean" ||
            literalTypeContext === undefined
                ? fromSdkBuiltInType(constantType.valueType)
                : convertConstantToEnum(
                      constantType,
                      enums,
                      literalTypeContext
                  ),
        Value: constantType.value,
        IsNullable: false
    };

    function convertConstantToEnum(
        constantType: SdkConstantType,
        enums: Map<string, InputEnumType>,
        literalTypeContext: LiteralTypeContext
    ) {
        // otherwise we need to wrap this into an extensible enum
        // we use the model name followed by the property name as the enum name to ensure it is unique
        const enumName = `${literalTypeContext.ModelName}_${literalTypeContext.PropertyName}`;
        const enumValueType =
            constantType.valueType.kind === "string"
                ? InputPrimitiveTypeKind.String
                : InputPrimitiveTypeKind.Float32;
        const enumValueName =
            constantType.value === null
                ? "Null"
                : constantType.value.toString();
        const allowValues: InputEnumTypeValue[] = [
            {
                Name: enumValueName,
                Value: constantType.value,
                Description: enumValueName
            }
        ];
        const enumType: InputEnumType = {
            Kind: InputTypeKind.Enum,
            Name: enumName,
            EnumValueType: enumValueType, //EnumValueType and  AllowedValues should be the first field after id and name, so that it can be corrected serialized.
            AllowedValues: allowValues,
            Namespace: literalTypeContext.Namespace,
            Accessibility: undefined,
            Deprecated: undefined,
            Description: `The ${enumName}`, // TODO -- what should we put here?
            IsExtensible: true,
            IsNullable: false,
            Usage: "None" // will be updated later
        };
        enums.set(enumName, enumType);
        return enumType;
    }
}

function fromSdkEnumValueType(
    enumValueType: SdkEnumValueType
): InputEnumTypeValue {
    return {
        Name: enumValueType.name,
        Value: enumValueType.value,
        Description: enumValueType.description
    };
}

function fromSdkDictionaryType(
    dictionaryType: SdkDictionaryType,
    context: SdkContext,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
): InputDictionaryType {
    return {
        Kind: InputTypeKind.Dictionary,
        Name: InputTypeKind.Dictionary,
        KeyType: fromSdkType(dictionaryType.keyType, context, models, enums),
        ValueType: fromSdkType(
            dictionaryType.valueType,
            context,
            models,
            enums
        ),
        IsNullable: dictionaryType.nullable
    };
}

export function fromSdkArrayType(
    arrayType: SdkArrayType,
    context: SdkContext,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
): InputListType {
    return {
        Kind: InputTypeKind.Array,
        Name: InputTypeKind.Array,
        ElementType: fromSdkType(arrayType.valueType, context, models, enums),
        IsNullable: arrayType.nullable
    };
}

export function fromUsageFlags(usage: UsageFlags): Usage {
    if (usage === UsageFlags.Input) return Usage.Input;
    else if (usage === UsageFlags.Output) return Usage.Output;
    else if (usage === (UsageFlags.Input | UsageFlags.Output))
        return Usage.RoundTrip;
    else return Usage.None;
}

function fromSdkModelPropertyType(
    propertyType: SdkModelPropertyType,
    context: SdkContext,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>,
    literalTypeContext: LiteralTypeContext
): InputModelProperty {
    const serializedName =
        propertyType.kind === "property"
            ? (propertyType as SdkBodyModelPropertyType).serializedName
            : "";
    literalTypeContext.PropertyName = serializedName;

    const isRequired =
        propertyType.kind === "path" || propertyType.kind === "body"
            ? true
            : !propertyType.optional; // TO-DO: SdkBodyParameter lacks of optional
    const isReadOnly =
        propertyType.kind === "property" &&
        propertyType.visibility?.includes(Visibility.Read)
            ? true
            : false;
    const isDiscriminator =
        propertyType.kind === "property" && propertyType.discriminator
            ? true
            : false;
    const modelProperty: InputModelProperty = {
        Name: propertyType.nameInClient,
        SerializedName: serializedName,
        Description:
            propertyType.description ??
            (isDiscriminator ? "Discriminator" : ""),
        Type: fromSdkType(
            propertyType.type,
            context,
            models,
            enums,
            literalTypeContext
        ),
        IsRequired: isRequired,
        IsReadOnly: isReadOnly,
        IsDiscriminator: isDiscriminator
    };

    return modelProperty;
}

function isSdkBuiltInType(kind: string): boolean {
    return [
        "bytes",
        "boolean",
        "date",
        "time",
        "any",
        "int32",
        "int64",
        "float32",
        "float64",
        "decimal",
        "decimal128",
        "string",
        "guid",
        "url",
        "uuid",
        "password",
        "armId",
        "ipAddress",
        "azureLocation",
        "etag"
    ].includes(kind);
}

function getCSharpInputTypeKindByIntrinsic(
    type: IntrinsicType
): InputIntrinsicTypeKind {
    switch (type.name) {
        case "ErrorType":
            return InputIntrinsicTypeKind.Error;
        case "void":
            return InputIntrinsicTypeKind.Void;
        case "never":
            return InputIntrinsicTypeKind.Never;
        case "unknown":
            return InputIntrinsicTypeKind.Unknown;
        case "null":
            return InputIntrinsicTypeKind.Null;
        default:
            throw new Error(`Unsupported intrinsic type name '${type.name}'`);
    }
}
