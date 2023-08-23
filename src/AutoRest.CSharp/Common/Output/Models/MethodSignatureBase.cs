// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract record MethodSignatureBase(string Name, string? Summary, string? Description, MethodSignatureModifiers Modifiers, IReadOnlyList<Parameter> Parameters, IReadOnlyList<CSharpAttribute> Attributes)
    {
        public string? SummaryText => Summary.IsNullOrEmpty() ? Description : Summary;
        public string? DescriptionText => Summary.IsNullOrEmpty() || Description == Summary ? string.Empty : Description;

        public static IEnumerable<MethodSignature> PopulateMethods(INamedTypeSymbol? typeSymbol)
        {
            if (typeSymbol is null)
            {
                // TODO: handle missing type
                yield break;
            }
            var methods = typeSymbol!.GetMembers().OfType<IMethodSymbol>();
            foreach (var method in methods)
            {
                var typeFactory = new TypeFactory(MgmtContext.Library);
                if (typeFactory.TryCreateType(method.ReturnType, out var returnType))
                {
                    // TODO: handle missing parameter type from MgmtOutputLibrary
                    var parameters = new List<Parameter>();
                    foreach (var parameter in method.Parameters)
                    {
                        var methodParameter = Parameter.FromParameterSymbol(parameter);
                        if (methodParameter is not null)
                        {
                            parameters.Add(methodParameter);
                        }
                    }
                    yield return new MethodSignature(method.Name, null, null, MapModifiers(method), returnType, null, parameters);
                }
                else
                {
                    // TODO: handle missing method return type from MgmtOutputLibrary
                }
            }
        }

        private static MethodSignatureModifiers MapModifiers(IMethodSymbol methodSymbol)
        {
            var modifiers = MethodSignatureModifiers.None;
            var accessibility = methodSymbol.DeclaredAccessibility;
            switch (accessibility)
            {
                case Accessibility.Public:
                    modifiers |= MethodSignatureModifiers.Public;
                    break;
                case Accessibility.Internal:
                    modifiers |= MethodSignatureModifiers.Internal;
                    break;
                case Accessibility.Private:
                    modifiers |= MethodSignatureModifiers.Private;
                    break;
                case Accessibility.Protected:
                    modifiers |= MethodSignatureModifiers.Protected;
                    break;
                case Accessibility.ProtectedAndInternal:
                    modifiers |= MethodSignatureModifiers.Protected | MethodSignatureModifiers.Internal;
                    break;
            }
            if (methodSymbol.IsStatic)
            {
                modifiers |= MethodSignatureModifiers.Static;
            }
            if (methodSymbol.IsAsync)
            {
                modifiers |= MethodSignatureModifiers.Async;
            }
            if (methodSymbol.IsVirtual)
            {
                modifiers |= MethodSignatureModifiers.Virtual;
            }
            if (methodSymbol.IsOverride)
            {
                modifiers |= MethodSignatureModifiers.Override;
            }
            return modifiers;
        }
    }

    [Flags]
    internal enum MethodSignatureModifiers
    {
        None = 0,
        Public = 1,
        Internal = 2,
        Protected = 4,
        Private = 8,
        Static = 16,
        Extension = 32,
        Virtual = 64,
        Async = 128,
        New = 256,
        Override = 512
    }
}
