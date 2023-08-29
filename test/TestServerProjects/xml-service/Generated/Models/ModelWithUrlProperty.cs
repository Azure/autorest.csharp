// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> The ModelWithUrlProperty. </summary>
    public partial class ModelWithUrlProperty
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ModelWithUrlProperty"/>. </summary>
        public ModelWithUrlProperty()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithUrlProperty"/>. </summary>
        /// <param name="url"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelWithUrlProperty(Uri url, Dictionary<string, BinaryData> rawData)
        {
            Url = url;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the url. </summary>
        public Uri Url { get; set; }
    }
}
