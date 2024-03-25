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
            Assert.AreEqual("wrongKind", value.Kind);
            Assert.AreEqual(1, value.Age);
        });
    }
}
