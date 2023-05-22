// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class NonPagingOperationMethodsBuilderBase : OperationMethodsBuilderBase
    {
        protected NonPagingOperationMethodsBuilderBase(InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, ClientMethodReturnTypes returnTypes, ClientMethodParameters clientMethodParameters)
            : base(operation, restClient, fields, clientName, typeFactory, returnTypes, clientMethodParameters)
        {
            ResponseType = returnTypes.ResponseType;
        }

        protected override bool ShouldConvenienceMethodGenerated() => ResponseType is not null || base.ShouldConvenienceMethodGenerated();

        protected CSharpType? ResponseType { get; }

        protected IEnumerable<MethodBodyStatement> AddProtocolMethodArguments(List<ValueExpression> protocolMethodArguments)
        {
            foreach (var protocolParameter in ProtocolMethodParameters)
            {
                if (ArgumentsMap.TryGetValue(protocolParameter, out var argument))
                {
                    protocolMethodArguments.Add(argument);
                    if (ConversionsMap.TryGetValue(protocolParameter, out var conversion))
                    {
                        yield return conversion;
                    }
                }
                else
                {
                    protocolMethodArguments.Add(protocolParameter);
                }
            }
        }

        protected static CSharpType? GetResponseType(InputOperation operation, TypeFactory typeFactory)
        {
            if (operation.HttpMethod == RequestMethod.Head && Input.Configuration.HeadAsBoolean)
            {
                return null;
            }

            var responseTypes = operation.Responses
                .Where(r => !r.IsErrorResponse)
                .Select(r => r.BodyType)
                .WhereNotNull()
                .Distinct()
                .ToList();

            return responseTypes.Count switch
            {
                0 => null,
                1 => TypeFactory.GetOutputType(typeFactory.CreateType(responseTypes[0])),
                _ => typeof(object)
            };
        }
    }
}
