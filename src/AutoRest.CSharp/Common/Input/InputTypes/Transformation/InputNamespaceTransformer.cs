﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Mgmt.Decorator.Transformer;

namespace AutoRest.CSharp.Common.Input
{
    internal class InputNamespaceTransformer
    {
        public static void Transform(InputNamespace inputNamespace)
        {
            // TODO: Remove this when we have a better way to remove operations, tracking in https://github.com/Azure/typespec-azure/issues/964
            InputClientTransformer.Transform(inputNamespace);
            CommonSingleWordModelTransformer.Transform(inputNamespace);
            DuplicateSchemaResolver.ResolveDuplicates(inputNamespace);
        }
    }
}
