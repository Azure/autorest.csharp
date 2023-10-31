// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal abstract class JsonSerialization: ObjectSerialization
    {
        protected JsonSerialization(CSharpType type, bool isNullable, JsonSerializationOptions options = JsonSerializationOptions.None)
        {
            Type = type;
            IsNullable = isNullable;
            Options = options;
        }

        public CSharpType Type { get; }

        public bool IsNullable { get; }

        public JsonSerializationOptions Options { get; }
    }
}
