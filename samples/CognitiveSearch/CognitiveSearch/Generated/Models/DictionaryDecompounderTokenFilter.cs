// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Decomposes compound words found in many Germanic languages. This token filter is implemented using Apache Lucene. </summary>
    public partial class DictionaryDecompounderTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of DictionaryDecompounderTokenFilter. </summary>
        public DictionaryDecompounderTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.DictionaryDecompounderTokenFilter";
        }
        /// <summary> The list of words to match against. </summary>
        public ICollection<string> WordList { get; set; } = new List<string>();
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
