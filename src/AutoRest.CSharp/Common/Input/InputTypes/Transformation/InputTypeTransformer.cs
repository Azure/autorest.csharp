// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input
{
    internal class InputTypeTransformer
    {
        public static void Transform(InputNamespace input)
        {
            InputClientTransformer.Transform(input);
            InputPluralEnumTransformer.Transform(input);
        }
    }
}
