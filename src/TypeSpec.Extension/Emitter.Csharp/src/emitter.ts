// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { createDiagnostic, createSdkContext } from "@azure-tools/typespec-client-generator-core";
import {
    CompilerHost,
    Diagnostic,
    DiagnosticHandler,
    DiagnosticTarget,
    EmitContext,
    JsSourceFileNode,
    LibraryInstance,
    LibraryMetadata,
    LocationContext,
    ModuleLibraryMetadata,
    ModuleResolutionResult,
    NoTarget,
    NodeFlags,
    Program,
    ProjectLocationContext,
    ResolveModuleHost,
    ResolvedModule,
    SyntaxKind,
    TypeSpecLibrary,
    createSourceFile,
    logDiagnostics,
    resolveModule,
    resolvePath
} from "@typespec/compiler";

import { execSync } from "child_process";
import fs, { existsSync } from "fs";
import { PreserveType, stringifyRefs } from "json-serialize-refs";
import path from "node:path";
import {
    configurationFileName,
    tspOutputFileName,
    packageName
} from "./constants.js";
import { createModel } from "./lib/client-model-builder.js";
import { LoggerLevel } from "./lib/log-level.js";
import { Logger } from "./lib/logger.js";
import {
    NetEmitterOptions,
    resolveOptions,
    resolveOutputFolder
} from "./options.js";
import { Configuration } from "./type/configuration.js";
export interface FileHandlingOptions {
    allowFileNotFound?: boolean;
    diagnosticTarget?: DiagnosticTarget | typeof NoTarget;
    jsDiagnosticTarget?: DiagnosticTarget;
  }
export async function doIO<T>(
    action: (path: string) => Promise<T>,
    path: string,
    reportDiagnostic: DiagnosticHandler,
    options?: FileHandlingOptions
  ): Promise<T | undefined> {
    let result;
    try {
      result = await action(path);
    } catch (e: any) {
      let diagnostic: Diagnostic;
      let target = options?.diagnosticTarget ?? NoTarget;
  
      // blame the JS file, not the TypeSpec import statement for JS syntax errors.
      if (e instanceof SyntaxError && options?.jsDiagnosticTarget) {
        target = options.jsDiagnosticTarget;
      }
  
      switch (e.code) {
        case "ENOENT":
          if (options?.allowFileNotFound) {
            return undefined;
          }
          diagnostic = createDiagnostic({ code: "no-emitter-name", target, format: { path } });
          break;
        default:
          diagnostic = createDiagnostic({
            code: "no-emitter-name",
            target,
            format: { message: e.message },
          });
          break;
      }
  
      reportDiagnostic(diagnostic);
      return undefined;
    }
  
    return result;
  }
  
async function loadJsFile(
    path: string,
    locationContext: LocationContext,
    diagnosticTarget: DiagnosticTarget | typeof NoTarget,
    program: Program
  ): Promise<JsSourceFileNode | undefined> {
    const sourceFile = program.jsSourceFiles.get(path);
    if (sourceFile !== undefined) {
      return sourceFile;
    }

    const file = createSourceFile("", path);
    //sourceFileLocationContexts.set(file, locationContext);
    const exports = await doIO(program.host.getJsImport, path, program.reportDiagnostic, {
      diagnosticTarget,
      jsDiagnosticTarget: { file, pos: 0, end: 0 },
    });

    if (!exports) {
      return undefined;
    }

    return {
      kind: SyntaxKind.JsSourceFile,
      id: {
        kind: SyntaxKind.Identifier,
        sv: "",
        pos: 0,
        end: 0,
        symbol: undefined!,
        flags: NodeFlags.Synthetic,
      },
      esmExports: exports,
      file,
      namespaceSymbols: [],
      symbol: undefined!,
      pos: 0,
      end: 0,
      flags: NodeFlags.None,
    };
  }
  
function getResolveModuleHost(host:CompilerHost): ResolveModuleHost {
    return {
      realpath: host.realpath,
      stat: host.stat,
      readFile: async (path) => {
        const file = await host.readFile(path);
        return file.text;
      },
    };
  }
  
