// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
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
                new MethodBody(new[] { WriteObject(new Utf8JsonWriterExpression(utf8JsonWriter), jsonObjectSerialization) })
            );
        }

        public static Method BuildToRequestContent(MethodSignatureModifiers modifiers)
        {
            return new Method
            (
                new MethodSignature("ToRequestContent", null, "Convert into a Utf8JsonRequestContent.", modifiers, typeof(RequestContent), null, Array.Empty<Parameter>()),
                new MethodBody(new MethodBodyStatement[]
                {
                    New("content", out Utf8JsonRequestContentExpression requestContent),
                    requestContent.JsonWriter.WriteObjectValue(This),
                    Return(requestContent)
                })
            );
        }

        private static MethodBodyStatement WriteObject(Utf8JsonWriterExpression utf8JsonWriter, JsonObjectSerialization serialization)
        {
            return new MethodBodyStatements
            (
                utf8JsonWriter.WriteStartObject(),
                WritProperties(utf8JsonWriter, serialization.Properties).AsStatement(),
                SerializeAdditionalProperties(utf8JsonWriter, serialization.AdditionalProperties),
                utf8JsonWriter.WriteEndObject()
            );
        }

        public static IEnumerable<MethodBodyStatement> WritProperties(Utf8JsonWriterExpression utf8JsonWriter, IEnumerable<JsonPropertySerialization> properties)
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
                    yield return WritProperties(utf8JsonWriter, property.PropertySerializations!).AsStatement();
                    yield return utf8JsonWriter.WriteEndObject();
                }
                else
                {
                    yield return WriteProperty(utf8JsonWriter, property);
                }
            }
        }

        private static MethodBodyStatement WriteProperty(Utf8JsonWriterExpression utf8JsonWriter, JsonPropertySerialization property)
        {
            var propertyNameReference = new FormattableStringToExpression($"{property.PropertyName:I}");

            var writePropertyNameLine = utf8JsonWriter.WritePropertyName(property.SerializedName);
            var writePropertyValueBlock = property is { OptionalViaNullability: true, PropertyType: { IsNullable: true, IsValueType: true } }
                ? SerializeExpression(utf8JsonWriter, property.ValueSerialization, new MemberReference(propertyNameReference, "Value"))
                : SerializeExpression(utf8JsonWriter, property.ValueSerialization, propertyNameReference);

            MethodBodyStatement writeProperty = new MethodBodyStatements(writePropertyNameLine, writePropertyValueBlock);
            MethodBodyStatement writePropertyWithNullCheck = property.ValueType is { IsNullable: true }
                ? new IfElseStatement(IsNotNull(propertyNameReference), writeProperty, utf8JsonWriter.WriteNull(property.SerializedName))
                : writeProperty;

            if (property.IsRequired)
            {
                return writePropertyWithNullCheck;
            }

            return TypeFactory.IsCollectionType(property.PropertyType)
                ? new IfElseStatement(Call.Optional.IsCollectionDefined(propertyNameReference), writePropertyWithNullCheck, null)
                : new IfElseStatement(Call.Optional.IsDefined(propertyNameReference), writePropertyWithNullCheck, null);
        }

        private static MethodBodyStatement SerializeAdditionalProperties(Utf8JsonWriterExpression utf8JsonWriter, JsonAdditionalPropertiesSerialization? additionalProperties)
        {
            if (additionalProperties is null)
            {
                return new MethodBodyStatement();
            }

            var itemVariable = new CodeWriterDeclaration("item");
            return new ForeachStatement(itemVariable, new FormattableStringToExpression($"{additionalProperties.PropertyName}"), new MethodBodyStatements(
                utf8JsonWriter.WritePropertyName(new MemberReference(itemVariable, nameof(KeyValuePair<string, string>.Key))),
                SerializeExpression(utf8JsonWriter, additionalProperties.ValueSerialization, new MemberReference(itemVariable, nameof(KeyValuePair<string, string>.Value))))
            );
        }

        public static MethodBodyStatement SerializeExpression(Utf8JsonWriterExpression utf8JsonWriter, JsonSerialization? serialization, ValueExpression expression)
            => serialization switch
            {
                JsonArraySerialization array => SerializeArray(utf8JsonWriter, array, expression),
                JsonDictionarySerialization dictionary => SerializeDictionary(utf8JsonWriter, dictionary, expression),
                JsonValueSerialization value => SerializeValue(utf8JsonWriter, value, expression),
                _ => throw new NotSupportedException()
            };

        private static MethodBodyStatement SerializeArray(Utf8JsonWriterExpression utf8JsonWriter, JsonArraySerialization arraySerialization, ValueExpression array)
        {
            var item = new CodeWriterDeclaration("item");
            return new MethodBodyStatements
            (
                utf8JsonWriter.WriteStartArray(),
                new ForeachStatement(item, array, new MethodBodyStatements
                (
                    CheckCollectionItemForNull(utf8JsonWriter, arraySerialization.ValueSerialization, item),
                    SerializeExpression(utf8JsonWriter, arraySerialization.ValueSerialization, item))
                ),
                utf8JsonWriter.WriteEndArray()
            );
        }

        private static MethodBodyStatement SerializeDictionary(Utf8JsonWriterExpression utf8JsonWriter, JsonDictionarySerialization dictionarySerialization, ValueExpression dictionary)
        {
            var keyValuePair = new CodeWriterDeclaration("item");
            var value = new MemberReference(keyValuePair, nameof(KeyValuePair<string, string>.Value));
            return new MethodBodyStatements
            (
                utf8JsonWriter.WriteStartObject(),
                new ForeachStatement(keyValuePair, dictionary, new MethodBodyStatements
                (
                    utf8JsonWriter.WritePropertyName(new MemberReference(keyValuePair, nameof(KeyValuePair<string, string>.Key))),
                    CheckCollectionItemForNull(utf8JsonWriter, dictionarySerialization.ValueSerialization, value),
                    SerializeExpression(utf8JsonWriter, dictionarySerialization.ValueSerialization, value))
                ),
                utf8JsonWriter.WriteEndObject()
            );
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
                        var declareSerializeOptions = DeclareJsonSerializerOptions(out var serializeOptions);
                        return new MethodBodyStatements(declareSerializeOptions, LineCall.JsonSerializer.Serialize(utf8JsonWriter, value, serializeOptions));
                    }

                    return LineCall.JsonSerializer.Serialize(utf8JsonWriter, value);

                case ObjectType:
                    return utf8JsonWriter.WriteObjectValue(value);

                case EnumType { IsIntValueType: true, IsExtensible: false } enumType:
                    return utf8JsonWriter.WriteNumberValue(new CastExpression(NullableValue(value, valueSerialization.Type), enumType.ValueType));

                case EnumType enumType:
                    return utf8JsonWriter.WriteStringValue(Call.Enum.ToString(NullableValue(value, valueSerialization.Type), enumType));
            }

            throw new NotSupportedException();
        }

        private static MethodBodyStatement SerializeFrameworkTypeValue(Utf8JsonWriterExpression utf8JsonWriter, JsonValueSerialization valueSerialization, ValueExpression value, Type valueType)
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
                return utf8JsonWriter.WriteStringValue(Call.ToString(value));
            }

            if (valueType == typeof(Uri))
            {
                return utf8JsonWriter.WriteStringValue(new MemberReference(value, nameof(Uri.AbsoluteUri)));
            }

            if (valueType == typeof(BinaryData))
            {
                return new IfElsePreprocessorDirective
                (
                    "NET6_0_OR_GREATER",
                    utf8JsonWriter.WriteRawValue(value),
                    LineCall.JsonSerializer.Serialize(utf8JsonWriter, JsonDocumentExpression.Parse(Call.ToString(value)).RootElement)
                );
            }

            if (IsCustomJsonConverterAdded(valueType))
            {
                return LineCall.JsonSerializer.Serialize(utf8JsonWriter, value);
            }

            throw new NotSupportedException($"Framework type {valueType} serialization not supported");
        }

        private static MethodBodyStatement CheckCollectionItemForNull(Utf8JsonWriterExpression utf8JsonWriter, JsonSerialization valueSerialization, ValueExpression value)
            => CollectionItemRequiresNullCheckInSerialization(valueSerialization)
                ? new IfElseStatement(IsNull(value), new MethodBodyStatements(utf8JsonWriter.WriteNullValue(), Continue), null)
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
                    UsingVar("document", JsonDocumentExpression.Parse(new MemberReference(fromResponse, nameof(Response.Content))), out var document),
                    Return(Call.Static(null, $"Deserialize{returnType.Name}", document.RootElement))
                })
            );
        }

        private static IEnumerable<MethodBodyStatement> BuildDeserializeBody(Parameter element, JsonObjectSerialization serialization)
        {
            var jsonElement = new JsonElementExpression(element);
            if (!serialization.Type.IsValueType) // only return null for reference type (e.g. no enum)
            {
                yield return new IfElseStatement(jsonElement.ValueKindEqualsNull(), Return(Null), null);
            }

            var discriminator = serialization.Discriminator;
            if (discriminator is not null && discriminator.HasDescendants)
            {
                yield return new IfElseStatement
                (
                    Call.JsonElement.TryGetProperty(element, discriminator.SerializedName, out var discriminatorElement),
                    new SwitchStatement(discriminatorElement.GetString(), GetDiscriminatorCases(jsonElement, discriminator).ToArray()),
                    null
                );
            }

            if (discriminator is not null && !serialization.Type.HasParent && !serialization.Type.Equals(discriminator.DefaultObjectType.Type))
            {
                yield return Return(GetDeserializeImplementation(discriminator.DefaultObjectType.Type.Implementation, jsonElement, null));
            }
            else
            {
                yield return WriteObjectInitialization(jsonElement, serialization).AsStatement();
            }
        }

        private static IEnumerable<SwitchCase> GetDiscriminatorCases(JsonElementExpression element, ObjectTypeDiscriminator discriminator)
        {
            foreach (var implementation in discriminator.Implementations)
            {
                yield return new SwitchCaseLine(implementation.Key, Return(GetDeserializeImplementation(implementation.Type.Implementation, element, null)));
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

            var property = new CodeWriterDeclaration("property");
            var shouldTreatEmptyStringAsNull = Configuration.ModelsToTreatEmptyStringAsNull.Contains(serialization.Type.Name);
            yield return new ForeachStatement(
                property,
                element.EnumerateObject(),
                DeserializeIntoObjectProperties(serialization.Properties, objAdditionalProperties?.ValueSerialization, new JsonPropertyExpression(property), dictionaryVariable, propertyVariables, shouldTreatEmptyStringAsNull).AsStatement());

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

        private static IEnumerable<MethodBodyStatement> DeserializeIntoObjectProperties(IEnumerable<JsonPropertySerialization> propertySerializations, JsonSerialization? additionalPropertiesSerialization, JsonPropertyExpression jsonProperty, CodeWriterDeclaration dictionaryVariable, IReadOnlyDictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            yield return DeserializeIntoObjectProperties(propertySerializations, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull).AsStatement();
            if (additionalPropertiesSerialization is null)
            {
                yield break;
            }

            yield return DeserializeValue(additionalPropertiesSerialization, jsonProperty.Value, out var value);
            yield return LineCall.Dictionary.Add(dictionaryVariable, jsonProperty.Name, value);
        }

        private static IEnumerable<MethodBodyStatement> DeserializeIntoObjectProperties(IEnumerable<JsonPropertySerialization> propertySerializations, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, bool shouldTreatEmptyStringAsNull)
            => propertySerializations
                .Where(p => !p.ShouldSkipDeserialization)
                .Select(p => new IfElseStatement(jsonProperty.NameEquals(p.SerializedName), DeserializeIntoObjectProperty(p, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull).AsStatement(), null));

        private static IEnumerable<MethodBodyStatement> DeserializeIntoObjectProperty(JsonPropertySerialization jsonPropertySerialization, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, bool shouldTreatEmptyStringAsNull)
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
                        jsonProperty.ThrowNonNullablePropertyIsNull(),
                        Continue
                    }.AsStatement(), null);
                }
            }

            if (jsonPropertySerialization.ValueSerialization is not null)
            {
                // Reading a property value
                yield return DeserializeValue(jsonPropertySerialization.ValueSerialization, jsonProperty.Value, out var value);
                yield return new SetValueLine(propertyVariables[jsonPropertySerialization].Declaration, value);
            }
            else if (jsonPropertySerialization.PropertySerializations is not null)
            {
                // Reading a nested object
                var nestedItemVariable = new CodeWriterDeclaration("property");
                yield return new ForeachStatement
                (
                    nestedItemVariable,
                    jsonProperty.Value.EnumerateObject(),
                    DeserializeIntoObjectProperties(jsonPropertySerialization.PropertySerializations, new JsonPropertyExpression(nestedItemVariable), propertyVariables, shouldTreatEmptyStringAsNull).AsStatement()
                );
            }
            else
            {
                throw new InvalidOperationException($"Either {nameof(JsonPropertySerialization.ValueSerialization)} must not be null or {nameof(JsonPropertySerialization.PropertySerializations)} must not be null.");
            }

            yield return Continue;
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

            return Or(jsonElement.ValueKindEqualsNull(), And(jsonElement.ValueKindEqualsString(), StringLengthEqualsZero(jsonElement.GetString())));

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

            var declareDocument = UsingVar("document", JsonDocumentExpression.Parse(response, async), out var document);
            var deserializeValueBlock = DeserializeValue(serialization, document.RootElement, out var value);
            MethodBodyLine setOrReturnValue = variable is not null ? new SetValueLine(variable, value) : new ReturnValueLine(value);

            if (!serialization.IsNullable)
            {
                return new MethodBodyStatements(declareDocument, deserializeValueBlock, setOrReturnValue);
            }

            return new MethodBodyStatements(declareDocument, new IfElseStatement
            (
                document.RootElement.ValueKindEqualsNull(),
                variable is not null ? new SetValueLine(variable, Null) : new ReturnValueLine(Null),
                new MethodBodyStatements(deserializeValueBlock, setOrReturnValue)
            ));
        }

        public static MethodBodyStatement DeserializeValue(JsonSerialization serialization, JsonElementExpression element, out ValueExpression value)
        {
            switch (serialization)
            {
                case JsonArraySerialization jsonArray:
                    var array = new CodeWriterDeclaration("array");
                    var item = new CodeWriterDeclaration("item");
                    value = array;

                    var declareListVariable = new DeclareVariableLine(jsonArray.ImplementationType, array, New(jsonArray.ImplementationType));
                    var iterateOverJsonArray = new ForeachStatement(item, element.EnumerateArray(), DeserializeArrayItem(jsonArray.ValueSerialization, array, new JsonElementExpression(item)));
                    return new MethodBodyStatements(declareListVariable, iterateOverJsonArray);

                case JsonDictionarySerialization jsonDictionary:
                    var dictionary = new CodeWriterDeclaration("dictionary");
                    var property = new CodeWriterDeclaration("property");
                    value = dictionary;

                    var declareDictionaryVariable = new DeclareVariableLine(jsonDictionary.Type, dictionary, New(jsonDictionary.Type));
                    var iterateOverJsonObject = new ForeachStatement(property, element.EnumerateObject(), DeserializeDictionaryValue(jsonDictionary.ValueSerialization, dictionary, property));

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

        private static MethodBodyStatement DeserializeArrayItem(JsonSerialization serialization, CodeWriterDeclaration arrayVariable, JsonElementExpression arrayItemVariable)
        {
            var deserializeValueBlock = DeserializeValue(serialization, arrayItemVariable, out var value);
            var addValueLine = LineCall.List.Add(arrayVariable, value);

            if (CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                return new IfElseStatement
                (
                    arrayItemVariable.ValueKindEqualsNull(),
                    LineCall.List.Add(arrayVariable, Null),
                    new MethodBodyStatements(deserializeValueBlock, addValueLine)
                );
            }

            return new MethodBodyStatements(deserializeValueBlock, addValueLine);
        }

        private static MethodBodyStatement DeserializeDictionaryValue(JsonSerialization serialization, CodeWriterDeclaration dictionaryVariable, CodeWriterDeclaration itemVariable)
        {
            var key = new MemberReference(itemVariable, "Name");
            var element = new JsonElementExpression(new MemberReference(itemVariable, "Value"));

            var deserializeValueBlock = DeserializeValue(serialization, element, out var value);
            var addValueLine = LineCall.Dictionary.Add(dictionaryVariable, key, value);

            if (CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                return new IfElseStatement
                (
                    element.ValueKindEqualsNull(),
                    LineCall.Dictionary.Add(dictionaryVariable, key, Null),
                    new MethodBodyStatements(deserializeValueBlock, addValueLine)
                );
            }

            return new MethodBodyStatements(deserializeValueBlock, addValueLine);
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
                return New(frameworkType, element.GetString());
            }

            if (frameworkType == typeof(IPAddress))
            {
                return Call.Static(typeof(IPAddress), nameof(IPAddress.Parse), element.GetString());
            }

            if (frameworkType == typeof(BinaryData))
            {
                return Call.BinaryData.FromString(element.GetRawText());
            }

            if (IsCustomJsonConverterAdded(frameworkType) && serializationType is not null)
            {
                return Call.JsonSerializer.Deserialize(element, serializationType);
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
                return element.GetDateTimeOffset(format.ToFormatSpecifier());
            if (frameworkType == typeof(DateTime))
                return element.GetDateTime();
            if (frameworkType == typeof(TimeSpan))
                return element.GetTimeSpan(format.ToFormatSpecifier());

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
