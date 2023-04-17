// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class ModelTypeMapping
    {
        private readonly INamedTypeSymbol? _existingType;
        private readonly Dictionary<string, ISymbol> _propertyMappings;
        private readonly Dictionary<ISymbol, string[]> _serializationMappings;

        public string[]? Usage { get; }
        public string[]? Formats { get; }

        public ModelTypeMapping(INamedTypeSymbol modelAttribute, INamedTypeSymbol memberAttribute, INamedTypeSymbol serializationAttribute, INamedTypeSymbol? existingType)
        {
            _existingType = existingType;
            _propertyMappings = new Dictionary<string, ISymbol>();
            _serializationMappings = new Dictionary<ISymbol, string[]>(SymbolEqualityComparer.Default);

            foreach (ISymbol member in GetMembers(existingType))
            {
                if (TryGetAttributeCtorParameterValue(member, memberAttribute, out var schemaMemberName))
                {
                    _propertyMappings.Add(schemaMemberName, member);
                }
                if (TryGetAttributeCtorParameterValues(member, serializationAttribute, out var serializationPath))
                {
                    _serializationMappings.Add(member, serializationPath);
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

        internal static bool TryGetAttributeCtorParameterValue(ISymbol symbol, INamedTypeSymbol attributeType, [MaybeNullWhen(false)] out string name)
        {
            name = null;

            var attribute = symbol.GetAttributes().SingleOrDefault(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass, attributeType));

            if (attribute?.ConstructorArguments.Length > 0)
            {
                name = attribute.ConstructorArguments[0].Value as string;
            }

            return name != null;
        }

        internal static bool TryGetAttributeCtorParameterValues(ISymbol symbol, INamedTypeSymbol attributeType, [MaybeNullWhen(false)] out string[] parameters)
        {
            parameters = null;

            var attributes = symbol.GetAttributes().SingleOrDefault(a => SymbolEqualityComparer.Default.Equals(a.AttributeClass, attributeType));
            if (attributes?.ConstructorArguments.Length > 0)
            {
                parameters = ToStringArray(attributes.ConstructorArguments[0].Values);
            }

            return parameters != null;
        }

        private static string[]? ToStringArray(ImmutableArray<TypedConstant> values)
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

        public SourceMemberMapping? GetForMember(string name)
        {
            if (!_propertyMappings.TryGetValue(name, out var memberSymbol))
            {
                memberSymbol = _existingType?.GetMembers(name).FirstOrDefault();
            }

            if (memberSymbol != null)
            {
                return new SourceMemberMapping(name, memberSymbol);
            }

            return null;
        }

        public IEnumerable<SourcePropertySerailizationMapping> GetSerializationMembers()
        {
            foreach (var (symbol, serializations) in _serializationMappings)
            {
                yield return new SourcePropertySerailizationMapping(symbol, serializations);
            }
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
