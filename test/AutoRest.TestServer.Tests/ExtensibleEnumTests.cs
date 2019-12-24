using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using extensible_enums_swagger;
using extensible_enums_swagger.Models.V20160707;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class ExtensibleEnumTests : TestServerTestBase
    {
        public ExtensibleEnumTests(TestServerVersion version) : base(version, "extensibleenums") { }

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Dynamic")]
        public Task RoundTripEnum() => TestStatus(async (host, pipeline) =>
        {
            var response = await new PetOperations(ClientDiagnostics, pipeline, host).AddPetAsync( new Pet()
            {
                Name = "Retriever",
                IntEnum = IntEnum._2,
                DaysOfWeek = DaysOfWeekExtensibleEnum.Friday
            });

            Assert.AreEqual("Retriever", response.Value.Name);
            Assert.AreEqual(IntEnum._2, response.Value.IntEnum);
            Assert.AreEqual(DaysOfWeekExtensibleEnum.Friday, response.Value.DaysOfWeek);

            return response.GetRawResponse();
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Dynamic")]
        public Task RoundTripEnum_Custom() => TestStatus(async (host, pipeline) =>
        {
            var response = await new PetOperations(ClientDiagnostics, pipeline, host).AddPetAsync( new Pet()
            {
                Name = "Retriever",
                IntEnum = "77",
                DaysOfWeek = "WED"
            });

            Assert.AreEqual("Retriever", response.Value.Name);
            Assert.AreEqual("77", response.Value.IntEnum.ToString());
            Assert.AreEqual("WED", response.Value.DaysOfWeek.Value.ToString());

            return response.GetRawResponse();
        });

        [Test]
        [IgnoreOnTestServer(TestServerVersion.V2, "Dynamic")]
        public Task RoundTripEnum_Null() => TestStatus(async (host, pipeline) =>
        {
            var response = await new PetOperations(ClientDiagnostics, pipeline, host).AddPetAsync( new Pet()
            {
                Name = "Retriever",
                IntEnum = "77",
                DaysOfWeek = null
            });

            Assert.AreEqual("Retriever", response.Value.Name);
            Assert.AreEqual("77", response.Value.IntEnum.ToString());
            Assert.Null(response.Value.DaysOfWeek);

            return response.GetRawResponse();
        });

        [Test]
        public Task AllowedValueEnum() => TestStatus(async (host, pipeline) =>
        {
            var response = await new PetOperations(ClientDiagnostics, pipeline, host).GetByPetIdAsync( "scooby");

            Assert.AreEqual("Scooby Scarface", response.Value.Name);
            Assert.AreEqual("2.1", response.Value.IntEnum.ToString());
            Assert.AreEqual(DaysOfWeekExtensibleEnum.Thursday, response.Value.DaysOfWeek);

            return response.GetRawResponse();
        });

        [Test]
        public Task ExpectedEnum() => TestStatus(async (host, pipeline) =>
        {
            var response = await new PetOperations(ClientDiagnostics, pipeline, host).GetByPetIdAsync( "tommy");

            Assert.AreEqual("Tommy Tomson", response.Value.Name);
            Assert.AreEqual(IntEnum._1, response.Value.IntEnum);
            Assert.AreEqual(DaysOfWeekExtensibleEnum.Monday, response.Value.DaysOfWeek);

            return response.GetRawResponse();
        });

        [Test]
        public Task UnexpectedEnum() => TestStatus(async (host, pipeline) =>
        {
            var response = await new PetOperations(ClientDiagnostics, pipeline, host).GetByPetIdAsync( "casper");

            Assert.AreEqual("Casper Ghosty", response.Value.Name);
            Assert.AreEqual(IntEnum._2, response.Value.IntEnum);
            Assert.AreEqual("Weekend", response.Value.DaysOfWeek.Value.ToString());

            return response.GetRawResponse();
        });
    }
}
