// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.AcceptanceTestsXmsErrorResponses.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    [Newtonsoft.Json.JsonObject("InvalidResourceLink")]
    public partial class LinkNotFound : NotFoundErrorBase, IHttpRestErrorModel
    {
        /// <summary>
        /// Initializes a new instance of the LinkNotFound class.
        /// </summary>
        public LinkNotFound()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the LinkNotFound class.
        /// </summary>
        public LinkNotFound(string someBaseProp = default(string), string reason = default(string), string whatSubAddress = default(string))
            : base(someBaseProp, reason)
        {
            WhatSubAddress = whatSubAddress;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "whatSubAddress")]
        public string WhatSubAddress { get; set; }

        /// <summary>
        /// Method that creates an exception of LinkNotFoundException
        /// </summary>
        public override void CreateAndThrowException(HttpRequestMessageWrapper requestMessage, HttpResponseMessageWrapper responseMessage)
        {
            var ex = new LinkNotFoundException
            {
                Request = requestMessage,
                Response = responseMessage
            };
            ex.SetErrorModel(this);
            throw ex;
        }
    }
}
