// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input.InputTypes.Transformation;

namespace AutoRest.CSharp.Common.Input.InputTypes
{
    internal class InputTypeTransformer
    {
        public static void Transform(InputNamespace input)
        {
            InputClientTransformer.Transform(input);
        }
    }
}
