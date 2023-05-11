import { Model } from "@typespec/compiler";

export function capitalize(str: string): string {
    return str.charAt(0).toUpperCase() + str.slice(1);
}

export function templateRename(model: Model): string {
    if (model.name === "CustomPage") {
        const itemType = model.templateMapper?.args[0];
        if (itemType === undefined) {
            throw "Item type of a paged model should be Model";
        }

        const itemName = (itemType as Model).name;
        if (itemName == null) {
            throw "Item type of a paged model should have a name";
        }

        return `Paged${itemName}`;
    }

    return model.name;
}
