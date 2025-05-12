using System;
using System.Xml.Linq;
using NUnit.Framework;
using MgmtXmlDeserialization;
using System.ClientModel.Primitives;
using System.Reflection;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class MgmtXmlDeserializationTests : TestProjectTests
    {
        public MgmtXmlDeserializationTests()
            : base("MgmtXmlDeserialization") { }

        private protected override Assembly GetAssembly() => typeof(XmlInstanceData).Assembly;

        [Test]
        public void ValidateXmlDeserialization()
        {
            string id = "/subscriptions/27af6a7d-4b66-4d59-8786-0999a97b32b9/resourceGroups/testRg/providers/Microsoft.XmlDeserialization/xmls/fakeXml";
            string name = "fakeXml";
            string type = "Microsoft.XmlDeserialization/xmls";
            XmlInstanceData xmlInstanceData = ModelReaderWriter.Read<XmlInstanceData>(BinaryData.FromString(BuildXElement(id, name, type)), ModelReaderWriterOptions.Xml);
            Assert.AreEqual(id, xmlInstanceData.Id.ToString());
            Assert.AreEqual(name, xmlInstanceData.Name);
            Assert.AreEqual(type, xmlInstanceData.ResourceType.ToString());
        }

        [Test]
        public void ValidateXmlDeserializationWithWrongId()
        {
            string id = "/subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.XmlDeserialization/xmls/fakeXml";
            string name = "fakeXml";
            string type = "Microsoft.XmlDeserialization/xmls";
            string xElement = BuildXElement(id, name, type);
            // ResourceIdentifier changes to lazy initialization, so you won't get the parsing error until you fetch properties
            Assert.DoesNotThrow(() => ModelReaderWriter.Read<XmlInstanceData>(BinaryData.FromString(xElement), ModelReaderWriterOptions.Xml));
            Assert.Throws<FormatException>(() => { var _ = ModelReaderWriter.Read<XmlInstanceData>(BinaryData.FromString(xElement), ModelReaderWriterOptions.Xml).Id.SubscriptionId; });
        }

        [Test]
        public void ValidateXmlDeserializationWithWrongType()
        {
            string id = "/subscriptions/27af6a7d-4b66-4d59-8786-0999a97b32b9/resourceGroups/testRg/providers/Microsoft.XmlDeserialization/xmls/fakeXml";
            string name = "fakeXml";
            string type = "";
            string xElement = BuildXElement(id, name, type);
            Assert.Throws<ArgumentException>(() => ModelReaderWriter.Read<XmlInstanceData>(BinaryData.FromString(xElement), ModelReaderWriterOptions.Xml));
        }

        private static string BuildXElement(string id, string name, string type)
        {
            return new XElement("XmlInstance",
                new XElement("id", id),
                new XElement("name", name),
                new XElement("type", type)
            ).ToString();
        }
    }
}
