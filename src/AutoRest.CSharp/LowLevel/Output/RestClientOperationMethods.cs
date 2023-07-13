// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;

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

        int Order,
        InputOperation Operation,
        InputType? RequestBodyType,
        CSharpType? ResponseType,
        CSharpType? PageItemType,
        // May be not null when CreateNextPageMessage is null, referencing method created by for another operation
        MethodSignature? CreateNextPageMessageSignature
    );
}
