// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtExpandResourceTypes.Models
{
    internal static partial class RecordTypeExtensions
    {
        public static string ToSerialString(this RecordType value) => value switch
        {
            RecordType.A => "A",
            RecordType.Aaaa => "AAAA",
            RecordType.CAA => "CAA",
            RecordType.Cname => "CNAME",
            RecordType.MX => "MX",
            RecordType.NS => "NS",
            RecordType.PTR => "PTR",
            RecordType.SOA => "SOA",
            RecordType.SRV => "SRV",
            RecordType.TXT => "TXT",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RecordType value.")
        };

        public static RecordType ToRecordType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "A")) return RecordType.A;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AAAA")) return RecordType.Aaaa;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "CAA")) return RecordType.CAA;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "CNAME")) return RecordType.Cname;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "MX")) return RecordType.MX;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "NS")) return RecordType.NS;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "PTR")) return RecordType.PTR;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "SOA")) return RecordType.SOA;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "SRV")) return RecordType.SRV;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "TXT")) return RecordType.TXT;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RecordType value.");
        }
    }
}
