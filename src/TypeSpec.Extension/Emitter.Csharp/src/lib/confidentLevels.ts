// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
    InputDictionaryType,
    InputListType,
    InputModelType,
    InputType,
    isInputDictionaryType,
    isInputListType,
    isInputModelType
} from "../type/inputType.js";

/**
 * The function calculates if the type passing in is confident or not.
 * @param type the type to calculate confident level
 * @param visitedModels a cache for visited models, to avoid infinite loop in those cases that a model contains direct or indirect reference to itself
 * @returns true if the type is confident, otherwise false
 */
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
    // check if the type is visited before, if so, there are two cases:
    // 1. it already has a value, true or false, we return that.
    // 2. it is being calculated right now, which means its value now is null (undefined is prohibited by the definition of the interface)
    //    in this case we return true to skip the calculation, because the calculation of `IsConfident` is trying to find if there is a false (we are using && to do that)
    if (visitedModels.has(type)) return type.IsConfident ?? true;
    visitedModels.add(type);

    if (type.IsConfident !== null) return type.IsConfident;

    const isBaseConfident = type.BaseModel
        ? getModelConfident(type.BaseModel, visitedModels)
        : true;

    if (!isBaseConfident) return false;

    let isModelConfident: boolean = isBaseConfident;
    for (const prop of type.Properties) {
        isModelConfident &&= getConfident(prop.Type, visitedModels);
        if (!isModelConfident) break; // if one of the property is not confident, we could stop here and return false which means the model is not confident
    }

    return isModelConfident;
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
