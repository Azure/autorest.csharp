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
import { SdkContext } from "@azure-tools/typespec-client-generator-core";

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

const anonCounter = (function () {
    let count = 0; // Private counter variable

    return {
        increment: function () {
            return ++count;
        },
        getCount: function () {
            return count;
        }
    };
})();

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
            anonCounter.increment();
            return `Anon_${anonCounter.getCount()}`;
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
