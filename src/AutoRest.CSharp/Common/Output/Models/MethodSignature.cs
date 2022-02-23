// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models
{
    internal record MethodSignature(string Name, string? Description, string Modifiers, CSharpType? ReturnType, FormattableString? ReturnDescription, Parameter[] Parameters, bool IsPageable = false) : MethodSignatureBase(Name, Description, Modifiers, Parameters)
    {
        public MethodSignature MakeAsync() => this with
        {
            Modifiers = Modifiers + " async",
            Name = Name + "Async",
            ReturnType = ReturnType != null ? new CSharpType(typeof(Task<>), ReturnType) : new CSharpType(typeof(Task))
        };
    }
}
