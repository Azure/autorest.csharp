// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
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
    internal class MgmtExtensionTestWriter : MgmtBaseTestWriter
    {
        protected MgmtExtensions _extensions;
        protected string TestNamespace => _extensions.Type.Namespace + ".Tests.Mock";
        protected string TypeNameOfThis => _extensions.Type.Name + "MockTests";

        protected string TestBaseName => $"MockTestBase";

        public MgmtExtensionTestWriter(CodeWriter writer, MgmtExtensions extensions, IEnumerable<string>? scenarioVariables = default) : base(writer, extensions, scenarioVariables)
        {
            this._extensions = extensions;
        }

        public override void Write()
        {
            WriteUsings(_writer);

            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test for {_extensions.ResourceName}");
                _writer.Append($"public partial class {TypeNameOfThis:D} : ");
                _writer.Line($"{TestBaseName}");
                using (_writer.Scope())
                {
                    WriteTesterCtors();
                    foreach (var clientOperation in _extensions.ClientOperations)
                    {
                        _writer.Line();
                        WriteTestMethod(clientOperation, true, false);
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

        protected void WriteTestMethod(MgmtClientOperation clientOperation, bool async, bool isLroOperation)
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
                    _writer.Append($"public {GetAsyncKeyword(async)} {MgmtBaseTestWriter.GetTaskOrVoid(async)} {CreateTestMethodName(methodName, exampleIdx)}()");
                    using (_writer.Scope())
                    {
                        _writer.LineRaw($"// Example: {exampleModel.Name}");
                        WriteOperationInvocation(clientOperation, operation, exampleModel, async, isLroOperation);
                    }
                    _writer.Line();
                    exampleIdx++;
                }
            }
        }

        public void WriteOperationInvocation(MgmtClientOperation clientOperation, MgmtRestOperation restOperation, ExampleModel exampleModel, bool async, bool isLroOperation)
        {
            var testMethodName = CreateMethodName(clientOperation.Name, async);
            var resourceIdentifierParams = ComposeResourceIdentifierParams(restOperation.RequestPath, exampleModel);
            var subscriptionVariableName = new CodeWriterDeclaration(_extensions.Type.Name.FirstCharToLowerCase());
            var subscriptionRequestPath = GetSubscriptionRequestPath(restOperation.RequestPath, exampleModel);
            _writer.Line($"var {subscriptionVariableName:D} = GetArmClient().GetSubscriptionResource(new {typeof(Azure.Core.ResourceIdentifier)}({FormatResourceId(subscriptionRequestPath).RefScenarioDefinedVariables(_scenarioVariables)}));");
            List<KeyValuePair<string, FormattableString>> parameterValues = WriteOperationParameters(clientOperation.MethodParameters.Skip(1), exampleModel);

            _writer.Line();
            WriteMethodTestInvocation(async, clientOperation, isLroOperation, $"{subscriptionVariableName}.{testMethodName}", parameterValues.Select(pv => pv.Value));
        }

        public string GetSubscriptionRequestPath(RequestPath requestPath, ExampleModel exampleModel)
        {
            var result = new List<Segment>();
            // this might throw exceptions when there are less than 2 segments
            foreach (var segment in requestPath.Take(2))
            {
            if (segment.IsConstant)
            result.Add(segment);
            else
            {
            var v = FindParameterValueByName(exampleModel, segment.ReferenceName) ?? "00000000-0000-0000-0000-000000000000";
            result.Add(new Segment(v));
            }
            }
            return new RequestPath(result);
        }
    }
}
