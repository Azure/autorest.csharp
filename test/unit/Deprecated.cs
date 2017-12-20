// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Xunit;
using Xunit.Abstractions;

namespace AutoRest.CSharp.Unit.Tests
{
    public class Deprecated : BugTest
    {
        public Deprecated(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        ///     https://github.com/Azure/autorest/issues/1285
        ///     Deprecated on: methods, model classes, properties
        /// </summary>
        [Fact]
        public async Task DeprecatedOnLotsOfStuff()
        {
            // simplified test pattern for unit testing aspects of code generation
            using (var fileSystem = GenerateCodeForTestFromSpec())
            {
                // check for the expected class.
                Assert.True(fileSystem.FileExists(@"PathExtensions.cs"));
                Assert.True(fileSystem.FileExists(@"Models/PetNo.cs"));
                Assert.True(fileSystem.FileExists(@"Models/PetYes.cs"));
                Assert.True(fileSystem.FileExists(@"Models/Pet.cs"));
                Assert.True(fileSystem.FileExists(@"Models/ChildPet.cs"));
                Assert.True(fileSystem.FileExists(@"Models/Enum1No.cs"));
                Assert.True(fileSystem.FileExists(@"Models/Enum1Yes.cs"));
                Assert.True(fileSystem.FileExists(@"Models/Enum2No.cs"));
                Assert.True(fileSystem.FileExists(@"Models/Enum2Yes.cs"));
                Assert.True(fileSystem.FileExists(@"Models/Enum3No.cs"));
                Assert.True(fileSystem.FileExists(@"Models/Enum3Yes.cs"));

                var result = await Compile(fileSystem);

                // filter the warnings
                var warnings = result.Messages.Where(
                    each => each.Severity == DiagnosticSeverity.Warning
                            && !SuppressWarnings.Contains(each.Id)).ToArray();

                // filter the errors
                var errors = result.Messages.Where(each => each.Severity == DiagnosticSeverity.Error).ToArray();

                Write(warnings, fileSystem);
                Write(errors, fileSystem);

                // Don't proceed unless we have zero Warnings (except "obsolete" stuff).
                Assert.Empty(warnings.Where(x => !x.GetMessage().Contains("obsolete")));

                // Don't proceed unless we have zero Errors.
                Assert.Empty(errors);

                // Should also succeed.
                Assert.True(result.Succeeded);

                // try to load the assembly
                var asm = LoadAssembly(result.Output);
                Assert.NotNull(asm);


                // VALIDATE
                
                // - method
                var approvedExtensions = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.PathExtensions");
                Assert.Null(approvedExtensions.GetMethod("No").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
                Assert.NotNull(approvedExtensions.GetMethod("Yes").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                // - class
                Assert.Null(asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.Models.PetNo").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
                Assert.NotNull(asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.Models.PetYes").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                // - enums
                Assert.Null(asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.Models.Enum1No").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
                Assert.NotNull(asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.Models.Enum1Yes").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
                Assert.Null(asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.Models.Enum2No").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
                Assert.NotNull(asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.Models.Enum2Yes").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
                Assert.Null(asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.Models.Enum3No").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
                Assert.NotNull(asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.Models.Enum3Yes").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                // - property
                var pet = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.Models.Pet");
                Assert.Null(pet.GetProperty("NameNo").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
                Assert.NotNull(pet.GetProperty("NameYes").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                // - property via type
                var pet2 = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.Models.ChildPet");
                Assert.Null(pet2.GetProperty("ParentNo").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
                Assert.Null(pet2.GetProperty("ParentYes").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
            }
        }
    }
}