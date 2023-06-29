// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Output.Models
{
    internal record OperationMethodsBuilderBaseArgs(InputOperation Operation, ValueExpression? RestClientReference, ClientFields Fields, string ClientName, StatusCodeSwitchBuilder StatusCodeSwitchBuilder);
}
