// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class NonPagingOperationMethodsBuilderBase : OperationMethodsBuilderBase
    {
        private readonly IReadOnlyList<MethodParametersBuilder.ParameterLink> _parameterLinks;

        protected NonPagingOperationMethodsBuilderBase(InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, ClientMethodReturnTypes returnTypes, ClientMethodParameters clientMethodParameters)
            : base(operation, restClient, fields, clientName, typeFactory, returnTypes, clientMethodParameters)
        {
            ResponseType = returnTypes.ResponseType;
            _parameterLinks = clientMethodParameters.ParameterLinks;
        }

        protected override bool ShouldConvenienceMethodGenerated() => ResponseType is not null || base.ShouldConvenienceMethodGenerated();

        protected CSharpType? ResponseType { get; }

        protected IEnumerable<MethodBodyStatement> AddProtocolMethodArguments(List<ValueExpression> protocolMethodArguments)
        {
            foreach (var parameterLink in _parameterLinks)
            {
                switch (parameterLink)
                {
                    case { ProtocolParameters.Count: 0 }:
                        // Skip the convenience-only parameters
                        break;
                    case { ProtocolParameters: [var protocolParameter], ConvenienceParameters: [var convenienceParameter], IntermediateSerialization: null }:
                        if (protocolParameter == KnownParameters.RequestContext && convenienceParameter == KnownParameters.CancellationTokenParameter)
                        {
                            yield return Declare(RequestContextExpression.FromCancellationToken(), out var requestContext);
                            protocolMethodArguments.Add(requestContext);
                        }
                        else if (convenienceParameter != protocolParameter)
                        {
                            protocolMethodArguments.Add(CreateConversion(convenienceParameter, protocolParameter.Type));
                        }
                        else
                        {
                            protocolMethodArguments.Add(new ParameterReference(protocolParameter));
                        }
                        break;
                    case { ProtocolParameters: [var protocolParameter], ConvenienceParameters.Count: > 1, IntermediateSerialization: {} serializations }:
                        yield return Var(protocolParameter.Name, Utf8JsonRequestContentExpression.New(), out var requestContent);
                        yield return Var("writer", requestContent.JsonWriter, out var utf8JsonWriter);
                        yield return CreateSpreadConversion(utf8JsonWriter, serializations).AsStatement();

                        protocolMethodArguments.Add(requestContent);
                        break;
                    case { ProtocolParameters.Count: > 1, ConvenienceParameters.Count: 1, IntermediateSerialization: {} model }:
                        // Grouping is not supported yet
                        break;
                }
            }
        }

        protected static CSharpType? GetResponseType(InputOperation operation, TypeFactory typeFactory)
        {
            if (operation.HttpMethod == RequestMethod.Head && Input.Configuration.HeadAsBoolean)
            {
                return null;
            }

            var firstResponseBodyType = operation.Responses.Where(r => !r.IsErrorResponse).Select(r => r.BodyType).Distinct().FirstOrDefault();
            var responseType = firstResponseBodyType is not null ? typeFactory.CreateType(firstResponseBodyType) : null;
            return responseType is null ? null : TypeFactory.GetOutputType(responseType);
        }
    }
}
