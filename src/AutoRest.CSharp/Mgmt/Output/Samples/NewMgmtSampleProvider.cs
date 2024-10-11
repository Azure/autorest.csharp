// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using NUnit.Framework;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Mgmt.Output.Samples
{
    internal class NewMgmtSampleProvider : ExpressionTypeProvider
    {
        protected readonly MgmtTypeProvider _client;

        public NewMgmtSampleProvider(string defaultNamespace, MgmtTypeProvider client, SourceInputModel? sourceInputModel) : base($"{defaultNamespace}.Samples", sourceInputModel)
        {
            DeclarationModifiers = TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial;
            DefaultName = $"Sample_{client.Type.Name}";
            _client = client;
        }

        public bool IsEmpty => !Methods.Any();

        protected override string DefaultName { get; }

        private Method BuildSampleMethod(MgmtOperationSample sample, bool isAsync)
        {
            var signature = sample.GetMethodSignature(false);

            return new Method(signature, EmptyStatement);
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            foreach (var sample in _client.AllOperations.SelectMany(o => o.Samples))
            {
                yield return BuildSampleMethod(sample, true);
            }
        }
    }
}
