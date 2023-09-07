// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;

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
        public abstract IReadOnlyList<MethodSignature> Methods { get; }

        private (IList<MethodSignature> Missing, IList<(List<MethodSignature> Current, MethodSignature Previous)> Updated)? _methodChangeset;
        private (IList<MethodSignature> Missing, IList<(List<MethodSignature> Current, MethodSignature Previous)> Updated)? MethodChangeset
            => _methodChangeset ??= CompareMethods(Methods.Union(Customization?.Methods ?? Array.Empty<MethodSignature>(), new MethodSignatureComparer()), PreviousContract?.Methods);

        public IList<OverloadMethodSignature> MissingOverloadMethods
        {
            get
            {
                var overloadMethods = new List<OverloadMethodSignature>();
                var updated = MethodChangeset?.Updated;
                if (updated is null)
                {
                    return Array.Empty<OverloadMethodSignature>();
                }

                foreach (var (current, previous) in updated)
                {
                    if (TryGetPreviousMethodWithLessOptionalParameters(current, previous, out var currentMethodToCall, out var missingParameters))
                    {
                        overloadMethods.Add(new OverloadMethodSignature(currentMethodToCall, previous.DisableOptionalParameters(), missingParameters, previous.FormattableDescription));
                    }
                }
                return overloadMethods;
            }
        }

        protected IReadOnlyList<MethodSignature> PopulateMethodsFromCompilation(Compilation? compilation)
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

        private IReadOnlyList<MethodSignature> PopulateMethods(INamedTypeSymbol? typeSymbol)
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
                var description = method.GetDocumentationCommentXml();
                var returnType = MgmtContext.TypeFactory.GetCsharpType(method.ReturnType);
                if (returnType is null)
                {
                    // TODO: handle missing method return type from MgmtOutputLibrary
                    continue;
                }

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
                result.Add(new MethodSignature(method.Name, null, description, MapModifiers(method), returnType, null, parameters));
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

        private static (IList<MethodSignature> Missing, IList<(List<MethodSignature> Current, MethodSignature Previous)> Updated)? CompareMethods(IEnumerable<MethodSignature> currentMethods, IEnumerable<MethodSignature>? previousMethods)
        {
            if (previousMethods is null)
            {
                return null;
            }
            var missing = new List<MethodSignature>();
            var updated = new List<(List<MethodSignature> Current, MethodSignature Previous)>();
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
                    if (dict.TryGetValue(item.Name, out var currentOverloadMethods))
                    {
                        updated.Add((currentOverloadMethods, item));
                    }
                    else
                    {
                        missing.Add(item);
                    }
                }
            }
            return (missing, updated);
        }

        private bool TryGetPreviousMethodWithLessOptionalParameters(IList<MethodSignature> currentMethods, MethodSignature previousMethod, [NotNullWhen(true)] out MethodSignature? currentMethodToCall, [NotNullWhen(true)] out IReadOnlyList<Parameter>? missingParameters)
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
