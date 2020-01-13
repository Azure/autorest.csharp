// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
    internal abstract class XmlElementSerialization: ObjectSerialization
    {
        public abstract string Name { get; }
        public abstract TypeReference Type { get; }
    }
}
