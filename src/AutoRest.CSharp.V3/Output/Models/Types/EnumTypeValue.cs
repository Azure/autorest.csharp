// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.Shared;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class EnumTypeValue
    {
        public EnumTypeValue(string name, string description, Constant value)
        {
            Name = name;
            Description = description;
            Value = value;
        }

        public string Name { get; }
        public Constant Value { get; }
        public string Description { get; }
    }
}
