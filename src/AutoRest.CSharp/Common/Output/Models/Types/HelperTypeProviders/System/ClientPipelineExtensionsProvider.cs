// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ClientModel.Primitives.Pipeline;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types.System
{
    internal class ClientPipelineExtensionsProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<ClientPipelineExtensionsProvider> _instance = new(() => new ClientPipelineExtensionsProvider());

        public static ClientPipelineExtensionsProvider Instance => _instance.Value;

        private const string _processMessageAsync = "ProcessMessageAsync";
        private const string _processMessage = "ProcessMessage";
        private const string _processHeadAsBoolMessageAsync = "ProcessHeadAsBoolMessageAsync";
        private const string _processHeadAsBoolMessage = "ProcessHeadAsBoolMessage";

        private Parameter _pipelineParam;
        private Parameter _messageParam;
        private Parameter _requestContextParam;
        private ParameterReference _pipeline;
        private ParameterReference _message;
        private ParameterReference _requestContext;
        private MemberExpression _messageResponse;

        private ClientPipelineExtensionsProvider()
            : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;
            _pipelineParam = new Parameter("pipeline", null, typeof(Pipeline<PipelineMessage>), null, ValidationType.None, null);
            _messageParam = new Parameter("message", null, typeof(PipelineMessage), null, ValidationType.None, null);
            _requestContextParam = new Parameter("requestContext", null, typeof(RequestOptions), null, ValidationType.None, null);
            _pipeline = new ParameterReference(_pipelineParam);
            _message = new ParameterReference(_messageParam);
            _requestContext = new ParameterReference(_requestContextParam);
            _messageResponse = new MemberExpression(_message, "Response");
        }

        protected override string DefaultName => "ClientPipelineExtensions";

        protected override IEnumerable<Method> BuildMethods()
        {
            yield return BuildProcessMessageAsync();
            yield return BuildProcessMessage();
            yield return ProcessHeadAsBoolMessageAsync();
            yield return ProcessHeadAsBoolMessage();
        }

        private Method ProcessHeadAsBoolMessage()
        {
            MethodSignature signature = GetProcessHeadAsBoolMessageSignature(false);
            var responseVariable = new VariableReference(typeof(PipelineResponse), "response");
            var response = new PipelineResponseExpression(responseVariable);
            return new Method(signature, new MethodBodyStatement[]
            {
                Assign(new DeclarationExpression(responseVariable, false), _pipeline.Invoke(_processMessage, new[] { _message, _requestContext }, false)),
                GetProcessHeadAsBoolMessageBody(response)
            });
        }

        private Method ProcessHeadAsBoolMessageAsync()
        {
            MethodSignature signature = GetProcessHeadAsBoolMessageSignature(true);
            var responseVariable = new VariableReference(typeof(PipelineResponse), "response");
            var response = new PipelineResponseExpression(responseVariable);
            return new Method(signature, new MethodBodyStatement[]
            {
                Assign(new DeclarationExpression(responseVariable, false), _pipeline.Invoke(_processMessageAsync, new[] { _message, _requestContext }, true)),
                GetProcessHeadAsBoolMessageBody(response)
            });
        }

        private MethodBodyStatement GetProcessHeadAsBoolMessageBody(PipelineResponseExpression response)
        {
            return new MethodBodyStatement[]
            {
                new SwitchStatement(new MemberExpression(response, "Status"), new SwitchCase[]
                {
                    new SwitchCase(new BinaryOperatorExpression("<", new UnaryOperatorExpression("and", new UnaryOperatorExpression(">=", Literal(200), false), true), Literal(300)), new MethodBodyStatement[]
                    {
                        Return(ResultExpression.FromValue(True, response))
                    }),
                    new SwitchCase(new BinaryOperatorExpression("<", new UnaryOperatorExpression("and", new UnaryOperatorExpression(">=", Literal(400), false), true), Literal(500)), new MethodBodyStatement[]
                    {
                        Return(ResultExpression.FromValue(False, response))
                    }),
                    new SwitchCase(Array.Empty<ValueExpression>(), new MethodBodyStatement[]
                    {
                        Return(new NewInstanceExpression(ErrorResultProvider.Instance.Type.MakeGenericType(new CSharpType[]{ typeof(bool) }), new ValueExpression[]{ response, new NewInstanceExpression(typeof(MessageFailedException), new[] { response })}))
                    })
                }),
            };
        }

        private MethodSignature GetProcessHeadAsBoolMessageSignature(bool isAsync)
        {
            var modifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension;
            if (isAsync)
            {
                modifiers |= MethodSignatureModifiers.Async;
            }
            return new MethodSignature(
                isAsync ? "ProcessHeadAsBoolMessageAsync" : "ProcessHeadAsBoolMessage",
                null,
                null,
                modifiers,
                isAsync ? typeof(ValueTask<NullableResult<bool>>) : typeof(NullableResult<bool>),
                null,
                new[] { _pipelineParam, _messageParam, _requestContextParam });
        }

        private Method BuildProcessMessage()
        {
            MethodSignature signature = GetProcessMessageSignature(false, out var cancellationTokenParam);
            var cancellationToken = new ParameterReference(cancellationTokenParam);
            return new Method(signature, new MethodBodyStatement[]
            {
                new InvokeInstanceMethodStatement(_pipeline, nameof(Pipeline<PipelineMessage>.Send), new[]{ _message }, false),
                GetProcessMessageBody()
            });
        }

        private MethodBodyStatement GetProcessMessageBody()
        {
            return new MethodBodyStatement[]
            {
                EmptyLine,
                new IfStatement(Equal(_messageResponse, Null))
                {
                    Throw(New.InvalidOperationException(Literal("Failed to receive Result.")))
                },
                EmptyLine,
                new IfStatement(Not(new BoolExpression(new MemberExpression(_messageResponse, "IsError"))).Or(Equal(new MemberExpression(_requestContext, "ErrorBehavior"), FrameworkEnumValue(ErrorBehavior.NoThrow))))
                {
                    Return(_messageResponse)
                },
                EmptyLine,
                Throw(new NewInstanceExpression(typeof(MessageFailedException), new[] { _messageResponse }))
            };
        }

        private MethodSignature GetProcessMessageSignature(bool isAsync, out Parameter cancellationTokenParam)
        {
            cancellationTokenParam = new Parameter("cancellationToken", null, typeof(CancellationToken), Constant.Default(typeof(CancellationToken)), ValidationType.None, null);
            var modifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Extension;
            if (isAsync)
            {
                modifiers |= MethodSignatureModifiers.Async;
            }
            return new MethodSignature(
                isAsync ? "ProcessMessageAsync" : "ProcessMessage",
                null,
                null,
                modifiers,
                isAsync ? typeof(ValueTask<PipelineResponse>) : typeof(PipelineResponse),
                null,
                new[] { _pipelineParam, _messageParam, _requestContextParam, cancellationTokenParam });
        }

        private Method BuildProcessMessageAsync()
        {
            MethodSignature signature = GetProcessMessageSignature(true, out var cancellationTokenParam);
            var cancellationToken = new ParameterReference(cancellationTokenParam);
            return new Method(signature, new MethodBodyStatement[]
            {
                new InvokeInstanceMethodStatement(_pipeline, nameof(Pipeline<PipelineMessage>.SendAsync), new[]{ _message }, true),
                GetProcessMessageBody()
            });
        }

        internal PipelineResponseExpression ProcessMessage(IReadOnlyList<ValueExpression> arguments, bool isAsync)
        {
            return new(new InvokeStaticMethodExpression(Type, isAsync ? _processMessageAsync : _processMessage, arguments, CallAsExtension: true, CallAsAsync: isAsync));
        }

        internal ResultExpression ProcessHeadAsBoolMessage(IReadOnlyList<ValueExpression> arguments, bool isAsync)
        {
            return new(new InvokeStaticMethodExpression(Type, isAsync ? _processHeadAsBoolMessageAsync : _processHeadAsBoolMessage, arguments, CallAsExtension: true, CallAsAsync: isAsync));
        }
    }
}
