// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using SerializationFormat = AutoRest.CSharp.Output.Models.Serialization.SerializationFormat;

namespace AutoRest.CSharp.Output.Builders
{
    internal static class BuilderHelpers
    {
        public static Constant StringConstant(string? s) => ParseConstant(s, new CSharpType(typeof(string), s == null));

        public static Constant ParseConstant(object? value, CSharpType type)
        {
            object? normalizedValue;

            if (!type.IsFrameworkType && type.Implementation is EnumType enumType)
            {
                if (value == null)
                {
                    return Constant.Default(type);
                }

                var stringValue = Convert.ToString(value);
                var enumTypeValue = enumType.Values.SingleOrDefault(v => v.Value.Value?.ToString() == stringValue);

                // Fallback to the string value if we can't find an appropriate enum member (would work only for extensible enums)
                return new Constant((object?)enumTypeValue ?? stringValue, type);
            }

            Type? frameworkType = type.FrameworkType;
            if (frameworkType == null)
            {
                throw new InvalidOperationException("Only constants of framework type and enums are allowed");
            }

            if (frameworkType == typeof(byte[]) && value is string base64String)
                normalizedValue = Convert.FromBase64String(base64String);
            else if (frameworkType == typeof(BinaryData) && value is string base64String2)
                normalizedValue = BinaryData.FromBytes(Convert.FromBase64String(base64String2));
            else if (frameworkType == typeof(DateTimeOffset) && value is string dateTimeString)
                normalizedValue = DateTimeOffset.Parse(dateTimeString, styles: DateTimeStyles.AssumeUniversal);
            else if (frameworkType == typeof(ResourceType) && value is string resourceTypeString)
                normalizedValue = new ResourceType(resourceTypeString);
            else
                normalizedValue = Convert.ChangeType(value, frameworkType);

            return new Constant(normalizedValue, type);
        }

        public static SerializationFormat GetSerializationFormat(Schema schema) => schema switch
        {
            ConstantSchema constantSchema => GetSerializationFormat(constantSchema.ValueType), // forward the constantSchema to its underlying type

            ByteArraySchema byteArraySchema => byteArraySchema.Format switch
            {
                ByteArraySchemaFormat.Base64url => SerializationFormat.Bytes_Base64Url,
                ByteArraySchemaFormat.Byte => SerializationFormat.Bytes_Base64,
                _ => SerializationFormat.Default
            },

            UnixTimeSchema => SerializationFormat.DateTime_Unix,
            DateTimeSchema dateTimeSchema => dateTimeSchema.Format switch
            {
                DateTimeSchemaFormat.DateTime => SerializationFormat.DateTime_ISO8601,
                DateTimeSchemaFormat.DateTimeRfc1123 => SerializationFormat.DateTime_RFC1123,
                _ => SerializationFormat.Default
            },

            DateSchema _ => SerializationFormat.Date_ISO8601,
            TimeSchema _ => SerializationFormat.Time_ISO8601,

            DurationSchema _ => schema.Extensions?.Format switch
            {
                XMsFormat.DurationConstant => SerializationFormat.Duration_Constant,
                _ => SerializationFormat.Duration_ISO8601
            },

            _ when schema.Type == AllSchemaTypes.Duration => SerializationFormat.Duration_ISO8601,
            _ when schema.Type == AllSchemaTypes.DateTime => SerializationFormat.DateTime_ISO8601,
            _ when schema.Type == AllSchemaTypes.Date => SerializationFormat.DateTime_ISO8601,
            _ when schema.Type == AllSchemaTypes.Time => SerializationFormat.DateTime_ISO8601,

            _ => schema.Extensions?.Format switch
            {
                XMsFormat.DateTime => SerializationFormat.DateTime_ISO8601,
                XMsFormat.DateTimeRFC1123 => SerializationFormat.DateTime_RFC1123,
                XMsFormat.DateTimeUnix => SerializationFormat.DateTime_Unix,
                XMsFormat.DurationConstant => SerializationFormat.Duration_Constant,
                _ => SerializationFormat.Default
            }
        };

