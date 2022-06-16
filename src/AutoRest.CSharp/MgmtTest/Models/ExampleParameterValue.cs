// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.MgmtTest.Models
{
    internal record ExampleParameterValue(Parameter Parameter, ExampleValue? Value, FormattableString? RawValue, FormattableString? Note = null);
}
