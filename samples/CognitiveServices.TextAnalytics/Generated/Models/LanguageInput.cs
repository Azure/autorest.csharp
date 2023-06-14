// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The LanguageInput. </summary>
    public partial class LanguageInput
    {
        /// <summary> Initializes a new instance of LanguageInput. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="text"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="text"/> is null. </exception>
        public LanguageInput(string id, string text)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(text, nameof(text));

            Id = id;
            Text = text;
        }

        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; }
        /// <summary> Gets the text. </summary>
        public string Text { get; }
        /// <summary> Gets or sets the country hint. </summary>
        public string CountryHint { get; set; }
    }
}
