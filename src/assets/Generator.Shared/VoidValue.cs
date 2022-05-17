// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Core
{
    public struct VoidValue {
        internal static VoidValue DeserializeVoidValue(JsonElement element)
        {
            return new VoidValue();
        }

        public static explicit operator VoidValue(BinaryData v)
        {
            return new VoidValue();
        }
    }
}
