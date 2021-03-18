// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Shared
{
    internal class Parameter
    {
        public Parameter(string name, string? description, CSharpType type, Constant? defaultValue, bool validateNotNull, bool isApiVersionParameter = false)
        {
            Name = name;
            Description = description;
            Type = type;
            DefaultValue = defaultValue;
            ValidateNotNull = validateNotNull;
            IsApiVersionParameter = isApiVersionParameter;
        }

        public CSharpType Type { get; }
        public string Name { get; }
        public string? Description { get; }
        public Constant? DefaultValue { get; }
        public bool ValidateNotNull { get; }
        public bool IsApiVersionParameter { get; }
    }
}
