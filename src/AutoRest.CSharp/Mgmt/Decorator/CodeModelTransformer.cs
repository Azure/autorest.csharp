// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Decorator;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator.Transformer;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CodeModelTransformer
    {
        public static void Transform(CodeModel codeModel)
        {
            // schema usage transformer must run first
            SchemaUsageTransformer.Transform(codeModel);
            DefaultDerivedSchema.AddDefaultDerivedSchemas(codeModel);
            OmitOperationGroups.RemoveOperationGroups();
            PartialResourceResolver.Update();
            SubscriptionIdUpdater.Update();
            ConstantSchemaTransformer.Transform(MgmtContext.CodeModel);
            CommonSingleWordModels.Update();
            SchemaNameAndFormatUpdater.ApplyRenameMapping();
            SchemaNameAndFormatUpdater.UpdateAcronyms();
            UrlToUri.UpdateSuffix();
            FrameworkTypeUpdater.ValidateAndUpdate();
            SchemaFormatByNameTransformer.Update();
            SealedChoicesUpdater.UpdateSealChoiceTypes();
            RenameTimeToOn.Update();
            RearrangeParameterOrder.Update();
            RenamePluralEnums.Update();
            DuplicateSchemaResolver.ResolveDuplicates();

            if (Configuration.MgmtConfiguration.MgmtDebug.ShowSerializedNames)
            {
                SerializedNamesUpdater.Update();
            }
            //eliminate client default value from property
            ModelPropertyClientDefaultValueTransformer.Transform(MgmtContext.CodeModel);

            CodeModelValidator.Validate();
        }
    }
}
