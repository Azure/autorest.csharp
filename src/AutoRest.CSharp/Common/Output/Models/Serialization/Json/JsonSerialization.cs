// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal abstract class JsonSerialization: ObjectSerialization
    {
        protected JsonSerialization(bool isNullable, string? version = null)
        {
            IsNullable = isNullable;
            Version = version;
        }

        public bool IsNullable { get; }

        public string? Version { get; }
    }
}
