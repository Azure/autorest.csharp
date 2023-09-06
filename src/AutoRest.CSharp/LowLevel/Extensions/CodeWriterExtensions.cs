// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Samples.Models;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.LowLevel.Generation.Extensions
{
    internal static class CodeWriterExtensions
    {
        public static CodeWriter AppendInputExampleValue(this CodeWriter writer, InputExampleValue exampleValue, CSharpType type, SerializationFormat serializationFormat, bool includeCollectionInitialization = true)
        {
            // handle list
            if (TypeFactory.IsList(type))
                return writer.AppendListValue(type.Arguments.Single(), exampleValue, serializationFormat, includeCollectionInitialization);
            // handle dictionary
            if (TypeFactory.IsDictionary(type))
                return writer.AppendDictionaryValue(type, exampleValue, serializationFormat, includeCollectionInitialization: includeCollectionInitialization);

            Type? frameworkType = type.SerializeAs != null ? type.SerializeAs : type.IsFrameworkType ? type.FrameworkType : null;
            if (frameworkType != null)
            {
                // handle framework type
                return writer.AppendFrameworkTypeValue(exampleValue, frameworkType, serializationFormat, includeCollectionInitialization);
            }

            // handle implementation
            return writer.AppendTypeProviderValue(type, exampleValue);
        }

        private static CodeWriter AppendFrameworkTypeValue(this CodeWriter writer, InputExampleValue exampleValue, Type frameworkType, SerializationFormat serializationFormat, bool includeCollectionInitialization = true)
        {
            // handle objects - we usually do not generate object types, but for some rare cases (such as union type) we generate object.
            if (frameworkType == typeof(object))
            {
                return writer.AppendAnonymousObject(exampleValue, includeCollectionInitialization);
            }

            // handle RequestContent
            if (frameworkType == typeof(RequestContent))
            {
                return writer.AppendRequestContent(exampleValue);
            }

            if (frameworkType == typeof(ETag) ||
                frameworkType == typeof(Uri) ||
                frameworkType == typeof(ResourceIdentifier) ||
                frameworkType == typeof(ResourceType) ||
                frameworkType == typeof(ContentType) ||
                frameworkType == typeof(RequestMethod) ||
                frameworkType == typeof(AzureLocation))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue != null)
                    return writer.Append($"new {frameworkType}({rawValue.RawValue.ToString():L})");
                else
                    return writer.AppendRaw("default");
            }

            if (frameworkType == typeof(IPAddress))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue != null)
                    return writer.Append($"{frameworkType}.Parse({rawValue.RawValue.ToString():L})");
                else
                    return writer.AppendRaw("default");
            }

            if (frameworkType == typeof(BinaryData))
            {
                return writer.AppendBinaryData(exampleValue);
            }

            if (frameworkType == typeof(TimeSpan))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue is not null)
                {
                    switch (serializationFormat)
                    {
                        case SerializationFormat.Duration_Seconds or SerializationFormat.Duration_Seconds_Float:
                            if (rawValue.RawValue is int or float or double)
                                return writer.Append($"{typeof(TimeSpan)}.FromSeconds({rawValue.RawValue:L})");
                            break;
                        case SerializationFormat.Duration_ISO8601:
                            if (rawValue.RawValue is string s)
                                return writer.Append($"{typeof(XmlConvert)}.ToTimeSpan({s:L})");
                            break;
                            //case SerializationFormat.Duration_Constant:
                            // TODO - what does this look like?
                    };
                }

                return writer.AppendRaw("default");
            }

            if (frameworkType == typeof(DateTimeOffset))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue is not null)
                {
                    switch (serializationFormat)
                    {
                        case SerializationFormat.DateTime_Unix:
                            if (rawValue.RawValue is int or long)
                                return writer.Append($"{typeof(DateTimeOffset)}.FromUnixTimeSeconds({rawValue.RawValue:L})");
                            break;
                        case SerializationFormat.DateTime_RFC1123 or SerializationFormat.DateTime_RFC3339 or SerializationFormat.DateTime_RFC7231 or SerializationFormat.DateTime_ISO8601:
                            if (rawValue.RawValue is string s)
                                return writer.Append($"{typeof(DateTimeOffset)}.Parse({s:L})");
                            break;
                    }
                }

                return writer.AppendRaw("default");
            }

            if (frameworkType == typeof(Guid))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue is string s)
                {
                    return writer.Append($"{typeof(Guid)}.Parse({s:L})");
                }

                return writer.AppendRaw("default");
            }

            if (frameworkType == typeof(char) ||
                frameworkType == typeof(short) ||
                frameworkType == typeof(int) ||
                frameworkType == typeof(long) ||
                frameworkType == typeof(float) ||
                frameworkType == typeof(double) ||
                frameworkType == typeof(decimal))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue is char or short or int or long or float or double or decimal)
                {
                    return writer.Append($"({frameworkType}){rawValue.RawValue:L}"); // roslyn will trim off the cast if it is unnecessary
                }

                return writer.AppendRaw("default");
            }

            if (frameworkType == typeof(string))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue is not null)
                {
                    return writer.Literal(rawValue.RawValue.ToString());
                }

                return writer.AppendRaw("default");
            }

            if (frameworkType == typeof(bool))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue is bool b)
                    return writer.Literal(b);

                return writer.AppendRaw("default");
            }

            if (frameworkType == typeof(byte[]))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue is not null)
                    return writer.Append($"{typeof(Encoding)}.UTF8.GetBytes({rawValue.RawValue.ToString():L})");

                return writer.AppendRaw("default");
            }

            return writer.AppendRaw("default");
        }

        public static CodeWriter AppendInputExampleParameterValue(this CodeWriter writer, Parameter parameter, InputExampleParameterValue exampleParameterValue)
        {
            // for optional parameter, we write the parameter name here
            if (parameter.DefaultValue != null)
                writer.Append($"{parameter.Name}: ");

            return writer.AppendInputExampleParameterValue(exampleParameterValue, parameter.SerializationFormat);
        }

        public static CodeWriter AppendInputExampleParameterValue(this CodeWriter writer, InputExampleParameterValue exampleParameterValue, SerializationFormat serializationFormat)
        {
            if (exampleParameterValue.Value != null)
                return writer.AppendInputExampleValue(exampleParameterValue.Value, exampleParameterValue.Type, serializationFormat);
            else
                return writer.Append(exampleParameterValue.Expression!);
        }

        private static CodeWriter AppendRequestContent(this CodeWriter writer, InputExampleValue value)
        {
            if (value is InputExampleRawValue rawValue && rawValue.RawValue == null)
            {
                return writer.AppendRaw("null");
            }
            else
            {
                return writer.Append($"{typeof(RequestContent)}.Create(")
                    .AppendAnonymousObject(value, true)
                    .AppendRaw(")");
            }
        }

        private static CodeWriter AppendListValue(this CodeWriter writer, CSharpType elementType, InputExampleValue exampleValue, SerializationFormat serializationFormat, bool includeCollectionInitialization = true)
        {
            var exampleListValue = exampleValue as InputExampleListValue;
            // the collections in our generated SDK could never be assigned to, therefore if we have null value here, we can only assign an empty collection
            var elements = exampleListValue?.Values ?? Enumerable.Empty<InputExampleValue>();
            var initialization = includeCollectionInitialization ? (FormattableString)$"new {elementType}[]" : $"";
            using (writer.Scope(initialization, newLine: false))
            {
                foreach (var itemValue in elements)
                {
                    // TODO -- bad formatting will happen in collection initializer because roslyn formatter ignores things in these places: https://github.com/dotnet/roslyn/issues/8269
                    writer.AppendInputExampleValue(itemValue, elementType, serializationFormat);
                    if (elementType.IsFrameworkType)
                        writer.AppendRaw(",");
                    else
                        writer.LineRaw(",");
                }
                writer.RemoveTrailingComma();
                writer.Line();
            }
            return writer;
        }

        private static CodeWriter AppendDictionaryValue(this CodeWriter writer, CSharpType dictionaryType, InputExampleValue exampleValue, SerializationFormat serializationFormat, bool includeCollectionInitialization = true)
        {
            var exampleObjectValue = exampleValue as InputExampleObjectValue;
            // the collections in our generated SDK could never be assigned to, therefore if we have null value here, we can only assign an empty collection
            var keyValues = exampleObjectValue?.Values ?? new Dictionary<string, InputExampleValue>();
            // since this is a dictionary, we take the first generic argument as the key type
            // this is important because in our SDK, the key of a dictionary is not always a string. It could be a string-like type, for instance, a ResourceIdentifier
            var keyType = dictionaryType.Arguments[0];
            // the second as the value type
            var valueType = dictionaryType.Arguments[1];
            var initialization = includeCollectionInitialization ? (FormattableString)$"new {TypeFactory.GetImplementationType(dictionaryType)}()" : $"";
            writer.Append(initialization);
            if (keyValues.Any())
            {
                using (writer.Scope($"", newLine: false))
                {
                    foreach (var (key, value) in keyValues)
                    {
                        // write key
                        writer.AppendRaw("[");
                        writer.AppendInputExampleValue(InputExampleValue.Value(InputPrimitiveType.String, key), keyType, SerializationFormat.Default);
                        writer.AppendRaw("] = ");
                        writer.AppendInputExampleValue(value, valueType, serializationFormat, includeCollectionInitialization);
                        writer.LineRaw(", ");
                    }
                }
            }
            return writer;
        }

        private static CodeWriter AppendBinaryData(this CodeWriter writer, InputExampleValue exampleValue)
        {
            // determine which method on BinaryData we want to use to serialize this BinaryData
            string method = exampleValue is InputExampleRawValue exampleRawValue && exampleRawValue.RawValue is string ? "FromString" : "FromObjectAsJson";
            return writer.Append($"{typeof(BinaryData)}.{method}(")
                .AppendAnonymousObject(exampleValue, true)
                .AppendRaw(")");
        }

        private static CodeWriter AppendAnonymousObject(this CodeWriter writer, InputExampleValue exampleValue, bool includeCollectionInitialization = true) => exampleValue switch
        {
            InputExampleRawValue rawValue => rawValue.RawValue == null ?
                            writer.LineRaw("null") :
                            writer.AppendFrameworkTypeValue(exampleValue, rawValue.RawValue.GetType(), SerializationFormat.Default, includeCollectionInitialization),
            InputExampleListValue listValue => writer.AppendListValue(typeof(object), listValue, SerializationFormat.Default),
            InputExampleObjectValue objectValue => writer.AppendDictionaryValue(typeof(Dictionary<string, object>), objectValue, SerializationFormat.Default, includeCollectionInitialization),
            _ => throw new InvalidOperationException($"unhandled case {exampleValue}")
        };

        private static bool IsStringLikeType(CSharpType type) => type.IsFrameworkType && (_newInstanceInitializedTypes.Contains(type.FrameworkType) || _parsableInitializedTypes.Contains(type.FrameworkType));

        private static readonly HashSet<Type> _newInstanceInitializedTypes = new()
        {
            typeof(ResourceIdentifier),
            typeof(ResourceType),
            typeof(Uri),
            typeof(AzureLocation), typeof(AzureLocation?),
            typeof(RequestMethod), typeof(RequestMethod?),
            typeof(ContentType), typeof(ContentType?),
            typeof(ETag), typeof(ETag?)
        };

        private static readonly HashSet<Type> _parsableInitializedTypes = new()
        {
            typeof(DateTimeOffset),
            typeof(Guid), typeof(Guid?),
            typeof(TimeSpan), typeof(TimeSpan?),
            typeof(IPAddress)
        };

        private static CodeWriter AppendTypeProviderValue(this CodeWriter writer, CSharpType type, InputExampleValue exampleValue)
        {
            switch (type.Implementation)
            {
                case ObjectType objectType:
                    return writer.AppendObjectTypeValue(objectType, (exampleValue as InputExampleObjectValue)?.Values);
                case EnumType enumType when exampleValue is InputExampleRawValue rawValue:
                    return writer.AppendEnumTypeValue(enumType, rawValue.RawValue!);
            }
            return writer.AppendRaw("default");
        }

        private static ObjectType GetActualImplementation(ObjectType objectType, IReadOnlyDictionary<string, InputExampleValue> valueDict)
        {
            var discriminator = objectType.Discriminator;
            // check if this has a discriminator
            if (discriminator == null || !discriminator.HasDescendants)
                return objectType;
            var discriminatorPropertyName = discriminator.SerializedName;
            // get value of this in the valueDict and we should always has a discriminator value in the example
            if (!valueDict.TryGetValue(discriminatorPropertyName, out var exampleValue) || exampleValue is not InputExampleRawValue exampleRawValue || exampleRawValue.RawValue == null)
            {
                throw new InvalidOperationException($"Attempting to get the discriminator value for property `{discriminatorPropertyName}` on object type {objectType.Type.Name} but got none or non-primitive type");
            }
            // the discriminator should always be a primitive type
            var actualDiscriminatorValue = exampleRawValue.RawValue;
            var implementation = discriminator.Implementations.FirstOrDefault(info => info.Key.Equals(actualDiscriminatorValue));
            if (implementation == null)
                throw new InvalidOperationException($"Cannot find an implementation corresponding to the discriminator value {actualDiscriminatorValue} for object model type {objectType.Type.Name}");

            return (ObjectType)implementation.Type.Implementation;
        }

        private static CodeWriter AppendObjectTypeValue(this CodeWriter writer, ObjectType objectType, IReadOnlyDictionary<string, InputExampleValue>? valueDict)
        {
            if (valueDict == null)
            {
                writer.AppendRaw("null");
                return writer;
            }
            // need to get the actual ObjectType if this type has a discrinimator
            objectType = GetActualImplementation(objectType, valueDict);
            // get all the properties on this type, including the properties from its base type
            var properties = new HashSet<ObjectTypeProperty>(objectType.EnumerateHierarchy().SelectMany(objectType => objectType.Properties));
            var constructor = objectType.InitializationConstructor;
            writer.Append($"new {objectType.Type}(");
            // build a map from parameter name to property
            var propertyDict = properties.ToDictionary(
                property => property.Declaration.Name.ToVariableName(), property => property);
            // find the corresponding properties in the parameters
            foreach (var parameter in constructor.Signature.Parameters)
            {
                // try every property, convert them to variable name and see if there are some of them matching
                var property = propertyDict[parameter.Name];
                InputExampleValue? exampleValue;
                if (!valueDict.TryGetValue(property.InputModelProperty!.SerializedName, out exampleValue))
                {
                    // we could only stand the case that the missing property here is a collection, in this case, we pass an empty collection
                    if (TypeFactory.IsCollectionType(property.Declaration.Type))
                    {
                        exampleValue = InputExampleValue.List(property.InputModelProperty!.Type, Array.Empty<InputExampleValue>());
                    }
                    else if (IsStringLikeType(property.Declaration.Type))
                    {
                        // this is a patch that some parameter is not marked as required, but in our generated code, it inherits from ResourceData, in which location is in the constructor and our code will recognize it as required
                        exampleValue = InputExampleValue.Value(InputPrimitiveType.String, "placeholder");
                    }
                    else
                        throw new InvalidOperationException($"Example value for required property {property.InputModelProperty!.SerializedName} in class {objectType.Type.Name} is not found");
                }
                properties.Remove(property);
                writer.AppendInputExampleValue(exampleValue, property.Declaration.Type, property.SerializationFormat, includeCollectionInitialization: true).AppendRaw(",");
            }
            writer.RemoveTrailingComma();
            writer.AppendRaw(")");
            var propertiesToWrite = GetPropertiesToWrite(objectType, properties, valueDict);
            if (propertiesToWrite.Count > 0) // only write the property initializers when there are properties to write
            {
                using (writer.Scope($"", newLine: false))
                {
                    foreach (var (property, exampleValue) in propertiesToWrite)
                    {
                        writer.Append($"{property.Declaration.Name} = ");
                        // we need to pass in the current type of this property to make sure its initialization is correct
                        writer.AppendInputExampleValue(exampleValue, property.Declaration.Type, property.SerializationFormat, includeCollectionInitialization: false);
                        writer.LineRaw(",");
                    }
                }
            }
            return writer;
        }

        private static Dictionary<ObjectTypeProperty, InputExampleValue> GetPropertiesToWrite(ObjectType objectType, IEnumerable<ObjectTypeProperty> properties, IReadOnlyDictionary<string, InputExampleValue> valueDict)
        {
            var propertiesToWrite = new Dictionary<ObjectTypeProperty, InputExampleValue>();
            foreach (var property in properties)
            {
                var propertyToDeal = property;
                var inputModelProperty = propertyToDeal.InputModelProperty;
                if (inputModelProperty == null)
                    continue; // now we explicitly ignore all the AdditionalProperties

                if (!valueDict.TryGetValue(inputModelProperty.SerializedName, out var exampleValue))
                    continue; // skip the property that does not have a value

                // check if this property is safe-flattened
                var flattenedProperty = propertyToDeal.FlattenedProperty;
                if (flattenedProperty != null)
                {
                    // unwrap the single property object
                    exampleValue = UnwrapExampleValueFromSinglePropertySchema(exampleValue, flattenedProperty);
                    if (exampleValue == null)
                        continue;
                    propertyToDeal = flattenedProperty;
                }

                if (!IsPropertyAssignable(propertyToDeal))
                    continue; // now we explicitly ignore all the AdditionalProperties

                propertiesToWrite.Add(propertyToDeal, exampleValue);
            }

            return propertiesToWrite;
        }

        private static InputExampleValue? UnwrapExampleValueFromSinglePropertySchema(InputExampleValue exampleValue, FlattenedObjectTypeProperty flattenedProperty)
        {
            var hierarchyStack = flattenedProperty.BuildHierarchyStack();
            // reverse the stack because it is a stack, iterating it will start from the innerest property
            // skip the first because this stack include the property we are handling here right now
            foreach (var property in hierarchyStack.Reverse().Skip(1))
            {
                var schemaProperty = property.SchemaProperty;
                if (schemaProperty == null || exampleValue is not InputExampleObjectValue objectValue || !objectValue.Values.TryGetValue(schemaProperty.SerializedName, out var inner))
                    return null;
                // get the value of this layer
                exampleValue = inner;
            }
            return exampleValue;
        }

        private static bool IsPropertyAssignable(ObjectTypeProperty property)
            => property.Declaration.Accessibility == "public" && (TypeFactory.IsReadWriteDictionary(property.Declaration.Type) || TypeFactory.IsReadWriteList(property.Declaration.Type) || !property.IsReadOnly);

        private static CodeWriter AppendEnumTypeValue(this CodeWriter writer, EnumType enumType, object value)
        {
            // find value in one of the choices.
            // Here we convert the values to string then compare, because the raw value has the "primitive types are deserialized into strings" issue
            var choice = enumType.Values.FirstOrDefault(c => StringComparer.Ordinal.Equals(value.ToString(), c.Value.Value?.ToString()));
            writer.UseNamespace(enumType.Type.Namespace);
            if (choice != null)
                return writer.Append($"{enumType.Type.Name}.{choice.Declaration.Name}");
            // if we did not find a match, check if this is a SealedChoice, if so, we throw exceptions
            if (!enumType.IsExtensible)
                throw new InvalidOperationException($"Enum value `{value}` in example does not find in type {enumType.Type.Name}");
            return writer.Append($"new {enumType.Type}({value:L})");
        }

        public static void ConsoleWriteLine(this CodeWriter writer, FormattableString content)
        {
            writer.Line($"{typeof(Console)}.{nameof(Console.WriteLine)}({content});");
        }
    }
}
