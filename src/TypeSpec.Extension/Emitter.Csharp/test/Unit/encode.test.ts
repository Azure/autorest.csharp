import { TestHost } from "@typespec/compiler/testing";
import assert, { deepStrictEqual } from "assert";
import isEqual from "lodash.isequal";
import {
    createEmitterContext,
    createEmitterTestHost,
    navigateModels,
    typeSpecCompile
} from "./utils/TestUtil.js";
import { createSdkContext } from "@azure-tools/typespec-client-generator-core";
import { getAllHttpServices } from "@typespec/http";
import { InputEnumType, InputModelType } from "../../src/type/inputType.js";
import { loadOperation } from "../../src/lib/operation.js";

describe("Test encode duration", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });

    it("encode iso8601 for duration query parameter ", async () => {
        const program = await typeSpecCompile(
            `
            op test(
                @query
                @encode(DurationKnownEncoding.ISO8601)
                input: duration
              ): NoContentResponse;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const [services] = getAllHttpServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        const operation = loadOperation(
            context,
            services[0].operations[0],
            "",
            [],
            services[0].namespace,
            modelMap,
            enumMap
        );
        assert(
            isEqual(
                {
                    Name: "duration",
                    Kind: "DurationISO8601",
                    IsNullable: false
                },
                operation.Parameters[0].Type
            )
        );
    });

    it("encode seconds-int32 for duration query parameter ", async () => {
        const program = await typeSpecCompile(
            `
            op test(
                @query
                @encode(DurationKnownEncoding.seconds, int32)
                input: duration
              ): NoContentResponse;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const [services] = getAllHttpServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        const operation = loadOperation(
            context,
            services[0].operations[0],
            "",
            [],
            services[0].namespace,
            modelMap,
            enumMap
        );
        assert(
            isEqual(
                {
                    Name: "duration",
                    Kind: "DurationSeconds",
                    IsNullable: false
                },
                operation.Parameters[0].Type
            )
        );
    });

    it("encode seconds-float for duration query parameter ", async () => {
        const program = await typeSpecCompile(
            `
            op test(
                @query
                @encode(DurationKnownEncoding.seconds, float)
                input: duration
              ): NoContentResponse;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const [services] = getAllHttpServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        const operation = loadOperation(
            context,
            services[0].operations[0],
            "",
            [],
            services[0].namespace,
            modelMap,
            enumMap
        );
        assert(
            isEqual(
                {
                    Name: "duration",
                    Kind: "DurationSecondsFloat",
                    IsNullable: false
                },
                operation.Parameters[0].Type
            )
        );
    });

    it("encode iso8601 on duration model property", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            model ISO8601DurationProperty {
                @encode(DurationKnownEncoding.ISO8601)
                value: duration;
            }
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context, "csharp");
        const [services] = getAllHttpServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        navigateModels(sdkContext, services[0].namespace, modelMap, enumMap);
        const durationProperty = modelMap.get("ISO8601DurationProperty");
        assert(durationProperty !== undefined);
        assert(
            isEqual(
                {
                    Name: "duration",
                    Kind: "DurationISO8601",
                    IsNullable: false
                },
                durationProperty.Properties[0].Type
            )
        );
    });

    it("encode iso8601 on duration model property", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            model ISO8601DurationProperty {
                @encode(DurationKnownEncoding.ISO8601)
                value: duration;
            }
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context, "csharp");
        const [services] = getAllHttpServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        navigateModels(sdkContext, services[0].namespace, modelMap, enumMap);
        const durationProperty = modelMap.get("ISO8601DurationProperty");
        assert(durationProperty !== undefined);
        assert(
            isEqual(
                {
                    Name: "duration",
                    Kind: "DurationISO8601",
                    IsNullable: false
                },
                durationProperty.Properties[0].Type
            )
        );
    });

    it("encode seconds-int32 on duration model property", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            model Int32SecondsDurationProperty {
                @encode(DurationKnownEncoding.seconds, int32)
                value: duration;
            }
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context, "csharp");
        const [services] = getAllHttpServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        navigateModels(sdkContext, services[0].namespace, modelMap, enumMap);
        const durationProperty = modelMap.get("Int32SecondsDurationProperty");
        assert(durationProperty !== undefined);
        assert(
            isEqual(
                {
                    Name: "duration",
                    Kind: "DurationSeconds",
                    IsNullable: false
                },
                durationProperty.Properties[0].Type
            )
        );
    });

    it("encode seconds-int32 on duration model property", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            model FloatSecondsDurationProperty {
                @encode(DurationKnownEncoding.seconds, float)
                value: duration;
            }
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context, "csharp");
        const [services] = getAllHttpServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        navigateModels(sdkContext, services[0].namespace, modelMap, enumMap);
        const durationProperty = modelMap.get("FloatSecondsDurationProperty");
        assert(durationProperty !== undefined);
        assert(
            isEqual(
                {
                    Name: "duration",
                    Kind: "DurationSecondsFloat",
                    IsNullable: false
                },
                durationProperty.Properties[0].Type
            )
        );
    });
});
