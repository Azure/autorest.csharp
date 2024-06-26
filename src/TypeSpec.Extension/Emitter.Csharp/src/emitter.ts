// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { EmitContext, Program, resolvePath } from "@typespec/compiler";

import { execSync } from "child_process";
import fs, { existsSync } from "fs";
import path from "node:path";
import { configurationFileName, tspOutputFileName } from "./constants.js";
import { LoggerLevel } from "./lib/log-level.js";
import { Logger } from "./lib/logger.js";
import {
    NetEmitterOptions,
    resolveOptions,
    resolveOutputFolder
} from "./options.js";
import { loadLibrary } from "./lib/load-module.js";

export async function $onEmit(context: EmitContext<NetEmitterOptions>) {
    const program: Program = context.program;
    const options = resolveOptions(context);
    /* set the loglevel. */
    Logger.initialize(program, options.logLevel ?? LoggerLevel.INFO);

    /* load microsft csharp emitter. */
    const basedir = "./";
    const emitterNameOrPath = "@typespec/http-client-csharp";
    const library = await loadLibrary(
        basedir,
        emitterNameOrPath,
        context.program
    );

    if (library === undefined) {
        Logger.getInstance().error(`Cannot load emitter ${emitterNameOrPath}`);
        throw new Error(`Cannot load emitter ${emitterNameOrPath}`);
    }

    const { entrypoint } = library;
    if (entrypoint === undefined) {
        Logger.getInstance().error(
            `Invalid emitter ${emitterNameOrPath}. No entrypoint.`
        );
        throw new Error(`Invalid emitter ${emitterNameOrPath}. No entrypoint.`);
    }

    const emitFunction = entrypoint.esmExports.$onEmit;
    try {
        context.options.skipSDKGeneration = true;
        context.options.emitterName = "@azure-tools/typespec-csharp";
        await emitFunction(context);
    } catch (error: unknown) {
        throw new Error("emitter error");
    }

    const outputFolder = resolveOutputFolder(context);
    const generatedFolder = outputFolder.endsWith("src")
        ? resolvePath(outputFolder, "Generated")
        : resolvePath(outputFolder, "src", "Generated");
    if (options.skipSDKGeneration !== true) {
        /*
        const configurationFilePath = resolvePath(
            generatedFolder,
            configurationFileName
        );
        */
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
        configurations["shared-source-folders"] = resolvedSharedFolders ?? [];
        await program.host.writeFile(
            resolvePath(generatedFolder, configurationFileName),
            prettierOutput(JSON.stringify(configurations, null, 2))
        );

        /* copy tspConfiguration.json to the generated folder. */
        fs.renameSync(
            resolvePath(outputFolder, tspOutputFileName),
            resolvePath(generatedFolder, tspOutputFileName)
        );
        Logger.getInstance().info(
            `${tspOutputFileName} was copied to ${generatedFolder}`
        );
        /* clean up */
        deleteFile(resolvePath(outputFolder, configurationFileName));
        const csProjFile = resolvePath(
            outputFolder.endsWith("src")
                ? outputFolder
                : resolvePath(outputFolder, "src"),
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
        const debugFlag = options.debug ?? false ? " --debug" : "";

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
            deleteFile(resolvePath(generatedFolder, tspOutputFileName));
            deleteFile(resolvePath(generatedFolder, configurationFileName));
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
