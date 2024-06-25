// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
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

        internal static void Update(RequestMethod method, InputParameter bodyParameter, string resourceName, InputOperation operation, List<InputType> updatedTypes)
        {
            if (method == RequestMethod.Put)
            {
                UpdateRequestParameter(bodyParameter, "content", $"{resourceName}CreateOrUpdateContent", operation, updatedTypes);
            }
            else if (method == RequestMethod.Patch)
            {
                UpdateRequestParameter(bodyParameter, "patch", $"{resourceName}Patch", operation, updatedTypes);
            }
        }

        internal static void UpdateUsingReplacement(InputParameter bodyParameter, IDictionary<string, HashSet<OperationSet>> resourceDataDictionary, InputOperation operation, List<InputType> updatedTypes)
        {
            var schemaName = bodyParameter.Type.GetImplementType().Name;
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
            UpdateRequestParameter(bodyParameter, paramName, schemaName, operation, updatedTypes);
        }

        internal static void UpdateParameterNameOnly(InputParameter bodyParam, IDictionary<string, HashSet<OperationSet>> resourceDataDictionary, InputOperation operation)
        {
            string oriName = bodyParam.Name;
            bodyParam.Name = NormalizeParamNames.GetNewName(bodyParam.Name, bodyParam.Type.GetImplementType().Name, resourceDataDictionary);
            string fullSerializedName = operation.GetFullSerializedName(bodyParam);
            MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                new TransformItem(TransformTypeName.UpdateBodyParameter, fullSerializedName),
                fullSerializedName, "UpdateParameterNameOnly", oriName, bodyParam.Name);
        }

        private static void UpdateRequestParameter(InputParameter parameter, string parameterName, string schemaName, InputOperation operation, List<InputType> updatedTypes)
        {
            string oriParameterName = parameter.Name;
            parameter.Name = parameterName;
            string fullSerializedName = operation.GetFullSerializedName(parameter);
            MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                new TransformItem(TransformTypeName.UpdateBodyParameter, fullSerializedName),
                fullSerializedName, "UpdateParameterName", oriParameterName, parameter.Name);

            InputType parameterType = parameter.Type.GetImplementType();
            string oriSchemaName = parameterType.Name;
            if (oriSchemaName != schemaName)
            {
                // we only need to update the schema name if it is a model or enum type
                if (parameterType is InputModelType || parameter.Type is InputEnumType)
                {
                    updatedTypes.Add(parameterType);
                }
                parameterType.Name = schemaName;
                fullSerializedName = parameterType.GetFullSerializedName();
                MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                    new TransformItem(TransformTypeName.UpdateBodyParameter, fullSerializedName),
                    fullSerializedName, "UpdateParameterSchemaName", oriSchemaName, parameterType.Name);
            }

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
