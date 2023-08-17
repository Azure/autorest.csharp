// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Shared
{
    internal record Parameter(string Name, string? Description, CSharpType Type, Constant? DefaultValue, Validation Validation, FormattableString? Initializer, bool IsApiVersionParameter = false, bool IsResourceIdentifier = false, bool SkipUrlEncoding = false, RequestLocation RequestLocation = RequestLocation.None, bool IsPropertyBag = false)
    {
        public CSharpAttribute[] Attributes { get; init; } = Array.Empty<CSharpAttribute>();
        public bool IsOptionalInSignature => DefaultValue != null;

        public static Parameter FromInputParameter(in InputParameter operationParameter, CSharpType type, bool keepClientDefaultValue, TypeFactory typeFactory)
        {
            var name = operationParameter.Name.ToVariableName();
            var requestLocation = operationParameter.Location;
            var isConstant = operationParameter.Kind == InputOperationParameterKind.Constant;
            var isRequired = operationParameter.IsRequired;

            if (!keepClientDefaultValue && (operationParameter.Kind == InputOperationParameterKind.Constant || operationParameter.IsApiVersion || operationParameter.IsContentType || operationParameter.IsEndpoint))
            {
                keepClientDefaultValue = true;
            }

            CreateDefaultValue(ref type, typeFactory, operationParameter.DefaultValue, isConstant, isRequired, keepClientDefaultValue, out Constant? clientDefaultValue, out Constant? defaultValue, out FormattableString? initializer);
            var description = CreateDescription(operationParameter, type, (operationParameter.Type as InputEnumType)?.AllowedValues.Select(c => c.GetValueString()), keepClientDefaultValue ? null : clientDefaultValue);

            var validation = isRequired && initializer == null
                ? GetValidation(type, requestLocation, operationParameter.SkipUrlEncoding)
                : Validation.None;

            var inputType = TypeFactory.GetInputType(type);
            return new Parameter(
                name,
                description,
                inputType,
                defaultValue,
                validation,
                initializer,
                IsApiVersionParameter: operationParameter.IsApiVersion,
                IsResourceIdentifier: operationParameter.IsResourceParameter,
                SkipUrlEncoding: operationParameter.SkipUrlEncoding,
                RequestLocation: requestLocation);
        }

        public static void CreateDefaultValue(ref CSharpType type, TypeFactory typeFactory, InputConstant? inputDefaultValue, bool isConstant, bool isRequired, bool keepClientDefaultValue, out Constant? clientDefaultValue, out Constant? defaultValue, out FormattableString? initializer)
        {
            clientDefaultValue = inputDefaultValue != null ? BuilderHelpers.ParseConstant(inputDefaultValue.Value, typeFactory.CreateType(inputDefaultValue.Type)) : null;
            defaultValue = keepClientDefaultValue ? clientDefaultValue : null;

            initializer = null;

            if (defaultValue != null && !isConstant && !TypeFactory.CanBeInitializedInline(type, defaultValue))
            {
                initializer = type.GetParameterInitializer(defaultValue.Value);
                type = type.WithNullable(true);
                defaultValue = Constant.Default(type);
            }

            if (!isRequired && defaultValue == null)
            {
                type = type.WithNullable(true);
                defaultValue = Constant.Default(type);
            }
        }

        public static string CreateDescription(InputParameter operationParameter, CSharpType type, IEnumerable<string>? values, Constant? defaultValue)
        {
            string description = string.IsNullOrWhiteSpace(operationParameter.Description)
                ? $"The {type.ToStringForDocs()} to use."
                : BuilderHelpers.EscapeXmlDocDescription(operationParameter.Description);

            if (defaultValue != null)
            {
                var defaultValueString = defaultValue?.Value is string s ? $"\"{s}\"" : $"{defaultValue?.Value}";
                description = $"{description}{(description.EndsWith(".") ? "" : ".")} The default value is {defaultValueString}";
            }

            if (!type.IsFrameworkType || values == null)
            {
                return description;
            }

            var allowedValues = string.Join(" | ", values.Select(v => $"\"{v}\""));
            return $"{description}{(description.EndsWith(".") ? "" : ".")} Allowed values: {BuilderHelpers.EscapeXmlDocDescription(allowedValues)}";
        }

        public static Validation GetValidation(CSharpType type, RequestLocation requestLocation, bool skipUrlEncoding)
        {
            if (requestLocation is RequestLocation.Uri or RequestLocation.Path or RequestLocation.Body && type.EqualsIgnoreNullable(typeof(string)) && !skipUrlEncoding)
            {
                return Validation.AssertNotNullOrEmpty;
            }

            if (!type.IsValueType)
            {
                return Validation.AssertNotNull;
            }

            return Validation.None;
        }

        public static readonly IEqualityComparer<Parameter> EqualityComparerByType = new ParameterByTypeEqualityComparer();
        private class ParameterByTypeEqualityComparer : IEqualityComparer<Parameter>
        {
            public bool Equals(Parameter? x, Parameter? y) => Equals(x?.Type, y?.Type);
            public int GetHashCode(Parameter obj) => obj.Type.GetHashCode();
        }
    }

    internal record Validation(ValidationType Type, object? Data)
    {
        public static Validation None { get; } = new(ValidationType.None, null);
        public static Validation AssertNotNull { get; } = new(ValidationType.AssertNotNull, null);
        public static Validation AssertNotNullOrEmpty { get; } = new(ValidationType.AssertNotNullOrEmpty, null);
    }

    internal enum ValidationType
    {
        None,
        AssertNull,
        AssertNotNull,
        AssertNotNullOrEmpty
    }
}
