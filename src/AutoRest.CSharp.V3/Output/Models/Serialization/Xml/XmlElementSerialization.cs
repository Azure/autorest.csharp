﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Xml
{
    internal abstract class XmlElementSerialization: ObjectSerialization
    {
        public abstract string Name { get; }
    }
}
