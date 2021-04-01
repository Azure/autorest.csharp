// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace TenantOnly
{
    public partial class AgreementData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Participants))
            {
                writer.WritePropertyName("participants");
                writer.WriteStartArray();
                foreach (var item in Participants)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static AgreementData DeserializeAgreementData(JsonElement element)
        {
            Optional<string> agreementLink = default;
            Optional<Category> category = default;
            Optional<AcceptanceMode> acceptanceMode = default;
            Optional<DateTimeOffset> effectiveDate = default;
            Optional<DateTimeOffset> expirationDate = default;
            Optional<IList<Participants>> participants = default;
            Optional<string> status = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("agreementLink"))
                        {
                            agreementLink = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("category"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            category = new Category(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("acceptanceMode"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            acceptanceMode = new AcceptanceMode(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("effectiveDate"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            effectiveDate = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("expirationDate"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            expirationDate = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("participants"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<Participants> array = new List<Participants>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(TenantOnly.Participants.DeserializeParticipants(item));
                            }
                            participants = array;
                            continue;
                        }
                        if (property0.NameEquals("status"))
                        {
                            status = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new AgreementData(agreementLink.Value, Optional.ToNullable(category), Optional.ToNullable(acceptanceMode), Optional.ToNullable(effectiveDate), Optional.ToNullable(expirationDate), Optional.ToList(participants), status.Value);
        }
    }
}
