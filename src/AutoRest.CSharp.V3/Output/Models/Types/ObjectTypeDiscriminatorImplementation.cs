// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class ObjectTypeDiscriminatorImplementation
    {
        public ObjectTypeDiscriminatorImplementation(string key, CSharpType type, bool isDirect)
        {
            Key = key;
            Type = type;
            IsDirect = isDirect;
        }

        public string Key { get; }
        public CSharpType Type { get; }
        public bool IsDirect { get; }
    }
}
