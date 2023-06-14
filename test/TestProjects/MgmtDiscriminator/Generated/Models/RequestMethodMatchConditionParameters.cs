// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for RequestMethod match conditions. </summary>
    public partial class RequestMethodMatchConditionParameters
    {
        /// <summary> Initializes a new instance of RequestMethodMatchConditionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="operator"> Describes operator to be matched. </param>
        public RequestMethodMatchConditionParameters(RequestMethodMatchConditionParametersTypeName typeName, RequestMethodOperator @operator)
        {
            TypeName = typeName;
            Operator = @operator;
            Transforms = new ChangeTrackingList<Transform>();
            MatchValues = new ChangeTrackingList<RequestMethodMatchConditionParametersMatchValuesItem>();
        }

        /// <summary> Initializes a new instance of RequestMethodMatchConditionParameters. </summary>
        /// <param name="typeName"></param>
        /// <param name="operator"> Describes operator to be matched. </param>
        /// <param name="negateCondition"> Describes if this is negate condition or not. </param>
        /// <param name="transforms"> List of transforms. </param>
        /// <param name="matchValues"> The match value for the condition of the delivery rule. </param>
        internal RequestMethodMatchConditionParameters(RequestMethodMatchConditionParametersTypeName typeName, RequestMethodOperator @operator, bool? negateCondition, IList<Transform> transforms, IList<RequestMethodMatchConditionParametersMatchValuesItem> matchValues)
        {
            TypeName = typeName;
            Operator = @operator;
            NegateCondition = negateCondition;
            Transforms = transforms;
            MatchValues = matchValues;
        }

        /// <summary> Gets or sets the type name. </summary>
        public RequestMethodMatchConditionParametersTypeName TypeName { get; set; }
        /// <summary> Describes operator to be matched. </summary>
        public RequestMethodOperator Operator { get; set; }
        /// <summary> Describes if this is negate condition or not. </summary>
        public bool? NegateCondition { get; set; }
        /// <summary> List of transforms. </summary>
        public IList<Transform> Transforms { get; }
        /// <summary> The match value for the condition of the delivery rule. </summary>
        public IList<RequestMethodMatchConditionParametersMatchValuesItem> MatchValues { get; }
    }
}
