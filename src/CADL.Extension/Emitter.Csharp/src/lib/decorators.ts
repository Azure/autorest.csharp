// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { DecoratedType, Operation, Program, Type } from "@cadl-lang/compiler";
import { ExternalDocs } from "../type/externalDocs.js";

const externalDocsKey = Symbol("externalDocs");
export function getExternalDocs(
    program: Program,
    entity: Type
): ExternalDocs | undefined {
    return program.stateMap(externalDocsKey).get(entity);
}

const operationIdsKey = Symbol("operationIds");
/**
 * @returns operationId set via the @operationId decorator or `undefined`
 */
export function getOperationId(
    program: Program,
    entity: Operation
): string | undefined {
    return program.stateMap(operationIdsKey).get(entity);
}

export function hasDecorator(type: DecoratedType, name: string): boolean {
    return (
        type.decorators.find((it) => it.decorator.name === name) !== undefined
    );
}
