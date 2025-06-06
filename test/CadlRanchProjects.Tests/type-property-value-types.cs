﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using _Type.Property.ValueTypes;
using _Type.Property.ValueTypes.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class TypePropertyValueTypesTests : CadlRanchTestBase
    {
        [Test]
        public Task Type_Property_ValueTypes_Boolean_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetBooleanClient().GetBooleanAsync();
            Assert.AreEqual(true, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_Boolean_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetBooleanClient().PutAsync(new BooleanProperty(true));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_BooleanLiteral_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetBooleanLiteralClient().GetBooleanLiteralAsync();
            Assert.AreEqual(true, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_BooleanLiteral_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetBooleanLiteralClient().PutAsync(new BooleanLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_String_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetStringClient().GetStringAsync();
            Assert.AreEqual("hello", response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_String_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetStringClient().PutAsync(new StringProperty("hello"));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_StringLiteral_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetStringLiteralClient().GetStringLiteralAsync();
            Assert.AreEqual(StringLiteralPropertyProperty.Hello, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_StringLiteral_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetStringLiteralClient().PutAsync(new StringLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_Bytes_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetBytesClient().GetByteAsync();
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_Bytes_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetBytesClient().PutAsync(new BytesProperty(BinaryData.FromString("hello, world!")));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_Int_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetIntClient().GetIntAsync();
            Assert.AreEqual(42, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_Int_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetIntClient().PutAsync(new IntProperty(42));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_IntLiteral_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetIntLiteralClient().GetIntLiteralAsync();
            Assert.AreEqual(IntLiteralPropertyProperty._42, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_IntLiteral_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetIntLiteralClient().PutAsync(new IntLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_Float_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetFloatClient().GetFloatAsync();
            Assert.AreEqual(43.125f, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_Float_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetFloatClient().PutAsync(new FloatProperty((float)43.125));
            Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Type_Property_ValueTypes_FloatLiteral_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetFloatLiteralClient().GetFloatLiteralAsync();
            Assert.AreEqual(FloatLiteralPropertyProperty._43125, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_FloatLiteral_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetFloatLiteralClient().PutAsync(new FloatLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_Datetime_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDatetimeClient().GetDatetimeAsync();
            Assert.AreEqual(DateTimeOffset.Parse("2022-08-26T18:38:00Z"), response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_Datetime_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetDatetimeClient().PutAsync(new DatetimeProperty(DateTimeOffset.Parse("2022-08-26T18:38:00Z")));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_Duration_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDurationClient().GetDurationAsync();
            Assert.AreEqual(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_Duration_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetDurationClient().PutAsync(new DurationProperty(XmlConvert.ToTimeSpan("P123DT22H14M12.011S")));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_Enum_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetEnumClient().GetEnumAsync();
            Assert.AreEqual(FixedInnerEnum.ValueOne, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_Enum_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetEnumClient().PutAsync(new EnumProperty(FixedInnerEnum.ValueOne));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_ExtensibleEnum_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetExtensibleEnumClient().GetExtensibleEnumAsync();
            Assert.AreEqual(new InnerEnum("UnknownValue"), response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_ExtensibleEnum_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetExtensibleEnumClient().PutAsync(new ExtensibleEnumProperty(new InnerEnum("UnknownValue")));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_Model_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetModelClient().GetModelAsync();
            Assert.AreEqual("hello", response.Value.Property.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_Model_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetModelClient().PutAsync(new ModelProperty(new InnerModel("hello")));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_CollectionsString_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsStringClient().GetCollectionsStringAsync();
            CollectionAssert.AreEqual(new[] { "hello", "world" }, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_CollectionsString_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetCollectionsStringClient().PutAsync(new CollectionsStringProperty(new[] { "hello", "world" }));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_CollectionsInt_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsIntClient().GetCollectionsIntAsync();
            CollectionAssert.AreEqual(new[] { 1, 2 }, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_CollectionsInt_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetCollectionsIntClient().PutAsync(new CollectionsIntProperty(new[] { 1, 2 }));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_CollectionsModel_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsModelClient().GetCollectionsModelAsync();
            var result = response.Value;
            Assert.AreEqual("hello", result.Property[0].Property);
            Assert.AreEqual("world", result.Property[1].Property);
            Assert.AreEqual(2, result.Property.Count);
        });

        [Test]
        public Task Type_Property_ValueTypes_CollectionsModel_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetCollectionsModelClient().PutAsync(new CollectionsModelProperty(new[] { new InnerModel("hello"), new InnerModel("world") }));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_DictionaryString_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDictionaryStringClient().GetDictionaryStringAsync();
            var result = response.Value;
            Assert.AreEqual("hello", result.Property["k1"]);
            Assert.AreEqual("world", result.Property["k2"]);
            Assert.AreEqual(2, result.Property.Count);
        });

        [Test]
        public Task Type_Property_ValueTypes_DictionaryString_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetDictionaryStringClient().PutAsync(new DictionaryStringProperty(new Dictionary<string, string> { ["k1"] = "hello", ["k2"] = "world" }));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_Never_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetNeverClient().GetNeverAsync();
            var result = response.Value;
            Assert.NotNull(result);
        });

        [Test]
        public Task Type_Property_ValueTypes_Never_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetNeverClient().PutAsync(new NeverProperty());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_UnknownString_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownStringClient().GetUnknownStringAsync();
            Assert.AreEqual("hello", response.Value.Property.ToObjectFromJson());
        });

        [Test]
        public Task Type_Property_ValueTypes_UnknownString_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetUnknownStringClient().PutAsync(new UnknownStringProperty(new BinaryData("\"hello\"")));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_UnknownInt_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownIntClient().GetUnknownIntAsync();
            Assert.AreEqual(42, response.Value.Property.ToObjectFromJson());
        });

        [Test]
        public Task Type_Property_ValueTypes_UnknownInt_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetUnknownIntClient().PutAsync(new UnknownIntProperty(new BinaryData(42)));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_UnknownDict_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownDictClient().GetUnknownDictAsync();
            var result = response.Value.Property.ToObjectFromJson() as Dictionary<string, object>;
            Assert.IsNotNull(result);
            Assert.AreEqual("hello", result["k1"]);
            Assert.AreEqual(42, result["k2"]);
            Assert.AreEqual(2, result.Count);
        });

        [Test]
        public Task Type_Property_ValueTypes_UnknownDict_put() => Test(async (host) =>
        {
            var input = new Dictionary<string, object>()
            {
                {"k1", "hello" },
                {"k2", 42 }
            };

            Response response = await new ValueTypesClient(host, null).GetUnknownDictClient().PutAsync(new UnknownDictProperty(new BinaryData(input)));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_UnknownArray_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownArrayClient().GetUnknownArrayAsync();
            var result = response.Value.Property.ToObjectFromJson() as object[];
            Assert.IsNotNull(result);
            Assert.AreEqual("hello", result[0]);
            Assert.AreEqual("world", result[1]);
            Assert.AreEqual(2, result.Length);
        });

        [Test]
        public Task Type_Property_ValueTypes_UnknownArray_put() => Test(async (host) =>
        {
            var input = new[] { "hello", "world" };

            Response response = await new ValueTypesClient(host, null).GetUnknownArrayClient().PutAsync(new UnknownArrayProperty(new BinaryData(input)));
            Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Type_Property_ValueTypes_Decimal_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDecimalClient().GetDecimalAsync();
            Assert.AreEqual(0.33333m, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_Decimal_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetDecimalClient().PutAsync(new DecimalProperty(0.33333m));
            Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Type_Property_ValueTypes_Decimal128_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDecimal128Client().GetDecimal128Async();
            Assert.AreEqual(0.33333m, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_Decimal128_put() => Test(async (host) =>
        {
            Response response = await new ValueTypesClient(host, null).GetDecimal128Client().PutAsync(new Decimal128Property(0.33333m));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_UnionEnumValue_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionEnumValueClient().GetUnionEnumValueAsync();
            Assert.AreEqual(ExtendedEnum.EnumValue2, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_UnionEnumValue_put() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionEnumValueClient().PutAsync(new UnionEnumValueProperty());
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_UnionFloatLiteral_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionFloatLiteralClient().GetUnionFloatLiteralAsync();
            var actual = response.Value.Property;
            Assert.AreEqual(UnionFloatLiteralPropertyProperty._46875, actual);
        });

        [Test]
        public Task Type_Property_ValueTypes_UnionFloatLiteral_put() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionFloatLiteralClient().PutAsync(new UnionFloatLiteralProperty(UnionFloatLiteralPropertyProperty._46875));
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_Property_ValueTypes_UnionIntLiteral_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionIntLiteralClient().GetUnionIntLiteralAsync();
            Assert.AreEqual(UnionIntLiteralPropertyProperty._42, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_UnionIntLiteral_put() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionIntLiteralClient().PutAsync(new UnionIntLiteralProperty(UnionIntLiteralPropertyProperty._42));
            Assert.AreEqual(204, response.Status);
        });
        [Test]
        public Task Type_Property_ValueTypes_UnionStringLiteral_get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionStringLiteralClient().GetUnionStringLiteralAsync();
            Assert.AreEqual(UnionStringLiteralPropertyProperty.World, response.Value.Property);
        });

        [Test]
        public Task Type_Property_ValueTypes_UnionStringLiteral_put() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionStringLiteralClient().PutAsync(new UnionStringLiteralProperty(UnionStringLiteralPropertyProperty.World));
            Assert.AreEqual(204, response.Status);
        });
    }
}
