// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class BuildContext
    {
        public BuildContext(InputNamespace inputNamespace, SourceInputModel? sourceInputModel) : this(inputNamespace, sourceInputModel,Configuration.LibraryName, Configuration.Namespace)
        { }

        public BuildContext(InputNamespace inputNamespace, SourceInputModel? sourceInputModel, string defaultLibraryName, string defaultNamespace)
        {
            SourceInputModel = sourceInputModel;
            DefaultLibraryName = defaultLibraryName;
            DefaultNamespace = defaultNamespace;
            InputNamespace = inputNamespace;
        }

        public OutputLibrary? BaseLibrary { get; protected set; }

        public InputNamespace InputNamespace { get; }
        public string DefaultNamespace { get; }
        public string DefaultLibraryName { get; }
        public SourceInputModel? SourceInputModel { get; }
        public virtual TypeFactory TypeFactory { get; } = null!;
    }
}
