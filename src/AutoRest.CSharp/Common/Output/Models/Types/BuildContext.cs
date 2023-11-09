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

        public BuildContext(InputNamespace inputNamespace, CodeModel codeModel, SourceInputModel? sourceInputModel) : this(inputNamespace, codeModel, sourceInputModel, Configuration.Namespace)
        { }

        public BuildContext(InputNamespace inputNamespace, CodeModel codeModel, SourceInputModel? sourceInputModel, string defaultNamespace)
        {
            CodeModel = codeModel;
            SourceInputModel = sourceInputModel;
            DefaultNamespace = defaultNamespace;
            InputNamespace = inputNamespace;
        }

        public OutputLibrary? BaseLibrary { get; protected set; }

        public CodeModel CodeModel { get; }
        public string DefaultNamespace { get; }
        public SourceInputModel? SourceInputModel { get; }
        public virtual TypeFactory TypeFactory { get; } = null!;
        public InputNamespace InputNamespace { get; }
    }
}
