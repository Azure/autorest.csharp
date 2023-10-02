// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.LowLevel.Output.Samples;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Samples.Models;

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

        protected override IEnumerable<Method> EnsureMethods()
        {
            foreach (var sample in Client.ClientMethods.SelectMany(m => m.Samples))
            {
                yield return BuildSampleMethod(sample, true);
            }
        }

        protected override string GetMethodName(DpgOperationSample sample, bool isAsync)
        {
            var builder = new StringBuilder().Append(sample.OperationMethodSignature.Name);

            builder.Append('_').Append(sample.ExampleKey);

            if (sample.IsConvenienceSample)
            {
                builder.Append("_Convenience");
            }

            // do not append Async here because the test method is always using the async version of the operation

            return builder.ToString();
        }

        protected override MethodBodyStatement BuildGetClientStatement(DpgOperationSample sample, IReadOnlyList<MethodSignatureBase> methodsToCall, List<MethodBodyStatement> variableDeclarations, out VariableReference clientVar)
        {
            // change the first method in methodToCall to the factory method of this client
            var firstMethod = _testBaseProvider.CreateClientMethods[Client];
            var newMethodsToCall = methodsToCall.ToArray();
            newMethodsToCall[0] = firstMethod.Signature;
            return base.BuildGetClientStatement(sample, newMethodsToCall, variableDeclarations, out clientVar);
        }

        protected override IEnumerable<MethodBodyStatement> BuildResponseStatements(DpgOperationSample sample, VariableReference resultVar)
        {
            // for test methods, we never generate response handling for them
            yield break;
        }
    }
}
