import { createDiagnostic } from "@azure-tools/typespec-client-generator-core";
import { CompilerHost, Diagnostic, DiagnosticHandler, DiagnosticTarget, JsSourceFileNode, LibraryInstance, LibraryMetadata, LocationContext, ModuleLibraryMetadata, ModuleResolutionResult, NoTarget, NodeFlags, Program, ResolveModuleHost, ResolvedModule, SyntaxKind, TypeSpecLibrary, createSourceFile, resolveModule } from "@typespec/compiler";
  
async function loadJsFile(
    path: string,
    program: Program
  ): Promise<JsSourceFileNode | undefined> {
    const sourceFile = program.jsSourceFiles.get(path);
    if (sourceFile !== undefined) {
      return sourceFile;
    }

    const file = createSourceFile("", path);
    let exports;
    try {
        exports = await program.host.getJsImport(path);
    }catch (e: any) {
    }

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
    const file = await loadJsFile(entrypoint, program);

    return [{ module, entrypoint: file }, []];
  }

export async function loadLibrary(
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