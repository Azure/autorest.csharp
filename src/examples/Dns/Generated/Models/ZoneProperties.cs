// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Threading;

namespace Azure.Dns.Models.V20180501
{
    public partial class ZoneProperties
    {
        private List<string>? _nameServers;
        private List<SubResource>? _registrationVirtualNetworks;
        private List<SubResource>? _resolutionVirtualNetworks;

        public int? MaxNumberOfRecordSets { get; set; }
        public int? NumberOfRecordSets { get; set; }
        public ICollection<string> NameServers => LazyInitializer.EnsureInitialized(ref _nameServers);
        public ZoneType? ZoneType { get; set; }
        public ICollection<SubResource> RegistrationVirtualNetworks => LazyInitializer.EnsureInitialized(ref _registrationVirtualNetworks);
        public ICollection<SubResource> ResolutionVirtualNetworks => LazyInitializer.EnsureInitialized(ref _resolutionVirtualNetworks);
    }

    public partial class ZoneProperties
    {
        internal static ZoneProperties Deserialize(JsonElement element)
        {
            var result = new ZoneProperties();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxNumberOfRecordSets"))
                {
                    result.MaxNumberOfRecordSets = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("numberOfRecordSets"))
                {
                    result.NumberOfRecordSets = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("nameServers"))
                {
                    //result._nameServers = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.NameServers.Add(item.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("zoneType"))
                {
                    result.ZoneType = property.Value.ToString();
                    continue;
                }
                if (property.NameEquals("registrationVirtualNetworks"))
                {
                    //result._registrationVirtualNetworks = new List<SubResource>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.RegistrationVirtualNetworks.Add(SubResource.Deserialize(item));
                    }
                    continue;
                }
                if (property.NameEquals("resolutionVirtualNetworks"))
                {
                    //result._resolutionVirtualNetworks = new List<SubResource>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.ResolutionVirtualNetworks.Add(SubResource.Deserialize(item));
                    }
                    continue;
                }
            }
            return result;
        }

        public void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("zoneProperties");
            }
            else
            {
                writer.WriteStartObject();
            }
            
            if (MaxNumberOfRecordSets != null)
            {
                writer.WriteNumber("maxNumberOfRecordSets", MaxNumberOfRecordSets.Value);
            }
            if (NumberOfRecordSets != null)
            {
                writer.WriteNumber("numberOfRecordSets", NumberOfRecordSets.Value);
            }
            if (_nameServers != null)
            {
                writer.WriteStartArray("nameServers");
                foreach (var item in _nameServers)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (ZoneType != null)
            {
                writer.WriteString("zoneType", ZoneType.ToString());
            }
            if (_registrationVirtualNetworks != null)
            {
                writer.WriteStartArray("registrationVirtualNetworks");
                foreach (var item in _registrationVirtualNetworks)
                {
                    item.Serialize(writer, false);
                }
                writer.WriteEndArray();
            }
            if (_resolutionVirtualNetworks != null)
            {
                writer.WriteStartArray("resolutionVirtualNetworks");
                foreach (var item in _resolutionVirtualNetworks)
                {
                    item.Serialize(writer, false);
                }
                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }
    }
}
