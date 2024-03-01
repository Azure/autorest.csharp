// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class GenericParamTypeProvider : TypeProvider
    {
        public GenericParamTypeProvider(string name, string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
            DefaultName = name;
        }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";
    }
}
