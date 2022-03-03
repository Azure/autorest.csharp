// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    internal partial class MgmtBaseTestWriter: MgmtClientBaseWriter
    {
        public Queue<CodeWriterDelegate> assignmentWriterDelegates = new Queue<CodeWriterDelegate>();

        protected IEnumerable<string>? scenarioVariables;

        protected bool inScenario => scenarioVariables is not null;

        public MgmtBaseTestWriter(CodeWriter writer, MgmtTypeProvider provider, IEnumerable<string>? scenarioVariables) : base(writer, provider)
        {
            this.scenarioVariables = scenarioVariables;
        }

        public void WriteTestDecorator()
        {
            _writer.Line($"[RecordedTest]");

            var testModelerConfig = Configuration.MgmtConfiguration.TestModeler;
            string? ignoreReason = testModelerConfig?.IgnoreReason;
            if (ignoreReason is not null)
            {
                _writer.UseNamespace("NUnit.Framework");
                _writer.Line($"[Ignore(\"{ignoreReason}\")]");
            }
        }

        public string FormatResourceId(string resourceId)
        {
            if (resourceId.Length == 0)
            {
                return "/subscriptions/00000000-0000-0000-0000-000000000000";   // provide a fake resourceId to fullfill the ResourceIdentifier check
            }
            if (!resourceId.StartsWith('/'))
            {
                resourceId = '/' + resourceId;
            }
            resourceId = resourceId.Replace("{", "{{").Replace("}", "}}");
            var elements = resourceId.Split("/");
            for (int i = 2; i< elements.Length; i+=2)
            {
                if (elements[i-1].ToLower()== "subscriptions" && !inScenario)
                {
                    Regex regex = new Regex("^{[A-Z0-9]{8}-([A-Z0-9]{4}-){3}[A-Z0-9]{12}}$");
                    Match match = regex.Match(elements[i]);
                    if (!match.Success)
                    {
                        elements[i] = "00000000-0000-0000-0000-000000000000";
                    }
                }
            }
            return String.Join("/", elements);
        }

        public static string GetTaskOrVoid(bool isAsync)
        {
            return isAsync ? "Task" : "void";
        }

        public static ExampleGroup? FindExampleGroup(MgmtRestOperation restOperation)
        {
            if (restOperation is null)
                return null;
            foreach (var exampleGroup in MgmtContext.CodeModel.TestModel?.MockTest.ExampleGroups ?? Enumerable.Empty<ExampleGroup>())
            {
                if (exampleGroup.Examples.Count > 0 && exampleGroup.Examples.First().Operation == restOperation.Operation)
                {
                    return exampleGroup;
                }
            }
            return null;
        }

        public static SortedDictionary<RequestPath, MgmtRestOperation> GetSortedOperationMappings(MgmtClientOperation clientOperation) {
            var operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            return new SortedDictionary<RequestPath, MgmtRestOperation>(operationMappings, Comparer<RequestPath>.Create(
                (x1, x2) =>
                {
                    // order by path length descendently
                    if (x1.ToString() is null)
                    {
                        return 1;
                    }
                    else if (x2.ToString() is null)
                    {
                        return -1;
                    }

                    return x2.ToString()!.Length - x1.ToString()!.Length;
                }));
        }

        public static bool HasExample(MgmtClientOperation? clientOperation)
        {
            if (clientOperation is null)
            {
                return false;
            }

            foreach ((var branch, var operation) in GetSortedOperationMappings(clientOperation))
            {
                var exampleGroup = MgmtBaseTestWriter.FindExampleGroup(operation);
                if (exampleGroup is not null && exampleGroup.Examples.Count > 0)
                    return true;
                break;
            }
            return false;
        }

        public static ObjectTypeProperty? FindPropertyThroughSerialization(List<string> flattenedNames, JsonSerialization js)
        {
            if (flattenedNames.Count == 0)
            {
                return null;
            }
            if (js is JsonObjectSerialization obj)
            {
                foreach (JsonPropertySerialization property in obj.Properties)
                {
                    if (flattenedNames[0] == property.Name)
                    {
                        if (flattenedNames.Count == 1)
                            return property.Property;
                        return FindPropertyThroughSerialization(flattenedNames.Skip(1).ToList(), property.ValueSerialization);
                    }
                }
            }
            return null;
        }

        public static ExampleValue? FindPropertyValue(ObjectType ot, ExampleValue ev, ObjectTypeProperty targetProperty)
        {
            if (ot is SchemaObjectType sot)
            {
                var obj = (JsonSerialization)sot.Serializations.Single(x => typeof(JsonSerialization).IsInstanceOfType(x));
                foreach (var exampleProperty in ev.Properties ?? new DictionaryOfExamplValue())
                {
                    var property = FindPropertyThroughSerialization(exampleProperty.Value.FlattenedNames is not null ? exampleProperty.Value.FlattenedNames.ToList()! : new List<string> { exampleProperty.Key }, obj);
                    if (property == targetProperty)
                    {
                        return exampleProperty.Value;
                    }
                }
            }
            else
            {
                foreach (var exampleProperty in ev.Properties ?? new DictionaryOfExamplValue())
                {
                    foreach (var property in ot.Properties)
                    {
                        if (property == targetProperty)
                        {
                            return exampleProperty.Value;
                        }
                    }
                }
            }

            return null;
        }

        private ObjectTypeConstructor FindSuitableConstructor(ObjectType sot, ExampleValue ev)
        {
            var constructor = sot.Constructors[0];
            foreach (var c in sot.Constructors)
            {
                if (c.Signature.Parameters.Count < constructor.Signature.Parameters.Count && c.Signature.Modifiers.HasFlag(Public))
                    constructor = c;
            }

            // There is customized information not loaded in codegen for "Azure.ResourceManager.Resources.Models", use the simplest constructor
            if (sot.Type.Namespace == "Azure.ResourceManager.Resources.Models")
            {
                return constructor;
            }

            foreach (var c in sot.Constructors)
            {
                if (!c.Signature.Modifiers.HasFlag(Public))
                    continue;
                var missAnyRequiredParameter = false;
                foreach (var p in c.Signature.Parameters)
                {
                    if (!p.IsRequired)
                        continue;
                    var targetProperty = c.FindPropertyInitializedByParameter(p);
                    if (targetProperty is null)
                    {
                        missAnyRequiredParameter = true;
                        break;
                    }
                    var paramValue = FindPropertyValue(sot, ev, targetProperty!);
                    if (paramValue is null)
                    {
                        missAnyRequiredParameter = true;
                        break;
                    }
                }
                if (!missAnyRequiredParameter)
                {
                    if (c.Signature.Parameters.Count > constructor.Signature.Parameters.Count)
                        constructor = c;
                }
            }
            return constructor;
        }

        public FormattableString PropertyVaraibleName(FormattableString variableName, ObjectTypeProperty targetProperty)
        {
            bool isSingleProperty = targetProperty.IsSinglePropertyObject(out var innerProperty);
            return isSingleProperty ? variableName : $"{variableName}.{targetProperty.Declaration.Name}";
        }

        public void WriteSchemaObjectExampleValue(CodeWriter writer, ObjectType sot, ExampleValue ev, FormattableString variableName)
        {
            // Find Polimophismed schema
            if (sot is SchemaObjectType && MgmtContext.Library.SchemaMap.ContainsKey(ev.Schema))
            {
                var mappedTypeProvider = MgmtContext.Library.SchemaMap[ev.Schema];
                if (mappedTypeProvider is SchemaObjectType mappedSot)
                {
                    sot = mappedSot;
                }
            }

            var constructor = FindSuitableConstructor(sot, ev);
            HashSet<ObjectTypeProperty> consumedProperties = new HashSet<ObjectTypeProperty>();
            var signature = constructor.Signature;

            writer.Append($"new {sot.Type}(");
            foreach (var p in signature.Parameters)
            {
                var targetProperty = constructor.FindPropertyInitializedByParameter(p);
                if (targetProperty is null)
                {
                    writer.Append($"default, /* Can't find property for this parameter!*/");
                    continue;
                }
                var paramValue = FindPropertyValue(sot, ev, targetProperty);
                writer.Append($"{p.Name:D}: ");
                if (paramValue is not null)
                {
                    WriteExampleValue(writer, p.Type, paramValue!, $"{PropertyVaraibleName(variableName, targetProperty)}");
                }
                else
                {
                    // initiate for special parameter, others provide default
                    if (p.Name == "location")
                    {
                        writer.Append($"{typeof(AzureLocation)}.WestUS");
                    }
                    else
                    {
                        writer.Append($"default /* don't find example value for this parameter!*/");
                    }
                }
                writer.AppendRaw(",");
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
                        break;
                    }
                }
            }

            if (hasUnconsumedProperties)
                WriteSchemaObjectExampleProperties(writer, sot, ev, variableName, consumedProperties);

            // assign readonly list and dictionary properties.
            foreach (var objectType in sot.EnumerateHierarchy())
            {
                foreach (var targetProperty in objectType.Properties)
                {
                    if (consumedProperties.Contains(targetProperty))
                        continue;
                    var paramValue = FindPropertyValue(sot, ev, targetProperty!);
                    if (paramValue is not null)
                    {
                        assignmentWriterDelegates.Enqueue(CreateAssignmentWriterDelegate(targetProperty.ValueType, paramValue, $"{PropertyVaraibleName(variableName, targetProperty)}"));
                    }
                }
            }
        }

        public CodeWriterDelegate CreateAssignmentWriterDelegate(CSharpType cst, ExampleValue exampleValue, FormattableString variableName)
        {
            return new CodeWriterDelegate(writer =>
            {
                if (cst.Name == "IList" || cst.Name == "IEnumerable")
                {
                    writer.UseNamespace("System.Collections.Generic");
                    var idx = 0;
                    foreach (var element in exampleValue.Elements ?? new List<ExampleValue>())
                    {
                        writer.Append($"{variableName}.Add(");
                        WriteExampleValue(writer, cst.Arguments[0], element, $"{variableName}[{idx}]");
                        writer.Line($");");
                        idx++;
                    }
                }
                else if (cst.Name == "IDictionary")
                {
                    writer.UseNamespace("System.Collections.Generic");
                    foreach (var entry in exampleValue.Properties ?? new DictionaryOfExamplValue() { })
                    {
                        var k = entry.Key.RefScenariDefinedVariables(scenarioVariables);
                        writer.Append($"${variableName}[{k}] = ");
                        WriteExampleValue(writer, cst.Arguments[1], entry.Value, $"{variableName}[{k}]");
                        writer.Line($";");
                    }
                }
            });
        }

        protected void AddTagWriterDelegate(FormattableString newVariableName, CSharpType valueType, ExampleValue ev)
        {
            assignmentWriterDelegates.Enqueue(new CodeWriterDelegate(writer =>
            {
                writer.Append($"{newVariableName}.ReplaceWith(");
                WriteExampleValue(writer, valueType, ev, newVariableName);
                writer.Line($");");
            }));
        }

        private void WriteSchemaObjectExampleProperties(CodeWriter writer, ObjectType sot, ExampleValue ev, FormattableString variableName, HashSet<ObjectTypeProperty> consumedProperties)
        {
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
                            FormattableString newVariableName = $"{PropertyVaraibleName(variableName, targetProperty)}";
                            if (targetProperty.Declaration.Name == "Tags" && targetProperty.ValueType.Name == "IDictionary")
                            {
                                AddTagWriterDelegate(newVariableName, targetProperty.ValueType, paramValue);
                                consumedProperties.Add(targetProperty);
                            }
                            else if (!targetProperty.IsSinglePropertyObject(out var innerProperty))
                            {
                                writer.Append($"{targetProperty.Declaration.Name:D} = ");
                                WriteExampleValue(writer, targetProperty.ValueType, paramValue!, newVariableName);
                                writer.Append($", ");
                                consumedProperties.Add(targetProperty);
                            }
                        }
                    }
                }
            }
        }

        public void WriteJsonRawValue(CodeWriter writer, JsonRawValue jsonRawValue) {
            if (jsonRawValue.IsEnumerable()) {
                using (writer.Scope($"new object[]"))
                {
                    foreach (var element in jsonRawValue.AsEnumerable()) {
                        WriteJsonRawValue(writer, new JsonRawValue(element));
                        writer.Line($",");
                    }
                }
            }
            else if (jsonRawValue.IsDictionary()) {
                using (writer.Scope($"new {typeof(Dictionary<string, object?>)}()"))
                {
                    foreach (var entry in jsonRawValue.AsDictionary())
                    {
                        writer.Append($"[{entry.Key.RefScenariDefinedVariables(scenarioVariables)}] = ");
                        WriteJsonRawValue(writer, new JsonRawValue(entry.Value));
                        writer.Line($",");
                    }
                }
            }
            else if (jsonRawValue.IsString()) {
                writer.Append($"{jsonRawValue.AsString().RefScenariDefinedVariables(scenarioVariables)}");
            }
            else if (jsonRawValue.IsNull())
            {
                writer.Append($"null");
            }
            else {
                writer.Append($"{jsonRawValue.RawValue}");
            }
        }

        public void WriteFrameworkTypeExampleValue(CodeWriter writer, CSharpType cst, ExampleValue exampleValue, FormattableString variableName)
        {
            if (cst.Name == "IList" || cst.Name == "IEnumerable")
            {
                writer.UseNamespace("System.Collections.Generic");
                using (writer.Scope($"new List<{cst.Arguments[0]}>()", newLine: false))
                {
                    var idx = 0;
                    foreach (var element in exampleValue.Elements ?? new List<ExampleValue>())
                    {
                        WriteExampleValue(writer, cst.Arguments[0], element, $"{variableName}[{idx}]");
                        writer.Append($",");
                        idx++;
                    }
                }
            }
            else if (cst.Name == "IDictionary")
            {
                writer.UseNamespace("System.Collections.Generic");
                using (writer.Scope($"new {new CSharpType(typeof(Dictionary<,>), cst.Arguments)}()", newLine: false))
                {
                    foreach (var entry in exampleValue.Properties ?? new DictionaryOfExamplValue() { })
                    {
                        var k = entry.Key.RefScenariDefinedVariables(scenarioVariables);
                        writer.Append($"[{k}] = ");
                        WriteExampleValue(writer, cst.Arguments[1], entry.Value, $"{variableName}[{k}]");
                        writer.Append($",");
                    }
                }
            }
            else if (cst.Name == "Object")
            {
                WriteJsonRawValue(writer, new JsonRawValue(exampleValue.RawValue));
            }
            else if (cst.Name == "ResourceIdentifier" || cst.Name == "ResourceType")
            {
                writer.Append($"new {cst}(${FormatResourceId(exampleValue.RawValue!.ToString()!).RefScenariDefinedVariables(scenarioVariables):L})");
            }
            else if (cst.Name == "DateTimeOffset" && exampleValue.RawValue is string dtValue)
            {
                writer.Append($"{typeof(DateTimeOffset)}.Parse({dtValue.RefScenariDefinedVariables(scenarioVariables)})");
            }
            else if (cst.Name == "Guid" && exampleValue.RawValue is string guidValue)
            {
                writer.Append($"System.Guid.Parse({guidValue.RefScenariDefinedVariables(scenarioVariables)})");
            }
            else if (cst.Name == "TimeSpan" && exampleValue.RawValue is string tsValue)
            {
                writer.Append($"System.TimeSpan.Parse({tsValue.RefScenariDefinedVariables(scenarioVariables)})");
            }
            else if (exampleValue.RawValue is not null && exampleValue.RawValue is string strValue)
            {
                if (new string[] { "String", "AzureLocation" }.Contains(cst.FrameworkType.Name))
                {
                    writer.Append($"{strValue.RefScenariDefinedVariables(scenarioVariables)}");
                }
                else
                {
                    try
                    {
                        writer.Append($"{exampleValue.RawValue}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
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

        public void WriteEnumTypeExampleValue(CodeWriter writer, EnumType enumType, ExampleValue exampleValue)
        {
            if (enumType.IsExtendable)
            {
                if (new string[] { "String" }.Contains(enumType.BaseType.FrameworkType.Name) && exampleValue.RawValue is string strValue)
                {
                    writer.AppendEnumFromString(enumType, w => w.Append($"{strValue.RefScenariDefinedVariables(scenarioVariables)}"));
                }
                else
                {
                    writer.AppendEnumFromString(enumType, w => w.Append($"{exampleValue.RawValue}"));
                }
            }
            else
            {
                foreach (EnumTypeValue value in enumType.Values)
                {
                    if ((bool)enumType.BaseType.FrameworkType.GetMethod("Equals", new[] { enumType.BaseType.FrameworkType, enumType.BaseType.FrameworkType })!.Invoke(null, new object?[] { exampleValue.RawValue, value.Value.Value })!)
                    {
                        writer.Append($"{enumType.Declaration.Namespace}.{enumType.Declaration.Name}.{value.Declaration.Name}");
                        return;
                    }
                }
                throw new Exception($"Can't resolve {exampleValue.RawValue:L} as {enumType.Declaration.Name} value!");
            }
        }

        public void WriteExampleValue(CodeWriter writer, CSharpType cst, ExampleValue exampleValue, FormattableString variableName)
        {
            TypeProvider? tp = cst.IsFrameworkType ? null : cst.Implementation;
            switch (tp)
            {
                case SchemaObjectType sot:
                    WriteSchemaObjectExampleValue(writer, sot, exampleValue, variableName);
                    break;
                case SystemObjectType sot:
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

        public FormattableString WriteExampleParameterDeclaration(CodeWriter writer, ExampleParameter exampleParameter, Parameter parameter)
        {
            var variableName = new CodeWriterDeclaration(exampleParameter.Parameter.CSharpName());
            writer.Append($"{parameter.Type} {variableName:D} = ");
            FormattableString formattableVariableName = $"{variableName}";
            WriteExampleValue(writer, parameter.Type, exampleParameter.ExampleValue, formattableVariableName);
            writer.Line($";");

            while (assignmentWriterDelegates.Count > 0)
            {
                writer.Append($"{assignmentWriterDelegates.Dequeue()}");
            }
            return formattableVariableName;
        }

        public static string BuildValueString(ExampleValue exampleValue, Schema schema)
        {
            return $"\"{exampleValue.RawValue}\"";
        }

        public override void Write()
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingletonResourceEntry(Resource resource, string singletonResourceIdSuffix, MethodSignature signature)
        {
            throw new NotImplementedException();
        }

        protected override void WriteResourceCollectionEntry(ResourceCollection resource, MethodSignature signature)
        {
            throw new NotImplementedException();
        }

        public List<KeyValuePair<string, FormattableString>> WriteOperationParameters(IEnumerable<Parameter> methodParameters, ExampleModel exampleModel)
        {
            var parameterValues = new List<KeyValuePair<string, FormattableString>>();
            foreach (var passThruParameter in methodParameters)
            {
                if (passThruParameter.Name == KnownParameters.WaitForCompletion.Name ||
                    passThruParameter.Name == KnownParameters.CancellationTokenParameter.Name)
                    continue;
                FormattableString? paramName = null;
                foreach (ExampleParameter exampleParameter in exampleModel.AllParameter)
                {
                    if (passThruParameter.Name == exampleParameter.Parameter.CSharpName())
                    {
                        paramName = WriteExampleParameterDeclaration(_writer, exampleParameter, passThruParameter);
                    }
                }
                if (paramName is null)
                {
                    var paramNameDeclare = new CodeWriterDeclaration(passThruParameter.Name);
                    if (passThruParameter.Validate)
                    {
                        _writer.Line($"{passThruParameter.Type} {paramNameDeclare:D} = default; /* Can't find this parameter in example, please provide value here!*/");
                    }
                    else
                    {
                        _writer.Line($"{passThruParameter.Type} {paramNameDeclare:D} = default;");
                    }
                    paramName = $"{paramNameDeclare}";
                }
                parameterValues.Add(new KeyValuePair<string, FormattableString>(passThruParameter.Name, paramName));
            }
            return parameterValues;
        }

        public string? ParseRequestPath(MgmtTypeProvider tp, string requestPath, ExampleModel exampleModel)
        {
            List<string> result = new List<string>();
            var segements = requestPath.Split('/');
            if (tp is Resource resource)
                    {
                        var resourceTypeSegments = resource.ResourceType.SerializedType.Split('/');
                        bool inResourceType = false;
                        int idxInResourceType = 1;
                        bool odd = true;
                        foreach (string segment in segements)
                        {
                            if (segment == resourceTypeSegments[0])
                            {
                                inResourceType = true;
                            }
                            if (segment.StartsWith("{") && segment.EndsWith("}"))
                            {
                                var v = FindParameterValueByName(exampleModel, segment.Substring(1, segment.Length - 2));
                                if (v is null)
                                {
                                    return null;
                                }
                                result.Add(v);
                            }
                            else
                            {
                                if (inResourceType && !odd)
                                {
                                    if (idxInResourceType >= resourceTypeSegments.Length)
                                    {
                                        break;
                                    }
                                    if (segment.ToLower() != resourceTypeSegments[idxInResourceType++].ToLower())
                                    {
                                        break;
                                    }
                                }
                                result.Add(segment);
                            }
                            odd = !odd;
                        }
                        return String.Join("/", result.ToArray());
                    }
            int maxSegment = 0;
            if (tp is MgmtExtensions extension)
            {
                if (extension.ArmCoreType == typeof(ResourceGroupResource))
                {
                    maxSegment = 5;
                }
                else if (extension.ArmCoreType == typeof(SubscriptionResource))
                {
                    maxSegment = 3;
                }
            }
            int i = 0;
            foreach (string segment in segements)
            {
                if (segment.StartsWith("{") && segment.EndsWith("}"))
                {
                    var v = FindParameterValueByName(exampleModel, segment.Substring(1, segment.Length - 2));
                    if (v is null)
                    {
                         return null;
                    }
                    result.Add(v);
                }
                else
                {
                    result.Add(segment);
                }
                if (++i >= maxSegment)
                    break;
            }
            return String.Join("/", result.ToArray());
        }

        public FormattableString ComposeResourceIdentifierParams(RequestPath requestPath, ExampleModel exampleModel)
        {
            var identifierParams = string.Join(", ", requestPath.Where(segment => segment.IsReference).Select(segment => {
                var value = "\"default\"";
                foreach (var parameterValue in exampleModel.AllParameter)
                {
                    if (parameterValue.Parameter.CSharpName() == segment.ReferenceName)
                    {
                        value = $"\"{parameterValue.ExampleValue.RawValue}\"";
                    }
                }

                if (segment.ReferenceName == "subscriptionId" && !inScenario)
                {
                    Regex regex = new Regex("^{[A-Z0-9]{8}-([A-Z0-9]{4}-){3}[A-Z0-9]{12}}$");
                    Match match = regex.Match(value);
                    if (!match.Success)
                    {
                        value = "\"00000000-0000-0000-0000-000000000000\"";
                    }
                }
                return value.RefScenariDefinedVariables(scenarioVariables);
            }));
            return $"{identifierParams}";
        }

        public string? FindParameterValueByName(ExampleModel exampleModel, string parameterName)
        {
            foreach (var parameterValue in exampleModel.AllParameter)
            {
                if ((parameterValue.Parameter.Language.Default.SerializedName ?? parameterValue.Parameter.Language.Default.Name) == parameterName)
                {
                    return parameterValue.ExampleValue.RawValue?.ToString();
                }
            }
            return null;
        }

        protected static CodeWriterDelegate WriteMethodInvocation(FormattableString methodName, IEnumerable<FormattableString> paramNames)
        {
            return new CodeWriterDelegate(writer =>
            {
                writer.Append($"{methodName}(");
                foreach (var paramName in paramNames)
                {
                    writer.Append($"{paramName},");
                }
                writer.RemoveTrailingComma();
                writer.Append($")");
            });
        }

        protected void WriteMethodTestInvocation(bool async, MgmtClientOperation clientOperation, bool isLroOperation, FormattableString methodName, IEnumerable<FormattableString> paramNames)
        {
            _writer.Append($"{GetAwait(async)}");
            if (isLroOperation || clientOperation.IsLongRunningOperation && !clientOperation.IsPagingOperation) {
                paramNames = new List<FormattableString>().Append<FormattableString>($"{typeof(WaitUntil)}.Completed").Concat(paramNames);   // assign  waitUntil = WaitUntil.Completed
            }

            if (clientOperation.IsPagingOperation)
            {
                using (_writer.Scope($"foreach (var _ in {WriteMethodInvocation($"{methodName}", paramNames)})"))
                { }
            }
            else
            {
                _writer.Line($"{WriteMethodInvocation($"{methodName}", paramNames)};");
            }
        }
    }
}
