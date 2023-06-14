// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class MicrosoftStemmingTokenizerLanguageExtensions
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

        public static MicrosoftStemmingTokenizerLanguage ToMicrosoftStemmingTokenizerLanguage(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "arabic")) return MicrosoftStemmingTokenizerLanguage.Arabic;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "bangla")) return MicrosoftStemmingTokenizerLanguage.Bangla;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "bulgarian")) return MicrosoftStemmingTokenizerLanguage.Bulgarian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "catalan")) return MicrosoftStemmingTokenizerLanguage.Catalan;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "croatian")) return MicrosoftStemmingTokenizerLanguage.Croatian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "czech")) return MicrosoftStemmingTokenizerLanguage.Czech;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "danish")) return MicrosoftStemmingTokenizerLanguage.Danish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "dutch")) return MicrosoftStemmingTokenizerLanguage.Dutch;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "english")) return MicrosoftStemmingTokenizerLanguage.English;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "estonian")) return MicrosoftStemmingTokenizerLanguage.Estonian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "finnish")) return MicrosoftStemmingTokenizerLanguage.Finnish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "french")) return MicrosoftStemmingTokenizerLanguage.French;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "german")) return MicrosoftStemmingTokenizerLanguage.German;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "greek")) return MicrosoftStemmingTokenizerLanguage.Greek;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "gujarati")) return MicrosoftStemmingTokenizerLanguage.Gujarati;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "hebrew")) return MicrosoftStemmingTokenizerLanguage.Hebrew;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "hindi")) return MicrosoftStemmingTokenizerLanguage.Hindi;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "hungarian")) return MicrosoftStemmingTokenizerLanguage.Hungarian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "icelandic")) return MicrosoftStemmingTokenizerLanguage.Icelandic;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "indonesian")) return MicrosoftStemmingTokenizerLanguage.Indonesian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "italian")) return MicrosoftStemmingTokenizerLanguage.Italian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "kannada")) return MicrosoftStemmingTokenizerLanguage.Kannada;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "latvian")) return MicrosoftStemmingTokenizerLanguage.Latvian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lithuanian")) return MicrosoftStemmingTokenizerLanguage.Lithuanian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "malay")) return MicrosoftStemmingTokenizerLanguage.Malay;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "malayalam")) return MicrosoftStemmingTokenizerLanguage.Malayalam;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "marathi")) return MicrosoftStemmingTokenizerLanguage.Marathi;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "norwegianBokmaal")) return MicrosoftStemmingTokenizerLanguage.NorwegianBokmaal;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "polish")) return MicrosoftStemmingTokenizerLanguage.Polish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "portuguese")) return MicrosoftStemmingTokenizerLanguage.Portuguese;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "portugueseBrazilian")) return MicrosoftStemmingTokenizerLanguage.PortugueseBrazilian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "punjabi")) return MicrosoftStemmingTokenizerLanguage.Punjabi;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "romanian")) return MicrosoftStemmingTokenizerLanguage.Romanian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "russian")) return MicrosoftStemmingTokenizerLanguage.Russian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "serbianCyrillic")) return MicrosoftStemmingTokenizerLanguage.SerbianCyrillic;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "serbianLatin")) return MicrosoftStemmingTokenizerLanguage.SerbianLatin;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "slovak")) return MicrosoftStemmingTokenizerLanguage.Slovak;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "slovenian")) return MicrosoftStemmingTokenizerLanguage.Slovenian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "spanish")) return MicrosoftStemmingTokenizerLanguage.Spanish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "swedish")) return MicrosoftStemmingTokenizerLanguage.Swedish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "tamil")) return MicrosoftStemmingTokenizerLanguage.Tamil;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "telugu")) return MicrosoftStemmingTokenizerLanguage.Telugu;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "turkish")) return MicrosoftStemmingTokenizerLanguage.Turkish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ukrainian")) return MicrosoftStemmingTokenizerLanguage.Ukrainian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "urdu")) return MicrosoftStemmingTokenizerLanguage.Urdu;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MicrosoftStemmingTokenizerLanguage value.");
        }
    }
}
