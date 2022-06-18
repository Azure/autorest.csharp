// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class PropertySerializedNameAttribute : Attribute
    {
        internal PropertySerializedNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
