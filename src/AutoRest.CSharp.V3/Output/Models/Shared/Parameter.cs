// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Shared
{
    internal class Parameter
    {
        public Parameter(string name, string? description, CSharpType type, Constant? defaultValue, bool isRequired, bool isArtificial = false)
        {
            Name = name;
            Description = description;
            Type = type;
            DefaultValue = defaultValue;
            IsRequired = isRequired;
            IsArtificial = isArtificial;
        }

        public CSharpType Type { get; }
        public string Name { get; }
        public string? Description { get; }
        public Constant? DefaultValue { get; }
        public bool IsRequired { get; }
        // Indicates the parameter was created by the generator, not defined in the swagger
        public bool IsArtificial { get; }
    }
}
