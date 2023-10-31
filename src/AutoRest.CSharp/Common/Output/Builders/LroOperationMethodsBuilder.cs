// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class LroOperationMethodsBuilder : NonPagingOperationMethodsBuilderBase
    {
        private readonly OperationLongRunning _longRunning;
        private readonly SerializableObjectType? _lroResultModel;
        private readonly string? _fetchResultName;

        public LroOperationMethodsBuilder(OperationMethodsBuilderBaseArgs args, OperationLongRunning longRunning)
            : base(args)
        {
            _longRunning = longRunning;
            _lroResultModel = StatusCodeSwitchBuilder.LroResultType is { IsFrameworkType: false, Implementation: SerializableObjectType model } ? model : null;
            _fetchResultName = StatusCodeSwitchBuilder is {LroResultType: {} resultType, ResponseType: {} responseType} && !responseType.Equals(resultType)
                ? $"Fetch{resultType.Name}From{responseType.Name}"
                : null;
        }

        protected override MethodBodyStatement CreateProtocolMethodBody(MethodSignatureBase createMessageSignature, MethodSignature? createNextPageMessageSignature, bool async)
            => WrapInDiagnosticScope(ProtocolMethodName,
                Extensible.RestOperations.DeclareHttpMessage(createMessageSignature, out var message),
                Return(InvokeProtocolOperationHelpersProcessMessageMethod(CreateScopeName(ProtocolMethodName), message, _longRunning.FinalStateVia, async))
            );

        private ValueExpression InvokeProtocolOperationHelpersProcessMessageMethod(string scope, ValueExpression message, OperationFinalStateVia finalStateVia, bool async)
        {
            var processMessageMethodName = ResponseType is not null
                ? async ? nameof(ProtocolOperationHelpers.ProcessMessageAsync) : nameof(ProtocolOperationHelpers.ProcessMessage)
                : async ? nameof(ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync) : nameof(ProtocolOperationHelpers.ProcessMessageWithoutResponseValue);

            var arguments = new List<ValueExpression>
            {
                PipelineField,
                message,
                ClientDiagnosticsProperty,
                Literal(scope),
                FrameworkEnumValue(finalStateVia),
                KnownParameters.RequestContext,
                KnownParameters.WaitForCompletion
            };

            return new InvokeStaticMethodExpression(typeof(ProtocolOperationHelpers), processMessageMethodName, arguments, null, false, async);
        }

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, RestClientMethodParameters parameters, MethodSignature? createNextPageMessageSignature, bool async)
            => methodName != ProtocolMethodName
                ? WrapInDiagnosticScope(methodName, CreateConvenienceMethodLogic(methodName, parameters, async).AsStatement())
                : CreateConvenienceMethodLogic(methodName, parameters, async).AsStatement();

        protected override Method? BuildResultConversionMethod()
        {
            if (_longRunning is { ResultPath: {} resultPath } && _fetchResultName is not null && _lroResultModel is not null)
            {
                return new Method
                (
                    new MethodSignature(_fetchResultName, null, null, MethodSignatureModifiers.Private, StatusCodeSwitchBuilder.LroResultType, null, new[]{ KnownParameters.Response }),
                    new MethodBodyStatement[]
                    {
                        Var("resultJsonElement", JsonDocumentExpression.Parse(new ResponseExpression(KnownParameters.Response).Content).RootElement.GetProperty(resultPath), out var element),
                        Return(SerializableObjectTypeExpression.Deserialize(_lroResultModel, element))
                    }
                );
            }

            return base.BuildResultConversionMethod();
        }

        private IEnumerable<MethodBodyStatement> CreateConvenienceMethodLogic(string methodName, RestClientMethodParameters parameters, bool async)
        {
            var protocolMethodArguments = new List<ValueExpression>();
            yield return AddProtocolMethodArguments(parameters, protocolMethodArguments).ToArray();

            if (ResponseType == null)
            {
                yield return Return(InvokeProtocolMethod(null, protocolMethodArguments, async));
            }
            else
            {
                var response = new VariableReference(ProtocolMethodReturnType, "response");
                var fetchResultDelegate = _fetchResultName is not null
                    ? new MemberExpression(null, _fetchResultName)
                    : SerializableObjectTypeExpression.FromResponseDelegate((SerializableObjectType)ResponseType.Implementation);

                yield return Declare(response, InvokeProtocolMethod(null, protocolMethodArguments, async));
                yield return Return(InvokeProtocolOperationHelpersConvertMethod(fetchResultDelegate, response, CreateScopeName(methodName)));
            }
        }
    }
}
