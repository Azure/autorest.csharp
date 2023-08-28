// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Xml;
using Azure.Core.Serialization;

namespace Azure.Core
{
    internal interface IXmlSerializable
    {
        void Write(XmlWriter writer, string? nameHint);
    }
}
