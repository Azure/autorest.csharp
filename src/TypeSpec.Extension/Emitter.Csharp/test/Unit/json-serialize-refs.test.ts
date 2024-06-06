import { strictEqual } from "assert";
import { stringifyRefs } from "../../src/lib/json-serialize-refs.js";
import { describe, it } from "vitest";

describe("json serialize refs", () => {
    it("normal object without cyclic reference", async () => {
        const obj = {
            a: 1,
            b: "2",
            c: {
                d: 3,
                e: "4"
            }
        };
        const result = stringifyRefs(obj);
        const expected = {
            $id: "0",
            a: 1,
            b: "2",
            c: {
                $id: "1",
                d: 3,
                e: "4"
            }
        };
        strictEqual(result, JSON.stringify(expected));
    });

    it("object with arrays", async () => {
        const obj: any = {
            a: 1,
            b: "2",
            c: {
                d: 3,
                e: "4"
            }
        };

        const item = {
            f: 5,
            g: "6"
        };
        obj.z = [item, item];
        const result = stringifyRefs(obj);
        const expected = {
            $id: "0",
            a: 1,
            b: "2",
            c: {
                $id: "1",
                d: 3,
                e: "4"
            },
            z: [
                {
                    $id: "2",
                    f: 5,
                    g: "6"
                },
                {
                    $ref: "2"
                }
            ]
        };
        strictEqual(result, JSON.stringify(expected));
    });

    it("object with cyclic reference", async () => {
        const nested: any = {
            b: 1
        };

        nested.a = nested;

        const result = stringifyRefs(nested);
        const expected = {
            $id: "0",
            b: 1,
            a: {
                $ref: "0"
            }
        };
        strictEqual(result, JSON.stringify(expected));
    });
});
