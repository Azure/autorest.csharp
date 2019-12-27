// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using xml_service;

namespace AutoRest.TestServer.Tests
{
    public class XmlTests : TestServerTestBase
    {
        public XmlTests(TestServerVersion version) : base(version) { }

        [Test]
        public Task GetSimpleAsync() => Test(async (host, pipeline) =>
        {
            var result = await new XmlOperations(ClientDiagnostics, pipeline, host).GetSimpleAsync();
            var value = result.Value;

            Assert.AreEqual("Yours Truly", value.Author);
            Assert.AreEqual("Date of publication", value.Date);
            Assert.AreEqual("Sample Slide Show", value.Title);

            var slides = value.Slides.ToArray();
            Assert.AreEqual(2, slides.Length);

            Assert.AreEqual("Wake up to WonderWidgets!", slides[0].Title);
            Assert.AreEqual("all", slides[0].Type);
            Assert.AreEqual(0, slides[0].Items.Count);

            Assert.AreEqual("Overview", slides[1].Title);
            Assert.AreEqual("all", slides[1].Type);

            var items = slides[1].Items.ToArray();
            Assert.AreEqual("Why WonderWidgets are great", items[0]);
            Assert.AreEqual("", items[1]);
            Assert.AreEqual("Who buys WonderWidgets", items[2]);
        }, true);

        [Test]
        public Task GetComplexTypeRefNoMetaAsync() => Test(async (host, pipeline) =>
        {
            var result = await new XmlOperations(ClientDiagnostics, pipeline, host).GetComplexTypeRefNoMetaAsync();
            var value = result.Value;

            Assert.AreEqual("else", value.Something);
            Assert.AreEqual("myid", value.RefToModel.ID);
        }, true);

        [Test]
        public Task GetComplexTypeRefWithMetaAsync() => Test(async (host, pipeline) =>
        {
            var result = await new XmlOperations(ClientDiagnostics, pipeline, host).GetComplexTypeRefWithMetaAsync();
            var value = result.Value;

            Assert.AreEqual("else", value.Something);
            Assert.AreEqual("myid", value.RefToModel.ID);
        }, true);

        [Test]
        public Task GetAclsAsync() => Test(async (host, pipeline) =>
        {
            var result = await new XmlOperations(ClientDiagnostics, pipeline, host).GetAclsAsync();
            var value = result.Value;

            Assert.AreEqual(1, value.Count);

            var acl = value.Single();

            Assert.AreEqual("MTIzNDU2Nzg5MDEyMzQ1Njc4OTAxMjM0NTY3ODkwMTI=", acl.Id);
            Assert.AreEqual(DateTimeOffset.Parse("2009-09-28T08:49:37.123Z"), acl.AccessPolicy.Start);
            Assert.AreEqual(DateTimeOffset.Parse("2009-09-29T08:49:37.123Z"), acl.AccessPolicy.Expiry);
        }, true);

        [Test]
        public Task GetHeadersAsync() => Test(async (host, pipeline) =>
        {
            var result = await new XmlOperations(ClientDiagnostics, pipeline, host).GetHeadersAsync();
            var value = result.Headers;

            Assert.AreEqual("custom-value", value.CustomHeader);
        }, true);

