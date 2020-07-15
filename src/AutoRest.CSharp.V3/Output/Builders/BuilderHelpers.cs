﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Linq;
using System.Security;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using SerializationFormat = AutoRest.CSharp.V3.Output.Models.Serialization.SerializationFormat;

namespace AutoRest.CSharp.V3.Output.Builders
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
                var enumTypeValue = enumType.Values.SingleOrDefault(v => (v.Value.Value as string) == stringValue);

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
            else if (frameworkType == typeof(DateTimeOffset) && value is string dateTimeString)
                normalizedValue = DateTimeOffset.Parse(dateTimeString, styles: DateTimeStyles.AssumeUniversal);
            else
                normalizedValue = Convert.ChangeType(value, frameworkType);

            return new Constant(normalizedValue, type);
        }

        public static SerializationFormat GetSerializationFormat(Schema schema) => schema switch
        {
            ByteArraySchema byteArraySchema when byteArraySchema.Format == ByteArraySchemaFormat.Base64url => SerializationFormat.Bytes_Base64Url,
            UnixTimeSchema _ => SerializationFormat.DateTime_Unix,
            DateTimeSchema dateTimeSchema when dateTimeSchema.Format == DateTimeSchemaFormat.DateTime => SerializationFormat.DateTime_ISO8601,
            DateTimeSchema dateTimeSchema when dateTimeSchema.Format == DateTimeSchemaFormat.DateTimeRfc1123 => SerializationFormat.DateTime_RFC1123,
            DateSchema _ => SerializationFormat.Date_ISO8601,
            DurationSchema _ => SerializationFormat.Duration_ISO8601,
            TimeSchema _ => SerializationFormat.Time_ISO8601,
            _ => SerializationFormat.Default
        };

        public static string EscapeXmlDescription(string s) => SecurityElement.Escape(s) ?? s;

        public static string CSharpName(this RequestParameter parameter) => parameter.Language.Default.Name.ToVariableName();

        public static string CSharpName(this ChoiceValue choice) => choice.Language.Default.Name.ToCleanName();

        public static string CSharpName(this Property property) =>
            (property.Language.Default.Name == null || property.Language.Default.Name == "null") ? "NullProperty" : property.Language.Default.Name.ToCleanName();

        public static string CSharpName(this Operation operation) =>
            operation.Language.Default.Name.ToCleanName();

        public static string CSharpName(this Schema operation) =>
            operation.Language.Default.Name.ToCleanName();
        public static string CSharpName(this HttpResponseHeader header) =>
            header.Language!.Default.Name.ToCleanName();

        public static TypeDeclarationOptions CreateTypeAttributes(string defaultName, string defaultNamespace, string defaultAccessibility, INamedTypeSymbol? existingType = null, bool existingTypeOverrides = false)
        {
            if (existingType != null)
            {
                return new TypeDeclarationOptions(existingType.Name,
                    existingType.ContainingNamespace.ToDisplayString(),
                    SyntaxFacts.GetText(existingType.DeclaredAccessibility),
                    existingTypeOverrides
                );
            }

            return new TypeDeclarationOptions(defaultName,defaultNamespace, defaultAccessibility, false);
        }

        public static MemberDeclarationOptions CreateMemberDeclaration(string defaultName, CSharpType defaultType, string defaultAccessibility, ISymbol? existingMember, TypeFactory typeFactory)
        {
            if (existingMember != null)
            {
                var newType = existingMember switch
                {
                    IPropertySymbol propertySymbol => typeFactory.CreateType(propertySymbol.Type),
                    IFieldSymbol propertySymbol => typeFactory.CreateType(propertySymbol.Type),
                    _ => defaultType
                };

                return new MemberDeclarationOptions(
                    SyntaxFacts.GetText(existingMember.DeclaredAccessibility),
                    existingMember.Name,
                    PromoteNullabilityInformation(newType, defaultType)
                );
            }
            return new MemberDeclarationOptions(
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

            if (newType.Arguments.Length != defaultType.Arguments.Length)
            {
                return newType.WithNullable(defaultType.IsNullable);
            }

            if ((TypeFactory.IsList(newType) && TypeFactory.IsList(defaultType)) ||
                (TypeFactory.IsDictionary(newType) && TypeFactory.IsDictionary(defaultType)))
            {
                var arguments = new CSharpType[newType.Arguments.Length];
                for (var i = 0; i < newType.Arguments.Length; i++)
                {
                    arguments[i] = PromoteNullabilityInformation(newType.Arguments[i], defaultType.Arguments[i]);
                }

                return new CSharpType(newType.FrameworkType, defaultType.IsNullable, arguments);
            }

            return newType.WithNullable(defaultType.IsNullable);
        }

        public static string CreateDescription(Schema schema)
        {
            return string.IsNullOrWhiteSpace(schema.Language.Default.Description) ?
                $"The {schema.Name}." :
                EscapeXmlDescription(schema.Language.Default.Description);
        }

        public static string DisambiguateName(CSharpType type, string name)
        {
            if (name == type.Name ||
                name == nameof(GetHashCode) ||
                name == nameof(Equals) ||
                name == nameof(ToString))
            {
                return name + "Value";
            }

            return name;
        }
    }
}
