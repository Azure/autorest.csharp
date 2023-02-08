import { createTestHost, TestHost } from "@cadl-lang/compiler/testing";
import { RestTestLibrary } from "@cadl-lang/rest/testing";
import { VersioningTestLibrary } from "@cadl-lang/versioning/testing";
import { AzureCoreTestLibrary } from "@azure-tools/cadl-azure-core/testing";
import { EmitContext, Program } from "@cadl-lang/compiler";
import { NetEmitterOptions } from "../../../src/emitter";

export async function createEmitterTestHost(): Promise<TestHost> {
    return createTestHost({
        libraries: [
            RestTestLibrary,
            VersioningTestLibrary,
            AzureCoreTestLibrary
        ]
    });
}

export async function cadlCompile(
    content: string,
    host: TestHost,
    needNamespaces: boolean = true,
    needAzureCore: boolean = false
) {
    const namespace = `
    @service({
      title: "Azure Csharp emitter Testing",
      version: "2023-01-01-preview",
    })
    namespace Azure.Csharp.Testing;
    `;
    host.addCadlFile(
        "main.cadl",
        `
    import "@cadl-lang/rest";
    import "@cadl-lang/versioning";
    ${needAzureCore ? 'import "@azure-tools/cadl-azure-core";' : ""} 
    using Cadl.Rest; 
    using Cadl.Http;
    using Cadl.Versioning;
    ${needAzureCore ? "using Azure.Core;" : ""}
    
    ${needNamespaces ? namespace : ""}
    ${content}
    `
    );
    await host.compile("./", {
        warningAsError: false
    });
    return host.program;
}

export function createEmitterContext(
    program: Program
): EmitContext<NetEmitterOptions> {
    return {
        program: program,
        emitterOutputDir: "./",
        options: {
            outputFile: "cadl.json",
            logFile: "log.json",
            skipSDKGeneration: false,
            "new-project": false,
            "clear-output-folder": false,
            "save-inputs": false,
            "generate-protocol-methods": true,
            "generate-convenience-methods": true,
            "package-name": undefined
        } as NetEmitterOptions
    } as EmitContext<NetEmitterOptions>;
}
