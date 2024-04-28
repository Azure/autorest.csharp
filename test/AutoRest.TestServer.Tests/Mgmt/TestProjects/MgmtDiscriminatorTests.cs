// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
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
                // validate explicit null is still excluded
                Location = null,
                LocationWithCustomSerialization = AzureLocation.AustraliaCentral,
                DateTimeProperty = DateTimeOffset.Parse("2024-03-20T00:00:00.0000000Z"),
                Duration = TimeSpan.FromDays(1),
                Number = 4,
                ShellProperty = new Shell { Name = "shell" }
            };

            var bicep = ModelReaderWriter.Write(data, new ModelReaderWriterOptions("bicep")).ToString();
            var expected = File.ReadAllText(TestData.GetLocation("BicepData/NoOverrides.bicep"));
            Assert.AreEqual(expected, bicep);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ToBicepWithOverrides(bool initializeOverridedProperty)
        {
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
                DateTimeProperty = DateTimeOffset.Parse("2024-03-20T00:00:00.0000000Z"),
                Duration = TimeSpan.FromDays(1),
                Number = 4,
            };

            if (initializeOverridedProperty)
            {
                data.NestedName = "someSku";
                data.Unflattened = new Unflattened
                {
                    Name = "unflattened",
                    Value = "value"
                };
            }

            var options = new BicepModelReaderWriterOptions
            {
                PropertyOverrides =
                    {
                        {
                            data, new Dictionary<string, string>
                            {
                                { nameof(DeliveryRuleData.BoolProperty), "boolParameter" },
                                { nameof(DeliveryRuleData.Location), "locationParameter" },
                                { nameof(DeliveryRuleData.NestedName), "'overridenSku'" },
                                { nameof(DeliveryRuleData.UnflattenedName), "'unflattenedOverride'"}
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
            var file = initializeOverridedProperty ? "BicepData/OverridesWithInitialization.bicep" : "BicepData/Overrides.bicep";
            var expected = File.ReadAllText(TestData.GetLocation(file));
            Assert.AreEqual(expected, bicep);
        }

        [Test]
        public void ToBicepWithOverridesEnvelopeTakesPrecedence()
        {
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
                DateTimeProperty = DateTimeOffset.Parse("2024-03-20T00:00:00.0000000Z"),
                Duration = TimeSpan.FromDays(1),
                Number = 4,
            };

            var options = new BicepModelReaderWriterOptions
            {
                PropertyOverrides =
                    {
                        {
                            data, new Dictionary<string, string>
                            {
                                { nameof(DeliveryRuleData.BoolProperty), "boolParameter" },
                                { nameof(DeliveryRuleData.Location), "locationParameter" },
                                { nameof(DeliveryRuleData.NestedName), "'overridenSku'" },
                                { nameof(DeliveryRuleData.Unflattened), "{" + Environment.NewLine +
                                                                        "    name: 'envelopeOverride'" + Environment.NewLine +
                                                                        "    value: 'value'" + Environment.NewLine +
                                                                        "  }"},
                                { nameof(DeliveryRuleData.UnflattenedName), "'unflattenedOverride'"}
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
            var file = "BicepData/OverridesWithEnvelope.bicep";
            var expected = File.ReadAllText(TestData.GetLocation(file));
            Assert.AreEqual(expected, bicep);
        }

        [Test]
        public void ToBicepEmptyChildObject()
        {
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
                DateTimeProperty = DateTimeOffset.Parse("2024-03-20T00:00:00.0000000Z"),
                Duration = TimeSpan.FromDays(1),
                Number = 4,
                ShellProperty = new Shell()
            };

            var bicep = ModelReaderWriter.Write(data, new ModelReaderWriterOptions("bicep")).ToString();
            var expected = File.ReadAllText(TestData.GetLocation("BicepData/EmptyChildObject.bicep"));
            Assert.AreEqual(expected, bicep);
        }
    }
}
