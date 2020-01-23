// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Represents classes of characters on which a token filter can operate. </summary>
    public enum TokenCharacterKind
    {
        /// <summary> letter. </summary>
        Letter,
        /// <summary> digit. </summary>
        Digit,
        /// <summary> whitespace. </summary>
        Whitespace,
        /// <summary> punctuation. </summary>
        Punctuation,
        /// <summary> symbol. </summary>
        Symbol
    }
}
