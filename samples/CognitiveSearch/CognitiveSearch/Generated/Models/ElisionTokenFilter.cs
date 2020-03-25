// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Removes elisions. For example, &quot;l&apos;avion&quot; (the plane) will be converted to &quot;avion&quot; (plane). This token filter is implemented using Apache Lucene. </summary>
    public partial class ElisionTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of ElisionTokenFilter. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public ElisionTokenFilter(string name) : base(name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            OdataType = "#Microsoft.Azure.Search.ElisionTokenFilter";
        }

        /// <summary> Initializes a new instance of ElisionTokenFilter. </summary>
        /// <param name="articles"> The set of articles to remove. </param>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal ElisionTokenFilter(IList<string> articles, string odataType, string name) : base(odataType, name)
        {
            Articles = articles;
            OdataType = odataType ?? "#Microsoft.Azure.Search.ElisionTokenFilter";
        }

        /// <summary> The set of articles to remove. </summary>
        public IList<string> Articles { get; set; }
    }
}
