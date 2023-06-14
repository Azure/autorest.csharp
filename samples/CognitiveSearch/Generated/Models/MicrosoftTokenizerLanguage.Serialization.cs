// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class MicrosoftTokenizerLanguageExtensions
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

        public static MicrosoftTokenizerLanguage ToMicrosoftTokenizerLanguage(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "bangla")) return MicrosoftTokenizerLanguage.Bangla;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "bulgarian")) return MicrosoftTokenizerLanguage.Bulgarian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "catalan")) return MicrosoftTokenizerLanguage.Catalan;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "chineseSimplified")) return MicrosoftTokenizerLanguage.ChineseSimplified;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "chineseTraditional")) return MicrosoftTokenizerLanguage.ChineseTraditional;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "croatian")) return MicrosoftTokenizerLanguage.Croatian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "czech")) return MicrosoftTokenizerLanguage.Czech;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "danish")) return MicrosoftTokenizerLanguage.Danish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "dutch")) return MicrosoftTokenizerLanguage.Dutch;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "english")) return MicrosoftTokenizerLanguage.English;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "french")) return MicrosoftTokenizerLanguage.French;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "german")) return MicrosoftTokenizerLanguage.German;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "greek")) return MicrosoftTokenizerLanguage.Greek;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "gujarati")) return MicrosoftTokenizerLanguage.Gujarati;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "hindi")) return MicrosoftTokenizerLanguage.Hindi;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "icelandic")) return MicrosoftTokenizerLanguage.Icelandic;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "indonesian")) return MicrosoftTokenizerLanguage.Indonesian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "italian")) return MicrosoftTokenizerLanguage.Italian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "japanese")) return MicrosoftTokenizerLanguage.Japanese;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "kannada")) return MicrosoftTokenizerLanguage.Kannada;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "korean")) return MicrosoftTokenizerLanguage.Korean;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "malay")) return MicrosoftTokenizerLanguage.Malay;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "malayalam")) return MicrosoftTokenizerLanguage.Malayalam;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "marathi")) return MicrosoftTokenizerLanguage.Marathi;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "norwegianBokmaal")) return MicrosoftTokenizerLanguage.NorwegianBokmaal;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "polish")) return MicrosoftTokenizerLanguage.Polish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "portuguese")) return MicrosoftTokenizerLanguage.Portuguese;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "portugueseBrazilian")) return MicrosoftTokenizerLanguage.PortugueseBrazilian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "punjabi")) return MicrosoftTokenizerLanguage.Punjabi;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "romanian")) return MicrosoftTokenizerLanguage.Romanian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "russian")) return MicrosoftTokenizerLanguage.Russian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "serbianCyrillic")) return MicrosoftTokenizerLanguage.SerbianCyrillic;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "serbianLatin")) return MicrosoftTokenizerLanguage.SerbianLatin;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "slovenian")) return MicrosoftTokenizerLanguage.Slovenian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "spanish")) return MicrosoftTokenizerLanguage.Spanish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "swedish")) return MicrosoftTokenizerLanguage.Swedish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "tamil")) return MicrosoftTokenizerLanguage.Tamil;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "telugu")) return MicrosoftTokenizerLanguage.Telugu;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "thai")) return MicrosoftTokenizerLanguage.Thai;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ukrainian")) return MicrosoftTokenizerLanguage.Ukrainian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "urdu")) return MicrosoftTokenizerLanguage.Urdu;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "vietnamese")) return MicrosoftTokenizerLanguage.Vietnamese;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MicrosoftTokenizerLanguage value.");
        }
    }
}
