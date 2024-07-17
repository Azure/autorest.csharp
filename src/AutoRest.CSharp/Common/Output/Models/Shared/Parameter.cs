// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.InputTypes;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models.Shared
{
    internal record Parameter(string Name, FormattableString? Description, CSharpType Type, Constant? DefaultValue, ValidationType Validation, FormattableString? Initializer, bool IsApiVersionParameter = false, bool IsEndpoint = false, bool IsResourceIdentifier = false, bool SkipUrlEncoding = false, RequestLocation RequestLocation = RequestLocation.None, SerializationFormat SerializationFormat = SerializationFormat.Default, bool IsPropertyBag = false, bool IsRef = false, bool IsOut = false)
    {
        public bool IsRawData { get; init; }

        public static IEqualityComparer<Parameter> TypeAndNameEqualityComparer = new ParameterTypeAndNameEqualityComparer();
        public CSharpAttribute[] Attributes { get; init; } = Array.Empty<CSharpAttribute>();
        public bool IsOptionalInSignature => DefaultValue != null;

        public Parameter WithRef(bool isRef = true) => IsRef == isRef ? this : this with { IsRef = isRef };

        public Parameter ToRequired()
        {
            return this with { DefaultValue = null };
        }

        public static Parameter FromInputParameter(in InputParameter operationParameter, CSharpType type, TypeFactory typeFactory, bool shouldKeepClientDefaultValue = false)
        {
            var name = ConstructParameterVariableName(operationParameter, type);
            var skipUrlEncoding = operationParameter.SkipUrlEncoding;
            var requestLocation = operationParameter.Location;

            bool keepClientDefaultValue = shouldKeepClientDefaultValue || operationParameter.Kind == InputOperationParameterKind.Constant || operationParameter.IsApiVersion || operationParameter.IsContentType || operationParameter.IsEndpoint;
            Constant? clientDefaultValue = GetDefaultValue(operationParameter, typeFactory);

            var defaultValue = keepClientDefaultValue
                ? clientDefaultValue
                : (Constant?)null;

            var initializer = (FormattableString?)null;

            if (defaultValue != null && operationParameter.Kind != InputOperationParameterKind.Constant && !type.CanBeInitializedInline(defaultValue))
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

            var inputType = type.InputType;
            return new Parameter(
                name,
                CreateDescription(operationParameter, inputType, (operationParameter.Type.GetImplementType() as InputEnumType)?.Values.Select(c => c.GetValueString()), keepClientDefaultValue ? null : clientDefaultValue),
                inputType,
                defaultValue,
                validation,
                initializer,
                IsApiVersionParameter: operationParameter.IsApiVersion,
                IsEndpoint: operationParameter.IsEndpoint,
                IsResourceIdentifier: operationParameter.IsResourceParameter,
                SkipUrlEncoding: skipUrlEncoding,
                RequestLocation: requestLocation,
                SerializationFormat: SerializationBuilder.GetSerializationFormat(operationParameter.Type));
        }

        private static Constant? GetDefaultValue(InputParameter operationParameter, TypeFactory typeFactory) => operationParameter switch
        {
            { NameInRequest: var nameInRequest } when RequestHeader.ClientRequestIdHeaders.Contains(nameInRequest) => Constant.FromExpression($"message.{Configuration.ApiTypes.HttpMessageRequestName}.ClientRequestId", new CSharpType(typeof(string))),
            { NameInRequest: var nameInRequest } when RequestHeader.ReturnClientRequestIdResponseHeaders.Contains(nameInRequest) => new Constant("true", new CSharpType(typeof(string))),
            { DefaultValue: not null } => BuilderHelpers.ParseConstant(operationParameter.DefaultValue.Value, typeFactory.CreateType(operationParameter.DefaultValue.Type)),
            { Type: InputLiteralType { Value: not null} literalValue } => BuilderHelpers.ParseConstant(literalValue.Value, typeFactory.CreateType(literalValue.ValueType)),
            { NameInRequest: var nameInRequest } when nameInRequest.Equals(RequestHeader.RepeatabilityRequestId, StringComparison.OrdinalIgnoreCase) =>
                // Guid.NewGuid()
                Constant.FromExpression($"{nameof(Guid)}.{nameof(Guid.NewGuid)}()", new CSharpType(typeof(string))),
            { NameInRequest: var nameInRequest } when nameInRequest.Equals(RequestHeader.RepeatabilityFirstSent, StringComparison.OrdinalIgnoreCase) =>
                // DateTimeOffset.Now
                Constant.FromExpression($"{nameof(DateTimeOffset)}.{nameof(DateTimeOffset.Now)}", new CSharpType(typeof(DateTimeOffset))),
            _ => (Constant?)null,
        };

        public static FormattableString CreateDescription(InputParameter operationParameter, CSharpType type, IEnumerable<string>? values, Constant? defaultValue = null)
        {
            FormattableString description = string.IsNullOrWhiteSpace(operationParameter.Description)
                ? (FormattableString)$"The {type:C} to use."
                : $"{BuilderHelpers.EscapeXmlDocDescription(operationParameter.Description)}";
            if (defaultValue != null)
            {
                var defaultValueString = defaultValue?.Value is string s ? $"\"{s}\"" : $"{defaultValue?.Value}";
                description = $"{description}{(description.ToString().EndsWith(".") ? "" : ".")} The default value is {defaultValueString}";
            }

            if (!type.IsFrameworkType || values == null)
            {
                return description;
            }

            var allowedValues = string.Join(" | ", values.Select(v => $"\"{v}\""));
            return $"{description}{(description.ToString().EndsWith(".") ? "" : ".")} Allowed values: {BuilderHelpers.EscapeXmlDocDescription(allowedValues)}";
        }

        /// <summary>
        /// This method constructs the variable name for an input parameter. If the input parameter type is an input model type,
        /// and the input parameter name is the same as the input parameter type name, the variable name is constructed using the supplied CSharpType name. Otherwise,
        /// it will use the input parameter name by default.
        /// </summary>
        /// <param name="param">The input parameter.</param>
        /// <param name="type">The constructed CSharpType for the input parameter.</param>
        /// <returns>A string representing the variable name for the input parameter.</returns>
        private static string ConstructParameterVariableName(InputParameter param, CSharpType type)
        {
            string paramName = param.Name;
            string variableName = paramName.ToVariableName();

            if (param.Type.GetImplementType() is InputModelType paramInputType)
            {
                var paramInputTypeName = paramInputType.Name;

                if (paramName.Equals(paramInputTypeName) || // remove this after adoption of TCGC
                    paramName.Equals(paramInputTypeName.ToVariableName()))
                {
                    variableName = !string.IsNullOrEmpty(type.Name) ? type.Name.ToVariableName() : variableName;
                }

            }

            return variableName;
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

        private static FormattableString CreateDescription(InputParameter requestParameter, CSharpType type, Constant? defaultValue = null)
        {
            FormattableString description = string.IsNullOrWhiteSpace(requestParameter.Description) ?
                (FormattableString)$"The {type:C} to use." :
                $"{BuilderHelpers.EscapeXmlDocDescription(requestParameter.Description)}";
            if (defaultValue != null)
            {
                var defaultValueString = defaultValue?.Value is string s ? $"\"{s}\"" : $"{defaultValue?.Value}";
                description = $"{description}{(description.ToString().EndsWith(".") ? "" : ".")} The default value is {defaultValueString}";
            }

            return requestParameter.Type switch
            {
                InputEnumType choiceSchema when type.IsFrameworkType => AddAllowedValues(description, choiceSchema.Values),
                InputNullableType { Type: InputEnumType ie } => AddAllowedValues(description, ie.Values),
                _ => description
            };

            static FormattableString AddAllowedValues(FormattableString description, IReadOnlyList<InputEnumTypeValue> choices)
            {
                var allowedValues = choices.Select(c => (FormattableString)$"{c.Value:L}").ToArray().Join(" | ");

                return allowedValues.IsNullOrEmpty()
                    ? description
                    : $"{description}{(description.ToString().EndsWith(".") ? "" : ".")} Allowed values: {BuilderHelpers.EscapeXmlDocDescription(allowedValues.ToString())}";
            }
        }

        private static Constant? ParseConstant(InputParameter parameter, TypeFactory typeFactory)
        {
            if (parameter.Location == RequestLocation.Header)
            {
                if (RequestHeader.ClientRequestIdHeaders.Contains(parameter.NameInRequest ?? parameter.Name))
                {
                    return Constant.FromExpression($"message.{Configuration.ApiTypes.HttpMessageRequestName}.ClientRequestId", new CSharpType(typeof(string)));
                }
                else if (RequestHeader.ReturnClientRequestIdResponseHeaders.Contains(parameter.NameInRequest ?? parameter.Name))
                {
                    return new Constant("true", new CSharpType(typeof(string)));
                }
            }
            if (parameter.Kind == InputOperationParameterKind.Constant && parameter.IsRequired)
            {
                return GetDefaultValue(parameter, typeFactory);
            }

            return null;
        }

        public static readonly IEqualityComparer<Parameter> EqualityComparerByType = new ParameterByTypeEqualityComparer();
        private struct ParameterByTypeEqualityComparer : IEqualityComparer<Parameter>
        {
            public bool Equals(Parameter? x, Parameter? y)
            {
                return object.Equals(x?.Type, y?.Type);
            }

            public int GetHashCode([DisallowNull] Parameter obj) => obj.Type.GetHashCode();
        }

        private class ParameterTypeAndNameEqualityComparer : IEqualityComparer<Parameter>
        {
            public bool Equals(Parameter? x, Parameter? y)
            {
                if (object.ReferenceEquals(x, y))
                {
                    return true;
                }

                if (x is null || y is null)
                {
                    return false;
                }

                // We can't use CsharpType.Equals here because they can have different implementations from different versions
                var result = x.Type.AreNamesEqual(y.Type) && x.Name == y.Name;
                return result;
            }

            public int GetHashCode([DisallowNull] Parameter obj)
            {
                // remove type as part of the hash code generation as the type might have changes between versions
                return HashCode.Combine(obj.Name);
            }
        }
    }

    internal enum ValidationType
    {
        None,
        AssertNotNull,
        AssertNotNullOrEmpty
    }
}
