// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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

        private protected override Assembly GetAssembly() => typeof(DeliveryRuleData).Assembly;

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
            var type = GetType(className);
            Assert.NotNull(type);
            Assert.AreEqual(isPublic, type.IsPublic);
        }


        [Test]
        public void ToBicep()
        {
            var condition = GetModel<DeliveryRuleQueryStringCondition>(GetStaticProperty(GetType("MatchVariable"), "QueryString"), "query", null,
                new QueryStringMatchConditionParameters(
                    QueryStringMatchConditionParametersTypeName.DeliveryRuleQueryStringConditionParameters,
                    QueryStringOperator.Any) { MatchValues = { $"firstline{Environment.NewLine}secondline", "val2" } });
            var actions =
                new[]
                {
                    GetModel<DeliveryRuleAction>(GetStaticProperty(GetType("DeliveryRuleActionType"), "CacheExpiration"), "foo1", null),
                    GetModel<DeliveryRuleAction>(GetStaticProperty(GetType("DeliveryRuleActionType"), "UrlSigning"), "foo2", null)
                };
            var data = new DeliveryRuleData
            {
                Properties = GetModel<DeliveryRuleProperties>(3, condition, actions,
                    new Dictionary<string, DeliveryRuleAction>()
                        {{ "dictionaryKey", GetModel<DeliveryRuleAction>(GetStaticProperty(GetType("DeliveryRuleActionType"), "CacheExpiration"), "foo1", null) }},
                    new Dog { DogKind = DogKind.GermanShepherd, PetType = "dog" }, $"Foo{Environment.NewLine}bar", new Dictionary<string, BinaryData>()
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
            var condition = GetModel<DeliveryRuleQueryStringCondition>(GetStaticProperty(GetType("MatchVariable"), "QueryString"), "query", null,
                queryParams);
            var firstAction = GetModel<DeliveryRuleAction>(GetStaticProperty(GetType("DeliveryRuleActionType"), "CacheExpiration"), "foo1", null);
            var actions =
                new[]
                {
                    firstAction,
                    GetModel<DeliveryRuleAction>(GetStaticProperty(GetType("DeliveryRuleActionType"), "UrlSigning"), "foo2", null)
                };
            var data = new DeliveryRuleData
            {
                Properties = GetModel<DeliveryRuleProperties>(3, condition, actions,
                    new Dictionary<string, DeliveryRuleAction>()
                        {{ "dictionaryKey", GetModel<DeliveryRuleAction>(GetStaticProperty(GetType("DeliveryRuleActionType"), "CacheExpiration"), "foo1", null) }},
                    new Dog { DogKind = DogKind.GermanShepherd }, $"Foo{Environment.NewLine}bar", new Dictionary<string, BinaryData>()
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
            var condition = GetModel<DeliveryRuleQueryStringCondition>(GetStaticProperty(GetType("MatchVariable"), "QueryString"), "query", null,
                queryParams);
            var firstAction = GetModel<DeliveryRuleAction>(GetStaticProperty(GetType("DeliveryRuleActionType"), "CacheExpiration"), "foo1", null);
            var actions =
                new[]
                {
                    firstAction,
                    GetModel<DeliveryRuleAction>(GetStaticProperty(GetType("DeliveryRuleActionType"), "UrlSigning"), "foo2", null)
                };
            var data = new DeliveryRuleData
            {
                Properties = GetModel<DeliveryRuleProperties>(3, condition, actions,
                    new Dictionary<string, DeliveryRuleAction>()
                        {{ "dictionaryKey", GetModel<DeliveryRuleAction>(GetStaticProperty(GetType("DeliveryRuleActionType"), "CacheExpiration"), "foo1", null) }},
                    new Dog { DogKind = DogKind.GermanShepherd }, $"Foo{Environment.NewLine}bar", new Dictionary<string, BinaryData>()
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
            var condition = GetModel<DeliveryRuleQueryStringCondition>(GetStaticProperty(GetType("MatchVariable"), "QueryString"), "query", null,
                new QueryStringMatchConditionParameters(
                    QueryStringMatchConditionParametersTypeName.DeliveryRuleQueryStringConditionParameters,
                    QueryStringOperator.Any) { MatchValues = { $"firstline{Environment.NewLine}secondline", "val2" } });
            var actions =
                new[]
                {
                    GetModel<DeliveryRuleAction>(GetStaticProperty(GetType("DeliveryRuleActionType"), "CacheExpiration"), "foo1", null),
                    GetModel<DeliveryRuleAction>(GetStaticProperty(GetType("DeliveryRuleActionType"), "UrlSigning"), "foo2", null)
                };
            var data = new DeliveryRuleData
            {
                Properties = GetModel<DeliveryRuleProperties>(3, condition, actions,
                    new Dictionary<string, DeliveryRuleAction>()
                        {{ "dictionaryKey", GetModel<DeliveryRuleAction>(GetStaticProperty(GetType("DeliveryRuleActionType"), "CacheExpiration"), "foo1", null) }},
                    new Dog { DogKind = DogKind.GermanShepherd }, $"Foo{Environment.NewLine}bar", new Dictionary<string, BinaryData>()
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
