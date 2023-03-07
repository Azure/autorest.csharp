// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {
    createCadlLibrary,
    Program,
    resolvePath,
    Service
} from "@cadl-lang/compiler";

import { stringifyRefs, PreserveType } from "json-serialize-refs";
import fs from "fs";
import path from "node:path";
import { Configuration } from "./type/Configuration.js";
import { execSync } from "child_process";
import { EmitContext } from "@cadl-lang/compiler";
import {
    NetEmitterOptions,
    NetEmitterOptionsSchema,
    resolveOptions,
    resolveOutputFolder
} from "./options.js";
import { createModel } from "./lib/clientModelBuilder.js";

export const $lib = createCadlLibrary({
    name: "cadl-csharp",
    diagnostics: {},
    emitter: {
        options: NetEmitterOptionsSchema
    }
});

export async function $onEmit(context: EmitContext<NetEmitterOptions>) {
    const program: Program = context.program;
    const options = resolveOptions(context);
    const outputFolder = resolveOutputFolder(context);
    if (!program.compilerOptions.noEmit && !program.hasError()) {
        // Write out the dotnet model to the output path
        const root = createModel(context);
        const namespace = root.Name;
        // await program.host.writeFile(outPath, prettierOutput(JSON.stringify(root, null, 2)));
        if (root) {
            const generatedFolder = resolvePath(outputFolder, "Generated");

            //resolve shared folders based on generator path override
            const resolvedSharedFolders: string[] = [];
            const sharedFolders = [
                resolvePath(
                    options.csharpGeneratorPath,
                    "..",
                    "Generator.Shared"
                ),
                resolvePath(
                    options.csharpGeneratorPath,
                    "..",
                    "Azure.Core.Shared"
                )
            ];
            for (const sharedFolder of sharedFolders) {
                resolvedSharedFolders.push(
                    path
                        .relative(generatedFolder, sharedFolder)
                        .replaceAll("\\", "/")
                );
            }

            if (!fs.existsSync(generatedFolder)) {
                fs.mkdirSync(generatedFolder, { recursive: true });
            }

            await program.host.writeFile(
                resolvePath(generatedFolder, "cadl.json"),
                prettierOutput(
                    stringifyRefs(root, null, 1, PreserveType.Objects)
                )
            );

            //emit configuration.json
            const configurations = {
                OutputFolder: ".",
                Namespace: options.namespace ?? namespace,
                LibraryName: options["library-name"] ?? null,
                SharedSourceFolders: resolvedSharedFolders ?? [],
                SingleTopLevelClient: options["single-top-level-client"],
                "unreferenced-types-handling":
                    options["unreferenced-types-handling"],
                "model-namespace": options["model-namespace"]
            } as Configuration;

            await program.host.writeFile(
                resolvePath(generatedFolder, "Configuration.json"),
                prettierOutput(JSON.stringify(configurations, null, 2))
            );

            if (options.skipSDKGeneration !== true) {
                const newProjectOption = options["new-project"]
                    ? "--new-project"
                    : "";

                const debugFlag = options.debug ?? false ? " --debug" : "";

                const command = `dotnet --roll-forward Major ${resolvePath(
                    options.csharpGeneratorPath
                )} --project-path ${outputFolder} ${newProjectOption} --clear-output-folder ${
                    options["clear-output-folder"]
                }${debugFlag}`;
                console.info(command);

                try {
                    execSync(command, { stdio: "inherit" });
                } catch (error: any) {
                    if (error.message) console.log(error.message);
                    if (error.stderr) console.error(error.stderr);
                    if (error.stdout) console.log(error.stdout);

                    throw error;
                }
            }

            if (!options["save-inputs"]) {
                // delete
                deleteFile(resolvePath(generatedFolder, "cadl.json"));
                deleteFile(resolvePath(generatedFolder, "Configuration.json"));
            }
        }
    }
}

function deleteFile(filePath: string) {
    fs.unlink(filePath, (err) => {
        if (err) {
            console.log(`stderr: ${err}`);
        }

        console.log(`File ${filePath} is deleted.`);
    });
}

function prettierOutput(output: string) {
    return output + "\n";
}

class ErrorTypeFoundError extends Error {
    constructor() {
        super("Error type found in evaluated Cadl output");
    }
}
