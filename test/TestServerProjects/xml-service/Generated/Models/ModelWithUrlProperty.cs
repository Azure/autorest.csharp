// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace xml_service.Models
{
    /// <summary> The ModelWithUrlProperty. </summary>
    public partial class ModelWithUrlProperty
    {
        /// <summary> Initializes a new instance of <see cref="ModelWithUrlProperty"/>. </summary>
        public ModelWithUrlProperty()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithUrlProperty"/>. </summary>
        /// <param name="url"></param>
        internal ModelWithUrlProperty(Uri url)
        {
            Url = url;
        }

        /// <summary> Gets or sets the url. </summary>
        public Uri Url { get; set; }
    }
}
