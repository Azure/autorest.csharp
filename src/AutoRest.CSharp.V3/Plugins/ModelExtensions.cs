// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Plugins
{
    internal static class ModelExtensions
    {
        public static bool IsNullable(this Parameter parameter) => !(parameter.Required ?? false);
        public static bool IsNullable(this Property parameter) => !(parameter.Required ?? false);

        public static string CSharpName(this Parameter parameter) => parameter.Schema is ConstantSchema ?
            parameter.Language.Default.Name.ToCleanName() :
            parameter.Language.Default.Name.ToVariableName();

        public static string CSharpName(this ChoiceValue choice) => choice.Language.Default.Name.ToCleanName();

        public static string CSharpName(this Property property) =>
            (property.Language.Default.Name == null || property.Language.Default.Name == "null") ? "NullProperty" : property.Language.Default.Name.ToCleanName();

        public static string CSharpName(this OperationGroup operationGroup) =>
            $"{(!operationGroup.Language.Default.Name.IsNullOrEmpty() ? operationGroup.Language.Default.Name.ToCleanName() : "All")}Operations";

        public static string CSharpName(this Operation operation) =>
            operation.Language.Default.Name.ToCleanName();

        public static string CSharpName(this Schema operation) =>
            operation.Language.Default.Name.ToCleanName();

        public static string CSharpName(this ISchemaTypeProvider operation) =>
            operation.Name.ToCleanName();
    }
}
