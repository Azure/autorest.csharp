// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace paging.Models
{
    /// <summary> Parameter group. </summary>
    public partial class PagingGetMultiplePagesLroOptions
    {
        /// <summary> Initializes a new instance of PagingGetMultiplePagesLroOptions. </summary>
        public PagingGetMultiplePagesLroOptions()
        {
        }

        /// <summary> Initializes a new instance of PagingGetMultiplePagesLroOptions. </summary>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        internal PagingGetMultiplePagesLroOptions(int? maxresults, int? timeout)
        {
            Maxresults = maxresults;
            Timeout = timeout;
        }

        /// <summary> Sets the maximum number of items to return in the response. </summary>
        public int? Maxresults { get; set; }
        /// <summary> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </summary>
        public int? Timeout { get; set; }
    }
}
