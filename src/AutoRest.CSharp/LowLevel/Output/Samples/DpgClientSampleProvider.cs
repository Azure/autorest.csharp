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
        public bool IsEmpty => _isEmpty ??= !Samples.Any();

        private IEnumerable<DpgOperationSample>? _samples;
        public IEnumerable<DpgOperationSample> Samples => _samples ??= Client.ClientMethods.SelectMany(m => m.Samples);

        private IEnumerable<Method>? _sampleMethods;
        public IEnumerable<Method> SampleMethods => _sampleMethods ??= EnsureSampleMethods();

        private IEnumerable<Method> EnsureSampleMethods()
        {
            foreach (var sample in Samples)
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
            var operationInvocationStatements = ComposeSampleOperationInvocation(sample, clientVar, operationVariableStatements, isAsync);

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

        private MethodBodyStatement ComposeSampleOperationInvocation(DpgOperationSample sample, ValueExpression clientVar, List<MethodBodyStatement> variableDeclarations, bool isAsync) => (sample.IsLongRunning, sample.IsPageable) switch
        {
            (true, true) => ComposeLongRunningPageableOperation(sample, sample.OperationMethodSignature.WithAsync(isAsync), clientVar, variableDeclarations, isAsync).ToArray(),
            (true, false) => ComposeLongRunningOperation(sample, sample.OperationMethodSignature.WithAsync(isAsync), clientVar, variableDeclarations, isAsync).ToArray(),
            (false, true) => ComposePageableOperation(sample, sample.OperationMethodSignature.WithAsync(isAsync), clientVar, variableDeclarations, isAsync).ToArray(),
            (false, false) => ComposeNormalOperation(sample, sample.OperationMethodSignature.WithAsync(isAsync), clientVar, variableDeclarations, isAsync).ToArray()
        };

        private IEnumerable<MethodBodyStatement> ComposeLongRunningPageableOperation(DpgOperationSample sample, MethodSignature methodSignature, ValueExpression clientVar, List<MethodBodyStatement> variableDeclarations, bool isAsync)
        {
            foreach (var statement in ComposeLongRunningOperation(sample, methodSignature, clientVar, variableDeclarations, isAsync))
            {
                yield return statement;
            }

            // write a (await) foreach statement
        }

        private IEnumerable<MethodBodyStatement> ComposeLongRunningOperation(DpgOperationSample sample, MethodSignature methodSignature, ValueExpression clientVar, List<MethodBodyStatement> variableDeclarations, bool isAsync)
        {
            var parameterExpressions = sample.GetValueExpressionsForParameters(methodSignature.Parameters, variableDeclarations);
            var invocation = clientVar.Invoke(methodSignature, parameterExpressions.ToArray(), addConfigureAwaitFalse: false);
            var responseType = GetReturnType(methodSignature.ReturnType);
            var resultVar = new VariableReference(responseType, "operation");
            yield return Declare(resultVar, invocation);
        }

        private IEnumerable<MethodBodyStatement> ComposePageableOperation(DpgOperationSample sample, MethodSignature methodSignature, ValueExpression clientVar, List<MethodBodyStatement> variableDeclarations, bool isAsync)
        {
            var parameterExpressions = sample.GetValueExpressionsForParameters(methodSignature.Parameters, variableDeclarations);
            var invocation = clientVar.Invoke(methodSignature, parameterExpressions.ToArray(), addConfigureAwaitFalse: false);

            var itemType = GetPageableItemType(methodSignature.ReturnType);
            var foreachStatement = new ForeachStatement(itemType, new CodeWriterDeclaration("item"), invocation, isAsync);
            yield return foreachStatement;
        }

        private IEnumerable<MethodBodyStatement> ComposeNormalOperation(DpgOperationSample sample, MethodSignature methodSignature, ValueExpression clientVar, List<MethodBodyStatement> variableDeclarations, bool isAsync)
        {
            var parameterExpressions = sample.GetValueExpressionsForParameters(methodSignature.Parameters, variableDeclarations);
            var invocation = clientVar.Invoke(methodSignature, parameterExpressions.ToArray(), addConfigureAwaitFalse: false);
            var responseType = GetReturnType(methodSignature.ReturnType);
            var resultVar = new VariableReference(responseType, "response");
            yield return Declare(resultVar, invocation);
        }

        protected override string DefaultNamespace { get; }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility => "public";

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
