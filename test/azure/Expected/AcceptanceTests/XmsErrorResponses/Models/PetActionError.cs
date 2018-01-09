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

    public partial class PetActionError: IRestErrorModel
    {
        /// <summary>
        /// Initializes a new instance of the PetActionError class.
        /// </summary>
        public PetActionError()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PetActionError class.
        /// </summary>
        /// <param name="errorMessage">the error message</param>
        public PetActionError(string errorMessage = default(string))
        {
            ErrorMessage = errorMessage;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Method that creates an exception of PetActionErrorException
        /// </summary>
        public virtual void CreateAndThrowException(HttpRequestMessageWrapper requestMessage, HttpResponseMessageWrapper responseMessage, int statusCode)
        {
            var ex = new PetActionErrorException
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
