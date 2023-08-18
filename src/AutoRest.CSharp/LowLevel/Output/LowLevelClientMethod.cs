// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Samples.Models;

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
        IEnumerable<DpgOperationSample> Samples);
}
