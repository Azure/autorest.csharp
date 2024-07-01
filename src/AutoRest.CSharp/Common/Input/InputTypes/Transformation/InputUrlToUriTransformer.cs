// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.Common.Input
{
    internal class InputUrlToUriTransformer
    {
        private static readonly char LowerCaseI = 'i';

        public static void UpdateSuffix(InputNamespace input)
        {
            foreach (var model in input.Models)
            {
                if (model is not InputModelType inputModel)
                    continue;

                var schemaName = model.Name.AsSpan();
                if (schemaName.EndsWith("Url", StringComparison.Ordinal))
                    model.Name = schemaName.Slice(0, schemaName.Length - 1).ToString() + LowerCaseI;

                foreach (var property in inputModel.Properties)
                {
                    var propertyName = property.Name.AsSpan();
                    if (propertyName.EndsWith("Url", StringComparison.Ordinal))
                        property.Name = propertyName.Slice(0, propertyName.Length - 1).ToString() + LowerCaseI;
                }
            }
        }
    }
}
