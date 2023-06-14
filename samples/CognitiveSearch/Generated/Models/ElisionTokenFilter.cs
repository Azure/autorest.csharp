// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Removes elisions. For example, "l'avion" (the plane) will be converted to "avion" (plane). This token filter is implemented using Apache Lucene. </summary>
    public partial class ElisionTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of ElisionTokenFilter. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public ElisionTokenFilter(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Articles = new ChangeTrackingList<string>();
            OdataType = "#Microsoft.Azure.Search.ElisionTokenFilter";
        }

        /// <summary> Initializes a new instance of ElisionTokenFilter. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="articles"> The set of articles to remove. </param>
        internal ElisionTokenFilter(string odataType, string name, IList<string> articles) : base(odataType, name)
        {
            Articles = articles;
            OdataType = odataType ?? "#Microsoft.Azure.Search.ElisionTokenFilter";
        }

        /// <summary> The set of articles to remove. </summary>
        public IList<string> Articles { get; }
    }
}
