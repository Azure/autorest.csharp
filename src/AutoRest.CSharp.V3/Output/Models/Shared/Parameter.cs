// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class Parameter
    {
        public Parameter(string name, string? description, TypeReference type, Constant? defaultValue, bool isRequired, ParameterLocation? location)
        {
            Name = name;
            Description = description;
            Type = type;
            DefaultValue = defaultValue;
            IsRequired = isRequired;
            Location = location;
        }

        public TypeReference Type { get; }
        public string Name { get; }
        public string? Description { get; }
        public Constant? DefaultValue { get; }
        public bool IsRequired { get; }
        public ParameterLocation? Location { get; }
    }
}
