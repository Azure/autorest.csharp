// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models.Types
{
#pragma warning disable SA1649 // File name should match first type name
    internal class BuildContext<T> : BuildContext where T: OutputLibrary
#pragma warning restore SA1649 // File name should match first type name
    {
        private TypeFactory? _typeFactory;

        public T Library { get; private set; }

        public BuildContext(CodeModel codeModel, Configuration configuration, SourceInputModel? sourceInputModel): base(codeModel, configuration, sourceInputModel)
        {
            if (configuration.LowLevelClient)
            {
                Library = (T)(object)new LowLevelOutputLibrary(codeModel, (BuildContext<LowLevelOutputLibrary>)(object)this);
            }
            else
            {
                Library = (T)(object)new DataPlaneOutputLibrary(codeModel, (BuildContext<DataPlaneOutputLibrary>)(object)this);
            }
        }

        public override TypeFactory TypeFactory => _typeFactory ??= new TypeFactory(Library);
    }
}
