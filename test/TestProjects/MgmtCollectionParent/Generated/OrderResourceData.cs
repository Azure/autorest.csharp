// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtCollectionParent.Models;

namespace MgmtCollectionParent
{
    /// <summary>
    /// A class representing the OrderResource data model.
    /// Specifies the properties or parameters for an order. Order is a grouping of one or more order items.
    /// </summary>
    public partial class OrderResourceData : ResourceData
    {
        /// <summary> Initializes a new instance of OrderResourceData. </summary>
        internal OrderResourceData()
        {
            OrderItemIds = new ChangeTrackingList<string>();
            OrderStageHistory = new ChangeTrackingList<StageDetails>();
        }

        /// <summary> Initializes a new instance of OrderResourceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="orderItemIds"> List of order item ARM Ids which are part of an order. </param>
        /// <param name="currentStage"> Order current status. </param>
        /// <param name="orderStageHistory"> Order status history. </param>
        internal OrderResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IReadOnlyList<string> orderItemIds, StageDetails currentStage, IReadOnlyList<StageDetails> orderStageHistory) : base(id, name, resourceType, systemData)
        {
            OrderItemIds = orderItemIds;
            CurrentStage = currentStage;
            OrderStageHistory = orderStageHistory;
        }

        /// <summary> List of order item ARM Ids which are part of an order. </summary>
        public IReadOnlyList<string> OrderItemIds { get; }
        /// <summary> Order current status. </summary>
        public StageDetails CurrentStage { get; }
        /// <summary> Order status history. </summary>
        public IReadOnlyList<StageDetails> OrderStageHistory { get; }
    }
}
