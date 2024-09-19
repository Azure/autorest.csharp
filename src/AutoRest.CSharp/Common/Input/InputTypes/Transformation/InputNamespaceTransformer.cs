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
            InputCommonSingleWordModelTransformer.Transform(input);
            InputAcronymTransformer.Transform(input);
            InputUrlToUriTransformer.Transform(input);
            InputRenameTimeToOnTransformer.Transform(input);
            InputPluralEnumTransformer.Transform(input);
        }
    }
}
