// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Matches single or multi-word synonyms in a token stream. This token filter is implemented using Apache Lucene. </summary>
    public partial class SynonymTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of SynonymTokenFilter. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="synonyms"> A list of synonyms in following one of two formats: 1. incredible, unbelievable, fabulous =&gt; amazing - all terms on the left side of =&gt; symbol will be replaced with all terms on its right side; 2. incredible, unbelievable, fabulous, amazing - comma separated list of equivalent words. Set the expand option to change how this list is interpreted. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="synonyms"/> is null. </exception>
        public SynonymTokenFilter(string name, IEnumerable<string> synonyms) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(synonyms, nameof(synonyms));

            Synonyms = synonyms.ToList();
            OdataType = "#Microsoft.Azure.Search.SynonymTokenFilter";
        }

        /// <summary> Initializes a new instance of SynonymTokenFilter. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="synonyms"> A list of synonyms in following one of two formats: 1. incredible, unbelievable, fabulous =&gt; amazing - all terms on the left side of =&gt; symbol will be replaced with all terms on its right side; 2. incredible, unbelievable, fabulous, amazing - comma separated list of equivalent words. Set the expand option to change how this list is interpreted. </param>
        /// <param name="ignoreCase"> A value indicating whether to case-fold input for matching. Default is false. </param>
        /// <param name="expand"> A value indicating whether all words in the list of synonyms (if =&gt; notation is not used) will map to one another. If true, all words in the list of synonyms (if =&gt; notation is not used) will map to one another. The following list: incredible, unbelievable, fabulous, amazing is equivalent to: incredible, unbelievable, fabulous, amazing =&gt; incredible, unbelievable, fabulous, amazing. If false, the following list: incredible, unbelievable, fabulous, amazing will be equivalent to: incredible, unbelievable, fabulous, amazing =&gt; incredible. Default is true. </param>
        internal SynonymTokenFilter(string odataType, string name, IList<string> synonyms, bool? ignoreCase, bool? expand) : base(odataType, name)
        {
            Synonyms = synonyms;
            IgnoreCase = ignoreCase;
            Expand = expand;
            OdataType = odataType ?? "#Microsoft.Azure.Search.SynonymTokenFilter";
        }

        /// <summary> A list of synonyms in following one of two formats: 1. incredible, unbelievable, fabulous =&gt; amazing - all terms on the left side of =&gt; symbol will be replaced with all terms on its right side; 2. incredible, unbelievable, fabulous, amazing - comma separated list of equivalent words. Set the expand option to change how this list is interpreted. </summary>
        public IList<string> Synonyms { get; }
        /// <summary> A value indicating whether to case-fold input for matching. Default is false. </summary>
        public bool? IgnoreCase { get; set; }
        /// <summary> A value indicating whether all words in the list of synonyms (if =&gt; notation is not used) will map to one another. If true, all words in the list of synonyms (if =&gt; notation is not used) will map to one another. The following list: incredible, unbelievable, fabulous, amazing is equivalent to: incredible, unbelievable, fabulous, amazing =&gt; incredible, unbelievable, fabulous, amazing. If false, the following list: incredible, unbelievable, fabulous, amazing will be equivalent to: incredible, unbelievable, fabulous, amazing =&gt; incredible. Default is true. </summary>
        public bool? Expand { get; set; }
    }
}
