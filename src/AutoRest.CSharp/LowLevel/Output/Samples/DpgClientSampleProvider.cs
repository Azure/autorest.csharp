// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Samples.Models;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.LowLevel.Output.Samples
{
    internal class DpgClientSampleProvider : TypeProvider
    {
        public LowLevelClient Client { get; }

        public DpgClientSampleProvider(string defaultNamespace, LowLevelClient client, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            Client = client;
            DefaultNamespace = $"{defaultNamespace}.Samples";
            DefaultName = $"Samples_{client.Declaration.Name}";
        }

        private bool? _isEmpty;
        public bool IsEmpty => _isEmpty ??= !SampleMethods.Any();

        private IEnumerable<Method>? _sampleMethods;
        public IEnumerable<Method> SampleMethods => _sampleMethods ??= EnsureSampleMethods();

        private IEnumerable<Method> EnsureSampleMethods()
        {
            foreach (var sample in Client.ClientMethods.SelectMany(m => m.Samples))
            {
                yield return ComposeSampleMethod(sample, false);
                yield return ComposeSampleMethod(sample, true);
            }
        }

        private Method ComposeSampleMethod(DpgOperationSample sample, bool isAsync)
        {
            var signature = sample.GetExampleMethodSignature(isAsync);
            var clientVariableStatements = new List<MethodBodyStatement>();
            var newClientStatement = ComposeGetClientStatement(sample, clientVariableStatements, out var clientVar);

            // the method invocation statements go here
            var operationVariableStatements = new List<MethodBodyStatement>();
            var operationInvocationStatements = ComposeSampleOperationInvocation(sample, clientVar, operationVariableStatements, isAsync).ToArray();

            return new Method(signature, new MethodBodyStatement[]
            {
                clientVariableStatements,
                newClientStatement,
                EmptyLine,
                operationVariableStatements,
                operationInvocationStatements
            });
        }

        private MethodBodyStatement ComposeGetClientStatement(DpgOperationSample sample, List<MethodBodyStatement> variableDeclarations, out VariableReference clientVar)
        {
            var methodsToCall = sample.ClientInvocationChain;
            var first = methodsToCall.First();
            ValueExpression valueExpression = first switch
            {
                ConstructorSignature ctor => New.Instance(ctor.Type, sample.GetValueExpressionsForParameters(ctor.Parameters, variableDeclarations).ToArray()),
                _ => new InvokeInstanceMethodExpression(null, first.Name, sample.GetValueExpressionsForParameters(first.Parameters, variableDeclarations).ToArray(), null, false)
            };

            foreach (var method in methodsToCall.Skip(1))
            {
                valueExpression = valueExpression.Invoke(method.Name, sample.GetValueExpressionsForParameters(method.Parameters, variableDeclarations).ToArray());
            }

            clientVar = new VariableReference(sample.Client.Type, "client");

            return Declare(clientVar, valueExpression);
        }

        private IEnumerable<MethodBodyStatement> ComposeSampleOperationInvocation(DpgOperationSample sample, ValueExpression clientVar, List<MethodBodyStatement> variableDeclarations, bool isAsync)
        {
            var methodSignature = sample.OperationMethodSignature.WithAsync(isAsync);
            var parameterExpressions = sample.GetValueExpressionsForParameters(methodSignature.Parameters, variableDeclarations);
            var invocation = clientVar.Invoke(methodSignature, parameterExpressions.ToArray(), addConfigureAwaitFalse: false);
            var returnType = GetReturnType(methodSignature.ReturnType);
            VariableReference resultVar = sample.IsLongRunning
                ? new VariableReference(returnType, "operation")
                : new VariableReference(returnType, "response");

            if (sample.IsPageable)
            {
                // if it is pageable, we need to wrap the invocation inside a foreach statement
                // but before the foreach, if this operation is long-running, we still need to call it, and pass the operation.Value into the foreach
                if (sample.IsLongRunning)
                {
                    /*
                     * This will generate code like:
                     * Operation<T> operation = <invocation>;
                     */
                    yield return Declare(resultVar, invocation);
                    invocation = resultVar.Property("Value");
                    returnType = GetOperationValueType(returnType);
                }
                /*
                 * This will generate code like:
                 * await foreach (ItemType item in <invocation>)
                 * {}
                 */
                var itemType = GetPageableItemType(returnType);
                var foreachStatement = new ForeachStatement(itemType, new CodeWriterDeclaration("item"), invocation, isAsync);
                yield return foreachStatement;
            }
            else
            {
                // if it is not pageable, we just call the operation, declare a local variable and assign the result to it
                /*
                 * This will generate code like:
                 * Operation<T> operation = <invocation>; // when it is long-running
                 * Response<T> response = <invocation>; // when it is not long-running
                 */
                yield return Declare(resultVar, invocation);
            }
        }

        protected override string DefaultNamespace { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

        private static CSharpType GetOperationValueType(CSharpType? returnType)
        {
            if (returnType == null)
                throw new InvalidOperationException("The return type of a client operation should never be null");

            returnType = GetReturnType(returnType);

            Debug.Assert(TypeFactory.IsOperationOfT(returnType));

            return returnType.Arguments.Single();
        }

        private static CSharpType GetReturnType(CSharpType? returnType)
        {
            if (returnType == null)
                throw new InvalidOperationException("The return type of a client operation should never be null");

            if (returnType.IsFrameworkType && returnType.FrameworkType.Equals(typeof(Task<>)))
            {
                return returnType.Arguments.Single();
            }

            return returnType;
        }

        private static CSharpType GetPageableItemType(CSharpType? returnType)
        {
            if (returnType == null)
                throw new InvalidOperationException("The return type of a client operation should never be null");

            Debug.Assert(TypeFactory.IsPageable(returnType) || TypeFactory.IsAsyncPageable(returnType));

            return returnType.Arguments.Single();
        }
    }
}
