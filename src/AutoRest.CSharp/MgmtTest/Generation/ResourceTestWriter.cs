// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;
using System.Diagnostics.CodeAnalysis;

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
            writer.UseNamespace("System");
            writer.UseNamespace("System.Threading.Tasks");
            writer.UseNamespace("System.Net");
            writer.UseNamespace("System.Collections.Generic");
            writer.UseNamespace("Azure.Core.TestFramework");
            writer.UseNamespace("Azure.ResourceManager.TestFramework");
        }

        protected void WriteMethodTestIfExist(Resource resource)
        {
            if (resource.GetOperation != null)
            {
                _writer.Line();
                WriteMethodTest(resource, resource.GetOperation, true, false);
            }
            if (resource.DeleteOperation != null)
            {
                _writer.Line();
                WriteMethodTest(resource, resource.DeleteOperation, true, true);
            }
            if (resource.UpdateOperation != null)
            {
                _writer.Line();
                WriteMethodTest(resource, resource.UpdateOperation, true, false);
            }
            foreach (var clientOperation in resource.ClientOperations)
            {
                _writer.Line();
                WriteMethodTest(resource, clientOperation, true, false);
            }
        }

        protected void WriteTesterCtors()
        {
            // write protected default constructor
            _writer.Line();
            using (_writer.Scope($"public {TypeNameOfThis}(bool isAsync): base(isAsync, RecordedTestMode.Record)"))
            {
                _writer.Line($"ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;");
                _writer.Line($"System.Environment.SetEnvironmentVariable(\"RESOURCE_MANAGER_URL\", $\"https://localhost:8443\");");
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

        protected void WriteMethodTest(Resource resource, MgmtClientOperation clientOperation, bool async, bool isLroOperation)
        {
            Debug.Assert(clientOperation != null);
            var methodName = clientOperation.Name;

            int exampleIdx = 0;
            foreach ((var branch, var operation) in GetSortedOperationMappings(clientOperation))
            {
                var exampleGroup = MgmtBaseTestWriter.FindExampleGroup(operation);
                if (exampleGroup is null || exampleGroup.Examples.Count() == 0)
                    return;

                foreach (var exampleModel in exampleGroup?.Examples ?? Enumerable.Empty<ExampleModel>())
                {
                    WriteTestDecorator();
                    var testCaseSuffix = exampleIdx > 0 ? (exampleIdx + 1).ToString() : String.Empty;
                    _writer.Append($"public {GetAsyncKeyword(async)} {MgmtBaseTestWriter.GetTaskOrVoid(async)} {(resource == This ? "" : resource.Type.Name)}{methodName}{testCaseSuffix}()");

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
