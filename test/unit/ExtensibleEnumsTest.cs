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
using Microsoft.Rest;
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
            var settings = new Settings{
                Namespace = "ExtensibleEnums"
            };
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

                Write(warnings, fileSystem);
                Write(errors, fileSystem);

                // use this to write out all the messages, even hidden ones.
                // Write(result.Messages, fileSystem);

                // Don't proceed unless we have zero warnings.
                Assert.Empty(warnings);

                // Don't proceed unless we have zero Errors.
                Assert.Empty(errors);

                // Should also succeed.
                Assert.True(result.Succeeded);

                // try to load the assembly
                var asm = LoadAssembly(result.Output);
                Assert.NotNull(asm);

                var extensibleEnumsModel = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "ExtensibleEnums.Models.Category");
                Assert.NotNull(extensibleEnumsModel);

                var enumVals = extensibleEnumsModel.GetFields().Where(f=>f.IsPublic && f.IsStatic && f.DeclaringType.ToString() == "ExtensibleEnums.Models.Category");
                Assert.Equal(enumVals.Count(), 4);
                Assert.True(Enumerable.SequenceEqual(enumVals.Select(val=>val.GetValue(null).ToString()), 
                    new List<string>(){"HighAvailability", "Security", "Performance", "Cost" }));
            }
            
        }
    }
}