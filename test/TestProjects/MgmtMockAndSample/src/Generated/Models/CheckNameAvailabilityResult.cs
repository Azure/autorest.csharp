// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> The CheckNameAvailability operation response. </summary>
    public partial class CheckNameAvailabilityResult
    {
        /// <summary> Initializes a new instance of CheckNameAvailabilityResult. </summary>
        internal CheckNameAvailabilityResult()
        {
        }

        /// <summary> Initializes a new instance of CheckNameAvailabilityResult. </summary>
        /// <param name="nameAvailable"> A boolean value that indicates whether the name is available for you to use. If true, the name is available. If false, the name has already been taken or is invalid and cannot be used. </param>
        /// <param name="reason"> The reason that a vault name could not be used. The Reason element is only returned if NameAvailable is false. </param>
        /// <param name="message"> An error message explaining the Reason value in more detail. </param>
        internal CheckNameAvailabilityResult(bool? nameAvailable, Reason? reason, string message)
        {
            NameAvailable = nameAvailable;
            Reason = reason;
            Message = message;
        }

        /// <summary> A boolean value that indicates whether the name is available for you to use. If true, the name is available. If false, the name has already been taken or is invalid and cannot be used. </summary>
        public bool? NameAvailable { get; }
        /// <summary> The reason that a vault name could not be used. The Reason element is only returned if NameAvailable is false. </summary>
        public Reason? Reason { get; }
        /// <summary> An error message explaining the Reason value in more detail. </summary>
        public string Message { get; }
    }
}
