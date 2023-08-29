// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Specs_.Azure.ClientGenerator.Core.Internal.Models
{
    /// <summary> This is a model only used by internal operation. It should be generated but not exported. </summary>
    internal partial class InternalModel
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of InternalModel. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal InternalModel(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Initializes a new instance of InternalModel. </summary>
        /// <param name="name"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalModel(string name, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="InternalModel"/> for deserialization. </summary>
        internal InternalModel()
        {
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
