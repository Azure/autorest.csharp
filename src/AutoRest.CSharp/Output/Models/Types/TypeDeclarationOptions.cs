// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class TypeDeclarationOptions
    {
        public TypeDeclarationOptions(string name, string ns, string accessibility, bool isUserDefined)
        {
            Name = name;
            Namespace = ns;
            Accessibility = accessibility;
            IsUserDefined = isUserDefined;
        }

        public string Name { get; }
        public string Namespace { get; }
        public string Accessibility { get; }
        public bool IsUserDefined { get; }
    }
}
