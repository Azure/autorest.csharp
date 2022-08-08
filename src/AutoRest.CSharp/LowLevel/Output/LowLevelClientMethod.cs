// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models
{
    internal record LowLevelClientMethod(
        MethodSignature ProtocolMethodSignature,
        LowLevelConvenienceMethod? ConvenienceMethod,
        RestClientMethod RequestMethod,
        InputType? RequestBodyType,
        InputType? ResponseBodyType,
        Diagnostic ProtocolMethodDiagnostic,
        LowLevelPagingInfo? PagingInfo,
        OperationLongRunning? LongRunning);
}
