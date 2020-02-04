// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Serialization;


namespace AutoRest.CSharp.V3.Output.Models.Responses
{
    internal class ObjectResponseBody: ResponseBody
    {
        public ObjectResponseBody(CSharpType type, ObjectSerialization serialization)
        {
            Serialization = serialization;
            Type = type;
        }

        public ObjectSerialization Serialization { get; }
        public override CSharpType Type { get; }
    }
}
