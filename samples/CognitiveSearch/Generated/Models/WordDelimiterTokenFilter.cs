// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Splits words into subwords and performs optional transformations on subword groups. This token filter is implemented using Apache Lucene. </summary>
    public partial class WordDelimiterTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of <see cref="WordDelimiterTokenFilter"/>. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public WordDelimiterTokenFilter(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            ProtectedWords = new ChangeTrackingList<string>();
            OdataType = "#Microsoft.Azure.Search.WordDelimiterTokenFilter";
        }

        /// <summary> Initializes a new instance of <see cref="WordDelimiterTokenFilter"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="generateWordParts"> A value indicating whether to generate part words. If set, causes parts of words to be generated; for example "AzureSearch" becomes "Azure" "Search". Default is true. </param>
        /// <param name="generateNumberParts"> A value indicating whether to generate number subwords. Default is true. </param>
        /// <param name="catenateWords"> A value indicating whether maximum runs of word parts will be catenated. For example, if this is set to true, "Azure-Search" becomes "AzureSearch". Default is false. </param>
        /// <param name="catenateNumbers"> A value indicating whether maximum runs of number parts will be catenated. For example, if this is set to true, "1-2" becomes "12". Default is false. </param>
        /// <param name="catenateAll"> A value indicating whether all subword parts will be catenated. For example, if this is set to true, "Azure-Search-1" becomes "AzureSearch1". Default is false. </param>
        /// <param name="splitOnCaseChange"> A value indicating whether to split words on caseChange. For example, if this is set to true, "AzureSearch" becomes "Azure" "Search". Default is true. </param>
        /// <param name="preserveOriginal"> A value indicating whether original words will be preserved and added to the subword list. Default is false. </param>
        /// <param name="splitOnNumerics"> A value indicating whether to split on numbers. For example, if this is set to true, "Azure1Search" becomes "Azure" "1" "Search". Default is true. </param>
        /// <param name="stemEnglishPossessive"> A value indicating whether to remove trailing "'s" for each subword. Default is true. </param>
        /// <param name="protectedWords"> A list of tokens to protect from being delimited. </param>
        internal WordDelimiterTokenFilter(string odataType, string name, IDictionary<string, BinaryData> serializedAdditionalRawData, bool? generateWordParts, bool? generateNumberParts, bool? catenateWords, bool? catenateNumbers, bool? catenateAll, bool? splitOnCaseChange, bool? preserveOriginal, bool? splitOnNumerics, bool? stemEnglishPossessive, IList<string> protectedWords) : base(odataType, name, serializedAdditionalRawData)
        {
            GenerateWordParts = generateWordParts;
            GenerateNumberParts = generateNumberParts;
            CatenateWords = catenateWords;
            CatenateNumbers = catenateNumbers;
            CatenateAll = catenateAll;
            SplitOnCaseChange = splitOnCaseChange;
            PreserveOriginal = preserveOriginal;
            SplitOnNumerics = splitOnNumerics;
            StemEnglishPossessive = stemEnglishPossessive;
            ProtectedWords = protectedWords;
            OdataType = odataType ?? "#Microsoft.Azure.Search.WordDelimiterTokenFilter";
        }

        /// <summary> Initializes a new instance of <see cref="WordDelimiterTokenFilter"/> for deserialization. </summary>
        internal WordDelimiterTokenFilter()
        {
        }

        /// <summary> A value indicating whether to generate part words. If set, causes parts of words to be generated; for example "AzureSearch" becomes "Azure" "Search". Default is true. </summary>
        public bool? GenerateWordParts { get; set; }
        /// <summary> A value indicating whether to generate number subwords. Default is true. </summary>
        public bool? GenerateNumberParts { get; set; }
        /// <summary> A value indicating whether maximum runs of word parts will be catenated. For example, if this is set to true, "Azure-Search" becomes "AzureSearch". Default is false. </summary>
        public bool? CatenateWords { get; set; }
        /// <summary> A value indicating whether maximum runs of number parts will be catenated. For example, if this is set to true, "1-2" becomes "12". Default is false. </summary>
        public bool? CatenateNumbers { get; set; }
        /// <summary> A value indicating whether all subword parts will be catenated. For example, if this is set to true, "Azure-Search-1" becomes "AzureSearch1". Default is false. </summary>
        public bool? CatenateAll { get; set; }
        /// <summary> A value indicating whether to split words on caseChange. For example, if this is set to true, "AzureSearch" becomes "Azure" "Search". Default is true. </summary>
        public bool? SplitOnCaseChange { get; set; }
        /// <summary> A value indicating whether original words will be preserved and added to the subword list. Default is false. </summary>
        public bool? PreserveOriginal { get; set; }
        /// <summary> A value indicating whether to split on numbers. For example, if this is set to true, "Azure1Search" becomes "Azure" "1" "Search". Default is true. </summary>
        public bool? SplitOnNumerics { get; set; }
        /// <summary> A value indicating whether to remove trailing "'s" for each subword. Default is true. </summary>
        public bool? StemEnglishPossessive { get; set; }
        /// <summary> A list of tokens to protect from being delimited. </summary>
        public IList<string> ProtectedWords { get; }
    }
}
