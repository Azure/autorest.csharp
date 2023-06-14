// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class SnowballTokenFilterLanguageExtensions
    {
        public static string ToSerialString(this SnowballTokenFilterLanguage value) => value switch
        {
            SnowballTokenFilterLanguage.Armenian => "armenian",
            SnowballTokenFilterLanguage.Basque => "basque",
            SnowballTokenFilterLanguage.Catalan => "catalan",
            SnowballTokenFilterLanguage.Danish => "danish",
            SnowballTokenFilterLanguage.Dutch => "dutch",
            SnowballTokenFilterLanguage.English => "english",
            SnowballTokenFilterLanguage.Finnish => "finnish",
            SnowballTokenFilterLanguage.French => "french",
            SnowballTokenFilterLanguage.German => "german",
            SnowballTokenFilterLanguage.German2 => "german2",
            SnowballTokenFilterLanguage.Hungarian => "hungarian",
            SnowballTokenFilterLanguage.Italian => "italian",
            SnowballTokenFilterLanguage.Kp => "kp",
            SnowballTokenFilterLanguage.Lovins => "lovins",
            SnowballTokenFilterLanguage.Norwegian => "norwegian",
            SnowballTokenFilterLanguage.Porter => "porter",
            SnowballTokenFilterLanguage.Portuguese => "portuguese",
            SnowballTokenFilterLanguage.Romanian => "romanian",
            SnowballTokenFilterLanguage.Russian => "russian",
            SnowballTokenFilterLanguage.Spanish => "spanish",
            SnowballTokenFilterLanguage.Swedish => "swedish",
            SnowballTokenFilterLanguage.Turkish => "turkish",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SnowballTokenFilterLanguage value.")
        };

        public static SnowballTokenFilterLanguage ToSnowballTokenFilterLanguage(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "armenian")) return SnowballTokenFilterLanguage.Armenian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "basque")) return SnowballTokenFilterLanguage.Basque;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "catalan")) return SnowballTokenFilterLanguage.Catalan;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "danish")) return SnowballTokenFilterLanguage.Danish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "dutch")) return SnowballTokenFilterLanguage.Dutch;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "english")) return SnowballTokenFilterLanguage.English;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "finnish")) return SnowballTokenFilterLanguage.Finnish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "french")) return SnowballTokenFilterLanguage.French;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "german")) return SnowballTokenFilterLanguage.German;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "german2")) return SnowballTokenFilterLanguage.German2;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "hungarian")) return SnowballTokenFilterLanguage.Hungarian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "italian")) return SnowballTokenFilterLanguage.Italian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "kp")) return SnowballTokenFilterLanguage.Kp;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "lovins")) return SnowballTokenFilterLanguage.Lovins;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "norwegian")) return SnowballTokenFilterLanguage.Norwegian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "porter")) return SnowballTokenFilterLanguage.Porter;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "portuguese")) return SnowballTokenFilterLanguage.Portuguese;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "romanian")) return SnowballTokenFilterLanguage.Romanian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "russian")) return SnowballTokenFilterLanguage.Russian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "spanish")) return SnowballTokenFilterLanguage.Spanish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "swedish")) return SnowballTokenFilterLanguage.Swedish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "turkish")) return SnowballTokenFilterLanguage.Turkish;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SnowballTokenFilterLanguage value.");
        }
    }
}
