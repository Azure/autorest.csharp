// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class FirewallPolicyData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity"u8);
                var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
                JsonSerializer.Serialize(writer, Identity, serializeOptions);
            }
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("location"u8);
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(StartupProbe))
            {
                writer.WritePropertyName("startupProbe"u8);
                writer.WriteObjectValue(StartupProbe);
            }
            if (Optional.IsDefined(ReadinessProbe))
            {
                writer.WritePropertyName("readinessProbe"u8);
                writer.WriteObjectValue(ReadinessProbe);
            }
            if (Optional.IsDefined(DesiredStatusCode))
            {
                writer.WritePropertyName("desiredStatusCode"u8);
                writer.WriteNumberValue(DesiredStatusCode.Value.ToSerialInt32());
            }
            if (Optional.IsDefined(BasePolicy))
            {
                writer.WritePropertyName("basePolicy"u8);
                JsonSerializer.Serialize(writer, BasePolicy);
            }
            if (Optional.IsDefined(ThreatIntelWhitelist))
            {
                writer.WritePropertyName("threatIntelWhitelist"u8);
                writer.WriteObjectValue(ThreatIntelWhitelist);
            }
            if (Optional.IsDefined(Insights))
            {
                writer.WritePropertyName("insights"u8);
                writer.WriteObjectValue(Insights);
            }
            if (Optional.IsDefined(Snat))
            {
                writer.WritePropertyName("snat"u8);
                writer.WriteObjectValue(Snat);
            }
            if (Optional.IsDefined(DnsSettings))
            {
                writer.WritePropertyName("dnsSettings"u8);
                writer.WriteObjectValue(DnsSettings);
            }
            if (Optional.IsDefined(IntrusionDetection))
            {
                writer.WritePropertyName("intrusionDetection"u8);
                writer.WriteObjectValue(IntrusionDetection);
            }
            if (Optional.IsDefined(TransportSecurity))
            {
                writer.WritePropertyName("transportSecurity"u8);
                writer.WriteObjectValue(TransportSecurity);
            }
            if (Optional.IsDefined(Sku))
            {
                writer.WritePropertyName("sku"u8);
                writer.WriteObjectValue(Sku);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static FirewallPolicyData DeserializeFirewallPolicyData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> etag = default;
            Optional<ManagedServiceIdentity> identity = default;
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<Probe> startupProbe = default;
            Optional<Probe> readinessProbe = default;
            Optional<DesiredStatusCode> desiredStatusCode = default;
            Optional<IReadOnlyList<WritableSubResource>> ruleCollectionGroups = default;
            Optional<ProvisioningState> provisioningState = default;
            Optional<WritableSubResource> basePolicy = default;
            Optional<IReadOnlyList<WritableSubResource>> firewalls = default;
            Optional<IReadOnlyList<WritableSubResource>> childPolicies = default;
            Optional<FirewallPolicyThreatIntelWhitelist> threatIntelWhitelist = default;
            Optional<FirewallPolicyInsights> insights = default;
            Optional<FirewallPolicySnat> snat = default;
            Optional<DnsSettings> dnsSettings = default;
            Optional<FirewallPolicyIntrusionDetection> intrusionDetection = default;
            Optional<FirewallPolicyTransportSecurity> transportSecurity = default;
            Optional<FirewallPolicySku> sku = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("etag"u8))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("identity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
                    identity = JsonSerializer.Deserialize<ManagedServiceIdentity>(property.Value.GetRawText(), serializeOptions);
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
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
                        if (property0.NameEquals("startupProbe"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            startupProbe = Probe.DeserializeProbe(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("readinessProbe"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            readinessProbe = Probe.DeserializeProbe(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("desiredStatusCode"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            desiredStatusCode = new DesiredStatusCode(property0.Value.GetInt32());
                            continue;
                        }
                        if (property0.NameEquals("ruleCollectionGroups"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<WritableSubResource> array = new List<WritableSubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(JsonSerializer.Deserialize<WritableSubResource>(item.GetRawText()));
                            }
                            ruleCollectionGroups = array;
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningState = new ProvisioningState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("basePolicy"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            basePolicy = JsonSerializer.Deserialize<WritableSubResource>(property0.Value.GetRawText());
                            continue;
                        }
                        if (property0.NameEquals("firewalls"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<WritableSubResource> array = new List<WritableSubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(JsonSerializer.Deserialize<WritableSubResource>(item.GetRawText()));
                            }
                            firewalls = array;
                            continue;
                        }
                        if (property0.NameEquals("childPolicies"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<WritableSubResource> array = new List<WritableSubResource>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(JsonSerializer.Deserialize<WritableSubResource>(item.GetRawText()));
                            }
                            childPolicies = array;
                            continue;
                        }
                        if (property0.NameEquals("threatIntelWhitelist"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            threatIntelWhitelist = FirewallPolicyThreatIntelWhitelist.DeserializeFirewallPolicyThreatIntelWhitelist(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("insights"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            insights = FirewallPolicyInsights.DeserializeFirewallPolicyInsights(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("snat"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            snat = FirewallPolicySnat.DeserializeFirewallPolicySnat(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("dnsSettings"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            dnsSettings = DnsSettings.DeserializeDnsSettings(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("intrusionDetection"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            intrusionDetection = FirewallPolicyIntrusionDetection.DeserializeFirewallPolicyIntrusionDetection(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("transportSecurity"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            transportSecurity = FirewallPolicyTransportSecurity.DeserializeFirewallPolicyTransportSecurity(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("sku"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            sku = FirewallPolicySku.DeserializeFirewallPolicySku(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new FirewallPolicyData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, etag.Value, identity, startupProbe.Value, readinessProbe.Value, Optional.ToNullable(desiredStatusCode), Optional.ToList(ruleCollectionGroups), Optional.ToNullable(provisioningState), basePolicy, Optional.ToList(firewalls), Optional.ToList(childPolicies), threatIntelWhitelist.Value, insights.Value, snat.Value, dnsSettings.Value, intrusionDetection.Value, transportSecurity.Value, sku.Value);
        }
    }
}
