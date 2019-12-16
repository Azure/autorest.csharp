// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientObjectDiscriminatorImplementation
    {
        public ClientObjectDiscriminatorImplementation(string key, SchemaTypeReference type, bool isDirect)
        {
            Key = key;
            Type = type;
            IsDirect = isDirect;
        }

        public string Key { get; }
        public SchemaTypeReference Type { get; }
        public bool IsDirect { get; }
    }
}
