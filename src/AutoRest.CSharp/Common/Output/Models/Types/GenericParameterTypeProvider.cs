// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class GenericParameterTypeProvider : TypeProvider
    {
        public GenericParameterTypeProvider(string name)
            : base(Configuration.Namespace, null)
        {
            DefaultName = name;
        }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";
    }
}
