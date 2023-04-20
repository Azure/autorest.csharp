// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class BuildContext
    {
        public BuildContext(CodeModel codeModel, SourceInputModel? sourceInputModel)
        {
            CodeModel = codeModel;
            SchemaUsageProvider = new SchemaUsageProvider(codeModel);
            SourceInputModel = sourceInputModel;
        }

        public OutputLibrary? BaseLibrary { get; protected set; }

        public CodeModel CodeModel { get; }
        public SchemaUsageProvider SchemaUsageProvider { get; }
        public string DefaultName => CodeModel.Language.Default.Name;
        public string DefaultNamespace => Configuration.Namespace ?? DefaultName;
        public SourceInputModel? SourceInputModel { get; }
    }
}
