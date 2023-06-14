// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class StopwordsListExtensions
    {
        public static string ToSerialString(this StopwordsList value) => value switch
        {
            StopwordsList.Arabic => "arabic",
            StopwordsList.Armenian => "armenian",
            StopwordsList.Basque => "basque",
            StopwordsList.Brazilian => "brazilian",
            StopwordsList.Bulgarian => "bulgarian",
            StopwordsList.Catalan => "catalan",
            StopwordsList.Czech => "czech",
            StopwordsList.Danish => "danish",
            StopwordsList.Dutch => "dutch",
            StopwordsList.English => "english",
            StopwordsList.Finnish => "finnish",
            StopwordsList.French => "french",
            StopwordsList.Galician => "galician",
            StopwordsList.German => "german",
            StopwordsList.Greek => "greek",
            StopwordsList.Hindi => "hindi",
            StopwordsList.Hungarian => "hungarian",
            StopwordsList.Indonesian => "indonesian",
            StopwordsList.Irish => "irish",
            StopwordsList.Italian => "italian",
            StopwordsList.Latvian => "latvian",
            StopwordsList.Norwegian => "norwegian",
            StopwordsList.Persian => "persian",
            StopwordsList.Portuguese => "portuguese",
            StopwordsList.Romanian => "romanian",
            StopwordsList.Russian => "russian",
            StopwordsList.Sorani => "sorani",
            StopwordsList.Spanish => "spanish",
            StopwordsList.Swedish => "swedish",
            StopwordsList.Thai => "thai",
            StopwordsList.Turkish => "turkish",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StopwordsList value.")
        };

        public static StopwordsList ToStopwordsList(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "arabic")) return StopwordsList.Arabic;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "armenian")) return StopwordsList.Armenian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "basque")) return StopwordsList.Basque;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "brazilian")) return StopwordsList.Brazilian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "bulgarian")) return StopwordsList.Bulgarian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "catalan")) return StopwordsList.Catalan;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "czech")) return StopwordsList.Czech;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "danish")) return StopwordsList.Danish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "dutch")) return StopwordsList.Dutch;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "english")) return StopwordsList.English;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "finnish")) return StopwordsList.Finnish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "french")) return StopwordsList.French;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "galician")) return StopwordsList.Galician;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "german")) return StopwordsList.German;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "greek")) return StopwordsList.Greek;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "hindi")) return StopwordsList.Hindi;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "hungarian")) return StopwordsList.Hungarian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "indonesian")) return StopwordsList.Indonesian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "irish")) return StopwordsList.Irish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "italian")) return StopwordsList.Italian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "latvian")) return StopwordsList.Latvian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "norwegian")) return StopwordsList.Norwegian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "persian")) return StopwordsList.Persian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "portuguese")) return StopwordsList.Portuguese;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "romanian")) return StopwordsList.Romanian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "russian")) return StopwordsList.Russian;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "sorani")) return StopwordsList.Sorani;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "spanish")) return StopwordsList.Spanish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "swedish")) return StopwordsList.Swedish;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "thai")) return StopwordsList.Thai;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "turkish")) return StopwordsList.Turkish;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StopwordsList value.");
        }
    }
}
