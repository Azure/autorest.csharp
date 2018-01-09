// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.MirrorPrimitives.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Error: IRestErrorModel
    {
        /// <summary>
        /// Initializes a new instance of the Error class.
        /// </summary>
        public Error()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Error class.
        /// </summary>
        public Error(int? code = default(int?), string message = default(string), string fields = default(string))
        {
            Code = code;
            Message = message;
            Fields = fields;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int? Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fields")]
        public string Fields { get; set; }

        /// <summary>
        /// Method that creates an exception of ErrorException
        /// </summary>
        public void CreateAndThrowException(HttpRequestMessageWrapper requestMessage, HttpResponseMessageWrapper responseMessage, int statusCode)
        {
            var ex = new ErrorException
            {
                Request = requestMessage,
                Response = responseMessage,
                ResponseStatusCode = statusCode
            };
            ex.SetErrorModel(this);
            throw ex;
        }
    }
}
