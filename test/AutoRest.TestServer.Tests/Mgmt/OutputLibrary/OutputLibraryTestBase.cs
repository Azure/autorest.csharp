// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
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
        public void ValidateResourceClassTypesCount()
        {
            var result = Generate(_projectName).Result;
            var context = result.Context;

            var count = context.Library.ResourceSchemaMap.Count;
            var singletonCount = context.CodeModel.OperationGroups.Count(
                c => c.IsSingletonResource(result.Context.Configuration.MgmtConfiguration));

            Assert.AreEqual(count, context.Library.ResourceOperations.Count() + context.Library.TupleResourceOperations.Count(), "Did not find the expected resourceOperations count");
            Assert.AreEqual(count - singletonCount, context.Library.ResourceContainers.Count() + context.Library.TupleResourceContainers.Count(), "Did not find the expected resourceContainers count");
            Assert.AreEqual(count, context.Library.ArmResource.Count(), "Did not find the expected resource count");
            Assert.AreEqual(count, context.Library.ResourceData.Count(), "Did not find the expected resourceData count");
        }

        [Test]
        public void TestTupleResources()
        {
            var result = Generate(_projectName).Result;
            var tupleOperationGroupList = result.Context.Configuration.MgmtConfiguration.OperationGroupIsTuple;
            foreach (var operationGroup in result.Context.CodeModel.OperationGroups)
            {
                if (tupleOperationGroupList.Contains(operationGroup.Key))
                {
                    Assert.True(operationGroup.IsTupleResource(result.Context));
                }
                else
                {
                    Assert.False(operationGroup.IsTupleResource(result.Context));
                }
            }
        }

        [TestCase("Delete")]
        [TestCase("DeleteAsync")]
        [TestCase("StartDelete")]
        [TestCase("StartDeleteAsync")]
        public void ValidateDeleteMethodAsLRO(string methodName)
        {
            var result = Generate(_projectName).Result;
            var context = result.Context;

            foreach (var resourceOperation in context.Library.ResourceOperations)
            {
                var name = $"{_projectName}.{resourceOperation.Type.Name}";
                var OperationsType = Assembly.GetExecutingAssembly().GetType(name);
                if (IsSingletonOperation(OperationsType.BaseType))
                {
                    continue;
                }

                var httpMethodsMap = resourceOperation.OperationGroup.OperationHttpMethodMapping();
                httpMethodsMap.TryGetValue(HttpMethod.Delete, out var deleteMethods);
                if (deleteMethods != null && deleteMethods.Count > 0)
                {
                    var method = OperationsType.GetMethod(methodName);
                    Assert.NotNull(method, $"{OperationsType.Name} does not implement the {methodName} method.");

                    Assert.AreEqual(1, method.GetParameters().Length);
                    var param1 = TypeAsserts.HasParameter(method, "cancellationToken");
                    Assert.AreEqual(typeof(CancellationToken), param1.ParameterType);
                }
            }
        }

        [TestCase("Get")]
        [TestCase("GetAsync")]
        public void ValidateGetOverloadMethod(string methodName)
        {
            var result = Generate(_projectName).Result;
            var context = result.Context;

            foreach (var resourceOperation in context.Library.ResourceOperations)
            {
                var name = $"{_projectName}.{resourceOperation.Type.Name}";
                var OperationsType = Assembly.GetExecutingAssembly().GetType(name);
                if (IsSingletonOperation(OperationsType.BaseType))
                {
                    continue;
                }

                var restClient = context.Library.GetRestClient(resourceOperation.OperationGroup);
                var getMethod = restClient.Methods.Where(m => m.Name == "Get").FirstOrDefault();
                Assert.NotNull(getMethod, $"{restClient.Type.Name} does not implement the Get method.");
            }
        }

        private bool IsSingletonOperation(Type type)
        {
            return type == typeof(SingletonOperations);
        }

        private Parameter[] GetNonPathParameters(RestClientMethod clientMethod)
        {
            var pathParameters = GetPathParameters(clientMethod);

            List<Parameter> nonPathParameters = new List<Parameter>();
            foreach (Parameter parameter in clientMethod.Parameters)
            {
                if (!pathParameters.Contains(parameter))
                {
                    nonPathParameters.Add(parameter);
                }
            }

            return nonPathParameters.ToArray();
        }

        private Parameter[] GetPathParameters(RestClientMethod clientMethod)
        {
            var pathParameters = clientMethod.Request.PathSegments.Where(m => m.Value.IsConstant == false && m.IsRaw == false);
            List<Parameter> pathParametersList = new List<Parameter>();
            foreach (var parameter in clientMethod.Parameters)
            {
                if (pathParameters.Any(p => p.Value.Reference.Type.Name == parameter.Type.Name &&
                p.Value.Reference.Name == parameter.Name))
                {
                    pathParametersList.Add(parameter);
                }
            }

            return pathParametersList.ToArray();
        }
    }
}
