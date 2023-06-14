// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> Properties of the FirewallPolicyNatRuleCollectionAction. </summary>
    internal partial class FirewallPolicyNatRuleCollectionAction
    {
        /// <summary> Initializes a new instance of FirewallPolicyNatRuleCollectionAction. </summary>
        public FirewallPolicyNatRuleCollectionAction()
        {
        }

        /// <summary> Initializes a new instance of FirewallPolicyNatRuleCollectionAction. </summary>
        /// <param name="actionType"> The type of action. </param>
        internal FirewallPolicyNatRuleCollectionAction(FirewallPolicyNatRuleCollectionActionType? actionType)
        {
            ActionType = actionType;
        }

        /// <summary> The type of action. </summary>
        public FirewallPolicyNatRuleCollectionActionType? ActionType { get; set; }
    }
}
