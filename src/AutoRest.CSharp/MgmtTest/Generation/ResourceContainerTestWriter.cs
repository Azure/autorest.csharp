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

namespace AutoRest.CSharp.Mgmt.TestGeneration
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
    internal class ResourceContainerTestWriter : MgmtTestBaseWriter
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

        protected string TestNamespace => TypeOfContainer.Namespace + ".Tests";
        protected override string TypeNameOfThis => TypeOfContainer.Name + "MockTests";
        protected string TestEnvironmentName => _context.DefaultLibraryName + "TestEnvironment";
        protected string TestBaseName => _context.DefaultLibraryName + "TestBase";

        protected Dictionary<string, EnumType> EnumTypes => CollectEnumTypes(_context);

        public ResourceContainerTestWriter(CodeWriter writer, ResourceContainer resourceContainer, BuildContext<MgmtOutputLibrary> context)
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
            _writer.UseNamespace("NUnit.Framework");
            _writer.UseNamespace("Azure.Core.TestFramework");
            _writer.UseNamespace("Azure.ResourceManager.TestFramework");
            _writer.UseNamespace("Azure.ResourceManager.Resources");
            _writer.UseNamespace("Azure.ResourceManager.Compute.Tests.Helpers");

            using (_writer.Namespace(TestNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"Test for {_resourceContainer.ResourceName}");
                _writer.Append($"public partial class {TypeNameOfThis:D} : ");
                _writer.Line($"{TestBaseName}");
                using (_writer.Scope())
                {
                    // WriteFields(_writer, _restClient!);
                    WriteContainerTesterCtors();

                    WriteCreateContainerFromResourceGroup();
                    WriteCreateOrUpdate();
                    // WriteCreateResourceGroup();
                }
            }
        }

        protected void WriteContainerTesterCtors()
        {
            // write protected default constructor
            _writer.Line();
            using (_writer.Scope($"public {TypeNameOfThis}(bool isAsync): base(isAsync)"))
            { }
        }

        protected void WriteCreateContainerFromResourceGroup()
        {
            // write protected default constructor
            _writer.Line();
            using (_writer.Scope($"private async Task<{TypeNameOfContainer}> Get{TypeNameOfContainer}Async()"))
            {
                _writer.Line($"var resourceGroup = await CreateResourceGroupAsync();");
                _writer.Line($"return resourceGroup.Get{_resourceContainer.Resource.Type.Name.ToPlural()}();");
            }
        }

        protected void WriteCreateOrUpdate()
        {
            _writer.Line();
            if (_resourceContainer.CreateMethod != null)
            {
                WriteCreateOrUpdateVariants(_resourceContainer.CreateMethod, _resourceContainer.PutMethods);
            }
        }

        protected void WriteCreateResourceGroup()
        {
            // write protected default constructor
            _writer.Line();
            using (_writer.Scope($"protected async Task<ResourceGroup> CreateResourceGroupAsync()"))
            {
                _writer.Line($"var resourceGroupName = Recording.GenerateAssetName(\"testRG - \");");
                _writer.Append($"return await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(resourceGroupName");
                using (_writer.Scope($"new ResourceGroupData(DefaultLocation)"))
                {
                    using (_writer.Scope($"Tags ="))
                    {
                        _writer.Line($"{{ \"test\", \"env\" }}");
                    }
                }
            }
        }

        private void WriteCreateOrUpdateVariants(RestClientMethod clientMethod, List<RestClientMethod>? clientMethods = null)
        {
            WriteFirstLROMethodTest(clientMethod, _context, false, true, "CreateOrUpdate");
            WriteFirstLROMethodTest(clientMethod, _context, true, true, "CreateOrUpdate");

            //WriteStartLROMethod(_writer, clientMethod, _context, false, true, "CreateOrUpdate", clientMethods);
            //WriteStartLROMethod(_writer, clientMethod, _context, true, true, "CreateOrUpdate", clientMethods);
        }

        protected void WriteGetContainer()
        {
            _writer.Line($"var container = await Get{TypeNameOfContainer}Async();");
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
            var constructor = sot.Constructors[0];
            // find the simplest constructor
            foreach (var c in sot.Constructors)
            {
                if (c.Signature.Parameters.Length < constructor.Signature.Parameters.Length)
                    constructor = c;
            }
            HashSet<ObjectTypeProperty> consumedProperties = new HashSet<ObjectTypeProperty>();
            var signature = constructor.Signature;
            // var variableName = sot.Declaration.Name;
            writer.Append($"new {signature.Name}(");
            foreach (var p in signature.Parameters)
            {
                // _writer.WriteParameter(parameter);
                // var property2 = sot.Properties.Where(x => x.Declaration.Name.ToVariableName() == p.Name).FirstOrDefault().SchemaProperty;
                // var property = constructor.FindPropertyInitializedByParameter(p)?.SchemaProperty;
                var targetProperty = constructor.FindPropertyInitializedByParameter(p);
                var paramValue = FindPropertyValue(sot, ev, targetProperty!);
                if (paramValue is not null)
                {
                    // _writer.Append($"var ");
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
                // <{cst.Arguments[0]}, {cst.Arguments[1]}>
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
                writer.Append($"JsonSerializer.Deserialize<object>({JsonSerializer.Serialize(ConvertToStringDictionary(exampleValue.RawValue!)):L})");
            }
            else if (cst.Name == "ResourceIdentifier")
            {
                writer.Append($"new {cst}({exampleValue.RawValue:L})");
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
            //  _writer.Append($"{ModelWriter.GetValueFieldName(enumType.Declaration.Name, (string)exampleValue.RawValue!, enumType.Values)}");
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
                // var jsonSerialization = _resourceData.Serializations.Where(x => typeof(JsonSerialization).IsInstanceOfType(x)).First();
                _writer.Append($"var {variableName} = ");
                // _writer.Append($"var ");
                //DeserializeExampleValue (_resourceData, exampleParameter.ExampleValue, variableName);
                WriteSchemaObjectExampleValue(_writer, _resourceData, exampleParameter.ExampleValue, variableName);
                _writer.Line($";");
                // _writer.Line($";");
                // var constructor = _resourceData.Constructors[0];
                //foreach (var c in _resourceData.Constructors)
                //{
                //    if (c.Signature.Parameters.Length > constructor.Signature.Parameters.Length)
                //        constructor = c;
                //}

                //var signature = constructor.Signature;
                //_writer.Append($"var {variableName} = new {signature.Name}(");
                //foreach (var p in signature.Parameters)
                //{
                //    // _writer.WriteParameter(parameter);
                //    // var property2 = _resourceData.Properties.Where(x => x.Declaration.Name.ToVariableName() == p.Name).FirstOrDefault().SchemaProperty;
                //    var property = constructor.FindPropertyInitializedByParameter(p)?.SchemaProperty;

                //    if (exampleParameter.ExampleValue.CSharpName() == property?.CSharpName())
                //    {
                //        _writer.Append($"{BuildValueString(exampleParameter.ExampleValue, exampleParameter.ExampleValue.Schema)},");
                //    }
                //}
                //_writer.RemoveTrailingComma();
                //_writer.Line($");");

            }
            else
            {
                _writer.Append($"var {variableName} = ");
                WriteExampleValue(_writer, parameter.Type, exampleParameter.ExampleValue, variableName);
                _writer.Line($";");
            }
            //else if (parameter.Type.Name == "String")
            //{
            //    _writer.Append($"var {variableName} = \"{exampleParameter.ExampleValue.RawValue}\";");
            //    _writer.Line();
            //}
            //else
            //{
            //    _writer.LineRaw($"var {variableName} = {exampleParameter.ExampleValue.RawValue};");
            //    _writer.Line();
            //}

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

        protected void WriteFirstLROMethodTest(RestClientMethod clientMethod, BuildContext<MgmtOutputLibrary> context, bool isAsync, bool isVirtual, string? methodName = null)
        {
            Debug.Assert(clientMethod.Operation != null);

            methodName = methodName ?? clientMethod.Name;
            // CSharpType returnType = isAsync? typeof(Task): typeof(void);
            var parameterMapping = BuildParameterMapping(clientMethod);
            var passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            WriteTestDecorator(_writer);
            var testMethodName = CreateMethodName(methodName, isAsync);
            _writer.Append($"public async Task {testMethodName}()");
            var paramNames = new List<string>();
            using (_writer.Scope())
            {
                WriteGetContainer();

                var exampleGroup = (from x in context.CodeModel.TestLayout?.MockTest.ExampleGroups where x.Name == $"{_resourceContainer.OperationGroup.Key}_{clientMethod.Operation.Language.Default.Name}" select x).FirstOrDefault();
                foreach (var exampleModel in exampleGroup?.Examples ?? Enumerable.Empty<ExampleModel>())
                {
                    // do something with entry.Value or entry.Key
                    _writer.LineRaw($"// Example: {exampleModel.Name}");
                    foreach (var passThruParameter in passThruParameters)
                    {
                        string? paramName = null;
                        foreach (ExampleParameter exampleParameter in exampleModel.MethodParameters)
                        {
                            if (passThruParameter.Name == exampleParameter.Parameter.CSharpName())
                            {
                                // paramName = WriteParameter(clientMethod, context, exampleParameter, passThruParameter);
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
                                _writer.LineRaw($"var {paramName} = null;");
                            }
                        }
                        paramNames.Add(paramName);
                    }

                    _writer.Line();
                    _writer.Append($"{(isAsync ? ("await ") : "")}container.{testMethodName}(");
                    foreach (var paramName in paramNames)
                    {
                        _writer.Append($"{paramName},");
                    }
                    _writer.RemoveTrailingComma();
                    _writer.LineRaw(");");
                    break;
                }
            }

            // ///////////////////


            //writer.Line();
            //writer.WriteXmlDocumentationSummary($"{clientMethod.Description}");

            //var parameterMapping = BuildParameterMapping(clientMethod);
            //var passThruParameters = parameterMapping.Where(p => p.IsPassThru).Select(p => p.Parameter);

            //foreach (var parameter in passThruParameters)
            //{
            //    writer.WriteXmlDocumentationParameter(parameter);
            //}

            //writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            //writer.WriteXmlDocumentationRequiredParametersException(passThruParameters.ToArray());

            //CSharpType? returnType = GetLROReturnType(clientMethod, context);
            //CSharpType responseType = returnType != null ?
            //    new CSharpType(typeof(Response<>), returnType) :
            //    typeof(Response);
            //responseType = responseType.WrapAsync(isAsync);

            //writer.Append($"public {GetAsyncKeyword(isAsync)} {GetVirtual(isVirtual)} {responseType} {CreateMethodName(methodName, isAsync)}(");
            //foreach (var parameter in passThruParameters)
            //{
            //    writer.WriteParameter(parameter);
            //}
            //writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            //using (writer.Scope())
            //{
            //    writer.WriteParameterNullChecks(passThruParameters.ToArray());

            //    Diagnostic diagnostic = new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>());
            //    WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
            //    {
            //        var operation = new CodeWriterDeclaration("operation");
            //        writer.Append($"var {operation:D} = {GetAwait(isAsync)}");
            //        writer.Append($"{CreateMethodName($"Start{methodName}", isAsync)}(");
            //        WriteArguments(writer, parameterMapping.Where(p => p.IsPassThru));
            //        writer.Line($"cancellationToken){GetConfigureAwait(isAsync)};");

            //        writer.Append($"return {GetAwait(isAsync)}");
            //        var waitForCompletionMethod = returnType == null && isAsync ?
            //        "WaitForCompletionResponse" :
            //        "WaitForCompletion";
            //        writer.Line($"{operation}.{CreateMethodName(waitForCompletionMethod, isAsync)}(cancellationToken){GetConfigureAwait(isAsync)};");
            //    });
            //    writer.Line();
            //}
        }

        protected override void MakeResourceNameParamPassThrough(RestClientMethod restMethod, List<ParameterMapping> parameterMapping, Stack<string> parentNameStack)
        {
            // if the method needs resource name (typically all non-list methods), we should make it pass-thru by
            // making the last string-like mandatory parameter (typically the resource name) pass-through
            if (!restMethod.IsListMethod())
            {
                var lastString = parameterMapping.LastOrDefault(parameter => parameter.Parameter.Type.IsStringLike() && IsMandatory(parameter.Parameter));
                if (lastString?.Parameter != null)
                {
                    var paramName = lastString.Parameter.Name;
                    if (!paramName.Equals("resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                    {
                        lastString.IsPassThru = true;
                        parentNameStack.Pop();
                    }
                }
            }
        }

        protected override bool ShouldPassThrough(ref string dotParent, Stack<string> parentNameStack, Parameter parameter, ref string valueExpression)
        {
            bool passThru = false;
            var isAncestorResourceTypeTenant = _resource.OperationGroup.IsAncestorResourceTypeTenant(_context);
            if (string.Equals(parameter.Name, "resourceGroupName", StringComparison.InvariantCultureIgnoreCase) && !isAncestorResourceTypeTenant)
            {
                valueExpression = "Id.ResourceGroupName";
            }
            else
            {
                // container.Id is the ID of parent resource, so the first name should just be `Id.Name`
                parentNameStack.Push($"Id{dotParent}.Name");
                dotParent += ".Parent";
            }

            return passThru;
        }
    }
}
