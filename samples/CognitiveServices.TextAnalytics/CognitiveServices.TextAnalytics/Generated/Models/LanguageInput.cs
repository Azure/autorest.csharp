// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The LanguageInput. </summary>
    public partial class LanguageInput
    {
        /// <summary> Initializes a new instance of LanguageInput. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="text"> . </param>
        public LanguageInput(string id, string text)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Id = id;
            Text = text;
        }

        /// <summary> Initializes a new instance of LanguageInput. </summary>
        /// <param name="id"> Unique, non-empty document identifier. </param>
        /// <param name="text"> . </param>
        /// <param name="countryHint"> . </param>
        internal LanguageInput(string id, string text, string countryHint)
        {
            Id = id;
            Text = text;
            CountryHint = countryHint;
        }

        /// <summary> Unique, non-empty document identifier. </summary>
        public string Id { get; }
        public string Text { get; }
        public string CountryHint { get; set; }
    }
}
