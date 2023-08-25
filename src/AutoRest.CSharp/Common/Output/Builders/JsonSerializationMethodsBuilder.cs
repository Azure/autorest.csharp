// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
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
                new MethodSignature(nameof(IUtf8JsonSerializable.Write), null, null, MethodSignatureModifiers.None, null, null, new[]{utf8JsonWriter}, ExplicitInterface: typeof(IUtf8JsonSerializable)),
                WriteObject(new Utf8JsonWriterExpression(utf8JsonWriter), jsonObjectSerialization)
            );
        }

        public static Method BuildToRequestContent(MethodSignatureModifiers modifiers)
        {
            return new Method
            (
                new MethodSignature("ToRequestContent", null, "Convert into a Utf8JsonRequestContent.", modifiers, typeof(RequestContent), null, Array.Empty<Parameter>()),
                new[]
                {
                    Var("content", New.Utf8JsonRequestContent(), out var requestContent),
                    requestContent.JsonWriter.WriteObjectValue(This),
                    Return(requestContent)
                }
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

        private static IEnumerable<MethodBodyStatement> WriteProperties(Utf8JsonWriterExpression utf8JsonWriter, IEnumerable<JsonPropertySerialization> properties)
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
                else
                {
                    yield return WriteProperty(utf8JsonWriter, property);
                }
            }
        }

        private static MethodBodyStatement WriteProperty(Utf8JsonWriterExpression utf8JsonWriter, JsonPropertySerialization serialization)
        {
            var writeProperty = new[]
            {
                utf8JsonWriter.WritePropertyName(serialization.SerializedName),
                serialization.CustomSerializationMethodName is {} serializationMethodName
                    ? InvokeCustomSerializationMethod(serializationMethodName, utf8JsonWriter)
                    : SerializeExpression(utf8JsonWriter, serialization.ValueSerialization, serialization.Value)
            };

            if (serialization.SerializedType is not { IsNullable: true })
            {
                return InvokeOptional.WrapInIsDefined(serialization, writeProperty);
            }

            var nullSafeWriteProperty = new IfElseStatement(NotEqual(serialization.Value, Null), writeProperty, utf8JsonWriter.WriteNull(serialization.SerializedName));
            return InvokeOptional.WrapInIsDefined(serialization, nullSafeWriteProperty);
        }

        private static MethodBodyStatement SerializeAdditionalProperties(Utf8JsonWriterExpression utf8JsonWriter, JsonAdditionalPropertiesSerialization? additionalProperties)
        {
            if (additionalProperties is null)
            {
                return new MethodBodyStatement();
            }

            var additionalPropertiesExpression = new DictionaryExpression(additionalProperties.Value);
            return new ForeachStatement("item", additionalPropertiesExpression, out KeyValuePairExpression item)
            {
                utf8JsonWriter.WritePropertyName(item.Key),
                SerializeExpression(utf8JsonWriter, additionalProperties.ValueSerialization, item.Value)
            };
        }

        public static MethodBodyStatement SerializeExpression(Utf8JsonWriterExpression utf8JsonWriter, JsonSerialization? serialization, ValueExpression expression)
            => serialization switch
            {
                JsonArraySerialization array => SerializeArray(utf8JsonWriter, array, new EnumerableExpression(expression)),
                JsonDictionarySerialization dictionary => SerializeDictionary(utf8JsonWriter, dictionary, new DictionaryExpression(expression)),
                JsonValueSerialization value => SerializeValue(utf8JsonWriter, value, expression),
                _ => throw new NotSupportedException()
            };

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

        private static MethodBodyStatement SerializeValue(Utf8JsonWriterExpression utf8JsonWriter, JsonValueSerialization valueSerialization, ValueExpression value)
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
                if (valueSerialization.Format == SerializationFormat.DateTime_Unix)
                {
                    return utf8JsonWriter.WriteNumberValue(value, valueSerialization.Format.ToFormatSpecifier());
                }

                var format = valueSerialization.Format.ToFormatSpecifier();
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
                if (valueSerialization.Format is SerializationFormat.Bytes_Base64 or SerializationFormat.Bytes_Base64Url)
                {
                    return utf8JsonWriter.WriteBase64StringValue(new BinaryDataExpression(value).ToArray(), valueSerialization.Format.ToFormatSpecifier());
                }

                return new IfElsePreprocessorDirective
                (
                    "NET6_0_OR_GREATER",
                    utf8JsonWriter.WriteRawValue(value),
                    InvokeJsonSerializerSerializeMethod(utf8JsonWriter, JsonDocumentExpression.Parse(value.InvokeToString()).RootElement)
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
                ? new IfStatement(Equal(value, Null)) {utf8JsonWriter.WriteNullValue(), Continue}
                : new MethodBodyStatement();

        public static Method BuildDeserialize(TypeDeclarationOptions declaration, JsonObjectSerialization serialization)
        {
            var methodName = $"Deserialize{declaration.Name}";
            var element = new Parameter("element", null, typeof(JsonElement), null, Validation.None, null);
            return new Method
            (
                new MethodSignature(methodName, null, null, MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static, serialization.Type, null, new[]{element}),
                BuildDeserializeBody(element, serialization).ToArray()
            );
        }

        public static Method BuildFromResponse(SerializableObjectType type, MethodSignatureModifiers modifiers)
        {
            var fromResponse = new Parameter("response", "The response to deserialize the model from.", new CSharpType(typeof(Response)), null, Validation.None, null);
            return new Method
            (
                new MethodSignature("FromResponse", null, "Deserializes the model from a raw response.", modifiers, type.Type, null, new[]{fromResponse}),
                new MethodBodyStatement[]
                {
                    UsingVar("document", JsonDocumentExpression.Parse(new ResponseExpression(fromResponse).Content), out var document),
                    Return(SerializableObjectTypeExpression.Deserialize(type, document.RootElement))
                }
            );
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
            var propertyVariables = new Dictionary<JsonPropertySerialization, ObjectPropertyVariable>();

            CollectPropertiesForDeserialization(propertyVariables, serialization.Properties);

            var additionalProperties = serialization.AdditionalProperties;
            if (additionalProperties != null)
            {
                var propertyDeclaration = new CodeWriterDeclaration(additionalProperties.SerializationConstructorParameterName);
                propertyVariables.Add(additionalProperties, new ObjectPropertyVariable(propertyDeclaration, additionalProperties.ValueType));
            }

            bool isThisTheDefaultDerivedType = serialization.Type.Equals(serialization.Discriminator?.DefaultObjectType.Type);

            foreach (var variable in propertyVariables)
            {
                if (serialization.Discriminator?.SerializedName == variable.Key.SerializedName &&
                    isThisTheDefaultDerivedType &&
                    serialization.Discriminator.Value is not null &&
                    (!serialization.Discriminator.Property.ValueType.IsEnum || serialization.Discriminator.Property.ValueType.Implementation is EnumType { IsExtensible: true }))
                {
                    var defaultValue = serialization.Discriminator.Value.Value.Value?.ToString();
                    yield return new DeclareVariableStatement(variable.Value.Type, variable.Value.Declaration, Literal(defaultValue));
                }
                else
                {
                    yield return new DeclareVariableStatement(variable.Value.Type, variable.Value.Declaration, Snippets.Default);
                }
            }

            var dictionaryVariable = new CodeWriterDeclaration("additionalPropertiesDictionary");
            var objAdditionalProperties = serialization.AdditionalProperties;
            if (objAdditionalProperties != null)
            {
                yield return new DeclareVariableStatement(objAdditionalProperties.Type, dictionaryVariable, New.Instance(objAdditionalProperties.Type));
            }

            var shouldTreatEmptyStringAsNull = Configuration.ModelsToTreatEmptyStringAsNull.Contains(serialization.Type.Name);
            yield return new ForeachStatement("property", element.EnumerateObject(), out var property)
            {
                DeserializeIntoObjectProperties(serialization.Properties, objAdditionalProperties?.ValueSerialization, new JsonPropertyExpression(property), new DictionaryExpression(dictionaryVariable), propertyVariables, shouldTreatEmptyStringAsNull)
            };

            if (objAdditionalProperties != null)
            {
                yield return new AssignValueStatement(propertyVariables[objAdditionalProperties].Declaration, dictionaryVariable);
            }

            var parameterValues = propertyVariables.ToDictionary(v => v.Key.SerializationConstructorParameterName, v => GetOptional(v.Key, v.Value));
            var parameters = serialization.ConstructorParameters
                .Select(p => parameterValues[p.Name])
                .ToArray();

            yield return Return(New.Instance(serialization.Type, parameters));
        }

        private static MethodBodyStatement DeserializeIntoObjectProperties(IEnumerable<JsonPropertySerialization> propertySerializations, JsonSerialization? additionalPropertiesSerialization, JsonPropertyExpression jsonProperty, DictionaryExpression dictionary, IReadOnlyDictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, bool shouldTreatEmptyStringAsNull)
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

        private static MethodBodyStatement DeserializeIntoObjectProperties(IEnumerable<JsonPropertySerialization> propertySerializations, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, bool shouldTreatEmptyStringAsNull)
            => propertySerializations
                .Where(p => !p.ShouldSkipDeserialization)
                .Select(p => new IfStatement(jsonProperty.NameEquals(p.SerializedName))
                {
                    DeserializeIntoObjectProperty(p, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull).AsStatement()
                })
                .ToArray();

        private static IEnumerable<MethodBodyStatement> DeserializeIntoObjectProperty(JsonPropertySerialization jsonPropertySerialization, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            yield return CreatePropertyNullCheckStatement(jsonPropertySerialization, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull);

            if (jsonPropertySerialization.CustomDeserializationMethodName is {} deserializationMethodName)
            {
                // write the deserialization hook
                yield return InvokeCustomDeserializationMethod(deserializationMethodName, jsonProperty, propertyVariables[jsonPropertySerialization].Declaration);
            }
            else if (jsonPropertySerialization.ValueSerialization is not null)
            {
                // Reading a property value
                yield return DeserializeValue(jsonPropertySerialization.ValueSerialization, jsonProperty.Value, out var value);
                yield return Assign(propertyVariables[jsonPropertySerialization].Declaration, value);
            }
            else if (jsonPropertySerialization.PropertySerializations is not null)
            {
                // Reading a nested object
                yield return new ForeachStatement("property", jsonProperty.Value.EnumerateObject(), out var nestedItemVariable)
                {
                    DeserializeIntoObjectProperties(jsonPropertySerialization.PropertySerializations, new JsonPropertyExpression(nestedItemVariable), propertyVariables, shouldTreatEmptyStringAsNull)
                };
            }
            else
            {
                throw new InvalidOperationException($"Either {nameof(JsonPropertySerialization.ValueSerialization)} must not be null or {nameof(JsonPropertySerialization.PropertySerializations)} must not be null.");
            }

            yield return Continue;
        }

        private static MethodBodyStatement CreatePropertyNullCheckStatement(JsonPropertySerialization jsonPropertySerialization, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            if (jsonPropertySerialization.CustomSerializationMethodName is not null)
            {
                // if we have the deserialization hook here, we do not need to do any check, all these checks should be taken care of by the hook
                return new MethodBodyStatement();
            }

            if (jsonPropertySerialization.SerializedType?.IsNullable == true)
            {
                return new IfStatement(GetCheckEmptyPropertyValueExpression(jsonProperty, jsonPropertySerialization, shouldTreatEmptyStringAsNull))
                {
                    Assign(propertyVariables[jsonPropertySerialization].Declaration, Null),
                    Continue
                };
            }

            if (!jsonPropertySerialization.IsRequired &&
                jsonPropertySerialization.SerializedType?.Equals(typeof(JsonElement)) != true && // JsonElement handles nulls internally
                jsonPropertySerialization.SerializedType?.Equals(typeof(string)) != true) //https://github.com/Azure/autorest.csharp/issues/922
            {
                if (jsonPropertySerialization.PropertySerializations is null)
                {
                    return new IfStatement(GetCheckEmptyPropertyValueExpression(jsonProperty, jsonPropertySerialization, shouldTreatEmptyStringAsNull))
                    {
                        Continue
                    };
                }

                return new IfStatement(GetCheckEmptyPropertyValueExpression(jsonProperty, jsonPropertySerialization, shouldTreatEmptyStringAsNull))
                {
                    jsonProperty.ThrowNonNullablePropertyIsNull(),
                    Continue
                };
            }

            return new MethodBodyStatement();
        }

        private static ValueExpression GetCheckEmptyPropertyValueExpression(JsonPropertyExpression jsonProperty, JsonPropertySerialization jsonPropertySerialization, bool shouldTreatEmptyStringAsNull)
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

            return Or(jsonElement.ValueKindEqualsNull(), And(jsonElement.ValueKindEqualsString(), Equal(jsonElement.GetString().Length, new FormattableStringToExpression($"0"))));

        }

        /// Collects a list of properties being read from all level of object hierarchy
        private static void CollectPropertiesForDeserialization(IDictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, IEnumerable<JsonPropertySerialization> jsonProperties)
        {
            foreach (JsonPropertySerialization jsonProperty in jsonProperties.Where(p => !p.ShouldSkipDeserialization))
            {
                if (jsonProperty.SerializedType != null)
                {
                    var propertyDeclaration = new CodeWriterDeclaration(jsonProperty.SerializedName.ToVariableName());

                    var type = jsonProperty.SerializedType;
                    if (!jsonProperty.IsRequired)
                    {
                        if (type.IsFrameworkType && type.FrameworkType == typeof(Nullable<>))
                        {
                            type = new CSharpType(type.Arguments[0].FrameworkType);
                        }
                        type = new CSharpType(typeof(Optional<>), type);
                    }

                    propertyVariables.Add(jsonProperty, new ObjectPropertyVariable(propertyDeclaration, type));
                }
                else if (jsonProperty.PropertySerializations != null)
                {
                    CollectPropertiesForDeserialization(propertyVariables, jsonProperty.PropertySerializations);
                }
            }
        }

        public static MethodBodyStatement BuildDeserializationForMethods(JsonSerialization serialization, bool async, ValueExpression? variable, ResponseExpression response, bool isBinaryData)
        {
            if (isBinaryData)
            {
                var callFromStream = BinaryDataExpression.FromStream(response, async);
                var variableExpression = variable is not null ? new BinaryDataExpression(variable) : null;
                return AssignOrReturn(variableExpression, callFromStream);
            }

            var declareDocument = UsingVar("document", JsonDocumentExpression.Parse(response, async), out var document);
            var deserializeValueBlock = DeserializeValue(serialization, document.RootElement, out var value);

            if (!serialization.IsNullable)
            {
                return new[]{declareDocument, deserializeValueBlock, AssignOrReturn(variable, value)};
            }

            return new MethodBodyStatement[]
            {
                declareDocument,
                new IfElseStatement
                (
                    document.RootElement.ValueKindEqualsNull(),
                    AssignOrReturn(variable, Null),
                    new[]{deserializeValueBlock, AssignOrReturn(variable, value)}
                )
            };
        }

        public static MethodBodyStatement DeserializeValue(JsonSerialization serialization, JsonElementExpression element, out ValueExpression value)
        {
            switch (serialization)
            {
                case JsonArraySerialization jsonArray:
                    var array = new CodeWriterDeclaration("array");
                    value = array;

                    return new MethodBodyStatement[]
                    {
                        new DeclareVariableStatement(jsonArray.ImplementationType, array, New.Instance(jsonArray.ImplementationType)),
                        new ForeachStatement("item", element.EnumerateArray(), out var item)
                        {
                            DeserializeArrayItem(jsonArray.ValueSerialization, array, new JsonElementExpression(item))
                        }
                    };

                case JsonDictionarySerialization jsonDictionary:
                    var dictionary = new CodeWriterDeclaration("dictionary");
                    value = dictionary;

                    return new MethodBodyStatement[]
                    {
                        new DeclareVariableStatement(jsonDictionary.Type, dictionary, New.Instance(jsonDictionary.Type)),
                        new ForeachStatement("property", element.EnumerateObject(), out var property)
                        {
                            DeserializeDictionaryValue(jsonDictionary.ValueSerialization, new DictionaryExpression(value), new JsonPropertyExpression(property))
                        }
                    };

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

        private static MethodBodyStatement DeserializeArrayItem(JsonSerialization serialization, CodeWriterDeclaration arrayVariable, JsonElementExpression arrayItemVariable)
        {
            if (!CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                return Deserialize(serialization, arrayVariable, arrayItemVariable);
            }

            return new IfElseStatement(
                arrayItemVariable.ValueKindEqualsNull(),
                InvokeListAdd(arrayVariable, Null),
                Deserialize(serialization, arrayVariable, arrayItemVariable)
            );

            static MethodBodyStatement Deserialize(JsonSerialization jsonSerialization, CodeWriterDeclaration codeWriterDeclaration, JsonElementExpression jsonElementExpression)
                => new[]
                {
                    DeserializeValue(jsonSerialization, jsonElementExpression, out var value),
                    InvokeListAdd(codeWriterDeclaration, value)
                };
        }

        private static MethodBodyStatement DeserializeDictionaryValue(JsonSerialization serialization, DictionaryExpression dictionary, JsonPropertyExpression property)
        {
            var deserializeValueBlock = new[]
            {
                DeserializeValue(serialization, property.Value, out var value),
                dictionary.Add(property.Name, value)
            };

            if (CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                return new IfElseStatement
                (
                    property.Value.ValueKindEqualsNull(),
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
                    return New.Instance(resource.Type, new FormattableStringToExpression($"Client"), SerializableObjectTypeExpression.Deserialize(resourceDataType, element));

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

        private static ValueExpression GetOptional(PropertySerialization jsonPropertySerialization, ObjectPropertyVariable variable)
        {
            var targetType = jsonPropertySerialization.ValueType;
            var sourceType = variable.Type;
            if (!sourceType.IsFrameworkType || sourceType.FrameworkType != typeof(Optional<>))
            {
                return variable.Declaration;
            }

            if (TypeFactory.IsList(targetType))
            {
                return InvokeOptional.ToList(variable.Declaration);
            }

            if (TypeFactory.IsDictionary(targetType))
            {
                return InvokeOptional.ToDictionary(variable.Declaration);
            }

            if (targetType is { IsValueType: true, IsNullable: true })
            {
                return InvokeOptional.ToNullable(variable.Declaration);
            }

            if (targetType.IsNullable)
            {
                return new MemberExpression(variable.Declaration, "Value");
            }

            return variable.Declaration;
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
                return new InvokeStaticMethodExpression(typeof(IPAddress), nameof(IPAddress.Parse), new[]{ element.GetString() });
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
                return element.CallClone();
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
                    ? InvokeDateTimeOffsetFromUnixTimeSeconds(element.GetInt64())
                    : element.GetDateTimeOffset(format.ToFormatSpecifier());
            }

            if (frameworkType == typeof(DateTime))
                return element.GetDateTime();
            if (frameworkType == typeof(TimeSpan))
                return element.GetTimeSpan(format.ToFormatSpecifier());

            throw new NotSupportedException($"Framework type {frameworkType} is not supported");
        }

        private static MethodBodyStatement InvokeListAdd(ValueExpression list, ValueExpression value)
            => new InvokeInstanceMethodStatement(list, nameof(List<object>.Add), value);

        private static ValueExpression InvokeJsonSerializerDeserializeMethod(JsonElementExpression element, CSharpType serializationType, ValueExpression? options = null)
        {
            var arguments = options is null
                ? new[]{ element.GetRawText() }
                : new[]{ element.GetRawText(), options };
            return new InvokeStaticMethodExpression(typeof(JsonSerializer), nameof(JsonSerializer.Deserialize), arguments, new[] { serializationType });
        }

        private static MethodBodyStatement InvokeJsonSerializerSerializeMethod(ValueExpression writer, ValueExpression value)
            => new InvokeStaticMethodStatement(typeof(JsonSerializer), nameof(JsonSerializer.Serialize), new[]{writer, value});

        private static MethodBodyStatement InvokeJsonSerializerSerializeMethod(ValueExpression writer, ValueExpression value, ValueExpression options)
            => new InvokeStaticMethodStatement(typeof(JsonSerializer), nameof(JsonSerializer.Serialize), new[]{writer, value, options});

        private static bool IsCustomJsonConverterAdded(Type type)
            => type.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonConverterAttribute));

        public static bool CollectionItemRequiresNullCheckInSerialization(JsonSerialization serialization) =>
            serialization is { IsNullable: true } and JsonValueSerialization { Type: { IsValueType: true } } || // nullable value type, like int?
            serialization is JsonArraySerialization or JsonDictionarySerialization || // list or dictionary
            serialization is JsonValueSerialization jsonValueSerialization &&
            jsonValueSerialization is { Type: { IsValueType: false, IsFrameworkType: true } } && // framework reference type, e.g. byte[]
            jsonValueSerialization.Type.FrameworkType != typeof(string) && // excluding string, because JsonElement.GetString() can handle null
            jsonValueSerialization.Type.FrameworkType != typeof(byte[]); // excluding byte[], because JsonElement.GetBytesFromBase64() can handle null

        private readonly struct ObjectPropertyVariable
        {
            public ObjectPropertyVariable(CodeWriterDeclaration declaration, CSharpType type)
            {
                Declaration = declaration;
                Type = type;
            }

            public CodeWriterDeclaration Declaration { get; }
            public CSharpType Type { get; }
        }
    }
}
