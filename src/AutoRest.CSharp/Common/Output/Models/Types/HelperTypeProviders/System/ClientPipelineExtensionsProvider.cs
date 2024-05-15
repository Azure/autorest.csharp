// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Input;
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
        private Parameter _requestOptionsParam;
        private ClientPipelineExpression _pipeline;
        private PipelineMessageExpression _message;
        private RequestOptionsExpression _options;

        private ClientPipelineExtensionsProvider()
            : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;
            _pipelineParam = new Parameter("pipeline", null, typeof(ClientPipeline), null, ValidationType.None, null);
            _messageParam = new Parameter("message", null, typeof(PipelineMessage), null, ValidationType.None, null);
            _requestOptionsParam = new Parameter("options", null, typeof(RequestOptions), null, ValidationType.None, null);
            _pipeline = new ClientPipelineExpression(_pipelineParam);
            _message = new PipelineMessageExpression(_messageParam);
            _options = new RequestOptionsExpression(_requestOptionsParam);
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
                Assign(new DeclarationExpression(responseVariable, false), _pipeline.ProcessMessage(_message, _options, false)),
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
                Assign(new DeclarationExpression(responseVariable, false), _pipeline.ProcessMessage(_message, _options, true)),
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
                        Return(ClientResultExpression.FromValue(typeof(bool), True, response))
                    }),
                    new SwitchCase(new BinaryOperatorExpression("<", new UnaryOperatorExpression("and", new UnaryOperatorExpression(">=", Literal(400), false), true), Literal(500)), new MethodBodyStatement[]
                    {
                        Return(ClientResultExpression.FromValue(typeof(bool), False, response))
                    }),
                    new SwitchCase(Array.Empty<ValueExpression>(), new MethodBodyStatement[]
                    {
                        Return(new NewInstanceExpression(ErrorResultProvider.Instance.Type.MakeGenericType(new CSharpType[]{ typeof(bool) }), new ValueExpression[]{ response, new NewInstanceExpression(typeof(ClientResultException), new[] { response })}))
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
                isAsync ? typeof(ValueTask<ClientResult<bool>>) : typeof(ClientResult<bool>),
                null,
                new[] { _pipelineParam, _messageParam, _requestOptionsParam });
        }

        private Method BuildProcessMessage()
        {
            MethodSignature signature = GetProcessMessageSignature(false);

            var clientErrorNoThrow = FrameworkEnumValue(ClientErrorBehaviors.NoThrow);
            return new Method(signature, new MethodBodyStatement[]
            {
                new InvokeInstanceMethodStatement(_pipeline, nameof(ClientPipeline.Send), new[] { _message }, false),
                EmptyLine,
                new IfStatement(And(_message.Response.IsError, NotEqual(new BinaryOperatorExpression("&", _options.Property("ErrorOptions", true), clientErrorNoThrow), clientErrorNoThrow)))
                {
                    Throw(New.Instance(typeof(ClientResultException), _message.Response))
                },
                EmptyLine,
                Declare("response", new TypedValueExpression(typeof(PipelineResponse), new TernaryConditionalOperator(_message.BufferResponse, _message.Response, _message.ExtractResponse())), out var response),
                Return(response)
            });
        }

        private MethodSignature GetProcessMessageSignature(bool isAsync)
        {
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
                new[] { _pipelineParam, _messageParam, _requestOptionsParam });
        }

        private Method BuildProcessMessageAsync()
        {
            MethodSignature signature = GetProcessMessageSignature(true);

            var clientErrorNoThrow = FrameworkEnumValue(ClientErrorBehaviors.NoThrow);
            return new Method(signature, new MethodBodyStatement[]
            {
                new InvokeInstanceMethodStatement(_pipeline, nameof(ClientPipeline.SendAsync), new[]{ _message }, true),
                EmptyLine,
                new IfStatement(And(_message.Response.IsError, NotEqual(new BinaryOperatorExpression("&", _options.Property("ErrorOptions", true), clientErrorNoThrow), clientErrorNoThrow)))
                {
                    Throw(new InvokeStaticMethodExpression(typeof(ClientResultException), nameof(ClientResultException.CreateAsync), new[] { _message.Response }, CallAsAsync: true))
                },
                EmptyLine,
                Declare("response", new TypedValueExpression(typeof(PipelineResponse), new TernaryConditionalOperator(_message.BufferResponse, _message.Response, _message.ExtractResponse())), out var response),
                Return(response)
            });
        }

        internal PipelineResponseExpression ProcessMessage(IReadOnlyList<ValueExpression> arguments, bool isAsync)
        {
            return new(new InvokeStaticMethodExpression(Type, isAsync ? _processMessageAsync : _processMessage, arguments, CallAsExtension: true, CallAsAsync: isAsync));
        }

        internal ClientResultExpression ProcessHeadAsBoolMessage(IReadOnlyList<ValueExpression> arguments, bool isAsync)
        {
            return new(new InvokeStaticMethodExpression(Type, isAsync ? _processHeadAsBoolMessageAsync : _processHeadAsBoolMessage, arguments, CallAsExtension: true, CallAsAsync: isAsync));
        }
    }
}
