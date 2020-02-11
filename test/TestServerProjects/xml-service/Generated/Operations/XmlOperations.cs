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
    internal partial class XmlOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of XmlOperations. </summary>
        public XmlOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string host = "http://localhost:3000")
        {
            if (host == null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            this.host = host;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateGetComplexTypeRefNoMetaRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/complex-type-ref-no-meta", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<RootWithRefAndNoMeta>> GetComplexTypeRefNoMetaAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetComplexTypeRefNoMeta");
            scope.Start();
            try
            {
                using var message = CreateGetComplexTypeRefNoMetaRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            RootWithRefAndNoMeta value = default;
                            var rootWithRefAndNoMeta = document.Element("RootWithRefAndNoMeta");
                            if (rootWithRefAndNoMeta != null)
                            {
                                value = RootWithRefAndNoMeta.DeserializeRootWithRefAndNoMeta(rootWithRefAndNoMeta);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<RootWithRefAndNoMeta> GetComplexTypeRefNoMeta(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetComplexTypeRefNoMeta");
            scope.Start();
            try
            {
                using var message = CreateGetComplexTypeRefNoMetaRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            RootWithRefAndNoMeta value = default;
                            var rootWithRefAndNoMeta = document.Element("RootWithRefAndNoMeta");
                            if (rootWithRefAndNoMeta != null)
                            {
                                value = RootWithRefAndNoMeta.DeserializeRootWithRefAndNoMeta(rootWithRefAndNoMeta);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutComplexTypeRefNoMetaRequest(RootWithRefAndNoMeta model)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/complex-type-ref-no-meta", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(model, "RootWithRefAndNoMeta");
            request.Content = content;
            return message;
        }
        /// <summary> Puts a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="model"> The RootWithRefAndNoMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutComplexTypeRefNoMetaAsync(RootWithRefAndNoMeta model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutComplexTypeRefNoMeta");
            scope.Start();
            try
            {
                using var message = CreatePutComplexTypeRefNoMetaRequest(model);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Puts a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="model"> The RootWithRefAndNoMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutComplexTypeRefNoMeta(RootWithRefAndNoMeta model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutComplexTypeRefNoMeta");
            scope.Start();
            try
            {
                using var message = CreatePutComplexTypeRefNoMetaRequest(model);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetComplexTypeRefWithMetaRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/complex-type-ref-with-meta", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<RootWithRefAndMeta>> GetComplexTypeRefWithMetaAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetComplexTypeRefWithMeta");
            scope.Start();
            try
            {
                using var message = CreateGetComplexTypeRefWithMetaRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            RootWithRefAndMeta value = default;
                            var rootWithRefAndMeta = document.Element("RootWithRefAndMeta");
                            if (rootWithRefAndMeta != null)
                            {
                                value = RootWithRefAndMeta.DeserializeRootWithRefAndMeta(rootWithRefAndMeta);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<RootWithRefAndMeta> GetComplexTypeRefWithMeta(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetComplexTypeRefWithMeta");
            scope.Start();
            try
            {
                using var message = CreateGetComplexTypeRefWithMetaRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            RootWithRefAndMeta value = default;
                            var rootWithRefAndMeta = document.Element("RootWithRefAndMeta");
                            if (rootWithRefAndMeta != null)
                            {
                                value = RootWithRefAndMeta.DeserializeRootWithRefAndMeta(rootWithRefAndMeta);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutComplexTypeRefWithMetaRequest(RootWithRefAndMeta model)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/complex-type-ref-with-meta", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(model, "RootWithRefAndMeta");
            request.Content = content;
            return message;
        }
        /// <summary> Puts a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="model"> The RootWithRefAndMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutComplexTypeRefWithMetaAsync(RootWithRefAndMeta model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutComplexTypeRefWithMeta");
            scope.Start();
            try
            {
                using var message = CreatePutComplexTypeRefWithMetaRequest(model);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Puts a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="model"> The RootWithRefAndMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutComplexTypeRefWithMeta(RootWithRefAndMeta model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutComplexTypeRefWithMeta");
            scope.Start();
            try
            {
                using var message = CreatePutComplexTypeRefWithMetaRequest(model);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetSimpleRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/simple", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get a simple XML document. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Slideshow>> GetSimpleAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetSimple");
            scope.Start();
            try
            {
                using var message = CreateGetSimpleRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            Slideshow value = default;
                            var slideshow = document.Element("slideshow");
                            if (slideshow != null)
                            {
                                value = Slideshow.DeserializeSlideshow(slideshow);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get a simple XML document. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Slideshow> GetSimple(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetSimple");
            scope.Start();
            try
            {
                using var message = CreateGetSimpleRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            Slideshow value = default;
                            var slideshow = document.Element("slideshow");
                            if (slideshow != null)
                            {
                                value = Slideshow.DeserializeSlideshow(slideshow);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutSimpleRequest(Slideshow slideshow)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/simple", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(slideshow, "slideshow");
            request.Content = content;
            return message;
        }
        /// <summary> Put a simple XML document. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutSimpleAsync(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            if (slideshow == null)
            {
                throw new ArgumentNullException(nameof(slideshow));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutSimple");
            scope.Start();
            try
            {
                using var message = CreatePutSimpleRequest(slideshow);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put a simple XML document. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutSimple(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            if (slideshow == null)
            {
                throw new ArgumentNullException(nameof(slideshow));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutSimple");
            scope.Start();
            try
            {
                using var message = CreatePutSimpleRequest(slideshow);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetWrappedListsRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/wrapped-lists", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an XML document with multiple wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<AppleBarrel>> GetWrappedListsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetWrappedLists");
            scope.Start();
            try
            {
                using var message = CreateGetWrappedListsRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            AppleBarrel value = default;
                            var appleBarrel = document.Element("AppleBarrel");
                            if (appleBarrel != null)
                            {
                                value = AppleBarrel.DeserializeAppleBarrel(appleBarrel);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an XML document with multiple wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<AppleBarrel> GetWrappedLists(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetWrappedLists");
            scope.Start();
            try
            {
                using var message = CreateGetWrappedListsRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            AppleBarrel value = default;
                            var appleBarrel = document.Element("AppleBarrel");
                            if (appleBarrel != null)
                            {
                                value = AppleBarrel.DeserializeAppleBarrel(appleBarrel);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutWrappedListsRequest(AppleBarrel wrappedLists)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/wrapped-lists", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(wrappedLists, "AppleBarrel");
            request.Content = content;
            return message;
        }
        /// <summary> Put an XML document with multiple wrapped lists. </summary>
        /// <param name="wrappedLists"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutWrappedListsAsync(AppleBarrel wrappedLists, CancellationToken cancellationToken = default)
        {
            if (wrappedLists == null)
            {
                throw new ArgumentNullException(nameof(wrappedLists));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutWrappedLists");
            scope.Start();
            try
            {
                using var message = CreatePutWrappedListsRequest(wrappedLists);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Put an XML document with multiple wrapped lists. </summary>
        /// <param name="wrappedLists"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutWrappedLists(AppleBarrel wrappedLists, CancellationToken cancellationToken = default)
        {
            if (wrappedLists == null)
            {
                throw new ArgumentNullException(nameof(wrappedLists));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutWrappedLists");
            scope.Start();
            try
            {
                using var message = CreatePutWrappedListsRequest(wrappedLists);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetHeadersRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/headers", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get strongly-typed response headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<GetHeadersHeaders>> GetHeadersAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetHeaders");
            scope.Start();
            try
            {
                using var message = CreateGetHeadersRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new GetHeadersHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get strongly-typed response headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<GetHeadersHeaders> GetHeaders(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetHeaders");
            scope.Start();
            try
            {
                using var message = CreateGetHeadersRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new GetHeadersHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetEmptyListRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/empty-list", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Get an empty list. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Slideshow>> GetEmptyListAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetEmptyList");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyListRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            Slideshow value = default;
                            var slideshow = document.Element("slideshow");
                            if (slideshow != null)
                            {
                                value = Slideshow.DeserializeSlideshow(slideshow);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Get an empty list. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Slideshow> GetEmptyList(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetEmptyList");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyListRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            Slideshow value = default;
                            var slideshow = document.Element("slideshow");
                            if (slideshow != null)
                            {
                                value = Slideshow.DeserializeSlideshow(slideshow);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutEmptyListRequest(Slideshow slideshow)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/empty-list", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(slideshow, "slideshow");
            request.Content = content;
            return message;
        }
        /// <summary> Puts an empty list. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyListAsync(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            if (slideshow == null)
            {
                throw new ArgumentNullException(nameof(slideshow));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutEmptyList");
            scope.Start();
            try
            {
                using var message = CreatePutEmptyListRequest(slideshow);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Puts an empty list. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmptyList(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            if (slideshow == null)
            {
                throw new ArgumentNullException(nameof(slideshow));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutEmptyList");
            scope.Start();
            try
            {
                using var message = CreatePutEmptyListRequest(slideshow);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetEmptyWrappedListsRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/empty-wrapped-lists", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Gets some empty wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<AppleBarrel>> GetEmptyWrappedListsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetEmptyWrappedLists");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyWrappedListsRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            AppleBarrel value = default;
                            var appleBarrel = document.Element("AppleBarrel");
                            if (appleBarrel != null)
                            {
                                value = AppleBarrel.DeserializeAppleBarrel(appleBarrel);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets some empty wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<AppleBarrel> GetEmptyWrappedLists(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetEmptyWrappedLists");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyWrappedListsRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            AppleBarrel value = default;
                            var appleBarrel = document.Element("AppleBarrel");
                            if (appleBarrel != null)
                            {
                                value = AppleBarrel.DeserializeAppleBarrel(appleBarrel);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutEmptyWrappedListsRequest(AppleBarrel appleBarrel)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/empty-wrapped-lists", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(appleBarrel, "AppleBarrel");
            request.Content = content;
            return message;
        }
        /// <summary> Puts some empty wrapped lists. </summary>
        /// <param name="appleBarrel"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyWrappedListsAsync(AppleBarrel appleBarrel, CancellationToken cancellationToken = default)
        {
            if (appleBarrel == null)
            {
                throw new ArgumentNullException(nameof(appleBarrel));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutEmptyWrappedLists");
            scope.Start();
            try
            {
                using var message = CreatePutEmptyWrappedListsRequest(appleBarrel);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Puts some empty wrapped lists. </summary>
        /// <param name="appleBarrel"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmptyWrappedLists(AppleBarrel appleBarrel, CancellationToken cancellationToken = default)
        {
            if (appleBarrel == null)
            {
                throw new ArgumentNullException(nameof(appleBarrel));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutEmptyWrappedLists");
            scope.Start();
            try
            {
                using var message = CreatePutEmptyWrappedListsRequest(appleBarrel);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetRootListRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/root-list", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Gets a list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Banana>>> GetRootListAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetRootList");
            scope.Start();
            try
            {
                using var message = CreateGetRootListRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ICollection<Banana> value = default;
                            var bananas = document.Element("bananas");
                            if (bananas != null)
                            {
                                value = new List<Banana>();
                                foreach (var e in bananas.Elements("banana"))
                                {
                                    Banana value0 = default;
                                    value0 = Banana.DeserializeBanana(e);
                                    value.Add(value0);
                                }
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets a list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Banana>> GetRootList(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetRootList");
            scope.Start();
            try
            {
                using var message = CreateGetRootListRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ICollection<Banana> value = default;
                            var bananas = document.Element("bananas");
                            if (bananas != null)
                            {
                                value = new List<Banana>();
                                foreach (var e in bananas.Elements("banana"))
                                {
                                    Banana value0 = default;
                                    value0 = Banana.DeserializeBanana(e);
                                    value.Add(value0);
                                }
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutRootListRequest(IEnumerable<Banana> bananas)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/root-list", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
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
        public async ValueTask<Response> PutRootListAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutRootList");
            scope.Start();
            try
            {
                using var message = CreatePutRootListRequest(bananas);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Puts a list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutRootList(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutRootList");
            scope.Start();
            try
            {
                using var message = CreatePutRootListRequest(bananas);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetRootListSingleItemRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/root-list-single-item", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Gets a list with a single item. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Banana>>> GetRootListSingleItemAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetRootListSingleItem");
            scope.Start();
            try
            {
                using var message = CreateGetRootListSingleItemRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ICollection<Banana> value = default;
                            var bananas = document.Element("bananas");
                            if (bananas != null)
                            {
                                value = new List<Banana>();
                                foreach (var e in bananas.Elements("banana"))
                                {
                                    Banana value0 = default;
                                    value0 = Banana.DeserializeBanana(e);
                                    value.Add(value0);
                                }
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets a list with a single item. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Banana>> GetRootListSingleItem(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetRootListSingleItem");
            scope.Start();
            try
            {
                using var message = CreateGetRootListSingleItemRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ICollection<Banana> value = default;
                            var bananas = document.Element("bananas");
                            if (bananas != null)
                            {
                                value = new List<Banana>();
                                foreach (var e in bananas.Elements("banana"))
                                {
                                    Banana value0 = default;
                                    value0 = Banana.DeserializeBanana(e);
                                    value.Add(value0);
                                }
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutRootListSingleItemRequest(IEnumerable<Banana> bananas)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/root-list-single-item", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
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
        public async ValueTask<Response> PutRootListSingleItemAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutRootListSingleItem");
            scope.Start();
            try
            {
                using var message = CreatePutRootListSingleItemRequest(bananas);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Puts a list with a single item. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutRootListSingleItem(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutRootListSingleItem");
            scope.Start();
            try
            {
                using var message = CreatePutRootListSingleItemRequest(bananas);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetEmptyRootListRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/empty-root-list", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Gets an empty list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<Banana>>> GetEmptyRootListAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetEmptyRootList");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyRootListRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ICollection<Banana> value = default;
                            var bananas = document.Element("bananas");
                            if (bananas != null)
                            {
                                value = new List<Banana>();
                                foreach (var e in bananas.Elements("banana"))
                                {
                                    Banana value0 = default;
                                    value0 = Banana.DeserializeBanana(e);
                                    value.Add(value0);
                                }
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets an empty list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<Banana>> GetEmptyRootList(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetEmptyRootList");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyRootListRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ICollection<Banana> value = default;
                            var bananas = document.Element("bananas");
                            if (bananas != null)
                            {
                                value = new List<Banana>();
                                foreach (var e in bananas.Elements("banana"))
                                {
                                    Banana value0 = default;
                                    value0 = Banana.DeserializeBanana(e);
                                    value.Add(value0);
                                }
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutEmptyRootListRequest(IEnumerable<Banana> bananas)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/empty-root-list", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
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
        public async ValueTask<Response> PutEmptyRootListAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutEmptyRootList");
            scope.Start();
            try
            {
                using var message = CreatePutEmptyRootListRequest(bananas);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Puts an empty list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmptyRootList(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutEmptyRootList");
            scope.Start();
            try
            {
                using var message = CreatePutEmptyRootListRequest(bananas);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetEmptyChildElementRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/empty-child-element", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> Gets an XML document with an empty child element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<Banana>> GetEmptyChildElementAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetEmptyChildElement");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyChildElementRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            Banana value = default;
                            var banana = document.Element("banana");
                            if (banana != null)
                            {
                                value = Banana.DeserializeBanana(banana);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets an XML document with an empty child element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<Banana> GetEmptyChildElement(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetEmptyChildElement");
            scope.Start();
            try
            {
                using var message = CreateGetEmptyChildElementRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            Banana value = default;
                            var banana = document.Element("banana");
                            if (banana != null)
                            {
                                value = Banana.DeserializeBanana(banana);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutEmptyChildElementRequest(Banana banana)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/empty-child-element", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(banana, "banana");
            request.Content = content;
            return message;
        }
        /// <summary> Puts a value with an empty child element. </summary>
        /// <param name="banana"> The Banana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutEmptyChildElementAsync(Banana banana, CancellationToken cancellationToken = default)
        {
            if (banana == null)
            {
                throw new ArgumentNullException(nameof(banana));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutEmptyChildElement");
            scope.Start();
            try
            {
                using var message = CreatePutEmptyChildElementRequest(banana);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Puts a value with an empty child element. </summary>
        /// <param name="banana"> The Banana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutEmptyChildElement(Banana banana, CancellationToken cancellationToken = default)
        {
            if (banana == null)
            {
                throw new ArgumentNullException(nameof(banana));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutEmptyChildElement");
            scope.Start();
            try
            {
                using var message = CreatePutEmptyChildElementRequest(banana);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateListContainersRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/", false);
            uri.AppendQuery("comp", "list", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Lists containers in a storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ListContainersResponse>> ListContainersAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.ListContainers");
            scope.Start();
            try
            {
                using var message = CreateListContainersRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ListContainersResponse value = default;
                            var enumerationResults = document.Element("EnumerationResults");
                            if (enumerationResults != null)
                            {
                                value = ListContainersResponse.DeserializeListContainersResponse(enumerationResults);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Lists containers in a storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ListContainersResponse> ListContainers(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.ListContainers");
            scope.Start();
            try
            {
                using var message = CreateListContainersRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ListContainersResponse value = default;
                            var enumerationResults = document.Element("EnumerationResults");
                            if (enumerationResults != null)
                            {
                                value = ListContainersResponse.DeserializeListContainersResponse(enumerationResults);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetServicePropertiesRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/", false);
            uri.AppendQuery("comp", "properties", true);
            uri.AppendQuery("restype", "service", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Gets storage service properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<StorageServiceProperties>> GetServicePropertiesAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetServiceProperties");
            scope.Start();
            try
            {
                using var message = CreateGetServicePropertiesRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            StorageServiceProperties value = default;
                            var storageServiceProperties = document.Element("StorageServiceProperties");
                            if (storageServiceProperties != null)
                            {
                                value = StorageServiceProperties.DeserializeStorageServiceProperties(storageServiceProperties);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets storage service properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<StorageServiceProperties> GetServiceProperties(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetServiceProperties");
            scope.Start();
            try
            {
                using var message = CreateGetServicePropertiesRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            StorageServiceProperties value = default;
                            var storageServiceProperties = document.Element("StorageServiceProperties");
                            if (storageServiceProperties != null)
                            {
                                value = StorageServiceProperties.DeserializeStorageServiceProperties(storageServiceProperties);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutServicePropertiesRequest(StorageServiceProperties properties)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/", false);
            uri.AppendQuery("comp", "properties", true);
            uri.AppendQuery("restype", "service", true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(properties, "StorageServiceProperties");
            request.Content = content;
            return message;
        }
        /// <summary> Puts storage service properties. </summary>
        /// <param name="properties"> The StorageServiceProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> PutServicePropertiesAsync(StorageServiceProperties properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutServiceProperties");
            scope.Start();
            try
            {
                using var message = CreatePutServicePropertiesRequest(properties);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Puts storage service properties. </summary>
        /// <param name="properties"> The StorageServiceProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutServiceProperties(StorageServiceProperties properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutServiceProperties");
            scope.Start();
            try
            {
                using var message = CreatePutServicePropertiesRequest(properties);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetAclsRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/mycontainer", false);
            uri.AppendQuery("comp", "acl", true);
            uri.AppendQuery("restype", "container", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Gets storage ACLs for a container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ICollection<SignedIdentifier>>> GetAclsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetAcls");
            scope.Start();
            try
            {
                using var message = CreateGetAclsRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ICollection<SignedIdentifier> value = default;
                            var signedIdentifiers = document.Element("SignedIdentifiers");
                            if (signedIdentifiers != null)
                            {
                                value = new List<SignedIdentifier>();
                                foreach (var e in signedIdentifiers.Elements("SignedIdentifier"))
                                {
                                    SignedIdentifier value0 = default;
                                    value0 = SignedIdentifier.DeserializeSignedIdentifier(e);
                                    value.Add(value0);
                                }
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Gets storage ACLs for a container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ICollection<SignedIdentifier>> GetAcls(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.GetAcls");
            scope.Start();
            try
            {
                using var message = CreateGetAclsRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ICollection<SignedIdentifier> value = default;
                            var signedIdentifiers = document.Element("SignedIdentifiers");
                            if (signedIdentifiers != null)
                            {
                                value = new List<SignedIdentifier>();
                                foreach (var e in signedIdentifiers.Elements("SignedIdentifier"))
                                {
                                    SignedIdentifier value0 = default;
                                    value0 = SignedIdentifier.DeserializeSignedIdentifier(e);
                                    value.Add(value0);
                                }
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreatePutAclsRequest(IEnumerable<SignedIdentifier> properties)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/mycontainer", false);
            uri.AppendQuery("comp", "acl", true);
            uri.AppendQuery("restype", "container", true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
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
        public async ValueTask<Response> PutAclsAsync(IEnumerable<SignedIdentifier> properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutAcls");
            scope.Start();
            try
            {
                using var message = CreatePutAclsRequest(properties);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Puts storage ACLs for a container. </summary>
        /// <param name="properties"> The SignedIdentifiers to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response PutAcls(IEnumerable<SignedIdentifier> properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.PutAcls");
            scope.Start();
            try
            {
                using var message = CreatePutAclsRequest(properties);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateListBlobsRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/mycontainer", false);
            uri.AppendQuery("comp", "list", true);
            uri.AppendQuery("restype", "container", true);
            request.Uri = uri;
            return message;
        }
        /// <summary> Lists blobs in a storage container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ListBlobsResponse>> ListBlobsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.ListBlobs");
            scope.Start();
            try
            {
                using var message = CreateListBlobsRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ListBlobsResponse value = default;
                            var enumerationResults = document.Element("EnumerationResults");
                            if (enumerationResults != null)
                            {
                                value = ListBlobsResponse.DeserializeListBlobsResponse(enumerationResults);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Lists blobs in a storage container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ListBlobsResponse> ListBlobs(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.ListBlobs");
            scope.Start();
            try
            {
                using var message = CreateListBlobsRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ListBlobsResponse value = default;
                            var enumerationResults = document.Element("EnumerationResults");
                            if (enumerationResults != null)
                            {
                                value = ListBlobsResponse.DeserializeListBlobsResponse(enumerationResults);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateJsonInputRequest(JsonInput properties)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/jsoninput", false);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(properties);
            request.Content = content;
            return message;
        }
        /// <summary> A Swagger with XML that has one operation that takes JSON as input. You need to send the ID number 42. </summary>
        /// <param name="properties"> The JsonInput to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> JsonInputAsync(JsonInput properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.JsonInput");
            scope.Start();
            try
            {
                using var message = CreateJsonInputRequest(properties);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A Swagger with XML that has one operation that takes JSON as input. You need to send the ID number 42. </summary>
        /// <param name="properties"> The JsonInput to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response JsonInput(JsonInput properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = clientDiagnostics.CreateScope("XmlOperations.JsonInput");
            scope.Start();
            try
            {
                using var message = CreateJsonInputRequest(properties);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateJsonOutputRequest()
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(host, false);
            uri.AppendPath("/xml/jsonoutput", false);
            request.Uri = uri;
            return message;
        }
        /// <summary> A Swagger with XML that has one operation that returns JSON. ID number 42. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<JsonOutput>> JsonOutputAsync(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.JsonOutput");
            scope.Start();
            try
            {
                using var message = CreateJsonOutputRequest();
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = Models.JsonOutput.DeserializeJsonOutput(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> A Swagger with XML that has one operation that returns JSON. ID number 42. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<JsonOutput> JsonOutput(CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("XmlOperations.JsonOutput");
            scope.Start();
            try
            {
                using var message = CreateJsonOutputRequest();
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = Models.JsonOutput.DeserializeJsonOutput(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
