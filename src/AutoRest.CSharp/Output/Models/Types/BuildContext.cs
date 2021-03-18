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
        private TypeFactory? _typeFactory;
        public OutputLibrary Library { get; private set; }

        public BuildContext(CodeModel codeModel, Configuration configuration, SourceInputModel? sourceInputModel)
        {
            CodeModel = codeModel;
            SchemaUsageProvider = new SchemaUsageProvider(codeModel);
            Configuration = configuration;
            SourceInputModel = sourceInputModel;

            if (configuration.LowLevelClient)
            {
                Library = new LowLevelOutputLibrary(CodeModel, this);
            }
            else
            {
                Library = new HighLevelOutputLibrary(CodeModel, this);
            }
        }

        public CodeModel CodeModel { get; }
        public SchemaUsageProvider SchemaUsageProvider { get; }
        public string DefaultNamespace => Configuration.Namespace ?? CodeModel.Language.Default.Name;
        public string DefaultLibraryName => Configuration.LibraryName ?? CodeModel.Language.Default.Name;
        public TypeFactory TypeFactory => _typeFactory ??= new TypeFactory(Library);
        public Configuration Configuration { get; }
        public SourceInputModel? SourceInputModel { get; }
    }
}
