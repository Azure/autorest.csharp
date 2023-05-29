// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Input.Source
{
    public class CodeGenAttributes
    {
        public CodeGenAttributes(Compilation compilation)
        {
            CodeGenSuppressAttribute = GetSymbol(compilation, typeof(CodeGenSuppressAttribute));
            CodeGenMemberAttribute = GetSymbol(compilation, typeof(CodeGenMemberAttribute));
            CodeGenTypeAttribute = GetSymbol(compilation, typeof(CodeGenTypeAttribute));
            CodeGenModelAttribute = GetSymbol(compilation, typeof(CodeGenModelAttribute));
            CodeGenClientAttribute = GetSymbol(compilation, typeof(CodeGenClientAttribute));
            CodeGenMemberSerializationAttribute = GetSymbol(compilation, typeof(CodeGenMemberSerializationAttribute));
            CodeGenMemberSerializationHooksAttribute = GetSymbol(compilation, typeof(CodeGenMemberSerializationHooksAttribute));
        }

        public INamedTypeSymbol CodeGenSuppressAttribute { get; }

        public INamedTypeSymbol CodeGenMemberAttribute { get; }

        public INamedTypeSymbol CodeGenTypeAttribute { get; }

        public INamedTypeSymbol CodeGenModelAttribute { get; }

        public INamedTypeSymbol CodeGenClientAttribute { get; }

        public INamedTypeSymbol CodeGenMemberSerializationAttribute { get; }

        public INamedTypeSymbol CodeGenMemberSerializationHooksAttribute { get; }

        private static INamedTypeSymbol GetSymbol(Compilation compilation, Type type) => compilation.GetTypeByMetadataName(type.FullName!) ?? throw new InvalidOperationException($"cannot load symbol of attribute {type}");

        private static bool CheckAttribute(AttributeData attributeData, INamedTypeSymbol codeGenAttribute)
            => SymbolEqualityComparer.Default.Equals(attributeData.AttributeClass, codeGenAttribute);

        public bool TryGetCodeGenMemberAttributeValue(AttributeData attributeData, [MaybeNullWhen(false)] out string name)
        {
            name = null;
            if (!CheckAttribute(attributeData, CodeGenMemberAttribute))
                return false;

            name = attributeData.ConstructorArguments.FirstOrDefault().Value as string;
            return name != null;
        }

        public bool TryGetSerializationAttributeValue(AttributeData attributeData, [MaybeNullWhen(false)] out string[] propertyNames)
        {
            propertyNames = null;
            if (!CheckAttribute(attributeData, CodeGenMemberSerializationAttribute))
                return false;

            if (attributeData.ConstructorArguments.Length > 0)
            {
                propertyNames = ToStringArray(attributeData.ConstructorArguments[0].Values);
            }

            return propertyNames != null;
        }

        public bool TryGetSerializationHooksAttributeValue(AttributeData attributeData, out (string? SerializationHook, string? SerializationValueHook, string? DeserializationValueHook) hooks)
        {
            hooks = default;
            if (!CheckAttribute(attributeData, CodeGenMemberSerializationHooksAttribute))
                return false;

            string? serializationHook = null;
            string? serializationValueHook = null;
            string? deserializationValueHook = null;

            foreach (var namedArgument in attributeData.NamedArguments)
            {
                switch (namedArgument.Key)
                {
                    case nameof(Azure.Core.CodeGenMemberSerializationHooksAttribute.SerializationHook):
                        serializationHook = namedArgument.Value.Value as string;
                        break;
                    case nameof(Azure.Core.CodeGenMemberSerializationHooksAttribute.SerializationValueHook):
                        serializationValueHook = namedArgument.Value.Value as string;
                        break;
                    case nameof(Azure.Core.CodeGenMemberSerializationHooksAttribute.DeserializationValueHook):
                        deserializationValueHook = namedArgument.Value.Value as string;
                        break;
                }
            }

            hooks = (serializationHook, serializationValueHook, deserializationValueHook);
            return serializationHook != null || serializationValueHook != null || deserializationValueHook != null;
        }

        public bool TryGetCodeGenModelAttributeValue(AttributeData attributeData, out string[]? usage, out string[]? formats)
        {
            usage = null;
            formats = null;
            if (!CheckAttribute(attributeData, CodeGenModelAttribute))
                return false;
            foreach (var namedArgument in attributeData.NamedArguments)
            {
                switch (namedArgument.Key)
                {
                    case nameof(Azure.Core.CodeGenModelAttribute.Usage):
                        usage = ToStringArray(namedArgument.Value.Values);
                        break;
                    case nameof(Azure.Core.CodeGenModelAttribute.Formats):
                        formats = ToStringArray(namedArgument.Value.Values);
                        break;
                }
            }

            return true;
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
    }
}
