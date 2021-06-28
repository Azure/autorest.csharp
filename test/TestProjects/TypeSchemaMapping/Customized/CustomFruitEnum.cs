// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace NamespaceForEnums
{
    [CodeGenModel("Fruit")]
    internal enum CustomFruitEnum
    {
        [CodeGenMember("apple")]
        Apple2,
        Pear
    }
}
