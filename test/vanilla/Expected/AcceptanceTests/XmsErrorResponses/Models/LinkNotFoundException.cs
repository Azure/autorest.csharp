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
    /// Exception thrown for an invalid response with LinkNotFound information.
    /// </summary>
    public partial class LinkNotFoundException : Microsoft.Rest.RestExceptionBase<LinkNotFound>
    {

        /// <summary>
        /// Initializes a new instance of the LinkNotFoundException class.
        /// </summary>
        public LinkNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the LinkNotFoundException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public LinkNotFoundException(string message)
        : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the LinkNotFoundException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public LinkNotFoundException(string message, System.Exception innerException)
        : base(message, innerException)
        {
        }

            /// <summary>
        /// </summary>
        public string WhatSubAddress
        {
            get
            {
                return Body?.WhatSubAddress;
            }
        }

        /// <summary>
        /// </summary>
        public string Reason
        {
            get
            {
                return Body?.Reason;
            }
        }

        /// <summary>
        /// </summary>
        public string SomeBaseProp
        {
            get
            {
                return Body?.SomeBaseProp;
            }
        }

    }
}
