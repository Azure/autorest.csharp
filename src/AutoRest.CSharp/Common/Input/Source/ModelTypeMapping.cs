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
        private readonly Dictionary<ISymbol, SourcePropertySerializationMapping> _serializationMappings;

        public string[]? Usage { get; }
        public string[]? Formats { get; }

        public ModelTypeMapping(CodeGenAttributes codeGenAttributes, INamedTypeSymbol existingType)
        {
            _existingType = existingType;
            _propertyMappings = new();
            _serializationMappings = new(SymbolEqualityComparer.Default);

            foreach (ISymbol member in GetMembers(existingType))
            {
                bool hasCodeGenMemberAttribute = false;
                string[]? serializationPath = null;
                string? serializationHook = null;
                string? deserializationHook = null;

                foreach (var attributeData in member.GetAttributes())
                {
                    // handle CodeGenMember attribute
                    if (codeGenAttributes.TryGetCodeGenMemberAttributeValue(attributeData, out var schemaMemberName))
                    {
                        hasCodeGenMemberAttribute = true;
                        _propertyMappings.Add(schemaMemberName, member);
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

                // If member is defined in both base and derived class, use derived one
                if (member.Kind is SymbolKind.Property or SymbolKind.Field && !hasCodeGenMemberAttribute && !_propertyMappings.ContainsKey(member.Name))
                {
                    _propertyMappings.Add(member.Name, member);
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
        {
            return !_propertyMappings.TryGetValue(name, out var memberSymbol) ? _existingType?.GetMembers(name).FirstOrDefault() : memberSymbol;
        }

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
