// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// Copyright (c) 2019-2022 Lorenzo Delana
// Licensed under the MIT License. See License.txt in the project root for license information.

// NOTE: code copied and changed from https://github.com/devel0/json-serialize-refs/blob/22e6ef737d57f9fe6c809181022b43be34bf65ef/src/lib/stringify-refs.ts because it has not been maintained for quite a long time for security concerns

function createRefs(obj: any): any {
    const map = new Map<object, string>();

    return doCreateRefs(obj, map);
}

function doCreateRefs(obj: any, refMap: Map<object, string>): any {
    if (typeof obj !== "object" || obj === null) {
        // this is primitive type
        return obj;
    }

    // set the id of the current object
    const id = refMap.size.toString();
    if (Array.isArray(obj)) {
        // this is an array
        const results: any[] = [];
        for (const v of obj) {
            const ref = refMap.get(v);
            if (ref) {
                results.push({
                    $ref: ref
                });
            } else {
                results.push(doCreateRefs(v, refMap));
            }
        }

        return results;
    } else {
        // this is an object
        refMap.set(obj, id);

        const result: any = { $id: id };
        for (const property in obj) {
            const v = obj[property];
            const ref = refMap.get(v);
            if (ref) {
                result[property] = {
                    $ref: ref
                };
            } else {
                result[property] = doCreateRefs(v, refMap);
            }
        }

        return result;
    }
}

/**
 * Convert the json into string with refs
 * @param obj
 * @param replacer
 * @param space
 * @returns
 */
export function stringifyRefs(
    obj: any,
    replacer?: (this: any, key: string, value: any) => any,
    space?: string | number
) {
    return JSON.stringify(createRefs(obj), replacer, space);
}
