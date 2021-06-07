// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class TupleResourceContainerWriter : ResourceContainerWriter
    {
        public TupleResourceContainerWriter(CodeWriter writer, ResourceContainer resourceContainer, MgmtOutputLibrary library)
            : base(writer, resourceContainer, library)
        {
        }
    }
}
