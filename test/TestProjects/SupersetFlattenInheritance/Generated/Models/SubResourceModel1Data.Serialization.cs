// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace SupersetFlattenInheritance
{
    public partial class SubResourceModel1Data : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Foo))
            {
                writer.WritePropertyName("foo");
                writer.WriteStringValue(Foo);
            }
            writer.WriteEndObject();
        }

        internal static SubResourceModel1Data DeserializeSubResourceModel1Data(JsonElement element)
        {
            Optional<string> foo = default;
            ResourceIdentifier id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("foo"))
                {
                    foo = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new SubResourceModel1Data(id, foo.Value);
        }
    }
}
