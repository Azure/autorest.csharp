// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal class ModelReaderWriterContextProvider : TypeProvider
    {
        public ModelReaderWriterContextProvider(BuildContext context) : base(context)
        {
            DefaultName = $"{context.DefaultNamespace.RemovePeriods()}Context";
            DefaultAccessibility = "public";
        }

        public ModelReaderWriterContextProvider(string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            DefaultName = $"{defaultNamespace.RemovePeriods()}Context";
            DefaultAccessibility = "public";
        }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; }
    }
}
