import { EmitContext, JSONSchemaType } from "@typespec/compiler";
import {
    NetEmitterOptions,
    NetEmitterOptionsSchema,
    defaultOptions,
    resolveOptions
} from "@typespec/http-client-csharp";
import { dllFilePath } from "@autorest/csharp";

export interface AzureNetEmitterOptions extends NetEmitterOptions {
    csharpGeneratorPath?: string;
    "enable-internal-raw-data"?: boolean;
    "single-top-level-client"?: boolean;
    "existing-project-folder"?: string;
    "keep-non-overloadable-protocol-signature"?: boolean;
    "models-to-treat-empty-string-as-null"?: string[];
    "additional-intrinsic-types-to-treat-empty-string-as-null"?: string[];
    "methods-to-keep-client-default-value"?: string[];
    "deserialize-null-collection-as-null-value"?: boolean;
    "package-dir"?: string;
    "head-as-boolean"?: boolean;
    flavor?: string;
    "generate-sample-project"?: boolean;
    "generate-test-project"?: boolean;
    "use-model-reader-writer"?: boolean;
}

export const AzureNetEmitterOptionsSchema: JSONSchemaType<AzureNetEmitterOptions> =
    {
        type: "object",
        additionalProperties: false,
        properties: {
            ...NetEmitterOptionsSchema.properties,
            csharpGeneratorPath: {
                type: "string",
                default: dllFilePath,
                nullable: true
            },
            "enable-internal-raw-data": {
                type: "boolean",
                default: false
            },
            "single-top-level-client": { type: "boolean", nullable: true },
            "existing-project-folder": { type: "string", nullable: true },
            "keep-non-overloadable-protocol-signature": {
                type: "boolean",
                nullable: true
            },
            "models-to-treat-empty-string-as-null": {
                type: "array",
                nullable: true,
                items: { type: "string" }
            },
            "additional-intrinsic-types-to-treat-empty-string-as-null": {
                type: "array",
                nullable: true,
                items: { type: "string" }
            },
            "methods-to-keep-client-default-value": {
                type: "array",
                nullable: true,
                items: { type: "string" }
            },
            "deserialize-null-collection-as-null-value": {
                type: "boolean",
                nullable: true
            },
            "package-dir": { type: "string", nullable: true },
            "head-as-boolean": { type: "boolean", nullable: true },
            flavor: { type: "string", nullable: true },
            "generate-sample-project": {
                type: "boolean",
                nullable: true,
                default: true
            },
            "generate-test-project": {
                type: "boolean",
                nullable: true,
                default: false
            },
            "use-model-reader-writer": { type: "boolean", nullable: true }
        },
        required: []
    };

const defaultAzureEmitterOptions = {
    ...defaultOptions,
    csharpGeneratorPath: dllFilePath,
    "enable-internal-raw-data": undefined,
    "models-to-treat-empty-string-as-null": undefined,
    "additional-intrinsic-types-to-treat-empty-string-as-null": [],
    "methods-to-keep-client-default-value": undefined,
    "deserialize-null-collection-as-null-value": undefined,
    flavor: undefined,
    "generate-test-project": false,
    "existing-project-folder": undefined
};

export function resolveAzureEmitterOptions(
    context: EmitContext<AzureNetEmitterOptions>
) {
    return {
        ...resolveOptions(context),
        csharpGeneratorPath:
            context.options.csharpGeneratorPath ??
            defaultAzureEmitterOptions.csharpGeneratorPath,
        "enable-internal-raw-data":
            context.options["enable-internal-raw-data"] ??
            defaultAzureEmitterOptions["enable-internal-raw-data"],
        "models-to-treat-empty-string-as-null":
            context.options["models-to-treat-empty-string-as-null"] ??
            defaultAzureEmitterOptions["models-to-treat-empty-string-as-null"],
        "additional-intrinsic-types-to-treat-empty-string-as-null":
            context.options[
                "additional-intrinsic-types-to-treat-empty-string-as-null"
            ] ??
            defaultAzureEmitterOptions[
                "additional-intrinsic-types-to-treat-empty-string-as-null"
            ],
        "methods-to-keep-client-default-value":
            context.options["methods-to-keep-client-default-value"] ??
            defaultAzureEmitterOptions["methods-to-keep-client-default-value"],
        "deserialize-null-collection-as-null-value":
            context.options["deserialize-null-collection-as-null-value"] ??
            defaultAzureEmitterOptions[
                "deserialize-null-collection-as-null-value"
            ],
        flavor: context.options.flavor ?? defaultAzureEmitterOptions.flavor,
        "existing-project-folder":
            context.options["existing-project-folder"] ??
            defaultAzureEmitterOptions["existing-project-folder"]
    };
}
