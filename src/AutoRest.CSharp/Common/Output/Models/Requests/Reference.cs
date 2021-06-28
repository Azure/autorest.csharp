// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal readonly struct Reference
    {
        public Reference(string name, CSharpType type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public CSharpType Type { get; }
    }
}
