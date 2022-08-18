// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class BaseResourceWriter : MgmtClientBaseWriter
    {
        private BaseResource This { get; }
        public BaseResourceWriter(CodeWriter writer, BaseResource baseResource) : base(writer, baseResource)
        {
            This = baseResource;
        }
    }
}
