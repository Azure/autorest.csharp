// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 


using AutoRest.Core.Utilities;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Xunit;
using Xunit.Abstractions;

namespace AutoRest.CSharp.Unit.Tests
{
    public class BatchTestSpecs : BugTest
    {
        public BatchTestSpecs(ITestOutputHelper output) : base(output)
        {
        }
        /// <summary>
        ///   Generates code for all JSON and YAML files in a folder and verifies the project compiles without error
        /// </summary>
        /// Comment out the Skip and update the path below to run
        [Fact(Skip = "Manual Test")]  
        public async Task BatchTest()
        {
            var path = new DirectoryInfo(@"C:\PathToSpecs");
            Assert.True(path.Exists, $"{path} does not exist");

            // get all of the json and yaml files from filesystem
            var files = path.GetFiles("*.json", SearchOption.AllDirectories).Concat(path.GetFiles("*.yaml", SearchOption.AllDirectories));
            Assert.True(files.Count() > 0, $"{path} does not contain any json or yaml files");

            foreach (var file in files)
            {
                // Comment this block out if not needed
                if (!File.ReadAllText(file.FullName).Contains(@"""swagger"": ""2.0"""))
                {
                    //skip files that are not swagger files.
                    continue;
                }

                using (var memoryFileSystem = GenerateCodeForTestFromSpec(dirName: file.FullName))
                {
                    // Expected Files
                    Assert.True(memoryFileSystem.GetFiles("", "*.cs", SearchOption.TopDirectoryOnly).GetUpperBound(0) > 0);
                    Assert.True(memoryFileSystem.GetFiles("Models", "*.cs", SearchOption.TopDirectoryOnly).GetUpperBound(0) > 0);

                    var result = await Compile(memoryFileSystem);

                    // filter the warnings
                    var warnings = result.Messages.Where(
                        each => each.Severity == DiagnosticSeverity.Warning
                                && !SuppressWarnings.Contains(each.Id)).ToArray();

                    // use this to dump the files to disk for examination
                    // memoryFileSystem.SaveFilesToTemp(file.Name);

                    // filter the errors
                    var errors = result.Messages.Where(each => each.Severity == DiagnosticSeverity.Error).ToArray();

                    Write(warnings, memoryFileSystem);
                    Write(errors, memoryFileSystem);

                    // use this to write out all the messages, even hidden ones.
                    // Write(result.Messages, memoryFileSystem);

                    // Don't proceed unless we have zero Warnings.
                    Assert.Empty(warnings);

                    // Don't proceed unless we have zero Errors.
                    Assert.Empty(errors);

                    // Should also succeed.
                    Assert.True(result.Succeeded);
                }
            }
        }
    }
}