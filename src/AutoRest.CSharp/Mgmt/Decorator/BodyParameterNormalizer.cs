// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator.Transformer;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class BodyParameterNormalizer
    {
        private static readonly string Content = "Content";

        internal static void Update(HttpMethod method, string methodName, RequestParameter bodyParameter, string resourceName)
        {
            switch (method)
            {
                case HttpMethod.Put:
                    UpdateRequestParameter(bodyParameter, "content", $"{resourceName}CreateOrUpdateContent");
                    break;
                case HttpMethod.Patch:
                    UpdateRequestParameter(bodyParameter, "patch", $"{resourceName}Patch");
                    break;
                default:
                    throw new InvalidOperationException($"unhandled HttpMethod {method} for resource {resourceName}");
            }
        }

        internal static void UpdateUsingReplacement(RequestParameter bodyParameter, IDictionary<string, HashSet<OperationSet>> resourceDataDictionary)
        {
            var schemaName = bodyParameter.Schema.Language.Default.Name;
            if (schemaName.EndsWith("Parameters", StringComparison.Ordinal))
                schemaName = schemaName.ReplaceLast("Parameters", Content);
            if (schemaName.EndsWith("Request", StringComparison.Ordinal))
                schemaName = schemaName.ReplaceLast("Request", Content);
            if (schemaName.EndsWith("Options", StringComparison.Ordinal))
                schemaName = schemaName.ReplaceLast("Options", Content);
            if (schemaName.EndsWith("Info", StringComparison.Ordinal))
                schemaName = schemaName.ReplaceLast("Info", Content);
            if (schemaName.EndsWith("Input", StringComparison.Ordinal))
                schemaName = schemaName.ReplaceLast("Input", Content);
            var paramName = NormalizeParamNames.GetNewName(bodyParameter.Language.Default.Name, schemaName, resourceDataDictionary);
            // TODO -- we need to add a check here to see if this rename introduces parameter name collisions
            UpdateRequestParameter(bodyParameter, paramName, schemaName);
        }

        internal static void UpdateParameterNameOnly(RequestParameter bodyParam, IDictionary<string, HashSet<OperationSet>> resourceDataDictionary)
        {
            bodyParam.Language.Default.SerializedName ??= bodyParam.Language.Default.Name;
            bodyParam.Language.Default.Name = NormalizeParamNames.GetNewName(bodyParam.Language.Default.Name, bodyParam.Schema.Name, resourceDataDictionary);
        }

        private static void UpdateRequestParameter(RequestParameter parameter, string parameterName, string schemaName)
        {
            parameter.Language.Default.SerializedName ??= parameter.Language.Default.Name;
            parameter.Language.Default.Name = parameterName;
            parameter.Schema.Language.Default.Name = schemaName;
            if (parameter.Schema is ChoiceSchema ||
                parameter.Schema is SealedChoiceSchema ||
                parameter.Schema is ObjectSchema)
                SchemaNameAndFormatUpdater.UpdateAcronym(parameter.Schema);
        }

        internal static void MakeRequired(RequestParameter bodyParameter, HttpMethod method)
        {
            if (ShouldMarkRequired(method))
            {
                bodyParameter.Required = true;
            }
        }

        internal static bool ShouldMarkRequired(HttpMethod method) => MethodsRequiredBodyParameter.Contains(method);

        private static readonly HttpMethod[] MethodsRequiredBodyParameter = new[] { HttpMethod.Put, HttpMethod.Patch };
    }
}
