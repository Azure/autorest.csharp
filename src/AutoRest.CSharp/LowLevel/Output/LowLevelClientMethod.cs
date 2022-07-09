// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models
{
    internal record LowLevelClientMethod(MethodSignature Signature, RestClientMethod RequestMethod, Schema? RequestBodySchema, Schema? ResponseBodySchema, Diagnostic Diagnostic, LowLevelPagingInfo? PagingInfo, OperationLongRunning? LongRunning);
}
