// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class SshPublicKeyGenerateKeyPairResult
    {
        internal static SshPublicKeyGenerateKeyPairResult DeserializeSshPublicKeyGenerateKeyPairResult(JsonElement element)
        {
            string privateKey = default;
            string publicKey = default;
            string id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("privateKey"u8))
                {
                    privateKey = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("publicKey"u8))
                {
                    publicKey = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new SshPublicKeyGenerateKeyPairResult(privateKey, publicKey, id);
        }
    }
}
