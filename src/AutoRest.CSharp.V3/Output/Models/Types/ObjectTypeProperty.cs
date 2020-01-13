// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.TypeReferences;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class ObjectTypeProperty
    {
        public ObjectTypeProperty(string name, string description, TypeReference type, bool isReadOnly, Constant? defaultValue = null)
        {
            Name = name;
            Description = description;
            Type = type;
            IsReadOnly = isReadOnly;
            DefaultValue = defaultValue;
        }

        public string Name { get; }
        public string Description { get; }
        public Constant? DefaultValue { get; }
        public TypeReference Type { get; }
        public bool IsReadOnly { get; }
     }
}
