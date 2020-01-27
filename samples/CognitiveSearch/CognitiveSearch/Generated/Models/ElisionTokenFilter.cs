// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Removes elisions. For example, &quot;l&apos;avion&quot; (the plane) will be converted to &quot;avion&quot; (plane). This token filter is implemented using Apache Lucene. </summary>
    public partial class ElisionTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of ElisionTokenFilter. </summary>
        public ElisionTokenFilter()
        {
            OdataType = "#Microsoft.Azure.Search.ElisionTokenFilter";
        }
        /// <summary> The set of articles to remove. </summary>
        public ICollection<string> Articles { get; set; }
    }
}
