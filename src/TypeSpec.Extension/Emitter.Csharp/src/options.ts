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
            }
        },
        required: []
    };

const defaultAzureEmitterOptions = {
    ...defaultOptions,
    csharpGeneratorPath: dllFilePath,
    "enable-internal-raw-data": undefined
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
            defaultAzureEmitterOptions["enable-internal-raw-data"]
    };
}
