// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Decorator;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator.Transformer;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CodeModelTransformer
    {
        public static void Transform()
        {
            DefaultDerivedSchema.AddDefaultDerivedSchemas(MgmtContext.CodeModel);
            OmitOperationGroups.RemoveOperationGroups();
            SubscriptionIdUpdater.Update();
            ConstantSchemaTransformer.TransformToChoice();
            SchemaNameAndFormatUpdater.ApplyRenameMapping();
            SchemaNameAndFormatUpdater.UpdateAcronyms();
            UrlToUri.UpdateSuffix();
            FrameworkTypeUpdater.ValidateAndUpdate();
            SchemaFormatByNameTransformer.Update();
            SealedChoicesUpdater.UpdateSealChoiceTypes();
            CommonSingleWordModels.Update();
            RenameTimeToOn.Update();
            RearrangeParameterOrder.Update();
            RenamePluralEnums.Update();
            DuplicateSchemaResolver.ResolveDuplicates();

            if (Configuration.MgmtConfiguration.MgmtDebug.ShowSerializedNames)
            {
                SerializedNamesUpdater.Update();
            }

            CodeModelValidator.Validate();
            Dictionary<string, Property> map = new();

            foreach (var schema in MgmtContext.CodeModel.AllSchemas.OfType<ObjectSchema>())
            {
                foreach (var property in schema.Properties)
                {
                    if (property.Extensions?.TryGetValue("x-ms-format-element-type", out var value) == true)
                    {
                        map.Add((string)value, property);
                    }
                }
            }

            foreach (var schema in MgmtContext.CodeModel.AllSchemas.OfType<ObjectSchema>())
            {
                if (map.TryGetValue(schema.Name, out var property))
                {
                    property.Extensions!["x-ms-format-element-type"] = schema;
                    schema.Extensions ??= new RecordOfStringAndAny();
                    if (!schema.Extensions!.ContainsKey("x-csharp-usage"))
                    {
                        schema.Extensions.Add("x-csharp-usage", "converter");
                    }
                    else
                    {
                        schema.Extensions!["x-csharp-usage"] += ",converter";
                    }
                }
            }
        }
    }
}
