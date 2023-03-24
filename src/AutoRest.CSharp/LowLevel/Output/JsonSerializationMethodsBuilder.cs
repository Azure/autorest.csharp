// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using static AutoRest.CSharp.Output.Models.MethodBodyLines;
using static AutoRest.CSharp.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Output.Models
{
    internal static class JsonSerializationMethodsBuilder
    {
        public static MethodBodyBlock BuildDeserializationForMethods(JsonSerialization serialization, bool async, CodeWriterDeclaration? variable, ValueExpression response, bool isBinaryData)
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
                return new MethodBodyBlocks(declareDocument, deserializeValueBlock, setOrReturnValue);
            }

            return new MethodBodyBlocks(declareDocument, new IfElseBlock
            (
                new FormattableStringToExpression($"{document}.RootElement.ValueKind == {typeof(JsonValueKind)}.Null"),
                variable is not null ? new SetValueLine(variable, Null) : new ReturnValueLine(Null),
                new MethodBodyBlocks(deserializeValueBlock, setOrReturnValue)
            ));
        }

        public static MethodBodyBlock DeserializeValue(JsonSerialization serialization, ValueExpression element, out ValueExpression value)
        {
            switch (serialization)
            {
                case JsonArraySerialization jsonArray:
                    var array = new CodeWriterDeclaration("array");
                    var item = new CodeWriterDeclaration("item");
                    value = array;

                    var declareListVariable = new DeclareVariableLine(jsonArray.ImplementationType, array, New(jsonArray.ImplementationType));
                    var iterateOverJsonArray = new ForeachBlock(item, Call.JsonElement.EnumerateArray(element), DeserializeArrayItem(jsonArray.ValueSerialization, array, item));
                    return new MethodBodyBlocks(declareListVariable, iterateOverJsonArray);

                case JsonDictionarySerialization jsonDictionary:
                    var dictionary = new CodeWriterDeclaration("dictionary");
                    var property = new CodeWriterDeclaration("property");
                    value = dictionary;

                    var declareDictionaryVariable = new DeclareVariableLine(jsonDictionary.Type, dictionary, New(jsonDictionary.Type));
                    var iterateOverJsonObject = new ForeachBlock(property, Call.JsonElement.EnumerateObject(element), DeserializeDictionaryValue(jsonDictionary.ValueSerialization, dictionary, property));

                    return new MethodBodyBlocks(declareDictionaryVariable, iterateOverJsonObject);

                case JsonValueSerialization { Options: JsonSerializationOptions.UseManagedServiceIdentityV3 } valueSerialization:
                    var serializeOptions = new CodeWriterDeclaration("serializeOptions");
                    var properties = new Dictionary<string, ValueExpression>
                    {
                        [nameof(JsonSerializerOptions.Converters)] = new FormattableStringToExpression($"{{ new {nameof(ManagedServiceIdentityTypeV3Converter)}() }}")
                    };

                    var declareSerializeOptions = new DeclareVariableLine(null, serializeOptions, New(typeof(JsonSerializerOptions), properties));
                    value = GetDeserializeValueExpression(element, valueSerialization.Type, valueSerialization.Format, serializeOptions);
                    return declareSerializeOptions;

                case JsonValueSerialization valueSerialization:
                    value = GetDeserializeValueExpression(element, valueSerialization.Type, valueSerialization.Format);
                    return new MethodBodyBlock();

                default:
                    throw new InvalidOperationException($"{serialization.GetType()} is not supported.");
            }
        }

        private static MethodBodyBlock DeserializeArrayItem(JsonSerialization serialization, CodeWriterDeclaration arrayVariable, CodeWriterDeclaration arrayItemVariable)
        {
            var deserializeValueBlock = DeserializeValue(serialization, arrayItemVariable, out var value);
            var addValueLine = LineCall.List.Add(arrayVariable, value);

            if (JsonCodeWriterExtensions.CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                return new IfElseBlock
                (
                    new FormattableStringToExpression($"{arrayItemVariable}.ValueKind == {typeof(JsonValueKind)}.Null"),
                    LineCall.List.Add(arrayVariable, Null),
                    new MethodBodyBlocks(deserializeValueBlock, addValueLine)
                );
            }

            return new MethodBodyBlocks(deserializeValueBlock, addValueLine);
        }

        private static MethodBodyBlock DeserializeDictionaryValue(JsonSerialization serialization, CodeWriterDeclaration dictionaryVariable, CodeWriterDeclaration itemVariable)
        {
            var key = new MemberReference(itemVariable, "Name");

            var deserializeValueBlock = DeserializeValue(serialization, new MemberReference(itemVariable, "Value"), out var value);
            var addValueLine = LineCall.Dictionary.Add(dictionaryVariable, key, value);

            if (JsonCodeWriterExtensions.CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                return new IfElseBlock
                (
                    new FormattableStringToExpression($"{itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null"),
                    LineCall.Dictionary.Add(dictionaryVariable, key, Null),
                    new MethodBodyBlocks(deserializeValueBlock, addValueLine)
                );
            }

            return new MethodBodyBlocks(deserializeValueBlock, addValueLine);
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

                case Resource { ResourceData: SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } resourceDataType } resource:
                    return New(resource.Type, new FormattableStringToExpression($"Client"), Call.Static(resourceDataType.Type, $"Deserialize{resourceDataType.Declaration.Name}", element));

                case MgmtObjectType mgmtObjectType when TypeReferenceTypeChooser.HasMatch(mgmtObjectType.ObjectSchema):
                    return Call.JsonSerializer.Deserialize(element, implementation.Type);

                case SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } type:
                    return Call.Static(type.Type, $"Deserialize{type.Declaration.Name}", element);

                case EnumType clientEnum:
                    var value = GetFrameworkTypeValueExpression(clientEnum.ValueType.FrameworkType, element, SerializationFormat.Default, null);
                    return clientEnum.IsExtensible ? New(clientEnum.Type, value) : Call.ToEnum(clientEnum.Type, value);

                default:
                    throw new NotSupportedException($"No deserialization logic exists for {implementation.Declaration.Name}");
            }
        }

        public static ValueExpression GetFrameworkTypeValueExpression(Type frameworkType, ValueExpression element, SerializationFormat format, CSharpType? serializationType)
        {
            bool includeFormat = false;

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

            var methodName = string.Empty;
            var callStaticExtension = false;
            if (frameworkType == typeof(JsonElement))
                methodName = nameof(JsonElement.Clone);
            if (frameworkType == typeof(object))
            {
                methodName = nameof(JsonElementExtensions.GetObject);
                callStaticExtension = true;
            }

            if (frameworkType == typeof(bool))
                methodName = nameof(JsonElement.GetBoolean);
            if (frameworkType == typeof(char))
            {
                methodName = nameof(JsonElementExtensions.GetChar);
                callStaticExtension = true;
            }

            if (frameworkType == typeof(short))
                methodName = nameof(JsonElement.GetInt16);
            if (frameworkType == typeof(int))
                methodName = nameof(JsonElement.GetInt32);
            if (frameworkType == typeof(long))
                methodName = nameof(JsonElement.GetInt64);
            if (frameworkType == typeof(float))
                methodName = nameof(JsonElement.GetSingle);
            if (frameworkType == typeof(double))
                methodName = nameof(JsonElement.GetDouble);
            if (frameworkType == typeof(decimal))
                methodName = nameof(JsonElement.GetDecimal);
            if (frameworkType == typeof(string))
                methodName = nameof(JsonElement.GetString);
            if (frameworkType == typeof(Guid))
                methodName = nameof(JsonElement.GetGuid);

            if (frameworkType == typeof(byte[]))
            {
                methodName = nameof(JsonElementExtensions.GetBytesFromBase64);
                callStaticExtension = true;
                includeFormat = true;
            }

            if (frameworkType == typeof(DateTimeOffset))
            {
                methodName = nameof(JsonElementExtensions.GetDateTimeOffset);
                callStaticExtension = true;
                includeFormat = true;
            }

            if (frameworkType == typeof(DateTime))
            {
                methodName = nameof(JsonElement.GetDateTime);
                includeFormat = true;
            }

            if (frameworkType == typeof(TimeSpan))
            {
                methodName = nameof(JsonElementExtensions.GetTimeSpan);
                callStaticExtension = true;
                includeFormat = true;
            }

            var arguments = new List<ValueExpression>();
            if (callStaticExtension)
            {
                arguments.Add(element);
            }
            if (includeFormat && format.ToFormatSpecifier() is { } formatString)
            {
                arguments.Add(new FormattableStringToExpression($"{formatString:L}"));
            }

            return callStaticExtension
                ? new StaticMethodCallExpression(typeof(JsonElementExtensions), methodName, arguments, CallAsExtension: true)
                : new InstanceMethodCallExpression(element, methodName, arguments, false);
        }

        private static bool IsCustomJsonConverterAdded(Type type)
            => type.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonConverterAttribute));
    }
}
