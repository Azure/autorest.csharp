import {
    SdkContext,
    getLibraryName
} from "@azure-tools/typespec-client-generator-core";
import { Model, getFriendlyName, getProjectedNames } from "@typespec/compiler";

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

export function getModelName(context: SdkContext, model: Model): string {
    // if the projectedName does not exist, we take friendlyName
    if (getProjectedNames(context.program, model) === undefined) {
        return (
            getFriendlyName(context.program, model) ?? getNameForTemplate(model)
        );
    }

    // otherwise we take the libraryName
    return getLibraryName(context, model);
}
