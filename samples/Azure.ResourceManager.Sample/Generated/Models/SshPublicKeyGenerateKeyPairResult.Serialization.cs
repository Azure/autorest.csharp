// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample
{
    public partial class SshPublicKeyGenerateKeyPairResult
    {
        internal static SshPublicKeyGenerateKeyPairResult DeserializeSshPublicKeyGenerateKeyPairResult(JsonElement element)
        {
            string privateKey = default;
            string publicKey = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("privateKey"))
                {
                    privateKey = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("publicKey"))
                {
                    publicKey = property.Value.GetString();
                    continue;
                }
            }
            return new SshPublicKeyGenerateKeyPairResult(privateKey, publicKey);
        }
    }
}
