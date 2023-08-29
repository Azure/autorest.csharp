// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace httpInfrastructure.Models
{
    /// <summary> The C. </summary>
    public partial class C
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="C"/>. </summary>
        internal C()
        {
        }

        /// <summary> Initializes a new instance of <see cref="C"/>. </summary>
        /// <param name="httpCode"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal C(string httpCode, Dictionary<string, BinaryData> rawData)
        {
            HttpCode = httpCode;
            _rawData = rawData;
        }

        /// <summary> Gets the http code. </summary>
        public string HttpCode { get; }
    }
}
