// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input
{
    internal class InputNamespaceTransformer
    {
        public static void Transform(InputNamespace input)
        {
            InputClientTransformer.Transform(input);
            InputAcronymTransformer.UpdateAcronyms(input);
            InputUrlToUriTransformer.UpdateSuffix(input);
            InputRenameTimeToOnTransformer.Update(input);
        }
    }
}
