// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.MgmtTest.AutoRest;
using AutoRest.CSharp.MgmtTest.Generation.Mock;
using AutoRest.CSharp.MgmtTest.Generation.Sample;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class MgmtTestTarget
    {
        public static async Task ExecuteAsync(GeneratedCodeWorkspace project, CodeModel codeModel)
        {
            Debug.Assert(codeModel.TestModel is not null);
            Debug.Assert(Configuration.MgmtConfiguration.TestGen is not null);

            var sourceCodePath = GetSourceCodePath();
            var sourceCodeProject = new SourceCodeProject(sourceCodePath, Configuration.SharedSourceFolders);
            var sourceInputModel = new SourceInputModel(await sourceCodeProject.GetCompilationAsync());

            // construct the MgmtTestOutputLibrary
            var library = new MgmtTestOutputLibrary(codeModel, sourceInputModel);

            if (Configuration.MgmtConfiguration.TestGen.Mock)
            {
                WriteMockTests(project, library);
            }

            if (Configuration.MgmtConfiguration.TestGen.Sample)
            {
                WriteSamples(project, library);
            }
        }

        private static void WriteMockTests(GeneratedCodeWorkspace project, MgmtTestOutputLibrary library)
        {
            // write the collection mock tests
            foreach (var collectionTest in library.ResourceCollectionMockTests)
            {
                var collectionTestWriter = new ResourceCollectionMockTestWriter(collectionTest);
                collectionTestWriter.Write();

                project.AddGeneratedFile($"Mock/{collectionTest.Type.Name}.cs", collectionTestWriter.ToString());
            }

            foreach (var resourceTest in library.ResourceMockTests)
            {
                var resourceTestWriter = new ResourceMockTestWriter(resourceTest);
                resourceTestWriter.Write();

                project.AddGeneratedFile($"Mock/{resourceTest.Type.Name}.cs", resourceTestWriter.ToString());
            }

            var extensionWrapperTest = library.ExtensionWrapperMockTest;
            var extensionWrapperTestWriter = new ExtensionWrapMockTestWriter(extensionWrapperTest, library.ExtensionMockTests);
            extensionWrapperTestWriter.Write();

            project.AddGeneratedFile($"Mock/{extensionWrapperTest.Type.Name}.cs", extensionWrapperTestWriter.ToString());
        }

        private static void WriteSamples(GeneratedCodeWorkspace project, MgmtTestOutputLibrary library)
        {
            var names = new Dictionary<string, int>();
            foreach (var sample in library.Samples)
            {
                var sampleWriter = new MgmtSampleWriter(sample);
                sampleWriter.Write();

                var filename = GetFilename(sample.Type.Name, names);
                project.AddGeneratedFile($"Samples/{filename}.cs", sampleWriter.ToString());
            }
        }

        private static string GetFilename(string name, Dictionary<string, int> names)
        {
            if (names.TryGetValue(name, out var count))
            {
                names[name]++;
                return $"{name}{count}";
            }

            names[name] = 1;
            return name;
        }

        private static string GetSourceCodePath()
        {
            if (Configuration.MgmtConfiguration.TestGen?.SourceCodePath != null)
                return Configuration.MgmtConfiguration.TestGen.SourceCodePath;

            return Path.Combine(Configuration.OutputFolder, "../../src");
        }
    }
}
