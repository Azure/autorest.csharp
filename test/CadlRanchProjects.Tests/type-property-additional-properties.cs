using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _Type.Property.AdditionalProperties;
using _Type.Property.AdditionalProperties.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class TypePropertyAdditionalPropertiesTests : CadlRanchTestBase
    {
        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsFloat_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsFloatClient().GetExtendsFloatAsync();
            var value = response.Value;
            Assert.AreEqual(43.125f, value.Id);
            CollectionAssert.AreEquivalent(new Dictionary<string, float>
            {
                ["prop"] = 43.125f,
            }, value.AdditionalProperties);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsFloat_put() => Test(async (host) =>
        {
            var value = new ExtendsFloatAdditionalProperties(43.125f)
            {
                AdditionalProperties =
                {
                    ["prop"] = 43.125f
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsFloatClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsFloat_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsFloatClient().GetIsFloatAsync();
            var value = response.Value;
            Assert.AreEqual(43.125f, value.Id);
            CollectionAssert.AreEquivalent(new Dictionary<string, float>
            {
                ["prop"] = 43.125f,
            }, value.AdditionalProperties);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsFloat_put() => Test(async (host) =>
        {
            var value = new IsFloatAdditionalProperties(43.125f)
            {
                AdditionalProperties =
                {
                    ["prop"] = 43.125f
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsFloatClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsModel_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsModelClient().GetExtendsModelAsync();
            var value = response.Value;
            Assert.AreEqual(1, value.AdditionalProperties.Count);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop"));
            var model = ModelReaderWriter.Read<ModelForRecord>(value.AdditionalProperties["prop"]);
            Assert.AreEqual("ok", model.State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsModel_put() => Test(async (host) =>
        {
            var value = new ExtendsModelAdditionalProperties(new ModelForRecord("ok"))
            {
                AdditionalProperties =
                {
                    ["prop"] = ModelReaderWriter.Write(new ModelForRecord("ok"))
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsModelClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsModel_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsModelClient().GetIsModelAsync();
            var value = response.Value;
            Assert.AreEqual(1, value.AdditionalProperties.Count);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop"));
            var model = ModelReaderWriter.Read<ModelForRecord>(value.AdditionalProperties["prop"]);
            Assert.AreEqual("ok", model.State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsModel_put() => Test(async (host) =>
        {
            var value = new IsModelAdditionalProperties(new ModelForRecord("ok"))
            {
                AdditionalProperties =
                {
                    ["prop"] = ModelReaderWriter.Write(new ModelForRecord("ok"))
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsModelClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsModelArray_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsModelArrayClient().GetExtendsModelArrayAsync();
            var value = response.Value;
            Assert.AreEqual(1, value.AdditionalProperties.Count);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop"));
            var prop = value.AdditionalProperties["prop"].Select(item => ModelReaderWriter.Read<ModelForRecord>(item)).ToList();
            Assert.AreEqual(2, prop.Count);
            Assert.AreEqual("ok", prop[0].State);
            Assert.AreEqual("ok", prop[1].State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsModelArray_put() => Test(async (host) =>
        {
            var value = new ExtendsModelArrayAdditionalProperties(new[] { new ModelForRecord("ok"), new ModelForRecord("ok") })
            {
                AdditionalProperties =
                {
                    ["prop"] = new[]
                    {
                        ModelReaderWriter.Write(new ModelForRecord("ok")),
                        ModelReaderWriter.Write(new ModelForRecord("ok"))
                    }
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsModelArrayClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsModelArray_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsModelArrayClient().GetIsModelArrayAsync();
            var value = response.Value;
            Assert.AreEqual(1, value.AdditionalProperties.Count);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop"));
            var prop = value.AdditionalProperties["prop"].Select(item => ModelReaderWriter.Read<ModelForRecord>(item)).ToList();
            Assert.AreEqual(2, prop.Count);
            Assert.AreEqual("ok", prop[0].State);
            Assert.AreEqual("ok", prop[1].State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsModelArray_put() => Test(async (host) =>
        {
            var value = new IsModelArrayAdditionalProperties(new[] { new ModelForRecord("ok"), new ModelForRecord("ok") })
            {
                AdditionalProperties =
                {
                    ["prop"] = new[]
                    {
                        ModelReaderWriter.Write(new ModelForRecord("ok")),
                        ModelReaderWriter.Write(new ModelForRecord("ok"))
                    }
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsModelArrayClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsString_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsStringClient().GetExtendsStringAsync();
            var value = response.Value;
            Assert.AreEqual("ExtendsStringAdditionalProperties", value.Name);
            CollectionAssert.AreEquivalent(new Dictionary<string, string>
            {
                ["prop"] = "abc"
            }, value.AdditionalProperties);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsString_put() => Test(async (host) =>
        {
            var value = new ExtendsStringAdditionalProperties("ExtendsStringAdditionalProperties")
            {
                AdditionalProperties =
                {
                    ["prop"] = "abc"
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsStringClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsString_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsStringClient().GetIsStringAsync();
            var value = response.Value;
            Assert.AreEqual("IsStringAdditionalProperties", value.Name);
            CollectionAssert.AreEquivalent(new Dictionary<string, string>
            {
                ["prop"] = "abc"
            }, value.AdditionalProperties);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsString_put() => Test(async (host) =>
        {
            var value = new IsStringAdditionalProperties("IsStringAdditionalProperties")
            {
                AdditionalProperties =
                {
                    ["prop"] = "abc"
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsStringClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsUnknown_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownClient().GetExtendsUnknownAsync();
            var value = response.Value;
            Assert.AreEqual("ExtendsUnknownAdditionalProperties", value.Name);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop1"));
            Assert.AreEqual(32, value.AdditionalProperties["prop1"].ToObjectFromJson<int>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop2"));
            Assert.AreEqual(true, value.AdditionalProperties["prop2"].ToObjectFromJson<bool>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop3"));
            Assert.AreEqual("abc", value.AdditionalProperties["prop3"].ToObjectFromJson<string>());
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsUnknown_put() => Test(async (host) =>
        {
            var value = new ExtendsUnknownAdditionalProperties("ExtendsUnknownAdditionalProperties")
            {
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson(32),
                    ["prop2"] = BinaryData.FromObjectAsJson(true),
                    ["prop3"] = BinaryData.FromObjectAsJson("abc")
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsUnknownDerived_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownDerivedClient().GetExtendsUnknownDerivedAsync();
            var value = response.Value;
            Assert.AreEqual("ExtendsUnknownAdditionalProperties", value.Name);
            Assert.AreEqual(314, value.Index);
            Assert.AreEqual(2.71828f, value.Age);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop1"));
            Assert.AreEqual(32, value.AdditionalProperties["prop1"].ToObjectFromJson<int>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop2"));
            Assert.AreEqual(true, value.AdditionalProperties["prop2"].ToObjectFromJson<bool>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop3"));
            Assert.AreEqual("abc", value.AdditionalProperties["prop3"].ToObjectFromJson<string>());
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsUnknownDerived_put() => Test(async (host) =>
        {
            var value = new ExtendsUnknownAdditionalPropertiesDerived("ExtendsUnknownAdditionalProperties", 314)
            {
                Age = 2.71828f,
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson(32),
                    ["prop2"] = BinaryData.FromObjectAsJson(true),
                    ["prop3"] = BinaryData.FromObjectAsJson("abc")
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownDerivedClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsUnknownDiscriminated_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownDiscriminatedClient().GetExtendsUnknownDiscriminatedAsync();
            var value = response.Value;
            Assert.AreEqual("Derived", value.Name);
            Assert.AreEqual("derived", value.Kind);
            var derived = value as ExtendsUnknownAdditionalPropertiesDiscriminatedDerived;
            Assert.IsNotNull(derived);
            Assert.AreEqual(314, derived.Index);
            Assert.AreEqual(2.71828f, derived.Age);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop1"));
            Assert.AreEqual(32, value.AdditionalProperties["prop1"].ToObjectFromJson<int>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop2"));
            Assert.AreEqual(true, value.AdditionalProperties["prop2"].ToObjectFromJson<bool>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop3"));
            Assert.AreEqual("abc", value.AdditionalProperties["prop3"].ToObjectFromJson<string>());
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsUnknownDiscriminated_put() => Test(async (host) =>
        {
            var value = new ExtendsUnknownAdditionalPropertiesDiscriminatedDerived("Derived", 314)
            {
                Age = 2.71828f,
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson(32),
                    ["prop2"] = BinaryData.FromObjectAsJson(true),
                    ["prop3"] = BinaryData.FromObjectAsJson("abc")
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsUnknownDiscriminatedClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsUnknown_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownClient().GetIsUnknownAsync();
            var value = response.Value;
            Assert.AreEqual("IsUnknownAdditionalProperties", value.Name);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop1"));
            Assert.AreEqual(32, value.AdditionalProperties["prop1"].ToObjectFromJson<int>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop2"));
            Assert.AreEqual(true, value.AdditionalProperties["prop2"].ToObjectFromJson<bool>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop3"));
            Assert.AreEqual("abc", value.AdditionalProperties["prop3"].ToObjectFromJson<string>());
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsUnknown_put() => Test(async (host) =>
        {
            var value = new IsUnknownAdditionalProperties("IsUnknownAdditionalProperties")
            {
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson(32),
                    ["prop2"] = BinaryData.FromObjectAsJson(true),
                    ["prop3"] = BinaryData.FromObjectAsJson("abc")
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsUnknownDerived_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownDerivedClient().GetIsUnknownDerivedAsync();
            var value = response.Value;
            Assert.AreEqual("IsUnknownAdditionalProperties", value.Name);
            Assert.AreEqual(314, value.Index);
            Assert.AreEqual(2.71828f, value.Age);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop1"));
            Assert.AreEqual(32, value.AdditionalProperties["prop1"].ToObjectFromJson<int>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop2"));
            Assert.AreEqual(true, value.AdditionalProperties["prop2"].ToObjectFromJson<bool>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop3"));
            Assert.AreEqual("abc", value.AdditionalProperties["prop3"].ToObjectFromJson<string>());
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsUnknownDerived_put() => Test(async (host) =>
        {
            var value = new IsUnknownAdditionalPropertiesDerived("IsUnknownAdditionalProperties", 314)
            {
                Age = 2.71828f,
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson(32),
                    ["prop2"] = BinaryData.FromObjectAsJson(true),
                    ["prop3"] = BinaryData.FromObjectAsJson("abc")
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownDerivedClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsUnknownDiscriminated_get() => Test(async (host) =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownDiscriminatedClient().GetIsUnknownDiscriminatedAsync();
            var value = response.Value;
            Assert.AreEqual("Derived", value.Name);
            Assert.AreEqual("derived", value.Kind);
            var derived = value as IsUnknownAdditionalPropertiesDiscriminatedDerived;
            Assert.IsNotNull(derived);
            Assert.AreEqual(314, derived.Index);
            Assert.AreEqual(2.71828f, derived.Age);
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop1"));
            Assert.AreEqual(32, value.AdditionalProperties["prop1"].ToObjectFromJson<int>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop2"));
            Assert.AreEqual(true, value.AdditionalProperties["prop2"].ToObjectFromJson<bool>());
            Assert.IsTrue(value.AdditionalProperties.ContainsKey("prop3"));
            Assert.AreEqual("abc", value.AdditionalProperties["prop3"].ToObjectFromJson<string>());
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsUnknownDiscriminated_put() => Test(async (host) =>
        {
            var value = new IsUnknownAdditionalPropertiesDiscriminatedDerived("Derived", 314)
            {
                Age = 2.71828f,
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson(32),
                    ["prop2"] = BinaryData.FromObjectAsJson(true),
                    ["prop3"] = BinaryData.FromObjectAsJson("abc")
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetIsUnknownDiscriminatedClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsDifferentSpreadFloat_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadFloatClient().GetExtendsDifferentSpreadFloatAsync();
            Assert.AreEqual("abc", response.Value.Name);
            Assert.AreEqual(43.125f, response.Value.DerivedProp);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual(43.125f, response.Value.AdditionalProperties["prop"]);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsDifferentSpreadFloat_put() => Test(async host =>
        {
            var value = new DifferentSpreadFloatDerived("abc", 43.125f)
            {
                AdditionalProperties =
                {
                    ["prop"] = 43.125f
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadFloatClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsDifferentSpreadModel_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadModelClient().GetExtendsDifferentSpreadModelAsync();
            Assert.AreEqual("abc", response.Value.KnownProp);
            Assert.IsNotNull(response.Value.DerivedProp);
            Assert.AreEqual("ok", response.Value.DerivedProp.State);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            var prop = ModelReaderWriter.Read<ModelForRecord>(response.Value.AdditionalProperties["prop"]);
            Assert.AreEqual("ok", prop.State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsDifferentSpreadModel_put() => Test(async host =>
        {
            var value = new DifferentSpreadModelDerived("abc", new ModelForRecord("ok"))
            {
                AdditionalProperties =
                {
                    ["prop"] = ModelReaderWriter.Write(new ModelForRecord("ok"))
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadModelClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsDifferentSpreadModelArray_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadModelArrayClient().GetExtendsDifferentSpreadModelArrayAsync();
            Assert.AreEqual("abc", response.Value.KnownProp);
            Assert.AreEqual(2, response.Value.DerivedProp.Count);
            Assert.AreEqual("ok", response.Value.DerivedProp[0].State);
            Assert.AreEqual("ok", response.Value.DerivedProp[1].State);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            var list = response.Value.AdditionalProperties["prop"];
            Assert.AreEqual(2, list.Count);
            var prop1 = ModelReaderWriter.Read<ModelForRecord>(list[0]);
            Assert.AreEqual("ok", prop1.State);
            var prop2 = ModelReaderWriter.Read<ModelForRecord>(list[1]);
            Assert.AreEqual("ok", prop2.State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsDifferentSpreadModelArray_put() => Test(async host =>
        {
            var value = new DifferentSpreadModelArrayDerived("abc", new[] { new ModelForRecord("ok"), new ModelForRecord("ok") })
            {
                AdditionalProperties =
                {
                    ["prop"] = new[] { ModelReaderWriter.Write(new ModelForRecord("ok")), ModelReaderWriter.Write(new ModelForRecord("ok")) }
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadModelArrayClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsDifferentSpreadString_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadStringClient().GetExtendsDifferentSpreadStringAsync();
            Assert.AreEqual(43.125f, response.Value.Id);
            Assert.AreEqual("abc", response.Value.DerivedProp);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual("abc", response.Value.AdditionalProperties["prop"]);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsDifferentSpreadString_put() => Test(async host =>
        {
            var value = new DifferentSpreadStringDerived(43.125f, "abc")
            {
                AdditionalProperties =
                {
                    ["prop"] = "abc"
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetExtendsDifferentSpreadStringClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_MultipleSpread_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetMultipleSpreadClient().GetMultipleSpreadAsync();
            Assert.IsTrue(response.Value.Flag);
            Assert.AreEqual(2, response.Value.AdditionalProperties.Count);
            Assert.AreEqual("abc", response.Value.AdditionalProperties["prop1"].ToObjectFromJson<string>());
            Assert.AreEqual(43.125f, response.Value.AdditionalProperties["prop2"].ToObjectFromJson<float>());
        });

        [Test]
        public Task Type_Property_AdditionalProperties_MultipleSpread_put() => Test(async host =>
        {
            var value = new MultipleSpreadRecord(true)
            {
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson("abc"),
                    ["prop2"] = BinaryData.FromObjectAsJson(43.125f)
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetMultipleSpreadClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadDifferentFloat_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentFloatClient().GetSpreadDifferentFloatAsync();
            Assert.AreEqual("abc", response.Value.Name);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual(43.125f, response.Value.AdditionalProperties["prop"]);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadDifferentFloat_put() => Test(async host =>
        {
            var value = new DifferentSpreadFloatRecord("abc")
            {
                AdditionalProperties =
                {
                    ["prop"] = 43.125f
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentFloatClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadDifferentModel_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentModelClient().GetSpreadDifferentModelAsync();
            Assert.AreEqual("abc", response.Value.KnownProp);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            var model = ModelReaderWriter.Read<ModelForRecord>(response.Value.AdditionalProperties["prop"]);
            Assert.AreEqual("ok", model.State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadDifferentModel_put() => Test(async host =>
        {
            var value = new DifferentSpreadModelRecord("abc")
            {
                AdditionalProperties =
                {
                    ["prop"] = ModelReaderWriter.Write(new ModelForRecord("ok"))
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentModelClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadDifferentModelArray_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentModelArrayClient().GetSpreadDifferentModelArrayAsync();
            Assert.AreEqual("abc", response.Value.KnownProp);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            var list = response.Value.AdditionalProperties["prop"];
            Assert.AreEqual(2, list.Count);
            var first = ModelReaderWriter.Read<ModelForRecord>(list[0]);
            var second = ModelReaderWriter.Read<ModelForRecord>(list[1]);
            Assert.AreEqual("ok", first.State);
            Assert.AreEqual("ok", second.State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadDifferentModelArray_put() => Test(async host =>
        {
            var value = new DifferentSpreadModelArrayRecord("abc")
            {
                AdditionalProperties =
                {
                    ["prop"] = new[]
                    {
                        ModelReaderWriter.Write(new ModelForRecord("ok")),
                        ModelReaderWriter.Write(new ModelForRecord("ok"))
                    }
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentModelArrayClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadDifferentString_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentStringClient().GetSpreadDifferentStringAsync();
            Assert.AreEqual(43.125f, response.Value.Id);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual("abc", response.Value.AdditionalProperties["prop"]);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadDifferentString_put() => Test(async host =>
        {
            var value = new DifferentSpreadStringRecord(43.125f)
            {
                AdditionalProperties =
                {
                    ["prop"] = "abc"
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadDifferentStringClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadFloat_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadFloatClient().GetSpreadFloatAsync();
            Assert.AreEqual(43.125f, response.Value.Id);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual(43.125f, response.Value.AdditionalProperties["prop"]);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadFloat_put() => Test(async host =>
        {
            var value = new SpreadFloatRecord(43.125f)
            {
                AdditionalProperties =
                {
                    ["prop"] = 43.125f
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadFloatClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadModel_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadModelClient().GetSpreadModelAsync();
            Assert.AreEqual("ok", response.Value.KnownProp.State);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            var model = ModelReaderWriter.Read<ModelForRecord>(response.Value.AdditionalProperties["prop"]);
            Assert.AreEqual("ok", model.State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadModel_put() => Test(async host =>
        {
            var value = new SpreadModelRecord(new ModelForRecord("ok"))
            {
                AdditionalProperties =
                {
                    ["prop"] = ModelReaderWriter.Write(new ModelForRecord("ok"))
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadModelClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadModelArray_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadModelArrayClient().GetSpreadModelArrayAsync();
            Assert.AreEqual(2, response.Value.KnownProp.Count);
            Assert.AreEqual("ok", response.Value.KnownProp[0].State);
            Assert.AreEqual("ok", response.Value.KnownProp[1].State);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            var list = response.Value.AdditionalProperties["prop"];
            Assert.AreEqual(2, list.Count);
            var first = ModelReaderWriter.Read<ModelForRecord>(list[0]);
            var second = ModelReaderWriter.Read<ModelForRecord>(list[1]);
            Assert.AreEqual("ok", first.State);
            Assert.AreEqual("ok", second.State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadModelArray_put() => Test(async host =>
        {
            var value = new SpreadModelArrayRecord(new[] { new ModelForRecord("ok"), new ModelForRecord("ok") })
            {
                AdditionalProperties =
                {
                    ["prop"] = new[]
                    {
                        ModelReaderWriter.Write(new ModelForRecord("ok")),
                        ModelReaderWriter.Write(new ModelForRecord("ok"))
                    }
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadModelArrayClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadRecordDiscriminatedUnion_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordDiscriminatedUnionClient().GetSpreadRecordDiscriminatedUnionAsync();
            Assert.AreEqual("abc", response.Value.Name);
            Assert.AreEqual(2, response.Value.AdditionalProperties.Count);
            var prop1 = ModelReaderWriter.Read<WidgetData0>(response.Value.AdditionalProperties["prop1"]);
            Assert.AreEqual("abc", prop1.FooProp);
            var prop2 = ModelReaderWriter.Read<WidgetData1>(response.Value.AdditionalProperties["prop2"]);
            Assert.AreEqual(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero), prop2.Start);
            Assert.AreEqual(new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero), prop2.End);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadRecordDiscriminatedUnion_put() => Test(async host =>
        {
            var value = new SpreadRecordForDiscriminatedUnion("abc")
            {
                AdditionalProperties =
                {
                    ["prop1"] = ModelReaderWriter.Write(new WidgetData0("abc")),
                    ["prop2"] = ModelReaderWriter.Write(new WidgetData1(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero))
                    {
                        End = new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero)
                    })
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordDiscriminatedUnionClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadRecordNonDiscriminatedUnion_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordNonDiscriminatedUnionClient().GetSpreadRecordNonDiscriminatedUnionAsync();
            Assert.AreEqual("abc", response.Value.Name);
            Assert.AreEqual(2, response.Value.AdditionalProperties.Count);
            var prop1 = ModelReaderWriter.Read<WidgetData0>(response.Value.AdditionalProperties["prop1"]);
            Assert.AreEqual("abc", prop1.FooProp);
            var prop2 = ModelReaderWriter.Read<WidgetData1>(response.Value.AdditionalProperties["prop2"]);
            Assert.AreEqual(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero), prop2.Start);
            Assert.AreEqual(new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero), prop2.End);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadRecordNonDiscriminatedUnion_put() => Test(async host =>
        {
            var value = new SpreadRecordForNonDiscriminatedUnion("abc")
            {
                AdditionalProperties =
                {
                    ["prop1"] = ModelReaderWriter.Write(new WidgetData0("abc")),
                    ["prop2"] = ModelReaderWriter.Write(new WidgetData1(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero))
                    {
                        End = new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero)
                    })
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordNonDiscriminatedUnionClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadRecordNonDiscriminatedUnion2_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordNonDiscriminatedUnion2Client().GetSpreadRecordNonDiscriminatedUnion2Async();
            Assert.AreEqual("abc", response.Value.Name);
            Assert.AreEqual(2, response.Value.AdditionalProperties.Count);
            var prop1 = ModelReaderWriter.Read<WidgetData2>(response.Value.AdditionalProperties["prop1"]);
            Assert.AreEqual("2021-01-01T00:00:00Z", prop1.Start);
            var prop2 = ModelReaderWriter.Read<WidgetData1>(response.Value.AdditionalProperties["prop2"]);
            Assert.AreEqual(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero), prop2.Start);
            Assert.AreEqual(new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero), prop2.End);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadRecordNonDiscriminatedUnion2_put() => Test(async host =>
        {
            var value = new SpreadRecordForNonDiscriminatedUnion2("abc")
            {
                AdditionalProperties =
                {
                    ["prop1"] = ModelReaderWriter.Write(new WidgetData2("2021-01-01T00:00:00Z")),
                    ["prop2"] = ModelReaderWriter.Write(new WidgetData1(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero))
                    {
                        End = new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero)
                    })
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordNonDiscriminatedUnion2Client().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        [Ignore("Need to find a way to handle array's serialization/deserialization gracefully via MRW before we could enable this test")]
        public Task Type_Property_AdditionalProperties_SpreadRecordNonDiscriminatedUnion3_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordNonDiscriminatedUnion3Client().GetSpreadRecordNonDiscriminatedUnion3Async();
            Assert.AreEqual("abc", response.Value.Name);
            Assert.AreEqual(2, response.Value.AdditionalProperties.Count);
            var prop1 = (IList<WidgetData2>)ModelReaderWriter.Read(response.Value.AdditionalProperties["prop1"], typeof(IList<WidgetData2>));
            Assert.AreEqual(2, prop1.Count);
            Assert.AreEqual("2021-01-01T00:00:00Z", prop1[0].Start);
            Assert.AreEqual("2021-01-01T00:00:00Z", prop1[1].Start);
            var prop2 = ModelReaderWriter.Read<WidgetData1>(response.Value.AdditionalProperties["prop2"]);
            Assert.AreEqual(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero), prop2.Start);
            Assert.AreEqual(new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero), prop2.End);
        });

        [Test]
        [Ignore("Need to find a way to handle array's serialization/deserialization gracefully via MRW before we could enable this test")]
        public Task Type_Property_AdditionalProperties_SpreadRecordNonDiscriminatedUnion3_put() => Test(async host =>
        {
            var value = new SpreadRecordForNonDiscriminatedUnion3("abc")
            {
                AdditionalProperties =
                {
                    ["prop1"] = ModelReaderWriter.Write(new[] { new WidgetData2("2021-01-01T00:00:00Z"), new WidgetData2("2021-01-01T00:00:00Z") }),
                    ["prop2"] = ModelReaderWriter.Write(new WidgetData1(new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero))
                    {
                        End = new DateTimeOffset(2021, 1, 2, 0, 0, 0, TimeSpan.Zero)
                    })
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordNonDiscriminatedUnion3Client().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadRecordUnion_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordUnionClient().GetSpreadRecordUnionAsync();
            Assert.IsTrue(response.Value.Flag);
            Assert.AreEqual(2, response.Value.AdditionalProperties.Count);
            Assert.AreEqual("abc", response.Value.AdditionalProperties["prop1"].ToObjectFromJson<string>());
            Assert.AreEqual(43.125f, response.Value.AdditionalProperties["prop2"].ToObjectFromJson<float>());
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadRecordUnion_put() => Test(async host =>
        {
            var value = new SpreadRecordForUnion(true)
            {
                AdditionalProperties =
                {
                    ["prop1"] = BinaryData.FromObjectAsJson("abc"),
                    ["prop2"] = BinaryData.FromObjectAsJson(43.125f)
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadRecordUnionClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadString_get() => Test(async host =>
        {
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadStringClient().GetSpreadStringAsync();
            Assert.AreEqual("SpreadSpringRecord", response.Value.Name);
            Assert.AreEqual(1, response.Value.AdditionalProperties.Count);
            Assert.AreEqual("abc", response.Value.AdditionalProperties["prop"]);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_SpreadString_put() => Test(async host =>
        {
            var value = new SpreadStringRecord("SpreadSpringRecord")
            {
                AdditionalProperties =
                {
                    ["prop"] = "abc"
                }
            };
            var response = await new AdditionalPropertiesClient(host, null).GetSpreadStringClient().PutAsync(value);
            Assert.AreEqual(204, response.Status);
        });
    }
}
