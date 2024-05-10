// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace NoDocsTypeSpec.Models
{
    internal static partial class CsProjectedEnumInModelExtensions
    {
        public static float ToSerialSingle(this CsProjectedEnumInModel value) => value switch
        {
            CsProjectedEnumInModel.CsOne => 1.1F,
            CsProjectedEnumInModel.Two => 2.2F,
            CsProjectedEnumInModel.Four => 4.4F,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CsProjectedEnumInModel value.")
        };

        public static CsProjectedEnumInModel ToCsProjectedEnumInModel(this float value)
        {
            if (value == 1.1F) return CsProjectedEnumInModel.CsOne;
            if (value == 2.2F) return CsProjectedEnumInModel.Two;
            if (value == 4.4F) return CsProjectedEnumInModel.Four;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CsProjectedEnumInModel value.");
        }
    }
}
