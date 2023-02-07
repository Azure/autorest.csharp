// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using NUnit.Framework;

namespace AutoRest.CSharp.Generation.Writers
{
    public class XmlDocWriterTests
    {
        private XmlDocWriter Writer;

        [SetUp]
        public void Setup()
        {
            Writer = new XmlDocWriter();
        }

        [Test]
        public void NeedInvokeCreateMemberFirst()
        {
            Assert.Throws<InvalidOperationException>(() => Writer.WriteXmlDocumentation("test", null));
        }

        [Test]
        public void EmptyContent()
        {
            AssertEqual(@"<?xml version=""1.0"" encoding=""utf-8""?>
<doc>
  <members>
  </members>
</doc>", Writer.ToString());
        }

        [Test]
        public void EmptyMember()
        {
            using (Writer.CreateMember("foo"))
            {
            };
            AssertEqual(@"<?xml version=""1.0"" encoding=""utf-8""?>
<doc>
  <members>
    <member name=""foo"">
    </member>
  </members>
</doc>", Writer.ToString());
        }

        [Test]
        public void EmptyTag()
        {
            using (Writer.CreateMember("foo"))
            {
                Writer.WriteXmlDocumentation("test", null);
            };
            AssertEqual(@"<?xml version=""1.0"" encoding=""utf-8""?>
<doc>
  <members>
    <member name=""foo"">
    </member>
  </members>
</doc>", Writer.ToString());
        }

        [Test]
        public void OneTag()
        {
            using (Writer.CreateMember("foo"))
            {
                Writer.WriteXmlDocumentation("test", $"Hello, world!");
            };
            AssertEqual(@"<?xml version=""1.0"" encoding=""utf-8""?>
<doc>
  <members>
    <member name=""foo"">
<test>
Hello, world!
</test>
    </member>
  </members>
</doc>", Writer.ToString());
        }

        [Test]
        public void MultipleTags()
        {
            using (Writer.CreateMember("foo"))
            {
                Writer.WriteXmlDocumentation("test", $"Hello, world!");
                Writer.WriteXmlDocumentation("test", $"Hello, world!");
            };
            AssertEqual(@"<?xml version=""1.0"" encoding=""utf-8""?>
<doc>
  <members>
    <member name=""foo"">
<test>
Hello, world!
</test>
<test>
Hello, world!
</test>
    </member>
  </members>
</doc>", Writer.ToString());
        }

        public void MultipleMembers()
        {
            using (Writer.CreateMember("foo"))
            {
                Writer.WriteXmlDocumentation("test", $"Hello, world!");
            };
            using (Writer.CreateMember("fooAsync"))
            {
                Writer.WriteXmlDocumentation("test", $"Hello, world!");
            };
            AssertEqual(@"<?xml version=""1.0"" encoding=""utf-8""?>
<doc>
  <members>
    <member name=""foo"">
<test>
Hello, world!
</test>
    </member>
    <member name=""fooAsync"">
<test>
Hello, world!
</test>
    </member>
  </members>
</doc>", Writer.ToString());
        }

        private void AssertEqual(string expect, string actual)
        {
            Assert.AreEqual(expect.Replace("\r\n", "\n"), actual);
        }
    }
}
