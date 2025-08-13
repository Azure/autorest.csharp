// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomizedTypeSpec.Models
{
    /// <summary> this is a ModelWithFormat model. </summary>
    [CodeGenSuppress("ModelWithFormat", typeof(Uri), typeof(Guid))]
    public partial class ModelWithFormat
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <param name="guid"></param>
        /// <param name="name"></param>
        /// <param name="serializedAdditionalRawData"></param>
        public ModelWithFormat(Uri sourceUrl, Guid guid, string name, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Argument.AssertNotNull(sourceUrl, nameof(sourceUrl));

            SourceUrl = sourceUrl;
            Guid = guid;
            _serializedAdditionalRawData = serializedAdditionalRawData;
            Name = name;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}
