// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xml_service.Models
{
    /// <summary> The LeaseStateType. </summary>
    public enum LeaseStateType
    {
        /// <summary> available. </summary>
        Available,
        /// <summary> leased. </summary>
        Leased,
        /// <summary> expired. </summary>
        Expired,
        /// <summary> breaking. </summary>
        Breaking,
        /// <summary> broken. </summary>
        Broken
    }
}
