// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.Common.Input
{
    internal class InputUrlToUriTransformer
    {
        private static readonly char LowerCaseI = 'i';
        private const string UrlSuffix = "Url";

        public static void Transform(InputNamespace input)
        {
            foreach (var model in input.Models)
            {
                if (model is not InputModelType inputModel)
                    continue;

                if (model.Name.AsSpan().EndsWith(UrlSuffix, StringComparison.Ordinal))
                {
                    var newName = model.Name.ToCharArray().AsSpan();
                    newName[^1] = LowerCaseI;
                    model.Name = newName.ToString();
                }

                foreach (var property in inputModel.Properties)
                {
                    if (property.Name.AsSpan().EndsWith(UrlSuffix, StringComparison.Ordinal))
                    {
                        var newName = property.Name.ToCharArray().AsSpan();
                        newName[^1] = LowerCaseI;
                        property.Name = newName.ToString();
                    }
                }
            }
        }
    }
}
