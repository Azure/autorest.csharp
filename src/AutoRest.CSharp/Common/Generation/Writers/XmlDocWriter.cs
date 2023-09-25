// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace AutoRest.CSharp.Generation.Writers
{
    /// <summary>
    /// Writer to compose the content of .Net external XML doc which can be included
    /// throught "// &lt;include&gt;" tag.
    /// For details, see: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments#d36-include
    /// </summary>
    internal class XmlDocWriter
    {
        private readonly XElement _membersElement;

        public XmlDocWriter()
        {
            _membersElement = new XElement("members");
            Document = new XDocument(new XElement("doc", _membersElement));
        }

        public IEnumerable<XElement> Members => _membersElement.Elements("member");

        public XDocument Document { get; }

        private XElement? _lastMember = null;

        public XmlDocWriter AddMember(string docRef)
        {
            _lastMember = new XElement("member", new XAttribute("name", docRef));
            _membersElement.Add(_lastMember);

            return this;
        }

        public XmlDocWriter AddExamples(IEnumerable<(string ExampleInformation, string ExampleCode)> examples)
        {
            if (_lastMember != null && examples.Any())
            {
                var exampleElement = new XElement("example");
                foreach (var example in examples)
                {
                    exampleElement.Add
                    (
                        Environment.NewLine,
                        example.ExampleInformation,
                        Environment.NewLine,
                        new XElement("code", new XCData(Environment.NewLine + example.ExampleCode))
                    );
                }
                _lastMember.Add(exampleElement);
            }

            return this;
        }


        public override string ToString()
        {
            using var memoryStream = new MemoryStream();
            using var xmlWriter = XmlWriter.Create(memoryStream, new XmlWriterSettings { OmitXmlDeclaration = false, Indent = true });
            Document.Save(xmlWriter);
            xmlWriter.Flush();
            ReadOnlySpan<byte> buffer = memoryStream.GetBuffer();
            return Encoding.UTF8.GetString(buffer.Slice(3)); // skip BOM from array
        }
    }
}
