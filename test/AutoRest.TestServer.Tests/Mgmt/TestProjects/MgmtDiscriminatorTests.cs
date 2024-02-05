// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Azure.Core;
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
            var now = DateTime.UtcNow;
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
                    new Dog(), foo: "Foo", new Dictionary<string, BinaryData>()
                {
                    {"foo", new BinaryData("bar") }
                }),
                BoolProperty = false,
                Location = AzureLocation.AustraliaCentral,
                LocationWithCustomSerialization = AzureLocation.AustraliaCentral,
                DateTimeProperty = now,
                Duration = TimeSpan.FromDays(1),
                Number = 4,
            };

            var bicep = ModelReaderWriter.Write(data, new ModelReaderWriterOptions("B")).ToString();
            TestContext.Progress.WriteLine(bicep);
            var expected = $$"""
                           {
                             boolProperty: false
                             location: 'australiacentral'
                             locationWithCustomSerialization: 'brazilsouth'
                             dateTimeProperty: '{{TypeFormatters.ToString(now, "o")}}'
                             duration: 'P1D'
                             number: 4
                             properties: {
                               order: 3
                               conditions: {
                                 parameters: {
                                   typeName: 'DeliveryRuleQueryStringConditionParameters'
                                   operator: 'Any'
                                   matchValues: [
                                     'val1'
                                     'val2'
                                   ]
                                 }
                                 name: 'QueryString'
                                 foo: 'query'
                               }
                               actions: [
                                 {
                                   name: 'CacheExpiration'
                                   foo: 'foo1'
                                 }
                                 {
                                   name: 'UrlSigning'
                                   foo: 'foo2'
                                 }
                               ]
                               extraMappingInfo: {
                                 dictionaryKey:  {
                                   name: 'CacheExpiration'
                                   foo: 'foo1'
                                 }
                               }
                               pet: {
                                 kind: 'Dog'
                               }
                               foo: 'Foo'
                             }
                           }
                           
                           """;
            Assert.AreEqual(expected, bicep);

            var props = new DeliveryRuleProperties(3, condition, actions,
                new Dictionary<string, DeliveryRuleAction>()
                {
                    {
                        "dictionaryKey", new DeliveryRuleAction(DeliveryRuleActionType.CacheExpiration, "foo1", null)
                    }
                },
                new Dog(), foo: "Foo", new Dictionary<string, BinaryData>() { { "foo", new BinaryData("bar") } });

            bicep = ModelReaderWriter.Write(props, new ModelReaderWriterOptions("B")).ToString();
            TestContext.Progress.WriteLine(bicep);
        }
    }
}
