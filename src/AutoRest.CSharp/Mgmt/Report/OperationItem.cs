// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Utilities;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Builders;
using YamlDotNet.Serialization;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class OperationItem : TransformableItem
    {
        public OperationItem(MgmtRestOperation operation, TransformSection transformSection, IReadOnlyDictionary<object, string>? renamingMap)
            : base(operation.Operation.Name, transformSection)
        {
            OperationName = operation.Operation.Name;
            IsLongRunningOperation = operation.IsLongRunningOperation;
            IsPageableOperation = operation.IsPagingOperation;
            Resource = operation.Resource?.ResourceName;

            var bodyParam = operation.Parameters.FirstOrDefault(p => p.RequestLocation == Common.Input.RequestLocation.Body);
            if (bodyParam != null)
            {
                var bodyRequestParam = operation.Operation.GetBodyParameter();
                string? paramFullSerializedName;
                if (bodyRequestParam == null)
                {
                    paramFullSerializedName = $"{operation.Operation.GetFullSerializedName()}.{bodyParam.Name}";
                    string warning = $"Can't find corresponding RequestParameter for Parameter {operation.OperationName}.{bodyParam.Name}. OperationName = {operation.Operation.Name}. Try to use Parameter.Name to parse fullSerializedName as {paramFullSerializedName}";
                    AutoRestLogger.Warning(warning).Wait();
                }
                else
                {
                    var paramName = renamingMap != null && renamingMap.TryGetValue(bodyRequestParam, out var newName) ? newName : bodyRequestParam.CSharpName();
                    if (paramName != bodyParam.Name)
                    {
                        paramFullSerializedName = operation.Operation.GetFullSerializedName(bodyRequestParam);
                        string warning = $"Name mismatch between Parameter and RequestParameter. OperationName = {operation.Operation.Name}. Parameter.Name = {bodyParam.Name}, RequestParameter.CSharpName = {bodyRequestParam.CSharpName()}. Try to use RequestParameter to parse fullSerializedName as {paramFullSerializedName}";
                        AutoRestLogger.Warning(warning).Wait();
                    }
                    else
                    {
                        paramFullSerializedName = operation.Operation.GetFullSerializedName(bodyRequestParam);
                    }
                }
                BodyParameter = new ParameterItem(bodyParam, paramFullSerializedName, transformSection);
            }
        }

        public string OperationName { get; set; }
        [YamlMember(DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ParameterItem? BodyParameter { get; set; }
        [YamlMember(DefaultValuesHandling = DefaultValuesHandling.OmitDefaults)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsLongRunningOperation { get; set; }
        [YamlMember(DefaultValuesHandling = DefaultValuesHandling.OmitDefaults)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool IsPageableOperation { get; set; }
        [YamlMember(DefaultValuesHandling = DefaultValuesHandling.OmitNull)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Resource { get; set; }
    }
}
