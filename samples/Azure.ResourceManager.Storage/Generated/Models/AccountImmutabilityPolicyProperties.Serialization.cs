// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class AccountImmutabilityPolicyProperties : IUtf8JsonSerializable, IJsonModel<AccountImmutabilityPolicyProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AccountImmutabilityPolicyProperties>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<AccountImmutabilityPolicyProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<AccountImmutabilityPolicyProperties>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<AccountImmutabilityPolicyProperties>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(ImmutabilityPeriodSinceCreationInDays))
            {
                writer.WritePropertyName("immutabilityPeriodSinceCreationInDays"u8);
                writer.WriteNumberValue(ImmutabilityPeriodSinceCreationInDays.Value);
            }
            if (Optional.IsDefined(State))
            {
                writer.WritePropertyName("state"u8);
                writer.WriteStringValue(State.Value.ToString());
            }
            if (Optional.IsDefined(AllowProtectedAppendWrites))
            {
                writer.WritePropertyName("allowProtectedAppendWrites"u8);
                writer.WriteBooleanValue(AllowProtectedAppendWrites.Value);
            }
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        AccountImmutabilityPolicyProperties IJsonModel<AccountImmutabilityPolicyProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AccountImmutabilityPolicyProperties)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAccountImmutabilityPolicyProperties(document.RootElement, options);
        }

        internal static AccountImmutabilityPolicyProperties DeserializeAccountImmutabilityPolicyProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> immutabilityPeriodSinceCreationInDays = default;
            Optional<AccountImmutabilityPolicyState> state = default;
            Optional<bool> allowProtectedAppendWrites = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("immutabilityPeriodSinceCreationInDays"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    immutabilityPeriodSinceCreationInDays = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("state"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    state = new AccountImmutabilityPolicyState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("allowProtectedAppendWrites"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    allowProtectedAppendWrites = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new AccountImmutabilityPolicyProperties(Optional.ToNullable(immutabilityPeriodSinceCreationInDays), Optional.ToNullable(state), Optional.ToNullable(allowProtectedAppendWrites), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<AccountImmutabilityPolicyProperties>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AccountImmutabilityPolicyProperties)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        AccountImmutabilityPolicyProperties IPersistableModel<AccountImmutabilityPolicyProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AccountImmutabilityPolicyProperties)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeAccountImmutabilityPolicyProperties(document.RootElement, options);
        }

        string IPersistableModel<AccountImmutabilityPolicyProperties>.GetWireFormat(ModelReaderWriterOptions options) => "J";
    }
}
