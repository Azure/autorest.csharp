// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal abstract class MgmtTypeProvider : TypeProvider
    {
        public abstract RequestPath ContextualPath { get; }

        protected MgmtTypeProvider(BuildContext context) : base(context)
        {
        }
    }
}
