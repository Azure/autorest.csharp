import { IntrinsicType, Program, UsageFlags, getDeprecated, getDiscriminator } from "@typespec/compiler";
import { Usage } from "./usage.js";
import { SdkType, SdkModelPropertyType, SdkBodyModelPropertyType, SdkModelType, SdkEnumType, SdkEnumValueType, SdkDictionaryType, SdkConstantType, SdkBuiltInType } from "@azure-tools/typespec-client-generator-core";
import { InputDictionaryType, InputEnumType, InputListType, InputLiteralType, InputModelType, InputNullType, InputPrimitiveType, InputType, InputUnknownType } from "./inputType.js";
import { InputModelProperty } from "./inputModelProperty.js";
import { Visibility } from "@typespec/http";
import { InputEnumTypeValue } from "./inputEnumTypeValue.js";
import { LiteralTypeContext } from "./literalTypeContext.js";

export function fromSdkType(sdkType: SdkType, program: Program, models: Map<string, InputModelType>, enums: Map<string, InputEnumType>): InputType {
    if (sdkType.kind === "model") return fromSdkModelType(sdkType, program, models, enums);
    if (sdkType.kind === "enum") return fromSdkEnumType(sdkType, program, enums);
    if (sdkType.kind === "dict") return fromSdkDictionaryType(sdkType, program, models, enums);
    if (sdkType.kind === "array") return fromSdkArrayType(sdkType, program, models, enums);
    return {} as InputType;
}

export function fromSdkModelType(modelType: SdkModelType, program: Program, models: Map<string, InputModelType>, enums: Map<string, InputEnumType>): InputModelType {
    let inputModelType = models.get(modelType.name);
    if (!inputModelType) {
        inputModelType = {
            Name: modelType.name,
            Namespace: "", // TO-DO: check if we need this for model
            Accessibility: modelType.access,
            Deprecated: getDeprecated(program, modelType.__raw), // TO-DO: SdkModelType lacks of deprecated
            Description: modelType.description,
            IsNullable: modelType.nullable,
            DiscriminatorPropertyName: getDiscriminator(program, modelType.__raw)?.propertyName, // TO-DO: SdkModelType lacks of DiscriminatorPropertyName
            DiscriminatorValue: modelType.discriminatorValue,
            BaseModel: modelType.baseModel,
            Usage: fromUsageFlags(modelType.usage)
        } as InputModelType;

        models.set(modelType.name, inputModelType);
        inputModelType.Properties = modelType.properties.map(p => fromSdkModelPropertyType(p, program, models, enums));
        if (modelType.discriminatedSubtypes) {
            inputModelType.DerivedModels = Object.values(modelType.discriminatedSubtypes).map(m => fromSdkModelType(m, program, models, enums));
        }
    }

    return inputModelType;
}

export function fromSdkEnumType(enumType: SdkEnumType, program: Program, enums: Map<string, InputEnumType>, addToCollection: boolean = true): InputEnumType {
    let inputEnumType = enums.get(enumType.name);
    if (!inputEnumType) {
        const enumValueType = enumType.valueType.kind === "float32" ? "Float32" : "String";
        inputEnumType = {
            Name: enumType.name,
            Accessibility: enumType.access,
            Deprecated: getDeprecated(program, enumType.__raw), // TO-DO: SdkEnumType lacks of deprecated
            Description: enumType.description,
            EnumValueType: enumValueType,
            AllowedValues: enumType.values.map(v => fromSdkEnumValueType(v)),
            IsExtensible: enumType.isFixed ? false : true,
            Usage: fromUsageFlags(enumType.usage)
        } as InputEnumType;
        if (addToCollection) enums.set(enumType.name, inputEnumType);
    }
    return inputEnumType;
}

export function fromSdkBuiltInType(builtInType: SdkBuiltInType): InputType {
    if (builtInType.kind === "any") { // TO-DO: intrinsic type will return kind "any"?
        switch ((builtInType.__raw as IntrinsicType).name) {
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
                throw new Error(`Unsupported type ${(builtInType.__raw as IntrinsicType).name}`);
        }
    }
}

export function fromSdkConstantType(constantType: SdkConstantType, literalContext?: LiteralTypeContext): InputLiteralType {
    return {
        Name: "Literal",
        LiteralValueType: constantType.valueType
    } as InputLiteralType;
}

export function fromSdkEnumValueType(enumValueType: SdkEnumValueType): InputEnumTypeValue {
    return {
        Name: enumValueType.name,
        Value: enumValueType.value,
        Description: enumValueType.description
    } as InputEnumTypeValue;
}

export function fromSdkDictionaryType(dictionaryType: SdkDictionaryType, program: Program, models: Map<string, InputModelType>, enums: Map<string, InputEnumType>) : InputDictionaryType {
    return {
        Name: "Dictionary",
        KeyType: fromSdkType(dictionaryType.keyType, program, models, enums),
        ValueType: fromSdkType(dictionaryType.valueType, program, models, enums)
    } as InputDictionaryType;
}

export function fromSdkArrayType(arrayType: SdkType, program: Program, models: Map<string, InputModelType>, enums: Map<string, InputEnumType>) : InputListType {
    return {
        Name: "Array",
        ElementType: fromSdkType(arrayType, program, models, enums)
    } as InputListType;
}

export function fromUsageFlags(usage: UsageFlags): Usage | undefined {
    if (usage === UsageFlags.Input) return Usage.Input;
    else if (usage === UsageFlags.Output) return Usage.Output;
    else if (usage === (UsageFlags.Input | UsageFlags.Output)) return Usage.RoundTrip;
    return undefined;
}

export function fromSdkModelPropertyType(propertyType: SdkModelPropertyType, program: Program, models: Map<string, InputModelType>, enums: Map<string, InputEnumType>): InputModelProperty {
    const serializedName = propertyType.kind === "property" ? (propertyType as SdkBodyModelPropertyType).serializedName : "";
    const isRequired = propertyType.kind === "path" || propertyType.kind === "body"? true : !propertyType.optional; // TO-DO: SdkBodyParameter lacks of optional
    const isReadOnly = propertyType.kind === "property" && propertyType.visibility?.includes(Visibility.Read) ? true : false;
    const isDiscriminator = propertyType.kind === "property" && propertyType.discriminator ? true : false;
    return {
        Name: propertyType.nameInClient,
        SerializedName: serializedName,
        Description: propertyType.description,
        Type: fromSdkType(propertyType.type, program, models, enums),
        IsRequired: isRequired,
        IsReadOnly: isReadOnly,
        IsDiscriminator: isDiscriminator
    } as InputModelProperty;
}