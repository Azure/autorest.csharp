// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.MgmtTest.AutoRest;
using AutoRest.CSharp.MgmtTest.Generation.Mock;
using System.Collections.Generic;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class MgmtTestTarget
    {
        public static void Execute(GeneratedCodeWorkspace project, CodeModel codeModel, SourceInputModel? sourceInputModel)
        {
            Debug.Assert(codeModel.TestModel is not null);
            Debug.Assert(Configuration.MgmtConfiguration.TestModeler is not null);

            // contruct the MgmtTestOutputLibrary
            var library = new MgmtTestOutputLibrary(codeModel, sourceInputModel);

            // write the collection mock tests
            foreach (var collectionTest in library.ResourceCollectionMockTests)
            {
                try
                {
                    var collectionTestWriter = new ResourceCollectionMockTestWriter(new CodeWriter(), collectionTest);
                    collectionTestWriter.Write();

                    project.AddGeneratedFile($"Mock/{collectionTest.Type.Name}.cs", collectionTestWriter.ToString());
                }
                catch
                {
                    // System.Console.WriteLine(ex.ToString());
                }
            }

            foreach (var resourceTest in library.ResourceMockTests)
            {
                try
                {
                    var resourceTestWriter = new ResourceMockTestWriter(new CodeWriter(), resourceTest);
                    resourceTestWriter.Write();

                    project.AddGeneratedFile($"Mock/{resourceTest.Type.Name}.cs", resourceTestWriter.ToString());
                }
                catch
                {
                    // System.Console.WriteLine(ex.ToString());
                }
        }

            var extensionWrapperTest = library.ExtensionWrapperMockTest;
            try
            {
                var extensionWrapperTestWriter = new ExtensionWrapMockTestWriter(new CodeWriter(), extensionWrapperTest, library.ExtensionMockTests);
                extensionWrapperTestWriter.Write();

                project.AddGeneratedFile($"Mock/{extensionWrapperTest.Type.Name}.cs", extensionWrapperTestWriter.ToString());
            }
            catch
            {
                // System.Console.WriteLine(ex.ToString());
            }


            if (Configuration.MgmtConfiguration.TestModeler.GenerateSdkSample == false)
                return;

            var generated = new HashSet<string>();
            foreach (var collectionTest in library.ResourceCollectionMockTests)
            {
                foreach (var testCase in collectionTest.MockTestCases)
                {
                    try
                    {
                        var collectionTestWriter = new ResourceCollectionMockTestWriter(new CodeWriter(), collectionTest);
                        collectionTestWriter.WriteSample(testCase);
                        var filename = GenExampleFileName(testCase);
                        if (!generated.Contains(filename))
                        {
                            project.AddGeneratedFile(filename, collectionTestWriter.ToString());
                            generated.Add(filename);
                        }
                    }
                    catch
                    {
                        // System.Console.WriteLine(ex.ToString());
                    }
                }
            }

            foreach (var resourceTest in library.ResourceMockTests)
            {
                foreach (var testCase in resourceTest.MockTestCases)
                {
                    try
                    {
                        var resourceTestWriter = new ResourceMockTestWriter(new CodeWriter(), resourceTest);
                        resourceTestWriter.WriteSample(testCase);
                        var filename = GenExampleFileName(testCase);
                        if (!generated.Contains(filename))
                        {
                            project.AddGeneratedFile(filename, resourceTestWriter.ToString());
                            generated.Add(filename);
                        }
                    }
                    catch
                    {
                        // System.Console.WriteLine(ex.ToString());
                    }
                }
            }
            foreach (var testCase in extensionWrapperTest.MockTestCases)
            {
                try
                {
                    var extensionWrapperTestWriter2 = new ExtensionWrapMockTestWriter(new CodeWriter(), extensionWrapperTest, library.ExtensionMockTests);
                    extensionWrapperTestWriter2.WriteSample(testCase);
                    var filename = GenExampleFileName(testCase);
                    if (!generated.Contains(filename))
                    {
                        project.AddGeneratedFile(GenExampleFileName(testCase), extensionWrapperTestWriter2.ToString());
                        generated.Add(filename);
                    }
                }
                catch
                {
                    // System.Console.WriteLine(ex.ToString());
                }
            }
        }

        private static string GenExampleFileName(MockTestCase testCase)
        {
            return $"../../Samples/Generated/{testCase.RestOperation.Operation.OperationId}$${testCase.Example.Name}.cs";
        }
    }
}
