// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.MgmtTest.AutoRest;
using AutoRest.CSharp.MgmtTest.Generation.Mock;
using AutoRest.CSharp.MgmtTest.Generation.Samples;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class MgmtTestTarget
    {
        public static void Execute(GeneratedCodeWorkspace project, CodeModel codeModel, SourceInputModel sourceInputModel)
        {
            Debug.Assert(codeModel.TestModel is not null);
            Debug.Assert(Configuration.MgmtTestConfiguration is not null);

            // construct the MgmtTestOutputLibrary
            var library = new MgmtTestOutputLibrary(codeModel, sourceInputModel);

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

            if (Configuration.MgmtTestConfiguration.ClearOutputFolder)
            {
                ClearTestGenOutputFolder();
            }
        }

        private static void WriteMockTests(GeneratedCodeWorkspace project, MgmtTestOutputLibrary library)
        {
            string outputFolder = GetTestGenOutputFolder();

            // write the collection mock tests
            foreach (var collectionTest in library.ResourceCollectionMockTests)
            {
                var collectionTestWriter = new ResourceCollectionMockTestWriter(collectionTest);
                collectionTestWriter.Write();

                AddGeneratedFile(project, Path.Combine(outputFolder, $"Mock/{collectionTest.Type.Name}.cs"), collectionTestWriter.ToString());
            }

            foreach (var resourceTest in library.ResourceMockTests)
            {
                var resourceTestWriter = new ResourceMockTestWriter(resourceTest);
                resourceTestWriter.Write();

                AddGeneratedFile(project, Path.Combine(outputFolder, $"Mock/{resourceTest.Type.Name}.cs"), resourceTestWriter.ToString());
            }

            var extensionWrapperTest = library.ExtensionWrapperMockTest;
            var extensionWrapperTestWriter = new ExtensionWrapMockTestWriter(extensionWrapperTest, library.ExtensionMockTests);
            extensionWrapperTestWriter.Write();

            AddGeneratedFile(project, Path.Combine(outputFolder, $"Mock/{extensionWrapperTest.Type.Name}.cs"), extensionWrapperTestWriter.ToString());
        }

        private static void WriteSamples(GeneratedCodeWorkspace project, MgmtTestOutputLibrary library)
        {
            string outputFolder = GetTestGenOutputFolder();

            var names = new Dictionary<string, int>();
            foreach (var sample in library.Samples)
            {
                var sampleWriter = new MgmtSampleWriter(sample);
                sampleWriter.Write();

                var filename = GetFilename(sample.Type.Name, names);
                AddGeneratedFile(project, Path.Combine(outputFolder, $"Samples/{filename}.cs"), sampleWriter.ToString());
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

        private static string GetTestGenOutputFolder()
        {
            if (Configuration.MgmtTestConfiguration == null ||
                string.IsNullOrEmpty(Configuration.MgmtTestConfiguration.OutputFolder))
                return Configuration.OutputFolder;
            else
                return Configuration.MgmtTestConfiguration.OutputFolder;
        }

        private static void ClearTestGenOutputFolder()
        {
            if (Configuration.MgmtTestConfiguration == null ||
                string.IsNullOrEmpty(Configuration.MgmtTestConfiguration.OutputFolder))
                return;
            DirectoryInfo di = new DirectoryInfo(Configuration.MgmtTestConfiguration.OutputFolder);
            ClearFolder(di);
        }

        private static void ClearFolder(DirectoryInfo di)
        {
            if (di.Exists)
            {
                foreach (FileInfo fi in di.EnumerateFiles())
                {
                    try
                    {
                        fi.Delete();
                    }
                    // Ignore the error from clearing folder
                    catch { }
                }
                foreach (DirectoryInfo subFolder in di.EnumerateDirectories())
                {
                    ClearFolder(subFolder);
                    try
                    {
                        subFolder.Delete();
                    }
                    // Ignore the error from clearing folder
                    catch { }
                }
            }
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
