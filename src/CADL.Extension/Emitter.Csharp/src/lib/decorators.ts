// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { OperationType, Program, Type } from "@cadl-lang/compiler";
import { ExternalDocs } from "../type/ExternalDocs.js";

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
    entity: OperationType
): string | undefined {
    return program.stateMap(operationIdsKey).get(entity);
}
