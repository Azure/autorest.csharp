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

    /// <summary>
    /// Exception thrown for an invalid response with PetActionError
    /// information.
    /// </summary>
    public partial class PetActionErrorException : RestException<PetActionError>
    {

        /// <summary>
        /// Initializes a new instance of the PetActionErrorException class.
        /// </summary>
        public PetActionErrorException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PetActionErrorException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public PetActionErrorException(string message)
        : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PetActionErrorException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public PetActionErrorException(string message, System.Exception innerException)
        : base(message, innerException)
        {
        }

            /// <summary>
        /// Gets or sets the error message
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return ErrorBody?.ErrorMessage;
            }
        }

    }
}
