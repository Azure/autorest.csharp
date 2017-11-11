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
    public class Bug1560 : BugTest
    {
        public Bug1560(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        ///     https://github.com/Azure/autorest/issues/1560
        ///     Obsolete attribute does not get applied to all generated c# methods.
        /// </summary>
        [Fact]
        public async Task MarkAllDeprecatedOperationVariantsObsolete()
        {
            using (var fileSystem = GenerateCodeForTestFromSpec())
            {
                // Expected Files
                Assert.True(fileSystem.FileExists("Models/ResultObject.cs"));
                Assert.True(fileSystem.FileExists("Interfaces/IDeprecated.cs"));
                Assert.True(fileSystem.FileExists("Operations/Deprecated.cs"));
                Assert.True(fileSystem.FileExists("Operations/DeprecatedWithHttpMessages.cs"));
                Assert.True(fileSystem.FileExists("Interfaces/IApproved.cs"));
                Assert.True(fileSystem.FileExists("Operations/Approved.cs"));
                Assert.True(fileSystem.FileExists("Operations/ApprovedWithHttpMessages.cs"));

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

                // verify that deprecated_operations are marked correctly
                var deprecatedInterface = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.IDeprecatedWithHttpMessages");
                Assert.NotNull(deprecatedInterface);
                Assert.NotNull(deprecatedInterface.GetMethod("OperationAsync").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                var deprecatedClass = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.DeprecatedWithHttpMessages");
                Assert.NotNull(deprecatedClass);
                Assert.NotNull(deprecatedClass.GetMethod("OperationAsync").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                var deprecatedExtensions = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.Deprecated");
                Assert.NotNull(deprecatedExtensions);
                Assert.NotNull(deprecatedExtensions.GetMethod("Operation").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
                Assert.NotNull(deprecatedExtensions.GetMethod("OperationAsync").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                // verify the other operations are not marked as deprecated
                var approvedInterface = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.IApprovedWithHttpMessages");
                Assert.NotNull(approvedInterface);
                Assert.Null(approvedInterface.GetMethod("OperationAsync").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                var approvedClass = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.ApprovedWithHttpMessages");
                Assert.NotNull(approvedClass);
                Assert.Null(approvedClass.GetMethod("OperationAsync").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                var approvedExtensions = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.Approved");
                Assert.NotNull(approvedExtensions);
                Assert.Null(approvedExtensions.GetMethod("Operation").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
                Assert.Null(approvedExtensions.GetMethod("OperationAsync").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
            }
        }

        /// <summary>
        ///     https://github.com/Azure/autorest/issues/1560
        ///     Obsolete attribute does not get applied to all generated c# methods.
        /// </summary>
        [Fact]
        public async Task MarkAllDeprecatedOperationVariantsObsoleteAzure()
        {
            using (var fileSystem = GenerateCodeForTestFromSpec(new AutoRest.CSharp.Azure.PluginCsa()))
            {
                // Expected Files
                Assert.True(fileSystem.FileExists("Models/ResultObject.cs"));
                Assert.True(fileSystem.FileExists("Interfaces/IDeprecatedOperations.cs"));
                Assert.True(fileSystem.FileExists("Operations/DeprecatedOperations.cs"));
                Assert.True(fileSystem.FileExists("Operations/DeprecatedOperationsWithHttpMessages.cs"));
                Assert.True(fileSystem.FileExists("Interfaces/IApprovedOperations.cs"));
                Assert.True(fileSystem.FileExists("Operations/ApprovedOperations.cs"));
                Assert.True(fileSystem.FileExists("Operations/ApprovedOperationsWithHttpMessages.cs"));

                var result = await Compile(fileSystem);

                // filter the warnings
                var warnings = result.Messages.Where(
                    each => each.Severity == DiagnosticSeverity.Warning
                            && !SuppressWarnings.Contains(each.Id)).ToArray();

                // use this to dump the files to disk for examination
                // fileSystem.SaveFilesToTemp("bug1285");

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

                // verify that deprecated_operations are marked correctly
                var deprecatedInterface = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.IDeprecatedOperationsWithHttpMessages");
                Assert.NotNull(deprecatedInterface);
                Assert.NotNull(deprecatedInterface.GetMethod("OperationAsync").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                var deprecatedClass = asm.DefinedTypes.FirstOrDefault(each => each.FullName == "Test.DeprecatedOperationsWithHttpMessages");
                Assert.NotNull(deprecatedClass);
                Assert.NotNull(deprecatedClass.GetMethod("OperationAsync").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                var deprecatedExtensions = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.DeprecatedOperations");
                Assert.NotNull(deprecatedExtensions);
                Assert.NotNull(deprecatedExtensions.GetMethod("Operation").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
                Assert.NotNull(deprecatedExtensions.GetMethod("OperationAsync").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                // verify the other operations are not marked as deprecated
                var approvedInterface = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.IApprovedOperationsWithHttpMessages");
                Assert.NotNull(approvedInterface);
                Assert.Null(approvedInterface.GetMethod("OperationAsync").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                var approvedClass = asm.DefinedTypes.FirstOrDefault(each => each.FullName == "Test.ApprovedOperationsWithHttpMessages");
                Assert.NotNull(approvedClass);
                Assert.Null(approvedClass.GetMethod("OperationAsync").GetCustomAttribute(typeof(System.ObsoleteAttribute)));

                var approvedExtensions = asm.ExportedTypes.FirstOrDefault(each => each.FullName == "Test.ApprovedOperations");
                Assert.NotNull(approvedExtensions);
                Assert.Null(approvedExtensions.GetMethod("Operation").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
                Assert.Null(approvedExtensions.GetMethod("OperationAsync").GetCustomAttribute(typeof(System.ObsoleteAttribute)));
            }
        }
    }
}