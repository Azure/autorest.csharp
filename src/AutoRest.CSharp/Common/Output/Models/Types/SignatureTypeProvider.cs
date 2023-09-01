// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Humanizer;
using Microsoft.CodeAnalysis;
using MethodParameter = AutoRest.CSharp.Output.Models.Shared.Parameter;

namespace AutoRest.CSharp.Common.Output.Models.Types
{
    internal abstract class SignatureTypeProvider : TypeProvider
    {
        protected SignatureTypeProvider(string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
        }

        protected abstract SignatureTypeProvider? Customization { get; }

        protected abstract SignatureTypeProvider? PreviousContract { get; }

        // TODO: store the implementation of missing methods along with declaration
        public abstract IList<MethodSignature> Methods { get; }

        public IList<(MethodSignature CurrentMethodToCall, MethodSignature PreviousMethodToAdd, IList<MethodParameter> MissingParameters)> MissingOverloadMethods
        {
            get
            {
                if (Methods == null || PreviousContract?.Methods == null)
                {
                    return Array.Empty<(MethodSignature, MethodSignature, IList<MethodParameter>)>();
                }

                IList<MethodSignature> missing;
                IList<(MethodSignature, MethodSignature, IList<MethodParameter>)> updated;
                if (Customization?.Methods != null)
                {
                    (missing, updated) = CompareMethods(Methods.Union(Customization!.Methods), PreviousContract.Methods);
                }
                else
                {
                    (missing, updated) = CompareMethods(Methods, PreviousContract!.Methods);
                }
                return updated;
            }
        }

        protected IList<MethodSignature> PopulateMethodsFromCompilation(Compilation? compilation)
        {
            if (compilation is null)
            {
                return new List<MethodSignature>();
            }
            var type = compilation.Assembly.GetTypeByMetadataName($"{DefaultNamespace}.{DefaultName}");
            if (type is null)
            {
                return new List<MethodSignature>();
            }
            return PopulateMethods(type);
        }

        private IList<MethodSignature> PopulateMethods(INamedTypeSymbol? typeSymbol)
        {
            var result = new List<MethodSignature>();
            if (typeSymbol is null)
            {
                // TODO: handle missing type
                return result;
            }
            var methods = typeSymbol!.GetMembers().OfType<IMethodSymbol>();
            foreach (var method in methods)
            {
                ;
                if (MgmtContext.TypeFactory.TryCreateType(method.ReturnType, out var returnType))
                {
                    // TODO: handle missing parameter type from MgmtOutputLibrary
                    var parameters = new List<MethodParameter>();
                    foreach (var parameter in method.Parameters)
                    {
                        var methodParameter = MethodParameter.FromParameterSymbol(parameter);
                        if (methodParameter is not null)
                        {
                            parameters.Add(methodParameter);
                        }
                    }
                    result.Add(new MethodSignature(method.Name, null, null, MapModifiers(method), returnType, null, parameters));
                }
                else
                {
                    // TODO: handle missing method return type from MgmtOutputLibrary
                }
            }
            return result;
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

        private (IList<MethodSignature> MissingMethods, IList<(MethodSignature CurrentMethodToCall, MethodSignature PreviousMethodToAdd, IList<MethodParameter> MissingParameters)> UpdatedMethods)
            CompareMethods(IEnumerable<MethodSignature> currentMethods, IEnumerable<MethodSignature> previousMethods)
        {
            var missing = new List<MethodSignature>();
            var updated = new List<(MethodSignature, MethodSignature, IList<MethodParameter>)>();
            var set = currentMethods.ToHashSet(new MethodSignatureComparer());
            var dict = new Dictionary<string, List<MethodSignature>>();
            foreach (var item in currentMethods)
            {
                if (!dict.TryGetValue(item.Name, out var list))
                {
                    dict.Add(item.Name, new List<MethodSignature> { item });
                }
                else
                {
                    list.Add(item);
                }
            }
            foreach (var item in previousMethods)
            {
                if (!set.Contains(item))
                {
                    if (dict.TryGetValue(item.Name, out var current))
                    {
                        if (TryGetPreviousMethodWithLessOptionalParameters(current, item, out var currentMethodToCall, out var missingParameters))
                        {
                            updated.Add((currentMethodToCall, item, missingParameters));
                        }
                    }
                    else
                    {
                        missing.Add(item);
                    }
                }
            }
            return (missing, updated);
        }

        private bool TryGetPreviousMethodWithLessOptionalParameters(IList<MethodSignature> currentMethods, MethodSignature previousMethod, [NotNullWhen(true)] out MethodSignature? currentMethodToCall, [NotNullWhen(true)] out IList<MethodParameter>? missingParameters)
        {
            foreach (var item in currentMethods)
            {
                if (item.Parameters.Count <= previousMethod.Parameters.Count)
                {
                    continue;
                }

                if (!CurrentContainAllPreviousParameters(previousMethod, item))
                {
                    continue;
                }

                var parameters = item.Parameters.Except(previousMethod.Parameters, new ParameterComparer());
                if (parameters.All(x => x.IsOptionalInSignature))
                {
                    missingParameters = parameters.ToList();
                    currentMethodToCall = item;
                    return true;
                }
            }
            missingParameters = null;
            currentMethodToCall = null;
            return false;
        }

        private bool CurrentContainAllPreviousParameters(MethodSignature previousMethod, MethodSignature currentMethod)
        {
            var set = currentMethod.Parameters.ToHashSet(new ParameterComparer());
            foreach (var parameter in previousMethod.Parameters)
            {
                if (!set.Contains(parameter))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
