// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using static AutoRest.CSharp.Output.Models.MethodBodyLines;
using static AutoRest.CSharp.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Output.Models
{
    internal static class JsonSerializationMethodsBuilder
    {
        public static Method BuildUtf8JsonSerializableWrite(JsonObjectSerialization jsonObjectSerialization)
        {
            var utf8JsonWriter = new Parameter("writer", null, typeof(Utf8JsonWriter), null, Validation.None, null);
            return new Method
            (
                new MethodSignature(nameof(IUtf8JsonSerializable.Write), null, null, MethodSignatureModifiers.None, null, null, new[]{utf8JsonWriter}, ExplicitInterface: typeof(IUtf8JsonSerializable)),
                new MethodBody(new[] { WriteObject(utf8JsonWriter, jsonObjectSerialization) })
            );
        }

        public static Method BuildToRequestContent(MethodSignatureModifiers modifiers)
        {
            return new Method
            (
                new MethodSignature("ToRequestContent", null, "Convert into a Utf8JsonRequestContent.", modifiers, typeof(RequestContent), null, Array.Empty<Parameter>()),
                new MethodBody(new MethodBodyStatement[]
                {
                    Declare.New(typeof(Utf8JsonRequestContent), "content", out var requestContent),
                    LineCall.Utf8JsonWriter.WriteObjectValue(new MemberReference(requestContent, nameof(Utf8JsonRequestContent.JsonWriter)), This),
                    Return(requestContent)
                })
            );
        }

        private static MethodBodyStatement WriteObject(ValueExpression utf8JsonWriter, JsonObjectSerialization serialization)
        {
            return new MethodBodyStatements
            (
                LineCall.Utf8JsonWriter.WriteStartObject(utf8JsonWriter),
                WritProperties(utf8JsonWriter, serialization.Properties).AsStatement(),
                SerializeAdditionalProperties(utf8JsonWriter, serialization.AdditionalProperties),
                LineCall.Utf8JsonWriter.WriteEndObject(utf8JsonWriter)
            );
        }

        public static IEnumerable<MethodBodyStatement> WritProperties(ValueExpression utf8JsonWriter, IEnumerable<JsonPropertySerialization> properties)
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
                    yield return LineCall.Utf8JsonWriter.WritePropertyName(utf8JsonWriter, property.SerializedName);
                    yield return LineCall.Utf8JsonWriter.WriteStartObject(utf8JsonWriter);
                    yield return WritProperties(utf8JsonWriter, property.PropertySerializations!).AsStatement();
                    yield return LineCall.Utf8JsonWriter.WriteEndObject(utf8JsonWriter);
                }
                else
                {
                    yield return WriteProperty(utf8JsonWriter, property);
                }
            }
        }

        private static MethodBodyStatement WriteProperty(ValueExpression utf8JsonWriter, JsonPropertySerialization property)
        {
            var propertyNameReference = new FormattableStringToExpression($"{property.PropertyName:I}");

            var writePropertyNameLine = LineCall.Utf8JsonWriter.WritePropertyName(utf8JsonWriter, property.SerializedName);
            var writePropertyValueBlock = property is { OptionalViaNullability: true, PropertyType: { IsNullable: true, IsValueType: true } }
                ? SerializeExpression(utf8JsonWriter, property.ValueSerialization, new MemberReference(propertyNameReference, "Value"))
                : SerializeExpression(utf8JsonWriter, property.ValueSerialization, propertyNameReference);

            MethodBodyStatement writeProperty = new MethodBodyStatements(writePropertyNameLine, writePropertyValueBlock);
            MethodBodyStatement writePropertyWithNullCheck = property.ValueType is { IsNullable: true }
                ? new IfElseStatement(IsNotNull(propertyNameReference), writeProperty, LineCall.Utf8JsonWriter.WriteNull(utf8JsonWriter, property.SerializedName))
                : writeProperty;

            if (property.IsRequired)
            {
                return writePropertyWithNullCheck;
            }

            return TypeFactory.IsCollectionType(property.PropertyType)
                ? new IfElseStatement(Call.Optional.IsCollectionDefined(propertyNameReference), writePropertyWithNullCheck, null)
                : new IfElseStatement(Call.Optional.IsDefined(propertyNameReference), writePropertyWithNullCheck, null);
        }

        private static MethodBodyStatement SerializeAdditionalProperties(ValueExpression utf8JsonWriter, JsonAdditionalPropertiesSerialization? additionalProperties)
        {
            if (additionalProperties is null)
            {
                return new MethodBodyStatement();
            }

            var itemVariable = new CodeWriterDeclaration("item");
            return new ForeachStatement(itemVariable, new FormattableStringToExpression($"{additionalProperties.PropertyName}"), new MethodBodyStatements(
                LineCall.Utf8JsonWriter.WritePropertyName(utf8JsonWriter, new MemberReference(itemVariable, nameof(KeyValuePair<string, string>.Key))),
                SerializeExpression(utf8JsonWriter, additionalProperties.ValueSerialization, new MemberReference(itemVariable, nameof(KeyValuePair<string, string>.Value))))
            );
        }

        public static MethodBodyStatement SerializeExpression(ValueExpression utf8JsonWriter, JsonSerialization? serialization, ValueExpression expression)
            => serialization switch
            {
                JsonArraySerialization array => SerializeArray(utf8JsonWriter, array, expression),
                JsonDictionarySerialization dictionary => SerializeDictionary(utf8JsonWriter, dictionary, expression),
                JsonValueSerialization value => SerializeValue(utf8JsonWriter, value, expression),
                _ => throw new NotSupportedException()
            };

        private static MethodBodyStatement SerializeArray(ValueExpression utf8JsonWriter, JsonArraySerialization arraySerialization, ValueExpression array)
        {
            var item = new CodeWriterDeclaration("item");
            return new MethodBodyStatements
            (
                LineCall.Utf8JsonWriter.WriteStartArray(utf8JsonWriter),
                new ForeachStatement(item, array, new MethodBodyStatements
                (
                    CheckCollectionItemForNull(utf8JsonWriter, arraySerialization.ValueSerialization, item),
                    SerializeExpression(utf8JsonWriter, arraySerialization.ValueSerialization, item))
                ),
                LineCall.Utf8JsonWriter.WriteEndArray(utf8JsonWriter)
            );
        }

        private static MethodBodyStatement SerializeDictionary(ValueExpression utf8JsonWriter, JsonDictionarySerialization dictionarySerialization, ValueExpression dictionary)
        {
            var keyValuePair = new CodeWriterDeclaration("item");
            var value = new MemberReference(keyValuePair, nameof(KeyValuePair<string, string>.Value));
            return new MethodBodyStatements
            (
                LineCall.Utf8JsonWriter.WriteStartObject(utf8JsonWriter),
                new ForeachStatement(keyValuePair, dictionary, new MethodBodyStatements
                (
                    LineCall.Utf8JsonWriter.WritePropertyName(utf8JsonWriter, new MemberReference(keyValuePair, nameof(KeyValuePair<string, string>.Key))),
                    CheckCollectionItemForNull(utf8JsonWriter, dictionarySerialization.ValueSerialization, value),
                    SerializeExpression(utf8JsonWriter, dictionarySerialization.ValueSerialization, value))
                ),
                LineCall.Utf8JsonWriter.WriteEndObject(utf8JsonWriter)
            );
        }

        private static MethodBodyStatement SerializeValue(ValueExpression utf8JsonWriter, JsonValueSerialization valueSerialization, ValueExpression value)
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
                        var declareSerializeOptions = DeclareJsonSerializerOptions(out var serializeOptions);
                        return new MethodBodyStatements(declareSerializeOptions, LineCall.JsonSerializer.Serialize(utf8JsonWriter, value, serializeOptions));
                    }

                    return LineCall.JsonSerializer.Serialize(utf8JsonWriter, value);

                case ObjectType:
                    return LineCall.Utf8JsonWriter.WriteObjectValue(utf8JsonWriter, value);

                case EnumType { IsIntValueType: true, IsExtensible: false } enumType:
                    return LineCall.Utf8JsonWriter.WriteNumberValue(utf8JsonWriter, new CastExpression(NullableValue(value, valueSerialization.Type), enumType.ValueType));

                case EnumType enumType:
                    return LineCall.Utf8JsonWriter.WriteStringValue(utf8JsonWriter, Call.Enum.ToString(NullableValue(value, valueSerialization.Type), enumType));
            }

            throw new NotSupportedException();
        }

        private static MethodBodyStatement SerializeFrameworkTypeValue(ValueExpression utf8JsonWriter, JsonValueSerialization valueSerialization, ValueExpression value, Type valueType)
        {
            if (valueType == typeof(JsonElement))
            {
                return LineCall.JsonElement.WriteTo(value, utf8JsonWriter);
            }

            if (valueType == typeof(Nullable<>))
            {
                valueType = valueSerialization.Type.Arguments[0].FrameworkType;
            }
            value = NullableValue(value, valueSerialization.Type);

            if (valueType == typeof(decimal) || valueType == typeof(double) || valueType == typeof(float) || valueType == typeof(long) || valueType == typeof(int) || valueType == typeof(short))
            {
                return LineCall.Utf8JsonWriter.WriteNumberValue(utf8JsonWriter, value);
            }

            if (valueType == typeof(object))
            {
                return LineCall.Utf8JsonWriter.WriteObjectValue(utf8JsonWriter, value);
            }

            if (valueType == typeof(string) || valueType == typeof(char) || valueType == typeof(Guid) || valueType == typeof(ResourceIdentifier) || valueType == typeof(ResourceType) || valueType == typeof(RequestMethod) || valueType == typeof(AzureLocation))
            {
                return LineCall.Utf8JsonWriter.WriteStringValue(utf8JsonWriter, value);
            }

            if (valueType == typeof(bool))
            {
                return LineCall.Utf8JsonWriter.WriteBooleanValue(utf8JsonWriter, value);
            }

            if (valueType == typeof(byte[]))
            {
                return LineCall.Utf8JsonWriter.WriteBase64StringValue(utf8JsonWriter, value, valueSerialization.Format.ToFormatSpecifier());
            }

            if (valueType == typeof(DateTimeOffset) || valueType == typeof(DateTime) || valueType == typeof(TimeSpan))
            {
                if (valueSerialization.Format == SerializationFormat.DateTime_Unix)
                {
                    return LineCall.Utf8JsonWriter.WriteNumberValue(utf8JsonWriter, value, valueSerialization.Format.ToFormatSpecifier());
                }

                var format = valueSerialization.Format.ToFormatSpecifier();
                return format is not null
                    ? LineCall.Utf8JsonWriter.WriteStringValue(utf8JsonWriter, value, format)
                    : LineCall.Utf8JsonWriter.WriteStringValue(utf8JsonWriter, value);
            }

            if (valueType == typeof(ETag) || valueType == typeof(ContentType) || valueType == typeof(IPAddress))
            {
                return LineCall.Utf8JsonWriter.WriteStringValue(utf8JsonWriter, Call.ToString(value));
            }

            if (valueType == typeof(Uri))
            {
                return LineCall.Utf8JsonWriter.WriteStringValue(utf8JsonWriter, new MemberReference(value, nameof(Uri.AbsoluteUri)));
            }

            if (valueType == typeof(BinaryData))
            {
                return new IfElsePreprocessorDirective
                (
                    "NET6_0_OR_GREATER",
                    LineCall.Utf8JsonWriter.WriteRawValue(utf8JsonWriter, value),
                    LineCall.JsonSerializer.Serialize(utf8JsonWriter, new MemberReference(Call.JsonDocument.Parse(Call.ToString(value)), "RootElement"))
                );
            }

            if (IsCustomJsonConverterAdded(valueType))
            {
                return LineCall.JsonSerializer.Serialize(utf8JsonWriter, value);
            }

            throw new NotSupportedException($"Framework type {valueType} serialization not supported");
        }

        private static MethodBodyStatement CheckCollectionItemForNull(ValueExpression utf8JsonWriter, JsonSerialization valueSerialization, ValueExpression value)
            => CollectionItemRequiresNullCheckInSerialization(valueSerialization)
                ? new IfElseStatement(IsNull(value), new MethodBodyStatements(LineCall.Utf8JsonWriter.WriteNullValue(utf8JsonWriter), Continue), null)
                : new MethodBodyStatement();

        private static ValueExpression NullableValue(ValueExpression value, CSharpType type)
            => type is { IsNullable: true, IsValueType: true } ? new MemberReference(value, "Value") : value;

        public static Method BuildDeserialize(TypeDeclarationOptions declaration, JsonObjectSerialization serialization)
        {
            var methodName = $"Deserialize{declaration.Name}";
            var element = new Parameter("element", null, typeof(JsonElement), null, Validation.None, null);
            return new Method
            (
                new MethodSignature(methodName, null, null, MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static, serialization.Type, null, new[]{element}),
                new MethodBody(BuildDeserializeBody(element, serialization).ToArray())
            );
        }

        public static Method BuildFromResponse(CSharpType returnType, MethodSignatureModifiers modifiers)
        {
            var fromResponse = new Parameter("response", "The response to deserialize the model from.", new CSharpType(typeof(Response)), null, Validation.None, null);
            return new Method
            (
                new MethodSignature("FromResponse", null, "Deserializes the model from a raw response.", modifiers, returnType, null, new[]{fromResponse}),
                new MethodBody(new MethodBodyStatement[]
                {
                    Declare.JsonDocument(Call.JsonDocument.Parse(new MemberReference(fromResponse, nameof(Response.Content))), out var document),
                    Return(Call.Static(null, $"Deserialize{returnType.Name}", new MemberReference(document, nameof(JsonDocument.RootElement))))
                })
            );
        }

        private static IEnumerable<MethodBodyStatement> BuildDeserializeBody(Parameter element, JsonObjectSerialization serialization)
        {
            if (!serialization.Type.IsValueType) // only return null for reference type (e.g. no enum)
            {
                yield return new IfElseStatement(Call.JsonElement.ValueKindEqualsNull(element), Return(Null), null);
            }

            var discriminator = serialization.Discriminator;
            if (discriminator is not null && discriminator.HasDescendants)
            {
                yield return new IfElseStatement
                (
                    Call.JsonElement.TryGetProperty(element, discriminator.SerializedName, out var discriminatorElement),
                    new SwitchStatement(Call.JsonElement.GetString(discriminatorElement), GetDiscriminatorCases(element, discriminator).ToArray()),
                    null
                );
            }

            if (discriminator is not null && !serialization.Type.HasParent && !serialization.Type.Equals(discriminator.DefaultObjectType.Type))
            {
                yield return Return(GetDeserializeImplementation(discriminator.DefaultObjectType.Type.Implementation, element, null));
            }
            else
            {
                yield return WriteObjectInitialization(element, serialization).AsStatement();
            }
        }

        private static IEnumerable<SwitchCase> GetDiscriminatorCases(ValueExpression element, ObjectTypeDiscriminator discriminator)
        {
            foreach (var implementation in discriminator.Implementations)
            {
                yield return new SwitchCaseLine(implementation.Key, Return(GetDeserializeImplementation(implementation.Type.Implementation, element, null)));
            }
        }

        private static IEnumerable<MethodBodyStatement> WriteObjectInitialization(ValueExpression element, JsonObjectSerialization serialization)
        {
            // this is the first level of object hierarchy
            // collect all properties and initialize the dictionary
            var propertyVariables = new Dictionary<JsonPropertySerialization, ObjectPropertyVariable>();

            CollectPropertiesForDeserialization(propertyVariables, serialization.Properties);

            var additionalProperties = serialization.AdditionalProperties;
            if (additionalProperties != null)
            {
                var propertyDeclaration = new CodeWriterDeclaration(additionalProperties.PropertyName.ToVariableName());
                propertyVariables.Add(additionalProperties, new ObjectPropertyVariable(propertyDeclaration, additionalProperties.PropertyType));
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
                    yield return new DeclareVariableLine(variable.Value.Type, variable.Value.Declaration, Literal(defaultValue));
                }
                else
                {
                    yield return new DeclareVariableLine(variable.Value.Type, variable.Value.Declaration, ValueExpressions.Default);
                }
            }

            var dictionaryVariable = new CodeWriterDeclaration("additionalPropertiesDictionary");
            var objAdditionalProperties = serialization.AdditionalProperties;
            if (objAdditionalProperties != null)
            {
                yield return new DeclareVariableLine(objAdditionalProperties.Type, dictionaryVariable, New(objAdditionalProperties.Type));
            }

            var itemVariable = new CodeWriterDeclaration("property");
            var shouldTreatEmptyStringAsNull = Configuration.ModelsToTreatEmptyStringAsNull.Contains(serialization.Type.Name);
            yield return new ForeachStatement(
                itemVariable,
                Call.JsonElement.EnumerateObject(element),
                DeserializeIntoObjectProperties(serialization.Properties, objAdditionalProperties?.ValueSerialization, itemVariable, dictionaryVariable, propertyVariables, shouldTreatEmptyStringAsNull).AsStatement());

            if (objAdditionalProperties != null)
            {
                yield return new SetValueLine(propertyVariables[objAdditionalProperties].Declaration, dictionaryVariable);
            }

            var parameterValues = propertyVariables.ToDictionary(v => v.Key.ParameterName, v => GetOptional(v.Key, v.Value));
            var parameters = serialization.Constructor.Parameters
                .Select(p => parameterValues[p.Name])
                .ToArray();

            yield return Return(New(serialization.Type, parameters));
        }

        private static IEnumerable<MethodBodyStatement> DeserializeIntoObjectProperties(IEnumerable<JsonPropertySerialization> propertySerializations, JsonSerialization? additionalPropertiesSerialization, CodeWriterDeclaration itemVariable, CodeWriterDeclaration dictionaryVariable, IReadOnlyDictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            yield return DeserializeIntoObjectProperties(propertySerializations, itemVariable, propertyVariables, shouldTreatEmptyStringAsNull).AsStatement();
            if (additionalPropertiesSerialization is null)
            {
                yield break;
            }

            var key = new MemberReference(itemVariable, "Name");
            yield return DeserializeValue(additionalPropertiesSerialization, new MemberReference(itemVariable, "Value"), out var value);
            yield return LineCall.Dictionary.Add(dictionaryVariable, key, value);
        }

        private static IEnumerable<MethodBodyStatement> DeserializeIntoObjectProperties(IEnumerable<JsonPropertySerialization> propertySerializations, CodeWriterDeclaration itemVariable, IReadOnlyDictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, bool shouldTreatEmptyStringAsNull)
            => propertySerializations
                .Where(p => !p.ShouldSkipDeserialization)
                .Select(p => new IfElseStatement(Call.JsonProperty.NameEquals(itemVariable, p.SerializedName), DeserializeIntoObjectProperty(p, itemVariable, propertyVariables, shouldTreatEmptyStringAsNull).AsStatement(), null));

        private static IEnumerable<MethodBodyStatement> DeserializeIntoObjectProperty(JsonPropertySerialization jsonPropertySerialization, CodeWriterDeclaration jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            if (jsonPropertySerialization.ValueType?.IsNullable == true)
            {
                yield return new IfElseStatement(GetCheckEmptyPropertyValueExpression(jsonProperty, jsonPropertySerialization, shouldTreatEmptyStringAsNull), new MethodBodyStatement[]
                {
                    new SetValueLine(propertyVariables[jsonPropertySerialization].Declaration, Null),
                    Continue
                }.AsStatement(), null);
            }
            else if (!jsonPropertySerialization.IsRequired &&
                     jsonPropertySerialization.ValueType?.Equals(typeof(JsonElement)) != true && // JsonElement handles nulls internally
                     jsonPropertySerialization.ValueType?.Equals(typeof(string)) != true) //https://github.com/Azure/autorest.csharp/issues/922
            {
                if (Configuration.AzureArm && jsonPropertySerialization.ValueType?.Equals(typeof(Uri)) == true)
                {
                    yield return new IfElseStatement(GetCheckEmptyPropertyValueExpression(jsonProperty, jsonPropertySerialization, shouldTreatEmptyStringAsNull), new MethodBodyStatement[]
                    {
                        new SetValueLine(propertyVariables[jsonPropertySerialization].Declaration, Null),
                        Continue
                    }.AsStatement(), null);
                }
                else
                {
                    yield return new IfElseStatement(GetCheckEmptyPropertyValueExpression(jsonProperty, jsonPropertySerialization, shouldTreatEmptyStringAsNull), new MethodBodyStatement[]
                    {
                        LineCall.JsonProperty.ThrowNonNullablePropertyIsNull(jsonProperty),
                        Continue
                    }.AsStatement(), null);
                }
            }

            if (jsonPropertySerialization.ValueSerialization is not null)
            {
                // Reading a property value
                yield return DeserializeValue(jsonPropertySerialization.ValueSerialization, new MemberReference(jsonProperty, "Value"), out var value);
                yield return new SetValueLine(propertyVariables[jsonPropertySerialization].Declaration, value);
            }
            else if (jsonPropertySerialization.PropertySerializations is not null)
            {
                // Reading a nested object
                var nestedItemVariable = new CodeWriterDeclaration("property");
                yield return new ForeachStatement(
                    nestedItemVariable,
                    Call.JsonElement.EnumerateObject(new MemberReference(jsonProperty, "Value")),
                    DeserializeIntoObjectProperties(jsonPropertySerialization.PropertySerializations, nestedItemVariable, propertyVariables, shouldTreatEmptyStringAsNull).AsStatement()
                );
            }
            else
            {
                throw new InvalidOperationException($"Either {nameof(JsonPropertySerialization.ValueSerialization)} must not be null or {nameof(JsonPropertySerialization.PropertySerializations)} must not be null.");
            }

            yield return Continue;
        }

        private static ValueExpression GetCheckEmptyPropertyValueExpression(CodeWriterDeclaration jsonProperty, JsonPropertySerialization jsonPropertySerialization, bool shouldTreatEmptyStringAsNull)
        {
            var jsonElement = new MemberReference(jsonProperty, "Value");
            if (!shouldTreatEmptyStringAsNull)
            {
                return Call.JsonElement.ValueKindEqualsNull(jsonElement);
            }

            if (jsonPropertySerialization.ValueSerialization is JsonValueSerialization { Type.IsFrameworkType: true } valueSerialization)
            {
                return Configuration.IntrinsicTypesToTreatEmptyStringAsNull.Contains(valueSerialization.Type.FrameworkType.Name)
                    ? Or(Call.JsonElement.ValueKindEqualsNull(jsonElement), And(Call.JsonElement.ValueKindEqualsString(jsonElement), Call.JsonElement.GetString(jsonElement)))
                    : Call.JsonElement.ValueKindEqualsNull(jsonElement);
            }

            return Call.JsonElement.ValueKindEqualsNull(jsonElement);

        }

        /// Collects a list of properties being read from all level of object hierarchy
        private static void CollectPropertiesForDeserialization(IDictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, IEnumerable<JsonPropertySerialization> jsonProperties)
        {
            foreach (JsonPropertySerialization jsonProperty in jsonProperties.Where(p => !p.ShouldSkipDeserialization))
            {
                if (jsonProperty.ValueType != null)
                {
                    var propertyDeclaration = new CodeWriterDeclaration(jsonProperty.SerializedName.ToVariableName());

                    var type = jsonProperty.ValueType;
                    if (!jsonProperty.IsRequired)
                    {
                        if (type.IsFrameworkType && type.FrameworkType == typeof(Nullable<>))
                            type = new CSharpType(type.Arguments[0].FrameworkType);
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

        public static MethodBodyStatement BuildDeserializationForMethods(JsonSerialization serialization, bool async, CodeWriterDeclaration? variable, ValueExpression response, bool isBinaryData)
        {
            if (isBinaryData)
            {
                var callFromStream = Call.BinaryData.FromStream(response, async);
                return variable is not null ? new SetValueLine(variable, callFromStream) : new ReturnValueLine(callFromStream);
            }

            var declareDocument = Declare.JsonDocument(Call.JsonDocument.Parse(response, async), out var document);
            var deserializeValueBlock = DeserializeValue(serialization, Call.JsonDocument.GetRootElement(document), out var value);
            MethodBodyLine setOrReturnValue = variable is not null ? new SetValueLine(variable, value) : new ReturnValueLine(value);

            if (!serialization.IsNullable)
            {
                return new MethodBodyStatements(declareDocument, deserializeValueBlock, setOrReturnValue);
            }

            return new MethodBodyStatements(declareDocument, new IfElseStatement
            (
                Call.JsonElement.ValueKindEqualsNull(new MemberReference(document, nameof(JsonDocument.RootElement))),
                variable is not null ? new SetValueLine(variable, Null) : new ReturnValueLine(Null),
                new MethodBodyStatements(deserializeValueBlock, setOrReturnValue)
            ));
        }

        public static MethodBodyStatement DeserializeValue(JsonSerialization serialization, ValueExpression element, out ValueExpression value)
        {
            switch (serialization)
            {
                case JsonArraySerialization jsonArray:
                    var array = new CodeWriterDeclaration("array");
                    var item = new CodeWriterDeclaration("item");
                    value = array;

                    var declareListVariable = new DeclareVariableLine(jsonArray.ImplementationType, array, New(jsonArray.ImplementationType));
                    var iterateOverJsonArray = new ForeachStatement(item, Call.JsonElement.EnumerateArray(element), DeserializeArrayItem(jsonArray.ValueSerialization, array, item));
                    return new MethodBodyStatements(declareListVariable, iterateOverJsonArray);

                case JsonDictionarySerialization jsonDictionary:
                    var dictionary = new CodeWriterDeclaration("dictionary");
                    var property = new CodeWriterDeclaration("property");
                    value = dictionary;

                    var declareDictionaryVariable = new DeclareVariableLine(jsonDictionary.Type, dictionary, New(jsonDictionary.Type));
                    var iterateOverJsonObject = new ForeachStatement(property, Call.JsonElement.EnumerateObject(element), DeserializeDictionaryValue(jsonDictionary.ValueSerialization, dictionary, property));

                    return new MethodBodyStatements(declareDictionaryVariable, iterateOverJsonObject);

                case JsonValueSerialization { Options: JsonSerializationOptions.UseManagedServiceIdentityV3 } valueSerialization:
                    var declareSerializeOptions = DeclareJsonSerializerOptions(out var serializeOptions);
                    value = GetDeserializeValueExpression(element, valueSerialization.Type, valueSerialization.Format, serializeOptions);
                    return declareSerializeOptions;

                case JsonValueSerialization valueSerialization:
                    value = GetDeserializeValueExpression(element, valueSerialization.Type, valueSerialization.Format);
                    return new MethodBodyStatement();

                default:
                    throw new InvalidOperationException($"{serialization.GetType()} is not supported.");
            }
        }

        private static MethodBodyStatement DeserializeArrayItem(JsonSerialization serialization, CodeWriterDeclaration arrayVariable, CodeWriterDeclaration arrayItemVariable)
        {
            var deserializeValueBlock = DeserializeValue(serialization, arrayItemVariable, out var value);
            var addValueLine = LineCall.List.Add(arrayVariable, value);

            if (CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                return new IfElseStatement
                (
                    Call.JsonElement.ValueKindEqualsNull(arrayItemVariable),
                    LineCall.List.Add(arrayVariable, Null),
                    new MethodBodyStatements(deserializeValueBlock, addValueLine)
                );
            }

            return new MethodBodyStatements(deserializeValueBlock, addValueLine);
        }

        private static MethodBodyStatement DeserializeDictionaryValue(JsonSerialization serialization, CodeWriterDeclaration dictionaryVariable, CodeWriterDeclaration itemVariable)
        {
            var key = new MemberReference(itemVariable, "Name");

            var deserializeValueBlock = DeserializeValue(serialization, new MemberReference(itemVariable, "Value"), out var value);
            var addValueLine = LineCall.Dictionary.Add(dictionaryVariable, key, value);

            if (CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                return new IfElseStatement
                (
                    Call.JsonElement.ValueKindEqualsNull(new MemberReference(itemVariable, "Value")),
                    LineCall.Dictionary.Add(dictionaryVariable, key, Null),
                    new MethodBodyStatements(deserializeValueBlock, addValueLine)
                );
            }

            return new MethodBodyStatements(deserializeValueBlock, addValueLine);
        }

        public static ValueExpression GetDeserializeValueExpression(ValueExpression element, CSharpType serializationType, SerializationFormat serializationFormat = SerializationFormat.Default, ValueExpression? serializerOptions = null)
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

        public static ValueExpression GetDeserializeImplementation(TypeProvider implementation, ValueExpression element, ValueExpression? serializerOptions)
        {
            switch (implementation)
            {
                case SystemObjectType systemObjectType when IsCustomJsonConverterAdded(systemObjectType.SystemType):
                    return Call.JsonSerializer.Deserialize(element, implementation.Type, serializerOptions);

                case Resource { ResourceData: SerializableObjectType { IncludeDeserializer: true } resourceDataType } resource:
                    return New(resource.Type, new FormattableStringToExpression($"Client"), Call.Static(resourceDataType.Type, $"Deserialize{resourceDataType.Declaration.Name}", element));

                case MgmtObjectType mgmtObjectType when TypeReferenceTypeChooser.HasMatch(mgmtObjectType.ObjectSchema):
                    return Call.JsonSerializer.Deserialize(element, implementation.Type);

                case SerializableObjectType { IncludeDeserializer: true } type:
                    return Call.Static(type.Type, $"Deserialize{type.Declaration.Name}", element);

                case EnumType clientEnum:
                    var value = GetFrameworkTypeValueExpression(clientEnum.ValueType.FrameworkType, element, SerializationFormat.Default, null);
                    return clientEnum.IsExtensible ? New(clientEnum.Type, value) : Call.ToEnum(clientEnum.Type, value);

                default:
                    throw new NotSupportedException($"No deserialization logic exists for {implementation.Declaration.Name}");
            }
        }

        private static ValueExpression GetOptional(JsonPropertySerialization jsonPropertySerialization, ObjectPropertyVariable variable)
        {
            var targetType = jsonPropertySerialization.PropertyType;
            var sourceType = variable.Type;
            if (!sourceType.IsFrameworkType || sourceType.FrameworkType != typeof(Optional<>))
            {
                return variable.Declaration;
            }

            if (TypeFactory.IsList(targetType))
            {
                return Call.Optional.ToList(variable.Declaration);
            }

            if (TypeFactory.IsDictionary(targetType))
            {
                return Call.Optional.ToDictionary(variable.Declaration);
            }

            if (targetType is { IsValueType: true, IsNullable: true })
            {
                return Call.Optional.ToNullable(variable.Declaration);
            }

            if (targetType.IsNullable)
            {
                return new MemberReference(variable.Declaration, "Value");
            }

            return variable.Declaration;
        }

        public static ValueExpression GetFrameworkTypeValueExpression(Type frameworkType, ValueExpression element, SerializationFormat format, CSharpType? serializationType)
        {
            if (frameworkType == typeof(ETag) ||
                frameworkType == typeof(Uri) ||
                frameworkType == typeof(ResourceIdentifier) ||
                frameworkType == typeof(ResourceType) ||
                frameworkType == typeof(ContentType) ||
                frameworkType == typeof(RequestMethod) ||
                frameworkType == typeof(AzureLocation))
            {
                return New(frameworkType, Call.JsonElement.GetString(element));
            }

            if (frameworkType == typeof(IPAddress))
            {
                return Call.Static(typeof(IPAddress), nameof(IPAddress.Parse), Call.JsonElement.GetString(element));
            }

            if (frameworkType == typeof(BinaryData))
            {
                return Call.BinaryData.FromString(Call.JsonElement.GetRawText(element));
            }

            if (IsCustomJsonConverterAdded(frameworkType) && serializationType is not null)
            {
                return Call.JsonSerializer.Deserialize(element, serializationType);
            }

            if (frameworkType == typeof(JsonElement))
                return Call.JsonElement.Clone(element);
            if (frameworkType == typeof(object))
                return Call.JsonElement.GetObject(element);
            if (frameworkType == typeof(bool))
                return Call.JsonElement.GetBoolean(element);
            if (frameworkType == typeof(char))
                return Call.JsonElement.GetChar(element);

            if (frameworkType == typeof(short))
                return Call.JsonElement.GetInt16(element);
            if (frameworkType == typeof(int))
                return Call.JsonElement.GetInt32(element);
            if (frameworkType == typeof(long))
                return Call.JsonElement.GetInt64(element);
            if (frameworkType == typeof(float))
                return Call.JsonElement.GetSingle(element);
            if (frameworkType == typeof(double))
                return Call.JsonElement.GetDouble(element);
            if (frameworkType == typeof(decimal))
                return Call.JsonElement.GetDecimal(element);
            if (frameworkType == typeof(string))
                return Call.JsonElement.GetString(element);
            if (frameworkType == typeof(Guid))
                return Call.JsonElement.GetGuid(element);
            if (frameworkType == typeof(byte[]))
                return Call.JsonElement.GetBytesFromBase64(element, format.ToFormatSpecifier());
            if (frameworkType == typeof(DateTimeOffset))
                return Call.JsonElement.GetDateTimeOffset(element, format.ToFormatSpecifier());
            if (frameworkType == typeof(DateTime))
                return Call.JsonElement.GetDateTime(element);
            if (frameworkType == typeof(TimeSpan))
                return Call.JsonElement.GetTimeSpan(element, format.ToFormatSpecifier());

            throw new NotSupportedException($"Framework type {frameworkType} is not supported");
        }

        private static DeclareVariableLine DeclareJsonSerializerOptions(out CodeWriterDeclaration serializeOptions)
        {
            serializeOptions = new CodeWriterDeclaration("serializeOptions");
            var properties = new Dictionary<string, ValueExpression>
            {
                [nameof(JsonSerializerOptions.Converters)] = new CollectionInitializerExpression(New(typeof(ManagedServiceIdentityTypeV3Converter)))
            };
            return new DeclareVariableLine(null, serializeOptions, New(typeof(JsonSerializerOptions), properties));
        }

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
