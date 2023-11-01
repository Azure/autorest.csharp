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
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Samples.Models;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Microsoft.CodeAnalysis.CSharp;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.LowLevel.Extensions
{
    internal static class ExampleValueSnippets
    {
        public static ValueExpression GetExpression(CSharpType type, InputExampleValue exampleValue, SerializationFormat serializationFormat, bool includeCollectionInitialization = true)
        {
            // handle ReadOnlyMemory
            if (TypeFactory.IsReadOnlyMemory(type))
                return GetExpressionForList(type, exampleValue, serializationFormat, true);
            // handle list
            if (TypeFactory.IsList(type))
            {
                return GetExpressionForList(type, exampleValue, serializationFormat, includeCollectionInitialization);
            }

            // handle dictionary
            if (TypeFactory.IsDictionary(type))
            {
                return GetExpressionForDictionary(type, exampleValue, serializationFormat, includeCollectionInitialization);
            }

            Type? frameworkType = type.SerializeAs ?? (type.IsFrameworkType ? type.FrameworkType : null);
            if (frameworkType != null)
            {
                // handle framework type
                return GetExpressionForFrameworkType(frameworkType, exampleValue, serializationFormat, includeCollectionInitialization);
            }

            // handle implementation
            return GetExpressionForTypeProvider(type, exampleValue);
        }

        private static ValueExpression GetExpressionForFrameworkType(Type frameworkType, InputExampleValue exampleValue, SerializationFormat serializationFormat, bool includeCollectionInitialization = true)
        {
            // handle objects - we usually do not generate object types, but for some rare cases (such as union type) we generate object
            // and we get this case in the free form object initialization as well
            if (frameworkType == typeof(object))
            {
                return GetExpressionForFreeFormObject(exampleValue, includeCollectionInitialization);
            }

            // handle RequestContent
            if (frameworkType == Configuration.ApiTypes.RequestContentType)
            {
                return GetExpressionForRequestContent(exampleValue);
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
                    return New.Instance(frameworkType, Literal(rawValue.RawValue.ToString()!));
                else
                    return frameworkType.IsValueType ? Default : Null;
            }

            if (frameworkType == typeof(IPAddress))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue != null)
                    return new InvokeStaticMethodExpression(typeof(IPAddress), nameof(IPAddress.Parse), new[] { Literal(rawValue.RawValue.ToString()!) });
                else
                    return Null;
            }

            if (frameworkType == typeof(BinaryData))
            {
                return GetExpressionForBinaryData(exampleValue);
            }

            if (frameworkType == typeof(TimeSpan))
            {
                if (exampleValue is InputExampleRawValue { RawValue: { } } rawValue)
                {
                    switch (serializationFormat)
                    {
                        case SerializationFormat.Duration_Seconds or SerializationFormat.Duration_Seconds_Float:
                            if (rawValue.RawValue is int or float or double)
                                return new InvokeStaticMethodExpression(typeof(TimeSpan), nameof(TimeSpan.FromSeconds), new[] { Literal(rawValue.RawValue) });
                            break;
                        case SerializationFormat.Duration_ISO8601:
                            if (rawValue.RawValue is string duration)
                                return new InvokeStaticMethodExpression(typeof(XmlConvert), nameof(XmlConvert.ToTimeSpan), new[] { Literal(duration) });
                            break;
                        case SerializationFormat.Time_ISO8601:
                            if (rawValue.RawValue is string time)
                                return new InvokeStaticMethodExpression(typeof(TimeSpan), nameof(TimeSpan.Parse), new[] { Literal(time) });
                            break;
                    };
                }

                return Default;
            }

            if (frameworkType == typeof(DateTimeOffset))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue is not null)
                {
                    switch (serializationFormat)
                    {
                        case SerializationFormat.DateTime_Unix:
                            long? time = rawValue.RawValue switch
                            {
                                int i => i,
                                long l => l,
                                _ => null
                            };
                            if (time != null)
                                return DateTimeOffsetExpression.FromUnixTimeSeconds(Long(time.Value));
                            break;
                        case SerializationFormat.DateTime_RFC1123 or SerializationFormat.DateTime_RFC3339 or SerializationFormat.DateTime_RFC7231 or SerializationFormat.DateTime_ISO8601 or SerializationFormat.Date_ISO8601:
                            if (rawValue.RawValue is string s)
                                return DateTimeOffsetExpression.Parse(s);
                            break;
                    }
                }

                return Default;
            }

            if (frameworkType == typeof(Guid))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue is string s)
                {
                    return GuidExpression.Parse(s);
                }

                return Default;
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
                    if (frameworkType == rawValue.RawValue.GetType())
                        return Literal(rawValue.RawValue);
                    else
                        return new CastExpression(Literal(rawValue.RawValue), frameworkType);
                }

                return Default;
            }

            if (frameworkType == typeof(string))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue is not null)
                {
                    return Literal(rawValue.RawValue.ToString());
                }

                return Null;
            }

            if (frameworkType == typeof(bool))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue is bool b)
                    return Literal(b);

                return Default;
            }

            if (frameworkType == typeof(byte[]))
            {
                if (exampleValue is InputExampleRawValue rawValue && rawValue.RawValue is not null)
                    return new TypeReference(typeof(Encoding)).Property(nameof(Encoding.UTF8)).Invoke(nameof(Encoding.GetBytes), Literal(rawValue.RawValue.ToString()));

                return Null;
            }

            return frameworkType.IsValueType ? Default : Null;
        }

        private static ValueExpression GetExpressionForRequestContent(InputExampleValue value)
        {
            if (value is InputExampleRawValue { RawValue: null })
            {
                return Null;
            }
            else
            {
                var freeFormObjectExpression = GetExpressionForFreeFormObject(value, includeCollectionInitialization: true);
                return Configuration.ApiTypes.GetCreateFromStreamSampleExpression(freeFormObjectExpression);
            }
        }

        private static ValueExpression GetExpressionForList(CSharpType listType, InputExampleValue exampleValue, SerializationFormat serializationFormat, bool includeCollectionInitialization = true)
        {
            var exampleListValue = exampleValue as InputExampleListValue;
            var elementType = listType.Arguments.Single();
            var elementExpressions = new List<ValueExpression>();
            // the collections in our generated SDK could never be assigned to, therefore if we have null value here, we can only assign an empty collection
            foreach (var itemValue in exampleListValue?.Values ?? Enumerable.Empty<InputExampleValue>())
            {
                var elementExpression = GetExpression(elementType, itemValue, serializationFormat, includeCollectionInitialization);
                elementExpressions.Add(elementExpression);
            }

            // we only put the array inline when the element is framework type or enum (which is basically framework type generated by us)
            var isNotInline = elementType is { IsFrameworkType: false, Implementation: not EnumType } // when the element is a complex object type (not enum)
                || TypeFactory.IsCollectionType(elementType) // when the element is a collection
                || (elementType.IsFrameworkType && (elementType.FrameworkType == typeof(object) || (elementType.FrameworkType == typeof(BinaryData))));

            return includeCollectionInitialization
                ? New.Array(elementType, !isNotInline, elementExpressions.ToArray())
                : new ArrayInitializerExpression(elementExpressions.ToArray());
        }

        private static ValueExpression GetExpressionForDictionary(CSharpType dictionaryType, InputExampleValue exampleValue, SerializationFormat serializationFormat, bool includeCollectionInitialization = true)
        {
            var exampleObjectValue = exampleValue as InputExampleObjectValue;
            // since this is a dictionary, we take the first generic argument as the key type
            // this is important because in our SDK, the key of a dictionary is not always a string. It could be a string-like type, for instance, a ResourceIdentifier
            var keyType = dictionaryType.Arguments[0];
            // the second as the value type
            var valueType = dictionaryType.Arguments[1];
            var elementExpressions = new List<(ValueExpression KeyExpression, ValueExpression ValueExpression)>();
            // the collections in our generated SDK could never be assigned to, therefore if we have null value here, we can only assign an empty collection
            foreach (var (key, value) in exampleObjectValue?.Values ?? new Dictionary<string, InputExampleValue>())
            {
                var keyExpression = GetExpression(keyType, InputExampleValue.Value(InputPrimitiveType.String, key), SerializationFormat.Default);
                var valueExpression = GetExpression(valueType, value, serializationFormat, includeCollectionInitialization);
                elementExpressions.Add((keyExpression, valueExpression));
            }

            return includeCollectionInitialization
                ? New.Dictionary(keyType, valueType, elementExpressions.ToArray())
                : new DictionaryInitializerExpression(elementExpressions.ToArray());
        }

        private static ValueExpression GetExpressionForBinaryData(InputExampleValue exampleValue)
        {
            //always use FromObjectAsJson for BinaryData so that the serialization works correctly.
            return BinaryDataExpression.FromObjectAsJson(GetExpressionForFreeFormObject(exampleValue, true));
        }

        private static ValueExpression GetExpressionForFreeFormObject(InputExampleValue exampleValue, bool includeCollectionInitialization = true) => exampleValue switch
        {
            InputExampleRawValue rawValue => rawValue.RawValue == null ?
                            Null :
                            GetExpressionForFrameworkType(rawValue.RawValue.GetType(), exampleValue, SerializationFormat.Default, includeCollectionInitialization),
            InputExampleListValue listValue => GetExpressionForList(typeof(IList<object>), listValue, SerializationFormat.Default),
            InputExampleObjectValue objectValue => CanBeInstantiatedByAnonymousObject(objectValue) ?
                            GetExpressionForAnonymousObject(objectValue, includeCollectionInitialization) :
                            GetExpressionForDictionary(typeof(Dictionary<string, object>), objectValue, SerializationFormat.Default, includeCollectionInitialization),
            InputExampleStreamValue streamValue => InvokeFileOpenRead(streamValue.Filename),
            _ => throw new InvalidOperationException($"unhandled case {exampleValue}")
        };

        private static ValueExpression GetExpressionForAnonymousObject(InputExampleObjectValue exampleObjectValue, bool includeCollectionInitialization = true)
        {
            // the collections in our generated SDK could never be assigned to, therefore if we have null value here, we can only assign an empty collection
            var keyValues = exampleObjectValue?.Values ?? new Dictionary<string, InputExampleValue>();
            if (keyValues.Any())
            {
                var properties = new Dictionary<string, ValueExpression>();
                foreach (var (key, value) in keyValues)
                {
                    // we only write a property when it is not null because an anonymous object cannot have null assignments (causes compilation error)
                    if (value is InputExampleRawValue rawValue && rawValue.RawValue == null)
                        continue;

                    var valueExpression = GetExpression(typeof(object), value, SerializationFormat.Default, includeCollectionInitialization);
                    properties.Add(key, valueExpression);
                }

                return New.Anonymous(properties);
            }
            else
            {
                return New.Instance(typeof(object));
            }
        }

        private static bool CanBeInstantiatedByAnonymousObject(InputExampleObjectValue objectValue)
        {
            foreach (var (key, _) in objectValue.Values)
            {
                if (!SyntaxFacts.IsValidIdentifier(key) || SyntaxFacts.IsReservedKeyword(SyntaxFacts.GetKeywordKind(key)))
                {
                    return false;
                }
            }

            return true;
        }

        private static ValueExpression GetExpressionForTypeProvider(CSharpType type, InputExampleValue exampleValue)
        {
            return type.Implementation switch
            {
                ObjectType objectType => GetExpressionForObjectType(objectType, (exampleValue as InputExampleObjectValue)?.Values),
                EnumType enumType when exampleValue is InputExampleRawValue rawValue => GetExpressionForEnumType(enumType, rawValue.RawValue!),
                _ => type is { IsValueType: true, IsNullable: false } ? Default : Null,
            };
        }

        private static ObjectType GetActualImplementation(ObjectType objectType, IReadOnlyDictionary<string, InputExampleValue> valueDict)
        {
            var discriminator = objectType.Discriminator;

            // check if this has a discriminator
            if (discriminator is not { HasDescendants: true })
            {
                return objectType;
            }

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
            {
                throw new InvalidOperationException($"Cannot find an implementation corresponding to the discriminator value {actualDiscriminatorValue} for object model type {objectType.Type.Name}");
            }

            return (ObjectType)implementation.Type.Implementation;
        }

        private static ValueExpression GetExpressionForObjectType(ObjectType objectType, IReadOnlyDictionary<string, InputExampleValue>? valueDict)
        {
            if (valueDict == null)
            {
                return Default;
            }

            // need to get the actual ObjectType if this type has a discriminator
            objectType = GetActualImplementation(objectType, valueDict);
            // get all the properties on this type, including the properties from its base type
            var properties = new HashSet<ObjectTypeProperty>(objectType.EnumerateHierarchy().SelectMany(objectType => objectType.Properties));
            var constructor = objectType.InitializationConstructor;
            // build a map from parameter name to property
            var propertyDict = properties.ToDictionary(property => property.Declaration.Name.ToVariableName(), property => property);
            // find the corresponding properties in the parameters
            var arguments = new List<ValueExpression>();
            foreach (var parameter in constructor.Signature.Parameters)
            {
                // try every property, convert them to variable name and see if there are some of them matching
                var property = propertyDict[parameter.Name];
                var propertyType = property.Declaration.Type;
                ValueExpression argument;
                if (valueDict.TryGetValue(property.InputModelProperty!.SerializedName, out var exampleValue))
                {
                    properties.Remove(property);
                    argument = GetExpression(propertyType, exampleValue, SerializationBuilder.GetSerializationFormat(exampleValue.Type), includeCollectionInitialization: true);
                }
                else
                {
                    // if no match, we put default here
                    argument = propertyType is { IsValueType: true, IsNullable: false } ? Default : Null;
                }
                arguments.Add(argument);
            }
            var propertiesToWrite = GetPropertiesToWrite(properties, valueDict);
            ObjectInitializerExpression? objectPropertyInitializer = null;
            if (propertiesToWrite.Count > 0) // only write the property initializers when there are properties to write
            {
                var initializerDict = new Dictionary<string, ValueExpression>();
                foreach (var (property, exampleValue) in propertiesToWrite)
                {
                    // we need to pass in the current type of this property to make sure its initialization is correct
                    var propertyExpression = GetExpression(property.Declaration.Type, exampleValue, SerializationBuilder.GetSerializationFormat(exampleValue.Type), includeCollectionInitialization: false);
                    initializerDict.Add(property.Declaration.Name, propertyExpression);
                }
                objectPropertyInitializer = new(initializerDict, false);
            }

            return new NewInstanceExpression(objectType.Type, arguments, objectPropertyInitializer);
        }

        private static IReadOnlyDictionary<ObjectTypeProperty, InputExampleValue> GetPropertiesToWrite(IEnumerable<ObjectTypeProperty> properties, IReadOnlyDictionary<string, InputExampleValue> valueDict)
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

        private static ValueExpression GetExpressionForEnumType(EnumType enumType, object value)
        {
            // find value in one of the choices.
            // Here we convert the values to string then compare, because the raw value has the "primitive types are deserialized into strings" issue
            var choice = enumType.Values.FirstOrDefault(c => StringComparer.Ordinal.Equals(value.ToString(), c.Value.Value?.ToString()));
            if (choice != null)
                return EnumValue(enumType, choice);
            // if we did not find a match, check if this is a SealedChoice, if so, we throw exceptions
            if (!enumType.IsExtensible)
                throw new InvalidOperationException($"Enum value `{value}` in example does not find in type {enumType.Type.Name}");
            return New.Instance(enumType.Type, Literal(value));
        }
    }
}
