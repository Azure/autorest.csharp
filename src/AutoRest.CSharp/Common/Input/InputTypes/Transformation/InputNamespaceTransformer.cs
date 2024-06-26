// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input
{
    internal class InputNamespaceTransformer
    {
        public static void Transform(InputNamespace input)
        {
            // TODO: Remove this when we have a better way to remove operations, tracking in https://github.com/Azure/typespec-azure/issues/964
            InputClientTransformer.Transform(input);
            InputAcronymTransformer.UpdateAcronyms(input);
            InputUrlToUriTransformer.UpdateSuffix(input);
            InputRenameTimeToOnTransformer.Update(input);
        }
    }
}
