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
    /// <summary> Decomposes compound words found in many Germanic languages. This token filter is implemented using Apache Lucene. </summary>
    public partial class DictionaryDecompounderTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of <see cref="DictionaryDecompounderTokenFilter"/>. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="wordList"> The list of words to match against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="wordList"/> is null. </exception>
        public DictionaryDecompounderTokenFilter(string name, IEnumerable<string> wordList) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(wordList, nameof(wordList));

            WordList = wordList.ToList();
            OdataType = "#Microsoft.Azure.Search.DictionaryDecompounderTokenFilter";
        }

        /// <summary> Initializes a new instance of <see cref="DictionaryDecompounderTokenFilter"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="wordList"> The list of words to match against. </param>
        /// <param name="minWordSize"> The minimum word size. Only words longer than this get processed. Default is 5. Maximum is 300. </param>
        /// <param name="minSubwordSize"> The minimum subword size. Only subwords longer than this are outputted. Default is 2. Maximum is 300. </param>
        /// <param name="maxSubwordSize"> The maximum subword size. Only subwords shorter than this are outputted. Default is 15. Maximum is 300. </param>
        /// <param name="onlyLongestMatch"> A value indicating whether to add only the longest matching subword to the output. Default is false. </param>
        internal DictionaryDecompounderTokenFilter(string odataType, string name, IDictionary<string, BinaryData> serializedAdditionalRawData, IList<string> wordList, int? minWordSize, int? minSubwordSize, int? maxSubwordSize, bool? onlyLongestMatch) : base(odataType, name, serializedAdditionalRawData)
        {
            WordList = wordList;
            MinWordSize = minWordSize;
            MinSubwordSize = minSubwordSize;
            MaxSubwordSize = maxSubwordSize;
            OnlyLongestMatch = onlyLongestMatch;
            OdataType = odataType ?? "#Microsoft.Azure.Search.DictionaryDecompounderTokenFilter";
        }

        /// <summary> Initializes a new instance of <see cref="DictionaryDecompounderTokenFilter"/> for deserialization. </summary>
        internal DictionaryDecompounderTokenFilter()
        {
        }

        /// <summary> The list of words to match against. </summary>
        public IList<string> WordList { get; }
        /// <summary> The minimum word size. Only words longer than this get processed. Default is 5. Maximum is 300. </summary>
        public int? MinWordSize { get; set; }
        /// <summary> The minimum subword size. Only subwords longer than this are outputted. Default is 2. Maximum is 300. </summary>
        public int? MinSubwordSize { get; set; }
        /// <summary> The maximum subword size. Only subwords shorter than this are outputted. Default is 15. Maximum is 300. </summary>
        public int? MaxSubwordSize { get; set; }
        /// <summary> A value indicating whether to add only the longest matching subword to the output. Default is false. </summary>
        public bool? OnlyLongestMatch { get; set; }
    }
}
