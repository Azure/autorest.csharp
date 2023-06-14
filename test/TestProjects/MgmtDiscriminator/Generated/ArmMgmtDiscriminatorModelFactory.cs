// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtDiscriminator;

namespace MgmtDiscriminator.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtDiscriminatorModelFactory
    {

        /// <summary> Initializes a new instance of DeliveryRuleData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> The properties. </param>
        /// <returns> A new <see cref="MgmtDiscriminator.DeliveryRuleData"/> instance for mocking. </returns>
        public static DeliveryRuleData DeliveryRuleData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, DeliveryRuleProperties properties = null)
        {
            return new DeliveryRuleData(id, name, resourceType, systemData, properties);
        }

        /// <summary> Initializes a new instance of DeliveryRuleCondition. </summary>
        /// <param name="name"> The name of the condition for the delivery rule. </param>
        /// <param name="foo"> For test. </param>
        /// <returns> A new <see cref="Models.DeliveryRuleCondition"/> instance for mocking. </returns>
        public static DeliveryRuleCondition DeliveryRuleCondition(string name = "Unknown", string foo = null)
        {
            return new UnknownDeliveryRuleCondition(name, foo);
        }

        /// <summary> Initializes a new instance of DeliveryRuleAction. </summary>
        /// <param name="name"> The name of the action for the delivery rule. </param>
        /// <param name="foo"> for test. </param>
        /// <returns> A new <see cref="Models.DeliveryRuleAction"/> instance for mocking. </returns>
        public static DeliveryRuleAction DeliveryRuleAction(string name = "Unknown", string foo = null)
        {
            return new DeliveryRuleAction(name, foo);
        }

        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="id"> The Id of the pet. </param>
        /// <returns> A new <see cref="Models.Pet"/> instance for mocking. </returns>
        public static Pet Pet(string id = null)
        {
            return new UnknownPet(default, id);
        }

        /// <summary> Initializes a new instance of Cat. </summary>
        /// <param name="id"> The Id of the pet. </param>
        /// <param name="meow"> A cat can meow. </param>
        /// <returns> A new <see cref="Models.Cat"/> instance for mocking. </returns>
        public static Cat Cat(string id = null, string meow = null)
        {
            return new Cat(PetKind.Cat, id, meow);
        }

        /// <summary> Initializes a new instance of Dog. </summary>
        /// <param name="id"> The Id of the pet. </param>
        /// <param name="bark"> A dog can bark. </param>
        /// <returns> A new <see cref="Models.Dog"/> instance for mocking. </returns>
        public static Dog Dog(string id = null, string bark = null)
        {
            return new Dog(PetKind.Dog, id, bark);
        }

        /// <summary> Initializes a new instance of DeliveryRuleRemoteAddressCondition. </summary>
        /// <param name="foo"> For test. </param>
        /// <param name="parameters"> Defines the parameters for the condition. </param>
        /// <returns> A new <see cref="Models.DeliveryRuleRemoteAddressCondition"/> instance for mocking. </returns>
        public static DeliveryRuleRemoteAddressCondition DeliveryRuleRemoteAddressCondition(string foo = null, RemoteAddressMatchConditionParameters parameters = null)
        {
            return new DeliveryRuleRemoteAddressCondition(MatchVariable.RemoteAddress, foo, parameters);
        }

        /// <summary> Initializes a new instance of DeliveryRuleRequestMethodCondition. </summary>
        /// <param name="foo"> For test. </param>
        /// <param name="parameters"> Defines the parameters for the condition. </param>
        /// <returns> A new <see cref="Models.DeliveryRuleRequestMethodCondition"/> instance for mocking. </returns>
        public static DeliveryRuleRequestMethodCondition DeliveryRuleRequestMethodCondition(string foo = null, RequestMethodMatchConditionParameters parameters = null)
        {
            return new DeliveryRuleRequestMethodCondition(MatchVariable.RequestMethod, foo, parameters);
        }

        /// <summary> Initializes a new instance of DeliveryRuleQueryStringCondition. </summary>
        /// <param name="foo"> For test. </param>
        /// <param name="parameters"> Defines the parameters for the condition. </param>
        /// <returns> A new <see cref="Models.DeliveryRuleQueryStringCondition"/> instance for mocking. </returns>
        public static DeliveryRuleQueryStringCondition DeliveryRuleQueryStringCondition(string foo = null, QueryStringMatchConditionParameters parameters = null)
        {
            return new DeliveryRuleQueryStringCondition(MatchVariable.QueryString, foo, parameters);
        }

        /// <summary> Initializes a new instance of UrlRedirectAction. </summary>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <returns> A new <see cref="Models.UrlRedirectAction"/> instance for mocking. </returns>
        public static UrlRedirectAction UrlRedirectAction(string foo = null, UrlRedirectActionParameters parameters = null)
        {
            return new UrlRedirectAction(DeliveryRuleActionType.UrlRedirect, foo, parameters);
        }

        /// <summary> Initializes a new instance of UrlSigningAction. </summary>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <returns> A new <see cref="Models.UrlSigningAction"/> instance for mocking. </returns>
        public static UrlSigningAction UrlSigningAction(string foo = null, UrlSigningActionParameters parameters = null)
        {
            return new UrlSigningAction(DeliveryRuleActionType.UrlSigning, foo, parameters);
        }

        /// <summary> Initializes a new instance of OriginGroupOverrideAction. </summary>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <returns> A new <see cref="Models.OriginGroupOverrideAction"/> instance for mocking. </returns>
        public static OriginGroupOverrideAction OriginGroupOverrideAction(string foo = null, OriginGroupOverrideActionParameters parameters = null)
        {
            return new OriginGroupOverrideAction(DeliveryRuleActionType.OriginGroupOverride, foo, parameters);
        }

        /// <summary> Initializes a new instance of UrlRewriteAction. </summary>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <returns> A new <see cref="Models.UrlRewriteAction"/> instance for mocking. </returns>
        public static UrlRewriteAction UrlRewriteAction(string foo = null, UrlRewriteActionParameters parameters = null)
        {
            return new UrlRewriteAction(DeliveryRuleActionType.UrlRewrite, foo, parameters);
        }

        /// <summary> Initializes a new instance of DeliveryRuleRequestHeaderAction. </summary>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <returns> A new <see cref="Models.DeliveryRuleRequestHeaderAction"/> instance for mocking. </returns>
        public static DeliveryRuleRequestHeaderAction DeliveryRuleRequestHeaderAction(string foo = null, HeaderActionParameters parameters = null)
        {
            return new DeliveryRuleRequestHeaderAction(DeliveryRuleActionType.ModifyRequestHeader, foo, parameters);
        }

        /// <summary> Initializes a new instance of DeliveryRuleResponseHeaderAction. </summary>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <returns> A new <see cref="Models.DeliveryRuleResponseHeaderAction"/> instance for mocking. </returns>
        public static DeliveryRuleResponseHeaderAction DeliveryRuleResponseHeaderAction(string foo = null, HeaderActionParameters parameters = null)
        {
            return new DeliveryRuleResponseHeaderAction(DeliveryRuleActionType.ModifyResponseHeader, foo, parameters);
        }

        /// <summary> Initializes a new instance of DeliveryRuleCacheExpirationAction. </summary>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <returns> A new <see cref="Models.DeliveryRuleCacheExpirationAction"/> instance for mocking. </returns>
        public static DeliveryRuleCacheExpirationAction DeliveryRuleCacheExpirationAction(string foo = null, CacheExpirationActionParameters parameters = null)
        {
            return new DeliveryRuleCacheExpirationAction(DeliveryRuleActionType.CacheExpiration, foo, parameters);
        }

        /// <summary> Initializes a new instance of DeliveryRuleCacheKeyQueryStringAction. </summary>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <returns> A new <see cref="Models.DeliveryRuleCacheKeyQueryStringAction"/> instance for mocking. </returns>
        public static DeliveryRuleCacheKeyQueryStringAction DeliveryRuleCacheKeyQueryStringAction(string foo = null, CacheKeyQueryStringActionParameters parameters = null)
        {
            return new DeliveryRuleCacheKeyQueryStringAction(DeliveryRuleActionType.CacheKeyQueryString, foo, parameters);
        }

        /// <summary> Initializes a new instance of DeliveryRuleRouteConfigurationOverrideAction. </summary>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <returns> A new <see cref="Models.DeliveryRuleRouteConfigurationOverrideAction"/> instance for mocking. </returns>
        public static DeliveryRuleRouteConfigurationOverrideAction DeliveryRuleRouteConfigurationOverrideAction(string foo = null, RouteConfigurationOverrideActionParameters parameters = null)
        {
            return new DeliveryRuleRouteConfigurationOverrideAction(DeliveryRuleActionType.RouteConfigurationOverride, foo, parameters);
        }
    }
}
