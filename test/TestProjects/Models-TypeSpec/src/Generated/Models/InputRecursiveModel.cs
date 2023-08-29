// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Input model that has property of its own type. </summary>
    public partial class InputRecursiveModel
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of InputRecursiveModel. </summary>
        /// <param name="message"> Message. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        public InputRecursiveModel(string message)
        {
            Argument.AssertNotNull(message, nameof(message));

            Message = message;
        }

        /// <summary> Initializes a new instance of InputRecursiveModel. </summary>
        /// <param name="message"> Message. </param>
        /// <param name="inner"> Required Record. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal InputRecursiveModel(string message, InputRecursiveModel inner, Dictionary<string, BinaryData> rawData)
        {
            Message = message;
            Inner = inner;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="InputRecursiveModel"/> for deserialization. </summary>
        internal InputRecursiveModel()
        {
        }

        /// <summary> Message. </summary>
        public string Message { get; }
        /// <summary> Required Record. </summary>
        public InputRecursiveModel Inner { get; set; }
    }
}
