// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> A result containing a document found by a suggestion query, plus associated metadata. </summary>
    public partial class SuggestResult
    {
        /// <summary> Initializes a new instance of <see cref="SuggestResult"/>. </summary>
        /// <param name="text"> The text of the suggestion result. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        internal SuggestResult(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Text = text;
            AdditionalProperties = new ChangeTrackingDictionary<string, object>();
        }

        /// <summary> Initializes a new instance of <see cref="SuggestResult"/>. </summary>
        /// <param name="text"> The text of the suggestion result. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        internal SuggestResult(string text, IReadOnlyDictionary<string, object> additionalProperties)
        {
            Text = text;
            AdditionalProperties = additionalProperties;
        }

        /// <summary> The text of the suggestion result. </summary>
        public string Text { get; }
        /// <summary> Additional Properties. </summary>
        public IReadOnlyDictionary<string, object> AdditionalProperties { get; }
    }
}
