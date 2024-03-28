using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Type.Model.Inheritance.NestedDiscriminator;
using _Type.Model.Inheritance.NestedDiscriminator.Models;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public class type_model_inheritance_nested_discriminator : CadlRanchTestBase
    {
        [Test]
        public Task Type_model_inheritance_nested_discriminator_getMissingDiscriminator() => Test(async (host) =>
        {
            var response = await new NestedDiscriminatorClient(host, null).GetMissingDiscriminatorAsync();
            var value = response.Value;
            Assert.AreEqual(1, value.Age);
        });

        [Test]
        public Task Type_model_inheritance_nested_discriminator_putModel() => Test(async (host) =>
        {
            var value = new GoblinShark(1)
            {
                Kind = "shark",
            };
            var response = await new NestedDiscriminatorClient(host, null).PutModelAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_model_inheritance_nested_discriminator_getModel() => Test(async (host) =>
        {
            var response = await new NestedDiscriminatorClient(host, null).GetModelAsync();
            var value = response.Value;
            Assert.AreEqual(1, value.Age);
            Assert.AreEqual("shark", value.Kind);
            if (value is Shark shark)
            {
                Assert.AreEqual("goblin", shark.Sharktype);
            }
        });

        [Test]
        public Task Type_model_inheritance_nested_discriminator_getRecursiveModel() => Test(async (host) =>
        {
            var response = await new NestedDiscriminatorClient(host, null).GetRecursiveModelAsync();
            var value = response.Value;
            Assert.AreEqual(1, value.Age);
            Assert.AreEqual("salmon", value.Kind);
            if (value is Salmon salmon)
            {
                Assert.AreEqual(2, salmon.Partner.Age);
                if (salmon.Partner is Shark shark)
                {
                    Assert.AreEqual("saw", shark.Sharktype);
                }
                Assert.AreEqual(2, salmon.Friends.Count);
                Assert.AreEqual("salmon", salmon.Friends[0].Kind);
                Assert.AreEqual("shark", salmon.Friends[1].Kind);
            }
        });

        [Test]
        public Task Type_model_inheritance_nested_discriminator_putRecursiveModel() => Test(async (host) =>
        {
            var value = new Salmon(1)
            {
                Kind = "salmon",
                Partner = new Shark(2) { Kind = "shark", Sharktype = "saw" },
                Friends =
                {
                    new Salmon(2)
                    {
                        Partner = new Salmon(3) { Kind = "salmon" },
                        Hate =
                        {
                            ["key1"] = new Salmon(4),
                            ["key2"] = new GoblinShark(2) { Kind = "shark" }
                        }
                    },
                    new GoblinShark(3) { Kind = "shark" }
                },
                Hate =
                {
                    ["key3"] = new SawShark(3)
                    {
                        Kind = "shark",
                    },
                    ["key4"] = new Salmon(2)
                    {
                        Kind = "salmon",
                        Friends =
                        {
                            new Salmon(1) { Kind = "salmon" },
                            new GoblinShark(4) { Kind = "shark" }
                        }
                    }
                }
            };
            var response = await new NestedDiscriminatorClient(host, null).PutRecursiveModelAsync(value);
            Assert.AreEqual(204, response.Status);
        });

        [Test]
        public Task Type_model_inheritance_nested_discriminator_getWrongDiscriminator() => Test(async (host) =>
        {
            var response = await new NestedDiscriminatorClient(host, null).GetWrongDiscriminatorAsync();
            var value = response.Value;
            Assert.AreEqual(1, value.Age);
            Assert.AreEqual("wrongKind", value.Kind);
        });
    }
}
