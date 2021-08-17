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
            var mockExtensionWriter = new TestHelperWriter(extensionsWriter, context);
            mockExtensionWriter.WriteMockExtension();
            project.AddGeneratedFile($"Mock/TestHelper.cs", extensionsWriter.ToString());

            foreach (var resourceCollection in context.Library.ResourceCollections)
            {
                if (!MgmtBaseTestWriter.CanCreateParentResourceFromExample(context, resourceCollection))
                {
                    continue;
                }
                if (!MgmtBaseTestWriter.HasCreateExample(context, resourceCollection)
                    // && !MgmtBaseTestWriter.HasGetExample(context, resourceCollection) // disable since can't successed in stateful mock test. enable this if use stateless mock test
                    )
                {
                    continue;
                }
                var codeWriter = new CodeWriter();
                var collectionTestWriter = new ResourceCollectionTestWriter(codeWriter, resourceCollection, context);
                collectionTestWriter.WriteCollectionTest();

                project.AddGeneratedFile($"Mock/{resourceCollection.Type.Name}Test.cs", codeWriter.ToString());
            }

            foreach (var resource in context.Library.ArmResources)
            {
                if (!MgmtBaseTestWriter.CanCreateResourceFromExample(context, resource.ResourceCollection))
                {
                    continue;
                }

                var codeWriter = new CodeWriter();
                var collectionTestWriter = new ResourceTestWriter(codeWriter, resource, context);
                collectionTestWriter.WriteCollectionTest();

                project.AddGeneratedFile($"Mock/{resource.Type.Name}Test.cs", codeWriter.ToString());
            }
        }
    }
}
