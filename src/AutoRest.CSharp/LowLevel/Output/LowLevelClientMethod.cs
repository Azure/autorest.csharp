// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models
{
    internal record LowLevelClientMethod(
        IReadOnlyList<Method> ConvenienceMethods,
        IReadOnlyList<Method> ProtocolMethods,
        IReadOnlyList<RestClientMethod> RequestMethods,
        InputType? RequestBodyType,
        InputType? ResponseBodyType,
        ProtocolMethodPaging? PagingInfo,
        OperationLongRunning? LongRunning);
}
