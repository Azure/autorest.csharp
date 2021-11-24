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

        public List<Parameter> collectionInitiateParameters = new List<Parameter>();

        public ResourceCollectionTestWriter(CodeWriter writer, ResourceCollection resourceCollection, BuildContext<MgmtOutputLibrary> context): base(writer, resourceCollection, context)
        {
            _resourceCollection = resourceCollection;
        }

        public void WriteCollectionTest()
        {
            WriteUsings(_writer);
            _writer.UseNamespace("System.Net");
            _writer.UseNamespace("Azure.Core.TestFramework");
            _writer.UseNamespace("Azure.ResourceManager.TestFramework");
            _writer.UseNamespace("Azure.ResourceManager.Resources");

            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test for {_resourceCollection.ResourceName}");
                _writer.Append($"public partial class {TypeNameOfThis:D} : ");
                _writer.Line($"{TestBaseName}");
                using (_writer.Scope())
                {
                    WriteTesterCtors();
                    WriteCreateCollectionMethod(true);
                    WriteCreateOrUpdateTest();
                    // WriteGetTest();  // disable since can't successed in stateful mock test. enable this if use stateless mock test
                    foreach (var clientOperation in _resourceCollection.ClientOperations)
                    {
                        WriteMethodTest(clientOperation, true);
                    }
                }
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

        protected string GenCollectionVariableName(ResourceCollection resourceCollection)
        {
            return resourceCollection.Type.Name.FirstCharToLowerCase();
        }

        public void EnsureCollectionInitiateParameters()
        {
            void EnsureByCollection(ResourceCollection resourceCollection)
            {
                var parentResources = resourceCollection!.Resource.Parent(Context);
                if (parentResources.Contains(Context.Library.SubscriptionExtensions) ||
                    parentResources.Contains(Context.Library.TenantExtensions))
                {
                    return;
                }

                if (parentResources.Contains(Context.Library.ResourceGroupExtensions))
                {
                    collectionInitiateParameters.Add(new Parameter("resourceGroupName", "", new CSharpType(typeof(string)), null, true));
                    return;
                }

                foreach (var parentResource in parentResources)
                {
                    if (parentResource is not null && parentResource is Resource)
                    {
                        var parentResourceCollection = ((Resource)parentResource).ResourceCollection;
                        EnsureByCollection(parentResourceCollection!);
                        collectionInitiateParameters.AddRange(GenExampleInstanceMethodParameters(parentResourceCollection!.CreateOperation!));
                        return;
                    }
                }
                throw new Exception($"Can't get parent resourceCollection for collection {resourceCollection.Type.Name}!");
            }

            if (collectionInitiateParameters.Count > 0)
                return;
            EnsureByCollection(_resourceCollection);
        }

        public void WriteCollectionDeclaration(ResourceCollection resourceCollection, bool isAsync, ref bool asyncContent)
        {
            var collectionVariable = GenCollectionVariableName(resourceCollection);
            // var parentResourceType = resourceCollection.OperationGroup.ParentResourceType(Context.Configuration.MgmtConfiguration);
            // var parentOperationGroup = resourceCollection.OperationGroup.ParentOperationGroup(Context);

            var parentResources = resourceCollection!.Resource.Parent(Context);
            if (parentResources.Contains(Context.Library.ResourceGroupExtensions))
            {
                _writer.Line($"ResourceGroup resourceGroup = {GetAwait(isAsync)} TestHelper.CreateResourceGroup{GetAsyncSuffix(isAsync)}(resourceGroupName, GetArmClient());");
                _writer.Line($"{resourceCollection.Type.Name} {collectionVariable} = resourceGroup.Get{resourceCollection.Resource.Type.Name.ToPlural()}();");
                asyncContent = true;
            }
            else if (parentResources.Contains(Context.Library.SubscriptionExtensions))
            {
                _writer.Line($"{resourceCollection.Type.Name} {collectionVariable} = GetArmClient().DefaultSubscription.Get{resourceCollection.Resource.Type.Name.ToPlural()}();");
            }
            else if (parentResources.Contains(Context.Library.TenantExtensions))
            {
                _writer.Line($"{resourceCollection.Type.Name} {collectionVariable} = GetArmClient().GetTenants().GetAll().GetEnumerator().Current.Get{resourceCollection.Resource.Type.Name.ToPlural()}();");
            }
            else
            {
                foreach (var parentResource in parentResources)
                {
                    if (parentResource is not null && parentResource is Resource)
                    {
                        var parentResourceCollection = ((Resource)parentResource).ResourceCollection;
                        if (parentResourceCollection is null)
                            throw new Exception($"Can't get ResourceCollection for {parentResource.Type.Name}");
                        WriteCollectionDeclaration(parentResourceCollection, isAsync, ref asyncContent);

                        var createParentParameters = GenExampleInstanceMethodParameters(parentResourceCollection.CreateOperation!);
                        var resourceVariableName = parentResourceCollection.Resource.ResourceName.FirstCharToLowerCase();
                        _writer.Append($"var {resourceVariableName}Operation = {GetAwait(isAsync)} TestHelper.{GenExampleInstanceMethodName("CreateOrUpdate", isAsync)}({GenCollectionVariableName(parentResourceCollection)}, ");
                        foreach (var parameter in createParentParameters)
                        {
                            _writer.Append($"{parameter.Name}, ");
                        }
                        _writer.RemoveTrailingComma();
                        _writer.Line($");");
                        _writer.Line($"{parentResourceCollection.Resource.Type.Name} {resourceVariableName} = {resourceVariableName}Operation.Value;");
                        _writer.Line($"{resourceCollection.Type.Name} {collectionVariable} = {resourceVariableName}.Get{resourceCollection.Resource.Type.Name.ToPlural()}();");
                        asyncContent = true;
                        return;
                    }
                }

                throw new Exception($"TODO: Can't create collection {resourceCollection.Type.Name}");
            }
        }

        public void WriteCreateCollectionMethod(bool isAsync)
        {
            EnsureCollectionInitiateParameters();
            _writer.Line();
            _writer.Append($"private {GetAsyncKeyword(isAsync)} {TypeOfCollection.WrapAsync(isAsync)} Get{TypeNameOfCollection}{GetAsyncSuffix(isAsync)}(");
            foreach (var parameter in collectionInitiateParameters)
            {
                _writer.Append($"{parameter.Type} {parameter.Name}, ");
            }
            _writer.RemoveTrailingComma();
            using (_writer.Scope($")"))
            {
                var asyncContent = false;
                WriteCollectionDeclaration(_resourceCollection, isAsync, ref asyncContent);
                if (asyncContent || !isAsync)
                {
                    _writer.Append($"return {GenCollectionVariableName(_resourceCollection)};");
                }
                else
                {
                    _writer.Append($"return await Task.FromResult({GenCollectionVariableName(_resourceCollection)});");
                }
            }
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
            foreach (var parameter in collectionInitiateParameters)
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

        public void WriteInvokeExampleInstanceMethod(MgmtClientOperation clientOperation, bool async, string methodName, ExampleModel exampleModel)
        {
            var parameters = GenExampleInstanceMethodParameters(clientOperation);
            _writer.Append($"{GetAwait(async && !clientOperation.IsPagingOperation(Context))} TestHelper.{GenExampleInstanceMethodName(methodName, async)}(collection, ");
            foreach (var parameter in parameters)
            {
                foreach (var methodParameter in exampleModel.MethodParameters)
                {
                    if (methodParameter.Parameter.CSharpName() == parameter.Name)
                    {
                        WriteExampleValue(_writer, parameter.Type, methodParameter.ExampleValue, parameter.Name);
                        _writer.Append($", ");
                        break;
                    }
                }
            }
            _writer.RemoveTrailingComma();
            _writer.Append($")");
            if (clientOperation.IsPagingOperation(Context))
            {
                _writer.Append($".AsPages()");
            }
            _writer.Line($";");
        }

        protected void WriteMethodTest(MgmtClientOperation clientOperation, bool async)
        {
            Debug.Assert(clientOperation != null);
            var methodName = clientOperation.Name;

            BuildParameters(clientOperation, out var operationMappings, out var parameterMappings, out var methodParameters);
            foreach ((var branch, var operation) in operationMappings)
            {
                var exampleGroup = MgmtBaseTestWriter.FindExampleGroup(Context, operation);
                if (exampleGroup is null || exampleGroup.Examples.Count() == 0)
                    return;
                // var testMethodParameters = GenExampleInstanceMethodParameters(clientOperation);
                var testMethodName = CreateMethodName(methodName, async);

                WriteTestDecorator();
                _writer.Append($"public {GetAsyncKeyword(async)} {MgmtBaseTestWriter.GetTaskOrVoid(async)} {testMethodName}()");
                var paramNames = new List<string>();
                using (_writer.Scope())
                {
                    foreach (var exampleModel in exampleGroup?.Examples ?? Enumerable.Empty<ExampleModel>())
                    {
                        _writer.LineRaw($"// Example: {exampleModel.Name}");
                        clearVariableNames();
                        WriteGetCollection(clientOperation, exampleModel, async);
                        WriteInvokeExampleInstanceMethod(clientOperation, async, methodName, exampleModel);
                        break;
                    }
                }
                _writer.Line();
            }
        }

        public CSharpType GenResponseType(MgmtClientOperation clientOperation, bool async, string? methodName = null)
        {
            if (clientOperation.IsLongRunningOperation() || methodName == "CreateOrUpdate")
            {
                var lroObjectType = GetLROObjectType(clientOperation.First().Operation, async);
                return lroObjectType.WrapAsync(async);
            }
            else if (clientOperation.IsPagingOperation(Context))
            {
                var itemType = clientOperation.First(restOperation => restOperation.IsPagingOperation(Context)).GetPagingMethod(Context)!.PagingResponse.ItemType;
                var actualItemType = WrapResourceDataType(itemType, clientOperation.First())!;
                return actualItemType.WrapPageable(async);
            }
            else if (clientOperation.IsListOperation(Context, out var itemType))
            {
                var returnType = new CSharpType(typeof(IReadOnlyList<>), WrapResourceDataType(itemType, clientOperation.First())!);
                return GetResponseType(returnType, async);
            }
            else
            {
                var returnType = WrapResourceDataType(clientOperation.ReturnType, clientOperation.First());
                return GetResponseType(returnType, async);
            }
        }

        public List<string> WriteOperationParameters(IEnumerable<Parameter> methodParameters, IEnumerable<Parameter> testMethodParameters, ExampleModel exampleModel)
        {
            var paramNames = new List<string>();
            foreach (var passThruParameter in methodParameters)
            {
                if (testMethodParameters.Contains(passThruParameter))
                {
                    paramNames.Add(passThruParameter.Name);
                    continue;
                }
                string? paramName = null;
                foreach (ExampleParameter exampleParameter in exampleModel.MethodParameters)
                {
                    if (passThruParameter.Name == exampleParameter.Parameter.CSharpName())
                    {
                        paramName = WriteExampleParameterDeclaration(_writer, exampleParameter, passThruParameter);
                    }
                }
                if (paramName is null)
                {
                    if (passThruParameter.ValidateNotNull)
                    {
                        throw new Exception($"parameter {passThruParameter.Name} not found in example {exampleModel.Name}");
                    }
                    else
                    {
                        paramName = passThruParameter.Name;
                        _writer.Line($"{passThruParameter.Type} {paramName} = null;");
                    }
                }
                paramNames.Add(paramName);
            }
            return paramNames;
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

        public void WriteExampleInstanceMethod(MgmtClientOperation clientOperation, bool async)
        {
            var methodName = clientOperation.Name;

            BuildParameters(clientOperation, out var operationMappings, out var parameterMappings, out var methodParameters);
            foreach ((var branch, var operation) in operationMappings)
            {
                var exampleGroup = MgmtBaseTestWriter.FindExampleGroup(Context, operation);
                if (exampleGroup is null || exampleGroup.Examples.Count() == 0)
                    return;
                var testMethodParameters = GenExampleInstanceMethodParameters(clientOperation);
                var testMethodName = CreateMethodName(methodName, async);

                CodeWriterDelegate returnTypeWriter = w =>
                {
                    var responseType = GenResponseType(clientOperation, async, methodName);
                    if (clientOperation.IsPagingOperation(Context))
                    {
                        w.Append($"{responseType}");
                    }
                    else
                    {
                        w.Append($"{GetAsyncKeyword(async)} {responseType}");
                    }
                };
                _writer.Append($"public static {returnTypeWriter} {GenExampleInstanceMethodName(methodName, async)}({_resourceCollection.Type.Name} collection, ");
                foreach (var testMethodParameter in testMethodParameters)
                {
                    _writer.Append($"{testMethodParameter.Type} {testMethodParameter.Name}, ");
                }
                _writer.RemoveTrailingComma();
                _writer.Append($")");

                using (_writer.Scope())
                {
                    foreach (var exampleModel in exampleGroup?.Examples ?? Enumerable.Empty<ExampleModel>())
                    {
                        _writer.LineRaw($"// Example: {exampleModel.Name}");
                        clearVariableNames();
                        List<string> paramNames = WriteOperationParameters(methodParameters, testMethodParameters, exampleModel);

                        _writer.Line();
                        _writer.Append($"return {GetAwait(async && !clientOperation.IsPagingOperation(Context))} collection.{testMethodName}(");
                        foreach (var paramName in paramNames)
                        {
                            _writer.Append($"{paramName},");
                        }
                        _writer.RemoveTrailingComma();
                        _writer.LineRaw(");");
                        _writer.Line();
                        break;
                    }
                }
                _writer.Line();
                break;
            }
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
