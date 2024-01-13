import {
    Enum,
    EnumMember,
    Model,
    ModelProperty,
    Operation,
    Scalar,
    Type,
    getFriendlyName,
    getProjectedName,
    getProjectedNames
} from "@typespec/compiler";
import {
    projectedNameCSharpKey,
    projectedNameClientKey,
    projectedNameJsonKey
} from "../constants.js";
import {
    SdkContext,
    getSdkModel
} from "@azure-tools/typespec-client-generator-core";
import { InputParameter } from "../type/inputParameter.js";
import { InputPrimitiveType, InputType } from "../type/inputType.js";
import { InputTypeKind } from "../type/inputTypeKind.js";
import { RequestLocation } from "../type/requestLocation.js";
import { InputOperationParameterKind } from "../type/inputOperationParameterKind.js";
import { InputConstant } from "../type/inputConstant.js";

export function capitalize(str: string): string {
    return str.charAt(0).toUpperCase() + str.slice(1);
}

export function getNameForTemplate(model: Model): string {
    if (
        model.name !== "" &&
        model.templateMapper &&
        model.templateMapper.args
    ) {
        return (
            model.name +
            model.templateMapper.args.map((it) => (it as Model).name).join("")
        );
    }

    return model.name;
}

export function getProjectedNameForCsharp(
    context: SdkContext,
    type: Type
): string | undefined {
    const projectedNamesMap = getProjectedNames(context.program, type);
    return (
        projectedNamesMap?.get(projectedNameCSharpKey) ??
        projectedNamesMap?.get(projectedNameClientKey)
    );
}

export function getTypeName(
    context: SdkContext,
    type: Model | Enum | EnumMember | ModelProperty | Scalar | Operation
): string {
    var name =
        getProjectedNameForCsharp(context, type) ??
        getFriendlyName(context.program, type);
    if (name) return name;
    if (type.kind === "Model") {
        name = getNameForTemplate(type);
        if (name === "") {
            const sdkModel = getSdkModel(context, type as Model);
            return sdkModel.generatedName || sdkModel.name;
        }
        return name;
    }
    return type.name;
}

export function getSerializeName(
    context: SdkContext,
    type: ModelProperty
): string {
    return (
        getProjectedName(context.program, type, projectedNameJsonKey) ??
        type.name
    );
}

export function createContentTypeOrAcceptParameter(
    mediaTypes: string[],
    name: string,
    nameInRequest: string
): InputParameter {
    const isContentType: boolean =
        nameInRequest.toLowerCase() === "content-type";
    const inputType: InputType = {
        Name: "String",
        Kind: InputTypeKind.String,
        IsNullable: false
    } as InputPrimitiveType;
    return {
        Name: name,
        NameInRequest: nameInRequest,
        Type: inputType,
        Location: RequestLocation.Header,
        IsApiVersion: false,
        IsResourceParameter: false,
        IsContentType: isContentType,
        IsRequired: true,
        IsEndpoint: false,
        SkipUrlEncoding: false,
        Explode: false,
        Kind: InputOperationParameterKind.Constant,
        DefaultValue:
            mediaTypes.length === 1
                ? ({
                      Type: inputType,
                      Value: mediaTypes[0]
                  } as InputConstant)
                : undefined
    } as InputParameter;
}
