// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class TupleResourceWriter : ResourceWriter
    {
        protected override Type BaseClass => typeof(ArmResource);

        public TupleResourceWriter(CodeWriter writer, Resource resource, BuildContext<MgmtOutputLibrary> context) : base(writer, resource, context)
        {
        }
    }
}
