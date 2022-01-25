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
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    /// <summary>
    /// Code writer for resource collection tests.
    /// </summary>
    internal class ResourceCollectionTestWriter : MgmtBaseTestWriter
    {
        private MgmtClientOperation? _getAllOperation;
        protected CSharpType TypeOfCollection => This.Type;
        protected string TypeNameOfCollection => TypeOfCollection.Name;

        protected string TestNamespace => TypeOfCollection.Namespace + ".Tests.Mock";
        private string TypeNameOfThis => This.Type.Name + "MockTests";

        protected string TestBaseName => $"MockTestBase";

        private ResourceCollection This { get; }

        public List<Tuple<Parameter, MgmtClientOperation?>> collectionInitiateParameters = new List<Tuple<Parameter, MgmtClientOperation?>>();
        public Dictionary<Tuple<Parameter, MgmtClientOperation?>, string> collectionInitiateParametersMap = new Dictionary<Tuple<Parameter, MgmtClientOperation?>, string>();

        public ResourceCollectionTestWriter(CodeWriter writer, ResourceCollection resourceCollection, IEnumerable<string>? scenarioVariables = default) : base(writer, resourceCollection, scenarioVariables)
        {
            This = resourceCollection;
            _getAllOperation = resourceCollection.GetAllOperation;
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
                    WriteCreateOrUpdateTest();
                    WriteGetTest();
                    foreach (var clientOperation in This.ClientOperations)
                    {
                        WriteMethodTest(clientOperation, true, false);
                    }
                }
            }
        }

        private void WriteUsings(CodeWriter writer)
        {
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
            if (This.CreateOperation != null)
            {
                _writer.Line();
                WriteMethodTest(This.CreateOperation, true, true);
            }
        }

        protected void WriteGetTest()
        {
            if (This.GetOperation != null)
            {
                _writer.Line();
                WriteMethodTest(This.GetOperation, true, false);
            }
        }

        internal static string GetAsyncSuffix(bool isAsync)
        {
            return isAsync ? "Async" : string.Empty;
        }

        public void WriteGetCollection(MgmtTypeProvider parentTp, string requestPath, ExampleModel exampleModel, List<KeyValuePair<string, FormattableString>> parameterValues)
        {
            var realRequestPath = ParseRequestPath(parentTp, requestPath, exampleModel)!;
            switch (parentTp)
            {
                case Resource parentResource:
                    {
                        var idVar = new CodeWriterDeclaration($"{parentResource.Type.Name.FirstCharToLowerCase()}Id");
                        _writer.Line($"var {idVar:D} = {parentResource.Type}.CreateResourceIdentifier({ComposeResourceIdentifierParams(parentResource.RequestPath, exampleModel)});");
                        _writer.Append($"var collection = GetArmClient().Get{parentResource.Type.Name}({idVar})");
                        break;
                    }
                case MgmtExtensions extension:
                    {
                        if (extension == MgmtContext.Library.TenantExtensions) {
                            _writer.Append($"var collection = GetArmClient().GetTenants().GetAll().GetEnumerator().Current");
                        }
                        else {
                            _writer.Append($"var collection = GetArmClient().Get{extension.ArmCoreType.Name}(new {typeof(Azure.Core.ResourceIdentifier)}({FormatResourceId(realRequestPath).RefScenariDefinedVariables(scenarioVariables)}))");
                        }
                        break;
                    }
                default:
                    throw new Exception($"Unknown parent {parentTp}");
            }
            List<FormattableString> extraParamNames = new List<FormattableString>();
            var paramsMap = parameterValues.ToDictionary(pv => pv.Key, pv => pv);
            foreach (var extraParam in This.ExtraConstructorParameters)
            {
                if (paramsMap.ContainsKey(extraParam.Name))
                {
                    extraParamNames.Add(paramsMap[extraParam.Name].Value);
                    parameterValues.Remove(paramsMap[extraParam.Name]);
                }
                else
                {
                    extraParamNames.Add($"default");
                }
            }
            _writer.Line($".{WriteMethodInvocation($"Get{This.Resource.ResourceName.ResourceNameToPlural()}", extraParamNames)};");
        }

        public MgmtTypeProvider? FindParentByRequestPath(string requestPath, ExampleModel exampleModel)
        {
            var mgmtParentResources = new List<MgmtTypeProvider>();
            foreach (var parent in This.Resource.Parent())
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
                    else if (x1 is MgmtExtensions)
                    {
                        return -1;
                    }

                    throw new Exception($"Unexpected ParentResource {x1}");
                }));

            foreach (var tp in mgmtParentResources)
            {
                if (tp is Resource rt)
                {
                    return tp;
                }
                var segments = requestPath.Split('/');
                if (tp is MgmtExtensions extension)
                {
                    if (extension.ArmCoreType == typeof(ResourceGroupResource))
                    {
                        if (segments.Length > 5 && segments[3].ToLower() == "resourcegroups")
                        {
                            return tp;
                        }
                    }
                    if (extension.ArmCoreType == typeof(SubscriptionResource))
                    {
                        if (segments.Length > 3 && segments[1].ToLower() == "subscriptions")
                        {
                            return tp;
                        }
                    }
                    if (extension.ArmCoreType == typeof(TenantResource))
                    {
                        return tp;
                    }
                }
            }
            return null;
        }

        protected void WriteMethodTest(MgmtClientOperation clientOperation, bool async, bool isLroOperation)
        {
            Debug.Assert(clientOperation != null);
            var methodName = clientOperation.Name;

            int exampleIdx = 0;
            foreach ((var branch, var operation) in GetSortedOperationMappings(clientOperation))
            {
                var exampleGroup = MgmtBaseTestWriter.FindExampleGroup(operation);
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
                        WriteOperationInvocation(This, clientOperation, operation, exampleModel, async, isLroOperation);
                    }
                    _writer.Line();
                    exampleIdx++;
                }
            }
        }

        public bool WriteOperationInvocation(ResourceCollection collection, MgmtClientOperation clientOperation, MgmtRestOperation restOperation, ExampleModel exampleModel, bool async, bool isLroOperation)
        {
            MgmtTypeProvider? parentTp = FindParentByRequestPath(restOperation.RequestPath.SerializedPath, exampleModel);
            if (parentTp is null) {
                return false;
            }

            var testMethodName = CreateMethodName(clientOperation.Name, async);
            List<KeyValuePair<string, FormattableString>> parameterValues = WriteOperationParameters(clientOperation.MethodParameters, exampleModel);
            _writer.Line();
            WriteGetCollection(parentTp, restOperation.RequestPath.SerializedPath, exampleModel, parameterValues);
            WriteMethodTestInvocation(async, clientOperation, isLroOperation, $"collection.{testMethodName}", parameterValues.Select(pv => pv.Value));
            return true;
        }

        public string GenExampleInstanceMethodName(string methodName, bool isAsync)
        {
            return $"{methodName}ExampleInstance{GetAsyncSuffix(isAsync)}";
        }

        public IEnumerable<Parameter> GenExampleInstanceMethodParameters(MgmtClientOperation clientOperation)
        {
            // var passThruParameters = parameterMappings.Where(p => p.IsPassThru).Select(p => p.Parameter);
            return clientOperation.MethodParameters.Where(p => p.Validate && p.Type.IsFrameworkType && (p.Type.FrameworkType.IsPrimitive || p.Type.FrameworkType == typeof(String))); // define all primitive parameters as method parameter
        }
    }
}
