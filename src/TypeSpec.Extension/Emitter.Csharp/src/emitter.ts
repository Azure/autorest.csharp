// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext, Program, resolvePath } from "@typespec/compiler";

import { execSync } from "child_process";
import fs, { existsSync } from "fs";
import path from "node:path";
import {
    $onEmit as $OnMGCEmit,
    Logger,
    LoggerLevel,
    configurationFileName,
    resolveOutputFolder,
    tspOutputFileName,
    setSDKContextOptions
} from "@typespec/http-client-csharp";
import { createSdkContext } from "@azure-tools/typespec-client-generator-core";
import {
    AzureNetEmitterOptions,
    resolveAzureEmitterOptions
} from "./options.js";
import { azureSDKContextOptions } from "./sdk-context-options.js";

export async function $onEmit(context: EmitContext<AzureNetEmitterOptions>) {
    const program: Program = context.program;

    if (program.compilerOptions.noEmit || program.hasError()) return;

    const options = resolveAzureEmitterOptions(context);
    /* set the loglevel. */
    Logger.initialize(program, options.logLevel ?? LoggerLevel.INFO);

    context.options.skipSDKGeneration = true;
    if (
        context.emitterOutputDir &&
        path.basename(context.emitterOutputDir) === "src"
    ) {
        context.emitterOutputDir = path.dirname(context.emitterOutputDir);
    }
    Logger.getInstance().info("Starting Microsoft Generator Csharp emitter.");
    setSDKContextOptions(azureSDKContextOptions);
    await $OnMGCEmit(context);
    const outputFolder = resolveOutputFolder(context);
    const isSrcFolder = path.basename(outputFolder) === "src";
    const generatedFolder = isSrcFolder
        ? resolvePath(outputFolder, "Generated")
        : resolvePath(outputFolder, "src", "Generated");
    if (options.skipSDKGeneration !== true) {
        const configurationFilePath = resolvePath(
            outputFolder,
            configurationFileName
        );
        const configurations = JSON.parse(
            fs.readFileSync(configurationFilePath, "utf-8")
        );
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

        if ("head-as-boolean" in options) {
            configurations["head-as-boolean"] = options["head-as-boolean"];
        }

        configurations["deserialize-null-collection-as-null-value"] =
            options["deserialize-null-collection-as-null-value"];
        configurations["flavor"] =
            options["flavor"] ??
            (configurations.namespace.toLowerCase().startsWith("azure.")
                ? "azure"
                : undefined);

        //only emit these if they are not the default values
        if ("generate-sample-project" in options) {
            configurations["generate-sample-project"] =
                options["generate-sample-project"] === true
                    ? undefined
                    : options["generate-sample-project"];
        }

        if ("generate-test-project" in options) {
            configurations["generate-test-project"] =
                options["generate-test-project"] === false
                    ? undefined
                    : options["generate-test-project"];
        }

        configurations["use-model-reader-writer"] = true;

        if ("use-model-reader-writer" in options) {
            configurations["use-model-reader-writer"] =
                options["use-model-reader-writer"];
        }

        if ("single-top-level-client" in options) {
            configurations["single-top-level-client"] =
                options["single-top-level-client"];
        }

        if ("keep-non-overloadable-protocol-signature" in options) {
            configurations["keep-non-overloadable-protocol-signature"] =
                options["keep-non-overloadable-protocol-signature"];
        }

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
        const sdkContext = await createSdkContext(
            context,
            "@azure-tools/typespec-csharp"
        );
        configurations["azure-arm"] =
            sdkContext.arm === false ? undefined : sdkContext.arm;
        await program.host.writeFile(
            resolvePath(outputFolder, configurationFileName),
            prettierOutput(JSON.stringify(configurations, null, 2))
        );

        const csProjFile = resolvePath(
            isSrcFolder ? outputFolder : resolvePath(outputFolder, "src"),
            `${configurations["library-name"]}.csproj`
        );
        Logger.getInstance().info(`Checking if ${csProjFile} exists`);
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
        Logger.getInstance().info(command);

        try {
            execSync(command, { stdio: "inherit" });
        } catch (error: any) {
            if (error.message) Logger.getInstance().info(error.message);
            if (error.stderr) Logger.getInstance().error(error.stderr);
            if (error.stdout) Logger.getInstance().verbose(error.stdout);
            throw error;
        }
        if (!options["save-inputs"]) {
            // delete
            deleteFile(resolvePath(outputFolder, tspOutputFileName));
            deleteFile(resolvePath(outputFolder, configurationFileName));
        }
    }
}

function deleteFile(filePath: string) {
    fs.unlink(filePath, (err) => {
        if (err) {
            //logger.error(`stderr: ${err}`);
        } else {
            Logger.getInstance().info(`File ${filePath} is deleted.`);
        }
    });
}

function prettierOutput(output: string) {
    return output + "\n";
}
