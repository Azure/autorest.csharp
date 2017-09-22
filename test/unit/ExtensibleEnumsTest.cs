// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoRest.Core;
using AutoRest.Core.Utilities;
using Microsoft.CodeAnalysis;
using Xunit;
using Xunit.Abstractions;

namespace AutoRest.CSharp.Unit.Tests
{
    public class ExtensibleEnumsTest : BugTest
    {
        public ExtensibleEnumsTest(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        ///     https://github.com/Azure/autorest/issues/1591
        ///     C# codegen generates extensible enums
        /// </summary>
        [Fact]
        public async Task CheckGeneratesValidCSharp()
        {
            var settings = new Settings();
            settings.CustomSettings.Add("ExtensibleEnums", true);
            
            using (var fileSystem = $"{GetType().Name}".GenerateCodeInto(new MemoryFileSystem(), settings))
            {
                // if newlines and stuff aren't excaped properly, compilation will fail
                var result = await Compile(fileSystem);
                
                // filter the warnings
                var warnings = result.Messages.Where(
                    each => each.Severity == DiagnosticSeverity.Warning
                            && !SuppressWarnings.Contains(each.Id)).ToArray();
                
                // filter the errors
                var errors = result.Messages.Where(each => each.Severity == DiagnosticSeverity.Error).ToArray();
                
                Assert.True(true);

                //Write(warnings, fileSystem);
                //Write(errors, fileSystem);

                // use this to write out all the messages, even hidden ones.
                // Write(result.Messages, fileSystem);

                // Don't proceed unless we have zero warnings.
                Assert.Empty(warnings);

                System.IO.StreamWriter logfile = new System.IO.StreamWriter(@"F:\artemp\rcm\autorest.csharp\src\bin\netcoreapp2.0\log.log", false);
                foreach(var err in errors)
                {
                        logfile.WriteLine(err.ToString());
                }
                    
                    logfile.Close();
                    

                // Don't proceed unless we have zero Errors.
                Assert.Empty(errors);

                // Should also succeed.
                Assert.True(result.Succeeded);

                // try to load the assembly
                var asm = LoadAssembly(result.Output);
                Assert.NotNull(asm);

                /*
                foreach(var name in asm.ExportedTypes)
                {
                    System.Console.WriteLine("Type is");
                    System.Console.WriteLine(name.FullName);
                }
                
                //var extensibleEnumsModel = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "ExtensibleEnums.Models.Category");
                //Assert.NotNull(testApi);
                */
               
            }
            
        }
    }
}