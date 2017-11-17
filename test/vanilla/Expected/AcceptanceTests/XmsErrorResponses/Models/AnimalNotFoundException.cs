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
    /// Exception thrown for an invalid response with AnimalNotFound
    /// information.
    /// </summary>
    public partial class AnimalNotFoundException : HttpRestExceptionBase<AnimalNotFound>
    {

        /// <summary>
        /// Initializes a new instance of the AnimalNotFoundException class.
        /// </summary>
        public AnimalNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AnimalNotFoundException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public AnimalNotFoundException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the AnimalNotFoundException class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public AnimalNotFoundException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// </summary>
        public string Name => Body.Name;

        /// <summary>
        /// </summary>
        public string Reason => Body.Reason;

        /// <summary>
        /// </summary>
        public string SomeBaseProp => Body.SomeBaseProp;

    }
}
