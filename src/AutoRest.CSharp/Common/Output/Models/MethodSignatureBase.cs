// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract record MethodSignatureBase(string Name, string? Description, string Modifiers, Parameter[] Parameters);
}
