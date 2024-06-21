// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Mgmt.Decorator.Transformer;

namespace AutoRest.CSharp.Common.Input
{
    internal class InputTypeTransformer
    {
        public static void Transform(InputNamespace input)
        {
            InputClientTransformer.Transform(input);
            SchemaNameAndFormatUpdater.UpdateAcronyms(input);
            UrlToUri.UpdateSuffix(input);
        }
    }
}
