// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using body_file;
using NUnit.Framework;
using System.Linq;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Types;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace AutoRest.TestServer.Tests
{
    internal class TestMgmtParent
    {
        [Test]
        public async Task TestParentComputer()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            basePath = Path.Combine(basePath.Substring(0, basePath.IndexOf("autorest.csharp")), "autorest.csharp", "samples", "Azure.ResourceManager.Sample", "Generated");
            var configuration = StandaloneGeneratorRunner.LoadConfiguration(basePath, File.ReadAllText(Path.Combine(basePath, "Configuration.json")));
            var codeModelTask = Task.Run(() => CodeModelSerialization.DeserializeCodeModel(File.ReadAllText(Path.Combine(basePath, "CodeModel.yaml"))));
            var projectDirectory = Path.Combine(configuration.OutputFolder, Configuration.ProjectRelativeDirectory);
            var project = await GeneratedCodeWorkspace.Create(projectDirectory, configuration.OutputFolder, configuration.SharedSourceFolders);
            var sourceInputModel = new SourceInputModel(await project.GetCompilationAsync());
            var model = await codeModelTask;
            var context = new BuildContext(model, configuration, sourceInputModel);
            _ = context.Library;
            foreach (var operations in model.OperationGroups)
            {
                Assert.IsNotNull(operations.Parent);
                if (operations.Key.Equals("VirtualMachineExtensionImages"))
                    Assert.IsTrue(operations.Parent.Equals("Microsoft.Compute/locations/publishers"));
                else if (operations.Key.Equals("AvailabilitySets"))
                    Assert.IsTrue(operations.Parent.Equals("resourceGroups"));
                else if (operations.Key.Equals("DedicatedHosts"))
                    Assert.IsTrue(operations.Parent.Equals("Microsoft.Compute/hostGroups"));
            }
        }

        [Test]
        public async Task TestTenant()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            basePath = Path.Combine(basePath.Substring(0, basePath.IndexOf("autorest.csharp")), "autorest.csharp", "test", "TestProjects", "TenantOnly", "Generated");
            var configuration = StandaloneGeneratorRunner.LoadConfiguration(basePath, File.ReadAllText(Path.Combine(basePath, "Configuration.json")));
            var codeModelTask = Task.Run(() => CodeModelSerialization.DeserializeCodeModel(File.ReadAllText(Path.Combine(basePath, "CodeModel.yaml"))));
            var projectDirectory = Path.Combine(configuration.OutputFolder, Configuration.ProjectRelativeDirectory);
            var project = await GeneratedCodeWorkspace.Create(projectDirectory, configuration.OutputFolder, configuration.SharedSourceFolders);
            var sourceInputModel = new SourceInputModel(await project.GetCompilationAsync());
            var model = await codeModelTask;
            var context = new BuildContext(model, configuration, sourceInputModel);
            _ = context.Library;
            foreach (var operations in model.OperationGroups)
            {
                Assert.IsNotNull(operations.Parent);
                if (operations.Key.Equals("AvailableBalances") || operations.Key.Equals("Instructions"))
                    Assert.IsTrue(operations.Parent.Equals("Microsoft.Billing/billingAccounts/billingProfiles"));
                else if (operations.Key.Equals("Agreements"))
                    Assert.IsTrue(operations.Parent.Equals("Microsoft.Billing/billingAccounts"));
                else
                    Assert.IsTrue(operations.Parent.Equals("tenant"));
            }
        }
    }
}
