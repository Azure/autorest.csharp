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
        ConvenienceMethodOmittingMessage? ConvenienceMethodOmittingMessage)
    {
        public bool ShouldGenerateConvenienceMethodRef()
        {
            // we only generate the convenience method ref when convenience method and protocol method have the same accessibility
            var convenienceMethod = ConvenienceMethod?.Signature.Modifiers;
            var protocolMethod = ProtocolMethodSignature.Modifiers;

            if (convenienceMethod?.HasFlag(MethodSignatureModifiers.Public) is true && protocolMethod.HasFlag(MethodSignatureModifiers.Public) is true)
                return true;

            if (convenienceMethod?.HasFlag(MethodSignatureModifiers.Internal) is true && protocolMethod.HasFlag(MethodSignatureModifiers.Internal) is true)
                return true;

            return false;
        }
    }
}
