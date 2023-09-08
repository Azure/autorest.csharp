// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;

namespace AutoRest.CSharp.Output.Models
{
    internal record OperationMethodsBuilderBaseArgs
    (
        InputOperation Operation,
        ClientFields Fields,
        string ClientNamespace,
        string ClientName,
        StatusCodeSwitchBuilder StatusCodeSwitchBuilder,
        TypeFactory TypeFactory,
        SourceInputModel? SourceInputModel
    );
}
