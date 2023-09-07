// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> The check availability result. </summary>
    [PropertyReferenceType]
    public partial class CheckNameAvailabilityResponse
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="CheckNameAvailabilityResponse"/>. </summary>
        [InitializationConstructor]
        public CheckNameAvailabilityResponse()
        {
        }

        /// <summary> Initializes a new instance of <see cref="CheckNameAvailabilityResponse"/>. </summary>
        /// <param name="nameAvailable"> Indicates if the resource name is available. </param>
        /// <param name="reason"> The reason why the given name is not available. </param>
        /// <param name="message"> Detailed reason why the given name is available. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CheckNameAvailabilityResponse(bool? nameAvailable, CheckNameAvailabilityReason? reason, string message, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            NameAvailable = nameAvailable;
            Reason = reason;
            Message = message;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Indicates if the resource name is available. </summary>
        public bool? NameAvailable { get; set; }
        /// <summary> The reason why the given name is not available. </summary>
        public CheckNameAvailabilityReason? Reason { get; set; }
        /// <summary> Detailed reason why the given name is available. </summary>
        public string Message { get; set; }
    }
}
