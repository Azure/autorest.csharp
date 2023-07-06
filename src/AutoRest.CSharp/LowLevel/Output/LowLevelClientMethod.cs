// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal record LowLevelClientMethod
    (
        IReadOnlyList<Method> CreateRequest,
        IReadOnlyList<Method> Protocol,
        IReadOnlyList<Method> Convenience,
        ResponseClassifierType ResponseClassifier,

        int Order,
        InputOperation Operation,
        InputType? RequestBodyType,
        CSharpType? ResponseType,
        CSharpType? PageItemType
    );

    internal record LegacyMethods
    (
        Method CreateRequest,
        Method? CreateNextPageRequest,
        IReadOnlyList<Method> RestClientConvenience,
        IReadOnlyList<Method> RestClientNextPageConvenience,
        IReadOnlyList<Method> Convenience,

        int Order,
        InputOperation Operation,
        CSharpType? ResponseType
    );
}
