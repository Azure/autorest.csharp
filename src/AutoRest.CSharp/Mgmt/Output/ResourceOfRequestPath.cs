// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceOfRequestPath : TypeProvider
    {
        public RequestPath RequestPath { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        public ResourceOfRequestPath(RequestPath requestPath, string name, BuildContext<MgmtOutputLibrary> context) : base(context)
        {
            RequestPath = requestPath;
            DefaultName = name;
        }

        public override string? ToString()
        {
            return $"{DefaultName}({RequestPath})";
        }
    }
}
