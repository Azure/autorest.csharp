// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext, Program, resolvePath } from "@typespec/compiler";

import { execSync } from "child_process";
import fs, { existsSync } from "fs";
import path from "node:path";
import {
    Logger,
    configurationFileName,
    tspOutputFileName,
    createModel,
    writeCodeModel,
    CSharpEmitterContext
} from "@typespec/http-client-csharp";
import { createSdkContext } from "@azure-tools/typespec-client-generator-core";
import {
    AzureCSharpEmitterOptions,
    resolveAzureEmitterOptions
} from "./options.js";
import { azureSDKContextOptions } from "./sdk-context-options.js";

export async function $onEmit(context: EmitContext<AzureCSharpEmitterOptions>) {
    const program: Program = context.program;

    if (program.compilerOptions.noEmit || program.hasError()) return;

    const options = resolveAzureEmitterOptions(context);
    /* set the loglevel. */
    const logger = new Logger(program, options.logLevel);

    if (
        context.emitterOutputDir &&
        path.basename(context.emitterOutputDir) === "src"
    ) {
        context.emitterOutputDir = path.dirname(context.emitterOutputDir);
    }
    logger.info("Starting Microsoft Generator Csharp emitter.");
    const sdkContext = await createSdkContext(
        context,
        "@azure-tools/typespec-csharp",
        azureSDKContextOptions
    );
    const csharpEmitterContext: CSharpEmitterContext = {
        logger: logger,
        __typeCache: {
            crossLanguageDefinitionIds: new Map(),
            types: new Map(),
            models: new Map(),
            enums: new Map()
        },
        ...sdkContext
    };
    const root = createModel(csharpEmitterContext);

    const outputFolder = resolvePath(
        context.emitterOutputDir ?? "./tsp-output"
    );
    const isSrcFolder = path.basename(outputFolder) === "src";
    const generatedFolder = isSrcFolder
        ? resolvePath(outputFolder, "Generated")
        : resolvePath(outputFolder, "src", "Generated");
    if (root) {
        if (!fs.existsSync(generatedFolder)) {
            fs.mkdirSync(generatedFolder, { recursive: true });
        }

        // write the tspCodeModel.json file
        await writeCodeModel(csharpEmitterContext, root, outputFolder);

        //resolve shared folders based on generator path override
        const resolvedSharedFolders: string[] = [];
        const sharedFolders = [
            resolvePath(options.csharpGeneratorPath, "..", "Generator.Shared"),
            resolvePath(options.csharpGeneratorPath, "..", "Azure.Core.Shared")
        ];
        for (const sharedFolder of sharedFolders) {
            resolvedSharedFolders.push(
                path
                    .relative(generatedFolder, sharedFolder)
                    .replaceAll("\\", "/")
            );
        }

        const configurations: any = {};

        configurations["output-folder"] = ".";

        const namespace = options["namespace"] ?? root.Name;
        configurations["namespace"] = namespace;
        configurations["library-name"] = options["library-name"] ?? namespace;
        configurations["unreferenced-types-handling"] =
            options["unreferenced-types-handling"];
        configurations["disable-xml-docs"] =
            options["disable-xml-docs"] === false
                ? undefined
                : options["disable-xml-docs"];

        configurations["head-as-boolean"] = options["head-as-boolean"];
        configurations["deserialize-null-collection-as-null-value"] =
            options["deserialize-null-collection-as-null-value"];
        configurations["flavor"] =
            options["flavor"] ??
            (configurations.namespace.toLowerCase().startsWith("azure.")
                ? "azure"
                : undefined);

        //only emit these if they are not the default values
        configurations["generate-sample-project"] =
            options["generate-sample-project"] === true
                ? undefined
                : options["generate-sample-project"];

        configurations["generate-test-project"] =
            options["generate-test-project"] === false
                ? undefined
                : options["generate-test-project"];

        configurations["use-model-reader-writer"] =
            options["use-model-reader-writer"];

        configurations["single-top-level-client"] =
            options["single-top-level-client"];

        configurations["keep-non-overloadable-protocol-signature"] =
            options["keep-non-overloadable-protocol-signature"];

        configurations["models-to-treat-empty-string-as-null"] =
            options["models-to-treat-empty-string-as-null"];

        configurations["intrinsic-types-to-treat-empty-string-as-null"] =
            options["models-to-treat-empty-string-as-null"]
                ? options[
                      "additional-intrinsic-types-to-treat-empty-string-as-null"
                  ].concat(
                      [
                          "Uri",
                          "Guid",
                          "ResourceIdentifier",
                          "DateTimeOffset"
                      ].filter(
                          (item) =>
                              options[
                                  "additional-intrinsic-types-to-treat-empty-string-as-null"
                              ].indexOf(item) < 0
                      )
                  )
                : undefined;

        configurations["methods-to-keep-client-default-value"] =
            options["methods-to-keep-client-default-value"];
        configurations["shared-source-folders"] = resolvedSharedFolders ?? [];

        configurations["enable-internal-raw-data"] =
            options["enable-internal-raw-data"];
        configurations["model-namespace"] = options["model-namespace"];
        const examplesDir =
            options["examples-dir"] ?? options["examples-directory"];
        if (examplesDir) {
            configurations["examples-dir"] = path.relative(
                outputFolder,
                examplesDir
            );
        }
        /* TODO: when we support to emit decorator list https://github.com/Azure/autorest.csharp/issues/4887, we will update to use emitted decorator to identify if it is azure-arm */
        /* set azure-arm */

        configurations["azure-arm"] =
            sdkContext.arm === false ? undefined : sdkContext.arm;

        // Write the config file
        await program.host.writeFile(
            resolvePath(outputFolder, configurationFileName),
            prettierOutput(JSON.stringify(configurations, null, 2))
        );

        const csProjFile = resolvePath(
            isSrcFolder ? outputFolder : resolvePath(outputFolder, "src"),
            `${configurations["library-name"]}.csproj`
        );
        logger.info(`Checking if ${csProjFile} exists`);
        const newProjectOption =
            options["new-project"] || !existsSync(csProjFile)
                ? "--new-project"
                : "";
        const existingProjectOption = options["existing-project-folder"]
            ? `--existing-project-folder ${options["existing-project-folder"]}`
            : "";
        const debugFlag = (options.debug ?? false) ? " --debug" : "";

        const command = `dotnet --roll-forward Major ${resolvePath(
            options.csharpGeneratorPath
        )} --project-path ${outputFolder} ${newProjectOption} ${existingProjectOption} --clear-output-folder ${
            options["clear-output-folder"]
        }${debugFlag}`;
        logger.info(command);

        try {
            execSync(command, { stdio: "inherit" });
        } catch (error: any) {
            if (error.message) logger.info(error.message);
            if (error.stderr) logger.error(error.stderr);
            if (error.stdout) logger.verbose(error.stdout);
            throw error;
        }
        if (!options["save-inputs"]) {
            // delete
            deleteFile(resolvePath(outputFolder, tspOutputFileName), logger);
            deleteFile(
                resolvePath(outputFolder, configurationFileName),
                logger
            );
        }
    }
}

function deleteFile(filePath: string, logger: Logger) {
    fs.unlink(filePath, (err) => {
        if (err) {
            //logger.error(`stderr: ${err}`);
        } else {
            logger.info(`File ${filePath} is deleted.`);
        }
    });
}

function prettierOutput(output: string) {
    return output + "\n";
}
