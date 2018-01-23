// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.MirrorPolymorphic.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Error2: IRestErrorModel
    {
        /// <summary>
        /// Initializes a new instance of the Error2 class.
        /// </summary>
        public Error2()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Error2 class.
        /// </summary>
        public Error2(int? code = default(int?), string message = default(string), string fields = default(string))
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
        /// Method that creates an exception of Error2Exception
        /// </summary>
        public void CreateAndThrowException(string errorMessage, HttpRequestMessageWrapper requestMessage, HttpResponseMessageWrapper responseMessage)
        {
            var ex = new Error2Exception(errorMessage)
            {
                Request = requestMessage,
                Response = responseMessage
            };
            ex.Body = this;
            throw ex;
        }
    }
}
