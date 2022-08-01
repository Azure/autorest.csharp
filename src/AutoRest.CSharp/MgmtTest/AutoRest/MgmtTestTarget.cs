// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.MgmtTest.AutoRest;
using AutoRest.CSharp.MgmtTest.Generation.Mock;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class MgmtTestTarget
    {
        public static async Task ExecuteAsync(GeneratedCodeWorkspace project, CodeModel codeModel)
        {
            Debug.Assert(codeModel.TestModel is not null);
            Debug.Assert(Configuration.MgmtConfiguration.TestModeler is not null);

            var sourceCodePath = GetSourceCodePath();
            var sourceCodeProject = new SourceCodeProject(sourceCodePath, Configuration.SharedSourceFolders);
            var sourceInputModel = new SourceInputModel(await sourceCodeProject.GetCompilationAsync());

            // construct the MgmtTestOutputLibrary
            var library = new MgmtTestOutputLibrary(codeModel, sourceInputModel);

            // write the collection mock tests
            foreach (var collectionTest in library.ResourceCollectionMockTests)
            {
                var collectionTestWriter = new ResourceCollectionMockTestWriter(new CodeWriter(), collectionTest);
                collectionTestWriter.Write();

                project.AddGeneratedFile($"Mock/{collectionTest.Type.Name}.cs", collectionTestWriter.ToString());
            }

            foreach (var resourceTest in library.ResourceMockTests)
            {
                var resourceTestWriter = new ResourceMockTestWriter(new CodeWriter(), resourceTest);
                resourceTestWriter.Write();

                project.AddGeneratedFile($"Mock/{resourceTest.Type.Name}.cs", resourceTestWriter.ToString());
            }

            var extensionWrapperTest = library.ExtensionWrapperMockTest;
            var extensionWrapperTestWriter = new ExtensionWrapMockTestWriter(new CodeWriter(), extensionWrapperTest, library.ExtensionMockTests);
            extensionWrapperTestWriter.Write();

            project.AddGeneratedFile($"Mock/{extensionWrapperTest.Type.Name}.cs", extensionWrapperTestWriter.ToString());
        }

        private static string GetSourceCodePath()
        {
            if (Configuration.MgmtConfiguration.TestModeler?.SourceCodePath != null)
                return Configuration.MgmtConfiguration.TestModeler.SourceCodePath;

            return Path.Combine(Configuration.OutputFolder, "../../src");
        }
    }
}
