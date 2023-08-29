// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace FirstTestTypeSpec.Models
{
    /// <summary> The ModelWithFormat. </summary>
    public partial class ModelWithFormat
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of ModelWithFormat. </summary>
        /// <param name="sourceUrl"> url format. </param>
        /// <param name="guid"> uuid format. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceUrl"/> is null. </exception>
        public ModelWithFormat(Uri sourceUrl, Guid guid)
        {
            Argument.AssertNotNull(sourceUrl, nameof(sourceUrl));

            SourceUrl = sourceUrl;
            Guid = guid;
        }

        /// <summary> Initializes a new instance of ModelWithFormat. </summary>
        /// <param name="sourceUrl"> url format. </param>
        /// <param name="guid"> uuid format. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelWithFormat(Uri sourceUrl, Guid guid, Dictionary<string, BinaryData> rawData)
        {
            SourceUrl = sourceUrl;
            Guid = guid;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithFormat"/> for deserialization. </summary>
        internal ModelWithFormat()
        {
        }

        /// <summary> url format. </summary>
        public Uri SourceUrl { get; }
        /// <summary> uuid format. </summary>
        public Guid Guid { get; }
    }
}
