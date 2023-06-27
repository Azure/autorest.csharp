// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class NonPagingOperationMethodsBuilderBase : OperationMethodsBuilderBase
    {
        protected NonPagingOperationMethodsBuilderBase(InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, StatusCodeSwitchBuilder statusCodeSwitchBuilder, ClientMethodParameters clientMethodParameters)
            : base(operation, restClient, fields, clientName, statusCodeSwitchBuilder, clientMethodParameters)
        {
        }

        protected override bool ShouldConvenienceMethodGenerated() => ResponseType is not null || base.ShouldConvenienceMethodGenerated();

        protected override IEnumerable<Method> BuildCreateRequestMethods(ResponseClassifierType responseClassifierType)
        {
            yield return BuildCreateRequestMethod(responseClassifierType);
        }

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
    }
}
