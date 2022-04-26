﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
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
using AutoRest.CSharp.MgmtTest.TestCommon;
using AutoRest.CSharp.MgmtTest.Models;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    internal abstract partial class MgmtBaseTestWriter : MgmtClientBaseWriter
    {
        public Queue<CodeWriterDelegate> assignmentWriterDelegates = new Queue<CodeWriterDelegate>();

        protected IEnumerable<string>? _scenarioVariables;

        protected bool InScenario => _scenarioVariables is not null;

        public MgmtBaseTestWriter(CodeWriter writer, MgmtTypeProvider provider, IEnumerable<string>? scenarioVariables) : base(writer, provider)
        {
            this._scenarioVariables = scenarioVariables;
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

        protected void WriteMockTestContext()
        {
            _writer.Line($"{typeof(ServicePointManager)}.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;");
            _writer.Line($"{typeof(Environment)}.SetEnvironmentVariable(\"RESOURCE_MANAGER_URL\", $\"https://localhost:8443\");");
        }

        protected static string CreateTestMethodName(string methodName, int exampleIndex)
        {
            var testCaseSuffix = exampleIndex > 0 ? (exampleIndex + 1).ToString() : string.Empty;
            return methodName + testCaseSuffix;
        }

        public string FormatResourceId(string resourceId)
        {
            // Two purpose of this function:
            // 1. correct wrong sample values
            // 2. make a resource identifier string can be used in a string interpolation $"", for instance:
            // "/subscriptions/{subscriptionId}/resourceGroups/{myResourceGroup}"  --> "/subscriptions/{{subscriptionId}}/resourceGroups/{{myResourceGroup}}"
            // After the interpolation, the output will come back to it's original value.

            if (resourceId.Length == 0)
            {
                return "/subscriptions/00000000-0000-0000-0000-000000000000";   // provide a fake resourceId to fullfill the ResourceIdentifier check
            }
            if (!resourceId.StartsWith('/'))    // to correct incorrect sample value
            {
                resourceId = '/' + resourceId;
            }
            resourceId = resourceId.Replace("{", "{{").Replace("}", "}}");
            var elements = resourceId.Split("/");
            for (int i = 2; i < elements.Length; i += 2)
            {
                if (elements[i - 1].ToLower() == "subscriptions" && !InScenario)
                {   // to correct subscription value
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

        public static FormattableString GetTaskOrVoid(bool isAsync)
        {
            return isAsync ? (FormattableString)$"{typeof(Task)}" : (FormattableString)$"void";
        }

        public static ExampleGroup? FindExampleGroup(MgmtRestOperation restOperation)
        {
            if (restOperation is null)
                return null;
            foreach (var exampleGroup in MgmtContext.CodeModel.TestModel!.MockTest.ExampleGroups)
            {
                if (exampleGroup.Examples.Count > 0 && exampleGroup.Examples.First().Operation == restOperation.Operation)
                {
                    return exampleGroup;
                }
            }
            return null;
        }

        public static SortedDictionary<RequestPath, MgmtRestOperation> GetSortedOperationMappings(MgmtClientOperation clientOperation)
        {
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
            foreach (var exampleProperty in ev.Properties)
            {
                if (targetProperty.SchemaProperty?.SerializedName == exampleProperty.Key)
                    return exampleProperty.Value;

                // handle special cases hard coded in Azure.ResourceManager
                if (ot is SystemObjectType)
                {
                    if (targetProperty.SchemaProperty?.SerializedName == "managedServiceIdentityType" && exampleProperty.Key == "type")
                        return exampleProperty.Value;
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

            // There is customized information not loaded in codegen for "Azure.ResourceManager" as SystemObjectType, use the simplest constructor
            if (sot is SystemObjectType)
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
            bool isSingleProperty = targetProperty.IsSinglePropertyObject(out _);
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
                    WriteExampleValue(writer, p.Type, paramValue, $"{PropertyVaraibleName(variableName, targetProperty)}");
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
            return writer =>
            {
                if (cst.IsFrameworkType && cst.FrameworkType == typeof(IList<>))
                {
                    var idx = 0;
                    foreach (var element in exampleValue.Elements)
                    {
                        writer.Append($"{variableName}.Add(");
                        WriteExampleValue(writer, cst.Arguments[0], element, $"{variableName}[{idx}]");
                        writer.Line($");");
                        idx++;
                    }
                }
                else if (cst.IsFrameworkType && cst.FrameworkType == typeof(IDictionary<,>))
                {
                    foreach (var entry in exampleValue.Properties)
                    {
                        var keyDelegate = WriteStringValue(cst.Arguments[0], entry.Key);
                        writer.Append($"{variableName}[{keyDelegate}] = ");
                        WriteExampleValue(writer, cst.Arguments[1], entry.Value, $"{variableName}[{keyDelegate}]");
                        writer.Line($";");
                    }
                }
            };
        }

        protected void AddTagWriterDelegate(FormattableString newVariableName, CSharpType valueType, ExampleValue ev)
        {
            assignmentWriterDelegates.Enqueue(writer =>
            {
                writer.Append($"{newVariableName}.ReplaceWith(");
                WriteExampleValue(writer, valueType, ev, newVariableName);
                writer.Line($");");
            });
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
                            else if (!targetProperty.IsSinglePropertyObject(out _))
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

        public void WriteJsonRawValue(CodeWriter writer, JsonRawValue jsonRawValue)
        {
            if (jsonRawValue.IsEnumerable())
            {
                using (writer.Scope($"new object[]"))
                {
                    foreach (var element in jsonRawValue.AsEnumerable())
                    {
                        WriteJsonRawValue(writer, new JsonRawValue(element));
                        writer.Line($",");
                    }
                }
            }
            else if (jsonRawValue.IsDictionary())
            {
                using (writer.Scope($"new {typeof(Dictionary<string, object?>)}()"))
                {
                    foreach (var entry in jsonRawValue.AsDictionary())
                    {
                        writer.Append($"[{entry.Key.RefScenarioDefinedVariables(_scenarioVariables)}] = ");
                        WriteJsonRawValue(writer, new JsonRawValue(entry.Value));
                        writer.Line($",");
                    }
                }
            }
            else if (jsonRawValue.IsString())
            {
                writer.Append($"{jsonRawValue.AsString()!.RefScenarioDefinedVariables(_scenarioVariables)}");
            }
            else if (jsonRawValue.IsNull())
            {
                writer.Append($"null");
            }
            else
            {
                writer.Append($"{jsonRawValue.RawValue}");
            }
        }

        public void WriteFrameworkTypeExampleValue(CodeWriter writer, CSharpType cst, ExampleValue exampleValue, FormattableString variableName)
        {
            Debug.Assert(cst.IsFrameworkType);
            switch ($"{cst.Namespace}.{cst.Name}")
            {
                case "System.Collections.Generic.IList":
                    using (writer.Scope($"new {new CSharpType(typeof(List<>), cst.Arguments)}()", newLine: false))
                    {
                        var idx = 0;
                        foreach (var element in exampleValue.Elements)
                        {
                            WriteExampleValue(writer, cst.Arguments[0], element, $"{variableName}[{idx}]");
                            writer.Append($",");
                            idx++;
                        }
                    }
                    break;
                case "System.Collections.Generic.IDictionary":
                    using (writer.Scope($"new {new CSharpType(typeof(Dictionary<,>), cst.Arguments)}()", newLine: false))
                    {
                        foreach (var entry in exampleValue.Properties)
                        {
                            var keyDelegate = WriteStringValue(cst.Arguments[0], entry.Key);
                            writer.Append($"[{keyDelegate}] = ");
                            WriteExampleValue(writer, cst.Arguments[1], entry.Value, $"{variableName}[{keyDelegate}]");
                            writer.Append($",");
                        }
                    }
                    break;
                case "System.Object":
                    WriteJsonRawValue(writer, new JsonRawValue(exampleValue.RawValue));
                    break;
                case "Azure.ResourceManager.Models.UserAssignedIdentity":
                    WriteExampleValue(writer, new CSharpType(new SystemObjectType(typeof(Azure.ResourceManager.Models.UserAssignedIdentity), MgmtContext.Context)), exampleValue, variableName);
                    break;
                case "Azure.ResourceManager.Models.SystemAssignedServiceIdentity":
                    WriteExampleValue(writer, new CSharpType(new SystemObjectType(typeof(Azure.ResourceManager.Models.SystemAssignedServiceIdentity), MgmtContext.Context)), exampleValue, variableName);
                    break;
                default:
                    var rawValue = new JsonRawValue(exampleValue.RawValue);
                    if (rawValue.IsString() && WriteStringValue(writer, cst, rawValue.AsString()))
                    {
                        return;
                    }
                    if (exampleValue.RawValue is null)
                    {
                        writer.Append($"null");
                        return;
                    }
                    try
                    {
                        writer.Append($"{exampleValue.RawValue}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    break;
            }
        }

        public bool WriteStringValue(CodeWriter writer, CSharpType cst, string value)
        {
            switch ($"{cst.Namespace}.{cst.Name}")
            {
                case "Azure.Core.ResourceIdentifier":
                case "Azure.Core.ResourceType":
                    writer.Append($"new {cst}({FormatResourceId(value).RefScenarioDefinedVariables(_scenarioVariables)})");
                    return true;
                case "System.DateTimeOffset":
                    writer.Append($"{typeof(DateTimeOffset)}.Parse({value.RefScenarioDefinedVariables(_scenarioVariables)})");
                    return true;
                case "System.Guid":
                    writer.Append($"{typeof(Guid)}.Parse({value.RefScenarioDefinedVariables(_scenarioVariables)})");
                    return true;
                case "System.TimeSpan":
                    writer.Append($"{typeof(TimeSpan)}.Parse({value.RefScenarioDefinedVariables(_scenarioVariables)})");
                    return true;
                case "System.Uri":
                    writer.Append($"new {typeof(Uri)}({value.RefScenarioDefinedVariables(_scenarioVariables)})");
                    return true;
                case "Azure.ResourceManager.Models.ManagedServiceIdentityType":
                    writer.Append($"new {typeof(Azure.ResourceManager.Models.ManagedServiceIdentityType)}({value.RefScenarioDefinedVariables(_scenarioVariables)})");
                    return true;
                case "Azure.Core.AzureLocation":
                    writer.Append($"new {typeof(Azure.Core.AzureLocation)}({value.RefScenarioDefinedVariables(_scenarioVariables)})");
                    return true;
                case "System.String":
                    writer.Append($"{value.RefScenarioDefinedVariables(_scenarioVariables)}");
                    return true;
            }
            return false;
        }

        public CodeWriterDelegate WriteStringValue(CSharpType cst, string value)
        {
            return writer =>
            {
                if (!WriteStringValue(writer, cst, value))
                {
                    writer.Append($"null");
                }
            };
        }

        public void WriteEnumTypeExampleValue(CodeWriter writer, EnumType enumType, ExampleValue exampleValue)
        {
            if (enumType.IsExtendable)
            {
                if (enumType.BaseType.FrameworkType == typeof(String) && exampleValue.RawValue is string strValue)
                {
                    writer.AppendEnumFromString(enumType, w => w.Append($"{strValue.RefScenarioDefinedVariables(_scenarioVariables)}"));
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
                case null:
                    WriteFrameworkTypeExampleValue(writer, cst, exampleValue, variableName);
                    break;
                default:
                    throw new Exception($"TODO: handle example value for {cst}!");
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

        public FormattableString ComposeResourceIdentifierParams(RequestPath requestPath, ExampleModel exampleModel)
        {
            var identifierParams = string.Join(", ", requestPath.Where(segment => segment.IsReference).Select(segment =>
            {
                var value = "\"default\"";
                foreach (var parameterValue in exampleModel.AllParameter)
                {
                    if (parameterValue.Parameter.CSharpName() == segment.ReferenceName)
                    {
                        value = $"\"{parameterValue.ExampleValue.RawValue}\"";
                    }
                }

                if (segment.ReferenceName == "subscriptionId" && !InScenario)
                {
                    Regex regex = new Regex("^{[A-Z0-9]{8}-([A-Z0-9]{4}-){3}[A-Z0-9]{12}}$");
                    Match match = regex.Match(value);
                    if (!match.Success)
                    {
                        value = "\"00000000-0000-0000-0000-000000000000\"";
                    }
                }
                return value.RefScenarioDefinedVariables(_scenarioVariables);
            }));
            return $"{identifierParams}";
        }

        public static string? FindParameterValueByName(ExampleModel exampleModel, string parameterName)
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
            return writer =>
            {
                writer.Append($"{methodName}(");
                foreach (var paramName in paramNames)
                {
                    writer.Append($"{paramName},");
                }
                writer.RemoveTrailingComma();
                writer.Append($")");
            };
        }

        protected void WriteMethodTestInvocation(bool async, MgmtClientOperation clientOperation, bool isLroOperation, FormattableString methodName, IEnumerable<FormattableString> paramNames)
        {
            _writer.Append($"{GetAwait(async)}");
            if (isLroOperation || clientOperation.IsLongRunningOperation && !clientOperation.IsPagingOperation)
            {
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

        public static string GetExampleValueFromRequestPath(RequestPath requestPath, ExampleModel exampleModel, string type)
        {
            int i = 0;
            string? exampleValue = null;
            foreach (var segment in requestPath)
            {
                if (segment.IsConstant && segment.ConstantValue.ToLower() == type)
                {
                    exampleValue = FindParameterValueByName(exampleModel, requestPath.ElementAt(i + 1).ReferenceName);
                    break;
                }
                i++;
            }
            return exampleValue ?? "00000000-0000-0000-0000-000000000000";
        }

        protected static CodeWriterDelegate WriteGetExtension(MgmtExtensions extensions, RequestPath requestPath, ExampleModel exampleModel, IEnumerable<string>? scenarioVariables)
        {
            return writer =>
            {
                if (extensions == MgmtContext.Library.TenantExtensions)
                {
                    writer.UseNamespace("System.Linq");
                    writer.Append($"GetArmClient().GetTenants().First()");
                }
                else if (extensions == MgmtContext.Library.ResourceGroupExtensions)
                {
                    writer.Append($"GetArmClient().Get{extensions.ArmCoreType.Name}({typeof(ResourceGroupResource)}.CreateResourceIdentifier({GetExampleValueFromRequestPath(requestPath, exampleModel, "subscriptions").RefScenarioDefinedVariables(scenarioVariables)}, {GetExampleValueFromRequestPath(requestPath, exampleModel, "resourcegroups").RefScenarioDefinedVariables(scenarioVariables)}))");
                }
                else if (extensions == MgmtContext.Library.SubscriptionExtensions)
                {
                    writer.Append($"GetArmClient().Get{extensions.ArmCoreType.Name}({typeof(SubscriptionResource)}.CreateResourceIdentifier({GetExampleValueFromRequestPath(requestPath, exampleModel, "subscriptions").RefScenarioDefinedVariables(scenarioVariables)}))");
                }
                else
                {
                    throw new Exception($"Unknown parent extension {extensions}");
                }
            };
        }
    }
}
