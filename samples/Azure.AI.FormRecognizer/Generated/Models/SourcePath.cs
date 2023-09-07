// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Uri or local path to source data. </summary>
    public partial class SourcePath
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="SourcePath"/>. </summary>
        public SourcePath()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SourcePath"/>. </summary>
        /// <param name="source"> File source path. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SourcePath(string source, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Source = source;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> File source path. </summary>
        public string Source { get; set; }
    }
}
