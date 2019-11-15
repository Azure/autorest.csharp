// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Dns.Models.V20180501
{
    public partial class SubResource
    {
        public string? Id { get; set; }
    }

    public partial class SubResource
    {
        public void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("subResource");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Id != null)
            {
                writer.WriteString("id", Id);
            }
            writer.WriteEndObject();
        }
    }
}
