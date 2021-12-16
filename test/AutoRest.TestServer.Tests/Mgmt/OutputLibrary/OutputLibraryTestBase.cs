// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    [Parallelizable(ParallelScope.All)]
    internal abstract class OutputLibraryTestBase
    {
        private string _projectName;

        public OutputLibraryTestBase(string projectName)
        {
            _projectName = projectName;
        }

        internal static async Task<(CodeModel Model, BuildContext<MgmtOutputLibrary> Context)> Generate(string testProject)
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
        public void ValidateResourceDataCount()
        {
            var result = Generate(_projectName).Result;
            var context = result.Context;

            var count = context.Library.ResourceSchemaMap.Count;

            Assert.AreEqual(count, context.Library.ResourceData.Count(), "Did not find the expected resourceData count");
        }

        [TestCase("Delete")]
        [TestCase("DeleteAsync")]
        public void ValidateDeleteMethodAsLRO(string methodName)
        {
            var result = Generate(_projectName).Result;
            var context = result.Context;

            foreach (var resource in context.Library.ArmResources)
            {
                var name = $"{_projectName}.{resource.Type.Name}";
                var generatedResourceType = Assembly.GetExecutingAssembly().GetType(name);
                if (IsSingletonOperation(generatedResourceType))
                {
                    continue;
                }

                var deleteOperation = resource.DeleteOperation;
                if (deleteOperation != null)
                {
                    var method = generatedResourceType.GetMethod(methodName);
                    Assert.NotNull(method, $"{generatedResourceType.Name} does not implement the {methodName} method.");

                    Assert.GreaterOrEqual(method.GetParameters().Length, 2);
                    var param1 = TypeAsserts.HasParameter(method, "waitForCompletion");
                    Assert.AreEqual(typeof(bool), param1.ParameterType);
                    var param2 = TypeAsserts.HasParameter(method, "cancellationToken");
                    Assert.AreEqual(typeof(CancellationToken), param2.ParameterType);
                }
            }
        }

        [TestCase("Get")]
        [TestCase("GetAsync")]
        public void ValidateGetOverloadMethod(string methodName)
        {
            (_, var context) = Generate(_projectName).Result;

            foreach (var resource in context.Library.ArmResources)
            {
                var name = $"{_projectName}.{resource.Type.Name}";
                var generatedResourceType = Assembly.GetExecutingAssembly().GetType(name);
                if (IsSingletonOperation(generatedResourceType))
                {
                    continue;
                }

                var getOperation = resource.GetOperation;
                Assert.NotNull(getOperation);
                var method = generatedResourceType.GetMethod(methodName);
                Assert.NotNull(method, $"{generatedResourceType.Name} does not implement the {methodName} method.");
            }
        }

        [Test]
        public void ValidateEnumerable()
        {
            (_, var context) = Generate(_projectName).Result;

            foreach (var collection in context.Library.ResourceCollections)
            {
                // skip this if this collection is in the list-exception configuration
                if (collection.RequestPaths.Any(path => context.Configuration.MgmtConfiguration.ListException.Contains(path)))
                    continue;
                var name = $"{_projectName}.{collection.Type.Name}";
                var generatedCollectionType = Assembly.GetExecutingAssembly().GetType(name);

                Assert.NotNull(generatedCollectionType.GetInterface("IEnumerable"), $"{generatedCollectionType.Name} did not implement IEnumerable");
                Assert.NotNull(generatedCollectionType.GetInterface("IEnumerable`1"), $"{generatedCollectionType.Name} did not implement IEnumerable<T>");

                // see if this collection has a Pageable GetAll operation
                // first find the GetAll method without required parameters
                var getAllMethods = generatedCollectionType.GetMethods().Where(method => method.Name == "GetAll")
                    .Where(method => method.GetParameters().Where(p => !p.HasDefaultValue).Count() == 0);
                var getAllMethod = getAllMethods.SingleOrDefault();
                Assert.NotNull(getAllMethod, $"{collection.Type.Name} should have a GetAll operation");
                if (getAllMethod.ReturnType.Name == typeof(Azure.Pageable<>).Name)
                {
                    Assert.NotNull(generatedCollectionType.GetInterface("IAsyncEnumerable`1"), $"{generatedCollectionType.Name} did not implement IAsyncEnumerable<T>");
                }
            }
        }

        private bool IsSingletonOperation(Type type)
        {
            var propertyInfo = type.GetProperty("Parent", BindingFlags.Instance | BindingFlags.Public);
            if (propertyInfo == null)
                return false;
            return type.BaseType == typeof(ArmResource) && propertyInfo.PropertyType == typeof(ArmResource);
        }
    }
}
