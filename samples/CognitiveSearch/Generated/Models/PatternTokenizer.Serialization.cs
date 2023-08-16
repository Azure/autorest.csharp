// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class PatternTokenizer : IUtf8JsonSerializable, IModelJsonSerializable<PatternTokenizer>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<PatternTokenizer>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<PatternTokenizer>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<PatternTokenizer>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(Pattern))
            {
                writer.WritePropertyName("pattern"u8);
                writer.WriteStringValue(Pattern);
            }
            if (Optional.IsDefined(Flags))
            {
                writer.WritePropertyName("flags"u8);
                writer.WriteStringValue(Flags.Value.ToString());
            }
            if (Optional.IsDefined(Group))
            {
                writer.WritePropertyName("group"u8);
                writer.WriteNumberValue(Group.Value);
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static PatternTokenizer DeserializePatternTokenizer(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> pattern = default;
            Optional<RegexFlags> flags = default;
            Optional<int> group = default;
            string odataType = default;
            string name = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("pattern"u8))
                {
                    pattern = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("flags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    flags = new RegexFlags(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("group"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    group = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new PatternTokenizer(odataType, name, pattern.Value, Optional.ToNullable(flags), Optional.ToNullable(group), rawData);
        }

        PatternTokenizer IModelJsonSerializable<PatternTokenizer>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<PatternTokenizer>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializePatternTokenizer(doc.RootElement, options);
        }

        BinaryData IModelSerializable<PatternTokenizer>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<PatternTokenizer>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        PatternTokenizer IModelSerializable<PatternTokenizer>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<PatternTokenizer>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializePatternTokenizer(doc.RootElement, options);
        }

        public static implicit operator RequestContent(PatternTokenizer model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator PatternTokenizer(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializePatternTokenizer(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
