// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class MemberDeclarationOptions
    {
        public MemberDeclarationOptions(string accessibility, string name, CSharpType type, bool isUserDefined)
        {
            Accessibility = accessibility;
            Name = name;
            Type = type;
            IsUserDefined = isUserDefined;
        }

        public string Accessibility { get; }
        public string Name { get; }
        public CSharpType Type { get; }
        public bool IsUserDefined { get; }
    }
}