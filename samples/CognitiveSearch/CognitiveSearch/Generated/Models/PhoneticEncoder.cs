// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Identifies the type of phonetic encoder to use with a PhoneticTokenFilter. </summary>
    public enum PhoneticEncoder
    {
        /// <summary> The value &apos;undefined&apos;. </summary>
        Metaphone,
        /// <summary> The value &apos;undefined&apos;. </summary>
        DoubleMetaphone,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Soundex,
        /// <summary> The value &apos;undefined&apos;. </summary>
        RefinedSoundex,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Caverphone1,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Caverphone2,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Cologne,
        /// <summary> The value &apos;undefined&apos;. </summary>
        Nysiis,
        /// <summary> The value &apos;undefined&apos;. </summary>
        KoelnerPhonetik,
        /// <summary> The value &apos;undefined&apos;. </summary>
        HaasePhonetik,
        /// <summary> The value &apos;undefined&apos;. </summary>
        BeiderMorse
    }
}
