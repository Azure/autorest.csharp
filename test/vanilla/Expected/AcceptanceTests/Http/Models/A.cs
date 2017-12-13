// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsHttp.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class A: IHttpRestErrorModel
    {
        /// <summary>
        /// Initializes a new instance of the A class.
        /// </summary>
        public A()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the A class.
        /// </summary>
        public A(string statusCode = default(string))
        {
            StatusCode = statusCode;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "statusCode")]
        public string StatusCode { get; set; }

        /// <summary>
        /// Method that creates an exception of AException
        /// </summary>
        public void CreateAndThrowException(HttpRequestMessageWrapper requestMessage, HttpResponseMessageWrapper responseMessage)
        {
            var ex = new AException
            {
                Request = requestMessage,
                Response = responseMessage
            };
            ex.SetErrorModel(this);
            throw ex;
        }
    }
}
