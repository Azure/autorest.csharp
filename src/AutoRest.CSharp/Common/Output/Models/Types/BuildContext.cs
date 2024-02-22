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
        public BuildContext(CodeModel? codeModel, SourceInputModel? sourceInputModel, InputNamespace? inputNamespace = null) : this(codeModel, sourceInputModel,Configuration.LibraryName, Configuration.Namespace, inputNamespace)
        { }

        public BuildContext(CodeModel? codeModel, SourceInputModel? sourceInputModel, string defaultLibraryName, string defaultNamespace, InputNamespace? inputNamespace = null)
        {
            CodeModel = codeModel;
            SchemaUsageProvider = codeModel is null ? null : new SchemaUsageProvider(codeModel);
            InputModelTypeUsageProvider = inputNamespace is null ? null : new InputTypeUsageProvider(inputNamespace);
            SourceInputModel = sourceInputModel;
            DefaultLibraryName = defaultLibraryName;
            DefaultNamespace = defaultNamespace;
            InputNamespace = inputNamespace;
        }

        public OutputLibrary? BaseLibrary { get; protected set; }

        public InputNamespace? InputNamespace { get; } = null;
        public CodeModel? CodeModel { get; }
        public SchemaUsageProvider? SchemaUsageProvider { get; }
        public InputTypeUsageProvider? InputModelTypeUsageProvider { get; }
        public string DefaultNamespace { get; }
        public string DefaultLibraryName { get; }
        public SourceInputModel? SourceInputModel { get; }
        public virtual TypeFactory TypeFactory { get; } = null!;
    }
}
