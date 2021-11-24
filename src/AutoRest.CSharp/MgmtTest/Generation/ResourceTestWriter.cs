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

        protected ResourceCollectionTestWriter? _collectionTestWriter;

        public ResourceTestWriter(CodeWriter writer, Resource resource, BuildContext<MgmtOutputLibrary> context): base(writer, resource, context)
        {
            _resource = resource;
            if (!resource.IsSingleton)
            {
                _collectionTestWriter = new ResourceCollectionTestWriter(writer, resource.ResourceCollection!, context);
                _collectionTestWriter.EnsureCollectionInitiateParameters();
            }
        }

        public void WriteCollectionTest()
        {
            WriteUsings(_writer);
            _writer.UseNamespace("System.Net");
            _writer.UseNamespace("System.Collections.Generic");
            _writer.UseNamespace("Azure.Core.TestFramework");
            _writer.UseNamespace("Azure.ResourceManager.TestFramework");
            _writer.UseNamespace("Azure.ResourceManager.Resources");

            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test for {_resource.ResourceName}");
                _writer.Append($"public partial class {TypeNameOfThis:D} : ");
                _writer.Line($"{TestBaseName}");
                using (_writer.Scope())
                {
                    WriteTesterCtors();
                    if (!_resource.IsSingleton)
                    {
                        _collectionTestWriter!.WriteCreateCollectionMethod(true);
                    }
                    WriteCreateResourceMethod(true);
                    WriteMethodTestIfExist(_resource);

                    foreach (var childResource in This.ChildResources)
                    {
                        _writer.Line();
                        if (childResource.IsSingleton) {
                            WriteMethodTestIfExist(childResource);
                        }
                    }
                }
            }
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

        protected void WriteCreateResourceMethod(bool async)
        {
            _writer.Line();
            using (_writer.Scope($"private {GetAsyncKeyword(async)} {_resource.Type.WrapAsync(async)} Get{_resource.Type.Name}{GetAsyncSuffix(async)}()"))
            {
                if (MgmtBaseTestWriter.CanCreateResourceFromExample(Context,_resource.ResourceCollection)) {
                    var operationMappings = _resource.ResourceCollection!.CreateOperation!.ToDictionary(
                        operation => operation.ContextualPath,
                        operation => operation);
                    foreach ((var branch, var operation) in operationMappings)
                    {
                        ExampleGroup exampleGroup = MgmtBaseTestWriter.FindExampleGroup(Context, operation)!;
                        _collectionTestWriter!.WriteGetCollection(_resource.ResourceCollection!.CreateOperation!, exampleGroup.Examples.First(), async);
                        _writer.Append($"var createOperation = ");
                        _collectionTestWriter!.WriteInvokeExampleInstanceMethod(_resource.ResourceCollection!.CreateOperation!, async, "CreateOrUpdate", exampleGroup.Examples.First());
                        _writer.Line($"return createOperation.Value;");
                    }
                }
                else
                {
                    throw new Exception("// TODO: create/get resource when there is no create example");
                }
            }
        }

        public void WriteGetResource(Resource resource, bool async)
        {
            _writer.Line($"var {_resource.Type.Name.FirstCharToLowerCase()} = {GetAwait(async)} Get{_resource.Type.Name}{GetAsyncSuffix(async)}();");
            if (resource != _resource) {
                _writer.Line($"var {resource.Type.Name.FirstCharToLowerCase()} = {_resource.Type.Name.FirstCharToLowerCase()}.Get{resource.Type.Name}();");
            }
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
            foreach ((var branch, var operation) in operationMappings)
            {
                var exampleGroup = MgmtBaseTestWriter.FindExampleGroup(Context, operation);
                if (exampleGroup is null || exampleGroup.Examples.Count() == 0)
                    return;
                //var testMethodParameters = _collectionTestWriter!.GenExampleInstanceMethodParameters(clientOperation);
                var testMethodName = CreateMethodName(methodName, async);

                WriteTestDecorator();
                _writer.Append($"public {GetAsyncKeyword(async)} {MgmtBaseTestWriter.GetTaskOrVoid(async)} {(resource == _resource ? "" : resource.Type.Name)}{testMethodName}()");

                using (_writer.Scope())
                {
                    foreach (var exampleModel in exampleGroup?.Examples ?? Enumerable.Empty<ExampleModel>())
                    {
                        _writer.LineRaw($"// Example: {exampleModel.Name}");
                        WriteGetResource(resource, async);

                        List<string> paramNames = this._collectionTestWriter!.WriteOperationParameters(methodParameters, Enumerable.Empty<Parameter> (), exampleModel);

                        _writer.Line();
                        _writer.Append($"{GetAwait(async && !clientOperation.IsPagingOperation(Context))} {resource.Type.Name.FirstCharToLowerCase()}.{testMethodName}(");
                        foreach (var paramName in paramNames)
                        {
                            _writer.Append($"{paramName},");
                        }
                        _writer.RemoveTrailingComma();
                        _writer.LineRaw(");");
                        break;
                    }
                }
                _writer.Line();
            }
        }
    }
}