        private const string EscapedAmpersand = "&amp;";
        private const string EscapedLessThan = "&lt;";
        private const string EscapedGreaterThan = "&gt;";
        private const string EscapedAppostrophe = "&apos;";
        private const string EscapedQuote = "&quot;";
        public static string EscapeXmlDocDescription(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            var span = s.AsSpan();
            Dictionary<int, string> replacements = new Dictionary<int, string>();
            for (int i = 0; i < span.Length; i++)
            {
                switch (span[i])
                {
                    case '&':
                        if (IsAlreadyEscaped(ref span, i, out int escapeLength))
                        {
                            i += escapeLength;
                        }
                        else
                        {
                            replacements.Add(i, EscapedAmpersand);
                        }
                        break;
                    case '<':
                        replacements.Add(i, EscapedLessThan);
                        break;
                    case '>':
                        replacements.Add(i, EscapedGreaterThan);
                        break;
                }
            }
            if (replacements.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                int lastStart = 0;
                foreach (var kv in replacements)
                {
                    sb.Append(span.Slice(lastStart, kv.Key - lastStart));
                    sb.Append(kv.Value);
                    lastStart = kv.Key + 1;
                }
                sb.Append(span.Slice(lastStart));
                return sb.ToString();
            }
            return s;
        }

        private static bool IsAlreadyEscaped(ref ReadOnlySpan<char> span, int i, out int escapeLength)
        {
            return IsEscapedMatch(ref span, i, EscapedAmpersand, out escapeLength) ||
                IsEscapedMatch(ref span, i, EscapedLessThan, out escapeLength) ||
                IsEscapedMatch(ref span, i, EscapedGreaterThan, out escapeLength) ||
                IsEscapedMatch(ref span, i, EscapedAppostrophe, out escapeLength) ||
                IsEscapedMatch(ref span, i, EscapedQuote, out escapeLength);
        }

        private static bool IsEscapedMatch(ref ReadOnlySpan<char> span, int i, string escapedChar, out int escapeLength)
        {
            escapeLength = 0;
            if (span.Length < i + escapedChar.Length)
                return false;

            var slice = span.Slice(i, escapedChar.Length);
            var isMatch = slice.Equals(escapedChar.AsSpan(), StringComparison.Ordinal);
            if (isMatch)
                escapeLength = slice.Length;
            return isMatch;
        }

        // TODO: Clean up these helper methods in https://github.com/Azure/autorest.csharp/issues/4767
        public static string CSharpName(this InputParameter parameter) => parameter.Name.ToVariableName();

        public static string CSharpName(this RequestParameter parameter) => parameter.Language.Default.Name.ToVariableName();

        public static string CSharpName(this ChoiceValue choice) => choice.Language.Default.Name.ToCleanName();

        public static string CSharpName(this Property property) =>
            (property.Language.Default.Name == null || property.Language.Default.Name == "null") ? "NullProperty" : property.Language.Default.Name.ToCleanName();

        public static string CSharpName(this InputModelProperty property) =>
            (property.Name == null || property.Name == "null") ? "NullProperty" : property.Name.ToCleanName();

        public static string CSharpName(this InputOperation operation) =>
            operation.Name.ToCleanName();

        public static string CSharpName(this InputType inputType) =>
            inputType.Name.ToCleanName();

        public static string CSharpName(this Schema operation) =>
            operation.Language.Default.Name.ToCleanName();
        public static string CSharpName(this HttpResponseHeader header) =>
            header.Language!.Default.Name.ToCleanName();

        public static TypeDeclarationOptions CreateTypeAttributes(string defaultName, string defaultNamespace, string defaultAccessibility, INamedTypeSymbol? existingType = null, bool existingTypeOverrides = false, bool isAbstract = false)
        {
            if (existingType != null)
            {
                return new TypeDeclarationOptions(existingType.Name,
                    existingType.ContainingNamespace.ToDisplayString(),
                    SyntaxFacts.GetText(existingType.DeclaredAccessibility),
                    existingType.IsAbstract || isAbstract,
                    existingTypeOverrides
                );
            }

            return new TypeDeclarationOptions(defaultName, defaultNamespace, defaultAccessibility, isAbstract, false);
        }

