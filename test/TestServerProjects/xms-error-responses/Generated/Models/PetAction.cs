// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xms_error_responses.Models
{
    /// <summary> The PetAction. </summary>
    public partial class PetAction
    {
        /// <summary> Initializes a new instance of PetAction. </summary>
        internal PetAction()
        {
        }

        /// <summary> Initializes a new instance of PetAction. </summary>
        /// <param name="actionResponse"> action feedback. </param>
        internal PetAction(string actionResponse)
        {
            ActionResponse = actionResponse;
        }

        /// <summary> action feedback. </summary>
        public string ActionResponse { get; }
    }
}
