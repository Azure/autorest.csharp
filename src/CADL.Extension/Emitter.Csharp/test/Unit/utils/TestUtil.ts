import { createTestHost, TestHost } from "@cadl-lang/compiler/testing";
import { RestTestLibrary } from "@cadl-lang/rest/testing";
import { VersioningTestLibrary } from "@cadl-lang/versioning/testing";
import { AzureCoreTestLibrary } from "@azure-tools/cadl-azure-core/testing";

export async function createEmitterTestHost(): Promise<TestHost> {
    return createTestHost({libraries: [RestTestLibrary, VersioningTestLibrary, AzureCoreTestLibrary]});
}

export async function cadlCompile(content: string, host: TestHost, needNamespaces: boolean = true, needAzureCore: boolean = false)
{
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