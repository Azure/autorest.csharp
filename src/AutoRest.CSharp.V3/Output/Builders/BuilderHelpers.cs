// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
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

        public static Constant ParseConstant(ConstantSchema constant, TypeFactory typeFactory) =>
            ParseConstant(constant.Value.Value, typeFactory.CreateType(constant.ValueType, constant.Value.Value == null));

        public static Constant ParseConstant(object? value, CSharpType type)
        {
            object? normalizedValue;

            Type? frameworkType = type.FrameworkType;
            if (frameworkType == null)
            {
                throw new InvalidOperationException("Only constants of framework type are allowed");
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
            _ => SerializationFormat.Default
        };

        public static string EscapeXmlDescription(string s) => SecurityElement.Escape(s) ?? s;

        public static bool IsNullable(this RequestParameter parameter) => !(parameter.Required ?? false);
        public static bool IsNullable(this Property parameter) => !(parameter.Required ?? false);

        public static string CSharpName(this RequestParameter parameter) => parameter.Schema is ConstantSchema ?
            parameter.Language.Default.Name.ToCleanName() :
            parameter.Language.Default.Name.ToVariableName();

        public static string CSharpName(this ChoiceValue choice) => choice.Language.Default.Name.ToCleanName();

        public static string CSharpName(this Property property) =>
            (property.Language.Default.Name == null || property.Language.Default.Name == "null") ? "NullProperty" : property.Language.Default.Name.ToCleanName();

        public static string CSharpName(this Operation operation) =>
            operation.Language.Default.Name.ToCleanName();

        public static string CSharpName(this Schema operation) =>
            operation.Language.Default.Name.ToCleanName();

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

        public static MemberDeclarationOptions CreateMemberDeclaration(string defaultName, CSharpType defaultType, string defaultAccessibility, ISymbol? existingMember)
        {
            if (existingMember != null)
            {
                // Not reading the return type information of existing members yet
                return new MemberDeclarationOptions(
                    SyntaxFacts.GetText(existingMember.DeclaredAccessibility),
                    existingMember.Name,
                    defaultType,
                    isUserDefined: true
                );
            }
            // Not reading the return type information of existing members yet
            return new MemberDeclarationOptions(
                defaultAccessibility,
                defaultName,
                defaultType,
                isUserDefined: false
                );
        }

        public static string CreateDescription(Schema schema)
        {
            return string.IsNullOrWhiteSpace(schema.Language.Default.Description) ?
                $"The {schema.Name}." :
                EscapeXmlDescription(schema.Language.Default.Description);
        }
    }
}
