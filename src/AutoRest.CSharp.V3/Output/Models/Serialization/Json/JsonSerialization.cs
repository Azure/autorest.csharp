// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal abstract class JsonSerialization: ObjectSerialization
    {
        public abstract CSharpType Type { get; }
    }
}
