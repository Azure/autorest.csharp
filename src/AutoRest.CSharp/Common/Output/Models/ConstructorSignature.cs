// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models
{
    internal record ConstructorSignature(string Name, string? Description, MethodSignatureModifiers Modifiers, Parameter[] Parameters, ConstructorInitializer? Initializer = null) : MethodSignatureBase(Name, Description, Modifiers, Parameters);
}
