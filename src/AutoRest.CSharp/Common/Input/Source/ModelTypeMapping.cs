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
        private readonly Dictionary<ISymbol, (string? SerializationHook, string? DeserializationHook)> _serializationHooksMappings;

        public string[]? Usage { get; }
        public string[]? Formats { get; }

        public ModelTypeMapping(INamedTypeSymbol modelAttribute, INamedTypeSymbol memberAttribute, INamedTypeSymbol serializationAttribute, INamedTypeSymbol serializationHooksAttribute, INamedTypeSymbol? existingType)
        {
            _existingType = existingType;
            _propertyMappings = new Dictionary<string, ISymbol>();
            _serializationMappings = new Dictionary<ISymbol, string[]>(SymbolEqualityComparer.Default);
            _serializationHooksMappings = new Dictionary<ISymbol, (string? SerializationHook, string? DeserializationHook)>(SymbolEqualityComparer.Default);

            foreach (ISymbol member in GetMembers(existingType))
            {
                foreach (var attributeData in member.GetAttributes())
                {
                    var attributeTypeSymbol = attributeData.AttributeClass;
                    // handle CodeGenMember attribute
                    if (SymbolEqualityComparer.Default.Equals(attributeTypeSymbol, memberAttribute) && TryGetCodeGenMemberAttributeValue(member, attributeData, out var schemaMemberName))
                    {
                        _propertyMappings.Add(schemaMemberName, member);
                    }
                    if (SymbolEqualityComparer.Default.Equals(attributeTypeSymbol, serializationAttribute) && TryGetSerializationAttributeValue(member, attributeData, out var serializationPath))
                    {
                        _serializationMappings.Add(member, serializationPath);
                    }
                    if (SymbolEqualityComparer.Default.Equals(attributeTypeSymbol, serializationHooksAttribute) && TryGetSerializationHooks(member, attributeData, out var hooks))
                    {
                        _serializationHooksMappings.Add(member, hooks);
                    }
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

        private static bool TryGetSerializationHooks(ISymbol symbol, AttributeData attributeData, out (string? SerializationHook, string? DeserializationHook) hooks)
        {
            string? serializationHook = null;
            string? deserializationHook = null;

            foreach (var namedArgument in attributeData.NamedArguments)
            {
                switch (namedArgument.Key)
                {
                    case nameof(CodeGenMemberSerializationHooksAttribute.SerializationHookMethodName):
                        serializationHook = namedArgument.Value.Value as string;
                        break;
                    case nameof(CodeGenMemberSerializationHooksAttribute.DeserializationHookMethodName):
                        deserializationHook = namedArgument.Value.Value as string;
                        break;
                }
            }

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
