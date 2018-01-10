// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsXmsErrorResponses.Models
{
    using Microsoft.Rest;

    /// <summary>
    /// Exception thrown for an invalid response with PetHungryOrThirstyError
    /// information.
    /// </summary>
    public partial class PetHungryOrThirstyErrorException : RestException<PetHungryOrThirstyError>
    {

        /// <summary>
        /// Initializes a new instance of the PetHungryOrThirstyErrorException class.
        /// </summary>
        public PetHungryOrThirstyErrorException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PetHungryOrThirstyErrorException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public PetHungryOrThirstyErrorException(string message)
        : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PetHungryOrThirstyErrorException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public PetHungryOrThirstyErrorException(string message, System.Exception innerException)
        : base(message, innerException)
        {
        }

            /// <summary>
        /// Gets or sets is the pet hungry or thirsty or both
        /// </summary>
        public string HungryOrThirsty
        {
            get
            {
                return ErrorBody?.HungryOrThirsty;
            }
        }

        /// <summary>
        /// Gets or sets why is the pet sad
        /// </summary>
        public string Reason
        {
            get
            {
                return ErrorBody?.Reason;
            }
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
