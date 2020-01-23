// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Splits words into subwords and performs optional transformations on subword groups. This token filter is implemented using Apache Lucene. </summary>
    public partial class WordDelimiterTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of WordDelimiterTokenFilter. </summary>
        public WordDelimiterTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.WordDelimiterTokenFilter";
        }
        /// <summary> A value indicating whether to generate part words. If set, causes parts of words to be generated; for example &quot;AzureSearch&quot; becomes &quot;Azure&quot; &quot;Search&quot;. Default is true. </summary>
        public bool? GenerateWordParts { get; set; }
        /// <summary> A value indicating whether to generate number subwords. Default is true. </summary>
        public bool? GenerateNumberParts { get; set; }
        /// <summary> A value indicating whether maximum runs of word parts will be catenated. For example, if this is set to true, &quot;Azure-Search&quot; becomes &quot;AzureSearch&quot;. Default is false. </summary>
        public bool? CatenateWords { get; set; }
        /// <summary> A value indicating whether maximum runs of number parts will be catenated. For example, if this is set to true, &quot;1-2&quot; becomes &quot;12&quot;. Default is false. </summary>
        public bool? CatenateNumbers { get; set; }
        /// <summary> A value indicating whether all subword parts will be catenated. For example, if this is set to true, &quot;Azure-Search-1&quot; becomes &quot;AzureSearch1&quot;. Default is false. </summary>
        public bool? CatenateAll { get; set; }
        /// <summary> A value indicating whether to split words on caseChange. For example, if this is set to true, &quot;AzureSearch&quot; becomes &quot;Azure&quot; &quot;Search&quot;. Default is true. </summary>
        public bool? SplitOnCaseChange { get; set; }
        /// <summary> A value indicating whether original words will be preserved and added to the subword list. Default is false. </summary>
        public bool? PreserveOriginal { get; set; }
        /// <summary> A value indicating whether to split on numbers. For example, if this is set to true, &quot;Azure1Search&quot; becomes &quot;Azure&quot; &quot;1&quot; &quot;Search&quot;. Default is true. </summary>
        public bool? SplitOnNumerics { get; set; }
        /// <summary> A value indicating whether to remove trailing &quot;&apos;s&quot; for each subword. Default is true. </summary>
        public bool? StemEnglishPossessive { get; set; }
        /// <summary> A list of tokens to protect from being delimited. </summary>
        public ICollection<string>? ProtectedWords { get; set; }
    }
}
