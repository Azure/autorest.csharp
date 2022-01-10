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
        protected Resource _resource;
        protected string TestNamespace => _resource.Type.Namespace + ".Tests.Mock";
        protected override string TypeNameOfThis => _resource.Type.Name + "MockTests";

        protected string TestBaseName => $"MockTestBase";

        public ResourceTestWriter(CodeWriter writer, Resource resource, BuildContext<MgmtOutputLibrary> context): base(writer, resource, context)
        {
            _resource = resource;
        }

        public void WriteCollectionTest()
        {
            WriteUsings(_writer);

            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test for {_resource.ResourceName}");
                _writer.Append($"public partial class {TypeNameOfThis:D} : ");
                _writer.Line($"{TestBaseName}");
                using (_writer.Scope())
                {
                    WriteTesterCtors();
                    WriteMethodTestIfExist(_resource);

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

        protected override void WriteUsings(CodeWriter writer)
        {
            base.WriteUsings(writer);
            writer.UseNamespace("System");
            writer.UseNamespace("System.Threading.Tasks");
            writer.UseNamespace("System.Net");
            writer.UseNamespace("System.Collections.Generic");
            writer.UseNamespace("Azure.Core.TestFramework");
            writer.UseNamespace("Azure.ResourceManager.TestFramework");
        }

        protected void WriteMethodTestIfExist(Resource resource) {
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

        public string WriteGetResource(Resource resource, string resourceIdentifierParams, ExampleModel exampleModel)
        {
            var resourceVariableName = useVariableName(resource.Type.Name.FirstCharToLowerCase());
            var idVar = useVariableName($"{resource.Type.Name.FirstCharToLowerCase()}Id");
            _writer.Line($"var {idVar} = {resource.Type}.CreateResourceIdentifier({resourceIdentifierParams});");
            _writer.Line($"var {resourceVariableName} = GetArmClient().Get{resource.Type.Name}({idVar});");
            return resourceVariableName;
        }

        protected override Resource? WrapResourceDataType(CSharpType? type, MgmtRestOperation operation)
        {
            if (!IsResourceDataType(type, operation, out _))
                return null;

            return _resource;
        }

        protected override bool IsResourceDataType(CSharpType? type, MgmtRestOperation operation, [MaybeNullWhen(false)] out ResourceData data)
        {
            data = _resource.ResourceData;
            return data.Type.Equals(type);
        }

        protected void WriteMethodTest(Resource resource, MgmtClientOperation clientOperation, bool async, bool isLroOperation)
        {
            Debug.Assert(clientOperation != null);
            var methodName = clientOperation.Name;

            BuildParameters(clientOperation, out var operationMappings, out var parameterMappings, out var methodParameters);
            int exampleIdx = 0;
            foreach ((var branch, var operation) in GetSortedOperationMappings(clientOperation))
            {
                var exampleGroup = MgmtBaseTestWriter.FindExampleGroup(Context, operation);
                if (exampleGroup is null || exampleGroup.Examples.Count() == 0)
                    return;
                var testMethodName = CreateMethodName(methodName, async);

                foreach (var exampleModel in exampleGroup?.Examples ?? Enumerable.Empty<ExampleModel>())
                {
                    if (resource.RequestPaths is null || resource.RequestPaths.Count()==0)
                    {
                        continue;
                    }

                    WriteTestDecorator();
                    var testCaseSuffix = exampleIdx > 0 ? (exampleIdx + 1).ToString() : String.Empty;
                    _writer.Append($"public {GetAsyncKeyword(async)} {MgmtBaseTestWriter.GetTaskOrVoid(async)} {(resource == _resource ? "" : resource.Type.Name)}{methodName}{testCaseSuffix}()");

                    using (_writer.Scope())
                    {
                        _writer.LineRaw($"// Example: {exampleModel.Name}");
                        clearVariableNames();
                        string resourceIdentifierParams = ComposeResourceIdentifierParams(resource.RequestPaths.First(), exampleModel);
                        var resourceVariableName = WriteGetResource(resource, resourceIdentifierParams, exampleModel);
                        List<string> paramNames = WriteOperationParameters(methodParameters, Enumerable.Empty<Parameter> (), exampleModel);
                        _writer.Line();
                        WriteMethodTestInvocation(async, clientOperation, isLroOperation, $"{resourceVariableName}.{testMethodName}", paramNames);
                    }
                    _writer.Line();
                    exampleIdx++;
                }
            }
        }
    }
}
