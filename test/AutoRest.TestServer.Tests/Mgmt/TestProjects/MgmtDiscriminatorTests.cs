// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using MgmtDiscriminator.Models;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtDiscriminatorTests : TestProjectTests
    {
        public MgmtDiscriminatorTests() : base("MgmtDiscriminator")
        {
        }

        [TestCase("DeliveryRuleListResult", false)]
        [TestCase("DeliveryRuleAction", true)]
        [TestCase("UrlRedirectAction", true)]
        [TestCase("UrlSigningAction", true)]
        [TestCase("OriginGroupOverrideAction", true)]
        [TestCase("UrlRewriteAction", true)]
        [TestCase("DeliveryRuleRequestHeaderAction", true)]
        [TestCase("DeliveryRuleResponseHeaderAction", true)]
        [TestCase("DeliveryRuleCacheExpirationAction", true)]
        [TestCase("DeliveryRuleCacheKeyQueryStringAction", true)]
        [TestCase("DeliveryRuleRouteConfigurationOverrideAction", true)]
        public void ValidateTypesAccessibility(string className, bool isPublic)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(className));
            Assert.NotNull(type);
            Assert.AreEqual(isPublic, type.IsPublic);
        }

        [TestCase("This is the first test case.")]
        [TestCase("This is the sceond test case.")]
        [TestCase("This is the third test case.")]
        public void ValidateAbstractClassExtensionMethod(string description)
        {
            BinaryData data = BinaryData.FromString($"{{\"Description\": \"{description}\"}}");
            var result = DeliveryRuleCondition.FromBinaryData(data);
            Assert.AreEqual(typeof(UnknownDeliveryRuleCondition), result.GetType());
            Assert.AreEqual(result.Name, new MatchVariable("Unknown"));
            Assert.AreEqual(result.Description, description);
        }
    }
}
