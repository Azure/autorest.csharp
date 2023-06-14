// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Information about a token returned by an analyzer. </summary>
    public partial class TokenInfo
    {
        /// <summary> Initializes a new instance of TokenInfo. </summary>
        /// <param name="token"> The token returned by the analyzer. </param>
        /// <param name="startOffset"> The index of the first character of the token in the input text. </param>
        /// <param name="endOffset"> The index of the last character of the token in the input text. </param>
        /// <param name="position"> The position of the token in the input text relative to other tokens. The first token in the input text has position 0, the next has position 1, and so on. Depending on the analyzer used, some tokens might have the same position, for example if they are synonyms of each other. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="token"/> is null. </exception>
        internal TokenInfo(string token, int startOffset, int endOffset, int position)
        {
            Argument.AssertNotNull(token, nameof(token));

            Token = token;
            StartOffset = startOffset;
            EndOffset = endOffset;
            Position = position;
        }

        /// <summary> The token returned by the analyzer. </summary>
        public string Token { get; }
        /// <summary> The index of the first character of the token in the input text. </summary>
        public int StartOffset { get; }
        /// <summary> The index of the last character of the token in the input text. </summary>
        public int EndOffset { get; }
        /// <summary> The position of the token in the input text relative to other tokens. The first token in the input text has position 0, the next has position 1, and so on. Depending on the analyzer used, some tokens might have the same position, for example if they are synonyms of each other. </summary>
        public int Position { get; }
    }
}
