// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Input.Source;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class BuildContext
    {
        public BuildContext(string defaultNamespace, TypeFactory typeFactory, SourceInputModel sourceInputModel, KnownMediaType[] supportedMediaTypes)
        {
            DefaultNamespace = defaultNamespace;
            TypeFactory = typeFactory;
            SourceInputModel = sourceInputModel;
            SupportedMediaTypes = supportedMediaTypes;
        }

        public string DefaultNamespace { get; }
        public TypeFactory TypeFactory { get; }
        public SourceInputModel SourceInputModel { get; }
        public KnownMediaType[] SupportedMediaTypes { get; }
    }
}