// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
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
        }
    }
}
