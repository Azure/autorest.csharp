// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static class PhoneticEncoderExtensions
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

        public static PhoneticEncoder ToPhoneticEncoder(this string value) => value switch
        {
            "metaphone" => PhoneticEncoder.Metaphone,
            "doubleMetaphone" => PhoneticEncoder.DoubleMetaphone,
            "soundex" => PhoneticEncoder.Soundex,
            "refinedSoundex" => PhoneticEncoder.RefinedSoundex,
            "caverphone1" => PhoneticEncoder.Caverphone1,
            "caverphone2" => PhoneticEncoder.Caverphone2,
            "cologne" => PhoneticEncoder.Cologne,
            "nysiis" => PhoneticEncoder.Nysiis,
            "koelnerPhonetik" => PhoneticEncoder.KoelnerPhonetik,
            "haasePhonetik" => PhoneticEncoder.HaasePhonetik,
            "beiderMorse" => PhoneticEncoder.BeiderMorse,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PhoneticEncoder value.")
        };
    }
}
