// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
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
        IReadOnlyList<MethodParametersBuilder.ParameterLink> ParameterLinks
    );

    internal record ClientPagingMethodParameters
    (
        IReadOnlyList<RequestPartSource> RequestParts,
        IReadOnlyList<Parameter> CreateMessage,
        IReadOnlyList<Parameter> CreateNextPageMessage,
        IReadOnlyList<Parameter> Protocol,
        IReadOnlyList<Parameter> Convenience,
        IReadOnlyList<MethodParametersBuilder.ParameterLink> ParameterLinks
    ) : ClientMethodParameters(RequestParts, CreateMessage, Protocol, Convenience, ParameterLinks);

    internal record ClientMethodReturnTypes
    (
        CSharpType? ResponseType,
        CSharpType ProtocolMethodReturnType,
        CSharpType ConvenienceMethodReturnType
    );
}
