// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class StemmerTokenFilterLanguageExtensions
    {
        public static string ToSerialString(this StemmerTokenFilterLanguage value) => value switch
        {
            StemmerTokenFilterLanguage.Arabic => "arabic",
            StemmerTokenFilterLanguage.Armenian => "armenian",
            StemmerTokenFilterLanguage.Basque => "basque",
            StemmerTokenFilterLanguage.Brazilian => "brazilian",
            StemmerTokenFilterLanguage.Bulgarian => "bulgarian",
            StemmerTokenFilterLanguage.Catalan => "catalan",
            StemmerTokenFilterLanguage.Czech => "czech",
            StemmerTokenFilterLanguage.Danish => "danish",
            StemmerTokenFilterLanguage.Dutch => "dutch",
            StemmerTokenFilterLanguage.DutchKp => "dutchKp",
            StemmerTokenFilterLanguage.English => "english",
            StemmerTokenFilterLanguage.LightEnglish => "lightEnglish",
            StemmerTokenFilterLanguage.MinimalEnglish => "minimalEnglish",
            StemmerTokenFilterLanguage.PossessiveEnglish => "possessiveEnglish",
            StemmerTokenFilterLanguage.Porter2 => "porter2",
            StemmerTokenFilterLanguage.Lovins => "lovins",
            StemmerTokenFilterLanguage.Finnish => "finnish",
            StemmerTokenFilterLanguage.LightFinnish => "lightFinnish",
            StemmerTokenFilterLanguage.French => "french",
            StemmerTokenFilterLanguage.LightFrench => "lightFrench",
            StemmerTokenFilterLanguage.MinimalFrench => "minimalFrench",
            StemmerTokenFilterLanguage.Galician => "galician",
            StemmerTokenFilterLanguage.MinimalGalician => "minimalGalician",
            StemmerTokenFilterLanguage.German => "german",
            StemmerTokenFilterLanguage.German2 => "german2",
            StemmerTokenFilterLanguage.LightGerman => "lightGerman",
            StemmerTokenFilterLanguage.MinimalGerman => "minimalGerman",
            StemmerTokenFilterLanguage.Greek => "greek",
            StemmerTokenFilterLanguage.Hindi => "hindi",
            StemmerTokenFilterLanguage.Hungarian => "hungarian",
            StemmerTokenFilterLanguage.LightHungarian => "lightHungarian",
            StemmerTokenFilterLanguage.Indonesian => "indonesian",
            StemmerTokenFilterLanguage.Irish => "irish",
            StemmerTokenFilterLanguage.Italian => "italian",
            StemmerTokenFilterLanguage.LightItalian => "lightItalian",
            StemmerTokenFilterLanguage.Sorani => "sorani",
            StemmerTokenFilterLanguage.Latvian => "latvian",
            StemmerTokenFilterLanguage.Norwegian => "norwegian",
            StemmerTokenFilterLanguage.LightNorwegian => "lightNorwegian",
            StemmerTokenFilterLanguage.MinimalNorwegian => "minimalNorwegian",
            StemmerTokenFilterLanguage.LightNynorsk => "lightNynorsk",
            StemmerTokenFilterLanguage.MinimalNynorsk => "minimalNynorsk",
            StemmerTokenFilterLanguage.Portuguese => "portuguese",
            StemmerTokenFilterLanguage.LightPortuguese => "lightPortuguese",
            StemmerTokenFilterLanguage.MinimalPortuguese => "minimalPortuguese",
            StemmerTokenFilterLanguage.PortugueseRslp => "portugueseRslp",
            StemmerTokenFilterLanguage.Romanian => "romanian",
            StemmerTokenFilterLanguage.Russian => "russian",
            StemmerTokenFilterLanguage.LightRussian => "lightRussian",
            StemmerTokenFilterLanguage.Spanish => "spanish",
            StemmerTokenFilterLanguage.LightSpanish => "lightSpanish",
            StemmerTokenFilterLanguage.Swedish => "swedish",
            StemmerTokenFilterLanguage.LightSwedish => "lightSwedish",
            StemmerTokenFilterLanguage.Turkish => "turkish",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StemmerTokenFilterLanguage value.")
        };

        public static StemmerTokenFilterLanguage ToStemmerTokenFilterLanguage(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "arabic")) return StemmerTokenFilterLanguage.Arabic;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "armenian")) return StemmerTokenFilterLanguage.Armenian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "basque")) return StemmerTokenFilterLanguage.Basque;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "brazilian")) return StemmerTokenFilterLanguage.Brazilian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "bulgarian")) return StemmerTokenFilterLanguage.Bulgarian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "catalan")) return StemmerTokenFilterLanguage.Catalan;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "czech")) return StemmerTokenFilterLanguage.Czech;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "danish")) return StemmerTokenFilterLanguage.Danish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "dutch")) return StemmerTokenFilterLanguage.Dutch;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "dutchKp")) return StemmerTokenFilterLanguage.DutchKp;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "english")) return StemmerTokenFilterLanguage.English;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lightEnglish")) return StemmerTokenFilterLanguage.LightEnglish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "minimalEnglish")) return StemmerTokenFilterLanguage.MinimalEnglish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "possessiveEnglish")) return StemmerTokenFilterLanguage.PossessiveEnglish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "porter2")) return StemmerTokenFilterLanguage.Porter2;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lovins")) return StemmerTokenFilterLanguage.Lovins;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "finnish")) return StemmerTokenFilterLanguage.Finnish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lightFinnish")) return StemmerTokenFilterLanguage.LightFinnish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "french")) return StemmerTokenFilterLanguage.French;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lightFrench")) return StemmerTokenFilterLanguage.LightFrench;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "minimalFrench")) return StemmerTokenFilterLanguage.MinimalFrench;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "galician")) return StemmerTokenFilterLanguage.Galician;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "minimalGalician")) return StemmerTokenFilterLanguage.MinimalGalician;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "german")) return StemmerTokenFilterLanguage.German;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "german2")) return StemmerTokenFilterLanguage.German2;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lightGerman")) return StemmerTokenFilterLanguage.LightGerman;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "minimalGerman")) return StemmerTokenFilterLanguage.MinimalGerman;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "greek")) return StemmerTokenFilterLanguage.Greek;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "hindi")) return StemmerTokenFilterLanguage.Hindi;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "hungarian")) return StemmerTokenFilterLanguage.Hungarian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lightHungarian")) return StemmerTokenFilterLanguage.LightHungarian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "indonesian")) return StemmerTokenFilterLanguage.Indonesian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "irish")) return StemmerTokenFilterLanguage.Irish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "italian")) return StemmerTokenFilterLanguage.Italian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lightItalian")) return StemmerTokenFilterLanguage.LightItalian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "sorani")) return StemmerTokenFilterLanguage.Sorani;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "latvian")) return StemmerTokenFilterLanguage.Latvian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "norwegian")) return StemmerTokenFilterLanguage.Norwegian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lightNorwegian")) return StemmerTokenFilterLanguage.LightNorwegian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "minimalNorwegian")) return StemmerTokenFilterLanguage.MinimalNorwegian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lightNynorsk")) return StemmerTokenFilterLanguage.LightNynorsk;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "minimalNynorsk")) return StemmerTokenFilterLanguage.MinimalNynorsk;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "portuguese")) return StemmerTokenFilterLanguage.Portuguese;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lightPortuguese")) return StemmerTokenFilterLanguage.LightPortuguese;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "minimalPortuguese")) return StemmerTokenFilterLanguage.MinimalPortuguese;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "portugueseRslp")) return StemmerTokenFilterLanguage.PortugueseRslp;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "romanian")) return StemmerTokenFilterLanguage.Romanian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "russian")) return StemmerTokenFilterLanguage.Russian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lightRussian")) return StemmerTokenFilterLanguage.LightRussian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "spanish")) return StemmerTokenFilterLanguage.Spanish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lightSpanish")) return StemmerTokenFilterLanguage.LightSpanish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "swedish")) return StemmerTokenFilterLanguage.Swedish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lightSwedish")) return StemmerTokenFilterLanguage.LightSwedish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "turkish")) return StemmerTokenFilterLanguage.Turkish;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StemmerTokenFilterLanguage value.");
        }
    }
}
