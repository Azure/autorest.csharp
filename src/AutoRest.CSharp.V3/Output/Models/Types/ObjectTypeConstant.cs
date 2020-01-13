// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
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
