// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;

#pragma warning disable SA1402
namespace AutoRest.CSharp.Output.Models.Types
{
    internal class BuildContext
    {
        public BuildContext(CodeModel codeModel, Configuration configuration, SourceInputModel? sourceInputModel)
        {
            CodeModel = codeModel;
            SchemaUsageProvider = new SchemaUsageProvider(codeModel);
            Configuration = configuration;
            SourceInputModel = sourceInputModel;

        }

        public CodeModel CodeModel { get; }
        public SchemaUsageProvider SchemaUsageProvider { get; }
        public string DefaultNamespace => Configuration.Namespace ?? CodeModel.Language.Default.Name;
        public string DefaultLibraryName => Configuration.LibraryName ?? CodeModel.Language.Default.Name;
        public Configuration Configuration { get; }
        public SourceInputModel? SourceInputModel { get; }
        public virtual TypeFactory TypeFactory { get; } = null!;
    }

    internal class BuildContext<T> : BuildContext where T: OutputLibrary
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
                Library = (T)(object)new HighLevelOutputLibrary(codeModel, (BuildContext<HighLevelOutputLibrary>)(object)this);
            }
        }

        public override TypeFactory TypeFactory => _typeFactory ??= new TypeFactory(Library);
    }
}