async function resolveJSLibrary(
    specifier: string,
    baseDir: string,
    locationContext: LocationContext,
    program: Program
  ): Promise<[ModuleResolutionResult | undefined, readonly Diagnostic[]]> {
    try {
      return [await resolveModule(getResolveModuleHost(program.host), specifier, { baseDir }), []];
    } catch (e: any) {
      if (e.code === "MODULE_NOT_FOUND") {
        return [
          undefined,
          [
            createDiagnostic({
              code: "no-emitter-name",
              format: { path: specifier },
              target: NoTarget,
            }),
          ],
        ];
      } else if (e.code === "INVALID_MAIN") {
        return [
          undefined,
          [
            createDiagnostic({
              code: "no-emitter-name",
              format: { path: specifier },
              target: NoTarget,
            }),
          ],
        ];
      } else {
        throw e;
      }
    }
  }
  
async function resolveEmitterModuleAndEntrypoint(
    basedir: string,
    emitterNameOrPath: string,
    program: Program
  ): Promise<
    [
      { module: ModuleResolutionResult; entrypoint: JsSourceFileNode | undefined } | undefined,
      readonly Diagnostic[],
    ]
  > {
    const locationContext: LocationContext = { type: "project" };
    // attempt to resolve a node module with this name
    const [module, diagnostics] = await resolveJSLibrary(
      emitterNameOrPath,
      basedir,
      locationContext,
      program
    );
    if (!module) {
      return [undefined, diagnostics];
    }

    const entrypoint = module.type === "file" ? module.path : module.mainFile;
    const file = await loadJsFile(entrypoint, locationContext, NoTarget, program);

    return [{ module, entrypoint: file }, []];
  }

async function loadLibrary(
    basedir: string,
    libraryNameOrPath: string,
    program: Program
  ): Promise<LibraryInstance | undefined> {
    const [resolution, diagnostics] = await resolveEmitterModuleAndEntrypoint(
      basedir,
      libraryNameOrPath,
      program
    );

    if (resolution === undefined) {
      program.reportDiagnostics(diagnostics);
      return undefined;
    }
    const { module, entrypoint } = resolution;

    const libDefinition: TypeSpecLibrary<any> | undefined = entrypoint?.esmExports.$lib;
    const metadata = computeLibraryMetadata(module, libDefinition);

    return {
      ...resolution,
      metadata,
      definition: libDefinition,
      linter: entrypoint?.esmExports.$linter,
    };
  }
  function computeLibraryMetadata(
    module: ModuleResolutionResult,
    libDefinition: TypeSpecLibrary<any> | undefined
  ): LibraryMetadata {
    if (module.type === "file") {
      return {
        type: "file",
        name: libDefinition?.name,
      };
    }

    return computeModuleMetadata(module);
  }

  function computeModuleMetadata(module: ResolvedModule): ModuleLibraryMetadata {
    const metadata: ModuleLibraryMetadata = {
      type: "module",
      name: module.manifest.name,
    };

    if (module.manifest.homepage) {
      metadata.homepage = module.manifest.homepage;
    }
    if (module.manifest.bugs?.url) {
      metadata.bugs = { url: module.manifest.bugs?.url };
    }
    if (module.manifest.version) {
      metadata.version = module.manifest.version;
    }

    return metadata;
  }
  
