// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.Input.Source
{
    public class ModelTypeMapping
    {
        private static readonly SymbolDisplayFormat _fullyQualifiedNameFormat
            = new SymbolDisplayFormat(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces);

        private readonly INamedTypeSymbol _existingType;
        private readonly Dictionary<string, ISymbol> _propertyMappings;
        private readonly Dictionary<string, List<IMethodSymbol>> _methodMappings;
        private readonly Dictionary<ISymbol, SourcePropertySerializationMapping> _serializationMappings;

        public string[]? Usage { get; }
        public string[]? Formats { get; }

        public ModelTypeMapping(CodeGenAttributes codeGenAttributes, INamedTypeSymbol existingType)
        {
            _existingType = existingType;
            _propertyMappings = new();
            _methodMappings = new();
            _serializationMappings = new(SymbolEqualityComparer.Default);

            foreach (ISymbol member in GetMembers(existingType))
            {
                if (member is IMethodSymbol method)
                {
                    var methodName = method.MethodKind switch
                    {
                        MethodKind.Constructor => method.ContainingType.Name, // the name of a ctor is always `.ctor` instead of the name of the containing type. Here we made the replacement here since we always use the name of the type as the name of constructor
                        _ => method.Name,
                    };
                    _methodMappings.AddInList(methodName, method);
                }

                string[]? serializationPath = null;
                (string? SerializationValueHook, string? DeserializationValueHook)? serializationHooks = null;
                foreach (var attributeData in member.GetAttributes())
                {
                    // handle CodeGenMember attribute
                    if (codeGenAttributes.TryGetCodeGenMemberAttributeValue(attributeData, out var schemaMemberName))
                    {
                        _propertyMappings.Add(schemaMemberName, member);
                    }
                    // handle CodeGenMemberSerialization attribute
                    if (codeGenAttributes.TryGetCodeGenMemberSerializationAttributeValue(attributeData, out var pathResult))
                    {
                        serializationPath = pathResult;
                    }
                    // handle CodeGenMemberSerializationHooks attribute
                    if (codeGenAttributes.TryGetCodeGenMemberSerializationHooksAttributeValue(attributeData, out var hooks))
                    {
                        serializationHooks = hooks;
                    }
                }
                if (serializationPath != null || serializationHooks != null)
                {
                    _serializationMappings.Add(member, new SourcePropertySerializationMapping(member, serializationPath, serializationHooks?.SerializationValueHook, serializationHooks?.DeserializationValueHook));
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

        internal SourcePropertyMapping? GetForMember(string name)
        {
            if (!_propertyMappings.TryGetValue(name, out var memberSymbol))
            {
                memberSymbol = _existingType.GetMembers(name).FirstOrDefault();
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
                var parameterTypeSymbols = method.Parameters.Select(p => (INamedTypeSymbol)p.Type).ToArray();
                if (IsSameTypeList(parameterTypeSymbols, parameterTypes))
                {
                    return new SourceMethodMapping(name, parameterTypes, method);
                }
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

        internal SourcePropertySerializationMapping? GetForMemberSerialization(ISymbol? symbol)
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
