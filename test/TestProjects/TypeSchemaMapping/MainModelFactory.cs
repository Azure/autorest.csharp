// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace TypeSchemaMapping.Models
{
    [CodeGenType("TypeSchemaMappingModelFactory")]
    internal partial class MainModelFactory
    {
        public static ModelWithAbstractModel ModelWithAbstractModel(AbstractModel abstractModelProperty = default)
        {
            return new ModelWithAbstractModel(abstractModelProperty);
        }
    }
}
