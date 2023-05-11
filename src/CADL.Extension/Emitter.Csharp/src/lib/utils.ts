import { Model } from "@typespec/compiler";

export function capitalize(str: string): string {
    return str.charAt(0).toUpperCase() + str.slice(1);
}

export function getNameForTemplate(model: Model): string {
    if (model.templateMapper && model.templateMapper.args) {
        return model.name + model.templateMapper.args.map(it => (it as Model).name).join("");
    }
    
    return model.name;
}