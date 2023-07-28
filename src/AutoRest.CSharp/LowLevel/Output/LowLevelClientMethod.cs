// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models
{
    internal record LowLevelClientMethod(
        MethodSignature ProtocolMethodSignature,
        ConvenienceMethod? ConvenienceMethod,
        RestClientMethod RequestMethod,
        InputType? RequestBodyType,
        InputType? ResponseBodyType,
        Diagnostic ProtocolMethodDiagnostic,
        ProtocolMethodPaging? PagingInfo,
        OperationLongRunning? LongRunning,
        RequestConditionHeaders ConditionHeaderFlag,
        ConvenienceMethodOmitReason? ConvenienceMethodOmitReason);
}
