// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class ModelTypeMapping
    {
        private readonly INamedTypeSymbol? _existingType;
        private readonly Dictionary<string, ISymbol> _propertyMappings;
        private readonly Dictionary<string, ISymbol> _codeGenMemberMappings;
        private readonly Dictionary<ISymbol, SourcePropertySerializationMapping> _serializationMappings;

        public string[]? Usage { get; }
        public string[]? Formats { get; }

        public ModelTypeMapping(CodeGenAttributes codeGenAttributes, INamedTypeSymbol existingType)
        {
            _existingType = existingType;
            _propertyMappings = new();
            _codeGenMemberMappings = new();
            _serializationMappings = new(SymbolEqualityComparer.Default);

            foreach (ISymbol member in GetMembers(existingType))
            {
                // If member is defined in both base and derived class, use derived one
                if (member.Kind is SymbolKind.Property or SymbolKind.Field && !_propertyMappings.ContainsKey(member.Name))
                {
                    _propertyMappings[member.Name] = member;
                }

                string[]? serializationPath = null;
                string? serializationHook = null;
                string? deserializationHook = null;

                foreach (var attributeData in member.GetAttributes())
                {
                    // handle CodeGenMember attribute
                    if (codeGenAttributes.TryGetCodeGenMemberAttributeValue(attributeData, out var schemaMemberName))
                    {
                        _codeGenMemberMappings[schemaMemberName] = member;
                    }

                    // handle CodeGenMemberSerialization attribute
                    if (codeGenAttributes.TryGetCodeGenMemberSerializationAttributeValue(attributeData, out var pathResult))
                    {
                        serializationPath = pathResult;
                    }
                    // handle CodeGenMemberSerializationHooks attribute
                    codeGenAttributes.TryGetCodeGenMemberSerializationHooksAttributeValue(attributeData, out serializationHook, out deserializationHook);
                }

                if (serializationPath != null || serializationHook != null || deserializationHook != null)
                {
                    _serializationMappings.Add(member, new SourcePropertySerializationMapping(member, serializationPath, serializationHook, deserializationHook));
                }
            }

            foreach (var attributeData in existingType.GetAttributes())
            {
                // handle CodeGenModel attribute
                if (codeGenAttributes.TryGetCodeGenModelAttributeValue(attributeData, out var usage, out var formats))
                {
                    Usage = usage;
                    Formats = formats;
                }
            }
        }

        public ISymbol? GetMemberByOriginalName(string name)
            => _codeGenMemberMappings.TryGetValue(name, out var renamedSymbol)
                ? renamedSymbol
                : _propertyMappings.TryGetValue(name, out var memberSymbol) ? memberSymbol : null;

        public SourcePropertySerializationMapping? GetForMemberSerialization(ISymbol? symbol)
        {
            if (symbol == null)
                return null;

            if (_serializationMappings.TryGetValue(symbol, out var serialization))
                return serialization;

            return null;
        }

        public IEnumerable<SourcePropertySerializationMapping> GetSerializationMembers()
        {
            return _serializationMappings.Values;
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
