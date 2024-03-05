// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator.Transformer;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Report;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class BodyParameterNormalizer
    {
        private static readonly string Content = "Content";

        internal static void Update(RequestMethod method, InputParameter bodyParameter, string resourceName, InputOperation operation)
        {
            if (method == RequestMethod.Put)
            {
                UpdateRequestParameter(bodyParameter, "content", $"{resourceName}CreateOrUpdateContent", operation);
            }
            else if (method == RequestMethod.Patch)
            {
                UpdateRequestParameter(bodyParameter, "patch", $"{resourceName}Patch", operation);
            }
            else
            {
                throw new InvalidOperationException($"unhandled HttpMethod {method} for resource {resourceName}");
            }
        }

        internal static void UpdateUsingReplacement(InputParameter bodyParameter, IDictionary<string, HashSet<OperationSet>> resourceDataDictionary, InputOperation operation)
        {
            var schemaName = bodyParameter.Type.Name;
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
            var paramName = NormalizeParamNames.GetNewName(bodyParameter.Name, schemaName, resourceDataDictionary);
            // TODO -- we need to add a check here to see if this rename introduces parameter name collisions
            UpdateRequestParameter(bodyParameter, paramName, schemaName, operation);
        }

        internal static void UpdateParameterNameOnly(InputParameter bodyParam, IDictionary<string, HashSet<OperationSet>> resourceDataDictionary, InputOperation operation)
        {
            string oriName = bodyParam.Name;
            bodyParam.NameInRequest ??= bodyParam.Name;
            bodyParam.Name = NormalizeParamNames.GetNewName(bodyParam.Name, bodyParam.Type.Name, resourceDataDictionary);
            string fullSerializedName = operation.GetFullSerializedName(bodyParam);
            MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                new TransformItem(TransformTypeName.UpdateBodyParameter, fullSerializedName),
                fullSerializedName, "UpdateParameterNameOnly", oriName, bodyParam.Name);
        }

        private static void UpdateRequestParameter(InputParameter parameter, string parameterName, string schemaName, InputOperation operation)
        {
            string oriParameterName = parameter.Name;
            parameter.NameInRequest ??= parameter.Name;
            parameter.Name = parameterName;
            string fullSerializedName = operation.GetFullSerializedName(parameter);
            MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                new TransformItem(TransformTypeName.UpdateBodyParameter, fullSerializedName),
                fullSerializedName, "UpdateParameterName", oriParameterName, parameter.Name);

            string oriSchemaName = parameter.Type.Name;
            parameter.Type.Name = schemaName;
            parameter.Type.OriginalName = oriSchemaName;
            fullSerializedName = parameter.Type.GetFullSerializedName();
            MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                new TransformItem(TransformTypeName.UpdateBodyParameter, fullSerializedName),
                fullSerializedName, "UpdateParameterSchemaName", oriSchemaName, parameter.Type.Name);

            if (parameter.Type is InputEnumType || parameter.Type is InputModelType)
                SchemaNameAndFormatUpdater.UpdateAcronym(parameter.Type);
        }

        internal static void MakeRequired(InputParameter bodyParameter, RequestMethod method)
        {
            if (ShouldMarkRequired(method))
            {
                bodyParameter.IsRequired = true;
            }
        }

        private static bool ShouldMarkRequired(RequestMethod method) => MethodsRequiredBodyParameter.Contains(method);

        private static readonly RequestMethod[] MethodsRequiredBodyParameter = new[] { RequestMethod.Put, RequestMethod.Patch };
    }
}
