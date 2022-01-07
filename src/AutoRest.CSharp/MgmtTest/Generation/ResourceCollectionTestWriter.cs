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
using AutoRest.CSharp.Mgmt.Models;
using System.Diagnostics.CodeAnalysis;

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
                        WriteMethodTest(clientOperation, true, false);
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
                WriteMethodTest(_resourceCollection.CreateOperation, true, true);
            }
        }

        protected void WriteGetTest()
        {
            if (_resourceCollection.GetOperation != null)
            {
                _writer.Line();
                WriteMethodTest(_resourceCollection.GetOperation, true, false);
            }
        }

        public void WriteGetCollection(MgmtTypeProvider parentTp, string requestPath, ExampleModel exampleModel, List<string> paramNames)
        {
            var realRequestPath = ParseRequestPath(parentTp, requestPath, exampleModel)!;
            switch (parentTp)
            {
                case Resource parentResource:
                    {
                        var idVar = $"{parentResource.Type.Name.FirstCharToLowerCase()}Id";
                        idVar = useVariableName(idVar);
                        _writer.Line($"var {idVar} = {parentResource.Type}.CreateResourceIdentifier({ComposeResourceIdentifierParams(parentResource.RequestPaths.First(), exampleModel)});");
                        _writer.Append($"var collection = GetArmClient().Get{parentResource.Type.Name}({idVar})");
                        break;
                    }
                case Mgmt.Output.ResourceGroupExtensions:
                    {
                        _writer.Append($"var collection = GetArmClient().GetResourceGroup(new {typeof(Azure.Core.ResourceIdentifier)}({MgmtBaseTestWriter.FormatResourceId(realRequestPath):L}))");
                        break;
                    }
                case Mgmt.Output.SubscriptionExtensions:
                    {
                        _writer.Append($"var collection = GetArmClient().GetSubscription(new {typeof(Azure.Core.ResourceIdentifier)}({MgmtBaseTestWriter.FormatResourceId(realRequestPath):L}))");
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
            List<string> extraParamNames = new List<string>();
            foreach (var extraParam in _resourceCollection.ExtraConstructorParameters)
            {
                if (paramNames.Contains(extraParam.Name))
                {
                    extraParamNames.Add(extraParam.Name);
                    paramNames.Remove(extraParam.Name);
                }
                else
                {
                    extraParamNames.Add("default");
                }
            }
            _writer.Line($".{WriteMethodInvocation($"Get{_resourceCollection.Resource.Type.Name.ToPlural()}", extraParamNames)};");
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
                if (tp is Resource rt && rt.RequestPaths is not null && rt.RequestPaths.Count() !=0)
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

        protected void WriteMethodTest(MgmtClientOperation clientOperation, bool async, bool isLroOperation)
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

                foreach (var exampleModel in (exampleGroup?.Examples ?? Enumerable.Empty<ExampleModel>()))
                {
                    MgmtTypeProvider? parentTp = FindParentByRequestPath(operation.RequestPath.SerializedPath, exampleModel);
                    if (parentTp is null)
                    {
                        continue;
                    }

                    WriteTestDecorator();
                    var testCaseSuffix = exampleIdx > 0 ? (exampleIdx + 1).ToString() : String.Empty;
                    _writer.Append($"public {GetAsyncKeyword(async)} {MgmtBaseTestWriter.GetTaskOrVoid(async)} {methodName}{testCaseSuffix}()");
                    using (_writer.Scope())
                    {
                        _writer.Line($"// Example: {exampleModel.Name}");
                        clearVariableNames();
                        List<string> paramNames = WriteOperationParameters(methodParameters, new List<Parameter>(), exampleModel);
                        _writer.Line();
                        WriteGetCollection(parentTp, operation.RequestPath.SerializedPath, exampleModel, paramNames);
                        WriteMethodTestInvocation(async, clientOperation, isLroOperation, $"collection.{testMethodName}", paramNames);
                    }
                    _writer.Line();
                    exampleIdx++;
                }
            }
        }

        protected override Resource? WrapResourceDataType(CSharpType? type, MgmtRestOperation operation)
        {
            if (!IsResourceDataType(type, operation, out _))
                return null;

            return _resourceCollection.Resource;
        }

        protected override bool IsResourceDataType(CSharpType? type, MgmtRestOperation operation, [MaybeNullWhen(false)] out ResourceData data)
        {
            data = _resourceCollection.ResourceData;
            return data.Type.Equals(type);
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
