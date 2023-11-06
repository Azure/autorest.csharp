// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Microsoft.CodeAnalysis;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal static class JsonSerializationMethodsBuilder
    {
        public static Method BuildUtf8JsonSerializableWrite(JsonObjectSerialization jsonObjectSerialization)
        {
            var utf8JsonWriter = new Parameter("writer", null, typeof(Utf8JsonWriter), null, Validation.None, null);
            return new Method
            (
                new MethodSignature(Configuration.ApiTypes.IUtf8JsonSerializableWriteName, null, null, MethodSignatureModifiers.None, null, null, new[] { utf8JsonWriter }, ExplicitInterface: Configuration.ApiTypes.IUtf8JsonSerializableType),
                WriteObject(new Utf8JsonWriterExpression(utf8JsonWriter), jsonObjectSerialization)
            );
        }

        public static MethodBodyStatement[] WriteObject(Utf8JsonWriterExpression utf8JsonWriter, JsonObjectSerialization serialization)
            => new[]
            {
                utf8JsonWriter.WriteStartObject(),
                WriteProperties(utf8JsonWriter, serialization.Properties).ToArray(),
                SerializeAdditionalProperties(utf8JsonWriter, serialization.AdditionalProperties),
                utf8JsonWriter.WriteEndObject()
            };

        public static IEnumerable<MethodBodyStatement> WriteProperties(Utf8JsonWriterExpression utf8JsonWriter, IEnumerable<JsonPropertySerialization> properties)
        {
            foreach (JsonPropertySerialization property in properties)
            {
                if (property.ShouldSkipSerialization)
                {
                    continue;
                }

                if (property.ValueSerialization == null)
                {
                    // Flattened property
                    yield return utf8JsonWriter.WritePropertyName(property.SerializedName);
                    yield return utf8JsonWriter.WriteStartObject();
                    yield return WriteProperties(utf8JsonWriter, property.PropertySerializations!).ToArray();
                    yield return utf8JsonWriter.WriteEndObject();
                }
                else if (property.SerializedType is { IsNullable: true })
                {
                    var checkPropertyIsInitialized = TypeFactory.IsCollectionType(property.Value.Type) && !TypeFactory.IsReadOnlyMemory(property.Value.Type) && property.IsRequired
                        ? And(NotEqual(property.Value, Null), InvokeOptional.IsCollectionDefined(property.Value))
                        : NotEqual(property.Value, Null);

                    yield return InvokeOptional.WrapInIsDefined(
                        property,
                        new IfElseStatement(checkPropertyIsInitialized,
                            WriteProperty(utf8JsonWriter, property),
                            utf8JsonWriter.WriteNull(property.SerializedName)
                        )
                    );
                }
                else
                {
                    yield return InvokeOptional.WrapInIsDefined(property, WriteProperty(utf8JsonWriter, property));
                }
            }
        }

        private static MethodBodyStatement WriteProperty(Utf8JsonWriterExpression utf8JsonWriter, JsonPropertySerialization serialization)
        {
            return new[]
            {
                utf8JsonWriter.WritePropertyName(serialization.SerializedName),
                serialization.CustomSerializationMethodName is {} serializationMethodName
                    ? InvokeCustomSerializationMethod(serializationMethodName, utf8JsonWriter)
                    : SerializeExpression(utf8JsonWriter, serialization.ValueSerialization, serialization.Value)
            };
        }

        private static MethodBodyStatement SerializeAdditionalProperties(Utf8JsonWriterExpression utf8JsonWriter, JsonAdditionalPropertiesSerialization? additionalProperties)
        {
            if (additionalProperties is null)
            {
                return new MethodBodyStatement();
            }

            var additionalPropertiesExpression = new DictionaryExpression(additionalProperties.Type.Arguments[0], additionalProperties.Type.Arguments[1], additionalProperties.Value);
            return new ForeachStatement("item", additionalPropertiesExpression, out KeyValuePairExpression item)
            {
                utf8JsonWriter.WritePropertyName(item.Key),
                SerializeExpression(utf8JsonWriter, additionalProperties.ValueSerialization, item.Value)
            };
        }

        public static MethodBodyStatement SerializeExpression(Utf8JsonWriterExpression utf8JsonWriter, JsonSerialization? serialization, TypedValueExpression expression)
            => serialization switch
            {
                JsonArraySerialization array => SerializeArray(utf8JsonWriter, array, GetEnumerableExpression(expression, array)),
                JsonDictionarySerialization dictionary => SerializeDictionary(utf8JsonWriter, dictionary, new DictionaryExpression(dictionary.Type.Arguments[0], dictionary.Type.Arguments[1], expression)),
                JsonValueSerialization value => SerializeValue(utf8JsonWriter, value, expression),
                _ => throw new NotSupportedException()
            };

        private static EnumerableExpression GetEnumerableExpression(TypedValueExpression expression, JsonArraySerialization array)
        {
            if (TypeFactory.IsReadOnlyMemory(expression.Type))
            {
                expression = expression
                    .NullableStructValue()
                    .Property(nameof(ReadOnlyMemory<byte>.Span), new CSharpType(typeof(ReadOnlySpan<>), expression.Type.Arguments[0]));
            }

            return new EnumerableExpression(TypeFactory.GetElementType(array.Type), expression);
        }

        private static MethodBodyStatement SerializeArray(Utf8JsonWriterExpression utf8JsonWriter, JsonArraySerialization arraySerialization, EnumerableExpression array)
        {
            return new[]
            {
                utf8JsonWriter.WriteStartArray(),
                new ForeachStatement("item", array, out var item)
                {
                    CheckCollectionItemForNull(utf8JsonWriter, arraySerialization.ValueSerialization, item),
                    SerializeExpression(utf8JsonWriter, arraySerialization.ValueSerialization, item)
                },
                utf8JsonWriter.WriteEndArray()
            };
        }

        private static MethodBodyStatement SerializeDictionary(Utf8JsonWriterExpression utf8JsonWriter, JsonDictionarySerialization dictionarySerialization, DictionaryExpression dictionary)
        {
            return new[]
            {
                utf8JsonWriter.WriteStartObject(),
                new ForeachStatement("item", dictionary, out KeyValuePairExpression keyValuePair)
                {
                    utf8JsonWriter.WritePropertyName(keyValuePair.Key),
                    CheckCollectionItemForNull(utf8JsonWriter, dictionarySerialization.ValueSerialization, keyValuePair.Value),
                    SerializeExpression(utf8JsonWriter, dictionarySerialization.ValueSerialization, keyValuePair.Value)
                },
                utf8JsonWriter.WriteEndObject()
            };
        }

        private static MethodBodyStatement SerializeValue(Utf8JsonWriterExpression utf8JsonWriter, JsonValueSerialization valueSerialization, TypedValueExpression value)
        {
            if (valueSerialization.Type.SerializeAs is not null)
            {
                return SerializeFrameworkTypeValue(utf8JsonWriter, valueSerialization, value, valueSerialization.Type.SerializeAs);
            }

            if (valueSerialization.Type.IsFrameworkType)
            {
                return SerializeFrameworkTypeValue(utf8JsonWriter, valueSerialization, value, valueSerialization.Type.FrameworkType);
            }

            switch (valueSerialization.Type.Implementation)
            {
                case SystemObjectType systemObjectType when IsCustomJsonConverterAdded(systemObjectType.SystemType):
                    if (valueSerialization.Options == JsonSerializationOptions.UseManagedServiceIdentityV3)
                    {
                        return new[]
                        {
                            Var("serializeOptions", New.JsonSerializerOptions(), out var serializeOptions),
                            InvokeJsonSerializerSerializeMethod(utf8JsonWriter, value, serializeOptions)
                        };
                    }

                    return InvokeJsonSerializerSerializeMethod(utf8JsonWriter, value);

                case ObjectType:
                    return utf8JsonWriter.WriteObjectValue(value);

                case EnumType { IsIntValueType: true, IsExtensible: false } enumType:
                    return utf8JsonWriter.WriteNumberValue(new CastExpression(value.NullableStructValue(valueSerialization.Type), enumType.ValueType));

                case EnumType { IsNumericValueType: true } enumType:
                    return utf8JsonWriter.WriteNumberValue(new EnumExpression(enumType, value.NullableStructValue(valueSerialization.Type)).ToSerial());

                case EnumType enumType:
                    return utf8JsonWriter.WriteStringValue(new EnumExpression(enumType, value.NullableStructValue(valueSerialization.Type)).ToSerial());
            }

            throw new NotSupportedException();
        }

        private static MethodBodyStatement SerializeFrameworkTypeValue(Utf8JsonWriterExpression utf8JsonWriter, JsonValueSerialization valueSerialization, ValueExpression value, Type valueType)
        {
            if (valueType == typeof(JsonElement))
            {
                return new JsonElementExpression(value).WriteTo(utf8JsonWriter);
            }

            if (valueType == typeof(Nullable<>))
            {
                valueType = valueSerialization.Type.Arguments[0].FrameworkType;
            }

            value = value.NullableStructValue(valueSerialization.Type);

            if (valueType == typeof(decimal) || valueType == typeof(double) || valueType == typeof(float) || valueType == typeof(long) || valueType == typeof(int) || valueType == typeof(short))
            {
                return utf8JsonWriter.WriteNumberValue(value);
            }

            if (valueType == typeof(object))
            {
                return utf8JsonWriter.WriteObjectValue(value);
            }

            if (valueType == typeof(string) || valueType == typeof(char) || valueType == typeof(Guid) || valueType == typeof(ResourceIdentifier) || valueType == typeof(ResourceType) || valueType == typeof(RequestMethod) || valueType == typeof(AzureLocation))
            {
                return utf8JsonWriter.WriteStringValue(value);
            }

            if (valueType == typeof(bool))
            {
                return utf8JsonWriter.WriteBooleanValue(value);
            }

            if (valueType == typeof(byte[]))
            {
                return utf8JsonWriter.WriteBase64StringValue(value, valueSerialization.Format.ToFormatSpecifier());
            }

            if (valueType == typeof(DateTimeOffset) || valueType == typeof(DateTime) || valueType == typeof(TimeSpan))
            {
                var format = valueSerialization.Format.ToFormatSpecifier();

                if (valueSerialization.Format is SerializationFormat.Duration_Seconds)
                {
                    return utf8JsonWriter.WriteNumberValue(InvokeConvert.ToInt32(new TimeSpanExpression(value).ToString(format)));
                }

                if (valueSerialization.Format is SerializationFormat.Duration_Seconds_Float)
                {
                    return utf8JsonWriter.WriteNumberValue(InvokeConvert.ToDouble(new TimeSpanExpression(value).ToString(format)));
                }

                if (valueSerialization.Format is SerializationFormat.DateTime_Unix)
                {
                    return utf8JsonWriter.WriteNumberValue(value, format);
                }
                return format is not null
                    ? utf8JsonWriter.WriteStringValue(value, format)
                    : utf8JsonWriter.WriteStringValue(value);
            }

            if (valueType == typeof(ETag) || valueType == typeof(ContentType) || valueType == typeof(IPAddress))
            {
                return utf8JsonWriter.WriteStringValue(value.InvokeToString());
            }

            if (valueType == typeof(Uri))
            {
                return utf8JsonWriter.WriteStringValue(new MemberExpression(value, nameof(Uri.AbsoluteUri)));
            }

            if (valueType == typeof(BinaryData))
            {
                var binaryDataValue = new BinaryDataExpression(value);
                if (valueSerialization.Format is SerializationFormat.Bytes_Base64 or SerializationFormat.Bytes_Base64Url)
                {
                    return utf8JsonWriter.WriteBase64StringValue(binaryDataValue.ToArray(), valueSerialization.Format.ToFormatSpecifier());
                }

                return new IfElsePreprocessorDirective
                (
                    "NET6_0_OR_GREATER",
                    utf8JsonWriter.WriteRawValue(value),
                    new UsingScopeStatement(typeof(JsonDocument), "document", JsonDocumentExpression.Parse(binaryDataValue), out var jsonDocumentVar)
                    {
                        InvokeJsonSerializerSerializeMethod(utf8JsonWriter, new JsonDocumentExpression(jsonDocumentVar).RootElement)
                    }
                );
            }

            if (IsCustomJsonConverterAdded(valueType))
            {
                return InvokeJsonSerializerSerializeMethod(utf8JsonWriter, value);
            }

            throw new NotSupportedException($"Framework type {valueType} serialization not supported");
        }

        private static MethodBodyStatement CheckCollectionItemForNull(Utf8JsonWriterExpression utf8JsonWriter, JsonSerialization valueSerialization, ValueExpression value)
            => CollectionItemRequiresNullCheckInSerialization(valueSerialization)
                ? new IfStatement(Equal(value, Null)) { utf8JsonWriter.WriteNullValue(), Continue }
                : new MethodBodyStatement();

        public static Method? BuildDeserialize(TypeDeclarationOptions declaration, JsonObjectSerialization serialization, INamedTypeSymbol? existingType)
        {
            var methodName = $"Deserialize{declaration.Name}";
            var element = new Parameter("element", null, typeof(JsonElement), null, Validation.None, null);
            var signature = new MethodSignature(methodName, null, null, MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static, serialization.Type, null, new[]{element});
            if (SourceInputHelper.TryGetExistingMethod(existingType, signature, out _))
            {
                return null;
            }

            return new Method(signature, BuildDeserializeBody(element, serialization).ToArray());
        }

        private static IEnumerable<MethodBodyStatement> BuildDeserializeBody(Parameter element, JsonObjectSerialization serialization)
        {
            var jsonElement = new JsonElementExpression(element);
            if (!serialization.Type.IsValueType) // only return null for reference type (e.g. no enum)
            {
                yield return new IfStatement(jsonElement.ValueKindEqualsNull())
                {
                    Return(Null)
                };
            }

            var discriminator = serialization.Discriminator;
            if (discriminator is not null && discriminator.HasDescendants)
            {
                yield return new IfStatement(jsonElement.TryGetProperty(element.Name, discriminator.SerializedName, out var discriminatorElement))
                {
                    new SwitchStatement(discriminatorElement.GetString(), GetDiscriminatorCases(jsonElement, discriminator).ToArray())
                };
            }

            if (discriminator is not null && !serialization.Type.HasParent && !serialization.Type.Equals(discriminator.DefaultObjectType.Type))
            {
                yield return Return(GetDeserializeImplementation(discriminator.DefaultObjectType.Type.Implementation, jsonElement, null));
            }
            else
            {
                yield return WriteObjectInitialization(jsonElement, serialization).ToArray();
            }
        }

        private static IEnumerable<SwitchCase> GetDiscriminatorCases(JsonElementExpression element, ObjectTypeDiscriminator discriminator)
        {
            foreach (var implementation in discriminator.Implementations)
            {
                yield return new SwitchCase(Literal(implementation.Key), Return(GetDeserializeImplementation(implementation.Type.Implementation, element, null)), true);
            }
        }

        private static IEnumerable<MethodBodyStatement> WriteObjectInitialization(JsonElementExpression element, JsonObjectSerialization serialization)
        {
            // this is the first level of object hierarchy
            // collect all properties and initialize the dictionary
            var propertyVariables = new Dictionary<JsonPropertySerialization, VariableReference>();

            CollectPropertiesForDeserialization(propertyVariables, serialization.Properties);

            var additionalProperties = serialization.AdditionalProperties;
            if (additionalProperties != null)
            {
                propertyVariables.Add(additionalProperties, new VariableReference(additionalProperties.Value.Type, additionalProperties.SerializationConstructorParameterName));
            }

            bool isThisTheDefaultDerivedType = serialization.Type.Equals(serialization.Discriminator?.DefaultObjectType.Type);

            foreach (var variable in propertyVariables)
            {
                if (serialization.Discriminator?.SerializedName == variable.Key.SerializedName &&
                    isThisTheDefaultDerivedType &&
                    serialization.Discriminator.Value is not null &&
                    serialization.Discriminator.Property.Declaration.Type is not { IsEnum: true, Implementation: not EnumType { IsExtensible: true }})
                {
                    var defaultValue = serialization.Discriminator.Value.Value.Value?.ToString();
                    yield return Declare(variable.Value, Literal(defaultValue));
                }
                else
                {
                    yield return Declare(variable.Value, Snippets.Default);
                }
            }

            var shouldTreatEmptyStringAsNull = Configuration.ModelsToTreatEmptyStringAsNull.Contains(serialization.Type.Name);
            var objAdditionalProperties = serialization.AdditionalProperties;
            if (objAdditionalProperties != null)
            {
                yield return Declare("additionalPropertiesDictionary", New.Dictionary(objAdditionalProperties.Type.Arguments[0], objAdditionalProperties.Type.Arguments[1]), out var dictionary);
                yield return new ForeachStatement("property", element.EnumerateObject(), out var property)
                {
                    DeserializeIntoObjectProperties(serialization.Properties, objAdditionalProperties.ValueSerialization, new JsonPropertyExpression(property), dictionary, propertyVariables, shouldTreatEmptyStringAsNull)
                };
                yield return new AssignValueStatement(propertyVariables[objAdditionalProperties], dictionary);
            }
            else
            {
                yield return new ForeachStatement("property", element.EnumerateObject(), out var property)
                {
                    DeserializeIntoObjectProperties(serialization.Properties, new JsonPropertyExpression(property), propertyVariables, shouldTreatEmptyStringAsNull)
                };
            }

            var parameterValues = propertyVariables.ToDictionary(v => v.Key.SerializationConstructorParameterName, v => GetOptional(v.Key, v.Value));
            var parameters = serialization.ConstructorParameters
                .Select(p => parameterValues[p.Name])
                .ToArray();

            yield return Return(New.Instance(serialization.Type, parameters));
        }

        private static MethodBodyStatement DeserializeIntoObjectProperties(IEnumerable<JsonPropertySerialization> propertySerializations, JsonSerialization? additionalPropertiesSerialization, JsonPropertyExpression jsonProperty, DictionaryExpression dictionary, IReadOnlyDictionary<JsonPropertySerialization, VariableReference> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            if (additionalPropertiesSerialization is null)
            {
                return DeserializeIntoObjectProperties(propertySerializations, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull);
            }

            return new[]
            {
                DeserializeIntoObjectProperties(propertySerializations, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull),
                DeserializeValue(additionalPropertiesSerialization, jsonProperty.Value, out var value),
                dictionary.Add(jsonProperty.Name, value)
            };
        }

        private static MethodBodyStatement DeserializeIntoObjectProperties(IEnumerable<JsonPropertySerialization> propertySerializations, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, VariableReference> propertyVariables, bool shouldTreatEmptyStringAsNull)
            => propertySerializations
                .Where(p => !p.ShouldSkipDeserialization)
                .Select(p => new IfStatement(jsonProperty.NameEquals(p.SerializedName))
                {
                    DeserializeIntoObjectProperty(p, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull)
                })
                .ToArray();

        private static MethodBodyStatement DeserializeIntoObjectProperty(JsonPropertySerialization jsonPropertySerialization, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, VariableReference> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            // write the deserialization hook
            if (jsonPropertySerialization.CustomDeserializationMethodName is { } deserializationMethodName)
            {
                return new[]
                {
                    InvokeCustomDeserializationMethod(deserializationMethodName, jsonProperty, propertyVariables[jsonPropertySerialization].Declaration),
                    Continue
                };
            }

            // Reading a property value
            if (jsonPropertySerialization.ValueSerialization is not null)
            {
                return new[]
                {
                    CreatePropertyNullCheckStatement(jsonPropertySerialization, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull),
                    DeserializeValue(jsonPropertySerialization.ValueSerialization, jsonProperty.Value, out var value),
                    Assign(propertyVariables[jsonPropertySerialization], value),
                    Continue
                };
            }

            // Reading a nested object
            if (jsonPropertySerialization.PropertySerializations is not null)
            {
                return new[]
                {
                    CreatePropertyNullCheckStatement(jsonPropertySerialization, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull),
                    new ForeachStatement("property", jsonProperty.Value.EnumerateObject(), out var nestedItemVariable)
                    {
                        DeserializeIntoObjectProperties(jsonPropertySerialization.PropertySerializations, new JsonPropertyExpression(nestedItemVariable), propertyVariables, shouldTreatEmptyStringAsNull)
                    },
                    Continue
                };
            }

            throw new InvalidOperationException($"Either {nameof(JsonPropertySerialization.ValueSerialization)} must not be null or {nameof(JsonPropertySerialization.PropertySerializations)} must not be null.");
        }

        private static MethodBodyStatement CreatePropertyNullCheckStatement(JsonPropertySerialization jsonPropertySerialization, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, VariableReference> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            var checkEmptyProperty = GetCheckEmptyPropertyValueExpression(jsonProperty, jsonPropertySerialization, shouldTreatEmptyStringAsNull);
            var serializedType = jsonPropertySerialization.SerializedType;
            if (serializedType?.IsNullable == true)
            {
                var propertyVariable = propertyVariables[jsonPropertySerialization];

                // we only assign null when it is not a collection if we have DeserializeNullCollectionAsNullValue configuration is off
                // specially when it is required, we assign ChangeTrackingList because for optional lists we are already doing that
                if (!TypeFactory.IsCollectionType(serializedType) || Configuration.DeserializeNullCollectionAsNullValue)
                {
                    return new IfStatement(checkEmptyProperty)
                    {
                        Assign(propertyVariable, Null),
                        Continue
                    };
                }

                if (jsonPropertySerialization.IsRequired && !propertyVariable.Type.IsValueType)
                {
                    return new IfStatement(checkEmptyProperty)
                    {
                        Assign(propertyVariable, New.Instance(TypeFactory.GetPropertyImplementationType(propertyVariable.Type))),
                        Continue
                    };
                }

                return new IfStatement(checkEmptyProperty)
                {
                    Continue
                };
            }

            if (jsonPropertySerialization.IsRequired)
            {
                return new MethodBodyStatement();
            }

            var propertyType = jsonPropertySerialization.ValueSerialization?.Type;
            // even if ReadOnlyMemory is required we leave the list empty if the payload doesn't have it
            if (jsonPropertySerialization.IsRequired && (propertyType is null || !TypeFactory.IsReadOnlyMemory(propertyType)))
            {
                return new MethodBodyStatement();
            }

            if (propertyType?.Equals(typeof(JsonElement)) == true || // JsonElement handles nulls internally
                propertyType?.Equals(typeof(string)) == true) //https://github.com/Azure/autorest.csharp/issues/922
            {
                return new MethodBodyStatement();
            }

            if (jsonPropertySerialization.PropertySerializations is null)
            {
                return new IfStatement(checkEmptyProperty)
                {
                    Continue
                };
            }

            return new IfStatement(checkEmptyProperty)
            {
                jsonProperty.ThrowNonNullablePropertyIsNull(),
                Continue
            };
        }

        private static BoolExpression GetCheckEmptyPropertyValueExpression(JsonPropertyExpression jsonProperty, JsonPropertySerialization jsonPropertySerialization, bool shouldTreatEmptyStringAsNull)
        {
            var jsonElement = jsonProperty.Value;
            if (!shouldTreatEmptyStringAsNull)
            {
                return jsonElement.ValueKindEqualsNull();
            }

            if (jsonPropertySerialization.ValueSerialization is not JsonValueSerialization { Type.IsFrameworkType: true } valueSerialization)
            {
                return jsonElement.ValueKindEqualsNull();
            }

            if (!Configuration.IntrinsicTypesToTreatEmptyStringAsNull.Contains(valueSerialization.Type.FrameworkType.Name))
            {
                return jsonElement.ValueKindEqualsNull();
            }

            return Or(jsonElement.ValueKindEqualsNull(), And(jsonElement.ValueKindEqualsString(), Equal(jsonElement.GetString().Length, Int(0))));

        }

        /// Collects a list of properties being read from all level of object hierarchy
        private static void CollectPropertiesForDeserialization(IDictionary<JsonPropertySerialization, VariableReference> propertyVariables, IEnumerable<JsonPropertySerialization> jsonProperties)
        {
            foreach (JsonPropertySerialization jsonProperty in jsonProperties.Where(p => !p.ShouldSkipDeserialization))
            {
                if (jsonProperty.ValueSerialization?.Type is {} variableType && jsonProperty.SerializedType is {} serializedType)
                {
                    var propertyDeclaration = new CodeWriterDeclaration(jsonProperty.SerializedName.ToVariableName());
                    if (!jsonProperty.IsRequired)
                    {
                        if (variableType.IsFrameworkType && variableType.FrameworkType == typeof(Nullable<>))
                        {
                            variableType = new CSharpType(variableType.Arguments[0].FrameworkType);
                        }

                        if (!serializedType.IsNullable) // Optional via nullability
                        {
                            variableType = variableType.WithNullable(false);
                        }

                        variableType = new CSharpType(Configuration.ApiTypes.OptionalPropertyType, variableType);
                    }

                    propertyVariables.Add(jsonProperty, new VariableReference(variableType, propertyDeclaration));
                }
                else if (jsonProperty.PropertySerializations != null)
                {
                    CollectPropertiesForDeserialization(propertyVariables, jsonProperty.PropertySerializations);
                }
            }
        }

        public static MethodBodyStatement BuildDeserializationForMethods(JsonSerialization serialization, bool async, ValueExpression? variable, StreamExpression stream, bool isBinaryData)
        {
            if (isBinaryData)
            {
                var callFromStream = BinaryDataExpression.FromStream(stream, async);
                var variableExpression = variable is not null ? new BinaryDataExpression(variable) : null;
                return AssignOrReturn(variableExpression, callFromStream);
            }

            if (!serialization.IsNullable)
            {
                return new[]
                {
                    UsingVar("document", JsonDocumentExpression.Parse(stream, async), out var document),
                    DeserializeValue(serialization, document.RootElement, out var value),
                    AssignOrReturn(variable, value)
                };
            }
            else
            {
                return new MethodBodyStatement[]
                {
                    UsingVar("document", JsonDocumentExpression.Parse(stream, async), out var document),
                    new IfElseStatement
                    (
                        document.RootElement.ValueKindEqualsNull(),
                        AssignOrReturn(variable, Null),
                        new[]
                        {
                            DeserializeValue(serialization, document.RootElement, out var value),
                            AssignOrReturn(variable, value)
                        }
                    )
                };
            }
        }

        public static MethodBodyStatement DeserializeValue(JsonSerialization serialization, JsonElementExpression element, out ValueExpression value)
        {
            switch (serialization)
            {
                case JsonArraySerialization jsonReadOnlyMemory when TypeFactory.IsReadOnlyMemory(jsonReadOnlyMemory.Type):
                    var array = new VariableReference(TypeFactory.GetImplementationType(jsonReadOnlyMemory.Type), "array");
                    var index = new VariableReference(typeof(int), "index");
                    var deserializeReadOnlyMemory = new MethodBodyStatement[]
                    {
                        Declare(index, Int(0)),
                        Declare(array, New.Array(jsonReadOnlyMemory.ValueSerialization.Type, element.GetArrayLength())),
                        new ForeachStatement("item", element.EnumerateArray(), out var item)
                        {
                            DeserializeArrayItemIntoArray(jsonReadOnlyMemory.ValueSerialization, new ArrayElementExpression(array, index), new JsonElementExpression(item)),
                            Increment(index)
                        }
                    };
                    value = New.Instance(jsonReadOnlyMemory.Type, array);
                    return deserializeReadOnlyMemory;

                case JsonArraySerialization arraySerialization:
                    var deserializeArrayStatement = new MethodBodyStatement[]
                    {
                        Declare("array", New.List(arraySerialization.ValueSerialization.Type), out var list),
                        new ForeachStatement("item", element.EnumerateArray(), out var arrayItem)
                        {
                            DeserializeArrayItemIntoList(arraySerialization.ValueSerialization, list, new JsonElementExpression(arrayItem))
                        }
                    };
                    value = list;
                    return deserializeArrayStatement;

                case JsonDictionarySerialization dictionarySerialization:
                    var deserializeDictionaryStatement = new MethodBodyStatement[]
                    {
                        Declare("dictionary", New.Dictionary(dictionarySerialization.Type.Arguments[0], dictionarySerialization.Type.Arguments[1]), out var dictionary),
                        new ForeachStatement("property", element.EnumerateObject(), out var property)
                        {
                            DeserializeDictionaryValue(dictionarySerialization.ValueSerialization, dictionary, new JsonPropertyExpression(property))
                        }
                    };
                    value = dictionary;
                    return deserializeDictionaryStatement;

                case JsonValueSerialization { Options: JsonSerializationOptions.UseManagedServiceIdentityV3 } valueSerialization:
                    var declareSerializeOptions = Var("serializeOptions", New.JsonSerializerOptions(), out var serializeOptions);
                    value = GetDeserializeValueExpression(element, valueSerialization.Type, valueSerialization.Format, serializeOptions);
                    return declareSerializeOptions;

                case JsonValueSerialization valueSerialization:
                    value = GetDeserializeValueExpression(element, valueSerialization.Type, valueSerialization.Format);
                    return new MethodBodyStatement();

                default:
                    throw new InvalidOperationException($"{serialization.GetType()} is not supported.");
            }
        }

        private static MethodBodyStatement DeserializeArrayItemIntoList(JsonSerialization serialization, ListExpression listVariable, JsonElementExpression arrayItemVariable)
            => NullCheckCollectionItemIfRequired(serialization, arrayItemVariable, listVariable.Add(Null), new[]
            {
                DeserializeValue(serialization, arrayItemVariable, out var value),
                listVariable.Add(value),
            });

        private static MethodBodyStatement DeserializeArrayItemIntoArray(JsonSerialization serialization, ArrayElementExpression arrayElement, JsonElementExpression arrayItemVariable)
            => NullCheckCollectionItemIfRequired(serialization, arrayItemVariable, Assign(arrayElement, Null), new[]
            {
                DeserializeValue(serialization, arrayItemVariable, out var value),
                Assign(arrayElement, value),
            });

        private static MethodBodyStatement NullCheckCollectionItemIfRequired(JsonSerialization serialization, JsonElementExpression arrayItemVariable, MethodBodyStatement assignNull, MethodBodyStatement deserializeValue)
            => CollectionItemRequiresNullCheckInSerialization(serialization)
                ? new IfElseStatement(arrayItemVariable.ValueKindEqualsNull(), assignNull, deserializeValue)
                : deserializeValue;

        private static MethodBodyStatement DeserializeDictionaryValue(JsonSerialization serialization, DictionaryExpression dictionary, JsonPropertyExpression property)
        {
            var element = property.Value;
            var deserializeValueBlock = new[]
            {
                DeserializeValue(serialization, element, out var value),
                dictionary.Add(property.Name, value)
            };

            if (CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                return new IfElseStatement
                (
                    element.ValueKindEqualsNull(),
                    dictionary.Add(property.Name, Null),
                    deserializeValueBlock
                );
            }

            return deserializeValueBlock;
        }

        public static ValueExpression GetDeserializeValueExpression(JsonElementExpression element, CSharpType serializationType, SerializationFormat serializationFormat = SerializationFormat.Default, ValueExpression? serializerOptions = null)
        {
            if (serializationType.SerializeAs != null)
            {
                return new CastExpression(GetFrameworkTypeValueExpression(serializationType.SerializeAs, element, serializationFormat, serializationType), serializationType);
            }

            if (serializationType.IsFrameworkType)
            {
                var frameworkType = serializationType.FrameworkType;
                if (frameworkType == typeof(Nullable<>))
                {
                    frameworkType = serializationType.Arguments[0].FrameworkType;
                }

                return GetFrameworkTypeValueExpression(frameworkType, element, serializationFormat, serializationType);
            }

            return GetDeserializeImplementation(serializationType.Implementation, element, serializerOptions);
        }

        public static ValueExpression GetDeserializeImplementation(TypeProvider implementation, JsonElementExpression element, ValueExpression? serializerOptions)
        {
            switch (implementation)
            {
                case SystemObjectType systemObjectType when IsCustomJsonConverterAdded(systemObjectType.SystemType):
                    return InvokeJsonSerializerDeserializeMethod(element, implementation.Type, serializerOptions);

                case Resource { ResourceData: SerializableObjectType { IncludeDeserializer: true } resourceDataType } resource:
                    return New.Instance(resource.Type, new MemberExpression(null, "Client"), SerializableObjectTypeExpression.Deserialize(resourceDataType, element));

                case MgmtObjectType mgmtObjectType when TypeReferenceTypeChooser.HasMatch(mgmtObjectType.ObjectSchema):
                    return InvokeJsonSerializerDeserializeMethod(element, implementation.Type);

                case SerializableObjectType { IncludeDeserializer: true } type:
                    return SerializableObjectTypeExpression.Deserialize(type, element);

                case EnumType clientEnum:
                    var value = GetFrameworkTypeValueExpression(clientEnum.ValueType.FrameworkType, element, SerializationFormat.Default, null);
                    return EnumExpression.ToEnum(clientEnum, value);

                default:
                    throw new NotSupportedException($"No deserialization logic exists for {implementation.Declaration.Name}");
            }
        }

        private static ValueExpression GetOptional(PropertySerialization jsonPropertySerialization, TypedValueExpression variable)
        {
            var sourceType = variable.Type;
            if (!sourceType.IsFrameworkType || sourceType.FrameworkType != Configuration.ApiTypes.OptionalPropertyType)
            {
                return variable;
            }

            var targetType = jsonPropertySerialization.Value.Type;
            if (TypeFactory.IsList(targetType) && !TypeFactory.IsReadOnlyMemory(targetType))
            {
                return InvokeOptional.ToList(variable);
            }

            if (TypeFactory.IsDictionary(targetType))
            {
                return InvokeOptional.ToDictionary(variable);
            }

            if (targetType is { IsValueType: true, IsNullable: true })
            {
                return InvokeOptional.ToNullable(variable);
            }

            if (targetType.IsNullable)
            {
                return new MemberExpression(variable, "Value");
            }

            return variable;
        }

        public static ValueExpression GetFrameworkTypeValueExpression(Type frameworkType, JsonElementExpression element, SerializationFormat format, CSharpType? serializationType)
        {
            if (frameworkType == typeof(ETag) ||
                frameworkType == typeof(Uri) ||
                frameworkType == typeof(ResourceIdentifier) ||
                frameworkType == typeof(ResourceType) ||
                frameworkType == typeof(ContentType) ||
                frameworkType == typeof(RequestMethod) ||
                frameworkType == typeof(AzureLocation))
            {
                return New.Instance(frameworkType, element.GetString());
            }

            if (frameworkType == typeof(IPAddress))
            {
                return new InvokeStaticMethodExpression(typeof(IPAddress), nameof(IPAddress.Parse), new[] { element.GetString() });
            }

            if (frameworkType == typeof(BinaryData))
            {
                return format is SerializationFormat.Bytes_Base64 or SerializationFormat.Bytes_Base64Url
                    ? BinaryDataExpression.FromBytes(element.GetBytesFromBase64(format.ToFormatSpecifier()))
                    : BinaryDataExpression.FromString(element.GetRawText());
            }

            if (IsCustomJsonConverterAdded(frameworkType) && serializationType is not null)
            {
                return InvokeJsonSerializerDeserializeMethod(element, serializationType);
            }

            if (frameworkType == typeof(JsonElement))
                return element.InvokeClone();
            if (frameworkType == typeof(object))
                return element.GetObject();
            if (frameworkType == typeof(bool))
                return element.GetBoolean();
            if (frameworkType == typeof(char))
                return element.GetChar();

            if (frameworkType == typeof(short))
                return element.GetInt16();
            if (frameworkType == typeof(int))
                return element.GetInt32();
            if (frameworkType == typeof(long))
                return element.GetInt64();
            if (frameworkType == typeof(float))
                return element.GetSingle();
            if (frameworkType == typeof(double))
                return element.GetDouble();
            if (frameworkType == typeof(decimal))
                return element.GetDecimal();
            if (frameworkType == typeof(string))
                return element.GetString();
            if (frameworkType == typeof(Guid))
                return element.GetGuid();
            if (frameworkType == typeof(byte[]))
                return element.GetBytesFromBase64(format.ToFormatSpecifier());

            if (frameworkType == typeof(DateTimeOffset))
            {
                return format == SerializationFormat.DateTime_Unix
                    ? DateTimeOffsetExpression.FromUnixTimeSeconds(element.GetInt64())
                    : element.GetDateTimeOffset(format.ToFormatSpecifier());
            }

            if (frameworkType == typeof(DateTime))
                return element.GetDateTime();
            if (frameworkType == typeof(TimeSpan))
            {
                if (format == SerializationFormat.Duration_Seconds)
                {
                    return TimeSpanExpression.FromSeconds(element.GetInt32());
                }

                if (format == SerializationFormat.Duration_Seconds_Float)
                {
                    return TimeSpanExpression.FromSeconds(element.GetDouble());
                }

                return element.GetTimeSpan(format.ToFormatSpecifier());
            }

            throw new NotSupportedException($"Framework type {frameworkType} is not supported");
        }

        private static ValueExpression InvokeJsonSerializerDeserializeMethod(JsonElementExpression element, CSharpType serializationType, ValueExpression? options = null)
        {
            var arguments = options is null
                ? new[] { element.GetRawText() }
                : new[] { element.GetRawText(), options };
            return new InvokeStaticMethodExpression(typeof(JsonSerializer), nameof(JsonSerializer.Deserialize), arguments, new[] { serializationType });
        }

        private static MethodBodyStatement InvokeJsonSerializerSerializeMethod(ValueExpression writer, ValueExpression value)
            => new InvokeStaticMethodStatement(typeof(JsonSerializer), nameof(JsonSerializer.Serialize), new[] { writer, value });

        private static MethodBodyStatement InvokeJsonSerializerSerializeMethod(ValueExpression writer, ValueExpression value, ValueExpression options)
            => new InvokeStaticMethodStatement(typeof(JsonSerializer), nameof(JsonSerializer.Serialize), new[] { writer, value, options });

        private static bool IsCustomJsonConverterAdded(Type type)
            => type.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonConverterAttribute));

        public static bool CollectionItemRequiresNullCheckInSerialization(JsonSerialization serialization) =>
            serialization is { IsNullable: true } and JsonValueSerialization { Type.IsValueType: true } || // nullable value type, like int?
            serialization is JsonArraySerialization or JsonDictionarySerialization || // list or dictionary
            serialization is JsonValueSerialization jsonValueSerialization &&
            jsonValueSerialization is { Type: { IsValueType: false, IsFrameworkType: true } } && // framework reference type, e.g. byte[]
            jsonValueSerialization.Type.FrameworkType != typeof(string) && // excluding string, because JsonElement.GetString() can handle null
            jsonValueSerialization.Type.FrameworkType != typeof(byte[]); // excluding byte[], because JsonElement.GetBytesFromBase64() can handle null
    }
}
