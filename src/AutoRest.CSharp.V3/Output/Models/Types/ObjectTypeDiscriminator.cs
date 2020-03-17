// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class ObjectTypeDiscriminator
    {
        public ObjectTypeProperty Property { get; }
        public string SerializedName { get; }

        public string? Value { get; }

        public ObjectTypeDiscriminatorImplementation[] Implementations { get; }

        public ObjectTypeDiscriminator(ObjectTypeProperty property, string serializedName, ObjectTypeDiscriminatorImplementation[] implementations, string? value)
        {
            Property = property;
            Implementations = implementations;
            Value = value;
            SerializedName = serializedName;
        }

        public bool HasDescendants => Implementations.Any();
    }
}
