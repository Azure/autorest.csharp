// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace xms_error_responses.Models
{
    /// <summary> The PetActionError. </summary>
    public partial class PetActionError : PetAction
    {
        /// <summary> Initializes a new instance of PetActionError. </summary>
        internal PetActionError()
        {
            ErrorType = "PetActionError";
        }

        /// <summary> Initializes a new instance of PetActionError. </summary>
        /// <param name="actionResponse"> action feedback. </param>
        /// <param name="errorType"></param>
        /// <param name="errorMessage"> the error message. </param>
        internal PetActionError(string actionResponse, string errorType, string errorMessage) : base(actionResponse)
        {
            ErrorType = errorType ?? "PetActionError";
            ErrorMessage = errorMessage;
        }

        /// <summary> Gets or sets the errortype. </summary>
        internal string ErrorType { get; set; }
        /// <summary> the error message. </summary>
        public string ErrorMessage { get; }
    }
}
