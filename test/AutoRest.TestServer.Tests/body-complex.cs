// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using AutoRest.TestServer.Tests.Infrastructure;
using body_complex;
using body_complex.Models.V20160229;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class BodyComplexTest: TestServerTestBase
    {
        public BodyComplexTest(TestServerVersion version) : base(version, "complex") { }

        [Test]
        public Task GetComplexBasicValid() => Test(async (host, pipeline) =>
        {
            var result = await BasicOperations.GetValidAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("abc", result.Value.Name);
            Assert.AreEqual(2, result.Value.Id);
            Assert.AreEqual(CMYKColors.YELLOW, result.Value.Color);
        });

        [Test]
        public Task PutComplexBasicValid() => TestStatus(async (host, pipeline) =>
        {
            var value = new Basic
            {
                Name = "abc",
                Id = 2,
                Color = CMYKColors.Magenta
            };
            return await BasicOperations.PutValidAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexBasicEmpty() => Test(async (host, pipeline) =>
        {
            var result = await BasicOperations.GetEmptyAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(null, result.Value.Name);
            Assert.AreEqual(null, result.Value.Id);
            Assert.AreEqual(null, result.Value.Color);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/299")]
        public Task GetComplexBasicNotProvided() => Test(async (host, pipeline) =>
        {
            var result = await BasicOperations.GetNotProvidedAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(null, result.Value.Name);
            Assert.AreEqual(null, result.Value.Id);
            Assert.AreEqual(null, result.Value.Color);
        });

        [Test]
        public Task GetComplexBasicNull() => Test(async (host, pipeline) =>
        {
            var result = await BasicOperations.GetNullAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(null, result.Value.Name);
            Assert.AreEqual(null, result.Value.Id);
            Assert.AreEqual(null, result.Value.Color);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/300")]
        public Task GetComplexBasicInvalid() => Test(async (host, pipeline) =>
        {
            var result = await BasicOperations.GetInvalidAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(null, result.Value.Name);
            Assert.AreEqual(null, result.Value.Id);
            Assert.AreEqual(null, result.Value.Color);
        });

        [Test]
        public void CheckComplexPrimitiveInteger()
        {
            var properties = typeof(IntWrapper).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(typeof(int?), properties.First(p => p.Name == "Field1").PropertyType);
            Assert.AreEqual(typeof(int?), properties.First(p => p.Name == "Field2").PropertyType);
        }

        [Test]
        public Task GetComplexPrimitiveInteger() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetIntAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(-1, result.Value.Field1);
            Assert.AreEqual(2, result.Value.Field2);
        });

        [Test]
        public Task PutComplexPrimitiveInteger() => TestStatus(async (host, pipeline) =>
        {
            var value = new IntWrapper
            {
                Field1 = -1,
                Field2 = 2
            };
            return await PrimitiveOperations.PutIntAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public void CheckComplexPrimitiveLong()
        {
            var properties = typeof(LongWrapper).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(typeof(long?), properties.First(p => p.Name == "Field1").PropertyType);
            Assert.AreEqual(typeof(long?), properties.First(p => p.Name == "Field2").PropertyType);
        }

        [Test]
        public Task GetComplexPrimitiveLong() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetLongAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(1099511627775L, result.Value.Field1);
            Assert.AreEqual(-999511627788L, result.Value.Field2);
        });

        [Test]
        public Task PutComplexPrimitiveLong() => TestStatus(async (host, pipeline) =>
        {
            var value = new LongWrapper
            {
                Field1 = 1099511627775L,
                Field2 = -999511627788L
            };
            return await PrimitiveOperations.PutLongAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public void CheckComplexPrimitiveFloat()
        {
            var properties = typeof(FloatWrapper).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(typeof(float?), properties.First(p => p.Name == "Field1").PropertyType);
            Assert.AreEqual(typeof(float?), properties.First(p => p.Name == "Field2").PropertyType);
        }

        [Test]
        public Task GetComplexPrimitiveFloat() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetFloatAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(1.05F, result.Value.Field1);
            Assert.AreEqual(-0.003F, result.Value.Field2);
        });

        [Test]
        public Task PutComplexPrimitiveFloat() => TestStatus(async (host, pipeline) =>
        {
            var value = new FloatWrapper
            {
                Field1 = 1.05F,
                Field2 = -0.003F
            };
            return await PrimitiveOperations.PutFloatAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public void CheckComplexPrimitiveDouble()
        {
            var properties = typeof(DoubleWrapper).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Assert.AreEqual(typeof(double?), properties.First(p => p.Name == "Field1").PropertyType);
            Assert.AreEqual(typeof(double?), properties.First(p => p.Name == "Field56ZerosAfterTheDotAndNegativeZeroBeforeDotAndThisIsALongFieldNameOnPurpose").PropertyType);
        }

        [Test]
        public Task GetComplexPrimitiveDouble() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetDoubleAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(3e-100D, result.Value.Field1);
            Assert.AreEqual(-0.000000000000000000000000000000000000000000000000000000005D, result.Value.Field56ZerosAfterTheDotAndNegativeZeroBeforeDotAndThisIsALongFieldNameOnPurpose);
        });

        [Test]
        public Task PutComplexPrimitiveDouble() => TestStatus(async (host, pipeline) =>
        {
            var value = new DoubleWrapper
            {
                Field1 = 3e-100D,
                Field56ZerosAfterTheDotAndNegativeZeroBeforeDotAndThisIsALongFieldNameOnPurpose = -0.000000000000000000000000000000000000000000000000000000005D
            };
            return await PrimitiveOperations.PutDoubleAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexPrimitiveBool() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetBoolAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(true, result.Value.FieldTrue);
            Assert.AreEqual(false, result.Value.FieldFalse);
        });

        [Test]
        public Task PutComplexPrimitiveBool() => TestStatus(async (host, pipeline) =>
        {
            var value = new BooleanWrapper
            {
                FieldTrue = true,
                FieldFalse = false
            };
            return await PrimitiveOperations.PutBoolAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexPrimitiveString() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetStringAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("goodrequest", result.Value.Field);
            Assert.AreEqual(string.Empty, result.Value.Empty);
            Assert.AreEqual(null, result.Value.NullProperty);
        });

        [Test]
        public Task PutComplexPrimitiveString() => TestStatus(async (host, pipeline) =>
        {
            var value = new StringWrapper
            {
                Field = "goodrequest",
                Empty = string.Empty,
                NullProperty = null
            };
            return await PrimitiveOperations.PutStringAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexPrimitiveDate() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetDateAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(DateTimeOffset.Parse("0001-01-01"), result.Value.Field);
            Assert.AreEqual(DateTimeOffset.Parse("2016-02-29"), result.Value.Leap);
        });

        [Test]
        public Task PutComplexPrimitiveDate() => TestStatus(async (host, pipeline) =>
        {
            var value = new DateWrapper
            {
                Field = DateTimeOffset.Parse("0001-01-01"),
                Leap = DateTimeOffset.Parse("2016-02-29")
            };
            return await PrimitiveOperations.PutDateAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexPrimitiveDateTime() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetDateTimeAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(DateTimeOffset.Parse("0001-01-01T00:00:00Z"), result.Value.Field);
            Assert.AreEqual(DateTimeOffset.Parse("2015-05-18T18:38:00Z"), result.Value.Now);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "404 response not found")]
        public Task PutComplexPrimitiveDateTime() => TestStatus(async (host, pipeline) =>
        {
            var value = new DatetimeWrapper
            {
                Field = DateTimeOffset.Parse("0001-01-01T00:00:00Z"),
                Now = DateTimeOffset.Parse("2015-05-18T18:38:00Z")
            };
            return await PrimitiveOperations.PutDateTimeAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexPrimitiveDateTimeRfc1123() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetDateTimeRfc1123Async(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(DateTimeOffset.Parse("Mon, 01 Jan 0001 00:00:00 GMT"), result.Value.Field);
            Assert.AreEqual(DateTimeOffset.Parse("Mon, 18 May 2015 11:38:00 GMT"), result.Value.Now);
        });

        [Test]
        public Task PutComplexPrimitiveDateTimeRfc1123() => TestStatus(async (host, pipeline) =>
        {
            var value = new Datetimerfc1123Wrapper
            {
                Field = DateTimeOffset.Parse("Mon, 01 Jan 0001 00:00:00 GMT"),
                Now = DateTimeOffset.Parse("Mon, 18 May 2015 11:38:00 GMT")
            };
            return await PrimitiveOperations.PutDateTimeRfc1123Async(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexPrimitiveDuration() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetDurationAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), result.Value.Field);
        });

        [Test]
        public Task PutComplexPrimitiveDuration() => TestStatus(async (host, pipeline) =>
        {
            var value = new DurationWrapper
            {
                Field = XmlConvert.ToTimeSpan("P123DT22H14M12.011S")
            };
            return await PrimitiveOperations.PutDurationAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexPrimitiveByte() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetByteAsync(ClientDiagnostics, pipeline, host);
            var content = new byte[] { 0xFF, 0xFE, 0xFD, 0xFC, 0x00, 0xFA, 0xF9, 0xF8, 0xF7, 0xF6 };
            Assert.AreEqual(content, result.Value.Field);
        });

        [Test]
        public Task PutComplexPrimitiveByte() => TestStatus(async (host, pipeline) =>
        {
            var content = new byte[] { 0xFF, 0xFE, 0xFD, 0xFC, 0x00, 0xFA, 0xF9, 0xF8, 0xF7, 0xF6 };
            var value = new ByteWrapper
            {
                Field = content
            };
            return await PrimitiveOperations.PutByteAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexArrayValid() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetValidAsync(ClientDiagnostics, pipeline, host);
            var content = new[] { "1, 2, 3, 4", string.Empty, null, "&S#$(*Y", "The quick brown fox jumps over the lazy dog" };
            Assert.AreEqual(content, result.Value.Array);
        });

        [Test]
        public Task PutComplexArrayValid() => TestStatus(async (host, pipeline) =>
        {
            var value = new ArrayWrapper();
            value.Array = new[] { "1, 2, 3, 4", string.Empty, null, "&S#$(*Y", "The quick brown fox jumps over the lazy dog" };
            return await ArrayOperations.PutValidAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexArrayEmpty() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetEmptyAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(new string[0], result.Value.Array);
        });

        [Test]
        public Task PutComplexArrayEmpty() => TestStatus(async (host, pipeline) =>
        {
            var value = new ArrayWrapper();
            value.Array = new List<string>();
            return await ArrayOperations.PutEmptyAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexArrayNotProvided() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetNotProvidedAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.GetRawResponse().Status);
            Assert.AreEqual(null, result.Value.Array);
        });

        [Test]
        public Task GetComplexDictionaryValid() => Test(async (host, pipeline) =>
        {
            var result = await DictionaryOperations.GetValidAsync(ClientDiagnostics, pipeline, host);
            var content = new Dictionary<string, string?>
            {
                { "txt", "notepad" },
                { "bmp", "mspaint" },
                { "xls", "excel" },
                { "exe", string.Empty },
                { string.Empty, null }
            };
            Assert.AreEqual(content, result.Value.DefaultProgram);
        });

        [Test]
        public Task PutComplexDictionaryValid() => TestStatus(async (host, pipeline) =>
        {
            var value = new DictionaryWrapper();
            value.DefaultProgram = new Dictionary<string, string?>
            {
                { "txt", "notepad" },
                { "bmp", "mspaint" },
                { "xls", "excel" },
                { "exe", string.Empty },
                { string.Empty, null }
            };
            return await DictionaryOperations.PutValidAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexDictionaryEmpty() => Test(async (host, pipeline) =>
        {
            var result = await DictionaryOperations.GetEmptyAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(new Dictionary<string, string?>(), result.Value.DefaultProgram);
        });

        [Test]
        public Task PutComplexDictionaryEmpty() => TestStatus(async (host, pipeline) =>
        {
            var value = new DictionaryWrapper();
            value.DefaultProgram = new Dictionary<string, string?>();
            return await DictionaryOperations.PutEmptyAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexDictionaryNull() => Test(async (host, pipeline) =>
        {
            var result = await DictionaryOperations.GetNullAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.GetRawResponse().Status);
            Assert.AreEqual(null, result.Value.DefaultProgram);
        });

        [Test]
        public Task GetComplexDictionaryNotProvided() => Test(async (host, pipeline) =>
        {
            var result = await DictionaryOperations.GetNotProvidedAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.GetRawResponse().Status);
            Assert.AreEqual(null, result.Value.DefaultProgram);
        });

        [Test]
        public Task GetComplexInheritanceValid() => Test(async (host, pipeline) =>
        {
            var result = await InheritanceOperations.GetValidAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("persian", result.Value.Breed);
            Assert.AreEqual("green", result.Value.Color);
            var hates = result.Value.Hates.ToArray();

            Assert.AreEqual("tomato", hates[0].Food);
            Assert.AreEqual(1, hates[0].Id);
            Assert.AreEqual("Potato", hates[0].Name);

            Assert.AreEqual("french fries", hates[1].Food);
            Assert.AreEqual(-1, hates[1].Id);
            Assert.AreEqual("Tomato", hates[1].Name);

            Assert.AreEqual(2, result.Value.Id);
            Assert.AreEqual("Siameeee", result.Value.Name);
        });

        [Test]
        public Task PutComplexInheritanceValid() => TestStatus(async (host, pipeline) =>
        {
            var value = new Siamese
            {
                Breed = "persian",
                Color = "green",
                Hates = new[]
                {
                    new Dog()
                    {
                        Food = "tomato",
                        Id = 1,
                        Name = "Potato"
                    },
                    new Dog()
                    {
                        Food = "french fries",
                        Id = -1,
                        Name = "Tomato"
                    },
                },
                Id = 2,
                Name = "Siameeee"
            };
            return await InheritanceOperations.PutValidAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexPolymorphismValid() => Test(async (host, pipeline) =>
        {
            var result = await PolymorphismOperations.GetValidAsync(ClientDiagnostics, pipeline, host);

            var value = (Salmon)result.Value;
            Assert.AreEqual("salmon", value.Fishtype);
            Assert.AreEqual("alaska", value.Location);
            Assert.AreEqual("king", value.Species);
            Assert.AreEqual(true, value.Iswild);
            Assert.AreEqual(1, value.Length);

            var siblings = value.Siblings.ToArray();

            var shark = (Shark)siblings[0];
            Assert.AreEqual("shark", shark.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("2012-01-05T01:00:00Z"), shark.Birthday);
            Assert.AreEqual("predator", shark.Species);
            Assert.AreEqual(6, shark.Age);
            Assert.AreEqual(20, shark.Length);

            var sawshark = (Sawshark)siblings[1];
            Assert.AreEqual("sawshark", sawshark.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("1900-01-05T01:00:00Z"), sawshark.Birthday);
            Assert.AreEqual("dangerous", sawshark.Species);
            Assert.AreEqual(105, sawshark.Age);
            Assert.AreEqual(10, sawshark.Length);

            var goblin = (Goblinshark)siblings[2];
            Assert.AreEqual("goblin", goblin.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("2015-08-08T00:00:00Z"), goblin.Birthday);
            Assert.AreEqual("scary", goblin.Species);
            Assert.AreEqual(1, goblin.Age);
            Assert.AreEqual(30, goblin.Length);
            Assert.AreEqual(5, goblin.Jawsize);
            Assert.AreEqual("pinkish-gray", goblin.Color.ToString());
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No match")]
        public Task PutComplexPolymorphismValid() => TestStatus(async (host, pipeline) =>
        {
            var value = new Salmon()
            {
                Location = "alaska",
                Iswild = true,
                Species = "king",
                Length = 1,
                Siblings = new[]
                {
                    new Shark
                    {
                        Age = 6,
                        Birthday = DateTimeOffset.Parse("2012-01-05T01:00:00Z"),
                        Length = 20,
                        Species = "predator"
                    },
                    new Sawshark()
                    {
                        Age = 105,
                        Birthday = DateTimeOffset.Parse("1900-01-05T01:00:00Z"),
                        Picture = new byte[] {255, 255, 255, 255, 254},
                        Length = 10,
                        Species = "dangerous"
                    },
                    new Goblinshark()
                    {
                        Age = 1,
                        Birthday = DateTimeOffset.Parse("2015-08-08T00:00:00Z"),
                        Length = 30,
                        Species = "scary",
                        Jawsize = 5,
                        Color = "pinkish-gray"
                    }
                }
            };
            return await PolymorphismOperations.PutValidAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        // TODO: Passes but without additional properties https://github.com/Azure/autorest.csharp/issues/348
        public Task GetComplexPolymorphismComplicated() => Test(async (host, pipeline) =>
        {
            var result = await PolymorphismOperations.GetComplicatedAsync(ClientDiagnostics, pipeline, host);

            var value = (SmartSalmon)result.Value;
            Assert.AreEqual("smart_salmon", value.Fishtype);
            Assert.AreEqual("alaska", value.Location);
            Assert.AreEqual("king", value.Species);
            Assert.AreEqual(true, value.Iswild);
            Assert.AreEqual(1, value.Length);

            var siblings = value.Siblings.ToArray();

            var shark = (Shark)siblings[0];
            Assert.AreEqual("shark", shark.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("2012-01-05T01:00:00Z"), shark.Birthday);
            Assert.AreEqual("predator", shark.Species);
            Assert.AreEqual(6, shark.Age);
            Assert.AreEqual(20, shark.Length);

            var sawshark = (Sawshark)siblings[1];
            Assert.AreEqual("sawshark", sawshark.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("1900-01-05T01:00:00Z"), sawshark.Birthday);
            Assert.AreEqual("dangerous", sawshark.Species);
            Assert.AreEqual(105, sawshark.Age);
            Assert.AreEqual(10, sawshark.Length);

            var goblin = (Goblinshark)siblings[2];
            Assert.AreEqual("goblin", goblin.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("2015-08-08T00:00:00Z"), goblin.Birthday);
            Assert.AreEqual("scary", goblin.Species);
            Assert.AreEqual(1, goblin.Age);
            Assert.AreEqual(30, goblin.Length);
            Assert.AreEqual(5, goblin.Jawsize);
            Assert.AreEqual("pinkish-gray", goblin.Color.ToString());

            /*
               var rawSalmon = {
                 'fishtype': 'smart_salmon',
                 'location': 'alaska',
                 'iswild': true,
                 'species': 'king',
                 'additionalProperty1': 1,
                 'additionalProperty2': false,
                 'additionalProperty3': "hello",
                 'additionalProperty4': { a: 1, b: 2 },
                 'additionalProperty5': [1, 3],
                 'length': 1.0,
                 'siblings': [
                   {
                     'fishtype': 'shark',
                     'age': 6,
                     'birthday': '2012-01-05T01:00:00Z',
                     'length': 20.0,
                     'species': 'predator',
                   },
                   {
                     'fishtype': 'sawshark',
                     'age': 105,
                     'birthday': '1900-01-05T01:00:00Z',
                     'length': 10.0,
                     'picture': new Buffer([255, 255, 255, 255, 254]).toString('base64'),
                     'species': 'dangerous',
                   },
                   {
                     'fishtype': 'goblin',
                     'age': 1,
                     'birthday': '2015-08-08T00:00:00Z',
                     'length': 30.0,
                     'species': 'scary',
                     'jawsize': 5,
                     'color':'pinkish-gray'
                   }
                 ]
               };
             */
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/348")]
        public Task PutComplexPolymorphismComplicated() => TestStatus(async (host, pipeline) =>
        {
            /*
               var rawSalmon = {
                 'fishtype': 'smart_salmon',
                 'location': 'alaska',
                 'iswild': true,
                 'species': 'king',
                 'additionalProperty1': 1,
                 'additionalProperty2': false,
                 'additionalProperty3': "hello",
                 'additionalProperty4': { a: 1, b: 2 },
                 'additionalProperty5': [1, 3],
                 'length': 1.0,
                 'siblings': [
                   {
                     'fishtype': 'shark',
                     'age': 6,
                     'birthday': '2012-01-05T01:00:00Z',
                     'length': 20.0,
                     'species': 'predator',
                   },
                   {
                     'fishtype': 'sawshark',
                     'age': 105,
                     'birthday': '1900-01-05T01:00:00Z',
                     'length': 10.0,
                     'picture': new Buffer([255, 255, 255, 255, 254]).toString('base64'),
                     'species': 'dangerous',
                   },
                   {
                     'fishtype': 'goblin',
                     'age': 1,
                     'birthday': '2015-08-08T00:00:00Z',
                     'length': 30.0,
                     'species': 'scary',
                     'jawsize': 5,
                     'color':'pinkish-gray'
                   }
                 ]
               };
             */
            var value = new Salmon
            {
                //Fishtype = "smart_salmon",
                Location = "alaska"
            };
            return await PolymorphismOperations.PutComplicatedAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No match")]
        public Task PutComplexPolymorphismNoDiscriminator() => TestStatus(async (host, pipeline) =>
        {
            var value = new Salmon()
            {
                Location = "alaska",
                Iswild = true,
                Species = "king",
                Length = 1,
                Siblings = new[]
                {
                    new Shark
                    {
                        Age = 6,
                        Birthday = DateTimeOffset.Parse("2012-01-05T01:00:00Z"),
                        Length = 20,
                        Species = "predator"
                    },
                    new Sawshark()
                    {
                        Age = 105,
                        Birthday = DateTimeOffset.Parse("1900-01-05T01:00:00Z"),
                        Picture = new byte[] {255, 255, 255, 255, 254},
                        Length = 10,
                        Species = "dangerous"
                    },
                    new Goblinshark()
                    {
                        Age = 1,
                        Birthday = DateTimeOffset.Parse("2015-08-08T00:00:00Z"),
                        Length = 30,
                        Species = "scary",
                        Jawsize = 5,
                        Color = "pinkish-gray"
                    }
                }
            };

            var result = await PolymorphismOperations.PutMissingDiscriminatorAsync(ClientDiagnostics, pipeline, value, host: host);

            value = result.Value;
            Assert.AreEqual("salmon", value.Fishtype);
            Assert.AreEqual("alaska", value.Location);
            Assert.AreEqual("king", value.Species);
            Assert.AreEqual(true, value.Iswild);
            Assert.AreEqual(1, value.Length);

            var siblings = value.Siblings.ToArray();

            var shark = (Shark)siblings[0];
            Assert.AreEqual("shark", shark.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("2012-01-05T01:00:00Z"), shark.Birthday);
            Assert.AreEqual("predator", shark.Species);
            Assert.AreEqual(6, shark.Age);
            Assert.AreEqual(20, shark.Length);
            Assert.Null(shark.Siblings);

            var sawshark = (Sawshark)siblings[1];
            Assert.AreEqual("sawshark", sawshark.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("1900-01-05T01:00:00Z"), sawshark.Birthday);
            Assert.AreEqual("dangerous", sawshark.Species);
            Assert.AreEqual(105, sawshark.Age);
            Assert.AreEqual(10, sawshark.Length);
            Assert.Null(sawshark.Siblings);

            var goblin = (Goblinshark)siblings[2];
            Assert.AreEqual("goblin", goblin.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("2015-08-08T00:00:00Z"), goblin.Birthday);
            Assert.AreEqual("scary", goblin.Species);
            Assert.AreEqual(1, goblin.Age);
            Assert.AreEqual(30, goblin.Length);
            Assert.AreEqual(5, goblin.Jawsize);
            Assert.AreEqual("pinkish-gray", goblin.Color.ToString());
            Assert.Null(goblin.Siblings);

            return result.GetRawResponse();
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No match")]
        public Task GetComplexPolymorphismDotSyntax() => Test(async (host, pipeline) =>
        {
            var result = await PolymorphismOperations.GetDotSyntaxAsync(ClientDiagnostics, pipeline, host);

            var dotSalmon = (DotSalmon)result.Value;
            Assert.AreEqual("DotSalmon", dotSalmon.FishType);
            Assert.AreEqual("sweden", dotSalmon.Location);
            Assert.AreEqual(true, dotSalmon.Iswild);
            Assert.AreEqual("king", dotSalmon.Species);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No match")]
        public Task GetComposedWithDiscriminator() => Test(async (host, pipeline) =>
        {
            var result = await PolymorphismOperations.GetComposedWithDiscriminatorAsync(ClientDiagnostics, pipeline, host);

            var dotSalmon = result.Value.SampleSalmon;
            Assert.AreEqual("DotSalmon", dotSalmon.FishType);
            Assert.AreEqual("sweden", dotSalmon.Location);
            Assert.AreEqual(false, dotSalmon.Iswild);
            Assert.AreEqual("king", dotSalmon.Species);

            var salmons = result.Value.Salmons.ToArray();

            dotSalmon = salmons[0];
            Assert.AreEqual("DotSalmon", dotSalmon.FishType);
            Assert.AreEqual("sweden", dotSalmon.Location);
            Assert.AreEqual(false, dotSalmon.Iswild);
            Assert.AreEqual("king", dotSalmon.Species);

            dotSalmon = salmons[1];
            Assert.AreEqual("DotSalmon", dotSalmon.FishType);
            Assert.AreEqual("atlantic", dotSalmon.Location);
            Assert.AreEqual(true, dotSalmon.Iswild);
            Assert.AreEqual("king", dotSalmon.Species);

            dotSalmon = (DotSalmon) result.Value.SampleFish;
            Assert.AreEqual("DotSalmon", dotSalmon.FishType);
            Assert.AreEqual("australia", dotSalmon.Location);
            Assert.AreEqual(false, dotSalmon.Iswild);
            Assert.AreEqual("king", dotSalmon.Species);

            var fishes = result.Value.Fishes.ToArray();

            dotSalmon = (DotSalmon) fishes[0];
            Assert.AreEqual("DotSalmon", dotSalmon.FishType);
            Assert.AreEqual("australia", dotSalmon.Location);
            Assert.AreEqual(false, dotSalmon.Iswild);
            Assert.AreEqual("king", dotSalmon.Species);

            dotSalmon = (DotSalmon) fishes[1];
            Assert.AreEqual("DotSalmon", dotSalmon.FishType);
            Assert.AreEqual("canada", dotSalmon.Location);
            Assert.AreEqual(true, dotSalmon.Iswild);
            Assert.AreEqual("king", dotSalmon.Species);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No match")]
        public Task GetComposedWithoutDiscriminator() => Test(async (host, pipeline) =>
        {
            var result = await PolymorphismOperations.GetComposedWithoutDiscriminatorAsync(ClientDiagnostics, pipeline, host);

            var dotSalmon = result.Value.SampleSalmon;
            Assert.AreEqual("DotSalmon", dotSalmon.FishType);
            Assert.AreEqual("sweden", dotSalmon.Location);
            Assert.AreEqual(false, dotSalmon.Iswild);
            Assert.AreEqual("king", dotSalmon.Species);

            var salmons = result.Value.Salmons.ToArray();

            dotSalmon = salmons[0];
            Assert.AreEqual("DotSalmon", dotSalmon.FishType);
            Assert.AreEqual("sweden", dotSalmon.Location);
            Assert.AreEqual(false, dotSalmon.Iswild);
            Assert.AreEqual("king", dotSalmon.Species);

            dotSalmon = salmons[1];
            Assert.AreEqual("DotSalmon", dotSalmon.FishType);
            Assert.AreEqual("atlantic", dotSalmon.Location);
            Assert.AreEqual(true, dotSalmon.Iswild);
            Assert.AreEqual("king", dotSalmon.Species);

            var dotFish = result.Value.SampleFish;
            Assert.AreEqual(null, dotFish.FishType);
            Assert.AreEqual("king", dotFish.Species);

            var fishes = result.Value.Fishes.ToArray();

            dotFish = fishes[0];
            Assert.AreEqual(null, dotFish.FishType);
            Assert.AreEqual("king", dotFish.Species);

            dotFish = fishes[1];
            Assert.AreEqual(null, dotFish.FishType);
            Assert.AreEqual("king", dotFish.Species);
        });

        [Test]
        public Task GetComplexPolymorphicRecursiveValid() => Test(async (host, pipeline) =>
        {
            var result = await PolymorphicrecursiveOperations.GetValidAsync(ClientDiagnostics, pipeline, host);
            var value = (Salmon)result.Value;
            Assert.AreEqual("salmon", value.Fishtype);
            Assert.AreEqual("alaska", value.Location);
            Assert.AreEqual("king", value.Species);
            Assert.AreEqual(true, value.Iswild);
            Assert.AreEqual(1, value.Length);

            var siblings = value.Siblings.ToArray();

            var shark = (Shark)siblings[0];
            Assert.AreEqual("shark", shark.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("2012-01-05T01:00:00Z"), shark.Birthday);
            Assert.AreEqual("predator", shark.Species);
            Assert.AreEqual(6, shark.Age);
            Assert.AreEqual(20, shark.Length);

            var sharkSiblings = shark.Siblings.ToArray();

            var innerSalmon = (Salmon)sharkSiblings[0];
            Assert.AreEqual("salmon", innerSalmon.Fishtype);
            Assert.AreEqual("atlantic", innerSalmon.Location);
            Assert.AreEqual("coho", innerSalmon.Species);
            Assert.AreEqual(true, innerSalmon.Iswild);
            Assert.AreEqual(2, innerSalmon.Length);

            var innerSalmonSiblings = innerSalmon.Siblings.ToArray();

            var innerInnerShark = (Shark)innerSalmonSiblings[0];
            Assert.AreEqual("shark", innerInnerShark.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("2012-01-05T01:00:00Z"), innerInnerShark.Birthday);
            Assert.AreEqual("predator", innerInnerShark.Species);
            Assert.AreEqual(6, innerInnerShark.Age);
            Assert.AreEqual(20, innerInnerShark.Length);
            Assert.Null(innerInnerShark.Siblings);

            var innerInnerSawshark = (Sawshark)innerSalmonSiblings[1];
            Assert.AreEqual("sawshark", innerInnerSawshark.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("1900-01-05T01:00:00Z"), innerInnerSawshark.Birthday);
            Assert.AreEqual("dangerous", innerInnerSawshark.Species);
            Assert.AreEqual(105, innerInnerSawshark.Age);
            Assert.AreEqual(10, innerInnerSawshark.Length);
            Assert.Null(innerInnerSawshark.Siblings);


            var innerSawshark = (Sawshark)sharkSiblings[1];
            Assert.AreEqual("sawshark", innerSawshark.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("1900-01-05T01:00:00Z"), innerSawshark.Birthday);
            Assert.AreEqual("dangerous", innerSawshark.Species);
            Assert.AreEqual(105, innerSawshark.Age);
            Assert.AreEqual(10, innerSawshark.Length);
            CollectionAssert.IsEmpty(innerSawshark.Siblings);

            var sawshark = (Sawshark)siblings[1];
            Assert.AreEqual("sawshark", sawshark.Fishtype);
            Assert.AreEqual(DateTimeOffset.Parse("1900-01-05T01:00:00Z"), sawshark.Birthday);
            Assert.AreEqual("dangerous", sawshark.Species);
            Assert.AreEqual(105, sawshark.Age);
            Assert.AreEqual(10, sawshark.Length);
            CollectionAssert.IsEmpty(sawshark.Siblings);
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No match")]
        public Task PutComplexPolymorphicRecursiveValid() => TestStatus(async (host, pipeline) =>
        {
            var value = new Salmon()
            {
                Location = "alaska",
                Iswild = true,
                Species = "king",
                Length = 1,
                Siblings = new[]
                {
                    new Shark
                    {
                        Age = 6,
                        Birthday = DateTimeOffset.Parse("2012-01-05T01:00:00Z"),
                        Length = 20,
                        Species = "predator",
                        Siblings = new Fish[]
                        {
                            new Salmon()
                            {
                                Location = "atlantic",
                                Iswild = true,
                                Species = "coho",
                                Length = 2,
                                Siblings = new[]
                                {
                                    new Shark
                                    {
                                        Age = 6,
                                        Birthday = DateTimeOffset.Parse("2012-01-05T01:00:00Z"),
                                        Length = 20,
                                        Species = "predator",
                                    },
                                    new Sawshark()
                                    {
                                        Age = 105,
                                        Birthday = DateTimeOffset.Parse("1900-01-05T01:00:00Z"),
                                        Picture = new byte[] {255, 255, 255, 255, 254},
                                        Length = 10,
                                        Species = "dangerous"
                                    },
                                }
                            },

                            new Sawshark()
                            {
                                Age = 105,
                                Birthday = DateTimeOffset.Parse("1900-01-05T01:00:00Z"),
                                Picture = new byte[] {255, 255, 255, 255, 254},
                                Length = 10,
                                Species = "dangerous",
                                Siblings = new Fish[] {}
                            },
                        }
                    },
                    new Sawshark()
                    {
                        Age = 105,
                        Birthday = DateTimeOffset.Parse("1900-01-05T01:00:00Z"),
                        Picture = new byte[] {255, 255, 255, 255, 254},
                        Length = 10,
                        Species = "dangerous",
                        Siblings = new Fish[] {}
                    },
                }
            };
            return await PolymorphicrecursiveOperations.PutValidAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexReadOnlyPropertyValid() => Test(async (host, pipeline) =>
        {
            var result = await ReadonlypropertyOperations.GetValidAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual("1234", result.Value.Id);
            Assert.AreEqual(2, result.Value.Size);
        }, true);

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "No response found")]
        public Task PutComplexReadOnlyPropertyValid() => TestStatus(async (host, pipeline) =>
        {
            var value = new ReadonlyObj();
            return await ReadonlypropertyOperations.PutValidAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public void EnumGeneratedAsExtensibleWithCorrectName()
        {
            // Name directive
            Assert.AreEqual("CMYKColors", typeof(CMYKColors).Name);
            // modelAsString
            Assert.True(typeof(CMYKColors).IsValueType);
            Assert.False(typeof(CMYKColors).IsEnum);
        }

        [Test]
        public void OptionalCollectionsAreNullByDefault()
        {
            var arrayWrapper = new ArrayWrapper();
            Assert.Null(arrayWrapper.Array);
        }

        [Test]
        public void OptionalDictionariesAreNullByDefault()
        {
            var dictionaryWrapper = new DictionaryWrapper();
            Assert.Null(dictionaryWrapper.DefaultProgram);
        }

        [Test]
        public void ReadonlyPropertiesAreGetOnly()
        {
            Assert.False(typeof(ReadonlyObj).GetProperty(nameof(ReadonlyObj.Id)).SetMethod.IsPublic);
        }
    }
}
