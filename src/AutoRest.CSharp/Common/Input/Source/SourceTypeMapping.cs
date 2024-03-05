// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class SourceTypeMapping
    {
        private readonly List<IMethodSymbol> _methodSymbols;
        private readonly Dictionary<string, ISymbol> _propertyMappings;
        private readonly Dictionary<string, ISymbol> _codeGenMemberMappings;
        private readonly Dictionary<string, SourcePropertySerializationMapping> _typeSerializationMappings;

        public string[]? Usage { get; }
        public string[]? Formats { get; }

        public SourceTypeMapping(CodeGenAttributes codeGenAttributes, INamedTypeSymbol existingType)
        {
            _methodSymbols = new();
            _propertyMappings = new();
            _codeGenMemberMappings = new();
            _typeSerializationMappings = new();

            foreach (ISymbol member in GetMembers(existingType))
            {
                // If member is defined in both base and derived class, use derived one
                if (IsPropertyOrFieldSymbol(member) && !_propertyMappings.ContainsKey(member.Name))
                {
                    _propertyMappings[member.Name] = member;
                }

                if (IsMethodSymbol(member))
                {
                    _methodSymbols.Add((IMethodSymbol)member);
                }

                foreach (var attributeData in member.GetAttributes())
                {
                    // handle CodeGenMember attribute
                    if (codeGenAttributes.TryGetCodeGenMemberAttributeValue(attributeData, out var schemaMemberName))
                    {
                        _codeGenMemberMappings[schemaMemberName] = member;
                    }
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

                // handle CodeGenSerialization attribute
                if (codeGenAttributes.TryGetCodeGenSerializationAttributeValue(attributeData, out var propertyName, out var serializationNames, out var serializationHook, out var deserializationHook, out var bicepSerializationHook) && !_typeSerializationMappings.ContainsKey(propertyName))
                {
                    _typeSerializationMappings.Add(propertyName, new(propertyName, serializationNames, serializationHook, deserializationHook, bicepSerializationHook));
                }
            }
        }

        private static bool IsPropertyOrFieldSymbol(ISymbol member)
        {
            // here we exclude those "CompilerGenerated" members, such as the backing field of a property which is also a field.
            return !member.IsImplicitlyDeclared && member is IPropertySymbol or IFieldSymbol;
        }

        private static bool IsMethodSymbol(ISymbol member)
        {
            // here we exclude those "CompilerGenerated" members and ctor symbols
            return !member.IsImplicitlyDeclared && member is IMethodSymbol method && method.MethodKind != MethodKind.Constructor;
        }

        public ISymbol? GetMemberByOriginalName(string name)
            => _codeGenMemberMappings.TryGetValue(name, out var renamedSymbol) ?
                renamedSymbol :
                _propertyMappings.TryGetValue(name, out var memberSymbol) ? memberSymbol : null;

        public SourcePropertySerializationMapping? GetForMemberSerialization(string name)
            => _typeSerializationMappings.TryGetValue(name, out var serialization) ? serialization : null;

        public IEnumerable<ISymbol> GetPropertiesWithSerialization()
        {
            // only the property with CodeGenSerialization attribute will be emitted into the serialization code.
            foreach (var (propertyName, symbol) in _propertyMappings)
            {
                if (_typeSerializationMappings.ContainsKey(propertyName))
                    yield return symbol;
            }
        }

        public IEnumerable<IMethodSymbol> GetMethods() => _methodSymbols;

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
