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
        public EmptyResourceData(MgmtOutputLibrary library, InputModelType inputModel, TypeFactory typeFactory, SourceInputModel? sourceInputModel, string? newName = null)
            : base(library, inputModel, typeFactory, sourceInputModel, newName)
        { }

        // we never need anything in the empty resource data
        internal override bool ShouldSetResourceIdentifier => false;
    }
}
