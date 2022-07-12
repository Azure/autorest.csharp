// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Shared
{
    internal record Parameter(string Name, string? Description, CSharpType Type, Constant? DefaultValue, ValidationType Validation, FormattableString? Initializer, bool IsApiVersionParameter = false, bool IsResourceIdentifier = false, bool SkipUrlEncoding = false, RequestLocation RequestLocation = RequestLocation.None)
    {
        public CSharpAttribute[] Attributes { get; init; } = Array.Empty<CSharpAttribute>();
        public bool IsOptionalInSignature => DefaultValue != null;

        public static Parameter FromRequestParameter(in OperationParameter operationParameter, CSharpType type, TypeFactory typeFactory)
        {
            var name = operationParameter.Name.ToVariableName();
            var skipUrlEncoding = operationParameter.SkipUrlEncoding;
            var requestLocation = operationParameter.Location;

            var defaultValue = operationParameter.DefaultValue != null
                ? BuilderHelpers.ParseConstant(operationParameter.DefaultValue.Value, typeFactory.CreateType(operationParameter.DefaultValue.Type))
                : (Constant?)null;

            var initializer = (FormattableString?)null;

            if (defaultValue != null && !operationParameter.IsConstant &&  !TypeFactory.CanBeInitializedInline(type, defaultValue))
            {
                initializer = GetParameterInitializer(type, defaultValue.Value);
                type = type.WithNullable(true);
                defaultValue = Constant.Default(type);
            }

            if (!operationParameter.IsRequired && defaultValue == null)
            {
                defaultValue = Constant.Default(type);
            }

            var validation = operationParameter.IsRequired && initializer == null
                ? GetValidation(type, requestLocation, skipUrlEncoding)
                : ValidationType.None;

            var inputType = TypeFactory.GetInputType(type);
            return new Parameter(
                name,
                CreateDescription(operationParameter, type, operationParameter.Type.AllowedValues?.Select(c => c.Value)),
                inputType,
                defaultValue,
                validation,
                initializer,
                IsApiVersionParameter: operationParameter.IsApiVersion,
                IsResourceIdentifier: operationParameter.IsResourceParameter,
                SkipUrlEncoding: skipUrlEncoding,
                RequestLocation: requestLocation);
        }

        public static FormattableString? GetParameterInitializer(CSharpType parameterType, Constant? defaultValue)
        {
            if (TypeFactory.IsCollectionType(parameterType) && (defaultValue == null || TypeFactory.IsCollectionType(defaultValue.Value.Type)))
            {
                defaultValue = Constant.NewInstanceOf(TypeFactory.GetImplementationType(parameterType).WithNullable(false));
            }

            return defaultValue?.GetConstantFormattable();
        }

        public static string CreateDescription(OperationParameter operationParameter, CSharpType type, IEnumerable<string>? values)
        {
            string description = string.IsNullOrWhiteSpace(operationParameter.Description)
                ? $"The {operationParameter.Type.Name} to use."
                : BuilderHelpers.EscapeXmlDescription(operationParameter.Description);

            if (!type.IsFrameworkType || values == null)
            {
                return description;
            }

            var allowedValues = string.Join(" | ", values.Select(v => $"\"{v}\""));
            return $"{description}{(description.EndsWith(".") ? "" : ".")} Allowed values: {BuilderHelpers.EscapeXmlDescription(allowedValues)}";
        }

        public static ValidationType GetValidation(CSharpType type, RequestLocation requestLocation, bool skipUrlEncoding)
        {
            if (requestLocation is RequestLocation.Uri or RequestLocation.Path or RequestLocation.Body && type.EqualsIgnoreNullable(typeof(string)) && !skipUrlEncoding)
            {
                return ValidationType.AssertNotNullOrEmpty;
            }

            if (!type.IsValueType)
            {
                return ValidationType.AssertNotNull;
            }

            return ValidationType.None;
        }
    }

    internal enum ValidationType
    {
        None,
        AssertNotNull,
        AssertNotNullOrEmpty
    }
}
