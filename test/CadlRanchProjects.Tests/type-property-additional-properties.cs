﻿using System;
using System.Collections.Generic;
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
            Assert.AreEqual(42.42f, value.Id);
            CollectionAssert.AreEquivalent(new Dictionary<string, float>
            {
                ["prop"] = 42.42f,
            }, value.AdditionalProperties);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsFloat_put() => Test(async (host) =>
        {
            var value = new ExtendsFloatAdditionalProperties(42.42f)
            {
                AdditionalProperties =
                {
                    ["prop"] = 42.42f
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
            Assert.AreEqual(42.42f, value.Id);
            CollectionAssert.AreEquivalent(new Dictionary<string, float>
            {
                ["prop"] = 42.42f,
            }, value.AdditionalProperties);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsFloat_put() => Test(async (host) =>
        {
            var value = new IsFloatAdditionalProperties(42.42f)
            {
                AdditionalProperties =
                {
                    ["prop"] = 42.42f
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
            var model = value.AdditionalProperties["prop"];
            Assert.AreEqual("ok", model.State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsModel_put() => Test(async (host) =>
        {
            var value = new ExtendsModelAdditionalProperties()
            {
                AdditionalProperties =
                {
                    ["prop"] = new ModelForRecord("ok")
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
            var model = value.AdditionalProperties["prop"];
            Assert.AreEqual("ok", model.State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsModel_put() => Test(async (host) =>
        {
            var value = new IsModelAdditionalProperties()
            {
                AdditionalProperties =
                {
                    ["prop"] = new ModelForRecord("ok")
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
            var prop = value.AdditionalProperties["prop"];
            Assert.AreEqual(2, prop.Count);
            Assert.AreEqual("ok", prop[0].State);
            Assert.AreEqual("ok", prop[1].State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_ExtendsModelArray_put() => Test(async (host) =>
        {
            var value = new ExtendsModelArrayAdditionalProperties()
            {
                AdditionalProperties =
                {
                    ["prop"] = new[]
                    {
                        new ModelForRecord("ok"),
                        new ModelForRecord("ok")
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
            var prop = value.AdditionalProperties["prop"];
            Assert.AreEqual(2, prop.Count);
            Assert.AreEqual("ok", prop[0].State);
            Assert.AreEqual("ok", prop[1].State);
        });

        [Test]
        public Task Type_Property_AdditionalProperties_IsModelArray_put() => Test(async (host) =>
        {
            var value = new IsModelArrayAdditionalProperties()
            {
                AdditionalProperties =
                {
                    ["prop"] = new[]
                    {
                        new ModelForRecord("ok"),
                        new ModelForRecord("ok")
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

        //[Test]
        //public Task Type_Property_Nullable_Duration_patchNull() => Test(async (host) =>
        //{
        //    string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
        //    var response = await new NullableClient(host, null).GetDurationClient().PatchNullAsync(RequestContent.Create(value));
        //    Assert.AreEqual(204, response.Status);
        //});

        //[Test]
        //public Task Type_Property_Nullable_CollectionsByte_getNonNull() => Test(async (host) =>
        //{
        //    var response = await new NullableClient(host, null).GetCollectionsByteClient().GetNonNullAsync();
        //    Assert.AreEqual("foo", response.Value.RequiredProperty);
        //    Assert.AreEqual(BinaryData.FromString("hello, world!").ToString(), response.Value.NullableProperty.First().ToString());
        //    Assert.AreEqual(BinaryData.FromString("hello, world!").ToString(), response.Value.NullableProperty.Last().ToString());
        //});

        //[Test]
        //public Task Type_Property_Nullable_CollectionsByte_getNull() => Test(async (host) =>
        //{
        //    var response = await new NullableClient(host, null).GetCollectionsByteClient().GetNullAsync();
        //    Assert.AreEqual("foo", response.Value.RequiredProperty);
        //    // we will never construct a null collection therefore this property is actually undefined here.
        //    Assert.IsNotNull(response.Value.NullableProperty);
        //    Assert.IsFalse(Optional.IsCollectionDefined(response.Value.NullableProperty));
        //});

        //[Test]
        //public Task Type_Property_Nullable_CollectionsByte_patchNonNull() => Test(async (host) =>
        //{
        //    var value = new
        //    {
        //        requiredProperty = "foo",
        //        nullableProperty = new[] { "aGVsbG8sIHdvcmxkIQ==", "aGVsbG8sIHdvcmxkIQ==" }
        //    };
        //    var response = await new NullableClient(host, null).GetCollectionsByteClient().PatchNonNullAsync(RequestContent.Create(value));
        //    Assert.AreEqual(204, response.Status);
        //});

        //[Test]
        //public Task Type_Property_Nullable_CollectionsByte_patchNull() => Test(async (host) =>
        //{
        //    string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
        //    var response = await new NullableClient(host, null).GetCollectionsByteClient().PatchNullAsync(RequestContent.Create(value));
        //    Assert.AreEqual(204, response.Status);
        //});

        //[Test]
        //public Task Type_Property_Nullable_CollectionsModel_getNonNull() => Test(async (host) =>
        //{
        //    var response = await new NullableClient(host, null).GetCollectionsModelClient().GetNonNullAsync();
        //    Assert.AreEqual("foo", response.Value.RequiredProperty);
        //    Assert.AreEqual("hello", response.Value.NullableProperty.First().Property);
        //    Assert.AreEqual("world", response.Value.NullableProperty.Last().Property);
        //});

        //[Test]
        //public Task Type_Property_Nullable_CollectionsModel_getNull() => Test(async (host) =>
        //{
        //    var response = await new NullableClient(host, null).GetCollectionsModelClient().GetNullAsync();
        //    Assert.AreEqual("foo", response.Value.RequiredProperty);
        //    // we will never construct a null collection therefore this property is actually undefined here.
        //    Assert.IsNotNull(response.Value.NullableProperty);
        //    Assert.IsFalse(Optional.IsCollectionDefined(response.Value.NullableProperty));
        //});

        //[Test]
        //public Task Type_Property_Nullable_CollectionsModel_patchNonNull() => Test(async (host) =>
        //{
        //    var value = new
        //    {
        //        requiredProperty = "foo",
        //        nullableProperty = new[]
        //        {
        //            new
        //            {
        //                property = "hello"
        //            },
        //            new
        //            {
        //                property = "world"
        //            }
        //        }
        //    };
        //    var response = await new NullableClient(host, null).GetCollectionsModelClient().PatchNonNullAsync(RequestContent.Create(value));
        //    Assert.AreEqual(204, response.Status);
        //});

        //[Test]
        //public Task Type_Property_Nullable_CollectionsModel_patchNull() => Test(async (host) =>
        //{
        //    string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
        //    var response = await new NullableClient(host, null).GetCollectionsModelClient().PatchNullAsync(RequestContent.Create(value));
        //    Assert.AreEqual(204, response.Status);
        //});
    }
}
