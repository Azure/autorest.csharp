using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using Agoda.Csharp.Client.Test.Models;
using System.Threading.Tasks;

namespace Agoda.Csharp.Client.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestShouldSerializeBasicDataTypes()
        {
            var config = new ApiBaseConfig()
            {
                settings = new List<string>()
                {
                    "http://localhost:8443"
                },
                name = "petstore",
                retryCount = 0,
                timeout = TimeSpan.FromMinutes(1)
            };
            var client = new SwaggerPetstore(config);
            var result = await client.GetPetByIdAsync(1);
            List<Tag> expectedTag = new List<Tag>();
            expectedTag.Add(new Tag(2, "Beagle"));
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.Category.Name, "Dog");
            Assert.IsTrue(TagEqual(result.Tags, expectedTag));
        }

        [Test]
        public async Task TestShouldSerializeDateTime()
        {
            var config = new ApiBaseConfig()
            {
                settings = new List<string>()
                {
                    "http://localhost:8443"
                },
                name = "petstore",
                retryCount = 0,
                timeout = TimeSpan.FromMinutes(1)
            };
            var client = new SwaggerPetstore(config);
            var result = await client.GetOrderByIdAsync(1);
            // 2019-04-30T04:36:59.348Z
            const long timeInTicks = 636921958193480000L;
            Assert.AreEqual(new DateTime(timeInTicks), result.ShipDate);
        }
        
        [Test]
        public async Task TestShouldBeAbleToMakePostCalls()
        {
            var config = new ApiBaseConfig()
            {
                settings = new List<string>()
                {
                    "http://localhost:8443"
                },
                name = "petstore",
                retryCount = 0,
                timeout = TimeSpan.FromMinutes(1)
            };
            var pet = new Pet("dog", new List<string>(), 2, null, new List<Tag>(), "good");
            var client = new SwaggerPetstore(config);
            var result = await client.AddPetAsync(pet);
            
            Assert.AreEqual(200, result.HttpCode);
        }

                
        [Test]
        public async Task TestShouldBeAbleToMakePostCallsWithNullValues()
        {
            var config = new ApiBaseConfig()
            {
                settings = new List<string>()
                {
                    "http://localhost:8443"
                },
                name = "petstore",
                retryCount = 0,
                timeout = TimeSpan.FromMinutes(1)
            };
            var pet = new Pet("dog", new List<string>(), null, null, new List<Tag>(), "good");
            var client = new SwaggerPetstore(config);
            var result = await client.AddPetAsync(pet);

            Assert.AreEqual(200, result.HttpCode);
        }
        
               
        [Test]
        public async Task TestShouldGetCorrectHttpCode()
        {
            var config = new ApiBaseConfig()
            {
                settings = new List<string>()
                {
                    "http://localhost:8443"
                },
                name = "petstore",
                retryCount = 0,
                timeout = TimeSpan.FromMinutes(1)
            };
            var pet = new Pet("dog", new List<string>(), null, null, new List<Tag>(), "good");
            var client = new SwaggerPetstore(config);
            var result = await client.AddPetAsync(pet);
            
            Assert.AreEqual(200, result.HttpCode);
            Assert.AreEqual(true, result.IsSuccessful);
        }

        class TagComparer : IEqualityComparer<Tag>
        {
            public bool Equals(Tag x, Tag y)
            {
                if (Object.ReferenceEquals(x, y)) return true;
                return x.Id == y.Id && x.Name == y.Name;
            }

            public int GetHashCode(Tag obj)
            {
                return obj.Id.GetHashCode() + obj.Name.GetHashCode();
            }
        }
        private static bool TagEqual(List<Tag> result, List<Tag> expectedTags)
        {
            var firstNotSecond = result.Except(expectedTags, new TagComparer()).ToList();
            var secondNotFirst = expectedTags.Except(result, new TagComparer()).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }
    }
}