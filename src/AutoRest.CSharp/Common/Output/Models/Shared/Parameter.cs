// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Shared
{
    internal record Parameter(string Name, string? Description, CSharpType Type, Constant? DefaultValue, ValidationType Validation, FormattableString? Initializer, bool IsApiVersionParameter = false, bool IsResourceIdentifier = false, bool SkipUrlEncoding = false, RequestLocation RequestLocation = RequestLocation.None, InputOperationParameterKind Kind = InputOperationParameterKind.Method)
    {
        public FormattableString? FormattableDescription => Description is null ? (FormattableString?)null : $"{Description}";
        public CSharpAttribute[] Attributes { get; init; } = Array.Empty<CSharpAttribute>();
        public bool IsOptionalInSignature => DefaultValue != null;

        public static Parameter FromModelProperty(in InputModelProperty property, string name, CSharpType propertyType, InputOperationParameterKind kind = InputOperationParameterKind.Method)
        {
            var validation = propertyType.IsValueType || property.IsReadOnly ? ValidationType.None : ValidationType.AssertNotNull;
            return new Parameter(name, property.Description, propertyType, null, validation, null, false, false, false, RequestLocation.None, kind);
        }

        public static Parameter FromInputParameter(in InputParameter operationParameter, CSharpType type, TypeFactory typeFactory)
        {
            var name = operationParameter.Name.ToVariableName();
            var skipUrlEncoding = operationParameter.SkipUrlEncoding;
            var requestLocation = operationParameter.Location;

            var defaultValue = operationParameter.DefaultValue != null
                ? BuilderHelpers.ParseConstant(operationParameter.DefaultValue.Value, typeFactory.CreateType(operationParameter.DefaultValue.Type))
                : (Constant?)null;

            var initializer = (FormattableString?)null;

            if (defaultValue != null && operationParameter.Kind != InputOperationParameterKind.Constant && !TypeFactory.CanBeInitializedInline(type, defaultValue))
            {
                initializer = type.GetParameterInitializer(defaultValue.Value);
                type = type.WithNullable(true);
                defaultValue = Constant.Default(type);
            }

            if (!operationParameter.IsRequired && defaultValue == null)
            {
                type = type.WithNullable(true);
                defaultValue = Constant.Default(type);
            }

            var validation = operationParameter.IsRequired && initializer == null
                ? GetValidation(type, requestLocation, skipUrlEncoding)
                : ValidationType.None;

            var inputType = TypeFactory.GetInputType(type);
            return new Parameter(
                name,
                CreateDescription(operationParameter, type, (operationParameter.Type as InputEnumType)?.AllowedValues.Select(c => c.GetValueString())),
                inputType,
                defaultValue,
                validation,
                initializer,
                IsApiVersionParameter: operationParameter.IsApiVersion,
                IsResourceIdentifier: operationParameter.IsResourceParameter,
                SkipUrlEncoding: skipUrlEncoding,
                RequestLocation: requestLocation,
                Kind: operationParameter.Kind);
        }

        public static string CreateDescription(InputParameter operationParameter, CSharpType type, IEnumerable<string>? values)
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

        public static Parameter FromRequestParameter(in RequestParameter requestParameter, CSharpType type, TypeFactory typeFactory)
        {
            var name = requestParameter.CSharpName();
            var skipUrlEncoding = requestParameter.Extensions?.SkipEncoding ?? false;
            var requestLocation = GetRequestLocation(requestParameter);

            var defaultValue = GetClientDefaultValue(requestParameter, typeFactory) ?? ParseConstant(requestParameter, typeFactory);
            var initializer = (FormattableString?)null;

            if (defaultValue != null && !TypeFactory.CanBeInitializedInline(type, defaultValue))
            {
                initializer = type.GetParameterInitializer(defaultValue.Value);
                type = type.WithNullable(true);
                defaultValue = Constant.Default(type);
            }

            if (!requestParameter.IsRequired && defaultValue == null)
            {
                defaultValue = Constant.Default(type);
            }

            var validation = requestParameter.IsRequired && initializer == null
                ? GetValidation(type, requestLocation, skipUrlEncoding)
                : ValidationType.None;

            var inputType = TypeFactory.GetInputType(type);
            return new Parameter(
                name,
                CreateDescription(requestParameter, type),
                inputType,
                defaultValue,
                validation,
                initializer,
                IsApiVersionParameter: requestParameter.Origin == "modelerfour:synthesized/api-version",
                IsResourceIdentifier: requestParameter.IsResourceParameter,
                SkipUrlEncoding: skipUrlEncoding,
                RequestLocation: requestLocation);
        }

        private static RequestLocation GetRequestLocation(RequestParameter requestParameter)
            => requestParameter.In switch
            {
                HttpParameterIn.Uri => RequestLocation.Uri,
                HttpParameterIn.Path => RequestLocation.Path,
                HttpParameterIn.Query => RequestLocation.Query,
                HttpParameterIn.Header => RequestLocation.Header,
                HttpParameterIn.Body => RequestLocation.Body,
                _ => RequestLocation.None
            };

        private static string CreateDescription(RequestParameter requestParameter, CSharpType type)
        {
            var description = string.IsNullOrWhiteSpace(requestParameter.Language.Default.Description) ?
                $"The {requestParameter.Schema.Name} to use." :
                BuilderHelpers.EscapeXmlDescription(requestParameter.Language.Default.Description);

            return requestParameter.Schema switch
            {
                ChoiceSchema choiceSchema when type.IsFrameworkType => AddAllowedValues(description, choiceSchema.Choices),
                SealedChoiceSchema sealedChoiceSchema when type.IsFrameworkType => AddAllowedValues(description, sealedChoiceSchema.Choices),
                _ => description
            };

            static string AddAllowedValues(string description, ICollection<ChoiceValue> choices)
            {
                var allowedValues = string.Join(" | ", choices.Select(c => c.Value).Select(v => $"\"{v}\""));

                return string.IsNullOrEmpty(allowedValues)
                    ? description
                    : $"{description}{(description.EndsWith(".") ? "" : ".")} Allowed values: {BuilderHelpers.EscapeXmlDescription(allowedValues)}";
            }
        }

        private static Constant? GetClientDefaultValue(RequestParameter parameter, TypeFactory typeFactory)
        {
            if (parameter.ClientDefaultValue != null)
            {
                CSharpType constantTypeReference = typeFactory.CreateType(parameter.Schema, parameter.IsNullable);
                return BuilderHelpers.ParseConstant(parameter.ClientDefaultValue, constantTypeReference);
            }

            return null;
        }

        private static Constant? ParseConstant(RequestParameter parameter, TypeFactory typeFactory)
        {
            if (parameter.Schema is ConstantSchema constantSchema)
            {
                return BuilderHelpers.ParseConstant(constantSchema.Value.Value, typeFactory.CreateType(constantSchema.ValueType, constantSchema.Value.Value == null));
            }

            return null;
        }
    }

    internal enum ValidationType
    {
        None,
        AssertNotNull,
        AssertNotNullOrEmpty
    }
}
