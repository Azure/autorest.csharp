import { createTestHost, TestHost } from "@typespec/compiler/testing";
import { RestTestLibrary } from "@typespec/rest/testing";
import { HttpTestLibrary } from "@typespec/http/testing";
import { VersioningTestLibrary } from "@typespec/versioning/testing";
import { AzureCoreTestLibrary } from "@azure-tools/typespec-azure-core/testing";
import { EmitContext, Program } from "@typespec/compiler";
import { NetEmitterOptions } from "../../../src/options";

export async function createEmitterTestHost(): Promise<TestHost> {
    return createTestHost({
        libraries: [
            RestTestLibrary,
            HttpTestLibrary,
            VersioningTestLibrary,
            AzureCoreTestLibrary
        ]
    });
}

export async function typeSpecCompile(
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
    ${needAzureCore ? "@useDependency(Azure.Core.Versions.v1_0_Preview_1)" : ""}
    namespace Azure.Csharp.Testing;
    `;
    host.addTypeSpecFile(
        "main.tsp",
        `
    import "@typespec/rest";
    import "@typespec/http";
    import "@typespec/versioning";
    ${needAzureCore ? 'import "@azure-tools/typespec-azure-core";' : ""} 
    using TypeSpec.Rest; 
    using TypeSpec.Http;
    using TypeSpec.Versioning;
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
