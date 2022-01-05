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
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager;

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
            writer.UseNamespace("Azure.ResourceManager.Resources");
            writer.UseNamespace("Azure.ResourceManager.Resources.Models");
            writer.UseNamespace($"{Context.DefaultNamespace}.Models");
        }

        protected void WriteMethodTestIfExist(Resource resource) {
            if (resource.GetOperation != null)
            {
                _writer.Line();
                WriteMethodTest(resource, resource.GetOperation, true);
            }
            if (resource.DeleteOperation != null)
            {
                _writer.Line();
                WriteMethodTest(resource, resource.DeleteOperation, true);
            }
            if (resource.UpdateOperation != null)
            {
                _writer.Line();
                WriteMethodTest(resource, resource.UpdateOperation, true);
            }
            foreach (var clientOperation in resource.ClientOperations)
            {
                _writer.Line();
                WriteMethodTest(resource, clientOperation, true);
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

        public string WriteGetResource(Resource resource, string requestPath, ExampleModel exampleModel)
        {
            var resourceVariableName = useVariableName(resource.Type.Name.FirstCharToLowerCase());
            _writer.Line($"var {resourceVariableName} = GetArmClient().Get{resource.Type.Name}(new {typeof(ResourceIdentifier)}({MgmtBaseTestWriter.FormatResourceId(requestPath):L}));");
            return resourceVariableName;
        }

        protected override CSharpType? WrapResourceDataType(CSharpType? type, MgmtRestOperation operation)
        {
            if (!IsResourceDataType(type, operation))
                return type;

            return _resource.Type;
        }

        protected override bool IsResourceDataType(CSharpType? type, MgmtRestOperation operation)
        {
            return _resource.Type.Equals(type);
        }

        protected void WriteMethodTest(Resource resource, MgmtClientOperation clientOperation, bool async)
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
                    var realRequestPath = ParseRequestPath(resource, operation.RequestPath.SerializedPath, exampleModel);
                    if (realRequestPath is null)
                    {
                        continue;
                    }
                    WriteTestDecorator();
                    var testCaseSuffix = exampleIdx > 0 ? (exampleIdx + 1).ToString() : String.Empty;
                    _writer.Append($"public {GetAsyncKeyword(async)} {MgmtBaseTestWriter.GetTaskOrVoid(async)} {(resource == _resource ? "" : resource.Type.Name)}{testMethodName}{testCaseSuffix}()");

                    using (_writer.Scope())
                    {
                        _writer.LineRaw($"// Example: {exampleModel.Name}");
                        clearVariableNames();
                        var resourceVariableName = WriteGetResource(resource, realRequestPath, exampleModel);

                        List<string> paramNames = WriteOperationParameters(methodParameters, Enumerable.Empty<Parameter> (), exampleModel);

                        _writer.Line();
                        WriteMethodTestInvocation(async, clientOperation.IsPagingOperation(Context) || clientOperation.IsListOperation(Context, out var _), $"{resourceVariableName}.{testMethodName}", paramNames);
                    }
                    _writer.Line();
                    exampleIdx++;
                }
            }
        }
    }
}
