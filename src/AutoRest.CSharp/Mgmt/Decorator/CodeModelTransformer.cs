// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Decorator;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator.Transformer;
using Humanizer.Inflections;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CodeModelTransformer
    {
        private static void ApplyGlobalConfigurations()
        {
            foreach ((var word, var plural) in Configuration.MgmtConfiguration.IrregularPluralWords)
            {
                Vocabularies.Default.AddIrregular(word, plural);
            }
        }

        public static void Transform()
        {
            ApplyGlobalConfigurations();

            // schema usage transformer must run first
            SchemaUsageTransformer.Transform(MgmtContext.CodeModel);
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