        public static CSharpType GetTypeFromExisting(ISymbol existingMember, CSharpType defaultType, TypeFactory typeFactory)
        {
            var newType = existingMember switch
            {
                IFieldSymbol { Type: INamedTypeSymbol { EnumUnderlyingType: { } } } => defaultType, // Special case for enums
                IFieldSymbol fieldSymbol => typeFactory.CreateType(fieldSymbol.Type),
                IPropertySymbol propertySymbol => typeFactory.CreateType(propertySymbol.Type),
                _ => defaultType
            };

            return PromoteNullabilityInformation(newType, defaultType);
        }

        private static bool IsExistingSettable(ISymbol existingMember) => existingMember switch
        {
            IPropertySymbol propertySymbol => propertySymbol.SetMethod != null,
            IFieldSymbol fieldSymbol => !fieldSymbol.IsReadOnly,
            _ => throw new NotSupportedException($"'{existingMember.ContainingType.Name}.{existingMember.Name}' must be either field or property.")
        };

        public static bool IsReadOnly(ISymbol existingMember, CSharpType type)
        {
            var hasSetter = IsExistingSettable(existingMember);
            if (hasSetter)
            {
                return false;
            }

            if (type.IsCollection)
            {
                return type.IsReadOnlyDictionary || type.IsReadOnlyList;
            }

            return !hasSetter;
        }

        public static MemberDeclarationOptions CreateMemberDeclaration(string defaultName, CSharpType defaultType, string defaultAccessibility, ISymbol? existingMember, TypeFactory typeFactory)
        {
            return existingMember != null ?
                new MemberDeclarationOptions(
                    SyntaxFacts.GetText(existingMember.DeclaredAccessibility),
                    existingMember.Name,
                    GetTypeFromExisting(existingMember, defaultType, typeFactory)
                ) :
                new MemberDeclarationOptions(
                    defaultAccessibility,
                    defaultName,
                    defaultType
                );
        }


        // Because most of our libraries don't use C# nullable reference types we are losing nullability information
        // for reference types when members are remapped
        // Try to copy it back where possible from the original type
        private static CSharpType PromoteNullabilityInformation(CSharpType newType, CSharpType defaultType)
        {
            if (newType.IsValueType)
            {
                return newType;
            }

            if (newType.Arguments.Count != defaultType.Arguments.Count)
            {
                return newType.WithNullable(defaultType.IsNullable);
            }

            if ((newType.IsList && defaultType.IsList) ||
                (newType.IsDictionary && defaultType.IsDictionary))
            {
                var arguments = new CSharpType[newType.Arguments.Count];
                for (var i = 0; i < newType.Arguments.Count; i++)
                {
                    arguments[i] = PromoteNullabilityInformation(newType.Arguments[i], defaultType.Arguments[i]);
                }

                return new CSharpType(newType.FrameworkType, defaultType.IsNullable, arguments);
            }

            return newType.WithNullable(defaultType.IsNullable);
        }

        public static FormattableString CreateDerivedTypesDescription(CSharpType type)
        {
            if (type.IsCollection)
            {
                type = type.ElementType;
            }

            if (type is { IsFrameworkType: false, Implementation: ObjectType objectType })
            {
                return objectType.CreateExtraDescriptionWithDiscriminator();
            }

            return $"";
        }

        public static string CreateDescription(this Schema schema)
            => EscapeXmlDocDescription(schema.Language.Default.Description);

        public static string DisambiguateName(string typeName, string name, string suffix)
        {
            if (name == typeName || name is nameof(GetHashCode) or nameof(Equals) or nameof(ToString))
            {
                return name + suffix;
            }

            return name;
        }

