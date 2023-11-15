// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation;

internal class PartialResourceWriter : ResourceWriter
{
    private PartialResource This { get; }

    internal PartialResourceWriter(PartialResource resource, IEnumerable<Resource> armResources) : this(new CodeWriter(), resource, armResources)
    {
    }

    protected PartialResourceWriter(CodeWriter writer, PartialResource resource, IEnumerable<Resource> armResources) : base(writer, resource, armResources)
    {
        This = resource;
    }

    protected override void WriteProperties()
    {
        _writer.WriteXmlDocumentationSummary($"Gets the resource type for the operations");

        _writer.Line($"public static readonly {typeof(ResourceType)} ResourceType = \"{This.ResourceType}\";");
        _writer.Line();

        // comparing with the `ResourceWriter`, `PartialResourceWriter` does not write the `public XXXData { get; }` property because partial resources do not have resource data.

        _writer.Line();
        WriteStaticValidate($"ResourceType");
    }
}
