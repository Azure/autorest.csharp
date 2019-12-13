// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientObjectDiscriminator
    {
        // TODO: I'm not a fan of addressing the property by a string name, should be represented by property reference
        public string Property { get; }
        public string SerializedName { get; }

        public string Value { get; }

        public IDictionary<string, SchemaTypeReference> Implementations { get; }

        public ClientObjectDiscriminator(string property, string serializedName, IDictionary<string, SchemaTypeReference> implementations, string value)
        {
            Property = property;
            Implementations = implementations;
            Value = value;
            SerializedName = serializedName;
        }
    }
}
