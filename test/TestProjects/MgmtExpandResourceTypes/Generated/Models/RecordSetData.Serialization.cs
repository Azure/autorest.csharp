// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtExpandResourceTypes.Models;

namespace MgmtExpandResourceTypes
{
    public partial class RecordSetData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Etag))
            {
                writer.WritePropertyName("etag");
                writer.WriteStringValue(Etag);
            }
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Metadata))
            {
                writer.WritePropertyName("metadata");
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
                writer.WritePropertyName("TTL");
                writer.WriteNumberValue(TTL.Value);
            }
            if (Optional.IsDefined(TargetResource))
            {
                writer.WritePropertyName("targetResource");
                JsonSerializer.Serialize(writer, TargetResource);
            }
            if (Optional.IsCollectionDefined(ARecords))
            {
                writer.WritePropertyName("ARecords");
                writer.WriteStartArray();
                foreach (var item in ARecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(AaaaRecords))
            {
                writer.WritePropertyName("AAAARecords");
                writer.WriteStartArray();
                foreach (var item in AaaaRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(MxRecords))
            {
                writer.WritePropertyName("MXRecords");
                writer.WriteStartArray();
                foreach (var item in MxRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(NsRecords))
            {
                writer.WritePropertyName("NSRecords");
                writer.WriteStartArray();
                foreach (var item in NsRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(PtrRecords))
            {
                writer.WritePropertyName("PTRRecords");
                writer.WriteStartArray();
                foreach (var item in PtrRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(SrvRecords))
            {
                writer.WritePropertyName("SRVRecords");
                writer.WriteStartArray();
                foreach (var item in SrvRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TxtRecords))
            {
                writer.WritePropertyName("TXTRecords");
                writer.WriteStartArray();
                foreach (var item in TxtRecords)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(CnameRecord))
            {
                writer.WritePropertyName("CNAMERecord");
                writer.WriteObjectValue(CnameRecord);
            }
            if (Optional.IsDefined(SoaRecord))
            {
                writer.WritePropertyName("SOARecord");
                writer.WriteObjectValue(SoaRecord);
            }
            if (Optional.IsCollectionDefined(CaaRecords))
            {
                writer.WritePropertyName("caaRecords");
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

        internal static RecordSetData DeserializeRecordSetData(JsonElement element)
        {
            Optional<string> etag = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            SystemData systemData = default;
            Optional<IDictionary<string, string>> metadata = default;
            Optional<long> tTL = default;
            Optional<string> fqdn = default;
            Optional<string> provisioningState = default;
            Optional<WritableSubResource> targetResource = default;
            Optional<IList<ARecord>> aRecords = default;
            Optional<IList<AaaaRecord>> aAAARecords = default;
            Optional<IList<MxRecord>> mXRecords = default;
            Optional<IList<NsRecord>> nSRecords = default;
            Optional<IList<PtrRecord>> pTRRecords = default;
            Optional<IList<SrvRecord>> sRVRecords = default;
            Optional<IList<TxtRecord>> tXTRecords = default;
            Optional<CnameRecord> cNAMERecord = default;
            Optional<SoaRecord> sOARecord = default;
            Optional<IList<CaaRecord>> caaRecords = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("metadata"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
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
                        if (property0.NameEquals("TTL"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            tTL = property0.Value.GetInt64();
                            continue;
                        }
                        if (property0.NameEquals("fqdn"))
                        {
                            fqdn = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("targetResource"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            targetResource = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.ToString());
                            continue;
                        }
                        if (property0.NameEquals("ARecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
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
                        if (property0.NameEquals("AAAARecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<AaaaRecord> array = new List<AaaaRecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(AaaaRecord.DeserializeAaaaRecord(item));
                            }
                            aAAARecords = array;
                            continue;
                        }
                        if (property0.NameEquals("MXRecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<MxRecord> array = new List<MxRecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(MxRecord.DeserializeMxRecord(item));
                            }
                            mXRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("NSRecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<NsRecord> array = new List<NsRecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(NsRecord.DeserializeNsRecord(item));
                            }
                            nSRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("PTRRecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<PtrRecord> array = new List<PtrRecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(PtrRecord.DeserializePtrRecord(item));
                            }
                            pTRRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("SRVRecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<SrvRecord> array = new List<SrvRecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(SrvRecord.DeserializeSrvRecord(item));
                            }
                            sRVRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("TXTRecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            List<TxtRecord> array = new List<TxtRecord>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(TxtRecord.DeserializeTxtRecord(item));
                            }
                            tXTRecords = array;
                            continue;
                        }
                        if (property0.NameEquals("CNAMERecord"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            cNAMERecord = CnameRecord.DeserializeCnameRecord(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("SOARecord"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            sOARecord = SoaRecord.DeserializeSoaRecord(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("caaRecords"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
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
            return new RecordSetData(id, name, type, systemData, etag.Value, Optional.ToDictionary(metadata), Optional.ToNullable(tTL), fqdn.Value, provisioningState.Value, targetResource, Optional.ToList(aRecords), Optional.ToList(aAAARecords), Optional.ToList(mXRecords), Optional.ToList(nSRecords), Optional.ToList(pTRRecords), Optional.ToList(sRVRecords), Optional.ToList(tXTRecords), cNAMERecord.Value, sOARecord.Value, Optional.ToList(caaRecords));
        }
    }
}
