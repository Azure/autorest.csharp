// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Model, Type } from "@cadl-lang/compiler";
import { hasDecorator } from "./decorators.js";

export function getTemplateModelName(model: Model): string | undefined {
    const pagingModelName = getPagingModelName(model);
    if (pagingModelName !== undefined) {
        return pagingModelName;
    }

    // TO-DO: Handle names from other templates
    return undefined;
}

/**
 * Pagination model should have name {ResourceType}ListResult
 */
export function isPagingModel(type: Type) : boolean {
    return type.kind === "Model" && hasDecorator(type, "$pagedResult");
}

export function getPagingModelName(model: Model) : string | undefined {
    if (isPagingModel(model)) {
        if (!model.templateArguments || model.templateArguments[0].kind !== "Model") {
            throw "Paging model should have a containing model resource";
        }
        
        return `${model.templateArguments[0].name}ListResult`;
    }

    return undefined;
}