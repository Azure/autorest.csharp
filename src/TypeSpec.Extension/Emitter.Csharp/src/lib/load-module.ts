import {
    CompilerHost,
    JsSourceFileNode,
    LibraryInstance,
    LibraryMetadata,
    ModuleLibraryMetadata,
    ModuleResolutionResult,
    NodeFlags,
    Program,
    ResolveModuleHost,
    ResolvedModule,
    SyntaxKind,
    TypeSpecLibrary,
    createSourceFile,
    resolveModule
} from "@typespec/compiler";
import { Logger } from "./logger.js";

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
        if (!exports) {
            return undefined;
        }
    } catch (e: any) {
        Logger.getInstance().error(e);
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
            flags: NodeFlags.Synthetic
        },
        esmExports: exports,
        file,
        namespaceSymbols: [],
        symbol: undefined!,
        pos: 0,
        end: 0,
        flags: NodeFlags.None
    };
}

function getResolveModuleHost(host: CompilerHost): ResolveModuleHost {
    return {
        realpath: host.realpath,
        stat: host.stat,
        readFile: async (path) => {
            const file = await host.readFile(path);
            return file.text;
        }
    };
}

async function resolveJSLibrary(
    specifier: string,
    baseDir: string,
    program: Program
): Promise<ModuleResolutionResult | undefined> {
    try {
        return await resolveModule(
            getResolveModuleHost(program.host),
            specifier,
            { baseDir }
        );
    } catch (e: any) {
        if (e.code === "MODULE_NOT_FOUND") {
            Logger.getInstance().error(`Cannot find module ${specifier}.`);
        } else if (e.code === "INVALID_MAIN") {
            Logger.getInstance().error(`library ${specifier} is not valid`);
        }
        throw e;
    }
    return undefined;
}

async function resolveEmitterModuleAndEntrypoint(
    basedir: string,
    emitterNameOrPath: string,
    program: Program
): Promise<
    | {
          module: ModuleResolutionResult;
          entrypoint: JsSourceFileNode | undefined;
      }
    | undefined
> {
    // attempt to resolve a node module with this name
    const module = await resolveJSLibrary(emitterNameOrPath, basedir, program);
    if (!module) {
        return undefined;
    }

    const entrypoint = module.type === "file" ? module.path : module.mainFile;
    const file = await loadJsFile(entrypoint, program);

    return { module, entrypoint: file };
}

export async function loadLibrary(
    basedir: string,
    libraryNameOrPath: string,
    program: Program
): Promise<LibraryInstance | undefined> {
    const resolution = await resolveEmitterModuleAndEntrypoint(
        basedir,
        libraryNameOrPath,
        program
    );

    if (resolution === undefined) {
        return undefined;
    }
    const { module, entrypoint } = resolution;

    const libDefinition: TypeSpecLibrary<any> | undefined =
        entrypoint?.esmExports.$lib;
    const metadata = computeLibraryMetadata(module, libDefinition);

    return {
        ...resolution,
        metadata,
        definition: libDefinition,
        linter: entrypoint?.esmExports.$linter
    };
}
function computeLibraryMetadata(
    module: ModuleResolutionResult,
    libDefinition: TypeSpecLibrary<any> | undefined
): LibraryMetadata {
    if (module.type === "file") {
        return {
            type: "file",
            name: libDefinition?.name
        };
    }

    return computeModuleMetadata(module);
}

function computeModuleMetadata(module: ResolvedModule): ModuleLibraryMetadata {
    const metadata: ModuleLibraryMetadata = {
        type: "module",
        name: module.manifest.name
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
