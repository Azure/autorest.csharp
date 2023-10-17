// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Samples.Models;

namespace AutoRest.CSharp.Output.Models
{
    internal record RestClientOperationMethods
    (
        Method CreateRequest,
        Method? CreateNextPageMessage,
        Method? Protocol,
        Method? ProtocolAsync,
        Method? Convenience,
        Method? ConvenienceAsync,
        Method? NextPageConvenience,
        Method? NextPageConvenienceAsync,
        ResponseClassifierType ResponseClassifier,

        // [TODO]: Order property is used required to preserve the order of methods in generated clients, it doesn't affect any semantics
        int Order,
        InputOperation Operation,
        CSharpType? ResponseType,
        CSharpType? PageItemType,
        IReadOnlyList<DpgOperationSample> Samples,
        // May be not null when CreateNextPageMessage is null, referencing method created by builder as `CreateRequest` for another operation
        MethodSignature? CreateNextPageMessageSignature
    );
}
