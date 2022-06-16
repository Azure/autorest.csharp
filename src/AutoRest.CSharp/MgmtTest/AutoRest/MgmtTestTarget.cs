// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.AutoRest;
using AutoRest.CSharp.MgmtTest.Generation;
using AutoRest.CSharp.MgmtTest.Generation.Mock;
using AutoRest.CSharp.MgmtTest.Output;
using AutoRest.CSharp.MgmtTest.Output.Mock;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class MgmtTestTarget
    {
        public static void Execute(GeneratedCodeWorkspace project, CodeModel codeModel, SourceInputModel? sourceInputModel)
        {
            Debug.Assert(codeModel.TestModel is not null);
            Debug.Assert(Configuration.MgmtConfiguration.TestModeler is not null);

            // reads all the source code files from the disk
            if (Configuration.MgmtConfiguration.TestModeler.SourceCodePath == null)
                throw new InvalidOperationException("The configuration `test-modeler.source-path` must be specified.");
            var sourceCodeProject = new SourceCodeProject(Configuration.MgmtConfiguration.TestModeler.SourceCodePath);

            MgmtContext.Initialize(new BuildContext<MgmtOutputLibrary>(codeModel, sourceInputModel));

            // force trigger the model initialization
            foreach (var _ in MgmtContext.Library.ResourceSchemaMap)
            {
            }

            // contruct the MgmtTestOutputLibrary
            var library = new MgmtTestOutputLibrary();

            // write the collection mock tests
            foreach (var collectionTest in library.ResourceCollectionMockTests)
            {
                var collectionTestWriter = new ResourceCollectionMockTestWriter(new CodeWriter(), collectionTest);
                collectionTestWriter.Write();

                project.AddGeneratedFile($"Mock/{collectionTest.Type.Name}.cs", collectionTestWriter.ToString());
            }

            var extensionsWriter = new CodeWriter();
            var mockExtensionWriter = new TestHelperWriter(extensionsWriter);
            mockExtensionWriter.WriteMockExtension();
            project.AddGeneratedFile($"Mock/TestHelper.cs", extensionsWriter.ToString());

            foreach (var resource in MgmtContext.Library.ArmResources)
            {
                var codeWriter = new CodeWriter();
                var resourceTestWriter = new ResourceTestWriter(codeWriter, resource);
                resourceTestWriter.WriteCollectionTest();

                project.AddGeneratedFile($"Mock/{resource.Type.Name}Test.cs", codeWriter.ToString());
            }

            var subscriptionExtensionsCodeWriter = new CodeWriter();
            new MgmtExtensionTestWriter(subscriptionExtensionsCodeWriter).Write();
            project.AddGeneratedFile($"Mock/{MgmtContext.Library.ExtensionWrapper.Type.Name}Test.cs", subscriptionExtensionsCodeWriter.ToString());
        }
    }
}
