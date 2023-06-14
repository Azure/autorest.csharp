// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace FirstTestTypeSpec.Models
{
    /// <summary> The ModelWithFormat. </summary>
    public partial class ModelWithFormat
    {
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

        /// <summary> url format. </summary>
        public Uri SourceUrl { get; }
        /// <summary> uuid format. </summary>
        public Guid Guid { get; }
    }
}
