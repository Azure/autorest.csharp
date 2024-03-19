// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Azure.Core;
using Azure.ResourceManager;
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
                    QueryStringOperator.Any) { MatchValues = { $"firstline{Environment.NewLine}secondline", "val2" } });
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
                    new Dog { DogKind = DogKind.GermanShepherd, PetType = "dog" }, foo: $"Foo{Environment.NewLine}bar", new Dictionary<string, BinaryData>()
                {
                    {$"foo{Environment.NewLine}bar", new BinaryData("bar") }
                }),
                BoolProperty = false,
                Location = AzureLocation.AustraliaCentral,
                LocationWithCustomSerialization = AzureLocation.AustraliaCentral,
                DateTimeProperty = now,
                Duration = TimeSpan.FromDays(1),
                Number = 4,
                ShellProperty = new Shell { Name = "shell" }
            };

            var bicep = ModelReaderWriter.Write(data, new ModelReaderWriterOptions("bicep")).ToString();
            var expected = $$"""
                           {
                             location: 'australiacentral'
                             boolProperty: false
                             locationWithCustomSerialization: 'brazilsouth'
                             dateTimeProperty: '{{TypeFormatters.ToString(now, "o")}}'
                             duration: 'P1D'
                             number: 4
                             shellProperty: {
                               name: 'shell'
                             }
                             properties: {
                               order: 3
                               conditions: {
                                 parameters: {
                                   typeName: 'DeliveryRuleQueryStringConditionParameters'
                                   operator: 'Any'
                                   matchValues: [
                                     '''
                           firstline
                           secondline'''
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
                                 'dictionaryKey': {
                                   name: 'CacheExpiration'
                                   foo: 'foo1'
                                 }
                               }
                               pet: {
                                 dogKind: 'german Shepherd'
                                 kind: 'Dog'
                                 type: 'dog'
                               }
                               foo: '''
                           Foo
                           bar'''
                             }
                           }
                           
                           """;
            Assert.AreEqual(expected, bicep);
        }

        [Test]
        public void ToBicepWithOverrides()
        {
            var now = DateTime.UtcNow;
            var queryParams = new QueryStringMatchConditionParameters(
                QueryStringMatchConditionParametersTypeName.DeliveryRuleQueryStringConditionParameters,
                QueryStringOperator.Any) { MatchValues = { $"firstline{Environment.NewLine}secondline", "val2" }};
            var condition = new DeliveryRuleQueryStringCondition(MatchVariable.QueryString, "query", null,
                queryParams);
            var firstAction = new DeliveryRuleAction(DeliveryRuleActionType.CacheExpiration, "foo1", null);
            var actions =
                new[]
                {
                    firstAction,
                    new DeliveryRuleAction(DeliveryRuleActionType.UrlSigning, "foo2", null)
                };
            var data = new DeliveryRuleData
            {
                Properties = new DeliveryRuleProperties(3, condition, actions,
                    new Dictionary<string, DeliveryRuleAction>()
                        {{ "dictionaryKey", new DeliveryRuleAction(DeliveryRuleActionType.CacheExpiration, "foo1", null) }},
                    new Dog { DogKind = DogKind.GermanShepherd }, foo: $"Foo{Environment.NewLine}bar", new Dictionary<string, BinaryData>()
                {
                    {$"foo{Environment.NewLine}bar", new BinaryData("bar") }
                }),
                BoolProperty = false,
                Location = AzureLocation.AustraliaCentral,
                LocationWithCustomSerialization = AzureLocation.AustraliaCentral,
                DateTimeProperty = now,
                Duration = TimeSpan.FromDays(1),
                Number = 4,
                NestedName = "someSku"
            };
            var options = new BicepModelReaderWriterOptions
            {
                ParameterOverrides =
                    {
                        {
                            data, new Dictionary<string, string>
                            {
                                { nameof(DeliveryRuleData.BoolProperty), "boolParameter" },
                                { nameof(DeliveryRuleData.Location), "locationParameter" },
                                { nameof(DeliveryRuleData.NestedName), "'overridenSku'" },
                            }
                        },
                        {
                            queryParams, new Dictionary<string, string>
                            {
                                { nameof(QueryStringMatchConditionParametersTypeName), "queryParametersTypeNameParameter" },
                            }
                        },
                        {
                            firstAction, new Dictionary<string, string>
                            {
                                { nameof(DeliveryRuleAction.Foo), "fooParameter" },
                            }
                        }
                    }
            };
            var bicep = ModelReaderWriter.Write(data, options).ToString();
            var expected = $$"""
                           {
                             location: locationParameter
                             boolProperty: boolParameter
                             locationWithCustomSerialization: 'brazilsouth'
                             dateTimeProperty: '{{TypeFormatters.ToString(now, "o")}}'
                             duration: 'P1D'
                             number: 4
                             sku: {
                               name: {
                                 nestedName: 'overridenSku'
                               }
                             }
                             properties: {
                               order: 3
                               conditions: {
                                 parameters: {
                                   typeName: 'DeliveryRuleQueryStringConditionParameters'
                                   operator: 'Any'
                                   matchValues: [
                                     '''
                           firstline
                           secondline'''
                                     'val2'
                                   ]
                                 }
                                 name: 'QueryString'
                                 foo: 'query'
                               }
                               actions: [
                                 {
                                   name: 'CacheExpiration'
                                   foo: fooParameter
                                 }
                                 {
                                   name: 'UrlSigning'
                                   foo: 'foo2'
                                 }
                               ]
                               extraMappingInfo: {
                                 'dictionaryKey': {
                                   name: 'CacheExpiration'
                                   foo: 'foo1'
                                 }
                               }
                               pet: {
                                 dogKind: 'german Shepherd'
                                 kind: 'Dog'
                               }
                               foo: '''
                           Foo
                           bar'''
                             }
                           }
                           
                           """;
            Assert.AreEqual(expected, bicep);
        }

        [Test]
        public void ToBicepEmptyChildObject()
        {
            var now = DateTime.UtcNow;
            var condition = new DeliveryRuleQueryStringCondition(MatchVariable.QueryString, "query", null,
                new QueryStringMatchConditionParameters(
                    QueryStringMatchConditionParametersTypeName.DeliveryRuleQueryStringConditionParameters,
                    QueryStringOperator.Any) { MatchValues = { $"firstline{Environment.NewLine}secondline", "val2" } });
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
                    new Dog { DogKind = DogKind.GermanShepherd }, foo: $"Foo{Environment.NewLine}bar", new Dictionary<string, BinaryData>()
                {
                    {$"foo{Environment.NewLine}bar", new BinaryData("bar") }
                }),
                BoolProperty = false,
                Location = AzureLocation.AustraliaCentral,
                LocationWithCustomSerialization = AzureLocation.AustraliaCentral,
                DateTimeProperty = now,
                Duration = TimeSpan.FromDays(1),
                Number = 4,
                ShellProperty = new Shell()
            };

            var bicep = ModelReaderWriter.Write(data, new ModelReaderWriterOptions("bicep")).ToString();
            var expected = $$"""
                           {
                             location: 'australiacentral'
                             boolProperty: false
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
                                     '''
                           firstline
                           secondline'''
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
                                 'dictionaryKey': {
                                   name: 'CacheExpiration'
                                   foo: 'foo1'
                                 }
                               }
                               pet: {
                                 dogKind: 'german Shepherd'
                                 kind: 'Dog'
                               }
                               foo: '''
                           Foo
                           bar'''
                             }
                           }
                           
                           """;
            Assert.AreEqual(expected, bicep);
        }
    }
}
