// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class TupleResourceOperationWriter : ResourceOperationWriter
    {
        protected override Type BaseClass => typeof(OperationsBase);
    }
}
