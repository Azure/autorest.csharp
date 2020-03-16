// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Storage.Management.Models
{
    /// <summary> The CheckNameAvailability operation response. </summary>
    public partial class CheckNameAvailabilityResult
    {
        /// <summary> Initializes a new instance of CheckNameAvailabilityResult. </summary>
        internal CheckNameAvailabilityResult()
        {
        }

        /// <summary> Initializes a new instance of CheckNameAvailabilityResult. </summary>
        /// <param name="nameAvailable"> Gets a boolean value that indicates whether the name is available for you to use. If true, the name is available. If false, the name has already been taken or is invalid and cannot be used. </param>
        /// <param name="reason"> Gets the reason that a storage account name could not be used. The Reason element is only returned if NameAvailable is false. </param>
        /// <param name="message"> Gets an error message explaining the Reason value in more detail. </param>
        internal CheckNameAvailabilityResult(bool? nameAvailable, Reason? reason, string message)
        {
            NameAvailable = nameAvailable;
            Reason = reason;
            Message = message;
        }

        /// <summary> Gets a boolean value that indicates whether the name is available for you to use. If true, the name is available. If false, the name has already been taken or is invalid and cannot be used. </summary>
        public bool? NameAvailable { get; internal set; }
        /// <summary> Gets the reason that a storage account name could not be used. The Reason element is only returned if NameAvailable is false. </summary>
        public Reason? Reason { get; internal set; }
        /// <summary> Gets an error message explaining the Reason value in more detail. </summary>
        public string Message { get; internal set; }
    }
}
