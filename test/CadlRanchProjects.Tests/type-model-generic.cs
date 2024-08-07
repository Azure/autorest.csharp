using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using Azure;
using NUnit.Framework;
using _Type.Model.Generic.Models;
using _Type.Model.Generic;
using System.Collections.Generic;

namespace CadlRanchProjects.Tests
{
    public class TypeModelGenericTests : CadlRanchTestBase
    {
        [Test]
        public Task Type_Model_Generic_genericType() => Test(async (host) =>
        {
            var values = new List<int> { 1234 };
            var value = 1234;
            var input = new Int32Type(values, value);
            Response response = await new GenericClient(host, null).GenericTypeAsync(input);
            Assert.AreEqual(204, response.Status);
        });
    }
}
