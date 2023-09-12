// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Shared;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal abstract class TypeProvider
    {
        private SourceInputModel? _sourceInputModel;
        private readonly Lazy<INamedTypeSymbol?> _existingType;

        protected string? _deprecated;

        private TypeDeclarationOptions? _type;

        protected TypeProvider(string defaultNamespace, SourceInputModel? sourceInputModel)
        {
            _sourceInputModel = sourceInputModel;
            DefaultNamespace = defaultNamespace;
            _existingType = new Lazy<INamedTypeSymbol?>(() => sourceInputModel?.FindForType(DefaultNamespace, DefaultName));
        }

        protected TypeProvider(BuildContext context) : this(context.DefaultNamespace, context.SourceInputModel) { }

        public CSharpType Type => new(this, TypeKind is TypeKind.Struct or TypeKind.Enum, this is EnumType);
        public TypeDeclarationOptions Declaration => _type ??= BuildType();

        protected abstract string DefaultName { get; }
        protected virtual string DefaultNamespace { get; }
        protected abstract string DefaultAccessibility { get; }

        public string? Deprecated => _deprecated;
        protected virtual TypeKind TypeKind { get; } = TypeKind.Class;
        protected virtual bool IsAbstract { get; } = false;
        protected INamedTypeSymbol? ExistingType => _existingType.Value;

        internal virtual Type? SerializeAs => null;

        private TypeProvider? _customization;
        private TypeProvider? Customization => _customization ??= InstantiateTypeProvider is null ? null : InstantiateTypeProvider(PopulateMethodsFromCompilation(_sourceInputModel?.Customization));

        private TypeProvider? _previousContract;
        private TypeProvider? PreviousContract => _previousContract ??= InstantiateTypeProvider is null ? null : InstantiateTypeProvider(PopulateMethodsFromCompilation(_sourceInputModel?.PreviousContract));

        protected virtual Func<IReadOnlyList<MethodSignature>, TypeProvider>? InstantiateTypeProvider => null;

        protected virtual IReadOnlyList<MethodSignature> MethodSignatures => new List<MethodSignature>();

        // Missing means the method with the same name is missing from the current contract
        // Updated means the method with the same name is updated in the current contract, and the list contains the previous method and current methods including overloading ones
        private (IList<MethodSignature> Missing, IList<(List<MethodSignature> Current, MethodSignature Previous)> Updated)? _methodChangeset;
        private (IList<MethodSignature> Missing, IList<(List<MethodSignature> Current, MethodSignature Previous)> Updated)? MethodChangeset
            => _methodChangeset ??= CompareMethods(MethodSignatures.Union(Customization?.MethodSignatures ?? Array.Empty<MethodSignature>(), new MethodSignatureComparer()), PreviousContract?.MethodSignatures);

        public IList<OverloadMethodSignature> OverloadingMethods
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

        private IReadOnlyList<MethodSignature> PopulateMethodsFromCompilation(Compilation? compilation)
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

        private TypeDeclarationOptions BuildType()
        {
            return BuilderHelpers.CreateTypeAttributes(
                DefaultName,
                DefaultNamespace,
                DefaultAccessibility,
                ExistingType,
                existingTypeOverrides: TypeKind == TypeKind.Enum,
                isAbstract: IsAbstract);
        }

        public static string GetDefaultModelNamespace(string? namespaceExtension, string defaultNamespace)
        {
            if (namespaceExtension != default)
            {
                return namespaceExtension;
            }

            if (Configuration.ModelNamespace)
            {
                return $"{defaultNamespace}.Models";
            }

            return defaultNamespace;
        }

        public static string GetDefaultNamespace(string? namespaceExtension, BuildContext context)
            => GetDefaultModelNamespace(namespaceExtension, context.DefaultNamespace);

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            if (obj is not TypeProvider other)
                return false;

            return string.Equals(DefaultName, other.DefaultName, StringComparison.Ordinal) &&
                string.Equals(DefaultNamespace, other.DefaultNamespace, StringComparison.Ordinal) &&
                string.Equals(DefaultAccessibility, other.DefaultAccessibility, StringComparison.Ordinal) &&
                TypeKind == other.TypeKind;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DefaultName, DefaultNamespace, DefaultAccessibility, TypeKind);
        }
    }
}
