﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Decorator;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator.Transformer;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CodeModelTransformer
    {
        public static void Transform()
        {
            DefaultDerivedSchema.AddDefaultDerivedSchemas(MgmtContext.CodeModel);
            SchemaUsageResolver.ResolveConverter(MgmtContext.CodeModel);
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
        }
    }
}
