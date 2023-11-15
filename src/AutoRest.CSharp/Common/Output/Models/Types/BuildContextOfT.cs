// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models.Types
{
#pragma warning disable SA1649 // File name should match first type name
    internal class BuildContext<T> : BuildContext where T : OutputLibrary
#pragma warning restore SA1649 // File name should match first type name
    {
        public BuildContext(CodeModel codeModel, SourceInputModel? sourceInputModel)
            : base(codeModel, sourceInputModel)
        {
        }
    }
}
