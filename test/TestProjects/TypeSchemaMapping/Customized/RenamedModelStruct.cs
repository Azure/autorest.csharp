// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace CustomNamespace
{
#pragma warning disable CS0282 // ignore struct ordering warning
    [CodeGenSchema("ModelStruct")]
    internal partial struct RenamedModelStruct
    {
        [CodeGenSchemaMember("ModelProperty")]
        private string CustomizedFlattenedStringProperty { get; }
    }
}