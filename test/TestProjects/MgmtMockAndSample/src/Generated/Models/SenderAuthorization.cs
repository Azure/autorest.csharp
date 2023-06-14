// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> the authorization used by the user who has performed the operation that led to this event. This captures the RBAC properties of the event. These usually include the 'action', 'role' and the 'scope'. </summary>
    public partial class SenderAuthorization
    {
        /// <summary> Initializes a new instance of SenderAuthorization. </summary>
        internal SenderAuthorization()
        {
        }

        /// <summary> Initializes a new instance of SenderAuthorization. </summary>
        /// <param name="action"> the permissible actions. For instance: microsoft.support/supporttickets/write. </param>
        /// <param name="role"> the role of the user. For instance: Subscription Admin. </param>
        /// <param name="scope"> the scope. </param>
        internal SenderAuthorization(string action, string role, string scope)
        {
            Action = action;
            Role = role;
            Scope = scope;
        }

        /// <summary> the permissible actions. For instance: microsoft.support/supporttickets/write. </summary>
        public string Action { get; }
        /// <summary> the role of the user. For instance: Subscription Admin. </summary>
        public string Role { get; }
        /// <summary> the scope. </summary>
        public string Scope { get; }
    }
}
