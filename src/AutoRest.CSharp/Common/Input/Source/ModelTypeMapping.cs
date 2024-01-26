// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class ModelTypeMapping
    {
        private readonly Dictionary<string, ISymbol> _propertyMappings;
        private readonly Dictionary<string, ISymbol> _codeGenMemberMappings;
        private readonly Dictionary<ISymbol, SourcePropertySerializationMapping> _propertySerializationMappings;
        private readonly Dictionary<string, SourcePropertySerializationMapping> _typeSerializationMappings;

        public string[]? Usage { get; }
        public string[]? Formats { get; }

        public ModelTypeMapping(CodeGenAttributes codeGenAttributes, INamedTypeSymbol existingType)
        {
            _propertyMappings = new();
            _codeGenMemberMappings = new();
            _propertySerializationMappings = new(SymbolEqualityComparer.Default);
            _typeSerializationMappings = new();

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
                    if (codeGenAttributes.TryGetCodeGenMemberSerializationAttributeValue(attributeData, out var propertyNames))
                    {
                        serializationPath = propertyNames;
                    }
                    // handle CodeGenMemberSerializationHooks attribute (here this attribute is added to a property therefore propertyName will be ignored
                    codeGenAttributes.TryGetCodeGenMemberSerializationHooksAttributeValue(attributeData, out _, out serializationHook, out deserializationHook);
                }
                if (serializationPath != null || serializationHook != null || deserializationHook != null)
                {
                    _propertySerializationMappings.Add(member, new(member, serializationPath, serializationHook, deserializationHook));
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

                // handle CodeGenMemberSerializationHooks attribute
                if (codeGenAttributes.TryGetCodeGenMemberSerializationHooksAttributeValue(attributeData, out var propertyName, out var serializationHook, out var deserializationHook))
                {
                    if (propertyName == null)
                        throw new InvalidOperationException($"{nameof(CodeGenMemberSerializationHooksAttribute)} defines on type {existingType.MetadataName}, PropertyName is required");
                    _typeSerializationMappings.Add(propertyName, new(propertyName, null, serializationHook, deserializationHook));
                }
            }
        }

        public ISymbol? GetMemberByOriginalName(string name)
            => _codeGenMemberMappings.TryGetValue(name, out var renamedSymbol) ?
                renamedSymbol :
                _propertyMappings.TryGetValue(name, out var memberSymbol) ? memberSymbol : null;

        public SourcePropertySerializationMapping? GetForMemberSerialization(ISymbol? symbol)
        {
            if (symbol == null)
                return null;

            if (_propertySerializationMappings.TryGetValue(symbol, out var serialization))
                return serialization;

            return null;
        }

        public IEnumerable<SourcePropertySerializationMapping> GetSerializationMembers()
        {
            return _propertySerializationMappings.Values;
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
