// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> Firewall Policy NAT Rule Collection. </summary>
    public partial class FirewallPolicyNatRuleCollection : FirewallPolicyRuleCollection
    {
        /// <summary> Initializes a new instance of FirewallPolicyNatRuleCollection. </summary>
        public FirewallPolicyNatRuleCollection()
        {
            Rules = new ChangeTrackingList<FirewallPolicyRule>();
            RuleCollectionType = FirewallPolicyRuleCollectionType.FirewallPolicyNatRuleCollection;
        }

        /// <summary> Initializes a new instance of FirewallPolicyNatRuleCollection. </summary>
        /// <param name="ruleCollectionType"> The type of the rule collection. </param>
        /// <param name="name"> The name of the rule collection. </param>
        /// <param name="priority"> Priority of the Firewall Policy Rule Collection resource. </param>
        /// <param name="action"> The action type of a Nat rule collection. </param>
        /// <param name="rules">
        /// List of rules included in a rule collection.
        /// Please note <see cref="FirewallPolicyRule"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="ApplicationRule"/>, <see cref="NatRule"/> and <see cref="NetworkRule"/>.
        /// </param>
        internal FirewallPolicyNatRuleCollection(FirewallPolicyRuleCollectionType ruleCollectionType, string name, int? priority, FirewallPolicyNatRuleCollectionAction action, IList<FirewallPolicyRule> rules) : base(ruleCollectionType, name, priority)
        {
            Action = action;
            Rules = rules;
            RuleCollectionType = ruleCollectionType;
        }

        /// <summary> The action type of a Nat rule collection. </summary>
        internal FirewallPolicyNatRuleCollectionAction Action { get; set; }
        /// <summary> The type of action. </summary>
        public FirewallPolicyNatRuleCollectionActionType? ActionType
        {
            get => Action is null ? default : Action.ActionType;
            set
            {
                if (Action is null)
                    Action = new FirewallPolicyNatRuleCollectionAction();
                Action.ActionType = value;
            }
        }

        /// <summary>
        /// List of rules included in a rule collection.
        /// Please note <see cref="FirewallPolicyRule"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="ApplicationRule"/>, <see cref="NatRule"/> and <see cref="NetworkRule"/>.
        /// </summary>
        public IList<FirewallPolicyRule> Rules { get; }
    }
}
