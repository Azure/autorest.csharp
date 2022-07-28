// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { Program, Type } from "@cadl-lang/compiler";
import { ExternalDocs } from "../type/ExternalDocs.js";

const externalDocsKey = Symbol("externalDocs");
export function getExternalDocs(
    program: Program,
    entity: Type
): ExternalDocs | undefined {
    return program.stateMap(externalDocsKey).get(entity);
}
