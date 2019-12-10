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
        [Ignore("https://github.com/Azure/autorest.csharp/issues/289")]
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
            Assert.AreEqual(DateTime.Parse("0001-01-01"), result.Value.Field);
            Assert.AreEqual(DateTime.Parse("2016-02-29"), result.Value.Leap);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/302")]
        public Task PutComplexPrimitiveDate() => TestStatus(async (host, pipeline) =>
        {
            var value = new DateWrapper
            {
                Field = DateTime.Parse("0001-01-01"),
                Leap = DateTime.Parse("2016-02-29")
            };
            return await PrimitiveOperations.PutDateAsync(ClientDiagnostics, pipeline, value, host);
        });

        //TODO: Passes, but has a bug: https://github.com/Azure/autorest.csharp/issues/316
        [Test]
        public Task GetComplexPrimitiveDateTime() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetDateTimeAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(DateTimeOffset.Parse("0001-01-01T00:00:00Z", null, DateTimeStyles.AdjustToUniversal), result.Value.Field);
            Assert.AreEqual(DateTimeOffset.Parse("2015-05-18T18:38:00Z", null, DateTimeStyles.AdjustToUniversal), result.Value.Now);
        });

        //TODO: Passes, but has a bug: https://github.com/Azure/autorest.csharp/issues/316
        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/303")]
        public Task PutComplexPrimitiveDateTime() => TestStatus(async (host, pipeline) =>
        {
            var value = new DatetimeWrapper
            {
                Field = DateTime.Parse("0001-01-01T00:00:00Z", null, DateTimeStyles.AdjustToUniversal),
                Now = DateTime.Parse("2015-05-18T18:38:00Z", null, DateTimeStyles.AdjustToUniversal)
            };
            return await PrimitiveOperations.PutDateTimeAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/307")]
        public Task GetComplexPrimitiveDateTimeRfc1123() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetDateTimeRfc1123Async(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(DateTime.Parse("Mon, 01 Jan 0001 12:00:00 GMT"), result.Value.Field);
            Assert.AreEqual(DateTime.Parse("Mon, 18 May 2015 11:38:00 GMT"), result.Value.Now);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/304")]
        public Task PutComplexPrimitiveDateTimeRfc1123() => TestStatus(async (host, pipeline) =>
        {
            var value = new Datetimerfc1123Wrapper
            {
                Field = DateTime.Parse("Mon, 01 Jan 0001 12:00:00 GMT"),
                Now = DateTime.Parse("Mon, 18 May 2015 11:38:00 GMT")
            };
            return await PrimitiveOperations.PutDateTimeRfc1123Async(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/309")]
        public Task GetComplexPrimitiveDuration() => Test(async (host, pipeline) =>
        {
            var result = await PrimitiveOperations.GetDurationAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), result.Value.Field);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/305")]
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
            //https://github.com/dotnet/csharplang/issues/1058
            var content = new[] { (byte)0xFF, (byte)0xFE, (byte)0xFD, (byte)0xFC, (byte)0x00, (byte)0xFA, (byte)0xF9, (byte)0xF8, (byte)0xF7, (byte)0xF6 };
            Assert.AreEqual(content, result.Value.Field);
        });

        [Test]
        public Task PutComplexPrimitiveByte() => TestStatus(async (host, pipeline) =>
        {
            //https://github.com/dotnet/csharplang/issues/1058
            var content = new[] { (byte)0xFF, (byte)0xFE, (byte)0xFD, (byte)0xFC, (byte)0x00, (byte)0xFA, (byte)0xF9, (byte)0xF8, (byte)0xF7, (byte)0xF6 };
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
            var content = new[] { "1, 2, 3, 4", string.Empty, null, "&S#$(*Y", "The quick brown fox jumps over the lazy dog" };
            foreach (var item in content)
            {
                value.Array.Add(item);
            }
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
            return await ArrayOperations.PutEmptyAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        public Task GetComplexArrayNotProvided() => Test(async (host, pipeline) =>
        {
            var result = await ArrayOperations.GetNotProvidedAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.GetRawResponse().Status);
            Assert.AreEqual(new string[0], result.Value.Array);
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
            var content = new Dictionary<string, string?>
            {
                { "txt", "notepad" },
                { "bmp", "mspaint" },
                { "xls", "excel" },
                { "exe", string.Empty },
                { string.Empty, null }
            };
            foreach (var item in content)
            {
                value.DefaultProgram.Add(item);
            }
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
            return await DictionaryOperations.PutEmptyAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/289")]
        public Task GetComplexDictionaryNull() => Test(async (host, pipeline) =>
        {
            var result = await DictionaryOperations.GetNullAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.GetRawResponse().Status);
            Assert.AreEqual(new Dictionary<string, string?>(), result.Value.DefaultProgram);
        });

        [Test]
        public Task GetComplexDictionaryNotProvided() => Test(async (host, pipeline) =>
        {
            var result = await DictionaryOperations.GetNotProvidedAsync(ClientDiagnostics, pipeline, host);
            Assert.AreEqual(200, result.GetRawResponse().Status);
            Assert.AreEqual(new Dictionary<string, string?>(), result.Value.DefaultProgram);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/312")]
        public Task GetComplexInheritanceValid() => Test(async (host, pipeline) =>
        {
            var result = await InheritanceOperations.GetValidAsync(ClientDiagnostics, pipeline, host);
            //"breed":"persian","color":"green","hates":[{"food":"tomato","id":1,"name":"Potato"},{"food":"french fries","id":-1,"name":"Tomato"}],"id":2,"name":"Siameeee"
            Assert.AreEqual("persian", result.Value.Breed);
            //Assert.AreEqual("green", result.Value.Color);
            //Assert.AreEqual(, result.Value.Hates); // Array of dictionaries or objects
            //Assert.AreEqual(2, result.Value.Id);
            //Assert.AreEqual("Siameeee", result.Value.Name);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/312")]
        public Task PutComplexInheritanceValid() => TestStatus(async (host, pipeline) =>
        {
            //"breed":"persian","color":"green","hates":[{"food":"tomato","id":1,"name":"Potato"},{"food":"french fries","id":-1,"name":"Tomato"}],"id":2,"name":"Siameeee"
            var value = new Siamese
            {
                Breed = "persian",
                //Color = "green",
                //Hates = ___, // Array of dictionaries or objects
                //Id = 2,
                //Name = "Siameeee"
            };
            return await InheritanceOperations.PutValidAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/312")]
        public Task GetComplexPolymorphismValid() => Test(async (host, pipeline) =>
        {
            var result = await PolymorphismOperations.GetValidAsync(ClientDiagnostics, pipeline, host);
            /*
             var rawFish = {
                'fishtype': 'salmon',
                'location': 'alaska',
                'iswild': true,
                'species': 'king',
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
                    // Intentionally requiring a value not defined in the enum, since
                    // such values should be allowed to be sent to/received from the server
                    'color':'pinkish-gray'
                  }
                ]
              };
             */

            //Assert.AreEqual("salmon", result.Value.Fishtype);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/312")]
        public Task PutComplexPolymorphismValid() => TestStatus(async (host, pipeline) =>
        {
            /*
             var rawFish = {
                'fishtype': 'salmon',
                'location': 'alaska',
                'iswild': true,
                'species': 'king',
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
                    // Intentionally requiring a value not defined in the enum, since
                    // such values should be allowed to be sent to/received from the server
                    'color':'pinkish-gray'
                  }
                ]
              };
             */
            var value = new Fish
            {
                Fishtype = "salmon",
                //Location = "alaska",
            };
            return await PolymorphismOperations.PutValidAsync(ClientDiagnostics, pipeline, value, host);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/312")]
        public Task GetComplexPolymorphismComplicated() => Test(async (host, pipeline) =>
        {
            var result = await PolymorphismOperations.GetComplicatedAsync(ClientDiagnostics, pipeline, host);
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

            //Assert.AreEqual("smart_salmon", result.Value.Fishtype);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/312")]
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
        [Ignore("https://github.com/Azure/autorest.csharp/issues/312")]
        public Task PutComplexPolymorphismNoDiscriminator() => Test(async (host, pipeline) =>
        {
            /*
                var regularSalmonWithoutDiscriminator = {
                'location': 'alaska',
                'iswild': true,
                'species': 'king',
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
            var result = await PolymorphismOperations.PutMissingDiscriminatorAsync(ClientDiagnostics, pipeline, value, host);
            Assert.AreEqual(200, result.GetRawResponse().Status);
            //Assert.AreEqual("alaska", result.Value.Location);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/312")]
        public Task GetComplexPolymorphismDotSyntax() => Test(async (host, pipeline) =>
        {
            var result = await PolymorphismOperations.GetDotSyntaxAsync(ClientDiagnostics, pipeline, host);
            /*
              var dotSalmon = {
                'fish.type': 'DotSalmon',
                'location': 'sweden',
                'iswild': true,
                'species': 'king',
              };
             */

            //Assert.AreEqual("DotSalmon", result.Value.Fish.Type);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/312")]
        public Task GetComposedWithDiscriminator() => Test(async (host, pipeline) =>
        {
            var result = await PolymorphismOperations.GetComposedWithDiscriminatorAsync(ClientDiagnostics, pipeline, host);
            /*
              var dotFishMarketWithDiscriminator = {
                'sampleSalmon': {
                  'fish.type': 'DotSalmon',
                  'location': 'sweden',
                  'iswild': false,
                  'species': 'king',
                },
                'salmons': [
                  {
                    'fish.type': 'DotSalmon',
                    'location': 'sweden',
                    'iswild': false,
                    'species': 'king',
                  },
                  {
                    'fish.type': 'DotSalmon',
                    'location': 'atlantic',
                    'iswild': true,
                    'species': 'king',
                  }
                ],
                'sampleFish': {
                  'fish.type': 'DotSalmon',
                  'location': 'australia',
                  'iswild': false,
                  'species': 'king',
                },
                'fishes': [
                  {
                    'fish.type': 'DotSalmon',
                    'location': 'australia',
                    'iswild': false,
                    'species': 'king',
                  },
                  {
                    'fish.type': 'DotSalmon',
                    'location': 'canada',
                    'iswild': true,
                    'species': 'king',
                  }
                ]
              }
             */

            //Assert.AreEqual("DotSalmon", result.Value.SampleSalmon.Fish.Type);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/312")]
        public Task GetComposedWithoutDiscriminator() => Test(async (host, pipeline) =>
        {
            var result = await PolymorphismOperations.GetComposedWithoutDiscriminatorAsync(ClientDiagnostics, pipeline, host);
            /*
              var dotFishMarketWithoutDiscriminator = {
                'sampleSalmon': {
                  'location': 'sweden',
                  'iswild': false,
                  'species': 'king',
                },
                'salmons': [
                  {
                    'location': 'sweden',
                    'iswild': false,
                    'species': 'king',
                  },
                  {
                    'location': 'atlantic',
                    'iswild': true,
                    'species': 'king',
                  }
                ],
                'sampleFish': {
                  'location': 'australia',
                  'iswild': false,
                  'species': 'king',
                },
                'fishes': [
                  {
                    'location': 'australia',
                    'iswild': false,
                    'species': 'king',
                  },
                  {
                    'location': 'canada',
                    'iswild': true,
                    'species': 'king',
                  }
                ]
              }
             */

            //Assert.AreEqual("sweden", result.Value.SampleSalmon.Location);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/312")]
        public Task GetComplexPolymorphicRecursiveValid() => Test(async (host, pipeline) =>
        {
            var result = await PolymorphicrecursiveOperations.GetValidAsync(ClientDiagnostics, pipeline, host);
            /*
                var bigfishRaw = {
                "fishtype": "salmon",
                "location": "alaska",
                "iswild": true,
                "species": "king",
                "length": 1,
                "siblings": [
                  {
                    "fishtype": "shark",
                    "age": 6,
                    'birthday': '2012-01-05T01:00:00Z',
                    "species": "predator",
                    "length": 20,
                    "siblings": [
                      {
                        "fishtype": "salmon",
                        "location": "atlantic",
                        "iswild": true,
                        "species": "coho",
                        "length": 2,
                        "siblings": [
                          {
                            "fishtype": "shark",
                            "age": 6,
                            'birthday': '2012-01-05T01:00:00Z',
                            "species": "predator",
                            "length": 20
                          },
                          {
                            "fishtype": "sawshark",
                            "age": 105,
                            'birthday': '1900-01-05T01:00:00Z',
                            'picture': new Buffer([255, 255, 255, 255, 254]).toString('base64'),
                            "species": "dangerous",
                            "length": 10
                          }
                        ]
                      },
                      {
                        "fishtype": "sawshark",
                        "age": 105,
                        'birthday': '1900-01-05T01:00:00Z',
                        'picture': new Buffer([255, 255, 255, 255, 254]).toString('base64'),
                        "species": "dangerous",
                        "length": 10,
                        "siblings": []
                      }
                    ]
                  },
                  {
                    "fishtype": "sawshark",
                    "age": 105,
                    'birthday': '1900-01-05T01:00:00Z',
                    'picture': new Buffer([255, 255, 255, 255, 254]).toString('base64'),
                    "species": "dangerous",
                    "length": 10, "siblings": []
                  }
                ]
              };
             */

            //Assert.AreEqual("salmon", result.Value.Fishtype);
        });

        [Test]
        [Ignore("https://github.com/Azure/autorest.csharp/issues/312")]
        public Task PutComplexPolymorphicRecursiveValid() => TestStatus(async (host, pipeline) =>
        {
            /*
                var bigfishRaw = {
                "fishtype": "salmon",
                "location": "alaska",
                "iswild": true,
                "species": "king",
                "length": 1,
                "siblings": [
                  {
                    "fishtype": "shark",
                    "age": 6,
                    'birthday': '2012-01-05T01:00:00Z',
                    "species": "predator",
                    "length": 20,
                    "siblings": [
                      {
                        "fishtype": "salmon",
                        "location": "atlantic",
                        "iswild": true,
                        "species": "coho",
                        "length": 2,
                        "siblings": [
                          {
                            "fishtype": "shark",
                            "age": 6,
                            'birthday': '2012-01-05T01:00:00Z',
                            "species": "predator",
                            "length": 20
                          },
                          {
                            "fishtype": "sawshark",
                            "age": 105,
                            'birthday': '1900-01-05T01:00:00Z',
                            'picture': new Buffer([255, 255, 255, 255, 254]).toString('base64'),
                            "species": "dangerous",
                            "length": 10
                          }
                        ]
                      },
                      {
                        "fishtype": "sawshark",
                        "age": 105,
                        'birthday': '1900-01-05T01:00:00Z',
                        'picture': new Buffer([255, 255, 255, 255, 254]).toString('base64'),
                        "species": "dangerous",
                        "length": 10,
                        "siblings": []
                      }
                    ]
                  },
                  {
                    "fishtype": "sawshark",
                    "age": 105,
                    'birthday': '1900-01-05T01:00:00Z',
                    'picture': new Buffer([255, 255, 255, 255, 254]).toString('base64'),
                    "species": "dangerous",
                    "length": 10, "siblings": []
                  }
                ]
              };
             */
            var value = new Fish
            {
                Fishtype = "salmon",
                //Location = "alaska"
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
    }
}
