// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Generation;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class MgmtTestTarget
    {
        public static void Execute(GeneratedCodeWorkspace project, CodeModel codeModel, SourceInputModel? sourceInputModel)
        {
            MgmtContext.Initialize(new BuildContext<MgmtOutputLibrary>(codeModel, sourceInputModel));

            // force trigger the model initialization
            foreach (var _ in MgmtContext.Library.ResourceSchemaMap)
            {
            }

            var extensionsWriter = new CodeWriter();

            bool hasCollectionTest = false;
            foreach (var resourceCollection in MgmtContext.Library.ResourceCollections)
            {
                var codeWriter = new CodeWriter();
                var collectionTestWriter = new ResourceCollectionTestWriter(codeWriter, resourceCollection);
                collectionTestWriter.WriteCollectionTest();

                project.AddGeneratedFile($"Mock/{resourceCollection.Type.Name}Test.cs", codeWriter.ToString());
                hasCollectionTest = true;
            }

            if (hasCollectionTest)
            {
                var mockExtensionWriter = new TestHelperWriter(extensionsWriter);
                mockExtensionWriter.WriteMockExtension();
                project.AddGeneratedFile($"Mock/TestHelper.cs", extensionsWriter.ToString());
            }

            foreach (var resource in MgmtContext.Library.ArmResources)
            {
                var codeWriter = new CodeWriter();
                var resourceTestWriter = new ResourceTestWriter(codeWriter, resource);
                resourceTestWriter.WriteCollectionTest();

                project.AddGeneratedFile($"Mock/{resource.Type.Name}Test.cs", codeWriter.ToString());
            }

            WriteExtensionTest(project, MgmtContext.Library.SubscriptionExtensionsClient);
            if (!MgmtContext.Library.TenantExtensions.IsEmpty)
            {
                WriteExtensionTest(project, MgmtContext.Library.TenantExtensionsClient);
            }

            bool hasScenarioTest = false;
            foreach (var scenarioTestDefinition in codeModel.TestModel?.ScenarioTests ?? new List<TestDefinitionModel>())
            {
                var codeWriter = new CodeWriter();
                var scenarioTestWriter = new ScenarioTestWriter(codeWriter, scenarioTestDefinition);
                scenarioTestWriter.WriteScenarioTest();

                project.AddGeneratedFile($"Scenario/{scenarioTestWriter.TypeName}Test.cs", codeWriter.ToString());
                hasScenarioTest = true;
            }

            if (hasScenarioTest)
            {
                var codeWriter = new CodeWriter();
                var testEnvironmentWriter = new TestEnvironmentWriter(codeWriter);
                testEnvironmentWriter.WriteTestEnvironment();

                project.AddGeneratedFile($"Scenario/{testEnvironmentWriter.TypeName}Test.cs", codeWriter.ToString());
            }
        }

        private static void WriteExtensionTest(GeneratedCodeWorkspace project, MgmtExtensionClient extensionClient)
        {
            var subscriptionExtensionsCodeWriter = new CodeWriter();
            new MgmtExtensionTestWriter(subscriptionExtensionsCodeWriter, extensionClient.Extension).Write();
            project.AddGeneratedFile($"Mock/{extensionClient.Extension.Type.Name}Test.cs", subscriptionExtensionsCodeWriter.ToString());
        }
    }
}
