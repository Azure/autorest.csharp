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
        public static void Execute(GeneratedCodeWorkspace project, CodeModel codeModel, SourceInputModel? sourceInputModel, Configuration configuration)
        {
            BuildContext<MgmtOutputLibrary> context = new BuildContext<MgmtOutputLibrary>(codeModel, configuration, sourceInputModel);
            var extensionsWriter = new CodeWriter();

            bool hasCollectionTest = false;
            foreach (var resourceCollection in context.Library.ResourceCollections)
            {
                var codeWriter = new CodeWriter();
                var collectionTestWriter = new ResourceCollectionTestWriter(codeWriter, resourceCollection, context);
                if (!collectionTestWriter.CanCreateParentResourceFromExample(context, resourceCollection))
                {
                    continue;
                }
                if (!MgmtBaseTestWriter.HasCreateExample(context, resourceCollection)
                    && !MgmtBaseTestWriter.HasGetExample(context, resourceCollection))
                {
                    continue;
                }
                collectionTestWriter.WriteCollectionTest();

                project.AddGeneratedFile($"Mock/{resourceCollection.Type.Name}Test.cs", codeWriter.ToString());
                hasCollectionTest = true;
            }

            if (hasCollectionTest)
            {
                var mockExtensionWriter = new TestHelperWriter(extensionsWriter, context);
                mockExtensionWriter.WriteMockExtension();
                project.AddGeneratedFile($"Mock/TestHelper.cs", extensionsWriter.ToString());
            }

            foreach (var resource in context.Library.ArmResources)
            {
                var codeWriter = new CodeWriter();
                var resourceTestWriter = new ResourceTestWriter(codeWriter, resource, context);
                if (!resourceTestWriter.CanCreateResourceFromExample(context, resource.ResourceCollection))
                {
                    continue;
                }

                resourceTestWriter.WriteCollectionTest();

                project.AddGeneratedFile($"Mock/{resource.Type.Name}Test.cs", codeWriter.ToString());
            }
        }
    }
}
