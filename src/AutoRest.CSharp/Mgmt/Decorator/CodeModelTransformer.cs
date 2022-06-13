// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator.Transformer;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CodeModelTransformer
    {
        public static void Transform()
        {
            OmitOperationGroups.RemoveOperationGroups();
            SubscriptionIdUpdater.Update();
            SchemaRenamer.UpdateAcronyms();
            UrlToUri.UpdateSuffix();
            BodyParameterNormalizer.UpdatePatchOperations();
            FrameworkTypeUpdater.ValidateAndUpdate();
            SealedChoicesUpdater.UpdateSealChoiceTypes();
            CommonSingleWordModels.Update();
            RenameTimeToOn.Update();
            RearrangeParameterOrder.Update();

            CodeModelValidator.Validate();
        }
    }
}