        [Test]
        public Task Get() => Test(async (host, pipeline) =>
        {
            var result = await new XmlOperations(ClientDiagnostics, pipeline, host).ListBlobsAsync();
            var value = result.Value;

            /*<EnumerationResults ContainerName="https://myaccount.blob.core.windows.net/mycontainer">
  <Blobs>
    <Blob>
      <Name>blob1.txt</Name>
      <Url>https://myaccount.blob.core.windows.net/mycontainer/blob1.txt</Url>
      <Properties>
        <Last-Modified>Wed, 09 Sep 2009 09:20:02 GMT</Last-Modified>
        <Etag>0x8CBFF45D8A29A19</Etag>
        <Content-Length>100</Content-Length>
        <Content-Type>text/html</Content-Type>
        <Content-Encoding />
        <Content-Language>en-US</Content-Language>
        <Content-MD5 />
        <Cache-Control>no-cache</Cache-Control>
        <BlobType>BlockBlob</BlobType>
        <LeaseStatus>unlocked</LeaseStatus>
      </Properties>
      <Metadata>
        <Color>blue</Color>
        <BlobNumber>01</BlobNumber>
        <SomeMetadataName>SomeMetadataValue</SomeMetadataName>
      </Metadata>
    </Blob>
    <Blob>
      <Name>blob2.txt</Name>
      <Snapshot>2009-09-09T09:20:03.0427659Z</Snapshot>
      <Url>https://myaccount.blob.core.windows.net/mycontainer/blob2.txt?snapshot=2009-09-09T09%3a20%3a03.0427659Z</Url>
      <Properties>
        <Last-Modified>Wed, 09 Sep 2009 09:20:02 GMT</Last-Modified>
        <Etag>0x8CBFF45D8B4C212</Etag>
        <Content-Length>5000</Content-Length>
        <Content-Type>application/octet-stream</Content-Type>
        <Content-Encoding>gzip</Content-Encoding>
        <Content-Language />
        <Content-MD5 />
        <Cache-Control />
        <BlobType>BlockBlob</BlobType>
      </Properties>
      <Metadata>
        <Color>green</Color>
        <BlobNumber>02</BlobNumber>
        <SomeMetadataName>SomeMetadataValue</SomeMetadataName>
        <x-ms-invalid-name>nasdf$@#$$</x-ms-invalid-name>
      </Metadata>
    </Blob>
    <Blob>
      <Name>blob2.txt</Name>
      <Snapshot>2009-09-09T09:20:03.1587543Z</Snapshot>
      <Url>https://myaccount.blob.core.windows.net/mycontainer/blob2.txt?snapshot=2009-09-09T09%3a20%3a03.1587543Z</Url>
      <Properties>
        <Last-Modified>Wed, 09 Sep 2009 09:20:02 GMT</Last-Modified>
        <Etag>0x8CBFF45D8B4C212</Etag>
        <Content-Length>5000</Content-Length>
        <Content-Type>application/octet-stream</Content-Type>
        <Content-Encoding>gzip</Content-Encoding>
        <Content-Language />
        <Content-MD5 />
        <Cache-Control />
        <BlobType>BlockBlob</BlobType>
      </Properties>
      <Metadata>
        <Color>green</Color>
        <BlobNumber>02</BlobNumber>
        <SomeMetadataName>SomeMetadataValue</SomeMetadataName>
      </Metadata>
    </Blob>
    <Blob>
      <Name>blob2.txt</Name>
      <Url>https://myaccount.blob.core.windows.net/mycontainer/blob2.txt</Url>
      <Properties>
        <Last-Modified>Wed, 09 Sep 2009 09:20:02 GMT</Last-Modified>
        <Etag>0x8CBFF45D8B4C212</Etag>
        <Content-Length>5000</Content-Length>
        <Content-Type>application/octet-stream</Content-Type>
        <Content-Encoding>gzip</Content-Encoding>
        <Content-Language />
        <Content-MD5 />
        <Cache-Control />
        <BlobType>BlockBlob</BlobType>
        <LeaseStatus>unlocked</LeaseStatus>
      </Properties>
      <Metadata>
        <Color>green</Color>
        <BlobNumber>02</BlobNumber>
        <SomeMetadataName>SomeMetadataValue</SomeMetadataName>
      </Metadata>
    </Blob>
    <Blob>
      <Name>blob3.txt</Name>
      <Url>https://myaccount.blob.core.windows.net/mycontainer/blob3.txt</Url>
      <Properties>
        <Last-Modified>Wed, 09 Sep 2009 09:20:03 GMT</Last-Modified>
        <Etag>0x8CBFF45D911FADF</Etag>
        <Content-Length>16384</Content-Length>
        <Content-Type>image/jpeg</Content-Type>
        <Content-Encoding />
        <Content-Language />
        <Content-MD5 />
        <Cache-Control />
        <x-ms-blob-sequence-number>3</x-ms-blob-sequence-number>
        <BlobType>PageBlob</BlobType>
        <LeaseStatus>locked</LeaseStatus>
      </Properties>
      <Metadata>
        <Color>yellow</Color>
        <BlobNumber>03</BlobNumber>
        <SomeMetadataName>SomeMetadataValue</SomeMetadataName>
      </Metadata>
    </Blob>
  </Blobs>
  <NextMarker />
</EnumerationResults>*/
        }, true);

        [Test]
        public Task GetServicePropertiesAsync() => Test(async (host, pipeline) =>
        {
            var result = await new XmlOperations(ClientDiagnostics, pipeline, host).GetServicePropertiesAsync();
            var value = result.Value;

            Assert.AreEqual("1.0", value.Logging.Version);
            Assert.AreEqual(true, value.Logging.Delete);
            Assert.AreEqual(false, value.Logging.Read);
            Assert.AreEqual(true, value.Logging.Write);
            Assert.AreEqual(7, value.Logging.RetentionPolicy.Days);
            Assert.AreEqual(true, value.Logging.RetentionPolicy.Enabled);

            Assert.AreEqual("1.0", value.HourMetrics.Version);
            Assert.AreEqual(true, value.HourMetrics.Enabled);
            Assert.AreEqual(false, value.HourMetrics.IncludeAPIs);
            Assert.AreEqual(7, value.HourMetrics.RetentionPolicy.Days);
            Assert.AreEqual(true, value.HourMetrics.RetentionPolicy.Enabled);

            Assert.AreEqual("1.0", value.MinuteMetrics.Version);
            Assert.AreEqual(true, value.MinuteMetrics.Enabled);
            Assert.AreEqual(true, value.MinuteMetrics.IncludeAPIs);
            Assert.AreEqual(7, value.MinuteMetrics.RetentionPolicy.Days);
            Assert.AreEqual(true, value.MinuteMetrics.RetentionPolicy.Enabled);
        }, true);
    }
}