export async function $onEmit(context: EmitContext<NetEmitterOptions>) {
    const program: Program = context.program;
    context.options.skipSDKGeneration = false;
    const options = resolveOptions(context);
    /* set the loglevel. */
    Logger.initialize(program, options.logLevel ?? LoggerLevel.INFO);

    /* load microsft csharp emitter. */
    const basedir = "./";
    const emitterNameOrPath = "@typespec/http-client-csharp";
    const library = await loadLibrary(basedir, emitterNameOrPath, context.program);

    if (library === undefined) {
      return undefined;
    }

    const { entrypoint, metadata } = library;
    if (entrypoint === undefined) {
      context.program.reportDiagnostic(
        createDiagnostic({
          code: "no-emitter-name",
          format: { emitterPackage: emitterNameOrPath },
          target: NoTarget,
        })
      );
      return undefined;
    }

    const emitFunction = entrypoint.esmExports.$onEmit;
    try {
        context.options.skipSDKGeneration = true;
        await emitFunction(context);
    } catch (error: unknown) {
        throw new Error("emitter error");
    }

    // const program: Program = context.program;
    // context.options.skipSDKGeneration = false;
    // const options = resolveOptions(context);
    //options.skipSDKGeneration = false;
    const outputFolder = resolveOutputFolder(context);
    const generatedFolder = outputFolder.endsWith("src")
                ? resolvePath(outputFolder, "Generated")
                : resolvePath(outputFolder, "src", "Generated");
    if (options.skipSDKGeneration !== true) {
        const configurationFilePath = resolvePath(generatedFolder, configurationFileName);
        const configurations = JSON.parse(fs.readFileSync(configurationFilePath, 'utf-8'));
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
        configurations["shared-source-folders"] = resolvedSharedFolders ?? [];
        await program.host.writeFile(
            resolvePath(generatedFolder, configurationFileName),
            prettierOutput(JSON.stringify(configurations, null, 2))
        );
        const csProjFile = resolvePath(
            outputFolder,
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
            if (error.stdout)
                Logger.getInstance().verbose(error.stdout);
            throw error;
        }
    }

    if (!options["save-inputs"]) {
        // delete
        deleteFile(resolvePath(generatedFolder, tspOutputFileName));
        deleteFile(resolvePath(generatedFolder, configurationFileName));
    }

    /*
    if (!program.compilerOptions.noEmit && !program.hasError()) {
        // Write out the dotnet model to the output path
        const sdkContext = createSdkContext(context, packageName);
        const root = createModel(sdkContext);
        if (
            context.program.diagnostics.length > 0 &&
            context.program.diagnostics.filter(
                (digs) => digs.severity === "error"
            ).length > 0
        ) {
            logDiagnostics(
                context.program.diagnostics,
                context.program.host.logSink
            );
            process.exit(1);
        }
        const tspNamespace = root.Name; // this is the top-level namespace defined in the typespec file, which is actually always different from the namespace of the SDK
        // await program.host.writeFile(outPath, prettierOutput(JSON.stringify(root, null, 2)));
        if (root) {
            const generatedFolder = outputFolder.endsWith("src")
                ? resolvePath(outputFolder, "Generated")
                : resolvePath(outputFolder, "src", "Generated");

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
                resolvePath(generatedFolder, tspOutputFileName),
                prettierOutput(
                    stringifyRefs(root, null, 1, PreserveType.Objects)
                )
            );

            //emit configuration.json
            const namespace = options.namespace ?? tspNamespace;
            const configurations: Configuration = {
                "output-folder": ".",
                namespace: namespace,
                "library-name": options["library-name"] ?? namespace,
                "shared-source-folders": resolvedSharedFolders ?? [],
                "single-top-level-client": options["single-top-level-client"],
                "unreferenced-types-handling":
                    options["unreferenced-types-handling"],
                "keep-non-overloadable-protocol-signature":
                    options["keep-non-overloadable-protocol-signature"],
                "model-namespace": options["model-namespace"],
                "models-to-treat-empty-string-as-null":
                    options["models-to-treat-empty-string-as-null"],
                "intrinsic-types-to-treat-empty-string-as-null": options[
                    "models-to-treat-empty-string-as-null"
                ]
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
                    : undefined,
                "methods-to-keep-client-default-value":
                    options["methods-to-keep-client-default-value"],
                "head-as-boolean": options["head-as-boolean"],
                "deserialize-null-collection-as-null-value":
                    options["deserialize-null-collection-as-null-value"],
                flavor:
                    options["flavor"] ??
                    (namespace.toLowerCase().startsWith("azure.")
                        ? "azure"
                        : undefined),
                //only emit these if they are not the default values
                "generate-sample-project":
                    options["generate-sample-project"] === true
                        ? undefined
                        : options["generate-sample-project"],
                "generate-test-project":
                    options["generate-test-project"] === false
                        ? undefined
                        : options["generate-test-project"],
                "use-model-reader-writer":
                    options["use-model-reader-writer"] ?? true,
                "azure-arm":
                    sdkContext.arm === false ? undefined : sdkContext.arm,
                "disable-xml-docs":
                    options["disable-xml-docs"] === false
                        ? undefined
                        : options["disable-xml-docs"]
            };

            await program.host.writeFile(
                resolvePath(generatedFolder, configurationFileName),
                prettierOutput(JSON.stringify(configurations, null, 2))
            );

            if (options.skipSDKGeneration !== true) {
                const csProjFile = resolvePath(
                    outputFolder,
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
                    if (error.stdout)
                        Logger.getInstance().verbose(error.stdout);
                    throw error;
                }
            }

            if (!options["save-inputs"]) {
                // delete
                deleteFile(resolvePath(generatedFolder, tspOutputFileName));
                deleteFile(resolvePath(generatedFolder, configurationFileName));
            }
        }
    }
    */
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


