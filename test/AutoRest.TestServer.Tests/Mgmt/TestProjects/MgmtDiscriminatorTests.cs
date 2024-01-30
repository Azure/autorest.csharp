// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MgmtDiscriminator;
using MgmtDiscriminator.Models;
using NUnit.Framework;

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

        [Test]
        public void ToBicep()
        {
            var condition = new DeliveryRuleQueryStringCondition(MatchVariable.QueryString, "query", null,
                new QueryStringMatchConditionParameters(
                    QueryStringMatchConditionParametersTypeName.DeliveryRuleQueryStringConditionParameters,
                    QueryStringOperator.Any) { MatchValues = { "val1", "val2" } });
            var actions =
                new[]
                {
                    new DeliveryRuleAction(DeliveryRuleActionType.CacheExpiration, "foo1", null),
                    new DeliveryRuleAction(DeliveryRuleActionType.UrlSigning, "foo2", null)
                };
            var data = new DeliveryRuleData
            {
                Properties = new DeliveryRuleProperties(3, condition, actions,
                    new Dictionary<string, DeliveryRuleAction>()
                        {{ "dictionaryKey", new DeliveryRuleAction(DeliveryRuleActionType.CacheExpiration, "foo1", null) }},
                    new Dog {Bark = "ruff"}, foo: "Foo", new Dictionary<string, BinaryData>()
                {
                    {"foo", new BinaryData("bar") }
                }),
            };

            TestContext.Progress.WriteLine(ModelReaderWriter.Write(data, new ModelReaderWriterOptions("B")).ToString());
        }
    }
}
