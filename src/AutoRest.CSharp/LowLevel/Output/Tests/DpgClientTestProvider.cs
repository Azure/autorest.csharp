// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.LowLevel.Output.Samples;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.LowLevel.Output.Tests
{
    internal class DpgClientTestProvider : DpgClientSampleProvider
    {
        private static readonly Parameter IsAsyncParameter = new("isAsync", null, typeof(bool), null, ValidationType.None, null);

        private readonly DpgTestBaseProvider _testBaseProvider;

        public DpgClientTestProvider(string defaultNamespace, LowLevelClient client, DpgTestBaseProvider testBase, SourceInputModel? sourceInputModel) : base(defaultNamespace, client, sourceInputModel)
        {
            _testBaseProvider = testBase;
            DefaultNamespace = $"{defaultNamespace}.Tests";
            DefaultName = $"{client.Declaration.Name}Tests";
        }

        public override CSharpType? Inherits => _testBaseProvider.Type;

        protected override string DefaultNamespace { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        protected override IEnumerable<Method> EnsureConstructors()
        {
            yield return new(new ConstructorSignature(
                Type,
                Summary: null,
                Description: null,
                Modifiers: MethodSignatureModifiers.Public,
                Parameters: new[] { IsAsyncParameter },
                Initializer: new ConstructorInitializer(
                    IsBase: true,
                    Arguments: new FormattableString[] { $"{IsAsyncParameter.Name:I}" })
                ),
                MethodBodyStatement.Empty);
        }
    }
}
