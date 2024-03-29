// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class PhoneticEncoderExtensions
    {
        public static string ToSerialString(this PhoneticEncoder value) => value switch
        {
            PhoneticEncoder.Metaphone => "metaphone",
            PhoneticEncoder.DoubleMetaphone => "doubleMetaphone",
            PhoneticEncoder.Soundex => "soundex",
            PhoneticEncoder.RefinedSoundex => "refinedSoundex",
            PhoneticEncoder.Caverphone1 => "caverphone1",
            PhoneticEncoder.Caverphone2 => "caverphone2",
            PhoneticEncoder.Cologne => "cologne",
            PhoneticEncoder.Nysiis => "nysiis",
            PhoneticEncoder.KoelnerPhonetik => "koelnerPhonetik",
            PhoneticEncoder.HaasePhonetik => "haasePhonetik",
            PhoneticEncoder.BeiderMorse => "beiderMorse",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PhoneticEncoder value.")
        };

        public static PhoneticEncoder ToPhoneticEncoder(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "metaphone")) return PhoneticEncoder.Metaphone;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "doubleMetaphone")) return PhoneticEncoder.DoubleMetaphone;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "soundex")) return PhoneticEncoder.Soundex;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "refinedSoundex")) return PhoneticEncoder.RefinedSoundex;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "caverphone1")) return PhoneticEncoder.Caverphone1;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "caverphone2")) return PhoneticEncoder.Caverphone2;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "cologne")) return PhoneticEncoder.Cologne;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "nysiis")) return PhoneticEncoder.Nysiis;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "koelnerPhonetik")) return PhoneticEncoder.KoelnerPhonetik;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "haasePhonetik")) return PhoneticEncoder.HaasePhonetik;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "beiderMorse")) return PhoneticEncoder.BeiderMorse;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PhoneticEncoder value.");
        }
    }
}
