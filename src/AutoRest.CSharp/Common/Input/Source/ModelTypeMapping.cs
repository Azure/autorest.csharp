// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class ModelTypeMapping
    {
        private readonly INamedTypeSymbol? _existingType;
        private readonly Dictionary<string, ISymbol> _propertyMappings;
        private readonly Dictionary<string, List<IMethodSymbol>> _methodMappings;

        public string[]? Usage { get; }
        public string[]? Formats { get; }

        public ModelTypeMapping(INamedTypeSymbol modelAttribute, INamedTypeSymbol memberAttribute, INamedTypeSymbol? existingType)
        {
            _existingType = existingType;
            _propertyMappings = new Dictionary<string, ISymbol>();
            _methodMappings = new Dictionary<string, List<IMethodSymbol>>();

            foreach (ISymbol member in GetMembers(existingType))
            {
                if (SourceInputModel.TryGetName(member, memberAttribute, out var schemaMemberName))
                {
                    _propertyMappings.Add(schemaMemberName, member);
                }

                if (member is IMethodSymbol methodSymbol)
                {
                    _methodMappings.AddInList(methodSymbol.Name, methodSymbol);
                }
            }

            if (existingType != null)
            {
                foreach (var attributeData in existingType.GetAttributes())
                {
                    if (SymbolEqualityComparer.Default.Equals(attributeData.AttributeClass, modelAttribute))
                    {
                        foreach (var namedArgument in attributeData.NamedArguments)
                        {
                            switch (namedArgument.Key)
                            {
                                case nameof(CodeGenModelAttribute.Usage):
                                    Usage = ToStringArray(namedArgument.Value.Values);
                                    break;
                                case nameof(CodeGenModelAttribute.Formats):
                                    Formats = ToStringArray(namedArgument.Value.Values);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private string[]? ToStringArray(ImmutableArray<TypedConstant> values)
        {
            if (values.IsDefaultOrEmpty)
            {
                return null;
            }

            return values
                .Select(v => (string?)v.Value)
                .OfType<string>()
                .ToArray();
        }

        internal SourcePropertyMapping? GetForMember(string name)
        {
            if (!_propertyMappings.TryGetValue(name, out var memberSymbol))
            {
                memberSymbol = _existingType?.GetMembers(name).FirstOrDefault();
            }

            if (memberSymbol != null)
            {
                return new SourcePropertyMapping(name, memberSymbol);
            }

            return null;
        }

        internal SourceMethodMapping? GetForMember(string name, IReadOnlyList<CSharpType> parameterTypes)
        {
            if (!_methodMappings.TryGetValue(name, out var methods))
                return null;

            foreach (var method in methods)
            {
                // we cannot say "we can only support framework type" here, therefore using NamedTypeSymbolExtensions.GetCSharpType is not an option here because it only supports getting CSharpType from a framework type
                var parameterTypeSymbols = method.Parameters.Select(p => (INamedTypeSymbol)p.Type).ToArray();
                if (IsSameTypeList(parameterTypeSymbols, parameterTypes))
                    return new SourceMethodMapping(name, parameterTypes, method);
            }

            return null;
        }

        private static bool IsSameTypeList(IReadOnlyList<INamedTypeSymbol> typeSymbols, IReadOnlyList<CSharpType> types)
        {
            if (typeSymbols.Count != types.Count)
                return false;

            for (int i = 0; i < typeSymbols.Count; i++)
            {
                if (!typeSymbols[i].IsSameType(types[i]))
                    return false;
            }

            return true;
        }

        private static IEnumerable<ISymbol> GetMembers(INamedTypeSymbol? typeSymbol)
        {
            while (typeSymbol != null)
            {
                foreach (var symbol in typeSymbol.GetMembers())
                {
                    yield return symbol;
                }

                typeSymbol = typeSymbol.BaseType;
            }
        }
    }
}
