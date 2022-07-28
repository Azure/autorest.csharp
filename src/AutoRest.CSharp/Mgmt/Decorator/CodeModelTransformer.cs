// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator.Transformer;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CodeModelTransformer
    {
        public static void Transform()
        {
            OmitOperationGroups.RemoveOperationGroups();
            PartialResourceResolver.Update();
            SubscriptionIdUpdater.Update();
            ConstantSchemaTransformer.TransformToChoice();
            SchemaRenamer.ApplyRenameMapping();
            SchemaRenamer.UpdateAcronyms();
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
