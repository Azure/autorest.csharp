// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Xunit;
using Xunit.Abstractions;

namespace AutoRest.CSharp.Unit.Tests
{
    public class Bug1587 : BugTest
    {
        public Bug1587(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        ///     https://github.com/Azure/autorest/issues/1587
        ///     `x-ms-long-running-operation: false` generates bad C# code.
        /// </summary>
        [Fact]
        public async Task CheckLruCodegenBehavior()
        {
            using (var fileSystem = GenerateCodeForTestFromSpec(new AutoRest.CSharp.Azure.PluginCsa()))
            {
                // Expected Files
                Assert.True(fileSystem.FileExists(@"Operations/SimpleAPIClientWithHttpMessages.cs"));

                // compilation is key in this test, as `x-ms-long-running-operation: false`
                // creates method that contains call to non-existent method.
                var result = await Compile(fileSystem);

                // filter the warnings
                var warnings = result.Messages.Where(
                    each => each.Severity == DiagnosticSeverity.Warning
                            && !SuppressWarnings.Contains(each.Id)).ToArray();

                // filter the errors
                var errors = result.Messages.Where(each => each.Severity == DiagnosticSeverity.Error).ToArray();

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

                // verify that correct methods exist.
                var simpleApi = asm.DefinedTypes.FirstOrDefault(each => each.FullName == "Test.SimpleAPIClientWithHttpMessages");
                Assert.NotNull(simpleApi);
                Assert.NotNull(simpleApi.GetMethod("Lru0Async"));
                Assert.NotNull(simpleApi.GetMethod("Lru1Async"));
                Assert.NotNull(simpleApi.GetMethod("Lru2Async"));
                Assert.Null(simpleApi.GetMethod("BeginLru0Async"));
                Assert.NotNull(simpleApi.GetMethod("BeginLru1Async"));
                Assert.Null(simpleApi.GetMethod("BeginLru2Async"));
            }
        }
    }
}