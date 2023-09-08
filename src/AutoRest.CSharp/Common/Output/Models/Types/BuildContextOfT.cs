// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;

namespace AutoRest.CSharp.Output.Models.Types
{
#pragma warning disable SA1649 // File name should match first type name
    internal class BuildContext<T> : BuildContext where T : OutputLibrary
#pragma warning restore SA1649 // File name should match first type name
    {
        private T? _library;
        public T Library => _library ??= EnsureLibrary();

        private T EnsureLibrary()
        {
            T library;
            if (Configuration.Generation1ConvenienceClient)
            {
                throw new InvalidOperationException($"{nameof(BuildContext)} isn't supported in legacy DataPlane");
            }

            if (Configuration.AzureArm)
            {
                library = (T)(object)new MgmtOutputLibrary(CodeModel, SchemaUsageProvider);
            }
            else
            {
                throw new InvalidOperationException($"{nameof(BuildContext)} isn't supported in DPG");
            }
            BaseLibrary = library;
            return library;
        }

        public BuildContext(CodeModel codeModel, SourceInputModel? sourceInputModel)
            : base(codeModel, sourceInputModel)
        {
        }
    }
}
