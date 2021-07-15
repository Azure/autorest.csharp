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
    internal class TupleResourceOperationWriter : ResourceOperationWriter
    {
        protected override Type BaseClass => typeof(OperationsBase);

        public TupleResourceOperationWriter(CodeWriter writer, ResourceOperation resourceOperation, BuildContext<MgmtOutputLibrary> context) : base(writer, resourceOperation, context)
        {
        }
    }
}
