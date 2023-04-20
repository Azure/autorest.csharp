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
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal class MgmtRestClientBuilder
    {
        private static readonly HashSet<string> IgnoredRequestHeader = new(StringComparer.OrdinalIgnoreCase)
        {
            "x-ms-client-request-id",
            "tracestate",
            "traceparent"
        };

        private class ParameterComparer : IEqualityComparer<RequestParameter>, IEqualityComparer<InputParameter>
        {
            public bool Equals(RequestParameter? x, RequestParameter? y)
            {
                if (x is null)
                    return y is null;

                if (y is null)
                    return false;

                return x.Language.Default.Name == y.Language.Default.Name && x.Implementation == y.Implementation;
            }

            public bool Equals(InputParameter? x, InputParameter? y)
            {
                if (x is null)
                    return y is null;

                if (y is null)
                    return false;

                return x.Name == y.Name;
            }

            public int GetHashCode(InputParameter obj) => obj.Name.GetHashCode();

            public int GetHashCode(RequestParameter obj) => obj.Language.Default.Name.GetHashCode() ^ obj.Implementation.GetHashCode();
        }

        public static IEnumerable<InputParameter> GetMgmtParametersFromOperations(IEnumerable<InputOperation> operations)
            => operations
                .SelectMany(op => op.Parameters)
                .Where(p => p.Kind == InputOperationParameterKind.Client)
                .Distinct(new ParameterComparer());

        public static IReadOnlyDictionary<string, (ReferenceOrConstant ReferenceOrConstant, bool SkipUrlEncoding)> GetReferencesToOperationParameters(Operation operation, IEnumerable<RequestParameter> requestParameters, TypeFactory typeFactory)
        {
            var allParameters = operation.Parameters
                .Concat(requestParameters)
                .Where(rp => !IsIgnoredHeaderParameter(rp));

            var dictionary = new Dictionary<string, (ReferenceOrConstant, bool SkipUrlEncoding)>();
            foreach (var requestParameter in allParameters)
            {
                var parameter = BuildParameter(requestParameter, typeFactory);
                var name = GetRequestParameterName(requestParameter);
                var reference = requestParameter.Implementation != ImplementationLocation.Method
                    ? BuildConstructorParameter(requestParameter, typeFactory)
                    : CreateReference(requestParameter, parameter, typeFactory);

                dictionary.Add(name, (reference, parameter.SkipUrlEncoding));
            }

            return dictionary;
        }

        private static ReferenceOrConstant CreateReference(RequestParameter requestParameter, Parameter parameter, TypeFactory typeFactory)
        {
            if (requestParameter.Schema is ConstantSchema constant)
            {
                return ParseConstant(constant, typeFactory);
            }

            var groupedByParameter = requestParameter.GroupedBy;
            if (groupedByParameter == null)
            {
                return parameter;
            }

            var groupModel = (SchemaObjectType)typeFactory.CreateType(groupedByParameter.Schema, false).Implementation;
            var property = groupModel.GetPropertyForGroupedParameter(requestParameter.Language.Default.Name);

            return new Reference($"{groupedByParameter.CSharpName()}.{property.Declaration.Name}", property.Declaration.Type);

        }

        private static Parameter BuildConstructorParameter(RequestParameter requestParameter, TypeFactory typeFactory)
        {
            var parameter = BuildParameter(requestParameter, typeFactory);
            if (IsEndpointParameter(requestParameter))
            {
                var name = "endpoint";
                var type = new CSharpType(typeof(Uri));
                var defaultValue = parameter.DefaultValue;
                var description = parameter.Description;
                var location = parameter.RequestLocation;

                parameter = defaultValue != null
                    ? new Parameter(name, description, type, Constant.Default(type.WithNullable(true)), Validation.None, $"new {typeof(Uri)}({defaultValue.Value.GetConstantFormattable()})", RequestLocation: location)
                    : new Parameter(name, description, type, null, parameter.Validation, null, RequestLocation: location);
            }

            return parameter.IsApiVersionParameter
                ? parameter with { DefaultValue = Constant.Default(parameter.Type.WithNullable(true)), Initializer = parameter.DefaultValue?.GetConstantFormattable() }
                : parameter;
        }

        private static Parameter BuildParameter(in RequestParameter requestParameter, TypeFactory typeFactory)
        {
            var isNullable = requestParameter.IsNullable || !requestParameter.IsRequired;
            CSharpType type = typeFactory.CreateType(requestParameter.Schema, requestParameter.Extensions?.Format, isNullable);
            return Parameter.FromRequestParameter(requestParameter, type, typeFactory);
        }

        private static Constant ParseConstant(ConstantSchema constant, TypeFactory typeFactory) =>
            BuilderHelpers.ParseConstant(constant.Value.Value, typeFactory.CreateType(constant.ValueType, constant.Value.Value == null));

        private static bool IsEndpointParameter(RequestParameter requestParameter)
            => requestParameter.Origin == "modelerfour:synthesized/host";

        private static string GetRequestParameterName(RequestParameter requestParameter)
        {
            var language = requestParameter.Language.Default;
            return language.SerializedName ?? language.Name;
        }

        private static bool IsIgnoredHeaderParameter(RequestParameter requestParameter)
            => requestParameter.In == HttpParameterIn.Header && IgnoredRequestHeader.Contains(GetRequestParameterName(requestParameter));
    }
}
