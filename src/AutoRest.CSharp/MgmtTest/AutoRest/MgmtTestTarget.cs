// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.MgmtTest.AutoRest;
using AutoRest.CSharp.MgmtTest.Generation.Mock;
using AutoRest.CSharp.MgmtTest.Generation.Samples;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class MgmtTestTarget
    {
        public static async Task ExecuteAsync(GeneratedCodeWorkspace project, CodeModel codeModel)
        {
            Debug.Assert(codeModel.TestModel is not null);
            Debug.Assert(Configuration.MgmtTestConfiguration is not null);

            var sourceCodePath = GetSourceCodePath();
            var sourceCodeProject = new SourceCodeProject(sourceCodePath, Configuration.SharedSourceFolders);
            var sourceInputModel = new SourceInputModel(await sourceCodeProject.GetCompilationAsync());

            // construct the MgmtTestOutputLibrary
            var library = new MgmtTestOutputLibrary(codeModel, sourceInputModel);

            // add the files in the source code project into the GeneratedCodeWorkspace so that our Roslyn could know how to simplify them
            project.AddDirectory(sourceCodePath);

            if (Configuration.MgmtTestConfiguration.Mock)
            {
                WriteMockTests(project, library);
            }

            if (Configuration.MgmtTestConfiguration.Sample)
            {
                WriteSamples(project, library);
            }

            if (_overriddenProjectFilenames.TryGetValue(project, out var overriddenFilenames))
                throw new InvalidOperationException($"At least one file was overridden during the generation process. Filenames are: {string.Join(", ", overriddenFilenames)}");
        }

        private static void WriteMockTests(GeneratedCodeWorkspace project, MgmtTestOutputLibrary library)
        {
            // write the collection mock tests
            foreach (var collectionTest in library.ResourceCollectionMockTests)
            {
                var collectionTestWriter = new ResourceCollectionMockTestWriter(collectionTest);
                collectionTestWriter.Write();

                AddGeneratedFile(project, $"Mock/{collectionTest.Type.Name}.cs", collectionTestWriter.ToString());
            }

            foreach (var resourceTest in library.ResourceMockTests)
            {
                var resourceTestWriter = new ResourceMockTestWriter(resourceTest);
                resourceTestWriter.Write();

                AddGeneratedFile(project, $"Mock/{resourceTest.Type.Name}.cs", resourceTestWriter.ToString());
            }

            var extensionWrapperTest = library.ExtensionWrapperMockTest;
            var extensionWrapperTestWriter = new ExtensionWrapMockTestWriter(extensionWrapperTest, library.ExtensionMockTests);
            extensionWrapperTestWriter.Write();

            AddGeneratedFile(project, $"Mock/{extensionWrapperTest.Type.Name}.cs", extensionWrapperTestWriter.ToString());
        }

        private static void WriteSamples(GeneratedCodeWorkspace project, MgmtTestOutputLibrary library)
        {
            var names = new Dictionary<string, int>();
            foreach (var sample in library.Samples)
            {
                var sampleWriter = new MgmtSampleWriter(sample);
                sampleWriter.Write();

                var filename = GetFilename(sample.Type.Name, names);
                AddGeneratedFile(project, $"Samples/{filename}.cs", sampleWriter.ToString());
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
            if (Configuration.MgmtTestConfiguration?.SourceCodePath != null)
                return Configuration.MgmtTestConfiguration.SourceCodePath;

            // try to find the sdk source code path according to the default folder structure
            // Azure.ResourceManager.XXX \ src <- default sdk source folder
            //                           \ samples \ Generated <- default sample output folder defined in msbuild
            return Path.Combine(Configuration.OutputFolder, "../../src");
        }

        private static IDictionary<GeneratedCodeWorkspace, ISet<string>> _addedProjectFilenames = new Dictionary<GeneratedCodeWorkspace, ISet<string>>();
        private static IDictionary<GeneratedCodeWorkspace, IList<string>> _overriddenProjectFilenames = new Dictionary<GeneratedCodeWorkspace, IList<string>>();

        private static void AddGeneratedFile(GeneratedCodeWorkspace project, string filename, string text)
        {
            if (!_addedProjectFilenames.TryGetValue(project, out var addedFileNames))
            {
                addedFileNames = new HashSet<string>();
                _addedProjectFilenames.Add(project, addedFileNames);
            }
            if (addedFileNames.Contains(filename))
            {
                if (!_overriddenProjectFilenames.TryGetValue(project, out var overriddenFileNames))
                {
                    overriddenFileNames = new List<string>();
                    _overriddenProjectFilenames.Add(project, overriddenFileNames);
                }
                overriddenFileNames.Add(filename);
            }
            else
            {
                addedFileNames.Add(filename);
            }
            project.AddGeneratedFile(filename, text);
        }
    }
}
