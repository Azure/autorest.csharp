﻿using System;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;
using NUnit.Framework;
using Azure.Core;
using XmlDeserialization;
using XmlDeserialization.Models;
using SingletonResource;

namespace AutoRest.TestServer.Tests.Mgmt.TestProjects
{
    public class XmlDeserializationTests : TestProjectTests
    {
        public XmlDeserializationTests()
            : base("XmlDeserialization") { }

        [Test]
        public void ValidateXmlDeserialization()
        {
            string id = "/subscriptions/27af6a7d-4b66-4d59-8786-0999a97b32b9/resourceGroups/testRg/providers/Microsoft.XmlDeserialization/xmls/fakeXml";
            string name = "fakeXml";
            string type = "Microsoft.XmlDeserialization/xmls";
            XElement xElement = BuildXElement(id, name, type);
            XmlInstanceResourceData xmlInstanceData = XmlInstanceResourceData.DeserializeXmlInstanceResourceData(xElement);
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
            XElement xElement = BuildXElement(id, name, type);
            // ResourceIdentifier changes to lazy initialization, so you won't get the parsing error until you fetch properties
            Assert.DoesNotThrow(() => XmlInstanceResourceData.DeserializeXmlInstanceResourceData(xElement));
            Assert.Throws<FormatException>(() => { var _ = XmlInstanceResourceData.DeserializeXmlInstanceResourceData(xElement).Id.SubscriptionId; });
        }

        [Test]
        public void ValidateXmlDeserializationWithWrongType()
        {
            string id = "/subscriptions/27af6a7d-4b66-4d59-8786-0999a97b32b9/resourceGroups/testRg/providers/Microsoft.XmlDeserialization/xmls/fakeXml";
            string name = "fakeXml";
            string type = "";
            XElement xElement = BuildXElement(id, name, type);
            Assert.Throws<ArgumentException>(() => XmlInstanceResourceData.DeserializeXmlInstanceResourceData(xElement));
        }

        private static XElement BuildXElement(string id, string name, string type)
        {
            return new XElement("XmlInstance",
                new XElement("id", id),
                new XElement("name", name),
                new XElement("type", type)
            );
        }
    }
}
