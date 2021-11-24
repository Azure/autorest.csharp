// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Collections.Generic;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using System.Text.Json;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Mgmt.Models;


namespace AutoRest.CSharp.MgmtTest.Generation
{
    internal partial class MgmtBaseTestWriter: MgmtClientBaseWriter
    {
        public static CodeWriter _tagsWriter = new CodeWriter();
        public HashSet<string>  variableNames = new HashSet<string>();

        public MgmtBaseTestWriter(CodeWriter writer, MgmtTypeProvider provider, BuildContext<MgmtOutputLibrary> context) : base(writer, provider, context)
        {
        }

        public void WriteTestDecorator()
        {
            _writer.Line($"[RecordedTest]");

            var testsConfiguration = Context.Configuration.MgmtConfiguration.TestModeler;
            System.Text.Json.JsonElement ignoreReason = default;
            if (testsConfiguration is not null && testsConfiguration.IsObject() && testsConfiguration?.TryGetProperty("ignore-reason", out ignoreReason) == true)
            {
                _writer.UseNamespace("NUnit.Framework");
                _writer.Line($"[Ignore(\"{ignoreReason.GetString()}\")]");
            }
        }

        public static object ConvertToStringDictionary(object dict)
        {
            Type t = dict.GetType();
            bool isDict = t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>);
            if (!isDict)
            {
                return dict;
            }
            var ret = new Dictionary<string, object>();
            foreach (KeyValuePair<object, object> entry in (IEnumerable< KeyValuePair<object, object>>)dict)
            {
                ret.Add(entry.Key.ToString()!, ConvertToStringDictionary(entry.Value));
            }
            return ret;
        }

        public static string FormatResourceId(string resourceId)
        {
            resourceId = resourceId.Replace("{", "{{").Replace("}", "}}");
            var elements = resourceId.Split("/");
            for (int i = 2; i< elements.Length; i+=2)
            {
                if (elements[i-1].ToLower()== "subscriptions")
                {
                    elements[i] = "00000000-0000-0000-0000-000000000000";
                }
            }
            return String.Join("/", elements);
        }

        public static string GetTaskOrVoid(bool isAsync)
        {
            return isAsync ? "Task" : "void";
        }

        public static ExampleGroup? FindExampleGroup(BuildContext<MgmtOutputLibrary> context, MgmtRestOperation restOperation)
        {
            if (restOperation is null)
                return null;
            foreach (var exampleGroup in context.CodeModel.TestModel?.MockTest.ExampleGroups ?? Enumerable.Empty<ExampleGroup>())
            {
                if (exampleGroup.Examples.Count > 0 && exampleGroup.Examples.First().Operation == restOperation.Operation)
                {
                    return exampleGroup;
                }
            }
            return null;
        }

        public static bool HasExample(BuildContext<MgmtOutputLibrary> context, MgmtClientOperation? clientOperation)
        {
            if (clientOperation is null)
            {
                return false;
            }

            var operationMappings = clientOperation.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
            foreach ((var branch, var operation) in operationMappings)
            {
                var exampleGroup = MgmtBaseTestWriter.FindExampleGroup(context, operation);
                if (exampleGroup is not null && exampleGroup.Examples.Count > 0)
                    return true;
            }
            return false;
        }

        public static bool HasCreateExample(BuildContext<MgmtOutputLibrary> context, ResourceCollection? resourceCollection)
        {
            if (resourceCollection is null)
                return false;
            return HasExample(context, resourceCollection.CreateOperation);
        }

        public static bool HasGetExample(BuildContext<MgmtOutputLibrary> context, ResourceCollection? resourceCollection)
        {
            if (resourceCollection is null)
                return false;
            return HasExample(context, resourceCollection.GetOperation);
        }

        public static bool CanCreateResourceFromExample(BuildContext<MgmtOutputLibrary> context, ResourceCollection? resourceCollection)
        {
            var hasCreateExample = HasCreateExample(context, resourceCollection);
            if (!hasCreateExample)
            {
                return false;
            }

            var parentResources = resourceCollection!.Resource.Parent(context);
            if (parentResources.Contains(context.Library.ResourceGroupExtensions) ||
                parentResources.Contains(context.Library.SubscriptionExtensions) ||
                parentResources.Contains(context.Library.TenantExtensions))
            {
                return true;
            }
            foreach (var parentResource in parentResources)
            {
                if (parentResource is not null && parentResource is Resource)
                {
                    if (CanCreateResourceFromExample(context, ((Resource)parentResource).ResourceCollection))
                        return true;
                }
            }
            return false;
        }

        public static bool CanCreateParentResourceFromExample(BuildContext<MgmtOutputLibrary> context, ResourceCollection? resourceCollection)
        {
            if (resourceCollection is null)
                return false;
            var parentResources = resourceCollection!.Resource.Parent(context);
            if (parentResources.Contains(context.Library.ResourceGroupExtensions) ||
                parentResources.Contains(context.Library.SubscriptionExtensions) ||
                parentResources.Contains(context.Library.TenantExtensions))
            {
                return true;
            }

            foreach (var parentResource in parentResources)
            {
                if (parentResource is not null && parentResource is Resource)
                {
                    if (CanCreateResourceFromExample(context, ((Resource)parentResource).ResourceCollection))
                        return true;
                }
            }

            return false;
        }

