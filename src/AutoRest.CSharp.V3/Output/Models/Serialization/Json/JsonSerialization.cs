// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal abstract class JsonSerialization: ObjectSerialization
    {
        protected JsonSerialization(bool isNullable)
        {
            IsNullable = isNullable;
        }

        public bool IsNullable { get; }
    }
}
