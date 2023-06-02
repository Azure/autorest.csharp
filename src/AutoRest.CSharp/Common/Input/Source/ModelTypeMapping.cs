// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class ModelTypeMapping
    {
        private readonly INamedTypeSymbol? _existingType;
        private readonly Dictionary<string, ISymbol> _propertyMappings;
        private readonly Dictionary<string, SourcePropertySerializationMapping> _serializationMappings;

        public string[]? Usage { get; }
        public string[]? Formats { get; }

        public ModelTypeMapping(CodeGenAttributes codeGenAttributes, INamedTypeSymbol existingType)
        {
            _existingType = existingType;
            _propertyMappings = new();
            _serializationMappings = new();

            foreach (ISymbol member in GetMembers(existingType))
            {
                string[]? serializationPath = null;
                string? serializationValueHook = null, deserializationValueHook = null;
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
                        (_, serializationValueHook, deserializationValueHook) = hooks; // property name is discarded because it is never needed here
                    }
                }
                if (serializationPath != null || serializationValueHook != null || deserializationValueHook != null)
                {
                    _serializationMappings.Add(member.Name, new SourcePropertySerializationMapping(member, serializationPath, serializationValueHook, deserializationValueHook));
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
                // handle CodeGenMemberSerializationHooks attribtue
                if (codeGenAttributes.TryGetCodeGenMemberSerializationHooksAttributeValue(attributeData, out var hooks))
                {
                    if (hooks.PropertyName == null)
                    {
                        ErrorHelpers.ThrowError($"When CodeGenMemberSerializationHooks attribute is added to a class, the `PropertyName` property is required.");
                    }
                    // if we already have one defined on the properties, and if it is not defined in this type, we ignore that mapping and add this one in.
                    if (!_serializationMappings.TryGetValue(hooks.PropertyName, out var existingMapping) || !SymbolEqualityComparer.Default.Equals(existingMapping.ExistingMember?.ContainingType, existingType))
                    {
                        _serializationMappings[hooks.PropertyName] = new SourcePropertySerializationMapping(hooks.PropertyName, null, hooks.SerializationHook, hooks.DeserializationHook);
                    }
                }
            }
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

        public SourcePropertySerializationMapping? GetForMemberSerialization(string name)
        {
            if (_serializationMappings.TryGetValue(name, out var serialization))
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
