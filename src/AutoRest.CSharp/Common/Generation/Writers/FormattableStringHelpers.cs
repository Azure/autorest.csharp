// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class FormattableStringHelpers
    {
        public static bool IsEmpty(this FormattableString fs) =>
            string.IsNullOrEmpty(fs.Format) && fs.ArgumentCount == 0;

        public static FormattableString Join(this ICollection<FormattableString> fss, string separator, string? lastSeparator = null)
            => fss.Count switch
            {
                0 => $"",
                1 => fss.First(),
                _ when lastSeparator is not null => FormattableStringFactory.Create(string.Join(separator, Enumerable.Range(0, fss.Count).Select(i => $"{{{i}}}")).ReplaceLast(separator, lastSeparator), fss.ToArray<object>()),
                _ => FormattableStringFactory.Create(string.Join(separator, Enumerable.Range(0, fss.Count).Select(i => $"{{{i}}}")), fss.ToArray<object>())
            };

        public static FormattableString GetLiteralsFormattable(this IReadOnlyCollection<Parameter> parameters)
            => GetLiteralsFormattable(parameters.Select(p => p.Name), parameters.Count);

        public static FormattableString GetLiteralsFormattable(this IReadOnlyCollection<Reference> references)
            => GetLiteralsFormattable(references.Select(p => p.Name), references.Count);

        public static FormattableString GetLiteralsFormattable(this IReadOnlyCollection<string> literals)
            => GetLiteralsFormattable(literals, literals.Count);

        public static FormattableString GetLiteralsFormattable(this ICollection<string> literals)
            => GetLiteralsFormattable(literals, literals.Count);

        public static FormattableString GetLiteralsFormattable(this IEnumerable<string> literals, int count)
            => count switch
            {
                0 => $"",
                1 => $"{literals.First():L}",
                _ => FormattableStringFactory.Create(GetNamesForMethodCallFormat(count, 'L'), literals.ToArray<object>())
            };

        public static FormattableString GetIdentifiersFormattable(this IReadOnlyCollection<Parameter> parameters)
            => GetIdentifiersFormattable(parameters.Select(p => p.Name), parameters.Count);

        public static FormattableString GetIdentifiersFormattable(this IReadOnlyCollection<Reference> references)
            => GetIdentifiersFormattable(references.Select(p => p.Name), references.Count);

        public static FormattableString GetIdentifiersFormattable(this IReadOnlyCollection<string> identifiers)
            => GetIdentifiersFormattable(identifiers, identifiers.Count);

        public static FormattableString GetIdentifiersFormattable(this IEnumerable<string> identifiers, int count)
            => count switch
            {
                0 => $"",
                1 => $"{identifiers.First():I}",
                _ => FormattableStringFactory.Create(GetNamesForMethodCallFormat(count, 'I'), identifiers.ToArray<object>())
            };

        public static FormattableString? GetParameterInitializer(this CSharpType parameterType, Constant? defaultValue)
        {
            if (TypeFactory.IsCollectionType(parameterType) && (defaultValue == null || TypeFactory.IsCollectionType(defaultValue.Value.Type)))
            {
                defaultValue = Constant.NewInstanceOf(TypeFactory.GetImplementationType(parameterType).WithNullable(false));
            }

            if (defaultValue == null)
            {
                return null;
            }

            var constantFormattable = GetConstantFormattable(defaultValue.Value);
            var conversion = GetConversionMethod(defaultValue.Value.Type, parameterType);
            return conversion == null ? constantFormattable : $"{constantFormattable}{conversion}";
        }

        public static FormattableString GetConversionFormattable(this Parameter parameter, CSharpType toType)
        {
            if (TypeFactory.IsReadWriteDictionary(parameter.Type) && toType.EqualsIgnoreNullable(typeof(RequestContent)))
            {
                return $"{typeof(RequestContentHelper)}.{nameof(RequestContentHelper.FromDictionary)}({parameter.Name})";
            }

            if (TypeFactory.IsList(parameter.Type) && toType.EqualsIgnoreNullable(typeof(RequestContent)))
            {
                return $"{typeof(RequestContent)}.{nameof(RequestContent.Create)}({parameter.Name})";
            }

            if (parameter.Type is { IsFrameworkType: false, Implementation: EnumType enumType } && toType.EqualsIgnoreNullable(typeof(RequestContent)))
            {
                if (enumType.IsExtensible)
                {
                    return $"{typeof(BinaryData)}.{nameof(BinaryData.FromObjectAsJson)}({parameter.Name}.{enumType.SerializationMethodName}())";
                }
                else
                {
                    return $"{typeof(BinaryData)}.{nameof(BinaryData.FromObjectAsJson)}({(enumType.IsIntValueType ? $"({enumType.ValueType}){parameter.Name}" : $"{parameter.Name}.{enumType.SerializationMethodName}()")})";
                }
            }

            var conversionMethod = GetConversionMethod(parameter.Type, toType);
            if (conversionMethod == null)
            {
                return $"{parameter.Name:I}";
            }

            if (parameter.IsOptionalInSignature)
            {
                return $"{parameter.Name:I}?{conversionMethod}";
            }

            return $"{parameter.Name:I}{conversionMethod}";
        }

        public static string? GetConversionMethod(CSharpType fromType, CSharpType toType)
            => fromType switch
            {
                { IsFrameworkType: false, Implementation: EnumType { IsExtensible: true } } when toType.EqualsIgnoreNullable(typeof(string)) => ".ToString()",
                { IsFrameworkType: false, Implementation: EnumType { IsExtensible: false } } when toType.EqualsIgnoreNullable(typeof(string)) => ".ToSerialString()",
                { IsFrameworkType: false, Implementation: ModelTypeProvider } when toType.EqualsIgnoreNullable(typeof(RequestContent)) => ".ToRequestContent()",
                _ => null
            };

        public static FormattableString GetReferenceOrConstantFormattable(this ReferenceOrConstant value)
            => value.IsConstant ? value.Constant.GetConstantFormattable() : value.Reference.GetReferenceFormattable();

        public static FormattableString GetConstantFormattable(this Constant constant)
        {
            if (constant.Value == null)
            {
                // Cast helps the overload resolution
                return $"({constant.Type}){null:L}";
            }

            if (constant.IsNewInstanceSentinel)
            {
                return $"new {constant.Type}()";
            }

            if (constant is { Type: { IsFrameworkType: false }, Value: EnumTypeValue enumTypeValue })
            {
                return $"{constant.Type}.{enumTypeValue.Declaration.Name}";
            }

            // we cannot check `constant.Value is string` because it is always string - this is an issue in yaml serialization)
            if (constant.Type is { IsFrameworkType: false, Implementation: EnumType enumType })
            {
                if (enumType.IsStringValueType)
                    return $"new {constant.Type}({constant.Value:L})";
                else
                    return $"new {constant.Type}(({enumType.ValueType}){constant.Value})";
            }

            Type frameworkType = constant.Type.FrameworkType;
            if (frameworkType == typeof(DateTimeOffset))
            {
                var d = (DateTimeOffset)constant.Value;
                d = d.ToUniversalTime();
                return $"new {typeof(DateTimeOffset)}({d.Year:L}, {d.Month:L}, {d.Day:L} ,{d.Hour:L}, {d.Minute:L}, {d.Second:L}, {d.Millisecond:L}, {typeof(TimeSpan)}.{nameof(TimeSpan.Zero)})";
            }

            if (frameworkType == typeof(byte[]))
            {
                var bytes = (byte[])constant.Value;
                var joinedBytes = string.Join(", ", bytes);
                return $"new byte[] {{{joinedBytes}}}";
            }

            if (frameworkType == typeof(ResourceType))
            {
                return $"{((ResourceType)constant.Value).ToString():L}";
            }

            return $"{constant.Value:L}";
        }

        public static FormattableString GetReferenceFormattable(this Reference reference)
        {
            var parts = reference.Name.Split(".");
            var sb = new StringBuilder("{0:I}");
            for (int i = 1; i < parts.Length; i++)
            {
                sb.Append(".").Append($"{{{i}:I}}");
            }

            return FormattableStringFactory.Create(sb.ToString(), parts.Cast<object>().ToArray());
        }

        private static string GetNamesForMethodCallFormat(int parametersCount, char format)
        {
            var sb = new StringBuilder(5 * parametersCount + 2 * (parametersCount - 1));
            sb.Append("{0:").Append(format).Append('}');
            for (var i = 1; i < parametersCount; i++)
            {
                sb.Append(", {").Append(i).Append(':').Append(format).Append('}');
            }

            return sb.ToString();
        }
    }
}
