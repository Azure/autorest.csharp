// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Input;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    internal static class UrlToUri
    {
        private static readonly char LowerCaseI = 'i';

        public static void UpdateSuffix(InputNamespace input)
        {
            foreach (var model in input.Models)
            {
                if (model is not InputModelType inputModel)
                    continue;

                var schemaName = model.Name;
                if (schemaName.EndsWith("Url", StringComparison.Ordinal))
                    model.Name = schemaName.Substring(0, schemaName.Length - 1) + LowerCaseI;

                foreach (var property in inputModel.Properties)
                {
                    var propertyName = property.Name;
                    if (propertyName.EndsWith("Url", StringComparison.Ordinal))
                        property.Name = propertyName.Substring(0, propertyName.Length - 1) + LowerCaseI;
                }
            }
        }
    }
}
