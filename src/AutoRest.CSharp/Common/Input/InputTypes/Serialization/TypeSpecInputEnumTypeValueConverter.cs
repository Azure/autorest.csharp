// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputEnumTypeValueConverter : JsonConverter<InputEnumTypeValue>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputEnumTypeValueConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputEnumTypeValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputEnumTypeValue>(_referenceHandler.CurrentResolver) ?? CreateEnumTypeValue(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        private static InputEnumTypeValue CreateEnumTypeValue(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            JsonElement? rawValue = null;
            InputPrimitiveType? valueType = null;
            string? summary = null;
            string? doc = null;
            IReadOnlyList<InputDecoratorInfo>? decorators = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadComplexType("value", options, ref rawValue)
                    || reader.TryReadComplexType("valueType", options, ref valueType)
                    || reader.TryReadString("summary", ref summary)
                    || reader.TryReadString("doc", ref doc)
                    || reader.TryReadComplexType("decorators", options, ref decorators);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException("EnumValue must have name");

            if (rawValue == null)
            {
                throw new JsonException("EnumValue must have value");
            }

            valueType = valueType ?? throw new JsonException("EnumValue must have valueType");

            InputEnumTypeValue enumValue = valueType.Kind switch
            {
                InputPrimitiveTypeKind.String => new InputEnumTypeStringValue(name, rawValue.Value.GetString() ?? throw new JsonException(), summary, doc) { Decorators = decorators ?? [] },
                InputPrimitiveTypeKind.Int32 => new InputEnumTypeIntegerValue(name, rawValue.Value.GetInt32(), summary, doc) { Decorators = decorators ?? [] },
                InputPrimitiveTypeKind.Float32 => new InputEnumTypeFloatValue(name, rawValue.Value.GetSingle(), summary, doc) { Decorators = decorators ?? [] },
                _ => throw new JsonException()
            };
            if (id != null)
            {
                resolver.AddReference(id, enumValue);
            }
            return enumValue;
        }

        public override void Write(Utf8JsonWriter writer, InputEnumTypeValue value, JsonSerializerOptions options)
            => writer.WriteObjectOrReference(value, options, _referenceHandler.CurrentResolver, WriteInputEnumTypeValueProperties);

        private static void WriteInputEnumTypeValueProperties(Utf8JsonWriter writer, InputEnumTypeValue value, JsonSerializerOptions options)
        {
            // kind
            writer.WriteString("kind", "enumvalue");
            // name
            writer.WriteString("name", value.Name);
            // value and valueType
            switch (value)
            {
                case InputEnumTypeStringValue strValue:
                    // value
                    writer.WriteString("value", strValue.StringValue);
                    // valueType
                    writer.WriteObject("valueType", InputPrimitiveType.String, options);
                    break;
                case InputEnumTypeIntegerValue intValue:
                    // value
                    writer.WriteNumber("value", intValue.IntegerValue);
                    // valueType
                    writer.WriteObject("valueType", InputPrimitiveType.Int32, options);
                    break;
                case InputEnumTypeFloatValue floatValue:
                    // value
                    writer.WriteNumber("value", floatValue.FloatValue);
                    // valueType
                    writer.WriteObject("valueType", InputPrimitiveType.Float32, options);
                    break;
                default:
                    throw new InvalidOperationException("this should never happen");
            }
            // enumType - the schema has this property but this has cyclic reference and we never used it
            // therefore omit this property.
            // summary
            writer.WriteStringIfPresent("summary", value.Summary);
            // doc
            writer.WriteStringIfPresent("doc", value.Doc);
            // decorators
            writer.WriteArray("decorators", value.Decorators, options);
        }
    }
}
