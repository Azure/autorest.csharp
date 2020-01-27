// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static class MicrosoftTokenizerLanguageExtensions
    {
        public static string ToSerialString(this MicrosoftTokenizerLanguage value) => value switch
        {
            MicrosoftTokenizerLanguage.Bangla => "bangla",
            MicrosoftTokenizerLanguage.Bulgarian => "bulgarian",
            MicrosoftTokenizerLanguage.Catalan => "catalan",
            MicrosoftTokenizerLanguage.ChineseSimplified => "chineseSimplified",
            MicrosoftTokenizerLanguage.ChineseTraditional => "chineseTraditional",
            MicrosoftTokenizerLanguage.Croatian => "croatian",
            MicrosoftTokenizerLanguage.Czech => "czech",
            MicrosoftTokenizerLanguage.Danish => "danish",
            MicrosoftTokenizerLanguage.Dutch => "dutch",
            MicrosoftTokenizerLanguage.English => "english",
            MicrosoftTokenizerLanguage.French => "french",
            MicrosoftTokenizerLanguage.German => "german",
            MicrosoftTokenizerLanguage.Greek => "greek",
            MicrosoftTokenizerLanguage.Gujarati => "gujarati",
            MicrosoftTokenizerLanguage.Hindi => "hindi",
            MicrosoftTokenizerLanguage.Icelandic => "icelandic",
            MicrosoftTokenizerLanguage.Indonesian => "indonesian",
            MicrosoftTokenizerLanguage.Italian => "italian",
            MicrosoftTokenizerLanguage.Japanese => "japanese",
            MicrosoftTokenizerLanguage.Kannada => "kannada",
            MicrosoftTokenizerLanguage.Korean => "korean",
            MicrosoftTokenizerLanguage.Malay => "malay",
            MicrosoftTokenizerLanguage.Malayalam => "malayalam",
            MicrosoftTokenizerLanguage.Marathi => "marathi",
            MicrosoftTokenizerLanguage.NorwegianBokmaal => "norwegianBokmaal",
            MicrosoftTokenizerLanguage.Polish => "polish",
            MicrosoftTokenizerLanguage.Portuguese => "portuguese",
            MicrosoftTokenizerLanguage.PortugueseBrazilian => "portugueseBrazilian",
            MicrosoftTokenizerLanguage.Punjabi => "punjabi",
            MicrosoftTokenizerLanguage.Romanian => "romanian",
            MicrosoftTokenizerLanguage.Russian => "russian",
            MicrosoftTokenizerLanguage.SerbianCyrillic => "serbianCyrillic",
            MicrosoftTokenizerLanguage.SerbianLatin => "serbianLatin",
            MicrosoftTokenizerLanguage.Slovenian => "slovenian",
            MicrosoftTokenizerLanguage.Spanish => "spanish",
            MicrosoftTokenizerLanguage.Swedish => "swedish",
            MicrosoftTokenizerLanguage.Tamil => "tamil",
            MicrosoftTokenizerLanguage.Telugu => "telugu",
            MicrosoftTokenizerLanguage.Thai => "thai",
            MicrosoftTokenizerLanguage.Ukrainian => "ukrainian",
            MicrosoftTokenizerLanguage.Urdu => "urdu",
            MicrosoftTokenizerLanguage.Vietnamese => "vietnamese",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MicrosoftTokenizerLanguage value.")
        };

        public static MicrosoftTokenizerLanguage ToMicrosoftTokenizerLanguage(this string value) => value switch
        {
            "bangla" => MicrosoftTokenizerLanguage.Bangla,
            "bulgarian" => MicrosoftTokenizerLanguage.Bulgarian,
            "catalan" => MicrosoftTokenizerLanguage.Catalan,
            "chineseSimplified" => MicrosoftTokenizerLanguage.ChineseSimplified,
            "chineseTraditional" => MicrosoftTokenizerLanguage.ChineseTraditional,
            "croatian" => MicrosoftTokenizerLanguage.Croatian,
            "czech" => MicrosoftTokenizerLanguage.Czech,
            "danish" => MicrosoftTokenizerLanguage.Danish,
            "dutch" => MicrosoftTokenizerLanguage.Dutch,
            "english" => MicrosoftTokenizerLanguage.English,
            "french" => MicrosoftTokenizerLanguage.French,
            "german" => MicrosoftTokenizerLanguage.German,
            "greek" => MicrosoftTokenizerLanguage.Greek,
            "gujarati" => MicrosoftTokenizerLanguage.Gujarati,
            "hindi" => MicrosoftTokenizerLanguage.Hindi,
            "icelandic" => MicrosoftTokenizerLanguage.Icelandic,
            "indonesian" => MicrosoftTokenizerLanguage.Indonesian,
            "italian" => MicrosoftTokenizerLanguage.Italian,
            "japanese" => MicrosoftTokenizerLanguage.Japanese,
            "kannada" => MicrosoftTokenizerLanguage.Kannada,
            "korean" => MicrosoftTokenizerLanguage.Korean,
            "malay" => MicrosoftTokenizerLanguage.Malay,
            "malayalam" => MicrosoftTokenizerLanguage.Malayalam,
            "marathi" => MicrosoftTokenizerLanguage.Marathi,
            "norwegianBokmaal" => MicrosoftTokenizerLanguage.NorwegianBokmaal,
            "polish" => MicrosoftTokenizerLanguage.Polish,
            "portuguese" => MicrosoftTokenizerLanguage.Portuguese,
            "portugueseBrazilian" => MicrosoftTokenizerLanguage.PortugueseBrazilian,
            "punjabi" => MicrosoftTokenizerLanguage.Punjabi,
            "romanian" => MicrosoftTokenizerLanguage.Romanian,
            "russian" => MicrosoftTokenizerLanguage.Russian,
            "serbianCyrillic" => MicrosoftTokenizerLanguage.SerbianCyrillic,
            "serbianLatin" => MicrosoftTokenizerLanguage.SerbianLatin,
            "slovenian" => MicrosoftTokenizerLanguage.Slovenian,
            "spanish" => MicrosoftTokenizerLanguage.Spanish,
            "swedish" => MicrosoftTokenizerLanguage.Swedish,
            "tamil" => MicrosoftTokenizerLanguage.Tamil,
            "telugu" => MicrosoftTokenizerLanguage.Telugu,
            "thai" => MicrosoftTokenizerLanguage.Thai,
            "ukrainian" => MicrosoftTokenizerLanguage.Ukrainian,
            "urdu" => MicrosoftTokenizerLanguage.Urdu,
            "vietnamese" => MicrosoftTokenizerLanguage.Vietnamese,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MicrosoftTokenizerLanguage value.")
        };
    }
}
