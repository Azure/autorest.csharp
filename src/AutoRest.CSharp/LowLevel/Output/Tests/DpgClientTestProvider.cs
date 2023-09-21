// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.LowLevel.Output.Tests
{
    internal class DpgClientTestProvider : TypeProvider
    {
        public LowLevelClient Client { get; }

        public DpgClientTestProvider(string defaultNamespace, LowLevelClient client, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            Client = client;
            DefaultNamespace = $"{defaultNamespace}.Tests";
            DefaultName = $"{client.Declaration.Name}Tests";
        }

        private bool? _isEmpty;
        public bool IsEmpty => _isEmpty ??= !TestCases.Any();

        private IEnumerable<DpgTestCase>? _testCases;
        public IEnumerable<DpgTestCase> TestCases => _testCases ??= Client.ClientMethods.SelectMany(m => m.Samples).Select(s => new DpgTestCase(s));

        protected override string DefaultNamespace { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";
    }
}
