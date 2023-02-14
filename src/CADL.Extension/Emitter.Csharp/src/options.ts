import { DpgEmitterOptions } from "@azure-tools/cadl-dpg";
import { EmitContext, JSONSchemaType, resolvePath } from "@cadl-lang/compiler";
import { dllFilePath } from "@autorest/csharp";

export type NetEmitterOptions = {
    outputFile?: string;
    logFile?: string;
    namespace?: string;
    "library-name"?: string;
    "single-top-level-client"?: boolean;
    skipSDKGeneration?: boolean;
    "unreferenced-types-handling"?:
        | "removeOrInternalize"
        | "internalize"
        | "keepAll";
    "new-project"?: boolean;
    csharpGeneratorPath?: string;
    "clear-output-folder"?: boolean;
    "save-inputs"?: boolean;
    "model-namespace"?: boolean;
} & DpgEmitterOptions;

export const NetEmitterOptionsSchema: JSONSchemaType<NetEmitterOptions> = {
    type: "object",
    additionalProperties: false,
    properties: {
        outputFile: { type: "string", nullable: true },
        logFile: { type: "string", nullable: true },
        namespace: { type: "string", nullable: true },
        "library-name": { type: "string", nullable: true },
        "single-top-level-client": { type: "boolean", nullable: true },
        skipSDKGeneration: { type: "boolean", default: false, nullable: true },
        "unreferenced-types-handling": {
            type: "string",
            enum: ["removeOrInternalize", "internalize", "keepAll"],
            nullable: true
        },
        "new-project": { type: "boolean", nullable: true },
        csharpGeneratorPath: {
            type: "string",
            default: dllFilePath,
            nullable: true
        },
        "clear-output-folder": { type: "boolean", nullable: true },
        "save-inputs": { type: "boolean", nullable: true },
        "model-namespace": { type: "boolean", nullable: true },
        "generate-protocol-methods": { type: "boolean", nullable: true },
        "generate-convenience-methods": { type: "boolean", nullable: true },
        "package-name": { type: "string", nullable: true }
    },
    required: []
};

const defaultOptions = {
    outputFile: "cadl.json",
    logFile: "log.json",
    skipSDKGeneration: false,
    "new-project": false,
    csharpGeneratorPath: dllFilePath,
    "clear-output-folder": false,
    "save-inputs": false,
    "generate-protocol-methods": true,
    "generate-convenience-methods": true,
    "package-name": undefined
};

export function resolveOptions(context: EmitContext<NetEmitterOptions>) {
    const emitterOptions = context.options;
    const emitterOutputDir = context.emitterOutputDir;
    const resolvedOptions = { ...defaultOptions, ...emitterOptions };
    const outputFolder = resolveOutputFolder(context);
    return {
        ...resolvedOptions,
        outputFile: resolvePath(outputFolder, resolvedOptions.outputFile),
        logFile: resolvePath(
            emitterOutputDir ?? "./cadl-output",
            resolvedOptions.logFile
        )
    };
}

export function resolveOutputFolder(
    context: EmitContext<NetEmitterOptions>
): string {
    return resolvePath(context.emitterOutputDir ?? "./cadl-output");
}
