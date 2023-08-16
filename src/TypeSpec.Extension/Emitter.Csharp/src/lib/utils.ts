import { Model, getFriendlyName, getProjectedNames } from "@typespec/compiler";
import {
    projectedNameCSharpKey,
    projectedNameClientKey
} from "../constants.js";
import { SdkContext } from "@azure-tools/typespec-client-generator-core";

export function capitalize(str: string): string {
    return str.charAt(0).toUpperCase() + str.slice(1);
}

export function getNameForTemplate(model: Model): string {
    if (model.templateMapper && model.templateMapper.args) {
        return (
            model.name +
            model.templateMapper.args.map((it) => (it as Model).name).join("")
        );
    }

    return model.name;
}

export function getModelName(context: SdkContext, m: Model): string {
    const projectedNamesMap = getProjectedNames(context.program, m);
    const name =
        projectedNamesMap?.get(projectedNameCSharpKey) ??
        projectedNamesMap?.get(projectedNameClientKey) ??
        getFriendlyName(context.program, m) ??
        getNameForTemplate(m);

    return name;
}
