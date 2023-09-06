// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Storage.Tables.Models
{
    /// <summary> The StorageError. </summary>
    internal partial class StorageError
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="StorageError"/>. </summary>
        internal StorageError()
        {
        }

        /// <summary> Initializes a new instance of <see cref="StorageError"/>. </summary>
        /// <param name="message"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal StorageError(string message, Dictionary<string, BinaryData> rawData)
        {
            Message = message;
            _rawData = rawData;
        }

        /// <summary> Gets the message. </summary>
        public string Message { get; }
    }
}
