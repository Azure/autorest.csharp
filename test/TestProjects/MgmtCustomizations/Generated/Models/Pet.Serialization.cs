// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace MgmtCustomizations.Models
{
    [PersistableModelProxy(typeof(UnknownPet))]
    public partial class Pet : IUtf8JsonSerializable, IJsonModel<Pet>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Pet>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<Pet>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Pet>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(Pet)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind.ToSerialString());
            if (options.Format == "J")
            {
                if (Optional.IsDefined(Name))
                {
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(Name);
                }
            }
            if (Optional.IsDefined(Size))
            {
                writer.WritePropertyName("size"u8);
                SerializeSizeProperty(writer);
            }
            if (Optional.IsDefined(DateOfBirth))
            {
                writer.WritePropertyName("dateOfBirth"u8);
                SerializeDateOfBirthProperty(writer);
            }
            if (_serializedAdditionalRawData != null && options.Format != "W")
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        Pet IJsonModel<Pet>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Pet>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(Pet)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePet(document.RootElement, options);
        }

        internal static Pet DeserializePet(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "Cat": return Cat.DeserializeCat(element);
                    case "Dog": return Dog.DeserializeDog(element);
                }
            }
            return UnknownPet.DeserializeUnknownPet(element);
        }

        BinaryData IPersistableModel<Pet>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Pet>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(Pet)} does not support '{options.Format}' format.");
            }
        }

        Pet IPersistableModel<Pet>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Pet>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializePet(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(Pet)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<Pet>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
