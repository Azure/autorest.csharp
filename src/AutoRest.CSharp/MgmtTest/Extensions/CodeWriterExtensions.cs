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
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.MgmtTest.Extensions
{
    internal static class CodeWriterExtensions
    {
        public static CodeWriter AppendExampleValue(this CodeWriter writer, ExampleValue exampleValue, bool includeCollectionInitialization = true)
        {
            // get the type of this schema in the type factory
            var type = MgmtContext.Context.TypeFactory.CreateType(exampleValue.Schema, false);

            return type.IsFrameworkType ?
                writer.AppendFrameworkTypeValue(type, exampleValue, includeCollectionInitialization) :
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

        private static CodeWriter AppendFrameworkTypeValue(this CodeWriter writer, CSharpType type, ExampleValue exampleValue, bool includeCollectionInitialization = true)
        {
            if (TypeFactory.IsList(type))
                return writer.AppendListValue(type, exampleValue, includeCollectionInitialization);

            if (TypeFactory.IsDictionary(type))
                return writer.AppendDictionaryValue(type, exampleValue, includeCollectionInitialization);

            return writer.AppendSimpleFrameworkType(type.FrameworkType, exampleValue);
        }

        private static CodeWriter AppendListValue(this CodeWriter writer, CSharpType type, ExampleValue exampleValue, bool includeInitialization = true)
        {
            // since this is a list, we take the first generic argument (and it should always has this first argument)
            var elementType = type.Arguments.First();
            var initialization = includeInitialization ? (FormattableString)$"new {elementType}[]" : (FormattableString)$"";
            using (writer.Scope(initialization, newLine: false))
            {
                foreach (var itemValue in exampleValue.Elements)
                {
                    // TODO -- bad formatting will happen in collection initializer because roslyn formatter ignores things in these places: https://github.com/dotnet/roslyn/issues/8269
                    writer.AppendExampleValue(itemValue);
                    if (type.IsFrameworkType)
                        writer.AppendRaw(",");
                    else
                        writer.LineRaw(",");
                }
                writer.RemoveTrailingComma();
                writer.Line();
            }
            return writer;
        }

        private static FormattableString WrapStringLiteral(string value) => $"\"{value}\"";

        private static CodeWriter AppendDictionaryValue(this CodeWriter writer, CSharpType type, ExampleValue exampleValue, bool includeInitialization = true)
        {
            // since this is a dictionary, we take the first generic argument as the key type which is always string
            // the second as the value type
            var valueType = type.Arguments[1];
            var initialization = includeInitialization ? (FormattableString)$"new {type}()" : (FormattableString)$"";
            using (writer.Scope(initialization, newLine: false))
            {
                foreach ((var key, var value) in (Dictionary<string, ExampleValue>)exampleValue.Properties)
                {
                    // write key
                    writer.Append($"[{WrapStringLiteral(key)}] = ");
                    writer.AppendExampleValue(value);
                    writer.LineRaw(", ");
                }
            }
            return writer;
        }

        private static CodeWriter AppendSimpleFrameworkType(this CodeWriter writer, Type type, ExampleValue exampleValue)
            => exampleValue.RawValue switch
            {
                string str => writer.AppendStringValue(type, str), // we need this function to convert the string to real type. There might be a bug that some literal types (like bool and int) are deserialized to string
                bool b => writer.Append($"{b}"),
                int i => writer.Append($"{i}"),
                long l => writer.Append($"{l}"),
                double d => writer.Append($"{d}"),
                decimal dec => writer.Append($"{dec}"),
                null => throw new InvalidOperationException($"Example value is null for framework type {type}"),
                _ => writer.AppendRaw(exampleValue.RawValue.ToString()!)
            };

        private static CodeWriter AppendStringValue(this CodeWriter writer, Type type, string value)
        {
            if (type == typeof(string))
                return writer.Append(WrapStringLiteral(value));
            if (IsStringLikeType(type))
                return writer.Append($"new {type}({WrapStringLiteral(value)})");
            return writer.AppendRaw(value);
        }

        private static bool IsStringLikeType(CSharpType type) => type.IsFrameworkType && IsStringLikeType(type.FrameworkType);

        private static bool IsStringLikeType(Type type)
            => type == typeof(Guid) || type == typeof(Guid?) || type == typeof(AzureLocation) || type == typeof(AzureLocation?)
            || type == typeof(ResourceType) || type == typeof(ResourceType?) || type == typeof(ResourceIdentifier);

        private static CodeWriter AppendTypeProviderValue(this CodeWriter writer, CSharpType type, ExampleValue exampleValue)
        {
            switch (type.Implementation)
            {
                case SchemaObjectType schemaObjectType:
                    return writer.AppendSchemaObjectTypeValue(schemaObjectType, (Dictionary<string, ExampleValue>)exampleValue.Properties);
                case EnumType enumType:
                    return writer.AppendEnumTypeValue(enumType, (string)exampleValue.RawValue!);
            }
            return writer.AppendRaw("default");
        }

        private static CodeWriter AppendSchemaObjectTypeValue(this CodeWriter writer, SchemaObjectType schemaObjectType, Dictionary<string, ExampleValue> valueDict)
        {
            // get all the properties on this type, including the properties from its base type
            var properties = new HashSet<ObjectTypeProperty>(schemaObjectType.EnumerateHierarchy().SelectMany(objectType => objectType.Properties));
            var constructor = schemaObjectType.InitializationConstructor;
            writer.UseNamespace(schemaObjectType.Type.Namespace);
            writer.Append($"new {schemaObjectType.Type.Name}(");
            // build a map from parameter name to property
            var propertyDict = properties.ToDictionary(
                property => property.Declaration.Name.ToVariableName(), property => property);
            // find the corresponding properties in the parameters
            foreach (var parameter in constructor.Signature.Parameters)
            {
                // try every property, convert them to variable name and see if there are some of them matching
                var property = propertyDict[parameter.Name];
                ExampleValue? exampleValue;
                if (!valueDict.TryGetValue(property.SchemaProperty!.SerializedName, out exampleValue))
                {
                    // we could only stand the case that the missing property here is a collection, in this case, we pass an empty collection
                    if (TypeFactory.IsCollectionType(property.ValueType))
                    {
                        exampleValue = new ExampleValue()
                        {
                            Schema = property.SchemaProperty.Schema,
                        };
                    }
                    else if (IsStringLikeType(property.ValueType))
                    {
                        // this is a patch that some parameter is not marked as required, but in our generated code, it inherits from ResourceData, in which location is in the constructor and our code will recognize it as required
                        exampleValue = new ExampleValue()
                        {
                            Schema = new StringSchema()
                            {
                                Type = AllSchemaTypes.String
                            },
                            RawValue = "placeholder",
                        };
                    }
                    else
                        throw new InvalidOperationException($"Example value for required property {property.SchemaProperty!.SerializedName} in class {schemaObjectType.Type.Name} is not found");
                }
                properties.Remove(property);
                writer.AppendExampleValue(exampleValue).AppendRaw(",");
            }
            writer.RemoveTrailingComma();
            writer.AppendRaw(")");
            var propertiesToWrite = new Dictionary<string, ExampleValue>();
            foreach (var property in properties)
            {
                var schemaProperty = property.SchemaProperty;
                if (schemaProperty == null)
                    continue; // now we explicitly ignore all the AdditionalProperties
                if (valueDict.TryGetValue(schemaProperty.SerializedName, out var exampleValue))
                {
                    propertiesToWrite.Add(property.Declaration.Name, exampleValue);
                }
            }
            if (propertiesToWrite.Count > 0) // only write the property initializers when there are properties to write
            {
                using (writer.Scope($"", newLine: false))
                {
                    foreach ((var propertyName, var exampleValue) in propertiesToWrite)
                    {
                        writer.Append($"{propertyName} = ");
                        writer.AppendExampleValue(exampleValue, false);
                        writer.LineRaw(",");
                    }
                }
            }
            return writer;
        }

        private static CodeWriter AppendEnumTypeValue(this CodeWriter writer, EnumType enumType, string value)
        {
            // find value in one of the choices
            var choice = enumType.Values.First(c => value.Equals(c.Value.Value));
            writer.UseNamespace(enumType.Type.Namespace);
            return writer.Append($"{enumType.Type.Name}.{choice.Declaration.Name}");
        }
    }
}
