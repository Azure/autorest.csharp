// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace TypeSchemaMapping.Models
{
    public partial class ModelWithCustomUsageViaAttribute : IUtf8JsonSerializable, IModelJsonSerializable<ModelWithCustomUsageViaAttribute>, IXmlSerializable, IModelSerializable<ModelWithCustomUsageViaAttribute>
    {
        private void Serialize(XmlWriter writer, string nameHint, ModelSerializerOptions options)
        {
            writer.WriteStartElement("ModelWithCustomUsageViaAttribute");
            if (Optional.IsDefined(ModelProperty))
            {
                writer.WriteStartElement("ModelProperty");
                writer.WriteValue(ModelProperty);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => Serialize(writer, nameHint, ModelSerializerOptions.DefaultWireOptions);

        internal static ModelWithCustomUsageViaAttribute DeserializeModelWithCustomUsageViaAttribute(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;
            string modelProperty = default;
            if (element.Element("ModelProperty") is XElement modelPropertyElement)
            {
                modelProperty = (string)modelPropertyElement;
            }
            return new ModelWithCustomUsageViaAttribute(modelProperty, default);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ModelWithCustomUsageViaAttribute>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ModelWithCustomUsageViaAttribute>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(ModelProperty))
            {
                writer.WritePropertyName("ModelProperty"u8);
                writer.WriteStringValue(ModelProperty);
            }
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

        internal static ModelWithCustomUsageViaAttribute DeserializeModelWithCustomUsageViaAttribute(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> modelProperty = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"u8))
                {
                    modelProperty = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new ModelWithCustomUsageViaAttribute(modelProperty.Value, rawData);
        }

        ModelWithCustomUsageViaAttribute IModelJsonSerializable<ModelWithCustomUsageViaAttribute>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithCustomUsageViaAttribute(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ModelWithCustomUsageViaAttribute>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            if (options.Format == ModelSerializerFormat.Json)
            {
                return ModelSerializer.SerializeCore(this, options);
            }
            else
            {
                options ??= ModelSerializerOptions.DefaultWireOptions;
                using MemoryStream stream = new MemoryStream();
                using XmlWriter writer = XmlWriter.Create(stream);
                Serialize(writer, null, options);
                writer.Flush();
                if (stream.Position > int.MaxValue)
                {
                    return BinaryData.FromStream(stream);
                }
                else
                {
                    return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
                }
            }
        }

        ModelWithCustomUsageViaAttribute IModelSerializable<ModelWithCustomUsageViaAttribute>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            if (data.ToMemory().Span.StartsWith("{"u8))
            {
                using var doc = JsonDocument.Parse(data);
                return DeserializeModelWithCustomUsageViaAttribute(doc.RootElement, options);
            }
            else
            {
                return DeserializeModelWithCustomUsageViaAttribute(XElement.Load(data.ToStream()), options);
            }
        }

        public static implicit operator RequestContent(ModelWithCustomUsageViaAttribute model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create((IModelSerializable<ModelWithCustomUsageViaAttribute>)model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator ModelWithCustomUsageViaAttribute(Response response)
        {
            if (response is null)
            {
                return null;
            }

            return DeserializeModelWithCustomUsageViaAttribute(XElement.Load(response.ContentStream), ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
