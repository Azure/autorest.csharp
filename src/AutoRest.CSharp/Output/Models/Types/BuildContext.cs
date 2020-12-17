// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class BuildContext
    {
        private OutputLibrary? _library;
        private TypeFactory? _typeFactory;

        public BuildContext(CodeModel codeModel, Configuration configuration, SourceInputModel sourceInputModel)
        {
            CodeModel = codeModel;
            SchemaUsageProvider = new SchemaUsageProvider(codeModel);
            Configuration = configuration;
            SourceInputModel = sourceInputModel;
        }

        public CodeModel CodeModel { get; }
        public SchemaUsageProvider SchemaUsageProvider { get; }
        public OutputLibrary Library => _library ??= new OutputLibrary(CodeModel, this);
        public string DefaultNamespace => Configuration.Namespace;
        public TypeFactory TypeFactory => _typeFactory ??= new TypeFactory(Library);
        public Configuration Configuration { get; }
        public SourceInputModel SourceInputModel { get; }
    }
}