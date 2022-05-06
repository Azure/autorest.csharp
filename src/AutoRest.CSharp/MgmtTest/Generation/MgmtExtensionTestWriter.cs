// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;
using AutoRest.CSharp.Mgmt.AutoRest;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    /// <summary>
    /// Code writer for resource test.
    /// </summary>
    internal class MgmtExtensionTestWriter : MgmtBaseTestWriter
    {
        protected string TestNamespace => MgmtContext.Library.ExtensionWrapper.Type.Namespace + ".Tests.Mock";
        protected string TypeNameOfThis => MgmtContext.Library.ExtensionWrapper.Type.Name + "MockTests";

        protected string TestBaseName => $"MockTestBase";

        public MgmtExtensionTestWriter(CodeWriter writer) : base(writer, MgmtContext.Library.ExtensionWrapper)
        {
        }

        public override void Write()
        {
            WriteUsings(_writer);

            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test for {MgmtContext.Library.ExtensionWrapper.Type.Name}");
                _writer.Append($"public partial class {TypeNameOfThis:D} : ");
                _writer.Line($"{TestBaseName}");
                using (_writer.Scope())
                {
                    WriteTesterCtors();
                    foreach (var extensions in MgmtContext.Library.ExtensionWrapper.Extensions)
                        if (extensions != MgmtContext.Library.ArmClientExtensions)
                        {
                            foreach (var clientOperation in extensions.ClientOperations)
                            {
                                _writer.Line();
                                WriteTestMethod(extensions, clientOperation, true, false);
                            }
                        }
                }
            }
        }

        protected void WriteUsings(CodeWriter writer)
        {
            writer.UseNamespace("Azure.Core.TestFramework");
            writer.UseNamespace("Azure.ResourceManager.TestFramework");
        }

        protected void WriteTesterCtors()
        {
            _writer.Line();
            using (_writer.Scope($"public {TypeNameOfThis}(bool isAsync): base(isAsync, RecordedTestMode.Record)"))
            {
                WriteMockTestContext();
            }
        }

        protected void WriteTestMethod(MgmtExtensions extensions, MgmtClientOperation clientOperation, bool async, bool isLroOperation)
        {
            var methodName = clientOperation.Name;
            foreach ((var branch, var operation) in GetSortedOperationMappings(clientOperation))
            {
                var exampleGroup = MgmtBaseTestWriter.FindExampleGroup(operation);
                if (exampleGroup is null || exampleGroup.Examples.Count == 0)
                    continue;

                foreach (var exampleModel in exampleGroup.Examples)
                {
                    if (!ShouldWriteTest(clientOperation, exampleModel))
                        continue;
                    WriteTestDecorator();
                    _writer.Append($"public {GetAsyncKeyword(async)} {MgmtBaseTestWriter.GetTaskOrVoid(async)} {CreateTestMethodName(methodName)}()");
                    using (_writer.Scope())
                    {
                        _writer.LineRaw($"// Example: {exampleModel.Name}");
                        WriteOperationInvocation(extensions, clientOperation, operation, exampleModel, async, isLroOperation);
                    }
                    _writer.Line();
                }
            }
        }

        public bool WriteOperationInvocation(MgmtExtensions extensions, MgmtClientOperation clientOperation, MgmtRestOperation restOperation, ExampleModel exampleModel, bool async, bool isLroOperation)
        {
            var testMethodName = CreateMethodName(clientOperation.Name, async);
            var resourceIdentifierParams = ComposeResourceIdentifierParams(restOperation.RequestPath, exampleModel);
            var resourceVariableName = new CodeWriterDeclaration(extensions.ResourceName.FirstCharToLowerCase());
            _writer.Line($"var {resourceVariableName:D} ={WriteGetExtension(extensions, restOperation.RequestPath, exampleModel)};");
            List<KeyValuePair<string, FormattableString>> parameterValues = WriteOperationParameters(clientOperation.MethodParameters.Skip(1), exampleModel);

            _writer.Line();
            WriteMethodTestInvocation(async, clientOperation, isLroOperation, $"{resourceVariableName}.{testMethodName}", parameterValues.Select(pv => pv.Value));
            return true;
        }
    }
}
