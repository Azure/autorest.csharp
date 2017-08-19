// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.AcceptanceTestsPaging.Models
{
    using Fixtures.Azure;
    using Fixtures.Azure.AcceptanceTestsPaging;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Additional parameters for GetMultiplePages operation.
    /// </summary>
    public partial class PagingGetMultiplePagesOptionsInner
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PagingGetMultiplePagesOptionsInner class.
        /// </summary>
        public PagingGetMultiplePagesOptionsInner()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// PagingGetMultiplePagesOptionsInner class.
        /// </summary>
        /// <param name="maxresults">Sets the maximum number of items to return
        /// in the response.</param>
        /// <param name="timeout">Sets the maximum time that the server can
        /// spend processing the request, in seconds. The default is 30
        /// seconds.</param>
        public PagingGetMultiplePagesOptionsInner(int? maxresults = default(int?), int? timeout = default(int?))
        {
            Maxresults = maxresults;
            Timeout = timeout;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets sets the maximum number of items to return in the
        /// response.
        /// </summary>
        [JsonProperty(PropertyName = "")]
        public int? Maxresults { get; set; }

        /// <summary>
        /// Gets or sets sets the maximum time that the server can spend
        /// processing the request, in seconds. The default is 30 seconds.
        /// </summary>
        [JsonProperty(PropertyName = "")]
        public int? Timeout { get; set; }

    }
}
