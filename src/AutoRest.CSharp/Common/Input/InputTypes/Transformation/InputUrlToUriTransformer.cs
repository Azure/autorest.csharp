// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;

namespace AutoRest.CSharp.Common.Input
{
    internal static class InputUrlToUriTransformer
    {
        public static void Transform(InputNamespace input)
        {
            foreach (var model in input.Models)
            {
                if (model is not InputModelType inputModel)
                    continue;

                if (TryTransformUrlToUri(model.Name, out var newModelName))
                {
                    model.Name = newModelName;
                }

                foreach (var property in inputModel.Properties)
                {
                    if (TryTransformUrlToUri(property.Name, out var newPropertyName))
                    {
                        property.Name = newPropertyName;
                    }
                }
            }
        }

        internal static bool TryTransformUrlToUri(string name, [MaybeNullWhen(false)] out string newName)
        {
            const char i = 'i';
            const char u = 'U';
            const char r = 'r';
            const char l = 'l';
            newName = null;
            var span = name.AsSpan();
            if (span.Length < 3)
            {
                return false;
            }

            // check if this ends with `Url`
            if (span[^3] == u && span[^2] == r && span[^1] == l)
            {
                Span<char> newSpan = span.ToArray();
                newSpan[^1] = i;

                newName = new string(newSpan);
                return true;
            }

            return false;
        }
    }
}
