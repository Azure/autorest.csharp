// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace _Type.Union.Models
{
    internal static partial class GetResponseProp2Extensions
    {
        public static GetResponseProp2 ToGetResponseProp2(this int value)
        {
            if (value == 1) return GetResponseProp2._1;
            if (value == 2) return GetResponseProp2._2;
            if (value == 3) return GetResponseProp2._3;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown GetResponseProp2 value.");
        }
    }
}
