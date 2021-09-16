// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using AutoRest.CSharp.AutoRest.Communication;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    /// <summary>
    /// The model for a "csharp-client-configuration" stanza for AutoRest configuration.
    ///
    /// The "csharp-client-configuration" is an array of client configuration objects. A
    /// client configuration object is either a string (an operation group name) or an object
    /// a name (again, an operation group name) and optional emitPublicConstructor boolean parameter
    /// and an optional subClients array of client configurations for all the sub clients.
    /// </summary>
    internal class LowLevelSubClientConfiguration
    {
        private const string ClientConfigurationPropertyName = "csharp-client-configuration";

        public LowLevelClientConfiguration[] ClientConfigurations { get; }

        private LowLevelSubClientConfiguration(LowLevelClientConfiguration[] clientConfigurations)
        {
            ClientConfigurations = clientConfigurations;
        }

        internal static LowLevelSubClientConfiguration GetConfiguration(IPluginCommunication autoRest)
        {
            var clientConfigurations = Array.Empty<LowLevelClientConfiguration>();

            var subClientConfigurationElement = autoRest.GetValue<JsonElement?>(ClientConfigurationPropertyName).GetAwaiter().GetResult();

            if (IsValidArrayElement(subClientConfigurationElement))
            {
                clientConfigurations = subClientConfigurationElement!.Value.EnumerateArray().Select(LowLevelClientConfiguration.ReadFromJson).ToArray();
            }

            return new LowLevelSubClientConfiguration(clientConfigurations);
        }

        private static bool IsValidArrayElement(JsonElement? element) => element.HasValue && element.Value.ValueKind == JsonValueKind.Array;

        internal void SaveConfiguration(Utf8JsonWriter writer)
        {
            if (ClientConfigurations.Any())
            {
                writer.WriteStartArray(ClientConfigurationPropertyName);
                foreach (var configuration in ClientConfigurations)
                {
                    configuration.WriteTo(writer);
                }
                writer.WriteEndArray();
            }
        }

        internal static LowLevelSubClientConfiguration LoadConfiguration(JsonElement root)
        {
            var clientConfigurations = Array.Empty<LowLevelClientConfiguration>();

            if (root.TryGetProperty(ClientConfigurationPropertyName, out JsonElement subClientConfigurationElement))
            {
                clientConfigurations = subClientConfigurationElement.EnumerateArray().Select(LowLevelClientConfiguration.ReadFromJson).ToArray();
            }

            return new LowLevelSubClientConfiguration(clientConfigurations);
        }
    }

    internal record LowLevelClientConfiguration(string OperationGroupName, bool? EmitPublicConstructor, LowLevelClientConfiguration[] SubClients)
    {
        public const string OperationGroupNamePropertyName = "name";
        public const string EmitPublicConstructorPropertyName = "emitPublicConstructor";
        public const string SubClientsPropertyName = "subClients";

        public static LowLevelClientConfiguration ReadFromJson(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.String)
            {
                return new LowLevelClientConfiguration(element.GetString(), null, Array.Empty<LowLevelClientConfiguration>());
            }
            else if (element.ValueKind == JsonValueKind.Object)
            {
                string? operationGroupName = null;
                bool? emitPublicConstructor = null;
                LowLevelClientConfiguration[]? subClientConfiguration = Array.Empty<LowLevelClientConfiguration>();

                foreach (JsonProperty property in element.EnumerateObject())
                {
                    switch (property.Name)
                    {
                        case OperationGroupNamePropertyName:
                            operationGroupName = property.Value.GetString();
                            break;
                        case EmitPublicConstructorPropertyName:
                            emitPublicConstructor = property.Value.GetBoolean();
                            break;
                        case SubClientsPropertyName:
                            subClientConfiguration = property.Value.EnumerateArray().Select(ReadFromJson).ToArray();
                            break;
                    }
                }

                if (operationGroupName == null)
                {
                    throw new Exception("Bad client configuration (missing 'name' key)");
                }

                return new LowLevelClientConfiguration(operationGroupName, emitPublicConstructor, subClientConfiguration);
            }

            throw new Exception("Bad client configuration    (not a string or an object)");

        }
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (!EmitPublicConstructor.HasValue && !SubClients.Any())
            {
                writer.WriteStringValue(OperationGroupName);
            }
            else
            {
                writer.WriteStartObject();
                writer.WriteString(OperationGroupNamePropertyName, OperationGroupName);
                if (EmitPublicConstructor.HasValue)
                {
                    writer.WriteBoolean(EmitPublicConstructorPropertyName, EmitPublicConstructor.Value);
                }
                if (SubClients.Any())
                {
                    writer.WriteStartArray(SubClientsPropertyName);
                    foreach (var subClient in SubClients)
                    {
                        subClient.WriteTo(writer);
                    }
                    writer.WriteEndArray();
                }
                writer.WriteEndObject();
            }
        }
    }
}
