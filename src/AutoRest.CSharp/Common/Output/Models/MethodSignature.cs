// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models
{
    internal record MethodSignature(string Name, string? Description, string Modifiers, CSharpType? ReturnType, FormattableString? ReturnDescription, Parameter[] Parameters) : MethodSignatureBase(Name, Description, Modifiers, Parameters);
}
