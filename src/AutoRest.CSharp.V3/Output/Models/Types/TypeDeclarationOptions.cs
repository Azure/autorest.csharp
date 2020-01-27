// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class TypeDeclarationOptions
    {
        public TypeDeclarationOptions(string name, string ns, string accessibility)
        {
            Name = name;
            Namespace = ns;
            Accessibility = accessibility;
        }

        public string Name { get; }
        public string Namespace { get; }
        public string Accessibility { get; }
    }
}