        public static ObjectTypeProperty? FindPropertyThroughSerialization(List<string> flattenedNames, JsonObjectSerialization obj)
        {
            if (flattenedNames.Count == 0)
            {
                return null;
            }
            foreach (JsonPropertySerialization property in obj.Properties)
            {
                if (flattenedNames[0] == property.Name)
                {
                    if (flattenedNames.Count == 1)
                        return property.Property;
                    return FindPropertyThroughSerialization(flattenedNames.Skip(1).ToList(), (JsonObjectSerialization)property.ValueSerialization);
                }
            }
            return null;
        }

        public static ExampleValue? FindPropertyValue(ObjectType ot, ExampleValue ev, ObjectTypeProperty targetProperty)
        {
            if (ot is SchemaObjectType)
            {
                var sot = (SchemaObjectType)ot;
                var obj = (JsonObjectSerialization)sot.Serializations.Single(x => typeof(JsonSerialization).IsInstanceOfType(x));
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

        public void WriteSchemaObjectExampleValue(CodeWriter writer, ObjectType sot, ExampleValue ev, string variableName)
        {
            // Find Polimophismed schema
            if (sot is SchemaObjectType && Context.Library.SchemaMap.ContainsKey(ev.Schema))
            {
                var mappedTypeProvider = Context.Library.SchemaMap[ev.Schema];
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

            writer.Append($"new {sot.Type}(");
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
                    // initiate for special parameter, others provide default
                    if (p.Name == "location")
                    {
                        writer.Append($"\"westus\"");
                    }
                    else
                    {
                        writer.Append($"default /* don't find example value for this parameter!*/,");
                    }
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
                                    MgmtBaseTestWriter._tagsWriter.Append($"{newVariableName}.ReplaceWith(");
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

        public void WriteFrameworkTypeExampleValue(CodeWriter writer, CSharpType cst, ExampleValue exampleValue, string variableName)
        {
            if (cst.Name == "IList" || cst.Name == "IEnumerable")
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
                writer.Append($"JsonSerializer.Deserialize<object>({JsonSerializer.Serialize(MgmtBaseTestWriter.ConvertToStringDictionary(exampleValue.RawValue!)):L})");
            }
            else if (cst.Name == "ResourceIdentifier")
            {
                writer.Append($"new {cst}(${MgmtBaseTestWriter.FormatResourceId(exampleValue.RawValue!.ToString()!):L})");
            }
            else if (cst.Name == "DateTimeOffset")
            {
                writer.Append($"{typeof(DateTimeOffset)}.Parse({exampleValue.RawValue:L})");
            }
            else if (cst.Name == "Guid")
            {
                writer.Append($"System.Guid.Parse({exampleValue.RawValue:L})");
            }
            else if (exampleValue.RawValue is not null)
            {
                if (new string[] { "String", "Location" }.Contains(cst.FrameworkType.Name))
                {
                    writer.Append($"{exampleValue.RawValue:L}");
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

        public static void WriteEnumTypeExampleValue(CodeWriter writer, EnumType enumType, ExampleValue exampleValue)
        {
            if (enumType.IsExtendable)
            {
                if (new string[] { "String" }.Contains(enumType.BaseType.FrameworkType.Name))
                {
                    writer.AppendEnumFromString(enumType, w => w.Append($"{exampleValue.RawValue:L}"));
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
                        writer.Append($"{enumType.Declaration.Name}.{value.Declaration.Name}");
                        return;
                    }
                }
                throw new Exception($"Can't resolve {exampleValue.RawValue:L} as {enumType.Declaration.Name} value!");
            }
        }

        public void WriteExampleValue(CodeWriter writer, CSharpType cst, ExampleValue exampleValue, string variableName)
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

        public string useVariableName(string variableName)
        {
            if (!variableNames.Contains(variableName))
            {
                variableNames.Add(variableName);
                return variableName;
            }

            for (int i = 2; true; i++)
            {
                var newName = $"{variableName}{i}";
                if (!variableNames.Contains(newName))
                {
                    variableNames.Add(newName);
                    return newName;
                }
            }
            throw new Exception($"Can't find a valid variable name start with {variableName}");
        }

        public void clearVariableNames() {
            variableNames = new HashSet<string>();
        }

        public string WriteExampleParameterDeclaration(CodeWriter writer, ExampleParameter exampleParameter, Parameter parameter)
        {
            var variableName = useVariableName(exampleParameter.Parameter.CSharpName());
            writer.Append($"var {variableName} = ");
            WriteExampleValue(writer, parameter.Type, exampleParameter.ExampleValue, variableName);
            writer.Line($";");

            foreach (var tagLine in _tagsWriter.ToString(false).Split(Environment.NewLine))
            {
                writer.AppendRaw(tagLine);
            }
            _tagsWriter = new CodeWriter();
            return variableName;
        }

        public static string BuildValueString(ExampleValue exampleValue, Schema schema)
        {
            return $"\"{exampleValue.RawValue}\"";
        }

        public override void Write()
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingletonResourceEntry(Resource resource, string singletonResourceIdSuffix)
        {
            throw new NotImplementedException();
        }

        protected override void WriteResourceCollectionEntry(Resource resource)
        {
            throw new NotImplementedException();
        }

        protected override ResourceType GetBranchResourceType(RequestPath branch)
        {
            throw new NotImplementedException();
        }
    }
}
