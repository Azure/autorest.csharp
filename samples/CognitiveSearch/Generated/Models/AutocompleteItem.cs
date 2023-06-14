// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> The result of Autocomplete requests. </summary>
    public partial class AutocompleteItem
    {
        /// <summary> Initializes a new instance of AutocompleteItem. </summary>
        /// <param name="text"> The completed term. </param>
        /// <param name="queryPlusText"> The query along with the completed term. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="queryPlusText"/> is null. </exception>
        internal AutocompleteItem(string text, string queryPlusText)
        {
            Argument.AssertNotNull(text, nameof(text));
            Argument.AssertNotNull(queryPlusText, nameof(queryPlusText));

            Text = text;
            QueryPlusText = queryPlusText;
        }

        /// <summary> The completed term. </summary>
        public string Text { get; }
        /// <summary> The query along with the completed term. </summary>
        public string QueryPlusText { get; }
    }
}
