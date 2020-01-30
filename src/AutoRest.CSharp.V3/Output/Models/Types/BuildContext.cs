// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Input.Source;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class BuildContext
    {
        private readonly CodeModel _codeModel;
        private OutputLibrary? _library;
        private TypeFactory? _typeFactory;

        public BuildContext(CodeModel codeModel, string defaultNamespace, SourceInputModel sourceInputModel)
        {
            _codeModel = codeModel;
            DefaultNamespace = defaultNamespace;
            SourceInputModel = sourceInputModel;
        }

        public OutputLibrary Library => _library ??= new OutputLibrary(_codeModel, this);
        public string DefaultNamespace { get; }
        public TypeFactory TypeFactory => _typeFactory ??= new TypeFactory(Library);
        public SourceInputModel SourceInputModel { get; }
    }
}