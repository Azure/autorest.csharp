// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Samples.Models;
using Azure;
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
        public bool IsEmpty => _isEmpty ??= !Methods.Any();

        private IEnumerable<Method>? _methods;
        public IEnumerable<Method> Methods => _methods ??= EnsureMethods();

        protected virtual IEnumerable<Method> EnsureMethods()
        {
            foreach (var sample in Client.ClientMethods.SelectMany(m => m.Samples))
            {
                yield return BuildSampleMethod(sample, false);
                yield return BuildSampleMethod(sample, true);
            }
        }

        private Method BuildSampleMethod(DpgOperationSample sample, bool isAsync)
        {
            var signature = sample.GetExampleMethodSignature(isAsync);
            var clientVariableStatements = new List<MethodBodyStatement>();
            var newClientStatement = BuildGetClientStatement(sample, sample.ClientInvocationChain, clientVariableStatements, out var clientVar);

            // the method invocation statements go here
            var operationVariableStatements = new List<MethodBodyStatement>();
            var operationInvocationStatements = BuildSampleOperationInvocation(sample, clientVar, operationVariableStatements, isAsync).ToArray();

            return new Method(signature, new MethodBodyStatement[]
            {
                clientVariableStatements,
                newClientStatement,
                EmptyLine,
                operationVariableStatements,
                operationInvocationStatements
            });
        }

        private MethodBodyStatement BuildGetClientStatement(DpgOperationSample sample, IReadOnlyList<MethodSignatureBase> methodsToCall, List<MethodBodyStatement> variableDeclarations, out VariableReference clientVar)
        {
            var first = methodsToCall[0];
            ValueExpression valueExpression = first switch
            {
                ConstructorSignature ctor => New.Instance(ctor.Type, sample.GetValueExpressionsForParameters(ctor.Parameters, variableDeclarations).ToArray()),
                _ => new InvokeInstanceMethodExpression(null, first.Name, sample.GetValueExpressionsForParameters(first.Parameters, variableDeclarations).ToArray(), null, false)
            };

            foreach (var method in methodsToCall.Skip(1))
            {
                valueExpression = valueExpression.Invoke(method.Name, sample.GetValueExpressionsForParameters(method.Parameters, variableDeclarations).ToArray());
            }

            clientVar = new VariableReference(Client.Type, "client");

            return Declare(clientVar, valueExpression);
        }

        private IEnumerable<MethodBodyStatement> BuildSampleOperationInvocation(DpgOperationSample sample, ValueExpression clientVar, List<MethodBodyStatement> variableDeclarations, bool isAsync)
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
                     * BinaryData responseData = operation.Value;
                     */
                    yield return Declare(resultVar, invocation);
                    returnType = GetOperationValueType(returnType);
                    invocation = resultVar.Property("Value");
                    resultVar = new VariableReference(returnType, "responseData");
                    yield return Declare(resultVar, invocation);
                }
                /*
                 * This will generate code like:
                 * await foreach (ItemType item in <invocation>)
                 * {}
                 */
                var itemType = GetPageableItemType(returnType);
                var foreachStatement = new ForeachStatement(itemType, "item", invocation, isAsync, out var itemVar)
                {
                    BuildResponseStatements(sample, itemVar).ToArray()
                };
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

                // generate an extra line when it is long-running
                /*
                 * This will generate code like:
                 * Operation<T> operation = <invocation>;
                 * BinaryData responseData = operation.Value;
                 */
                if (sample.IsLongRunning && TypeFactory.IsOperationOfT(returnType))
                {
                    returnType = GetOperationValueType(returnType);
                    invocation = resultVar.Property("Value");
                    resultVar = new VariableReference(returnType, "responseData");
                    yield return Declare(resultVar, invocation);
                }

                yield return EmptyLine;

                yield return BuildResponseStatements(sample, resultVar).ToArray();
            }
        }

        private IEnumerable<MethodBodyStatement> BuildResponseStatements(DpgOperationSample sample, VariableReference resultVar)
        {
            if (sample.IsResponseStream)
            {
                return BuildResponseForStream(sample, resultVar);
            }
            else
            {
                return BuildNormalResponse(sample, resultVar);
            }
        }

        private IEnumerable<MethodBodyStatement> BuildResponseForStream(DpgOperationSample sample, VariableReference resultVar)
        {
            var contentStreamExpression = new StreamExpression(resultVar.Property("ContentStream"));
            yield return new IfStatement(NotEqual(contentStreamExpression, Null))
            {
                UsingDeclare("outFileStream", new StreamExpression(new TypeReference(typeof(File)).InvokeStatic(nameof(File.OpenWrite), Literal("<filepath>"))), out var streamVariable),
                contentStreamExpression.CopyTo(streamVariable)
            };
        }

        private IEnumerable<MethodBodyStatement> BuildNormalResponse(DpgOperationSample sample, VariableReference responseVar)
        {
            // we do not write response handling for convenience method samples
            if (sample.IsConvenienceSample)
                yield break;

            ValueExpression streamVar;
            var responseType = responseVar.Type;
            if (responseType.EqualsIgnoreNullable(typeof(BinaryData)))
                streamVar = responseVar.Invoke(nameof(BinaryData.ToStream));
            else if (responseType.EqualsIgnoreNullable(typeof(Response)))
                streamVar = responseVar.Property(nameof(Response.ContentStream));
            else if (TypeFactory.IsResponseOfT(responseType))
                streamVar = responseVar.Invoke(nameof(Response<object>.GetRawResponse));
            else
                yield break;

            if (sample.ResultType != null)
            {
                var resultVar = new VariableReference(typeof(JsonElement), "result");
                yield return Declare(resultVar, new TypeReference(typeof(JsonDocument)).InvokeStatic(nameof(JsonDocument.Parse), streamVar).Property(nameof(JsonDocument.RootElement)));

                var responseParsingStatements = new List<MethodBodyStatement>();
                BuildResponseParseStatements(sample.IsAllParametersUsed, sample.ResultType, resultVar, responseParsingStatements, new HashSet<InputType>());

                yield return responseParsingStatements;
            }
            else
            {
                // if there is not a schema for us to show, just print status code
                ValueExpression statusVar = responseVar;
                if (TypeFactory.IsResponseOfT(responseType))
                    statusVar = responseVar.Invoke(nameof(Response<object>.GetRawResponse));
                if (TypeFactory.IsResponseOfT(responseType) || TypeFactory.IsResponse(responseType))
                    yield return InvokeConsoleWriteLine(statusVar.Property(nameof(Response.Status)));
            }
        }

        private static void BuildResponseParseStatements(bool useAllProperties, InputType type, ValueExpression invocation, List<MethodBodyStatement> statements, HashSet<InputType> visitedTypes)
        {
            switch (type)
            {
                case InputListType listType:
                    if (visitedTypes.Contains(listType.ElementType))
                        return;
                    // <invocation>[0]
                    invocation = new IndexerExpression(invocation, Literal(0));
                    BuildResponseParseStatements(useAllProperties, listType.ElementType, invocation, statements, visitedTypes);
                    return;
                case InputDictionaryType dictionaryType:
                    if (visitedTypes.Contains(dictionaryType.ValueType))
                        return;
                    // <invocation>.GetProperty("<key>")
                    invocation = invocation.Invoke("GetProperty", Literal("<key>"));
                    BuildResponseParseStatements(useAllProperties, dictionaryType.ValueType, invocation, statements, visitedTypes);
                    return;
                case InputModelType modelType:
                    BuildResponseParseStatementsForModelType(useAllProperties, modelType, invocation, statements, visitedTypes);
                    return;
            }
            // we get primitive types, return the statement
            var statement = InvokeConsoleWriteLine(invocation.InvokeToString());
            statements.Add(statement);
        }

        private static void BuildResponseParseStatementsForModelType(bool useAllProperties, InputModelType model, ValueExpression invocation, List<MethodBodyStatement> statements, HashSet<InputType> visitedTypes)
        {
            var allProperties = model.GetSelfAndBaseModels().SelectMany(m => m.Properties);
            var propertiesToExplore = useAllProperties
                ? allProperties
                : allProperties.Where(p => p.IsRequired);

            if (!propertiesToExplore.Any()) // if you have a required property, but its child properties are all optional
            {
                // return the object
                statements.Add(InvokeConsoleWriteLine(invocation.InvokeToString()));
                return;
            }

            foreach (var property in propertiesToExplore)
            {
                if (!visitedTypes.Contains(property.Type))
                {
                    // <invocation>.GetProperty("<propertyName>");
                    visitedTypes.Add(property.Type);
                    var next = invocation.Invoke("GetProperty", Literal(property.SerializedName));
                    BuildResponseParseStatements(useAllProperties, property.Type, next, statements, visitedTypes);
                    visitedTypes.Remove(property.Type);
                }
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
