// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class EmptyResourceData : ResourceData
    {
        public EmptyResourceData(InputModelType inputModel, TypeFactory typeFactory, string? newName = null)
            : base(inputModel, typeFactory, newName)
        { }

        // we never need anything in the empty resource data
        internal override bool ShouldSetResourceIdentifier => false;
    }
}
