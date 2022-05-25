// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Output.Models.Shared
{
    internal record Parameter(string Name, string? Description, CSharpType Type, Constant? DefaultValue, ValidationType Validation, FormattableString? Initializer, bool IsApiVersionParameter = false, bool IsResourceIdentifier = false, bool SkipUrlEncoding = false, RequestLocation RequestLocation = RequestLocation.None)
    {
        public CSharpAttribute[] Attributes { get; init; } = Array.Empty<CSharpAttribute>();
        public bool IsOptionalInSignature => DefaultValue != null;

        public static Parameter FromRequestParameter(in RequestParameter requestParameter, CSharpType type, TypeFactory typeFactory)
        {
            var name = requestParameter.CSharpName();
            var skipUrlEncoding = requestParameter.Extensions?.SkipEncoding ?? false;
            var requestLocation = GetRequestLocation(requestParameter);

            var defaultValue = GetClientDefaultValue(requestParameter, typeFactory) ?? ParseConstant(requestParameter, typeFactory);
            var initializer = (FormattableString?)null;

            if (defaultValue != null && !TypeFactory.CanBeInitializedInline(type, defaultValue))
            {
                initializer = GetParameterInitializer(type, defaultValue.Value);
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

        public static FormattableString? GetParameterInitializer(CSharpType parameterType, Constant? defaultValue)
        {
            if (TypeFactory.IsCollectionType(parameterType) && (defaultValue == null || TypeFactory.IsCollectionType(defaultValue.Value.Type)))
            {
                defaultValue = Constant.NewInstanceOf(TypeFactory.GetImplementationType(parameterType).WithNullable(false));
            }

            return defaultValue?.GetConstantFormattable();
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

        public Parameter CloneWithRequired()
        {
            return this with
            {
                DefaultValue = null,
            };
        }
    }

    internal enum ValidationType
    {
        None,
        AssertNotNull,
        AssertNotNullOrEmpty
    }

    internal enum RequestLocation
    {
        None,
        Uri,
        Path,
        Query,
        Header,
        Body,
    }
}
