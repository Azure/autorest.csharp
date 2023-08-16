// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> The result of testing an analyzer on text. </summary>
    public partial class AnalyzeResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.AnalyzeResult
        ///
        /// </summary>
        /// <param name="tokens"> The list of tokens returned by the analyzer specified in the request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tokens"/> is null. </exception>
        internal AnalyzeResult(IEnumerable<TokenInfo> tokens)
        {
            Argument.AssertNotNull(tokens, nameof(tokens));

            Tokens = tokens.ToList();
        }

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.AnalyzeResult
        ///
        /// </summary>
        /// <param name="tokens"> The list of tokens returned by the analyzer specified in the request. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal AnalyzeResult(IReadOnlyList<TokenInfo> tokens, Dictionary<string, BinaryData> rawData)
        {
            Tokens = tokens;
            _rawData = rawData;
        }

        /// <summary> The list of tokens returned by the analyzer specified in the request. </summary>
        public IReadOnlyList<TokenInfo> Tokens { get; }
    }
}
