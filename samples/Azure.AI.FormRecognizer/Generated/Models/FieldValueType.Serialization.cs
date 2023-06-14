// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.FormRecognizer.Models
{
    internal static partial class FieldValueTypeExtensions
    {
        public static string ToSerialString(this FieldValueType value) => value switch
        {
            FieldValueType.String => "string",
            FieldValueType.Date => "date",
            FieldValueType.Time => "time",
            FieldValueType.PhoneNumber => "phoneNumber",
            FieldValueType.Number => "number",
            FieldValueType.Integer => "integer",
            FieldValueType.Array => "array",
            FieldValueType.Object => "object",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FieldValueType value.")
        };

        public static FieldValueType ToFieldValueType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "string")) return FieldValueType.String;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "date")) return FieldValueType.Date;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "time")) return FieldValueType.Time;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "phoneNumber")) return FieldValueType.PhoneNumber;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "number")) return FieldValueType.Number;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "integer")) return FieldValueType.Integer;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "array")) return FieldValueType.Array;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "object")) return FieldValueType.Object;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FieldValueType value.");
        }
    }
}
