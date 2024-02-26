// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;

namespace AutoRest.CSharp.Output.Models.Types
{
#pragma warning disable SA1649 // File name should match first type name
    internal class BuildContext<T> : BuildContext where T : OutputLibrary
#pragma warning restore SA1649 // File name should match first type name
    {
        private TypeFactory? _typeFactory;
        private InputNamespace? _inputNamespace;

        private T? _library;
        public T Library => _library ??= EnsureLibrary();

        private T EnsureLibrary()
        {
            T library;
            if (Configuration.Generation1ConvenienceClient)
            {
                library = (T)(object)new DataPlaneOutputLibrary(CodeModel!, (BuildContext<DataPlaneOutputLibrary>)(object)this);
            }
            else if (Configuration.AzureArm)
            {
                library = (T)(object)new MgmtOutputLibrary(_inputNamespace!);
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
            CodeModelTransformer.Transform(codeModel);
            _inputNamespace = new CodeModelConverter(codeModel).CreateNamespace();
        }

        public override TypeFactory TypeFactory => _typeFactory ??= new TypeFactory(Library);
    }
}
