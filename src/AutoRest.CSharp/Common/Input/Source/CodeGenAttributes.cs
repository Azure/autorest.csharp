﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public class CodeGenAttributes
    {
        public const string CodeGenSuppressAttributeName = "CodeGenSuppressAttribute";

        public const string CodeGenMemberAttributeName = "CodeGenMemberAttribute";

        public const string CodeGenTypeAttributeName = "CodeGenTypeAttribute";

        public const string CodeGenModelAttributeName = "CodeGenModelAttribute";

        public const string CodeGenClientAttributeName = "CodeGenClientAttribute";

        public const string CodeGenSerializationAttributeName = "CodeGenSerializationAttribute";

        public bool TryGetCodeGenMemberAttributeValue(AttributeData attributeData, [MaybeNullWhen(false)] out string name)
        {
            name = null;
            if (attributeData.AttributeClass?.Name != CodeGenMemberAttributeName)
                return false;

            name = attributeData.ConstructorArguments.FirstOrDefault().Value as string;
            return name != null;
        }

        public bool TryGetCodeGenSerializationAttributeValue(AttributeData attributeData, [MaybeNullWhen(false)] out string propertyName, out IReadOnlyList<string>? serializationNames, out string? serializationHook, out string? deserializationHook, out string? bicepSerializationHook)
        {
            propertyName = null;
            serializationNames = null;
            serializationHook = null;
            deserializationHook = null;
            bicepSerializationHook = null;
            if (attributeData.AttributeClass?.Name != CodeGenSerializationAttributeName)
            {
                return false;
            }

            var ctorArgs = attributeData.ConstructorArguments;
            // this attribute could only at most have one constructor
            propertyName = ctorArgs[0].Value as string;

            if (ctorArgs.Length > 1)
            {
                var namesArg = ctorArgs[1];
                serializationNames = namesArg.Kind switch
                {
                    TypedConstantKind.Array => ToStringArray(namesArg.Values),
                    _ when namesArg.IsNull => null,
                    _ => new string[] { namesArg.Value?.ToString()! }
                };
            }

            foreach (var (key, namedArgument) in attributeData.NamedArguments)
            {
                switch (key)
                {
                    case nameof(CodeGenSerializationAttribute.SerializationPath):
                        serializationNames = ToStringArray(namedArgument.Values);
                        break;
                    case nameof(CodeGenSerializationAttribute.SerializationValueHook):
                        serializationHook = namedArgument.Value as string;
                        break;
                    case nameof(CodeGenSerializationAttribute.DeserializationValueHook):
                        deserializationHook = namedArgument.Value as string;
                        break;
                    case nameof(CodeGenSerializationAttribute.BicepSerializationValueHook):
                        bicepSerializationHook = namedArgument.Value as string;
                        break;
                }
            }

            return propertyName != null && (serializationNames != null || serializationHook != null || deserializationHook != null || bicepSerializationHook != null);
        }

        public bool TryGetCodeGenModelAttributeValue(AttributeData attributeData, out string[]? usage, out string[]? formats)
        {
            usage = null;
            formats = null;
            if (attributeData.AttributeClass?.Name != CodeGenModelAttributeName)
                return false;
            foreach (var namedArgument in attributeData.NamedArguments)
            {
                switch (namedArgument.Key)
                {
                    case nameof(CodeGenModelAttribute.Usage):
                        usage = ToStringArray(namedArgument.Value.Values);
                        break;
                    case nameof(CodeGenModelAttribute.Formats):
                        formats = ToStringArray(namedArgument.Value.Values);
                        break;
                }
            }

            return usage != null || formats != null;
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
