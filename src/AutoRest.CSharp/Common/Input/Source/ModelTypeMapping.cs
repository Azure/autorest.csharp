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

        public ModelTypeMapping(CodeGenAttributes codeGenAttributes, INamedTypeSymbol? existingType)
        {
            _existingType = existingType;
            _propertyMappings = new();
            _serializationMappings = new(SymbolEqualityComparer.Default);

            foreach (ISymbol member in GetMembers(existingType))
            {
                string[]? serializationPath = null;
                (string? SerializationHook, string? DeserializationHook)? serializationHooks = null;
                foreach (var attributeData in member.GetAttributes())
                {
                    var attributeTypeSymbol = attributeData.AttributeClass;
                    // handle CodeGenMember attribute
                    if (SymbolEqualityComparer.Default.Equals(attributeTypeSymbol, codeGenAttributes.CodeGenMemberAttribute) && TryGetCodeGenMemberAttributeValue(member, attributeData, out var schemaMemberName))
                    {
                        _propertyMappings.Add(schemaMemberName, member);
                    }
                    if (SymbolEqualityComparer.Default.Equals(attributeTypeSymbol, codeGenAttributes.CodeGenMemberSerializationAttribute) && TryGetSerializationAttributeValue(member, attributeData, out var pathResult))
                    {
                        serializationPath = pathResult;
                    }
                    if (SymbolEqualityComparer.Default.Equals(attributeTypeSymbol, codeGenAttributes.CodeGenMemberSerializationHooksAttribute) && TryGetSerializationHooks(member, attributeData, out var hooks))
                    {
                        serializationHooks = hooks;
                    }
                }
                if (serializationPath != null || serializationHooks != null)
                {
                    _serializationMappings.Add(member, new SourcePropertySerializationMapping(member, serializationPath, serializationHooks?.SerializationHook, serializationHooks?.DeserializationHook));
                }
            }

            if (existingType != null)
            {
                foreach (var attributeData in existingType.GetAttributes())
                {
                    var attributeClass = attributeData.AttributeClass;
                    if (SymbolEqualityComparer.Default.Equals(attributeClass, codeGenAttributes.CodeGenModelAttribute))
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

        private static bool TryGetSerializationHooks(ISymbol symbol, AttributeData attributeData, out (string? SerializationHook, string? DeserializationHook) hooks)
        {
            string? serializationHook = null;
            string? deserializationHook = null;

            var arguments = attributeData.ConstructorArguments;
            serializationHook = arguments[0].Value as string;
            deserializationHook = arguments[1].Value as string;

            hooks = (serializationHook, deserializationHook);
            return serializationHook != null || deserializationHook != null;
        }

        private static bool TryGetCodeGenMemberAttributeValue(ISymbol symbol, AttributeData attributeData, [MaybeNullWhen(false)] out string name)
        {
            name = attributeData.ConstructorArguments.FirstOrDefault().Value as string;
            return name != null;
        }

        private static bool TryGetSerializationAttributeValue(ISymbol symbol, AttributeData attributeData, [MaybeNullWhen(false)] out string[] propertyNames)
        {
            propertyNames = null;
            if (attributeData.ConstructorArguments.Length > 0)
            {
                propertyNames = ToStringArray(attributeData.ConstructorArguments[0].Values);
            }

            return propertyNames != null;
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
