// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal record ConvenienceMethod(MethodSignature Signature, IReadOnlyList<ProtocolToConvenienceParameterConverter> ProtocolToConvenienceParameters, CSharpType? ResponseType, Diagnostic? Diagnostic);

    internal record ProtocolToConvenienceParameterConverter(Parameter Protocol, Parameter Convenience, ConvenienceParameterSpread? ConvenienceSpread);

    internal record ConvenienceParameterSpread(ModelTypeProvider BackingModel, IEnumerable<Parameter> SpreadedParameters);
}
