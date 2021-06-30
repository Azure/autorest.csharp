// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models
{
    internal class MethodSignature
    {
        public MethodSignature(string name, string? description, string modifiers, Parameter[] parameters, MethodSignature? baseMethod = default)
            : this(name, description, modifiers, null, null, parameters, baseMethod)
        {
        }

        public MethodSignature(string name, string? description, string modifiers, CSharpType? returnType, string? returnDescription, Parameter[] parameters, MethodSignature? baseMethod = default)
        {
            Name = name;
            Description = description;
            Modifiers = modifiers;
            ReturnType = returnType;
            ReturnDescription = returnDescription;
            Parameters = parameters;
            BaseMethod = baseMethod;
        }

        public string Name { get; }
        public string? Description { get; }
        public string Modifiers { get; }
        public CSharpType? ReturnType { get; }
        public string? ReturnDescription { get; }
        public Parameter[] Parameters { get; }
        public MethodSignature? BaseMethod { get; }
    }
}
