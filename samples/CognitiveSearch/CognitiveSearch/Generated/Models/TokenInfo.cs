// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Information about a token returned by an analyzer. </summary>
    public partial class TokenInfo
    {
        /// <summary> The token returned by the analyzer. </summary>
        public string? Token { get; internal set; }
        /// <summary> The index of the first character of the token in the input text. </summary>
        public int? StartOffset { get; internal set; }
        /// <summary> The index of the last character of the token in the input text. </summary>
        public int? EndOffset { get; internal set; }
        /// <summary> The position of the token in the input text relative to other tokens. The first token in the input text has position 0, the next has position 1, and so on. Depending on the analyzer used, some tokens might have the same position, for example if they are synonyms of each other. </summary>
        public int? Position { get; internal set; }
    }
}
