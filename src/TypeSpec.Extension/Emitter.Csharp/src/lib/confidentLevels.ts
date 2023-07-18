import {
    InputDictionaryType,
    InputListType,
    InputModelType,
    InputType,
    isInputDictionaryType,
    isInputListType,
    isInputModelType
} from "../type/inputType.js";

export function getConfident(
    type: InputType,
    visitedModels: Set<InputModelType>
): boolean {
    if (isInputModelType(type)) {
        return getModelConfident(type, visitedModels);
    } else if (isInputListType(type)) {
        return getListConfident(type, visitedModels);
    } else if (isInputDictionaryType(type)) {
        return getDictionaryConfident(type, visitedModels);
    }

    return type.IsConfident ?? true; // by default they are confident
}

function getModelConfident(
    type: InputModelType,
    visitedModels: Set<InputModelType>
): boolean {
    if (visitedModels.has(type)) return true; // this means this has been calculated before or being calculated right now, return
    visitedModels.add(type);

    if (type.IsConfident !== null) return type.IsConfident;

    const isBaseLowConfident = type.BaseModel
        ? getModelConfident(type.BaseModel, visitedModels)
        : true;

    let isModelLowConfident = isBaseLowConfident;
    for (const prop of type.Properties) {
        isModelLowConfident &&= getConfident(prop.Type, visitedModels);
    }

    return isModelLowConfident;
}

function getListConfident(
    type: InputListType,
    visitedModels: Set<InputModelType>
): boolean {
    return getConfident(type.ElementType, visitedModels);
}

function getDictionaryConfident(
    type: InputDictionaryType,
    visitedModels: Set<InputModelType>
): boolean {
    return (
        getConfident(type.KeyType, visitedModels) &&
        getConfident(type.ValueType, visitedModels)
    );
}

// we use this method to get the confident level value of a type
// TODO -- in the future, we could consider if we could convert the InputType and all its derived types into a concrete type instead of interfaces, so that they could contain method and method override. If so, we no longer need to do this.
export function isConfident(type: InputType | undefined): boolean {
    if (type === undefined) return true; // if undefined, return true

    // only for list and dictionary, we redirect it to return its element or value's confident value
    if (isInputListType(type)) {
        return type.ElementType.IsConfident!;
    } else if (isInputDictionaryType(type)) {
        return type.KeyType.IsConfident! && type.ValueType.IsConfident!;
    }

    // for others, we could just return its own value
    return type.IsConfident!;
}
