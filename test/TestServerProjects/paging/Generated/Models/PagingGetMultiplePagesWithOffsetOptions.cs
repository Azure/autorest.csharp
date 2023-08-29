// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace paging.Models
{
    /// <summary> Parameter group. </summary>
    public partial class PagingGetMultiplePagesWithOffsetOptions
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="PagingGetMultiplePagesWithOffsetOptions"/>. </summary>
        /// <param name="offset"> Offset of return value. </param>
        public PagingGetMultiplePagesWithOffsetOptions(int offset)
        {
            Offset = offset;
        }

        /// <summary> Initializes a new instance of <see cref="PagingGetMultiplePagesWithOffsetOptions"/>. </summary>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="offset"> Offset of return value. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal PagingGetMultiplePagesWithOffsetOptions(int? maxresults, int offset, int? timeout, Dictionary<string, BinaryData> rawData)
        {
            Maxresults = maxresults;
            Offset = offset;
            Timeout = timeout;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="PagingGetMultiplePagesWithOffsetOptions"/> for deserialization. </summary>
        internal PagingGetMultiplePagesWithOffsetOptions()
        {
        }

        /// <summary> Sets the maximum number of items to return in the response. </summary>
        public int? Maxresults { get; set; }
        /// <summary> Offset of return value. </summary>
        public int Offset { get; }
        /// <summary> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </summary>
        public int? Timeout { get; set; }
    }
}
