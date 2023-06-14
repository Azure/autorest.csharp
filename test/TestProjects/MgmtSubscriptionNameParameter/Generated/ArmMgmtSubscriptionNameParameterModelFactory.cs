// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtSubscriptionNameParameter;

namespace MgmtSubscriptionNameParameter.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtSubscriptionNameParameterModelFactory
    {
        /// <summary> Initializes a new instance of SBSubscriptionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="messageCount"> Number of messages. </param>
        /// <param name="createdOn"> Exact time the message was created. </param>
        /// <param name="accessedOn"> Last time there was a receive request to this subscription. </param>
        /// <param name="updatedOn"> The exact time the message was updated. </param>
        /// <param name="lockDuration"> ISO 8061 lock duration timespan for the subscription. The default value is 1 minute. </param>
        /// <param name="requiresSession"> Value indicating if a subscription supports the concept of sessions. </param>
        /// <param name="defaultMessageTimeToLive"> ISO 8061 Default message timespan to live value. This is the duration after which the message expires, starting from when the message is sent to Service Bus. This is the default value used when TimeToLive is not set on a message itself. </param>
        /// <param name="deadLetteringOnFilterEvaluationExceptions"> Value that indicates whether a subscription has dead letter support on filter evaluation exceptions. </param>
        /// <param name="deadLetteringOnMessageExpiration"> Value that indicates whether a subscription has dead letter support when a message expires. </param>
        /// <param name="duplicateDetectionHistoryTimeWindow"> ISO 8601 timeSpan structure that defines the duration of the duplicate detection history. The default value is 10 minutes. </param>
        /// <param name="maxDeliveryCount"> Number of maximum deliveries. </param>
        /// <param name="enableBatchedOperations"> Value that indicates whether server-side batched operations are enabled. </param>
        /// <param name="autoDeleteOnIdle"> ISO 8061 timeSpan idle interval after which the topic is automatically deleted. The minimum duration is 5 minutes. </param>
        /// <param name="forwardTo"> Queue/Topic name to forward the messages. </param>
        /// <param name="forwardDeadLetteredMessagesTo"> Queue/Topic name to forward the Dead Letter message. </param>
        /// <param name="isClientAffine"> Value that indicates whether the subscription has an affinity to the client id. </param>
        /// <param name="clientAffineProperties"> Properties specific to client affine subscriptions. </param>
        /// <returns> A new <see cref="MgmtSubscriptionNameParameter.SBSubscriptionData"/> instance for mocking. </returns>
        public static SBSubscriptionData SBSubscriptionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, long? messageCount = null, DateTimeOffset? createdOn = null, DateTimeOffset? accessedOn = null, DateTimeOffset? updatedOn = null, TimeSpan? lockDuration = null, bool? requiresSession = null, TimeSpan? defaultMessageTimeToLive = null, bool? deadLetteringOnFilterEvaluationExceptions = null, bool? deadLetteringOnMessageExpiration = null, TimeSpan? duplicateDetectionHistoryTimeWindow = null, int? maxDeliveryCount = null, bool? enableBatchedOperations = null, TimeSpan? autoDeleteOnIdle = null, string forwardTo = null, string forwardDeadLetteredMessagesTo = null, bool? isClientAffine = null, SBClientAffineProperties clientAffineProperties = null)
        {
            return new SBSubscriptionData(id, name, resourceType, systemData, messageCount, createdOn, accessedOn, updatedOn, lockDuration, requiresSession, defaultMessageTimeToLive, deadLetteringOnFilterEvaluationExceptions, deadLetteringOnMessageExpiration, duplicateDetectionHistoryTimeWindow, maxDeliveryCount, enableBatchedOperations, autoDeleteOnIdle, forwardTo, forwardDeadLetteredMessagesTo, isClientAffine, clientAffineProperties);
        }
    }
}
