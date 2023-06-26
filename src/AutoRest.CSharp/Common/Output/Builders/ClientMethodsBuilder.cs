// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models
{
    internal class ClientMethodsBuilder
    {
        private static readonly HashSet<string> IgnoredRequestHeader = new(StringComparer.OrdinalIgnoreCase)
        {
            "x-ms-client-request-id",
            "tracestate",
            "traceparent"
        };

        private readonly IEnumerable<InputOperation> _operations;
        private readonly TypeFactory _typeFactory;
        private readonly bool _legacyParameterSorting;
        private readonly bool _legacyParameterBuilding;

        public ClientMethodsBuilder(IEnumerable<InputOperation> operations, TypeFactory typeFactory, bool legacyParameterSorting, bool legacyParameterBuilding)
        {
            _operations = operations;
            _typeFactory = typeFactory;
            _legacyParameterSorting = legacyParameterSorting;
            _legacyParameterBuilding = legacyParameterBuilding;
        }

        public IEnumerable<OperationMethodsBuilderBase> Build(ValueExpression? restClientReference, ClientFields fields, string clientName)
        {
            var operationParameters = new Dictionary<InputOperation, ClientMethodParameters>();

            foreach (var inputOperation in _operations)
            {
                var unsortedParameters = inputOperation.Parameters
                    .Where(rp => rp.Location != RequestLocation.Header || !IgnoredRequestHeader.Contains(rp.NameInRequest))
                    .ToArray();

                var sortedParameters = _legacyParameterSorting
                    ? GetLegacySortedParameters(unsortedParameters)
                    : GetSortedParameters(inputOperation, unsortedParameters);

                var builder = new MethodParametersBuilder(inputOperation, _typeFactory);
                var parameters = _legacyParameterBuilding
                    ? builder.BuildParametersLegacy(unsortedParameters, sortedParameters)
                    : builder.BuildParameters(sortedParameters);

                operationParameters[inputOperation] = parameters;
            }

            foreach (var (operation, parameters) in operationParameters)
            {
                if (operation.Paging is {} paging)
                {
                    var createNextPageMessageMethodParameters = paging switch
                    {
                        { NextLinkOperation: {} nextLinkOperation } => operationParameters[nextLinkOperation].CreateMessage,
                        { NextLinkName: {}} => parameters.CreateMessage.Prepend(KnownParameters.NextLink).ToArray(),
                        _ => Array.Empty<Parameter>()
                    };

                    var pagingParameters = new ClientPagingMethodParameters(parameters, createNextPageMessageMethodParameters);

                    yield return operation.LongRunning is { } longRunning
                        ? new LroPagingOperationMethodsBuilder(longRunning, paging, operation, restClientReference, fields, clientName, _typeFactory, pagingParameters)
                        : new PagingOperationMethodsBuilder(paging, operation, restClientReference, fields, clientName, _typeFactory, pagingParameters);
                }
                else
                {
                    yield return operation.LongRunning is { } longRunning
                        ? new LroOperationMethodsBuilder(longRunning, operation, restClientReference, fields, clientName, _typeFactory, parameters)
                        : operation.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean
                            ? new HeadAsBooleanOperationMethodsBuilder(operation, restClientReference, fields, clientName, _typeFactory, parameters)
                            : new OperationMethodsBuilder(operation, restClientReference, fields, clientName, _typeFactory, parameters);
                }
            }
        }

        private static IEnumerable<InputParameter> GetSortedParameters(InputOperation operation, IEnumerable<InputParameter> inputParameters)
        {
            var requiredPathParameters = new Dictionary<string, InputParameter>();
            var optionalPathParameters = new Dictionary<string, InputParameter>();
            var requiredRequestParameters = new List<InputParameter>();
            var optionalRequestParameters = new List<InputParameter>();

            InputParameter? bodyParameter = null;
            InputParameter? contentTypeRequestParameter = null;

            foreach (var operationParameter in inputParameters)
            {
                switch (operationParameter)
                {
                    case { Location: RequestLocation.Body }:
                        bodyParameter = operationParameter;
                        break;
                    case { Location: RequestLocation.Header, IsContentType: true } when contentTypeRequestParameter == null:
                        contentTypeRequestParameter = operationParameter;
                        break;
                    case { Location: RequestLocation.Uri or RequestLocation.Path, DefaultValue: null }:
                        requiredPathParameters.Add(operationParameter.NameInRequest, operationParameter);
                        break;
                    case { Location: RequestLocation.Uri or RequestLocation.Path, DefaultValue: not null }:
                        optionalPathParameters.Add(operationParameter.NameInRequest, operationParameter);
                        break;
                    case { IsRequired: true, DefaultValue: null }:
                        requiredRequestParameters.Add(operationParameter);
                        break;
                    default:
                        optionalRequestParameters.Add(operationParameter);
                        break;
                }
            }

            var orderedParameters = new List<InputParameter>();

            SortUriOrPathParameters(operation.Uri, requiredPathParameters, orderedParameters);
            SortUriOrPathParameters(operation.Path, requiredPathParameters, orderedParameters);
            orderedParameters.AddRange(requiredRequestParameters);
            if (bodyParameter is not null)
            {
                orderedParameters.Add(bodyParameter);
                if (contentTypeRequestParameter is not null)
                {
                    orderedParameters.Add(contentTypeRequestParameter);
                }
            }
            SortUriOrPathParameters(operation.Uri, optionalPathParameters, orderedParameters);
            SortUriOrPathParameters(operation.Path, optionalPathParameters, orderedParameters);
            orderedParameters.AddRange(optionalRequestParameters);

            return orderedParameters;
        }

        private static void SortUriOrPathParameters(string uriPart, IReadOnlyDictionary<string, InputParameter> requestParameters, ICollection<InputParameter> orderedParameters)
        {
            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(uriPart))
            {
                if (isLiteral)
                {
                    continue;
                }

                var text = span.ToString();
                if (requestParameters.TryGetValue(text, out var requestParameter))
                {
                    orderedParameters.Add(requestParameter);
                }
            }
        }

        private static IEnumerable<InputParameter> GetLegacySortedParameters(IEnumerable<InputParameter> inputParameters)
            => inputParameters.OrderByDescending(p => p is { IsRequired: true, DefaultValue: null });
    }
}
