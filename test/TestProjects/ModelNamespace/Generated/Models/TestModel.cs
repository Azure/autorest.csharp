// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace ModelNamespace
{
    /// <summary> . </summary>
    internal partial class TestModel
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="TestModel"/>. </summary>
        internal TestModel()
        {
        }

        /// <summary> Initializes a new instance of <see cref="TestModel"/>. </summary>
        /// <param name="code"></param>
        /// <param name="status"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal TestModel(string code, string status, Dictionary<string, BinaryData> rawData)
        {
            Code = code;
            Status = status;
            _rawData = rawData;
        }

        /// <summary> Gets the code. </summary>
        public string Code { get; }
        /// <summary> Gets the status. </summary>
        public string Status { get; }
    }
}
