import { TestHost } from "@cadl-lang/compiler/testing";
import assert, { AssertionError, deepStrictEqual } from "assert";
import { InputEnumType, InputModelType } from "../../src/type/InputType.js";
import { listServices } from "@cadl-lang/compiler";
import {
    cadlCompile,
    createEmitterContext,
    createEmitterTestHost
} from "./utils/TestUtil.js";
import { navigateModels } from "../../src/lib/model.js";

describe("Test navigateModels", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });

    it("only one unrefernced model", async () => {
        const program = await cadlCompile(
            `
        model unreferenceModel {
            @doc("The name of Model.")
            name: string;
        }
      `,
            runner
        );
        runner.compileAndDiagnose;
        const services = listServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        navigateModels(program, services[0].type, modelMap, enumMap);
        assert(modelMap.size === 1);
        assert(modelMap.has("unreferenceModel"));
    });

    it("only one unreferenced model and one referenced model", async () => {
        const program = await cadlCompile(
            `
        model unreferenceModel {
            @doc("The name of Model.")
            name: string;
        }

        model referenceModel {
            @doc("The id of Model.")
            id: string;
        }

        op test(@body input: referenceModel): void;
      `,
            runner
        );
        runner.compileAndDiagnose;
        const services = listServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        navigateModels(program, services[0].type, modelMap, enumMap);
        assert(modelMap.size === 2);
        assert(modelMap.has("unreferenceModel"));
        assert(modelMap.has("referenceModel"));
    });

    it("only one unrefernced enum", async () => {
        const program = await cadlCompile(
            `
        enum unreferenceEnum {
            "one",
            "two",
        }
      `,
            runner
        );
        runner.compileAndDiagnose;
        const services = listServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        navigateModels(program, services[0].type, modelMap, enumMap);
        assert(enumMap.size === 1);
        assert(enumMap.has("unreferenceEnum"));
    });
});
