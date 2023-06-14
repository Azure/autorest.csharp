// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using xml_service.Models;

namespace xml_service
{
    internal partial class XmlRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of XmlRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public XmlRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateGetComplexTypeRefNoMetaRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/complex-type-ref-no-meta", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Get a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<RootWithRefAndNoMeta>> GetComplexTypeRefNoMetaAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexTypeRefNoMetaRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RootWithRefAndNoMeta value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("RootWithRefAndNoMeta") is XElement rootWithRefAndNoMetaElement)
                        {
                            value = RootWithRefAndNoMeta.DeserializeRootWithRefAndNoMeta(rootWithRefAndNoMetaElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<RootWithRefAndNoMeta> GetComplexTypeRefNoMeta(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexTypeRefNoMetaRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RootWithRefAndNoMeta value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("RootWithRefAndNoMeta") is XElement rootWithRefAndNoMetaElement)
                        {
                            value = RootWithRefAndNoMeta.DeserializeRootWithRefAndNoMeta(rootWithRefAndNoMetaElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutComplexTypeRefNoMetaRequest(RootWithRefAndNoMeta model)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/complex-type-ref-no-meta", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(model, "RootWithRefAndNoMeta");
            request.Content = content;
            return message;
        }

        /// <summary> Puts a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="model"> The RootWithRefAndNoMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        public async Task<Response> PutComplexTypeRefNoMetaAsync(RootWithRefAndNoMeta model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using var message = CreatePutComplexTypeRefNoMetaRequest(model);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="model"> The RootWithRefAndNoMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        public Response PutComplexTypeRefNoMeta(RootWithRefAndNoMeta model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using var message = CreatePutComplexTypeRefNoMetaRequest(model);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetComplexTypeRefWithMetaRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/complex-type-ref-with-meta", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Get a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<RootWithRefAndMeta>> GetComplexTypeRefWithMetaAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexTypeRefWithMetaRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RootWithRefAndMeta value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("RootWithRefAndMeta") is XElement rootWithRefAndMetaElement)
                        {
                            value = RootWithRefAndMeta.DeserializeRootWithRefAndMeta(rootWithRefAndMetaElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<RootWithRefAndMeta> GetComplexTypeRefWithMeta(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetComplexTypeRefWithMetaRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RootWithRefAndMeta value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("RootWithRefAndMeta") is XElement rootWithRefAndMetaElement)
                        {
                            value = RootWithRefAndMeta.DeserializeRootWithRefAndMeta(rootWithRefAndMetaElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutComplexTypeRefWithMetaRequest(RootWithRefAndMeta model)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/complex-type-ref-with-meta", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(model, "RootWithRefAndMeta");
            request.Content = content;
            return message;
        }

        /// <summary> Puts a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="model"> The RootWithRefAndMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        public async Task<Response> PutComplexTypeRefWithMetaAsync(RootWithRefAndMeta model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using var message = CreatePutComplexTypeRefWithMetaRequest(model);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="model"> The RootWithRefAndMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        public Response PutComplexTypeRefWithMeta(RootWithRefAndMeta model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using var message = CreatePutComplexTypeRefWithMetaRequest(model);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetSimpleRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/simple", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Get a simple XML document. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<Slideshow>> GetSimpleAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSimpleRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Slideshow value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("slideshow") is XElement slideshowElement)
                        {
                            value = Slideshow.DeserializeSlideshow(slideshowElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get a simple XML document. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Slideshow> GetSimple(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetSimpleRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Slideshow value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("slideshow") is XElement slideshowElement)
                        {
                            value = Slideshow.DeserializeSlideshow(slideshowElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutSimpleRequest(Slideshow slideshow)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/simple", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(slideshow, "slideshow");
            request.Content = content;
            return message;
        }

        /// <summary> Put a simple XML document. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="slideshow"/> is null. </exception>
        public async Task<Response> PutSimpleAsync(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            if (slideshow == null)
            {
                throw new ArgumentNullException(nameof(slideshow));
            }

            using var message = CreatePutSimpleRequest(slideshow);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put a simple XML document. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="slideshow"/> is null. </exception>
        public Response PutSimple(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            if (slideshow == null)
            {
                throw new ArgumentNullException(nameof(slideshow));
            }

            using var message = CreatePutSimpleRequest(slideshow);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetWrappedListsRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/wrapped-lists", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Get an XML document with multiple wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<AppleBarrel>> GetWrappedListsAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetWrappedListsRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AppleBarrel value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("AppleBarrel") is XElement appleBarrelElement)
                        {
                            value = AppleBarrel.DeserializeAppleBarrel(appleBarrelElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an XML document with multiple wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<AppleBarrel> GetWrappedLists(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetWrappedListsRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AppleBarrel value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("AppleBarrel") is XElement appleBarrelElement)
                        {
                            value = AppleBarrel.DeserializeAppleBarrel(appleBarrelElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutWrappedListsRequest(AppleBarrel wrappedLists)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/wrapped-lists", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(wrappedLists, "AppleBarrel");
            request.Content = content;
            return message;
        }

        /// <summary> Put an XML document with multiple wrapped lists. </summary>
        /// <param name="wrappedLists"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="wrappedLists"/> is null. </exception>
        public async Task<Response> PutWrappedListsAsync(AppleBarrel wrappedLists, CancellationToken cancellationToken = default)
        {
            if (wrappedLists == null)
            {
                throw new ArgumentNullException(nameof(wrappedLists));
            }

            using var message = CreatePutWrappedListsRequest(wrappedLists);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put an XML document with multiple wrapped lists. </summary>
        /// <param name="wrappedLists"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="wrappedLists"/> is null. </exception>
        public Response PutWrappedLists(AppleBarrel wrappedLists, CancellationToken cancellationToken = default)
        {
            if (wrappedLists == null)
            {
                throw new ArgumentNullException(nameof(wrappedLists));
            }

            using var message = CreatePutWrappedListsRequest(wrappedLists);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetHeadersRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/headers", false);
            request.Uri = uri;
            return message;
        }

        /// <summary> Get strongly-typed response headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<XmlGetHeadersHeaders>> GetHeadersAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetHeadersRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new XmlGetHeadersHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get strongly-typed response headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<XmlGetHeadersHeaders> GetHeaders(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetHeadersRequest();
            _pipeline.Send(message, cancellationToken);
            var headers = new XmlGetHeadersHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    return ResponseWithHeaders.FromValue(headers, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetEmptyListRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/empty-list", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Get an empty list. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<Slideshow>> GetEmptyListAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEmptyListRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Slideshow value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("slideshow") is XElement slideshowElement)
                        {
                            value = Slideshow.DeserializeSlideshow(slideshowElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an empty list. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Slideshow> GetEmptyList(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEmptyListRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Slideshow value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("slideshow") is XElement slideshowElement)
                        {
                            value = Slideshow.DeserializeSlideshow(slideshowElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutEmptyListRequest(Slideshow slideshow)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/empty-list", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(slideshow, "slideshow");
            request.Content = content;
            return message;
        }

        /// <summary> Puts an empty list. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="slideshow"/> is null. </exception>
        public async Task<Response> PutEmptyListAsync(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            if (slideshow == null)
            {
                throw new ArgumentNullException(nameof(slideshow));
            }

            using var message = CreatePutEmptyListRequest(slideshow);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts an empty list. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="slideshow"/> is null. </exception>
        public Response PutEmptyList(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            if (slideshow == null)
            {
                throw new ArgumentNullException(nameof(slideshow));
            }

            using var message = CreatePutEmptyListRequest(slideshow);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetEmptyWrappedListsRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/empty-wrapped-lists", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Gets some empty wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<AppleBarrel>> GetEmptyWrappedListsAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEmptyWrappedListsRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AppleBarrel value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("AppleBarrel") is XElement appleBarrelElement)
                        {
                            value = AppleBarrel.DeserializeAppleBarrel(appleBarrelElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets some empty wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<AppleBarrel> GetEmptyWrappedLists(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEmptyWrappedListsRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AppleBarrel value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("AppleBarrel") is XElement appleBarrelElement)
                        {
                            value = AppleBarrel.DeserializeAppleBarrel(appleBarrelElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutEmptyWrappedListsRequest(AppleBarrel appleBarrel)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/empty-wrapped-lists", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(appleBarrel, "AppleBarrel");
            request.Content = content;
            return message;
        }

        /// <summary> Puts some empty wrapped lists. </summary>
        /// <param name="appleBarrel"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="appleBarrel"/> is null. </exception>
        public async Task<Response> PutEmptyWrappedListsAsync(AppleBarrel appleBarrel, CancellationToken cancellationToken = default)
        {
            if (appleBarrel == null)
            {
                throw new ArgumentNullException(nameof(appleBarrel));
            }

            using var message = CreatePutEmptyWrappedListsRequest(appleBarrel);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts some empty wrapped lists. </summary>
        /// <param name="appleBarrel"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="appleBarrel"/> is null. </exception>
        public Response PutEmptyWrappedLists(AppleBarrel appleBarrel, CancellationToken cancellationToken = default)
        {
            if (appleBarrel == null)
            {
                throw new ArgumentNullException(nameof(appleBarrel));
            }

            using var message = CreatePutEmptyWrappedListsRequest(appleBarrel);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRootListRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/root-list", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Gets a list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<Banana>>> GetRootListAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRootListRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Banana> value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("bananas") is XElement bananasElement)
                        {
                            var array = new List<Banana>();
                            foreach (var e in bananasElement.Elements("banana"))
                            {
                                array.Add(Banana.DeserializeBanana(e));
                            }
                            value = array;
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<Banana>> GetRootList(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRootListRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Banana> value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("bananas") is XElement bananasElement)
                        {
                            var array = new List<Banana>();
                            foreach (var e in bananasElement.Elements("banana"))
                            {
                                array.Add(Banana.DeserializeBanana(e));
                            }
                            value = array;
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutRootListRequest(IEnumerable<Banana> bananas)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/root-list", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteStartElement("bananas");
            foreach (var item in bananas)
            {
                content.XmlWriter.WriteObjectValue(item, "banana");
            }
            content.XmlWriter.WriteEndElement();
            request.Content = content;
            return message;
        }

        /// <summary> Puts a list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bananas"/> is null. </exception>
        public async Task<Response> PutRootListAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var message = CreatePutRootListRequest(bananas);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts a list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bananas"/> is null. </exception>
        public Response PutRootList(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var message = CreatePutRootListRequest(bananas);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetRootListSingleItemRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/root-list-single-item", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Gets a list with a single item. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<Banana>>> GetRootListSingleItemAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRootListSingleItemRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Banana> value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("bananas") is XElement bananasElement)
                        {
                            var array = new List<Banana>();
                            foreach (var e in bananasElement.Elements("banana"))
                            {
                                array.Add(Banana.DeserializeBanana(e));
                            }
                            value = array;
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a list with a single item. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<Banana>> GetRootListSingleItem(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetRootListSingleItemRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Banana> value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("bananas") is XElement bananasElement)
                        {
                            var array = new List<Banana>();
                            foreach (var e in bananasElement.Elements("banana"))
                            {
                                array.Add(Banana.DeserializeBanana(e));
                            }
                            value = array;
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutRootListSingleItemRequest(IEnumerable<Banana> bananas)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/root-list-single-item", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteStartElement("bananas");
            foreach (var item in bananas)
            {
                content.XmlWriter.WriteObjectValue(item, "banana");
            }
            content.XmlWriter.WriteEndElement();
            request.Content = content;
            return message;
        }

        /// <summary> Puts a list with a single item. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bananas"/> is null. </exception>
        public async Task<Response> PutRootListSingleItemAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var message = CreatePutRootListSingleItemRequest(bananas);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts a list with a single item. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bananas"/> is null. </exception>
        public Response PutRootListSingleItem(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var message = CreatePutRootListSingleItemRequest(bananas);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetEmptyRootListRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/empty-root-list", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Gets an empty list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<Banana>>> GetEmptyRootListAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEmptyRootListRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Banana> value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("bananas") is XElement bananasElement)
                        {
                            var array = new List<Banana>();
                            foreach (var e in bananasElement.Elements("banana"))
                            {
                                array.Add(Banana.DeserializeBanana(e));
                            }
                            value = array;
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets an empty list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<Banana>> GetEmptyRootList(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEmptyRootListRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<Banana> value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("bananas") is XElement bananasElement)
                        {
                            var array = new List<Banana>();
                            foreach (var e in bananasElement.Elements("banana"))
                            {
                                array.Add(Banana.DeserializeBanana(e));
                            }
                            value = array;
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutEmptyRootListRequest(IEnumerable<Banana> bananas)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/empty-root-list", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteStartElement("bananas");
            foreach (var item in bananas)
            {
                content.XmlWriter.WriteObjectValue(item, "banana");
            }
            content.XmlWriter.WriteEndElement();
            request.Content = content;
            return message;
        }

        /// <summary> Puts an empty list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bananas"/> is null. </exception>
        public async Task<Response> PutEmptyRootListAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var message = CreatePutEmptyRootListRequest(bananas);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts an empty list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bananas"/> is null. </exception>
        public Response PutEmptyRootList(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var message = CreatePutEmptyRootListRequest(bananas);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetEmptyChildElementRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/empty-child-element", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Gets an XML document with an empty child element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<Banana>> GetEmptyChildElementAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEmptyChildElementRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Banana value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("banana") is XElement bananaElement)
                        {
                            value = Banana.DeserializeBanana(bananaElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets an XML document with an empty child element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Banana> GetEmptyChildElement(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetEmptyChildElementRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Banana value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("banana") is XElement bananaElement)
                        {
                            value = Banana.DeserializeBanana(bananaElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutEmptyChildElementRequest(Banana banana)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/empty-child-element", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(banana, "banana");
            request.Content = content;
            return message;
        }

        /// <summary> Puts a value with an empty child element. </summary>
        /// <param name="banana"> The Banana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="banana"/> is null. </exception>
        public async Task<Response> PutEmptyChildElementAsync(Banana banana, CancellationToken cancellationToken = default)
        {
            if (banana == null)
            {
                throw new ArgumentNullException(nameof(banana));
            }

            using var message = CreatePutEmptyChildElementRequest(banana);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts a value with an empty child element. </summary>
        /// <param name="banana"> The Banana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="banana"/> is null. </exception>
        public Response PutEmptyChildElement(Banana banana, CancellationToken cancellationToken = default)
        {
            if (banana == null)
            {
                throw new ArgumentNullException(nameof(banana));
            }

            using var message = CreatePutEmptyChildElementRequest(banana);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListContainersRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/", false);
            uri.AppendQuery("comp", "list", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Lists containers in a storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ListContainersResponse>> ListContainersAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateListContainersRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ListContainersResponse value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("EnumerationResults") is XElement enumerationResultsElement)
                        {
                            value = ListContainersResponse.DeserializeListContainersResponse(enumerationResultsElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists containers in a storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ListContainersResponse> ListContainers(CancellationToken cancellationToken = default)
        {
            using var message = CreateListContainersRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ListContainersResponse value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("EnumerationResults") is XElement enumerationResultsElement)
                        {
                            value = ListContainersResponse.DeserializeListContainersResponse(enumerationResultsElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetServicePropertiesRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/", false);
            uri.AppendQuery("comp", "properties", true);
            uri.AppendQuery("restype", "service", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Gets storage service properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<StorageServiceProperties>> GetServicePropertiesAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetServicePropertiesRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        StorageServiceProperties value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("StorageServiceProperties") is XElement storageServicePropertiesElement)
                        {
                            value = StorageServiceProperties.DeserializeStorageServiceProperties(storageServicePropertiesElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets storage service properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<StorageServiceProperties> GetServiceProperties(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetServicePropertiesRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        StorageServiceProperties value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("StorageServiceProperties") is XElement storageServicePropertiesElement)
                        {
                            value = StorageServiceProperties.DeserializeStorageServiceProperties(storageServicePropertiesElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutServicePropertiesRequest(StorageServiceProperties properties)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/", false);
            uri.AppendQuery("comp", "properties", true);
            uri.AppendQuery("restype", "service", true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(properties, "StorageServiceProperties");
            request.Content = content;
            return message;
        }

        /// <summary> Puts storage service properties. </summary>
        /// <param name="properties"> The StorageServiceProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public async Task<Response> PutServicePropertiesAsync(StorageServiceProperties properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreatePutServicePropertiesRequest(properties);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts storage service properties. </summary>
        /// <param name="properties"> The StorageServiceProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public Response PutServiceProperties(StorageServiceProperties properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreatePutServicePropertiesRequest(properties);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetAclsRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/mycontainer", false);
            uri.AppendQuery("comp", "acl", true);
            uri.AppendQuery("restype", "container", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Gets storage ACLs for a container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<IReadOnlyList<SignedIdentifier>>> GetAclsAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetAclsRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<SignedIdentifier> value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("SignedIdentifiers") is XElement signedIdentifiersElement)
                        {
                            var array = new List<SignedIdentifier>();
                            foreach (var e in signedIdentifiersElement.Elements("SignedIdentifier"))
                            {
                                array.Add(SignedIdentifier.DeserializeSignedIdentifier(e));
                            }
                            value = array;
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets storage ACLs for a container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<IReadOnlyList<SignedIdentifier>> GetAcls(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetAclsRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        IReadOnlyList<SignedIdentifier> value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("SignedIdentifiers") is XElement signedIdentifiersElement)
                        {
                            var array = new List<SignedIdentifier>();
                            foreach (var e in signedIdentifiersElement.Elements("SignedIdentifier"))
                            {
                                array.Add(SignedIdentifier.DeserializeSignedIdentifier(e));
                            }
                            value = array;
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutAclsRequest(IEnumerable<SignedIdentifier> properties)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/mycontainer", false);
            uri.AppendQuery("comp", "acl", true);
            uri.AppendQuery("restype", "container", true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteStartElement("SignedIdentifiers");
            foreach (var item in properties)
            {
                content.XmlWriter.WriteObjectValue(item, "SignedIdentifier");
            }
            content.XmlWriter.WriteEndElement();
            request.Content = content;
            return message;
        }

        /// <summary> Puts storage ACLs for a container. </summary>
        /// <param name="properties"> The SignedIdentifiers to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public async Task<Response> PutAclsAsync(IEnumerable<SignedIdentifier> properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreatePutAclsRequest(properties);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Puts storage ACLs for a container. </summary>
        /// <param name="properties"> The SignedIdentifiers to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public Response PutAcls(IEnumerable<SignedIdentifier> properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreatePutAclsRequest(properties);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListBlobsRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/mycontainer", false);
            uri.AppendQuery("comp", "list", true);
            uri.AppendQuery("restype", "container", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Lists blobs in a storage container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ListBlobsResponse>> ListBlobsAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateListBlobsRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ListBlobsResponse value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("EnumerationResults") is XElement enumerationResultsElement)
                        {
                            value = ListBlobsResponse.DeserializeListBlobsResponse(enumerationResultsElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Lists blobs in a storage container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ListBlobsResponse> ListBlobs(CancellationToken cancellationToken = default)
        {
            using var message = CreateListBlobsRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ListBlobsResponse value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("EnumerationResults") is XElement enumerationResultsElement)
                        {
                            value = ListBlobsResponse.DeserializeListBlobsResponse(enumerationResultsElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateJsonInputRequest(JsonInput properties)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/jsoninput", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(properties);
            request.Content = content;
            return message;
        }

        /// <summary> A Swagger with XML that has one operation that takes JSON as input. You need to send the ID number 42. </summary>
        /// <param name="properties"> The JsonInput to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public async Task<Response> JsonInputAsync(JsonInput properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreateJsonInputRequest(properties);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A Swagger with XML that has one operation that takes JSON as input. You need to send the ID number 42. </summary>
        /// <param name="properties"> The JsonInput to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public Response JsonInput(JsonInput properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var message = CreateJsonInputRequest(properties);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateJsonOutputRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/jsonoutput", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> A Swagger with XML that has one operation that returns JSON. ID number 42. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<JsonOutput>> JsonOutputAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateJsonOutputRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        JsonOutput value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = Models.JsonOutput.DeserializeJsonOutput(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> A Swagger with XML that has one operation that returns JSON. ID number 42. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<JsonOutput> JsonOutput(CancellationToken cancellationToken = default)
        {
            using var message = CreateJsonOutputRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        JsonOutput value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = Models.JsonOutput.DeserializeJsonOutput(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetXMsTextRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/x-ms-text", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Get back an XML object with an x-ms-text property, which should translate to the returned object's 'language' property being 'english' and its 'content' property being 'I am text'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ObjectWithXMsTextProperty>> GetXMsTextAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetXMsTextRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ObjectWithXMsTextProperty value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("Data") is XElement dataElement)
                        {
                            value = ObjectWithXMsTextProperty.DeserializeObjectWithXMsTextProperty(dataElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get back an XML object with an x-ms-text property, which should translate to the returned object's 'language' property being 'english' and its 'content' property being 'I am text'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ObjectWithXMsTextProperty> GetXMsText(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetXMsTextRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ObjectWithXMsTextProperty value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("Data") is XElement dataElement)
                        {
                            value = ObjectWithXMsTextProperty.DeserializeObjectWithXMsTextProperty(dataElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetBytesRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/bytes", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Get an XML document with binary property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ModelWithByteProperty>> GetBytesAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBytesRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ModelWithByteProperty value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("ModelWithByteProperty") is XElement modelWithBytePropertyElement)
                        {
                            value = ModelWithByteProperty.DeserializeModelWithByteProperty(modelWithBytePropertyElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an XML document with binary property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ModelWithByteProperty> GetBytes(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetBytesRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ModelWithByteProperty value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("ModelWithByteProperty") is XElement modelWithBytePropertyElement)
                        {
                            value = ModelWithByteProperty.DeserializeModelWithByteProperty(modelWithBytePropertyElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutBinaryRequest(ModelWithByteProperty slideshow)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/bytes", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(slideshow, "ModelWithByteProperty");
            request.Content = content;
            return message;
        }

        /// <summary> Put an XML document with binary property. </summary>
        /// <param name="slideshow"> The ModelWithByteProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="slideshow"/> is null. </exception>
        public async Task<Response> PutBinaryAsync(ModelWithByteProperty slideshow, CancellationToken cancellationToken = default)
        {
            if (slideshow == null)
            {
                throw new ArgumentNullException(nameof(slideshow));
            }

            using var message = CreatePutBinaryRequest(slideshow);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put an XML document with binary property. </summary>
        /// <param name="slideshow"> The ModelWithByteProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="slideshow"/> is null. </exception>
        public Response PutBinary(ModelWithByteProperty slideshow, CancellationToken cancellationToken = default)
        {
            if (slideshow == null)
            {
                throw new ArgumentNullException(nameof(slideshow));
            }

            using var message = CreatePutBinaryRequest(slideshow);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetUriRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/url", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            return message;
        }

        /// <summary> Get an XML document with uri property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ModelWithUrlProperty>> GetUriAsync(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUriRequest();
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ModelWithUrlProperty value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("ModelWithUrlProperty") is XElement modelWithUrlPropertyElement)
                        {
                            value = ModelWithUrlProperty.DeserializeModelWithUrlProperty(modelWithUrlPropertyElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Get an XML document with uri property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ModelWithUrlProperty> GetUri(CancellationToken cancellationToken = default)
        {
            using var message = CreateGetUriRequest();
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ModelWithUrlProperty value = default;
                        var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                        if (document.Element("ModelWithUrlProperty") is XElement modelWithUrlPropertyElement)
                        {
                            value = ModelWithUrlProperty.DeserializeModelWithUrlProperty(modelWithUrlPropertyElement);
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePutUriRequest(ModelWithUrlProperty model)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/xml/url", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/xml");
            request.Headers.Add("Content-Type", "application/xml");
            var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(model, "ModelWithUrlProperty");
            request.Content = content;
            return message;
        }

        /// <summary> Put an XML document with uri property. </summary>
        /// <param name="model"> The ModelWithUrlProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        public async Task<Response> PutUriAsync(ModelWithUrlProperty model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using var message = CreatePutUriRequest(model);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Put an XML document with uri property. </summary>
        /// <param name="model"> The ModelWithUrlProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
        public Response PutUri(ModelWithUrlProperty model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using var message = CreatePutUriRequest(model);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 201:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
