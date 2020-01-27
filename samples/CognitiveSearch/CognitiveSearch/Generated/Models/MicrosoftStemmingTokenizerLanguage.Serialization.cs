// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static class MicrosoftStemmingTokenizerLanguageExtensions
    {
        public static string ToSerialString(this MicrosoftStemmingTokenizerLanguage value) => value switch
        {
            MicrosoftStemmingTokenizerLanguage.Arabic => "arabic",
            MicrosoftStemmingTokenizerLanguage.Bangla => "bangla",
            MicrosoftStemmingTokenizerLanguage.Bulgarian => "bulgarian",
            MicrosoftStemmingTokenizerLanguage.Catalan => "catalan",
            MicrosoftStemmingTokenizerLanguage.Croatian => "croatian",
            MicrosoftStemmingTokenizerLanguage.Czech => "czech",
            MicrosoftStemmingTokenizerLanguage.Danish => "danish",
            MicrosoftStemmingTokenizerLanguage.Dutch => "dutch",
            MicrosoftStemmingTokenizerLanguage.English => "english",
            MicrosoftStemmingTokenizerLanguage.Estonian => "estonian",
            MicrosoftStemmingTokenizerLanguage.Finnish => "finnish",
            MicrosoftStemmingTokenizerLanguage.French => "french",
            MicrosoftStemmingTokenizerLanguage.German => "german",
            MicrosoftStemmingTokenizerLanguage.Greek => "greek",
            MicrosoftStemmingTokenizerLanguage.Gujarati => "gujarati",
            MicrosoftStemmingTokenizerLanguage.Hebrew => "hebrew",
            MicrosoftStemmingTokenizerLanguage.Hindi => "hindi",
            MicrosoftStemmingTokenizerLanguage.Hungarian => "hungarian",
            MicrosoftStemmingTokenizerLanguage.Icelandic => "icelandic",
            MicrosoftStemmingTokenizerLanguage.Indonesian => "indonesian",
            MicrosoftStemmingTokenizerLanguage.Italian => "italian",
            MicrosoftStemmingTokenizerLanguage.Kannada => "kannada",
            MicrosoftStemmingTokenizerLanguage.Latvian => "latvian",
            MicrosoftStemmingTokenizerLanguage.Lithuanian => "lithuanian",
            MicrosoftStemmingTokenizerLanguage.Malay => "malay",
            MicrosoftStemmingTokenizerLanguage.Malayalam => "malayalam",
            MicrosoftStemmingTokenizerLanguage.Marathi => "marathi",
            MicrosoftStemmingTokenizerLanguage.NorwegianBokmaal => "norwegianBokmaal",
            MicrosoftStemmingTokenizerLanguage.Polish => "polish",
            MicrosoftStemmingTokenizerLanguage.Portuguese => "portuguese",
            MicrosoftStemmingTokenizerLanguage.PortugueseBrazilian => "portugueseBrazilian",
            MicrosoftStemmingTokenizerLanguage.Punjabi => "punjabi",
            MicrosoftStemmingTokenizerLanguage.Romanian => "romanian",
            MicrosoftStemmingTokenizerLanguage.Russian => "russian",
            MicrosoftStemmingTokenizerLanguage.SerbianCyrillic => "serbianCyrillic",
            MicrosoftStemmingTokenizerLanguage.SerbianLatin => "serbianLatin",
            MicrosoftStemmingTokenizerLanguage.Slovak => "slovak",
            MicrosoftStemmingTokenizerLanguage.Slovenian => "slovenian",
            MicrosoftStemmingTokenizerLanguage.Spanish => "spanish",
            MicrosoftStemmingTokenizerLanguage.Swedish => "swedish",
            MicrosoftStemmingTokenizerLanguage.Tamil => "tamil",
            MicrosoftStemmingTokenizerLanguage.Telugu => "telugu",
            MicrosoftStemmingTokenizerLanguage.Turkish => "turkish",
            MicrosoftStemmingTokenizerLanguage.Ukrainian => "ukrainian",
            MicrosoftStemmingTokenizerLanguage.Urdu => "urdu",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MicrosoftStemmingTokenizerLanguage value.")
        };

        public static MicrosoftStemmingTokenizerLanguage ToMicrosoftStemmingTokenizerLanguage(this string value) => value switch
        {
            "arabic" => MicrosoftStemmingTokenizerLanguage.Arabic,
            "bangla" => MicrosoftStemmingTokenizerLanguage.Bangla,
            "bulgarian" => MicrosoftStemmingTokenizerLanguage.Bulgarian,
            "catalan" => MicrosoftStemmingTokenizerLanguage.Catalan,
            "croatian" => MicrosoftStemmingTokenizerLanguage.Croatian,
            "czech" => MicrosoftStemmingTokenizerLanguage.Czech,
            "danish" => MicrosoftStemmingTokenizerLanguage.Danish,
            "dutch" => MicrosoftStemmingTokenizerLanguage.Dutch,
            "english" => MicrosoftStemmingTokenizerLanguage.English,
            "estonian" => MicrosoftStemmingTokenizerLanguage.Estonian,
            "finnish" => MicrosoftStemmingTokenizerLanguage.Finnish,
            "french" => MicrosoftStemmingTokenizerLanguage.French,
            "german" => MicrosoftStemmingTokenizerLanguage.German,
            "greek" => MicrosoftStemmingTokenizerLanguage.Greek,
            "gujarati" => MicrosoftStemmingTokenizerLanguage.Gujarati,
            "hebrew" => MicrosoftStemmingTokenizerLanguage.Hebrew,
            "hindi" => MicrosoftStemmingTokenizerLanguage.Hindi,
            "hungarian" => MicrosoftStemmingTokenizerLanguage.Hungarian,
            "icelandic" => MicrosoftStemmingTokenizerLanguage.Icelandic,
            "indonesian" => MicrosoftStemmingTokenizerLanguage.Indonesian,
            "italian" => MicrosoftStemmingTokenizerLanguage.Italian,
            "kannada" => MicrosoftStemmingTokenizerLanguage.Kannada,
            "latvian" => MicrosoftStemmingTokenizerLanguage.Latvian,
            "lithuanian" => MicrosoftStemmingTokenizerLanguage.Lithuanian,
            "malay" => MicrosoftStemmingTokenizerLanguage.Malay,
            "malayalam" => MicrosoftStemmingTokenizerLanguage.Malayalam,
            "marathi" => MicrosoftStemmingTokenizerLanguage.Marathi,
            "norwegianBokmaal" => MicrosoftStemmingTokenizerLanguage.NorwegianBokmaal,
            "polish" => MicrosoftStemmingTokenizerLanguage.Polish,
            "portuguese" => MicrosoftStemmingTokenizerLanguage.Portuguese,
            "portugueseBrazilian" => MicrosoftStemmingTokenizerLanguage.PortugueseBrazilian,
            "punjabi" => MicrosoftStemmingTokenizerLanguage.Punjabi,
            "romanian" => MicrosoftStemmingTokenizerLanguage.Romanian,
            "russian" => MicrosoftStemmingTokenizerLanguage.Russian,
            "serbianCyrillic" => MicrosoftStemmingTokenizerLanguage.SerbianCyrillic,
            "serbianLatin" => MicrosoftStemmingTokenizerLanguage.SerbianLatin,
            "slovak" => MicrosoftStemmingTokenizerLanguage.Slovak,
            "slovenian" => MicrosoftStemmingTokenizerLanguage.Slovenian,
            "spanish" => MicrosoftStemmingTokenizerLanguage.Spanish,
            "swedish" => MicrosoftStemmingTokenizerLanguage.Swedish,
            "tamil" => MicrosoftStemmingTokenizerLanguage.Tamil,
            "telugu" => MicrosoftStemmingTokenizerLanguage.Telugu,
            "turkish" => MicrosoftStemmingTokenizerLanguage.Turkish,
            "ukrainian" => MicrosoftStemmingTokenizerLanguage.Ukrainian,
            "urdu" => MicrosoftStemmingTokenizerLanguage.Urdu,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MicrosoftStemmingTokenizerLanguage value.")
        };
    }
}
