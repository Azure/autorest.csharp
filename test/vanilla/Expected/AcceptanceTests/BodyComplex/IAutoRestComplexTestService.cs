// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsBodyComplex
{
    using Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Test Infrastructure for AutoRest
    /// </summary>
    public partial interface IAutoRestComplexTestService : System.IDisposable
    {
        /// <summary>
        /// Gets or sets the base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets JSON serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets JSON deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// API ID.
        /// </summary>
        string ApiVersion { get; }


        /// <summary>
        /// Gets the IBasicOperations.
        /// </summary>
        IBasicOperations Basic { get; }

        /// <summary>
        /// Gets the IPrimitive.
        /// </summary>
        IPrimitive Primitive { get; }

        /// <summary>
        /// Gets the IArray.
        /// </summary>
        IArray Array { get; }

        /// <summary>
        /// Gets the IDictionary.
        /// </summary>
        IDictionary Dictionary { get; }

        /// <summary>
        /// Gets the IInheritance.
        /// </summary>
        IInheritance Inheritance { get; }

        /// <summary>
        /// Gets the IPolymorphism.
        /// </summary>
        IPolymorphism Polymorphism { get; }

        /// <summary>
        /// Gets the IPolymorphicrecursive.
        /// </summary>
        IPolymorphicrecursive Polymorphicrecursive { get; }

        /// <summary>
        /// Gets the IReadonlyproperty.
        /// </summary>
        IReadonlyproperty Readonlyproperty { get; }

    }
}
