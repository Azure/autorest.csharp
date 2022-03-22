// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;
using AutoRest.CSharp.MgmtTest.TestCommon;
namespace AutoRest.CSharp.MgmtTest.Generation
{
    /// <summary>
    /// Code writer for resource test.
    /// </summary>
    internal class ResourceTestWriter : MgmtBaseTestWriter
    {
        private IEnumerable<MgmtClientOperation> _allOperation;
        protected string TestNamespace => This.Type.Namespace + ".Tests.Mock";
        private string TypeNameOfThis => This.Type.Name + "MockTests";

        protected string TestBaseName => $"MockTestBase";
        private Resource This { get; }

        public ResourceTestWriter(CodeWriter writer, Resource resource, IEnumerable<string>? scenarioVariables = default) : base(writer, resource, scenarioVariables)
        {
            This = resource;
            _allOperation = resource.AllOperations;
        }

        public void WriteCollectionTest()
        {
            WriteUsings(_writer);

            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test for {This.ResourceName}");
                _writer.Append($"public partial class {TypeNameOfThis:D} : ");
                _writer.Line($"{TestBaseName}");
                using (_writer.Scope())
                {
                    WriteTesterCtors();
                    WriteMethodTestIfExist(This);

                    foreach (var childResource in This.ChildResources)
                    {
                        _writer.Line();
                        if (childResource.IsSingleton)
                        {
                            WriteMethodTestIfExist(childResource);
                        }
                    }
                }
            }
        }

        private void WriteUsings(CodeWriter writer)
        {
            writer.UseNamespace("Azure.Core.TestFramework");
            writer.UseNamespace("Azure.ResourceManager.TestFramework");
        }

        protected void WriteMethodTestIfExist(Resource resource)
        {
            if (resource.GetOperation != null)
            {
                _writer.Line();
                WriteTestMethod(resource, resource.GetOperation, true, false);
            }
            if (resource.DeleteOperation != null)
            {
                _writer.Line();
                WriteTestMethod(resource, resource.DeleteOperation, true, true);
            }
            if (resource.UpdateOperation != null)
            {
                _writer.Line();
                WriteTestMethod(resource, resource.UpdateOperation, true, false);
            }
            foreach (var clientOperation in resource.ClientOperations)
            {
                _writer.Line();
                WriteTestMethod(resource, clientOperation, true, false);
            }
        }

        protected void WriteTesterCtors()
        {
            // write protected default constructor
            _writer.Line();
            using (_writer.Scope($"public {TypeNameOfThis}(bool isAsync): base(isAsync, RecordedTestMode.Record)"))
            {
                WriteMockTestContext();
            }
        }

        public FormattableString WriteGetResource(Resource resource, FormattableString resourceIdentifierParams, ExampleModel exampleModel)
        {
            var resourceVariableName = new CodeWriterDeclaration(resource.Type.Name.FirstCharToLowerCase());
            var idVar = new CodeWriterDeclaration($"{resource.Type.Name.FirstCharToLowerCase()}Id");
            _writer.Line($"var {idVar:D} = {resource.Type}.CreateResourceIdentifier({resourceIdentifierParams});");
            _writer.Line($"var {resourceVariableName:D} = GetArmClient().Get{resource.Type.Name}({idVar});");
            return $"{resourceVariableName}";
        }

        protected void WriteTestMethod(Resource resource, MgmtClientOperation clientOperation, bool async, bool isLroOperation)
        {
            var methodName = clientOperation.Name;

            int exampleIdx = 0;
            foreach ((var branch, var operation) in GetSortedOperationMappings(clientOperation))
            {
                var exampleGroup = MgmtBaseTestWriter.FindExampleGroup(operation);
                if (exampleGroup is null || exampleGroup.Examples.Count == 0)
                    continue;

                foreach (var exampleModel in exampleGroup.Examples)
                {
                    WriteTestDecorator();
                    _writer.Append($"public {GetAsyncKeyword(async)} {MgmtBaseTestWriter.GetTaskOrVoid(async)} {(resource == This ? "" : resource.Type.Name)}{CreateTestMethodName(methodName, exampleIdx)}()");

                    using (_writer.Scope())
                    {
                        _writer.LineRaw($"// Example: {exampleModel.Name}");
                        WriteOperationInvocation(resource, clientOperation, operation, exampleModel, async, isLroOperation);
                    }
                    _writer.Line();
                    exampleIdx++;
                }
            }
        }

        public void WriteOperationInvocation(Resource resource, MgmtClientOperation clientOperation, MgmtRestOperation restOperation, ExampleModel exampleModel, bool async, bool isLroOperation)
        {
            var testMethodName = CreateMethodName(clientOperation.Name, async);
            var resourceIdentifierParams = ComposeResourceIdentifierParams(resource.RequestPath, exampleModel);
            var resourceVariableName = WriteGetResource(resource, resourceIdentifierParams, exampleModel);
            List<KeyValuePair<string, FormattableString>> parameterValues = WriteOperationParameters(clientOperation.MethodParameters, exampleModel);
            _writer.Line();
            WriteMethodTestInvocation(async, clientOperation, isLroOperation, $"{resourceVariableName}.{testMethodName}", parameterValues.Select(pv => pv.Value));
        }
    }
}
