// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtMultipleParentResource
{
    public partial class AnotherParentData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags");
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("location");
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties");
            writer.WriteStartObject();
            if (Optional.IsDefined(AsyncExecution))
            {
                writer.WritePropertyName("asyncExecution");
                writer.WriteBooleanValue(AsyncExecution.Value);
            }
            if (Optional.IsDefined(RunAsUser))
            {
                writer.WritePropertyName("runAsUser");
                writer.WriteStringValue(RunAsUser);
            }
            if (Optional.IsDefined(RunAsPassword))
            {
                writer.WritePropertyName("runAsPassword");
                writer.WriteStringValue(RunAsPassword);
            }
            if (Optional.IsDefined(TimeoutInSeconds))
            {
                writer.WritePropertyName("timeoutInSeconds");
                writer.WriteNumberValue(TimeoutInSeconds.Value);
            }
            if (Optional.IsDefined(OutputBlobUri))
            {
                writer.WritePropertyName("outputBlobUri");
                writer.WriteStringValue(OutputBlobUri.AbsoluteUri);
            }
            if (Optional.IsDefined(ErrorBlobUri))
            {
                writer.WritePropertyName("errorBlobUri");
                writer.WriteStringValue(ErrorBlobUri.AbsoluteUri);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static AnotherParentData DeserializeAnotherParentData(JsonElement element)
        {
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            Optional<ResourceIdentifier> id = default;
            Optional<string> name = default;
            Optional<ResourceType> type = default;
            Optional<SystemData> systemData = default;
            Optional<bool> asyncExecution = default;
            Optional<string> runAsUser = default;
            Optional<string> runAsPassword = default;
            Optional<int> timeoutInSeconds = default;
            Optional<Uri> outputBlobUri = default;
            Optional<Uri> errorBlobUri = default;
            Optional<string> provisioningState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tags"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
                if (property.NameEquals("location"))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
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
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
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
                        if (property0.NameEquals("asyncExecution"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            asyncExecution = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("runAsUser"))
                        {
                            runAsUser = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("runAsPassword"))
                        {
                            runAsPassword = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("timeoutInSeconds"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            timeoutInSeconds = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("outputBlobUri"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                outputBlobUri = null;
                                continue;
                            }
                            outputBlobUri = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("errorBlobUri"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                errorBlobUri = null;
                                continue;
                            }
                            errorBlobUri = new Uri(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new AnotherParentData(id, name, type, systemData, Optional.ToDictionary(tags), location, Optional.ToNullable(asyncExecution), runAsUser.Value, runAsPassword.Value, Optional.ToNullable(timeoutInSeconds), outputBlobUri.Value, errorBlobUri.Value, provisioningState.Value);
        }
    }
}
