// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal abstract class OutputLibraryTestBase
    {
        private string _projectName;

        public OutputLibraryTestBase(string projectName)
        {
            _projectName = projectName;
        }

        protected static async Task<(CodeModel Model, BuildContext<MgmtOutputLibrary> Context)> Generate(string testProject)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            basePath = Path.Combine(basePath.Substring(0, basePath.IndexOf("autorest.csharp")), "autorest.csharp", "test", "TestProjects", testProject, "Generated");
            var configuration = StandaloneGeneratorRunner.LoadConfiguration(basePath, File.ReadAllText(Path.Combine(basePath, "Configuration.json")));
            var codeModelTask = Task.Run(() => CodeModelSerialization.DeserializeCodeModel(File.ReadAllText(Path.Combine(basePath, "CodeModel.yaml"))));
            var projectDirectory = Path.Combine(configuration.OutputFolder, Configuration.ProjectRelativeDirectory);
            var project = await GeneratedCodeWorkspace.Create(projectDirectory, configuration.OutputFolder, configuration.SharedSourceFolders);
            var sourceInputModel = new SourceInputModel(await project.GetCompilationAsync());
            var model = await codeModelTask;
            var context = new BuildContext<MgmtOutputLibrary>(model, configuration, sourceInputModel);
            _ = context.Library; // gen lib
            return (model, context);
        }

        [Test]
        public void ValidateResourceClassTypesCount()
        {
            var result = Generate(_projectName).Result;
            var context = result.Context;

            var count = context.Library.ResourceSchemaMap.Count;
            Assert.AreEqual(count, context.Library.ResourceOperations.Count());
            Assert.AreEqual(count, context.Library.ResourceContainers.Count());
            Assert.AreEqual(count, context.Library.ResourceData.Count());
            Assert.AreEqual(count, context.Library.ArmResource.Count());
        }
    }
}
