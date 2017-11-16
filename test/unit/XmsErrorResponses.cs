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
    /// <summary>
    /// Tests semantics of x-ms-enum against https://review.docs.microsoft.com/en-us/new-hope/specs/reference/swagger-enums
    /// </summary>
    public class XmsErrorResponses : BugTest
    {
        public XmsErrorResponses(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task XmsErrorResponsesCompilationTests()
        {
            // simplified test pattern for unit testing aspects of code generation
            using (var fileSystem = GenerateCodeForTestFromSpec())
            {
                // Expected Files
                Assert.True(fileSystem.FileExists(@"Models/NotFoundErrorBase.cs"));
                Assert.True(fileSystem.FileExists(@"Models/BaseError.cs"));
                Assert.True(fileSystem.FileExists(@"Models/AnimalNotFound.cs"));
                Assert.True(fileSystem.FileExists(@"Models/LinkNotFoundException.cs"));
                Assert.True(fileSystem.FileExists(@"Models/AnimalNotFound.cs"));
                Assert.True(fileSystem.FileExists(@"Models/NotFoundErrorBaseException.cs"));

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

                // Don't proceed unless we have zero Warnings.
                Assert.Empty(warnings);

                // Don't proceed unless we have zero Errors.
                Assert.Empty(errors);

                // Should also succeed.
                Assert.True(result.Succeeded);

                // try to load the assembly
                var asm = LoadAssembly(result.Output);
                Assert.NotNull(asm);
            }
        }
    }
}
