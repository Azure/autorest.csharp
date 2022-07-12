// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models
{
    internal record ConstructorSignature(string Name, string? Description, string? Summary, MethodSignatureModifiers Modifiers, IReadOnlyList<Parameter> Parameters, ConstructorInitializer? Initializer = null) : MethodSignatureBase(Name, Description, Summary, Modifiers, Parameters);
}
