import {
    Model,
    Type,
    getFriendlyName,
    getProjectedNames
} from "@typespec/compiler";
import {
    projectedNameCSharpKey,
    projectedNameClientKey
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

export function getModelName(context: SdkContext, m: Model): string {
    const name =
        getProjectedNameForCsharp(context, m) ??
        getFriendlyName(context.program, m) ??
        getNameForTemplate(m);

    if (name === "") {
        anonCounter.increment();
        return `Anon_${anonCounter.getCount()}`;
    }

    return name;
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
