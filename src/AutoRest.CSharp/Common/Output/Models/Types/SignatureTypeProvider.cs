// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Shared;
using System;
using System.Linq;
using AutoRest.CSharp.Mgmt.Decorator;
using System.Diagnostics.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class SignatureTypeProvider
    {
        private readonly string _defaultNamespace;
        private readonly string _defaultName;
        private readonly SignatureTypeProvider? _customization;
        private readonly SignatureTypeProvider? _previousContract;

        // Missing means the method with the same name is missing from the current contract
        // Updated means the method with the same name is updated in the current contract, and the list contains the previous method and current methods including overloading ones
        private readonly (IReadOnlyList<MethodSignature> Missing, IReadOnlyList<(List<MethodSignature> Current, MethodSignature Previous)> Updated)? _methodChangeset;

        public SignatureTypeProvider(IReadOnlyList<MethodSignature> methods, SourceInputModel? sourceInputModel, string defaultNamespace, string defaultName)
        {
            Methods = methods;
            _defaultNamespace = defaultNamespace;
            _defaultName = defaultName;
            if (sourceInputModel is not null)
            {
                _customization = new SignatureTypeProvider(PopulateMethodsFromCompilation(sourceInputModel?.Customization), null, defaultNamespace, defaultName);
                _previousContract = new SignatureTypeProvider(PopulateMethodsFromCompilation(sourceInputModel?.PreviousContract), null, defaultNamespace, defaultName);
                _methodChangeset ??= CompareMethods(Methods.Union(_customization?.Methods ?? Array.Empty<MethodSignature>(), new MethodSignatureComparer()), _previousContract?.Methods);
            }
        }

        private IReadOnlyList<OverloadMethodSignature>? _overloadingMethods;
        public IReadOnlyList<OverloadMethodSignature> OverloadingMethods => _overloadingMethods ??= EnsureOverloadingMethods();

        private IReadOnlyList<OverloadMethodSignature> EnsureOverloadingMethods()
        {
            var overloadMethods = new List<OverloadMethodSignature>();
            var updated = _methodChangeset?.Updated;
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

        private HashSet<MethodSignature>? _methodsToSkip;
        public HashSet<MethodSignature> MethodsToSkip => _methodsToSkip ??= EnsureMethodsToSkip();
        private HashSet<MethodSignature> EnsureMethodsToSkip()
        {
            if (_customization is null)
            {
                return new HashSet<MethodSignature>();
            }
            return Methods.Intersect(_customization.Methods, new MethodSignatureComparer()).ToHashSet(new MethodSignatureComparer());
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

                if (!previousMethod.ReturnType.EqualsBySystemType(item.ReturnType))
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

        private static (IReadOnlyList<MethodSignature> Missing, IReadOnlyList<(List<MethodSignature> Current, MethodSignature Previous)> Updated)? CompareMethods(IEnumerable<MethodSignature> currentMethods, IEnumerable<MethodSignature>? previousMethods)
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

        public IReadOnlyList<MethodSignature> Methods { get; }

        private IReadOnlyList<MethodSignature> PopulateMethodsFromCompilation(Compilation? compilation)
        {
            if (compilation is null)
            {
                return new List<MethodSignature>();
            }
            var type = compilation.Assembly.GetTypeByMetadataName($"{_defaultNamespace}.{_defaultName}");
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
    }
}
