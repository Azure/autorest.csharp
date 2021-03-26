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
        public async Task TestParent()
        {
            StandaloneGeneratorRunner runner = new StandaloneGeneratorRunner();
            string[] args = {"--standalone $(SolutionDir)\\samples\\Azure.ResourceManager.Sample\\Generated"};
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            basePath = Path.Combine(basePath.Substring(0, basePath.IndexOf("autorest.csharp")), "autorest.csharp", "samples", "Azure.Management.Storage", "Generated");
            TestContext.Progress.WriteLine(basePath);
            JsonDocument doc = JsonDocument.Parse(File.ReadAllText(Path.Combine(basePath, "Configuration.json")));
            var root = doc.RootElement;
            TestContext.Progress.WriteLine(root.ValueKind);
            var configuration = StandaloneGeneratorRunner.LoadConfiguration(basePath, File.ReadAllText(Path.Combine(basePath, "Configuration.json")));
            var codeModelTask = Task.Run(() => CodeModelSerialization.DeserializeCodeModel(File.ReadAllText(Path.Combine(basePath, "CodeModel.yaml"))));
            //Directory.CreateDirectory(configuration.OutputFolder);
            var projectDirectory = Path.Combine(configuration.OutputFolder, Configuration.ProjectRelativeDirectory);
            var project = await GeneratedCodeWorkspace.Create(projectDirectory, configuration.OutputFolder, configuration.SharedSourceFolders);
            var sourceInputModel = new SourceInputModel(await project.GetCompilationAsync());
            var model = await codeModelTask;
            var context = new BuildContext(model, configuration, sourceInputModel);
            var lib = context.Library;
            foreach (var operations in model.OperationGroups)
            {
                Assert.IsNotNull(operations.Parent);
            }
        }
    }
}
