// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.BodyDateTime.Models
{
    using Microsoft.Rest;

    /// <summary>
    /// Exception thrown for an invalid response with Error information.
    /// </summary>
    public partial class ErrorException : RestException<Error>
    {

        /// <summary>
        /// Initializes a new instance of the ErrorException class.
        /// </summary>
        public ErrorException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ErrorException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public ErrorException(string message)
        : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ErrorException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public ErrorException(string message, System.Exception innerException)
        : base(message, innerException)
        {
        }

            /// <summary>
        /// </summary>
        public int? Status
        {
            get
            {
                return Body?.Status;
            }
        }

        /// <summary>
        /// </summary>
        public override string Message
        {
            get
            {
                return string.IsNullOrEmpty(Body?.Message)? base.Message : Body.Message;
            }
        }

    }
}
