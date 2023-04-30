// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models
{
    internal record ClientMethodParameters
    (
        IReadOnlyList<RequestPartSource> RequestParts,
        IReadOnlyList<Parameter> CreateMessage,
        IReadOnlyList<Parameter> Protocol,
        IReadOnlyList<Parameter> Convenience,
        bool HasRequestContextInCreateMessage,
        IReadOnlyDictionary<Parameter, ValueExpression> Arguments,
        IReadOnlyDictionary<Parameter, MethodBodyStatement> Conversions
    );

    internal record ClientPagingMethodParameters
    (
        IReadOnlyList<RequestPartSource> RequestParts,
        IReadOnlyList<Parameter> CreateMessage,
        IReadOnlyList<Parameter> CreateNextPageMessage,
        IReadOnlyList<Parameter> Protocol,
        IReadOnlyList<Parameter> Convenience,
        bool HasRequestContextInCreateMessage,
        IReadOnlyDictionary<Parameter, ValueExpression> Arguments,
        IReadOnlyDictionary<Parameter, MethodBodyStatement> Conversions

    ) : ClientMethodParameters(RequestParts, CreateMessage, Protocol, Convenience, HasRequestContextInCreateMessage, Arguments, Conversions)
    {
        public ClientPagingMethodParameters(ClientMethodParameters parameters, IReadOnlyList<Parameter> createNextPageMessage)
            : this(parameters.RequestParts, parameters.CreateMessage, createNextPageMessage, parameters.Protocol, parameters.Convenience, parameters.HasRequestContextInCreateMessage, parameters.Arguments, parameters.Conversions)
        {
        }
    }

    internal record ClientMethodReturnTypes
    (
        CSharpType? ResponseType,
        CSharpType ProtocolMethodReturnType,
        CSharpType ConvenienceMethodReturnType
    );
}
