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

        internal static void Update(RequestMethod method, InputParameter bodyParameter, string resourceName, InputOperation operation, Dictionary<object, string> renamingMap)
        {
            if (method == RequestMethod.Put)
            {
                UpdateRequestParameter(bodyParameter, "content", $"{resourceName}CreateOrUpdateContent", operation, renamingMap);
            }
            else if (method == RequestMethod.Patch)
            {
                UpdateRequestParameter(bodyParameter, "patch", $"{resourceName}Patch", operation, renamingMap);
            }
            else
            {
                throw new InvalidOperationException($"unhandled HttpMethod {method} for resource {resourceName}");
            }
        }

        internal static void UpdateUsingReplacement(InputParameter bodyParameter, IDictionary<string, HashSet<OperationSet>> resourceDataDictionary, InputOperation operation, Dictionary<object, string> renamingMap)
        {
            var typeName = bodyParameter.Type.Name;
            if (typeName.EndsWith("Parameters", StringComparison.Ordinal))
                typeName = typeName.ReplaceLast("Parameters", Content);
            if (typeName.EndsWith("Request", StringComparison.Ordinal))
                typeName = typeName.ReplaceLast("Request", Content);
            if (typeName.EndsWith("Options", StringComparison.Ordinal))
                typeName = typeName.ReplaceLast("Options", Content);
            if (typeName.EndsWith("Info", StringComparison.Ordinal))
                typeName = typeName.ReplaceLast("Info", Content);
            if (typeName.EndsWith("Input", StringComparison.Ordinal))
                typeName = typeName.ReplaceLast("Input", Content);
            var paramNewName = NormalizeParamNames.GetNewName(bodyParameter.Name, typeName, resourceDataDictionary);
            // TODO -- we need to add a check here to see if this rename introduces parameter name collisions
            UpdateRequestParameter(bodyParameter, paramNewName, typeName, operation, renamingMap);
        }

        internal static void UpdateParameterNameOnly(InputParameter bodyParam, IDictionary<string, HashSet<OperationSet>> resourceDataDictionary, InputOperation operation, Dictionary<object, string> parameterRenaming)
        {
            string oriName = bodyParam.Name;
            var newName = NormalizeParamNames.GetNewName(bodyParam.Name, bodyParam.Type.Name, resourceDataDictionary);
            parameterRenaming.Add(bodyParam, newName);
            string fullSerializedName = operation.GetFullSerializedName(bodyParam);
            MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                new TransformItem(TransformTypeName.UpdateBodyParameter, fullSerializedName),
                fullSerializedName, "UpdateParameterNameOnly", oriName, newName);
        }

        private static void UpdateRequestParameter(InputParameter parameter, string parameterNewName, string typeNewName, InputOperation operation, Dictionary<object, string> renamingMap)
        {
            string oriParameterName = parameter.Name;
            renamingMap.Add(parameter, parameterNewName);
            string fullSerializedName = operation.GetFullSerializedName(parameter);
            MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                new TransformItem(TransformTypeName.UpdateBodyParameter, fullSerializedName),
                fullSerializedName, "UpdateParameterName", oriParameterName, parameterNewName);

            string oriSchemaName = parameter.Type.Name;
            renamingMap.Add(parameter.Type, typeNewName);
            fullSerializedName = parameter.Type.GetFullSerializedName();
            MgmtReport.Instance.TransformSection.AddTransformLogForApplyChange(
                new TransformItem(TransformTypeName.UpdateBodyParameter, fullSerializedName),
                fullSerializedName, "UpdateParameterSchemaName", oriSchemaName, parameter.Type.Name);

            if (parameter.Type is InputEnumType ||
                parameter.Type is InputModelType)
                SchemaNameAndFormatUpdater.UpdateAcronym(parameter.Type, renamingMap);
        }

        internal static InputParameter? MakeRequired(InputParameter bodyParameter, RequestMethod method)
        {
            if (ShouldMarkRequired(method))
            {
                return bodyParameter with { IsRequired = true };
            }
            return null;
        }

        private static bool ShouldMarkRequired(RequestMethod method) => MethodsRequiredBodyParameter.Contains(method);

        private static readonly RequestMethod[] MethodsRequiredBodyParameter = new[] { RequestMethod.Put, RequestMethod.Patch };
    }
}
