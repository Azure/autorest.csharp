// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.Output.Models.Serialization.Json
{
    internal abstract class JsonSerialization : ObjectSerialization
    {
        protected JsonSerialization(bool isNullable, JsonSerializationOptions options = JsonSerializationOptions.None)
        {
            IsNullable = isNullable;
            Options = options;
        }

        public bool IsNullable { get; }

        public JsonSerializationOptions Options { get; }
    }
}
