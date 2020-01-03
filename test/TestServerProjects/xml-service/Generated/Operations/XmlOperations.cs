// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using xml_service.Models.V100;

namespace xml_service
{
    internal partial class XmlOperations
    {
        private string host;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/complex-type-ref-no-meta", false);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/complex-type-ref-no-meta", false);
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(model, "RootWithRefAndNoMeta");
            request.Content = content;
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/complex-type-ref-with-meta", false);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/complex-type-ref-with-meta", false);
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(model, "RootWithRefAndMeta");
            request.Content = content;
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/simple", false);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/simple", false);
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(slideshow, "slideshow");
            request.Content = content;
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/wrapped-lists", false);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/wrapped-lists", false);
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(wrappedLists, "AppleBarrel");
            request.Content = content;
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/headers", false);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/empty-list", false);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/empty-list", false);
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(slideshow, "slideshow");
            request.Content = content;
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/empty-wrapped-lists", false);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/empty-wrapped-lists", false);
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(appleBarrel, "AppleBarrel");
            request.Content = content;
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/root-list", false);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/root-list", false);
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/root-list-single-item", false);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/root-list-single-item", false);
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/empty-root-list", false);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/empty-root-list", false);
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/empty-child-element", false);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/empty-child-element", false);
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(banana, "banana");
            request.Content = content;
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/", false);
            request.Uri.AppendQuery("comp", "list", true);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/", false);
            request.Uri.AppendQuery("comp", "properties", true);
            request.Uri.AppendQuery("restype", "service", true);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/", false);
            request.Headers.Add("Content-Type", "application/xml");
            request.Uri.AppendQuery("comp", "properties", true);
            request.Uri.AppendQuery("restype", "service", true);
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteObjectValue(properties, "StorageServiceProperties");
            request.Content = content;
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/mycontainer", false);
            request.Uri.AppendQuery("comp", "acl", true);
            request.Uri.AppendQuery("restype", "container", true);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/mycontainer", false);
            request.Headers.Add("Content-Type", "application/xml");
            request.Uri.AppendQuery("comp", "acl", true);
            request.Uri.AppendQuery("restype", "container", true);
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/mycontainer", false);
            request.Uri.AppendQuery("comp", "list", true);
            request.Uri.AppendQuery("restype", "container", true);
            return message;
        }
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateJsonInputRequest(JSONInput properties)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/jsoninput", false);
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(properties);
            request.Content = content;
            return message;
        }
        public async ValueTask<Response> JsonInputAsync(JSONInput properties, CancellationToken cancellationToken = default)
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
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("{host}"));
            request.Uri.AppendPath("/xml/jsonoutput", false);
            return message;
        }
        public async ValueTask<Response<JSONOutput>> JsonOutputAsync(CancellationToken cancellationToken = default)
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
                            var value = JSONOutput.DeserializeJSONOutput(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
