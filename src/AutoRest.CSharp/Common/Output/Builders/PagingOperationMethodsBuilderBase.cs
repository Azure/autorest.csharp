// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class PagingOperationMethodsBuilderBase : OperationMethodsBuilderBase
    {
        private static readonly Parameter NextPageUrlParameter = new("nextLink", "The URL to the next page of results.", typeof(string), DefaultValue: null, Validation.AssertNotNull, null);
        private readonly StatusCodeSwitchBuilder _nextPageStatusCodeSwitchBuilder;
        private readonly string _clientName;
        private readonly string _clientNamespace;
        private readonly TypeFactory _typeFactory;
        private readonly SourceInputModel? _sourceInputModel;

        protected OperationPaging Paging { get; }

        protected string? NextLinkName { get; }
        protected string ItemPropertyName { get; }

        protected PagingOperationMethodsBuilderBase(OperationMethodsBuilderBaseArgs args, OperationPaging paging, StatusCodeSwitchBuilder nextPageStatusCodeSwitchBuilder)
            : base(args)
        {
            _nextPageStatusCodeSwitchBuilder = nextPageStatusCodeSwitchBuilder;
            _clientName = args.ClientName;
            _clientNamespace = args.ClientNamespace;
            _typeFactory = args.TypeFactory;
            _sourceInputModel = args.SourceInputModel;
            Paging = paging;

            ItemPropertyName = paging.ItemName ?? "value";
            NextLinkName = paging.NextLinkName;
        }

        protected override Method? BuildLegacyNextPageConvenienceMethod(IReadOnlyList<Parameter> parameters, Method? createRequestMethod, bool async)
        {
            if (createRequestMethod is null)
            {
                return null;
            }

            var nextPageMethodName = ProtocolMethodName + "NextPage";
            var nextPageParameters = parameters
                .Where(p => p.Name != NextPageUrlParameter.Name)
                .Prepend(NextPageUrlParameter)
                .ToArray();

            var methodSignature = CreateMethodSignature(nextPageMethodName, ConvenienceModifiers, nextPageParameters, RestClientConvenienceMethodReturnType, null);
            return BuildConvenienceMethod(methodSignature, CreateLegacyConvenienceMethodBody(createRequestMethod.Signature, _nextPageStatusCodeSwitchBuilder, async), async);
        }

        protected override MethodSignature? BuildCreateNextPageMessageSignature(IReadOnlyList<Parameter> createMessageParameters, IReadOnlyDictionary<object, string>? renamingMap)
        {
            var (methodName, parameters) = Paging switch {
                { SelfNextLink: true } => ($"Create{Operation.CleanName}Request", createMessageParameters),
                { NextLinkOperation: { } nextLinkOperation } => ($"Create{nextLinkOperation.CleanName}Request", BuildNextLinkOperationCreateMessageParameters(nextLinkOperation, renamingMap)),
                { NextLinkName: { }} => ($"Create{ProtocolMethodName}NextPageRequest", createMessageParameters.Prepend(KnownParameters.NextLink).ToArray()),
                _ => (null, Array.Empty<Parameter>())
            };

            return methodName is not null
                ? new MethodSignature(methodName, null, null, MethodSignatureModifiers.Internal, typeof(HttpMessage), null, parameters)
                : null;
        }

        private IReadOnlyList<Parameter> BuildNextLinkOperationCreateMessageParameters(InputOperation nextLinkOperation, IReadOnlyDictionary<object, string>? renamingMap)
            => new MethodParametersBuilder(nextLinkOperation, null, _typeFactory).BuildParameters(GenerateProtocolMethods, renamingMap).CreateMessage;

        protected override MethodBodyStatement? BuildCreateNextPageMessageMethodBody(RequestParts requestParts, MethodSignature signature)
        {
            if (Paging is not { NextLinkOperation: null, SelfNextLink: false })
            {
                return null;
            }

            var requestContext = signature.Parameters.FirstOrDefault(p => p.Type.Equals(Configuration.ApiTypes.RequestContextType)) is {} requestContextParameter ? (TypedValueExpression)requestContextParameter : null;
            return new[]
            {
                CreateMessageMethodBuilder.CreateHttpMessage(Fields, requestParts, RequestMethod.Get, requestContext, Operation.BufferResponse, _nextPageStatusCodeSwitchBuilder.ResponseClassifier, out var uriBuilder),
                uriBuilder.AddUri(Operation.Uri),
                uriBuilder.AppendRawNextLink(KnownParameters.NextLink, false),
                uriBuilder.SetUriToRequest(),

                uriBuilder.AddHeaders(),
                uriBuilder.AddUserAgent(),
                Return(uriBuilder.Message)
            };
        }

        protected IEnumerable<MethodBodyStatement> AddPageableMethodArguments(RestClientMethodParameters parameters, List<ValueExpression> createRequestArguments, out ValueExpression? requestContextVariable)
        {
            var conversions = new List<MethodBodyStatement>();
            MethodBodyStatement? requestContentConversion = null;

            requestContextVariable = null;
            foreach (var protocolParameter in parameters.Protocol)
            {
                if (parameters.Arguments.TryGetValue(protocolParameter, out var argument))
                {
                    createRequestArguments.Add(argument);
                    if (protocolParameter.Type.EqualsIgnoreNullable(KnownParameters.RequestContext.Type))
                    {
                        requestContextVariable = argument;
                    }

                    if (parameters.Conversions.TryGetValue(protocolParameter, out var conversion))
                    {
                        if (protocolParameter.Equals(KnownParameters.RequestContent) || protocolParameter.Equals(KnownParameters.RequestContentNullable))
                        {
                            requestContentConversion = conversion;
                        }
                        else
                        {
                            conversions.Add(conversion);
                        }
                    }
                }
                else
                {
                    createRequestArguments.Add(protocolParameter);
                }
            }

            if (requestContextVariable == null && parameters.Convenience.Contains(KnownParameters.CancellationTokenParameter))
            {
                requestContextVariable = KnownParameters.CancellationTokenParameter;
            }

            if (requestContentConversion is not null)
            {
                conversions.Add(requestContentConversion);
            }

            return conversions;
        }
    }
}
