// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Decorator;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator.Transformer;
using Humanizer.Inflections;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CodeModelTransformer
    {
        public static void Transform(CodeModel codeModel)
        {
            // schema usage transformer must run first
            SchemaUsageTransformer.Transform(codeModel);
            OmitOperationGroups.RemoveOperationGroups(codeModel);
            PartialResourceResolver.Update(codeModel);
            SubscriptionIdUpdater.Update(codeModel);
            ConstantSchemaTransformer.Transform(codeModel);
            CommonSingleWordModels.Update(codeModel);
            SchemaNameAndFormatUpdater.ApplyRenameMapping(codeModel);
            SchemaNameAndFormatUpdater.UpdateAcronyms(codeModel);
            UrlToUri.UpdateSuffix(codeModel);
            FrameworkTypeUpdater.ValidateAndUpdate(codeModel);
            SchemaFormatByNameTransformer.Update(codeModel);
            SealedChoicesUpdater.UpdateSealChoiceTypes(codeModel);
            RenameTimeToOn.Update(codeModel);
            RearrangeParameterOrder.Update(codeModel);
            RenamePluralEnums.Update(codeModel);
            DuplicateSchemaResolver.ResolveDuplicates(codeModel);

            if (Configuration.MgmtConfiguration.MgmtDebug.ShowSerializedNames)
            {
                SerializedNamesUpdater.Update(codeModel);
            }
            //eliminate client default value from property
            ModelPropertyClientDefaultValueTransformer.Transform(codeModel);

            CodeModelValidator.Validate(codeModel);
        }
    }
}
