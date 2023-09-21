// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core.TestFramework;

namespace AutoRest.CSharp.LowLevel.Output.Tests
{
    internal class DpgTestEnvironmentProvider : TypeProvider
    {
        public DpgTestEnvironmentProvider(string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            DefaultNamespace = $"{defaultNamespace}.Tests";
            DefaultName = $"{ClientBuilder.GetRPName(defaultNamespace)}TestEnvironment";
            BaseType = typeof(TestEnvironment);
        }

        public CSharpType BaseType { get; }

        protected override string DefaultNamespace { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";
    }
}
