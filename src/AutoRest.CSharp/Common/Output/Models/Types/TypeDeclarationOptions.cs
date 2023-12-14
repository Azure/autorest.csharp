// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class TypeDeclarationOptions
    {
        public TypeDeclarationOptions(string name, string ns, string accessibility, bool isAbstract)
        {
            Name = name;
            Namespace = ns;
            Accessibility = accessibility;
            IsAbstract = isAbstract;
            FullName = $"{Namespace}.{Name}";
        }

        public string Name { get; }
        public string Namespace { get; }
        public string Accessibility { get; }
        public bool IsAbstract { get; }
        public string FullName { get; }
    }
}
