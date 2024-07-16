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
            }
        },
        required: []
    };

const defaultAzureEmitterOptions = {
    ...defaultOptions,
    csharpGeneratorPath: dllFilePath
};

export function resolveAzureEmitterOptions(
    context: EmitContext<AzureNetEmitterOptions>
) {
    return {
        ...resolveOptions(context),
        csharpGeneratorPath:
            context.options.csharpGeneratorPath ??
            defaultAzureEmitterOptions.csharpGeneratorPath
    };
}
