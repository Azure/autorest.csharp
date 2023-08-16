// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace dpg_customization_LowLevel.Models
{
    /// <summary> The Input. </summary>
    public partial class Input
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of Input. </summary>
        /// <param name="hello"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="hello"/> is null. </exception>
        public Input(string hello)
        {
            if (hello == null)
            {
                throw new ArgumentNullException(nameof(hello));
            }

            Hello = hello;
        }

        internal Input(string hello, Dictionary<string, BinaryData> rawData)
        {
            Hello = hello;
            _rawData = rawData;
        }

        /// <summary> Gets the hello. </summary>
        public string Hello { get; }
    }
}
