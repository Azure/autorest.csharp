// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.MgmtTest.Extensions
{
    internal static class CodeWriterExtensions
    {
        public static CodeWriter AppendExampleValue(this CodeWriter writer, ExampleValue exampleValue)
        {
            // get the type of this schema in the type factory
            var type = MgmtContext.Context.TypeFactory.CreateType(exampleValue.Schema, false);

            return type.IsFrameworkType ?
                writer.AppendFrameworkTypeValue(type, exampleValue) :
                writer.AppendTypeProviderValue(type, exampleValue);
        }

        public static CodeWriter AppendExampleParameterValue(this CodeWriter writer, Parameter parameter, ExampleParameterValue exampleValue)
        {
            // for optional parameter, we write the parameter name here
            if (parameter.DefaultValue != null)
                writer.Append($"{parameter.Name}: ");
            if (exampleValue.Value != null)
                writer.AppendExampleValue(exampleValue.Value);
            else if (exampleValue.RawValue != null)
                writer.Append(exampleValue.RawValue);
            else
                throw new InvalidOperationException($"No value for parameter {exampleValue.Parameter.Name} assigned");
            return writer;
        }

        private static CodeWriter AppendFrameworkTypeValue(this CodeWriter writer, CSharpType type, ExampleValue exampleValue)
        {
            if (TypeFactory.IsList(type))
                return writer.AppendListValue(type, exampleValue);

            if (TypeFactory.IsDictionary(type))
                return writer.AppendDictionaryValue(type, exampleValue);

            return writer.AppendSimpleFrameworkType(type.FrameworkType, exampleValue);
        }

        private static CodeWriter AppendListValue(this CodeWriter writer, CSharpType type, ExampleValue exampleValue)
        {
            // since this is a list, we take the first generic argument (and it should always has this first argument)
            var elementType = type.Arguments.First();
            using (writer.Scope($"new[] "))
            {
                foreach (var itemValue in exampleValue.Elements)
                {
                    writer.AppendExampleValue(itemValue);
                    writer.AppendRaw(",");
                }
                writer.RemoveTrailingComma();
            }
            return writer;
        }

        private static CodeWriter AppendDictionaryValue(this CodeWriter writer, CSharpType type, ExampleValue exampleValue)
        {
            // since this is a dictionary, we take the first generic argument as the key type which is always string
            // the second as the value type
            var valueType = type.Arguments[1];
            using (writer.Scope($"new {type}()"))
            {
                foreach ((var key, var value) in (Dictionary<string, ExampleValue>)exampleValue.Properties)
                {
                    // write key
                    writer.Append($"[{key}] = ");
                    writer.AppendExampleValue(value);
                    writer.AppendRaw(",");
                }
                writer.RemoveTrailingComma();
            }
            return writer;
        }

        private static CodeWriter AppendSimpleFrameworkType(this CodeWriter writer, Type type, ExampleValue exampleValue)
        {
            switch (exampleValue.RawValue)
            {
                case string str:
                    return writer.Append($"\"{str}\"");
                case null:
                    throw new InvalidOperationException($"Example value is null for framework type {type}");
                default:
                    return writer.Append($"{exampleValue.RawValue}");
            }
        }

        private static CodeWriter AppendTypeProviderValue(this CodeWriter writer, CSharpType type, ExampleValue exampleValue)
        {
            return writer.AppendRaw("default");
        }

        //public static void WriteFrameworkTypeExampleValue(CodeWriter writer, CSharpType cst, ExampleValue exampleValue, FormattableString variableName)
        //{
        //    switch ($"{cst.Namespace}.{cst.Name}")
        //    {
        //        case "System.Collections.Generic.IList":
        //            using (writer.Scope($"new {new CSharpType(typeof(List<>), cst.Arguments)}()", newLine: false))
        //            {
        //                var idx = 0;
        //                foreach (var element in exampleValue.Elements)
        //                {
        //                    WriteExampleValue(writer, cst.Arguments[0], element, $"{variableName}[{idx}]");
        //                    writer.Append($",");
        //                    idx++;
        //                }
        //            }
        //            break;
        //        case "System.Collections.Generic.IDictionary":
        //            using (writer.Scope($"new {new CSharpType(typeof(Dictionary<,>), cst.Arguments)}()", newLine: false))
        //            {
        //                foreach (var entry in exampleValue.Properties)
        //                {
        //                    var keyDelegate = WriteStringValue(cst.Arguments[0], entry.Key);
        //                    writer.Append($"[{keyDelegate}] = ");
        //                    WriteExampleValue(writer, cst.Arguments[1], entry.Value, $"{variableName}[{keyDelegate}]");
        //                    writer.Append($",");
        //                }
        //            }
        //            break;
        //        case "System.Object":
        //            WriteJsonRawValue(writer, new JsonRawValue(exampleValue.RawValue));
        //            break;
        //        case "Azure.ResourceManager.Models.UserAssignedIdentity":
        //            WriteExampleValue(writer, new CSharpType(new SystemObjectType(typeof(Azure.ResourceManager.Models.UserAssignedIdentity), MgmtContext.Context)), exampleValue, variableName);
        //            break;
        //        case "Azure.ResourceManager.Models.SystemAssignedServiceIdentity":
        //            WriteExampleValue(writer, new CSharpType(new SystemObjectType(typeof(Azure.ResourceManager.Models.SystemAssignedServiceIdentity), MgmtContext.Context)), exampleValue, variableName);
        //            break;
        //        case "System.BinaryData":
        //            using (writer.Scope($"{typeof(BinaryData)}.FromObjectAsJson", start: "(", end: ")", newLine: false))
        //            {
        //                WriteJsonRawValue(writer, new JsonRawValue(exampleValue.RawValue));
        //            }
        //            break;
        //        default:
        //            var rawValue = new JsonRawValue(exampleValue.RawValue);
        //            if (rawValue.IsString() && WriteStringValue(writer, cst, rawValue.AsString()))
        //            {
        //                return;
        //            }
        //            if (exampleValue.RawValue is null)
        //            {
        //                writer.Append($"null");
        //                return;
        //            }
        //            try
        //            {
        //                writer.Append($"{exampleValue.RawValue}");
        //            }
        //            catch (Exception e)
        //            {
        //                Console.WriteLine(e);
        //            }
        //            break;
        //    }
        //}

        //public static void WriteExampleValue(this CodeWriter writer, CSharpType cst, ExampleValue exampleValue, FormattableString variableName)
        //{
        //    TypeProvider? tp = cst.IsFrameworkType ? null : cst.Implementation;
        //    switch (tp)
        //    {
        //        case SchemaObjectType sot:
        //            WriteSchemaObjectExampleValue(writer, sot, exampleValue, variableName);
        //            break;
        //        case SystemObjectType sot:
        //            WriteSchemaObjectExampleValue(writer, sot, exampleValue, variableName);
        //            break;
        //        case EnumType enumType:
        //            WriteEnumTypeExampleValue(writer, enumType, exampleValue);
        //            break;
        //        case null:
        //            WriteFrameworkTypeExampleValue(writer, cst, exampleValue, variableName);
        //            break;
        //        default:
        //            throw new Exception($"TODO: handle example value for {cst}!");
        //    }
        //}

        //public static void WriteSchemaObjectExampleValue(CodeWriter writer, ObjectType sot, ExampleValue ev, FormattableString variableName)
        //{
        //    // Find Polimophismed schema
        //    if (sot is SchemaObjectType && MgmtContext.Library.SchemaMap.ContainsKey(ev.Schema))
        //    {
        //        var mappedTypeProvider = MgmtContext.Library.SchemaMap[ev.Schema];
        //        if (mappedTypeProvider is SchemaObjectType mappedSot)
        //        {
        //            if (mappedSot != sot)
        //            {
        //                sot = mappedSot;
        //                variableName = $"(({mappedSot.Type}){variableName})";
        //            }
        //        }
        //    }

        //    var constructor = FindSuitableConstructor(sot, ev);
        //    HashSet<ObjectTypeProperty> consumedProperties = new HashSet<ObjectTypeProperty>();
        //    var signature = constructor.Signature;

        //    writer.Append($"new {sot.Type}(");
        //    foreach (var p in signature.Parameters)
        //    {
        //        var targetProperty = constructor.FindPropertyInitializedByParameter(p);
        //        if (targetProperty is null)
        //        {
        //            writer.Append($"default, /* Can't find property for this parameter!*/");
        //            continue;
        //        }
        //        var paramValue = FindPropertyValue(sot, ev, targetProperty);
        //        writer.Append($"{p.Name:D}: ");
        //        if (paramValue is not null)
        //        {
        //            WriteExampleValue(writer, p.Type, paramValue, $"{PropertyVaraibleName(variableName, targetProperty, paramValue)}");
        //        }
        //        else
        //        {
        //            // initiate for special parameter, others provide default
        //            if (p.Name == "location")
        //            {
        //                writer.Append($"{typeof(AzureLocation)}.WestUS");
        //            }
        //            else
        //            {
        //                writer.Append($"default /* don't find example value for this parameter!*/");
        //            }
        //        }
        //        writer.AppendRaw(",");
        //        consumedProperties.Add(targetProperty!);
        //    }
        //    writer.RemoveTrailingComma();
        //    writer.Append($")");

        //    var hasUnconsumedProperties = false;
        //    foreach (var objectType in sot.EnumerateHierarchy())
        //    {
        //        foreach (var targetProperty in objectType.Properties)
        //        {
        //            if (consumedProperties.Contains(targetProperty) || targetProperty.IsReadOnly)
        //                continue;
        //            var paramValue = FindPropertyValue(sot, ev, targetProperty!);
        //            if (paramValue is not null)
        //            {
        //                hasUnconsumedProperties = true;
        //                break;
        //            }
        //        }
        //    }

        //    if (hasUnconsumedProperties)
        //        WriteSchemaObjectExampleProperties(writer, sot, ev, variableName, consumedProperties);

        //    // assign readonly list and dictionary properties.
        //    foreach (var objectType in sot.EnumerateHierarchy())
        //    {
        //        foreach (var targetProperty in objectType.Properties)
        //        {
        //            if (consumedProperties.Contains(targetProperty))
        //                continue;
        //            var paramValue = FindPropertyValue(sot, ev, targetProperty!);
        //            if (paramValue is not null)
        //            {
        //                assignmentWriterDelegates.Enqueue(CreateAssignmentWriterDelegate(targetProperty.ValueType, paramValue, $"{PropertyVaraibleName(variableName, targetProperty, paramValue)}"));
        //            }
        //        }
        //    }
        //}

        //public static void WriteEnumTypeExampleValue(CodeWriter writer, EnumType enumType, ExampleValue exampleValue)
        //{
        //    if (enumType.IsExtendable)
        //    {
        //        if (enumType.BaseType.FrameworkType == typeof(String) && exampleValue.RawValue is string strValue)
        //        {
        //            writer.AppendEnumFromString(enumType, w => w.Append($"{strValue:L}"));
        //        }
        //        else
        //        {
        //            writer.AppendEnumFromString(enumType, w => w.Append($"{exampleValue.RawValue}"));
        //        }
        //    }
        //    else
        //    {
        //        foreach (EnumTypeValue value in enumType.Values)
        //        {
        //            if ((bool)enumType.BaseType.FrameworkType.GetMethod("Equals", new[] { enumType.BaseType.FrameworkType, enumType.BaseType.FrameworkType })!.Invoke(null, new object?[] { exampleValue.RawValue, value.Value.Value })!)
        //            {
        //                writer.Append($"{enumType.Declaration.Namespace}.{enumType.Declaration.Name}.{value.Declaration.Name}");
        //                return;
        //            }
        //        }
        //        throw new Exception($"Can't resolve {exampleValue.RawValue:L} as {enumType.Declaration.Name} value!");
        //    }
        //}
    }
}
