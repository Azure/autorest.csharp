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
using AutoRest.CSharp.Utilities;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Mgmt.Models;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    /// <summary>
    /// Code writer for resource collection tests.
    /// </summary>
    internal class ResourceCollectionTestWriter : MgmtBaseTestWriter
    {
        private ResourceCollection _resourceCollection;

        protected CSharpType TypeOfCollection => _resourceCollection.Type;
        protected string TypeNameOfCollection => TypeOfCollection.Name;

        protected string TestNamespace => TypeOfCollection.Namespace + ".Tests.Mock";
        protected override string TypeNameOfThis => TypeOfCollection.Name + "MockTests";

        protected string TestBaseName => $"MockTestBase";

        public List<Tuple<Parameter, MgmtClientOperation?>> collectionInitiateParameters = new List<Tuple<Parameter, MgmtClientOperation?>>();
        public Dictionary<Tuple<Parameter, MgmtClientOperation?>, string> collectionInitiateParametersMap = new Dictionary<Tuple<Parameter, MgmtClientOperation?>, string>();

        public ResourceCollectionTestWriter(CodeWriter writer, ResourceCollection resourceCollection, BuildContext<MgmtOutputLibrary> context): base(writer, resourceCollection, context)
        {
            _resourceCollection = resourceCollection;
        }

        public void WriteCollectionTest()
        {
            WriteUsings(_writer);

            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test for {_resourceCollection.ResourceName}");
                _writer.Append($"public partial class {TypeNameOfThis:D} : ");
                _writer.Line($"{TestBaseName}");
                using (_writer.Scope())
                {
                    WriteTesterCtors();
                    WriteCreateOrUpdateTest();
                    WriteGetTest();
                    foreach (var clientOperation in _resourceCollection.ClientOperations)
                    {
                        WriteMethodTest(clientOperation, true);
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
            writer.UseNamespace("Azure.Core.TestFramework");
            writer.UseNamespace("Azure.ResourceManager.TestFramework");
            writer.UseNamespace("Azure.ResourceManager.Resources");
            writer.UseNamespace("Azure.ResourceManager.Resources.Models");
            writer.UseNamespace($"{Context.DefaultNamespace}.Models");
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

        protected string GenCollectionVariableName(ResourceCollection resourceCollection)
        {
            return resourceCollection.Type.Name.FirstCharToLowerCase();
        }

        protected void WriteCreateOrUpdateTest()
        {
            if (_resourceCollection.CreateOperation != null)
            {
                _writer.Line();
                WriteMethodTest(_resourceCollection.CreateOperation, true);
            }
        }

        protected void WriteGetTest()
        {
            if (_resourceCollection.GetOperation != null)
            {
                _writer.Line();
                WriteMethodTest(_resourceCollection.GetOperation, true);
            }
        }

        public void WriteGetCollection(MgmtClientOperation clientOperation, ExampleModel exampleModel, bool isAsync)
        {
            _writer.Append($"var collection = {GetAwait(isAsync)} Get{TypeNameOfCollection}{GetAsyncSuffix(isAsync)}(");
            var methodParameters = GenExampleInstanceMethodParameters(clientOperation);
            var usedParameters = new HashSet<ExampleParameter>();
            var allMethodParameters = new HashSet<string>();
            foreach (var methodParameter in methodParameters)
            {
                allMethodParameters.Add(methodParameter.Name);
            }
            foreach (var (parameter, op) in collectionInitiateParameters)
            {
                var found = false;
                foreach (var exampleMethodParameter in exampleModel.MethodParameters)
                {
                    if (exampleMethodParameter.Parameter.CSharpName()==parameter.Name)
                    {
                        WriteExampleValue(_writer, parameter.Type, exampleMethodParameter.ExampleValue, parameter.Name);
                        _writer.Append($", ");
                        usedParameters.Add(exampleMethodParameter);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    foreach (var exampleMethodParameter in exampleModel.MethodParameters)
                    {
                        if (!usedParameters.Contains(exampleMethodParameter) && !allMethodParameters.Contains(exampleMethodParameter.Parameter.CSharpName()))
                        {
                            WriteExampleValue(_writer, parameter.Type, exampleMethodParameter.ExampleValue, parameter.Name);
                            _writer.Append($", ");
                            usedParameters.Add(exampleMethodParameter);
                            break;
                        }
                    }
                }
            }
            _writer.RemoveTrailingComma();
            _writer.Line($");");
        }

        public void WriteGetCollection(MgmtTypeProvider parentTp, string requestPath, ExampleModel exampleModel)
        {
            var realRequestPath = ParseRequestPath(parentTp, requestPath, exampleModel)!;
            switch (parentTp)
            {
                case Resource parentResource:
                    {
                        _writer.Append($"var collection = GetArmClient().Get{parentResource.Type.Name}(new {typeof(Azure.ResourceManager.ResourceIdentifier)}({MgmtBaseTestWriter.FormatResourceId(realRequestPath):L}))");
                        break;
                    }
                case Mgmt.Output.ResourceGroupExtensions:
                    {
                        _writer.Append($"var collection = GetArmClient().GetResourceGroup(new {typeof(Azure.ResourceManager.ResourceIdentifier)}({MgmtBaseTestWriter.FormatResourceId(realRequestPath):L}))");
                        break;
                    }
                case Mgmt.Output.SubscriptionExtensions:
                    {
                        _writer.Append($"var collection = GetArmClient().GetSubscription(new {typeof(Azure.ResourceManager.ResourceIdentifier)}({MgmtBaseTestWriter.FormatResourceId(realRequestPath):L}))");
                        break;
                    }
                case Mgmt.Output.TenantExtensions:
                    {
                        _writer.Append($"var collection = GetArmClient().GetTenants().GetAll().GetEnumerator().Current");
                        break;
                    }
                default:
                    throw new Exception($"Unknown parent {parentTp}");
            }
            _writer.Line($".Get{_resourceCollection.Resource.Type.Name.ToPlural()}();");
        }

        public MgmtTypeProvider? FindParentByRequestPath(string requestPath, ExampleModel exampleModel)
        {
            var mgmtParentResources = new List<MgmtTypeProvider>();
            foreach (var parent in _resourceCollection.Resource.Parent(Context))
            {
                if (parent is MgmtExtensions mgmtParent)
                {
                    mgmtParentResources.Add(mgmtParent);
                }
                else if (parent is Resource mgmtResource)
                {
                    mgmtParentResources.Add(mgmtResource);
                }
            }
            mgmtParentResources.Sort(Comparer<MgmtTypeProvider>.Create(
                (x1, x2) =>
                {
                    // order by path length descendently
                    if (x1 is Resource)
                    {
                        return -1;
                    }
                    else if (x1 is Mgmt.Output.ResourceGroupExtensions)
                    {
                        return -1;
                    }
                    else if (x1 is Mgmt.Output.SubscriptionExtensions)
                    {
                        return -1;
                    }
                    else if (x1 is Mgmt.Output.TenantExtensions)
                    {
                        return -1;
                    }

                    throw new Exception($"Unexpected ParentResource {x1}");
                }));

            foreach (var tp in mgmtParentResources)
            {
                if (tp is Resource rt && ParseRequestPath(rt, requestPath, exampleModel) is not null)
                {
                    return tp;
                }
                var segments = requestPath.Split('/');
                if (tp is Mgmt.Output.ResourceGroupExtensions)
                {
                    if (segments.Length > 5 && segments[3].ToLower() == "resourcegroups")
                    {
                        return tp;
                    }
                }
                if (tp is Mgmt.Output.SubscriptionExtensions)
                {
                    if (segments.Length > 3 && segments[1].ToLower() == "subscriptions")
                    {
                        return tp;
                    }
                }
                if (tp is Mgmt.Output.TenantExtensions)
                {
                    return tp;
                }
            }
            return null;
        }

        protected void WriteMethodTest(MgmtClientOperation clientOperation, bool async)
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
                // var testMethodParameters = GenExampleInstanceMethodParameters(clientOperation);
                var testMethodName = CreateMethodName(methodName, async);

                foreach (var exampleModel in (exampleGroup?.Examples ?? Enumerable.Empty<ExampleModel>()))
                {
                    MgmtTypeProvider? parentTp = FindParentByRequestPath(operation.RequestPath.SerializedPath, exampleModel);
                    if (parentTp is null)
                    {
                        continue;
                    }

                    WriteTestDecorator();
                    var testCaseSuffix = exampleIdx > 0 ? (exampleIdx + 1).ToString() : String.Empty;
                    _writer.Append($"public {GetAsyncKeyword(async)} {MgmtBaseTestWriter.GetTaskOrVoid(async)} {testMethodName}{testCaseSuffix}()");
                    using (_writer.Scope())
                    {
                        _writer.Line($"// Example: {exampleModel.Name}");
                        clearVariableNames();
                        // WriteGetCollection(clientOperation, exampleModel, async);
                        WriteGetCollection(parentTp, operation.RequestPath.SerializedPath, exampleModel);

                        List<string> paramNames = WriteOperationParameters(methodParameters, new List<Parameter>(), exampleModel);
                        _writer.Line();
                        WriteMethodTestInvocation(async, clientOperation.IsPagingOperation(Context)|| clientOperation.IsListOperation(Context, out var _), $"collection.{testMethodName}", paramNames);
                    }
                    _writer.Line();
                    exampleIdx++;
                }
            }
        }

        protected override CSharpType? WrapResourceDataType(CSharpType? type, MgmtRestOperation operation)
        {
            if (!IsResourceDataType(type, operation))
                return type;

            return _resourceCollection.Resource.Type;
        }

        protected override bool IsResourceDataType(CSharpType? type, MgmtRestOperation operation)
        {
            return _resourceCollection.ResourceData.Type.Equals(type);
        }

        public string GenExampleInstanceMethodName(string methodName, bool isAsync)
        {
            return $"{methodName}ExampleInstance{GetAsyncSuffix(isAsync)}";
        }

        public IEnumerable<Parameter> GenExampleInstanceMethodParameters(MgmtClientOperation clientOperation)
        {
            BuildParameters(clientOperation, out var operationMappings, out var parameterMappings, out var methodParameters);
            // var passThruParameters = parameterMappings.Where(p => p.IsPassThru).Select(p => p.Parameter);
            return methodParameters.Where(p => p.ValidateNotNull && p.Type.IsFrameworkType && (p.Type.FrameworkType.IsPrimitive || p.Type.FrameworkType == typeof(String))); // define all primitive parameters as method parameter
        }
    }
}
