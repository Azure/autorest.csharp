// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> Properties of the FirewallPolicyFilterRuleCollectionAction. </summary>
    internal partial class FirewallPolicyFilterRuleCollectionAction
    {
        /// <summary> Initializes a new instance of FirewallPolicyFilterRuleCollectionAction. </summary>
        public FirewallPolicyFilterRuleCollectionAction()
        {
        }

        /// <summary> Initializes a new instance of FirewallPolicyFilterRuleCollectionAction. </summary>
        /// <param name="actionType"> The type of action. </param>
        internal FirewallPolicyFilterRuleCollectionAction(FirewallPolicyFilterRuleCollectionActionType? actionType)
        {
            ActionType = actionType;
        }

        /// <summary> The type of action. </summary>
        public FirewallPolicyFilterRuleCollectionActionType? ActionType { get; set; }
    }
}
