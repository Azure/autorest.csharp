// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.LowLevel.Output.Tests
{
    internal class DpgClientTestProvider : TypeProvider
    {
        private static readonly Parameter IsAsyncParameter = new("isAsync", null, typeof(bool), null, ValidationType.None, null);

        private readonly DpgTestBaseProvider _testBaseProvider;
        public LowLevelClient Client { get; }

        public DpgClientTestProvider(string defaultNamespace, LowLevelClient client, DpgTestBaseProvider testBase, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            Client = client;
            _testBaseProvider = testBase;
            DefaultNamespace = $"{defaultNamespace}.Tests";
            DefaultName = $"{client.Declaration.Name}Tests";
        }

        public CSharpType BaseType => _testBaseProvider.Type;

        private bool? _isEmpty;
        public bool IsEmpty => _isEmpty ??= !TestCases.Any();

        private IEnumerable<DpgTestCase>? _testCases;
        public IEnumerable<DpgTestCase> TestCases => _testCases ??= Client.ClientMethods.SelectMany(m => m.Samples).Select(s => new DpgTestCase(s, _testBaseProvider));

        protected override string DefaultNamespace { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        public IEnumerable<ConstructorSignature> Constructors
        {
            get
            {
                yield return new ConstructorSignature(
                    Name: DefaultName,
                    Summary: null,
                    Description: null,
                    Modifiers: MethodSignatureModifiers.Public,
                    Parameters: new[] { IsAsyncParameter },
                    Initializer: new ConstructorInitializer(
                        IsBase: true,
                        Arguments: new FormattableString[] { $"{IsAsyncParameter.Name:I}" })
                    );
            }
        }
    }
}
