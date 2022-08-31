// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class ModelTypeMapping
    {
        private readonly INamedTypeSymbol? _existingType;
        private readonly Dictionary<string, ISymbol> _propertyMappings;

        public string[]? Usage { get; }
        public string[]? Formats { get; }

        public ModelTypeMapping(INamedTypeSymbol modelAttribute, INamedTypeSymbol memberAttribute, INamedTypeSymbol? existingType)
        {
            _existingType = existingType;
            _propertyMappings = new Dictionary<string, ISymbol>();

            foreach (ISymbol member in GetMembers(existingType))
            {
                if (SourceInputModel.TryGetName(member, memberAttribute, out var schemaMemberName))
                {
                    _propertyMappings.Add(schemaMemberName, member);
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
                .Select(v => (string?) v.Value)
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
