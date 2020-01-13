// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.TypeReferences;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class ObjectTypeConstant
    {
        public ObjectTypeConstant(string name, FrameworkTypeReference type, Constant value)
        {
            Name = name;
            Type = type;
            Value = value;
        }

        public string Name { get; }
        public TypeReference Type { get; }
        public Constant Value { get; }
    }
}
