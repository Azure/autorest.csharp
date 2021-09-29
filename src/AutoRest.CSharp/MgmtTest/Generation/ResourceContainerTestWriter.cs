// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Management;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using System.Text.Json;
using AutoRest.CSharp.Mgmt.Generation;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    /// <summary>
    /// Code writer for resource container.
    /// A resource container should have 3 operations:
    /// 1. CreateOrUpdate (4 variants)
    /// 2. Get (2 variants)
    /// 3. List (4 variants)
    /// and the following builder methods:
    /// 1. Construct
    /// </summary>
    internal class ResourceContainerTestWriter : ResourceContainerWriter
    {
        private CodeWriter _writer;
        private CodeWriter _tagsWriter = new CodeWriter();
        private ResourceContainer _resourceContainer;
        private ResourceData _resourceData;
        private Resource _resource;
        private BuildContext<MgmtOutputLibrary> _context;

        protected override string ContextProperty => "Parent";

        protected CSharpType TypeOfContainer => _resourceContainer.Type;
        protected string TypeNameOfContainer => TypeOfContainer.Name;

        protected string TestNamespace => TypeOfContainer.Namespace + ".Tests.Mock";
        protected override string TypeNameOfThis => TypeOfContainer.Name + "MockTests";
        protected string TestEnvironmentName => _context.DefaultLibraryName + "TestEnvironment";
        protected string TestBaseName => $"MockTestBase";

        protected List<Parameter> containerInitiateParameters = new List<Parameter>();

        public ResourceContainerTestWriter(CodeWriter writer, ResourceContainer resourceContainer, BuildContext<MgmtOutputLibrary> context): base(writer, resourceContainer, context)
        {
            _writer = writer;
            _resourceContainer = resourceContainer;
            var operationGroup = resourceContainer.OperationGroup;
            _resourceData = context.Library.GetResourceData(operationGroup);
            _restClient = context.Library.GetRestClient(operationGroup);
            _resource = context.Library.GetArmResource(operationGroup);
            _context = context;
        }

        public void WriteContainerTest()
        {
            WriteUsings(_writer);
            _writer.UseNamespace(TypeOfContainer.Namespace);
            _writer.UseNamespace($"{TypeOfContainer.Namespace}.Models");
            _writer.UseNamespace(TypeOfContainer.Namespace + ".Tests");
            _writer.UseNamespace("NUnit.Framework");
            _writer.UseNamespace("System.Net");
            _writer.UseNamespace("Azure.Core.TestFramework");
            _writer.UseNamespace("Azure.ResourceManager.TestFramework");
            _writer.UseNamespace("Azure.ResourceManager.Resources");

            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test for {_resourceContainer.ResourceName}");
                _writer.Append($"public partial class {TypeNameOfThis:D} : ");
                _writer.Line($"{TestBaseName}");
                using (_writer.Scope())
                {
                    WriteContainerTesterCtors();
                    WriteCreateContainerMethod(true);
                    WriteCreateContainerMethod(false);
                    WriteCreateOrUpdateTest();
                    WriteGetTest();
                }
            }
        }

        protected void WriteContainerTesterCtors()
        {
            // write protected default constructor
            _writer.Line();
            using (_writer.Scope($"public {TypeNameOfThis}(bool isAsync): base(isAsync, RecordedTestMode.Record)"))
            {
                _writer.Line($"ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;");
            }
        }

        protected string GenContainerVariableName(ResourceContainer resourceContainer)
        {
            return resourceContainer.Type.Name.FirstCharToLowerCase();
        }

        protected void EnsureContainerInitiateParameters()
        {
            void EnsureByContainer(ResourceContainer resourceContainer)
            {
                var parentOperationGroup = resourceContainer.OperationGroup.ParentOperationGroup(_context);
                if (parentOperationGroup is null)
                {
                    var parentResourceType = resourceContainer.OperationGroup.ParentResourceType(_context.Configuration.MgmtConfiguration);
                    switch (parentResourceType)
                    {
                        case ResourceTypeBuilder.ResourceGroups:
                            containerInitiateParameters.Add(new Parameter("resourceGroupName", "", new CSharpType(typeof(string)), null, true));
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    var parentResourceContainer = _context.Library.GetResourceContainer(parentOperationGroup);
                    if (parentResourceContainer is null)
                        throw new Exception($"Can't get resourceContainer for operationGroup {parentOperationGroup.Key}");
                    EnsureByContainer(parentResourceContainer);
                    containerInitiateParameters.AddRange(GenExampleInstanceMethodParameters(parentResourceContainer.CreateMethod!));
                }
            }

            if (containerInitiateParameters.Count > 0)
                return;
            EnsureByContainer(_resourceContainer);
        }


        protected void WriteCreateContainerMethod(bool isAsync)
        {
            var asyncContent = false;
            void WriteContainerDeclaration(ResourceContainer resourceContainer)
            {
                var containerVariable = GenContainerVariableName(resourceContainer);
                var parentResourceType = resourceContainer.OperationGroup.ParentResourceType(_context.Configuration.MgmtConfiguration);
                var parentOperationGroup = resourceContainer.OperationGroup.ParentOperationGroup(_context);
                if (parentOperationGroup is null)
                {
                    switch (parentResourceType)
                    {
                        case ResourceTypeBuilder.ResourceGroups:
                            _writer.Line($"ResourceGroup resourceGroup = {GetAwait(isAsync)} TestHelper.CreateResourceGroup{GetAsyncSuffix(isAsync)}(resourceGroupName, GetArmClient());");
                            _writer.Line($"{resourceContainer.Type.Name} {containerVariable} = resourceGroup.Get{resourceContainer.Resource.Type.Name.ToPlural()}();");
                            asyncContent = true;
                            break;
                        case ResourceTypeBuilder.Subscriptions:
                            _writer.Line($"{resourceContainer.Type.Name} {containerVariable} = GetArmClient().DefaultSubscription.Get{resourceContainer.Resource.Type.Name.ToPlural()}();");
                            break;
                        case ResourceTypeBuilder.Tenant:
                            _writer.Line($"{resourceContainer.Type.Name} {containerVariable} = GetArmClient().GetTenants().GetAll().GetEnumerator().Current.Get{resourceContainer.Resource.Type.Name.ToPlural()}();");
                            break;
                        default:
                            throw new Exception($"TODO: Can't create container from {parentResourceType}");
                    }
                }
                else
                {
                    var parentResourceContainer = _context.Library.GetResourceContainer(parentOperationGroup);
                    if (parentResourceContainer is null)
                        throw new Exception($"Can't get resourceContainer for operationGroup {parentOperationGroup.Key}");
                    WriteContainerDeclaration(parentResourceContainer);

                    var createParentParameters = GenExampleInstanceMethodParameters(parentResourceContainer.CreateMethod!);
                    var resourceVariableName = parentResourceContainer.Resource.ResourceName.FirstCharToLowerCase();
                    _writer.Append($"{parentResourceContainer.Resource.Type.Name} {resourceVariableName} = {GetAwait(isAsync)} TestHelper.{GenExampleInstanceMethodName(parentResourceContainer.CreateMethod!, isAsync)}({GenContainerVariableName(parentResourceContainer)}, ");
                    foreach (var parameter in createParentParameters)
                    {
                        _writer.Append($"{parameter.Name}, ");
                    }
                    _writer.RemoveTrailingComma();
                    _writer.Line($");");
                    _writer.Line($"{resourceContainer.Type.Name} {containerVariable} = {resourceVariableName}.Get{resourceContainer.Resource.Type.Name.ToPlural()}();");
                    asyncContent = true;
                }
            }

            EnsureContainerInitiateParameters();
            _writer.Line();
            _writer.Append($"private {GetAsyncKeyword(isAsync)} {TypeOfContainer.WrapAsync(isAsync)} Get{TypeNameOfContainer}{GetAsyncSuffix(isAsync)}(");
            foreach (var parameter in containerInitiateParameters)
            {
                _writer.Append($"{parameter.Type} {parameter.Name}, ");
            }
            _writer.RemoveTrailingComma();
            using (_writer.Scope($")"))
            {
                WriteContainerDeclaration(_resourceContainer);
                if (asyncContent || !isAsync)
                {
                    _writer.Append($"return {GenContainerVariableName(_resourceContainer)};");
                }
                else
                {
                    _writer.Append($"return await Task.FromResult({GenContainerVariableName(_resourceContainer)});");
                }
            }
        }

        protected void WriteCreateOrUpdateTest()
        {
            if (_resourceContainer.CreateMethod != null)
            {
                _writer.Line();
                WriteMethodTest(_resourceContainer.CreateMethod, _context, true, "CreateOrUpdate");
                WriteMethodTest(_resourceContainer.CreateMethod, _context, false, "CreateOrUpdate");
            }
        }

        protected void WriteGetTest()
        {
            if (_resourceContainer.GetMethod != null)
            {
                _writer.Line();
                WriteMethodTest(_resourceContainer.GetMethod.RestClientMethod, _context, true, "Get");
                WriteMethodTest(_resourceContainer.GetMethod.RestClientMethod, _context, false, "Get");
            }
        }

        protected void WriteGetContainer(RestClientMethod clientMethod, ExampleModel exampleModel, bool isAsync)
        {
            _writer.Append($"var container = {GetAwait(isAsync)} Get{TypeNameOfContainer}{GetAsyncSuffix(isAsync)}(");
            var methodParameters = GenExampleInstanceMethodParameters(clientMethod);
            var usedParameters = new HashSet<ExampleParameter>();
            var allMethodParameters = new HashSet<string>();
            foreach (var methodParameter in methodParameters)
            {
                allMethodParameters.Add(methodParameter.Name);
            }
            foreach (var parameter in containerInitiateParameters)
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

        protected string WriteParameter(RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, ExampleParameter exampleParameter, Parameter parameter) {
            var variableName = WriteExampleParameterDeclaration(exampleParameter, parameter);
            return variableName;
        }

        protected ObjectTypeProperty? FindPropertyThroughSerialization(List<string> flattenedNames, JsonObjectSerialization obj)
        {
            if (flattenedNames.Count==0)
            {
                return null;
            }
            foreach (JsonPropertySerialization property in obj.Properties)
            {
                if (flattenedNames[0] == property.Name)
                {
                    if (flattenedNames.Count==1)
                        return property.Property;
                    return FindPropertyThroughSerialization(flattenedNames.Skip(1).ToList(), (JsonObjectSerialization)property.ValueSerialization);
                }
            }
            return null;
        }

        protected ExampleValue? FindPropertyValue(SchemaObjectType sot, ExampleValue ev, ObjectTypeProperty targetProperty)
        {
            var obj = (JsonObjectSerialization)sot.Serializations.Single(x => typeof(JsonSerialization).IsInstanceOfType(x));

            foreach (var exampleProperty in ev.Properties ?? new DictionaryOfExamplValue()) {
                var property = FindPropertyThroughSerialization(exampleProperty.Value.FlattenedNames is not null ? exampleProperty.Value.FlattenedNames.ToList()! : new List<string> { exampleProperty.Key }, obj);
                if (property == targetProperty)
                {
                    return exampleProperty.Value;
                }
            }

            return null;
        }


        protected void WriteSchemaObjectExampleValue(CodeWriter writer, SchemaObjectType sot, ExampleValue ev, string variableName)
        {
            // Find Polimophismed schema
            if (_context.Library.SchemaMap.ContainsKey(ev.Schema))
            {
                var mappedTypeProvider = _context.Library.SchemaMap[ev.Schema];
                if (mappedTypeProvider is SchemaObjectType)
                {
                    sot = (SchemaObjectType)mappedTypeProvider;
                }
            }

            var constructor = sot.Constructors[0];
            // find the simplest constructor
            foreach (var c in sot.Constructors)
            {
                if (c.Signature.Parameters.Length < constructor.Signature.Parameters.Length)
                    constructor = c;
            }
            HashSet<ObjectTypeProperty> consumedProperties = new HashSet<ObjectTypeProperty>();
            var signature = constructor.Signature;

            writer.Append($"new {signature.Name}(");
            foreach (var p in signature.Parameters)
            {
                var targetProperty = constructor.FindPropertyInitializedByParameter(p);
                var paramValue = FindPropertyValue(sot, ev, targetProperty!);
                if (paramValue is not null)
                {
                    WriteExampleValue(writer, p.Type, paramValue!, $"{variableName}.{targetProperty!.Declaration.Name}");
                    writer.AppendRaw(",");
                }
                else
                {
                    writer.Line($"{p.Name} = default; // don't find example value for this parameter!");
                }
                consumedProperties.Add(targetProperty!);
            }
            writer.RemoveTrailingComma();
            writer.Append($")");

            var hasUnconsumedProperties = false;
            foreach (var objectType in sot.EnumerateHierarchy())
            {
                foreach (var targetProperty in objectType.Properties)
                {
                    if (consumedProperties.Contains(targetProperty) || targetProperty.IsReadOnly)
                        continue;
                    var paramValue = FindPropertyValue(sot, ev, targetProperty!);
                    if (paramValue is not null)
                    {
                        hasUnconsumedProperties = true;
                        goto WriteProperties;
                    }
                }
            }

            WriteProperties:
            if (hasUnconsumedProperties)
            using (writer.Scope($"", newLine: false))
            {
                foreach (var objectType in sot.EnumerateHierarchy())
                {
                    foreach (var targetProperty in objectType.Properties)
                    {
                        if (consumedProperties.Contains(targetProperty) || targetProperty.IsReadOnly)
                            continue;
                        var paramValue = FindPropertyValue(sot, ev, targetProperty!);
                        if (paramValue is not null)
                        {
                            var newVariableName = $"{variableName}.{targetProperty.Declaration.Name}";
                            if (targetProperty.Declaration.Name == "Tags")
                            {
                                _tagsWriter.Append($"{newVariableName}.ReplaceWith(");
                                WriteExampleValue(_tagsWriter, targetProperty.ValueType, paramValue!, newVariableName);
                                _tagsWriter.Append($");");
                            }
                            else
                            {
                                writer.Append($"{targetProperty.Declaration.Name} = ");
                                WriteExampleValue(writer, targetProperty.ValueType, paramValue!, newVariableName);
                                writer.Append($", ");
                            }
                            consumedProperties.Add(targetProperty);
                        }
                    }
                }
            }
        }

        protected void WriteFrameworkTypeExampleValue(CodeWriter writer, CSharpType cst, ExampleValue exampleValue, string variableName)
        {
            if (cst.Name == "IList")
            {
                using (writer.Scope($"new List<{cst.Arguments[0]}>()", newLine: false))
                {
                    var idx = 0;
                    foreach (var element in exampleValue.Elements!)
                    {
                        WriteExampleValue(writer, cst.Arguments[0], element, $"{variableName}[{idx}]");
                        writer.Append($",");
                        idx++;
                    }
                }
            }
            else if (cst.Name == "IDictionary")
            {
                using (writer.Scope($"new {new CSharpType(typeof(Dictionary<,>), cst.Arguments)}()", newLine: false))
                {
                    foreach (var entry in exampleValue.Properties!)
                    {
                        using (writer.Scope())
                        {
                            writer.Append($"{entry.Key:L}");
                            writer.Append($",");
                            WriteExampleValue(writer, cst.Arguments[1], entry.Value, $"{variableName}[{entry.Key:L}]");
                        }
                        writer.Append($",");
                    }
                }
            }
            else if (cst.Name == "Object")
            {
                writer.UseNamespace("System.Text.Json");
                writer.Append($"JsonSerializer.Deserialize<object>({JsonSerializer.Serialize(TestTool.ConvertToStringDictionary(exampleValue.RawValue!)):L})");
            }
            else if (cst.Name == "ResourceIdentifier")
            {
                writer.Append($"new {cst}(${TestTool.FormatResourceId(exampleValue.RawValue!.ToString()!):L})");
            }
            else if (cst.Name == "DateTimeOffset")
            {
                writer.Append($"{typeof(DateTimeOffset)}.Parse({exampleValue.RawValue:L})");
            }
            else if (exampleValue.RawValue is not null)
            {
                if (new string[] { "String", "Location" }.Contains(cst.FrameworkType.Name))
                {
                    writer.Append($"{exampleValue.RawValue:L}");
                }
                else
                    try
                {
                    writer.Append($"{exampleValue.RawValue}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (exampleValue.Elements is not null)
            {
                writer.Append($"{exampleValue.Elements}");
            }
            else if (exampleValue.Properties is not null)
            {
                writer.Append($"{exampleValue.Properties}");
            }
            else
            {
                writer.Append($"null");
            }
        }

        protected void WriteEnumTypeExampleValue(CodeWriter writer, EnumType enumType, ExampleValue exampleValue)
        {
            writer.AppendEnumFromString(enumType, w => w.Append($"{exampleValue.RawValue:L}"));
        }

        protected void WriteExampleValue(CodeWriter writer, CSharpType cst, ExampleValue exampleValue, string variableName)
        {
            TypeProvider? tp = cst.IsFrameworkType ? null : cst.Implementation;
            switch (tp)
            {
                case SchemaObjectType sot:
                    WriteSchemaObjectExampleValue(writer, sot, exampleValue, variableName);
                    break;
                case EnumType enumType:
                    WriteEnumTypeExampleValue(writer, enumType, exampleValue);
                    break;
                default:
                    WriteFrameworkTypeExampleValue(writer, cst, exampleValue, variableName);
                    break;
            }
        }

        protected string WriteExampleParameterDeclaration(ExampleParameter exampleParameter, Parameter parameter)
        {
            var variableName = exampleParameter.Parameter.CSharpName();
            if (parameter.Type.Name == _resourceData.Declaration.Name)
            {
                _writer.Append($"var {variableName} = ");
                WriteSchemaObjectExampleValue(_writer, _resourceData, exampleParameter.ExampleValue, variableName);
                _writer.Line($";");
            }
            else
            {
                _writer.Append($"var {variableName} = ");
                WriteExampleValue(_writer, parameter.Type, exampleParameter.ExampleValue, variableName);
                _writer.Line($";");
            }

            foreach (var tagLine in _tagsWriter.ToString(false).Split(Environment.NewLine))
            {
                _writer.AppendRaw(tagLine);
            }
            _tagsWriter = new CodeWriter();
            return variableName;
        }

        protected string BuildValueString(ExampleValue exampleValue, Schema schema)
        {
            return $"\"{exampleValue.RawValue}\"";
        }

        protected void WriteMethodTest(RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool isAsync, string? methodName = null)
        {
            Debug.Assert(clientMethod.Operation != null);

            var exampleGroup = FindExampleGroup(_context, _resourceContainer, clientMethod);
            if (exampleGroup is null || exampleGroup.Examples.Count() == 0)
                return;

            methodName = methodName ?? clientMethod.Name;
            var parameterMapping = BuildParameterMapping(clientMethod);
            var passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            TestTool.WriteTestDecorator(_writer);
            var testMethodName = CreateMethodName(methodName, isAsync);
            _writer.Append($"public {GetAsyncKeyword(isAsync)} {TestTool.GetTaskOrVoid(isAsync)} {testMethodName}()");
            var paramNames = new List<string>();
            using (_writer.Scope())
            {
                foreach (var exampleModel in exampleGroup?.Examples ?? Enumerable.Empty<ExampleModel>())
                {
                    _writer.LineRaw($"// Example: {exampleModel.Name}");
                    WriteGetContainer(clientMethod, exampleModel, isAsync);

                    var parameters = GenExampleInstanceMethodParameters(clientMethod);
                    _writer.Append($"{GetAwait(isAsync)} TestHelper.{GenExampleInstanceMethodName(clientMethod, isAsync)}(container, ");
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
                    _writer.Line($");");
                    break;
                }
            }
            _writer.Line();
        }

        public  void WriteExampleInstanceMethod(RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool isAsync, string? methodName = null)
        {
            Debug.Assert(clientMethod.Operation != null);

            var exampleGroup = FindExampleGroup(_context, _resourceContainer, clientMethod);
            if (exampleGroup is null || exampleGroup.Examples.Count()==0)
                return;

            methodName = methodName ?? clientMethod.Name;

            var parameterMapping = BuildParameterMapping(clientMethod);
            var passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);
            var methodParameters = GenExampleInstanceMethodParameters(clientMethod);
            var testMethodName = CreateMethodName(methodName, isAsync);

            _writer.Append($"public static {GetAsyncKeyword(isAsync)} {_resource.Type.WrapAsync(isAsync)} {GenExampleInstanceMethodName(clientMethod, isAsync)}({_resourceContainer.Type.Name} container, ");
            foreach (var methodParameter in methodParameters)
            {
                _writer.Append($"{methodParameter.Type} {methodParameter.Name}, ");
            }
            _writer.RemoveTrailingComma();
            _writer.Append($")");
            var paramNames = new List<string>();
            using (_writer.Scope())
            {
                foreach (var exampleModel in exampleGroup?.Examples ?? Enumerable.Empty<ExampleModel>())
                {
                    _writer.LineRaw($"// Example: {exampleModel.Name}");
                    foreach (var passThruParameter in passThruParameters)
                    {
                        if (methodParameters.Contains(passThruParameter))
                        {
                            paramNames.Add(passThruParameter.Name);
                            continue;
                        }
                        string? paramName = null;
                        foreach (ExampleParameter exampleParameter in exampleModel.MethodParameters)
                        {
                            if (passThruParameter.Name == exampleParameter.Parameter.CSharpName())
                            {
                                paramName = WriteExampleParameterDeclaration(exampleParameter, passThruParameter);
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
                                _writer.LineRaw($"{passThruParameter.Type.Name}? {paramName} = null;");
                            }
                        }
                        paramNames.Add(paramName);
                    }

                    _writer.Line();
                    _writer.Append($"return {GetAwait(isAsync)} container.{testMethodName}(");
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

        public string GenExampleInstanceMethodName(RestClientMethod clientMethod, bool isAsync)
        {
            return $"{clientMethod.Name}ExampleInstance{GetAsyncSuffix(isAsync)}";
        }

        public IEnumerable<Parameter> GenExampleInstanceMethodParameters(RestClientMethod clientMethod)
        {
            var parameterMapping = BuildParameterMapping(clientMethod);
            var passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);
            return passThruParameters.Where(p => p.ValidateNotNull && p.Type.IsFrameworkType && (p.Type.FrameworkType.IsPrimitive || p.Type.FrameworkType == typeof(String))); // define all primitive parameters as method parameter
        }

        public static ExampleGroup? FindExampleGroup(BuildContext<MgmtOutputLibrary> context, ResourceContainer resourceContainer, RestClientMethod? clientMethod)
        {
            if (clientMethod is null)
                return null;
            return (from x in context.CodeModel.TestModel?.MockTest.ExampleGroups where x.OperationId == $"{resourceContainer.OperationGroup.Key}_{clientMethod.Operation.Language.Default.Name}" select x).FirstOrDefault();
        }

        public static bool HasCreateExample(BuildContext<MgmtOutputLibrary> context, ResourceContainer resourceContainer)
        {
            var exampleGroup = FindExampleGroup(context, resourceContainer, resourceContainer.CreateMethod);
            return exampleGroup is not null && exampleGroup.Examples.Count() > 0;
        }

        public static bool IsRootResourceType(string resourceType)
        {
            return resourceType.Equals(ResourceTypeBuilder.ResourceGroupResources) || resourceType.Equals(ResourceTypeBuilder.Subscriptions) || resourceType.Equals(ResourceTypeBuilder.Tenant);
        }
        public static bool CanCreateResourceFromExample(BuildContext<MgmtOutputLibrary> context, ResourceContainer resourceContainer)
        {
            if (IsRootResourceType(resourceContainer.OperationGroup.ResourceType(context.Configuration.MgmtConfiguration)))
                return true;
            var hasCreateExample = HasCreateExample(context, resourceContainer);
            if (!hasCreateExample)
                return false;

            var parentResourceType = resourceContainer.OperationGroup.ParentResourceType(context.Configuration.MgmtConfiguration);
            if (IsRootResourceType(parentResourceType))
                return true;

            var parentOperationGroup = resourceContainer.OperationGroup.ParentOperationGroup(context);
            if (parentOperationGroup is null)
                return true;
            var parentResourceContainer = context.Library.GetResourceContainer(parentOperationGroup);
            if (parentResourceContainer is null)
                return true;

            return CanCreateResourceFromExample(context, parentResourceContainer);
        }

        public static bool CanCreateParentResourceFromExample(BuildContext<MgmtOutputLibrary> context, ResourceContainer resourceContainer)
        {
            var parentOperationGroup = resourceContainer.OperationGroup.ParentOperationGroup(context);
            if (parentOperationGroup is null)
                return true;
            var parentResourceContainer = context.Library.GetResourceContainer(parentOperationGroup);
            if (parentResourceContainer is null)
                return true;
            return CanCreateResourceFromExample(context, parentResourceContainer);
        }
    }
}
