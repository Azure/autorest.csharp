// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtExpandResourceTypes.Models;

namespace MgmtExpandResourceTypes
{
    public partial class RecordSetData : IUtf8JsonSerializable, IModelJsonSerializable<RecordSetData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<RecordSetData>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<RecordSetData>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Etag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(Etag);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Metadata))
            {
                writer.WritePropertyName("metadata"u8);
                writer.WriteStartObject();
                foreach (var item in Metadata)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(TTL))
            {
                writer.WritePropertyName("TTL"u8);
                writer.WriteNumberValue(TTL.Value);
            }
            if (Optional.IsDefined(TargetResource))
            {
                writer.WritePropertyName("targetResource"u8);
                JsonSerializer.Serialize(writer, TargetResource);
            }
            if (Optional.IsCollectionDefined(ARecords))
            {
                writer.WritePropertyName("ARecords"u8);
                writer.WriteStartArray();
                foreach (var item in ARecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(AaaaRecords))
            {
                writer.WritePropertyName("AAAARecords"u8);
                writer.WriteStartArray();
                foreach (var item in AaaaRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(MxRecords))
            {
                writer.WritePropertyName("MXRecords"u8);
                writer.WriteStartArray();
                foreach (var item in MxRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(NsRecords))
            {
                writer.WritePropertyName("NSRecords"u8);
                writer.WriteStartArray();
                foreach (var item in NsRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(PtrRecords))
            {
                writer.WritePropertyName("PTRRecords"u8);
                writer.WriteStartArray();
                foreach (var item in PtrRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(SrvRecords))
            {
                writer.WritePropertyName("SRVRecords"u8);
                writer.WriteStartArray();
                foreach (var item in SrvRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TxtRecords))
            {
                writer.WritePropertyName("TXTRecords"u8);
                writer.WriteStartArray();
                foreach (var item in TxtRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(CnameRecord))
            {
                writer.WritePropertyName("CNAMERecord"u8);
                writer.WriteObjectValue(CnameRecord);
            }
            if (Optional.IsDefined(SoaRecord))
            {
                writer.WritePropertyName("SOARecord"u8);
                writer.WriteObjectValue(SoaRecord);
            }
            if (Optional.IsCollectionDefined(CaaRecords))
            {
                writer.WritePropertyName("caaRecords"u8);
                writer.WriteStartArray();
                foreach (var item in CaaRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        RecordSetData IModelJsonSerializable<RecordSetData>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeRecordSetData(doc.RootElement, options);
        }

        BinaryData IModelSerializable<RecordSetData>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        RecordSetData IModelSerializable<RecordSetData>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeRecordSetData(document.RootElement, options);
        }

        internal static RecordSetData DeserializeRecordSetData(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> etag = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<IDictionary<string, string>> metadata = default;
            Optional<long> ttl = default;
            Optional<string> fqdn = default;
            Optional<string> provisioningState = default;
            Optional<WritableSubResource> targetResource = default;
            Optional<IList<ARecord>> aRecords = default;
            Optional<IList<AaaaRecord>> aaaaRecords = default;
            Optional<IList<MxRecord>> mxRecords = default;
            Optional<IList<NsRecord>> nsRecords = default;
            Optional<IList<PtrRecord>> ptrRecords = default;
            Optional<IList<SrvRecord>> srvRecords = default;
            Optional<IList<TxtRecord>> txtRecords = default;
            Optional<CnameRecord> cnameRecord = default;
            Optional<SoaRecord> soaRecord = default;
            Optional<IList<CaaRecord>> caaRecords = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"u8))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("metadata"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            Dictionary<string, string> dictionary = new Dictionary<string, string>();
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                dictionary.Add(property1.Name, property1.Value.GetString());
                            }
                            metadata = dictionary;
                            continue;
                        }
                        if (property0.NameEquals("TTL"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            ttl = property0.Value.GetInt64();
                            continue;
                        }
                        if (property0.NameEquals("fqdn"u8))
                        {
                            fqdn = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("targetResource"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            targetResource = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("ARecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ARecord> array = new List<ARecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ARecord.DeserializeARecord(item));
                            }
                            aRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("AAAARecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<AaaaRecord> array = new List<AaaaRecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(AaaaRecord.DeserializeAaaaRecord(item));
                            }
                            aaaaRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("MXRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<MxRecord> array = new List<MxRecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(MxRecord.DeserializeMxRecord(item));
                            }
                            mxRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("NSRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<NsRecord> array = new List<NsRecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(NsRecord.DeserializeNsRecord(item));
                            }
                            nsRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("PTRRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<PtrRecord> array = new List<PtrRecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(PtrRecord.DeserializePtrRecord(item));
                            }
                            ptrRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("SRVRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<SrvRecord> array = new List<SrvRecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(SrvRecord.DeserializeSrvRecord(item));
                            }
                            srvRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("TXTRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<TxtRecord> array = new List<TxtRecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(TxtRecord.DeserializeTxtRecord(item));
                            }
                            txtRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("CNAMERecord"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            cnameRecord = CnameRecord.DeserializeCnameRecord(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("SOARecord"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            soaRecord = SoaRecord.DeserializeSoaRecord(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("caaRecords"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<CaaRecord> array = new List<CaaRecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(CaaRecord.DeserializeCaaRecord(item));
                            }
                            caaRecords = array;
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new RecordSetData(id, name, type, systemData.Value, etag.Value, Optional.ToDictionary(metadata), Optional.ToNullable(ttl), fqdn.Value, provisioningState.Value, targetResource, Optional.ToList(aRecords), Optional.ToList(aaaaRecords), Optional.ToList(mxRecords), Optional.ToList(nsRecords), Optional.ToList(ptrRecords), Optional.ToList(srvRecords), Optional.ToList(txtRecords), cnameRecord.Value, soaRecord.Value, Optional.ToList(caaRecords));
        }
    }
}
