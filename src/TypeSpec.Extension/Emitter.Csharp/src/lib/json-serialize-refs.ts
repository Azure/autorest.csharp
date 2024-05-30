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