        public static string DisambiguateName(CSharpType type, string name, string suffix = "Value")
        {
            if (name == type.Name ||
                name == nameof(GetHashCode) ||
                name == nameof(Equals) ||
                name == nameof(ToString))
            {
                return name + suffix;
            }

            return name;
        }

        public static MethodSignatureModifiers MapModifiers(ISymbol symbol)
        {
            var modifiers = MethodSignatureModifiers.None;
            switch (symbol.DeclaredAccessibility)
            {
                case Accessibility.Public:
                    modifiers |= MethodSignatureModifiers.Public;
                    break;
                case Accessibility.Internal:
                    modifiers |= MethodSignatureModifiers.Internal;
                    break;
                case Accessibility.Private:
                    modifiers |= MethodSignatureModifiers.Private;
                    break;
                case Accessibility.Protected:
                    modifiers |= MethodSignatureModifiers.Protected;
                    break;
                case Accessibility.ProtectedAndInternal:
                    modifiers |= MethodSignatureModifiers.Protected | MethodSignatureModifiers.Internal;
                    break;
            }
            if (symbol.IsStatic)
            {
                modifiers |= MethodSignatureModifiers.Static;
            }
            if (symbol is IMethodSymbol methodSymbol && methodSymbol.IsAsync)
            {
                modifiers |= MethodSignatureModifiers.Async;
            }
            if (symbol.IsVirtual)
            {
                modifiers |= MethodSignatureModifiers.Virtual;
            }
            if (symbol.IsOverride)
            {
                modifiers |= MethodSignatureModifiers.Override;
            }
            return modifiers;
        }

        public static CSharpType CreateAdditionalPropertiesPropertyType(CSharpType originalType, CSharpType unknownType)
        {
            // TODO -- we only construct additional properties when the type is verifiable, because we always need the property to fall into the bucket of serialized additional raw data field when it does not fit the additional properties.
            var arguments = originalType.Arguments;
            var keyType = arguments[0];
            var valueType = arguments[1];

            return originalType.MakeGenericType(new[] { ReplaceUnverifiableType(keyType, unknownType), ReplaceUnverifiableType(valueType, unknownType) });
        }

        private static CSharpType ReplaceUnverifiableType(CSharpType type, CSharpType unknownType)
        {
            // when the type is System.Object Or BinaryData
            if (type.EqualsIgnoreNullable(unknownType))
            {
                return type;
            }

            // when the type is a verifiable type
            if (IsVerifiableType(type))
            {
                return type;
            }

            // when the type is a union
            if (type.IsUnion)
            {
                return type;
            }

            // otherwise the type is not a verifiable type
            // replace for list
            if (type.IsList)
            {
                return type.MakeGenericType(new[] { ReplaceUnverifiableType(type.Arguments[0], unknownType) });
            }
            // replace for dictionary
            if (type.IsDictionary)
            {
                return type.MakeGenericType(new[] { ReplaceUnverifiableType(type.Arguments[0], unknownType), ReplaceUnverifiableType(type.Arguments[1], unknownType) });
            }
            // for the other cases, wrap them in a union
            return CSharpType.FromUnion(new[] { type });
        }

        private static readonly HashSet<Type> _verifiableTypes = new HashSet<Type>
        {
            // The following types are constructed by the `TryGetXXX` methods on `JsonElement`.
            typeof(byte), typeof(byte[]), typeof(sbyte),
            typeof(DateTime), typeof(DateTimeOffset),
            typeof(decimal), typeof(double), typeof(short), typeof(int), typeof(long), typeof(float),
            typeof(ushort), typeof(uint), typeof(ulong),
            typeof(Guid),
            // The following types have a firm JsonValueKind to verify
            typeof(string), typeof(bool)
        };

        public static bool IsVerifiableType(Type type) => _verifiableTypes.Contains(type);

        public static bool IsVerifiableType(CSharpType type) => type is { IsFrameworkType: true, FrameworkType: { } frameworkType } && IsVerifiableType(frameworkType);
    }
}
