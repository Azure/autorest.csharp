// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class MemberDeclarationOptions
    {
        public MemberDeclarationOptions(string accessibility, string name, CSharpType type)
        {
            Accessibility = accessibility;
            Name = name;
            Type = type;
        }

        public string Accessibility { get; }
        public string Name { get; }
        public CSharpType Type { get; }

        public string GetPropertyName()
        {
            const string properties = "Properties";
            if (this.Name.Equals(properties, StringComparison.Ordinal))
            {
                string typeName = this.Type.Name;
                int index = typeName.IndexOf(properties);
                if (index > -1 && index + properties.Length == typeName.Length)
                    return typeName.Substring(0, index);

                return typeName;
            }
            return this.Name;
        }
    }
}
