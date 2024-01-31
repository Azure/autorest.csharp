import {
    IntrinsicType,
    Program,
    UsageFlags,
    getDeprecated,
    getDiscriminator,
    Type,
    DateTimeKnownEncoding,
    Model,
    Enum
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
    SdkBuiltInKinds
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
    mapTypeSpecTypeToCSharpInputTypeKind
} from "../lib/model.js";
import { InputTypeKind } from "./inputTypeKind.js";
import { getFullNamespaceString } from "../lib/utils.js";
import { InputPrimitiveTypeKind } from "./inputPrimitiveTypeKind.js";
import { LiteralTypeContext } from "./literalTypeContext.js";
import { InputIntrinsicTypeKind } from "./inputIntrinsicTypeKind.js";

export function fromSdkType(
    sdkType: SdkType,
    program: Program,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>,
    literalTypeContext?: LiteralTypeContext
): InputType {
    if (sdkType.kind === "model")
        return fromSdkModelType(sdkType, program, models, enums);
    if (sdkType.kind === "enum")
        return fromSdkEnumType(sdkType, program, enums);
    if (sdkType.kind === "dict")
        return fromSdkDictionaryType(sdkType, program, models, enums);
    if (sdkType.kind === "array")
        return fromSdkArrayType(sdkType, program, models, enums);
    if (sdkType.kind === "constant")
        return fromSdkConstantType(sdkType, enums, literalTypeContext);
    if (sdkType.kind === "union")
        return fromUnionType(sdkType, program, models, enums);
    if (sdkType.kind === "datetime") return fromSdkDatetimeType(sdkType);
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
    program: Program,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
): InputModelType {
    const modelTypeName = modelType.generatedName || modelType.name;
    let inputModelType = models.get(modelTypeName);
    if (!inputModelType) {
        inputModelType = {
            Kind: InputTypeKind.Model,
            Name: modelTypeName,
            Namespace: getFullNamespaceString(
                (modelType.__raw as Model).namespace
            ),
            Accessibility: modelType.access,
            Deprecated: getDeprecated(program, modelType.__raw!), // TO-DO: SdkModelType lacks of deprecated
            Description: modelType.description,
            IsNullable: modelType.nullable,
            DiscriminatorPropertyName: getDiscriminator(
                program,
                modelType.__raw!
            )?.propertyName, // TO-DO: SdkModelType lacks of DiscriminatorPropertyName
            DiscriminatorValue: modelType.discriminatorValue,
            Usage: fromUsageFlags(modelType.usage),
            BaseModel: modelType.baseModel
                ? fromSdkModelType(modelType.baseModel, program, models, enums)
                : undefined,
        } as InputModelType;

        models.set(modelTypeName, inputModelType);

        // TODO: can we fix the resolving reference issue in csharp?
        // https://github.com/Azure/autorest.csharp/issues/4136
        // if (modelType.discriminatedSubtypes) {
        //     inputModelType.DerivedModels = Object.values(
        //         modelType.discriminatedSubtypes
        //     ).map((m) => fromSdkModelType(m, program, models, enums));
        // }

        inputModelType.Properties = modelType.properties
            .filter(
                (p) =>
                    !(p as SdkBodyModelPropertyType).discriminator ||
                    !modelType.baseModel
            )
            .map((p) =>
                fromSdkModelPropertyType(p, program, models, enums, {
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

export function fromSdkEnumType(
    enumType: SdkEnumType,
    program: Program,
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
            Namespace: getFullNamespaceString(
                (enumType.__raw! as Enum).namespace
            ),
            Accessibility: enumType.access,
            Deprecated: getDeprecated(program, enumType.__raw!), // TO-DO: SdkEnumType lacks of deprecated
            Description: enumType.description,
            EnumValueType: enumValueType,
            AllowedValues: enumType.values.map((v) => fromSdkEnumValueType(v)),
            IsExtensible: enumType.isFixed ? false : true,
            IsNullable: false,
            Usage: fromUsageFlags(enumType.usage) ?? Usage.None
        };
        if (addToCollection) enums.set(enumType.name, newInputEnumType);
        inputEnumType = newInputEnumType;
    }
    return inputEnumType;
}

export function fromSdkDatetimeType(
    datetimeType: SdkDatetimeType
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
        Name: fromDateTimeKnownEncoding(datetimeType.encode),
        IsNullable: false
    } as InputPrimitiveType;
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

export function fromScalarType(scalarType: SdkType): InputPrimitiveType {
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
        Name: getCSharpInputTypeKindByIntrinsic(scalarType.__raw! as IntrinsicType),
        IsNullable: false
    };
}

export function fromUnionType(
    union: SdkUnionType,
    program: Program,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
): InputUnionType | InputType {
    let itemTypes: InputType[] = [];
    for (const value of union.values) {
        const inputType = fromSdkType(value, program, models, enums);
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

export function fromSdkConstantType(
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

export function fromSdkEnumValueType(
    enumValueType: SdkEnumValueType
): InputEnumTypeValue {
    return {
        Name: enumValueType.name,
        Value: enumValueType.value,
        Description: enumValueType.description
    };
}

export function fromSdkDictionaryType(
    dictionaryType: SdkDictionaryType,
    program: Program,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
): InputDictionaryType {
    return {
        Kind: InputTypeKind.Dictionary,
        Name: InputTypeKind.Dictionary,
        KeyType: fromSdkType(dictionaryType.keyType, program, models, enums),
        ValueType: fromSdkType(
            dictionaryType.valueType,
            program,
            models,
            enums
        ),
        IsNullable: dictionaryType.nullable
    };
}

export function fromSdkArrayType(
    arrayType: SdkArrayType,
    program: Program,
    models: Map<string, InputModelType>,
    enums: Map<string, InputEnumType>
): InputListType {
    return {
        Kind: InputTypeKind.Array,
        Name: InputTypeKind.Array,
        ElementType: fromSdkType(arrayType.valueType, program, models, enums),
        IsNullable: arrayType.nullable
    };
}

export function fromUsageFlags(usage: UsageFlags): Usage | undefined {
    if (usage === UsageFlags.Input) return Usage.Input;
    else if (usage === UsageFlags.Output) return Usage.Output;
    else if (usage === (UsageFlags.Input | UsageFlags.Output))
        return Usage.RoundTrip;
    return undefined;
}

export function fromSdkModelPropertyType(
    propertyType: SdkModelPropertyType,
    program: Program,
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
        Description: propertyType.description ?? (isDiscriminator ? "Discriminator" : ""),
        Type: fromSdkType(
            propertyType.type,
            program,
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

function getCSharpInputTypeKindByIntrinsic(type: IntrinsicType): InputIntrinsicTypeKind {
    switch (type.name)
    {
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

