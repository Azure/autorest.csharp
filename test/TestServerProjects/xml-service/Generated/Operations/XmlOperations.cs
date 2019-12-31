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
        public async ValueTask<Response<RootWithRefAndNoMeta>> GetComplexTypeRefNoMetaAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.GetComplexTypeRefNoMeta");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/complex-type-ref-no-meta", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            RootWithRefAndNoMeta value = default;
                            var rootWithRefAndNoMeta = document.Element("RootWithRefAndNoMeta");
                            if (rootWithRefAndNoMeta != null)
                            {
                                value = RootWithRefAndNoMeta.DeserializeRootWithRefAndNoMeta(rootWithRefAndNoMeta);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> PutComplexTypeRefNoMetaAsync(RootWithRefAndNoMeta model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using var scope = clientDiagnostics.CreateScope("xml_service.PutComplexTypeRefNoMeta");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/complex-type-ref-no-meta", false);
                request.Headers.Add("Content-Type", "application/xml");
                using var content = new XmlWriterContent();
                content.XmlWriter.WriteObjectValue(model, "RootWithRefAndNoMeta");
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<RootWithRefAndMeta>> GetComplexTypeRefWithMetaAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.GetComplexTypeRefWithMeta");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/complex-type-ref-with-meta", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            RootWithRefAndMeta value = default;
                            var rootWithRefAndMeta = document.Element("RootWithRefAndMeta");
                            if (rootWithRefAndMeta != null)
                            {
                                value = RootWithRefAndMeta.DeserializeRootWithRefAndMeta(rootWithRefAndMeta);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> PutComplexTypeRefWithMetaAsync(RootWithRefAndMeta model, CancellationToken cancellationToken = default)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            using var scope = clientDiagnostics.CreateScope("xml_service.PutComplexTypeRefWithMeta");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/complex-type-ref-with-meta", false);
                request.Headers.Add("Content-Type", "application/xml");
                using var content = new XmlWriterContent();
                content.XmlWriter.WriteObjectValue(model, "RootWithRefAndMeta");
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<Slideshow>> GetSimpleAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.GetSimple");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/simple", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            Slideshow value = default;
                            var slideshow = document.Element("slideshow");
                            if (slideshow != null)
                            {
                                value = Slideshow.DeserializeSlideshow(slideshow);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> PutSimpleAsync(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            if (slideshow == null)
            {
                throw new ArgumentNullException(nameof(slideshow));
            }

            using var scope = clientDiagnostics.CreateScope("xml_service.PutSimple");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/simple", false);
                request.Headers.Add("Content-Type", "application/xml");
                using var content = new XmlWriterContent();
                content.XmlWriter.WriteObjectValue(slideshow, "slideshow");
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<AppleBarrel>> GetWrappedListsAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.GetWrappedLists");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/wrapped-lists", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            AppleBarrel value = default;
                            var appleBarrel = document.Element("AppleBarrel");
                            if (appleBarrel != null)
                            {
                                value = AppleBarrel.DeserializeAppleBarrel(appleBarrel);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> PutWrappedListsAsync(AppleBarrel wrappedLists, CancellationToken cancellationToken = default)
        {
            if (wrappedLists == null)
            {
                throw new ArgumentNullException(nameof(wrappedLists));
            }

            using var scope = clientDiagnostics.CreateScope("xml_service.PutWrappedLists");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/wrapped-lists", false);
                request.Headers.Add("Content-Type", "application/xml");
                using var content = new XmlWriterContent();
                content.XmlWriter.WriteObjectValue(wrappedLists, "AppleBarrel");
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<ResponseWithHeaders<GetHeadersHeaders>> GetHeadersAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.GetHeaders");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/headers", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new GetHeadersHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<Slideshow>> GetEmptyListAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.GetEmptyList");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/empty-list", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            Slideshow value = default;
                            var slideshow = document.Element("slideshow");
                            if (slideshow != null)
                            {
                                value = Slideshow.DeserializeSlideshow(slideshow);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> PutEmptyListAsync(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            if (slideshow == null)
            {
                throw new ArgumentNullException(nameof(slideshow));
            }

            using var scope = clientDiagnostics.CreateScope("xml_service.PutEmptyList");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/empty-list", false);
                request.Headers.Add("Content-Type", "application/xml");
                using var content = new XmlWriterContent();
                content.XmlWriter.WriteObjectValue(slideshow, "slideshow");
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<AppleBarrel>> GetEmptyWrappedListsAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.GetEmptyWrappedLists");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/empty-wrapped-lists", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            AppleBarrel value = default;
                            var appleBarrel = document.Element("AppleBarrel");
                            if (appleBarrel != null)
                            {
                                value = AppleBarrel.DeserializeAppleBarrel(appleBarrel);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> PutEmptyWrappedListsAsync(AppleBarrel appleBarrel, CancellationToken cancellationToken = default)
        {
            if (appleBarrel == null)
            {
                throw new ArgumentNullException(nameof(appleBarrel));
            }

            using var scope = clientDiagnostics.CreateScope("xml_service.PutEmptyWrappedLists");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/empty-wrapped-lists", false);
                request.Headers.Add("Content-Type", "application/xml");
                using var content = new XmlWriterContent();
                content.XmlWriter.WriteObjectValue(appleBarrel, "AppleBarrel");
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<ICollection<Banana>>> GetRootListAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.GetRootList");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/root-list", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            ICollection<Banana> value = default;
                            value = new List<Banana>();
                            foreach (var e in document.Elements("banana"))
                            {
                                Banana value0 = default;
                                var banana = e.Element("banana");
                                if (banana != null)
                                {
                                    value0 = Banana.DeserializeBanana(banana);
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> PutRootListAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var scope = clientDiagnostics.CreateScope("xml_service.PutRootList");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
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
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<ICollection<Banana>>> GetRootListSingleItemAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.GetRootListSingleItem");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/root-list-single-item", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            ICollection<Banana> value = default;
                            value = new List<Banana>();
                            foreach (var e in document.Elements("banana"))
                            {
                                Banana value0 = default;
                                var banana = e.Element("banana");
                                if (banana != null)
                                {
                                    value0 = Banana.DeserializeBanana(banana);
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> PutRootListSingleItemAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var scope = clientDiagnostics.CreateScope("xml_service.PutRootListSingleItem");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
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
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<ICollection<Banana>>> GetEmptyRootListAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.GetEmptyRootList");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/empty-root-list", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            ICollection<Banana> value = default;
                            value = new List<Banana>();
                            foreach (var e in document.Elements("banana"))
                            {
                                Banana value0 = default;
                                var banana = e.Element("banana");
                                if (banana != null)
                                {
                                    value0 = Banana.DeserializeBanana(banana);
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> PutEmptyRootListAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            if (bananas == null)
            {
                throw new ArgumentNullException(nameof(bananas));
            }

            using var scope = clientDiagnostics.CreateScope("xml_service.PutEmptyRootList");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
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
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<Banana>> GetEmptyChildElementAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.GetEmptyChildElement");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/empty-child-element", false);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            Banana value = default;
                            var banana = document.Element("banana");
                            if (banana != null)
                            {
                                value = Banana.DeserializeBanana(banana);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> PutEmptyChildElementAsync(Banana banana, CancellationToken cancellationToken = default)
        {
            if (banana == null)
            {
                throw new ArgumentNullException(nameof(banana));
            }

            using var scope = clientDiagnostics.CreateScope("xml_service.PutEmptyChildElement");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/empty-child-element", false);
                request.Headers.Add("Content-Type", "application/xml");
                using var content = new XmlWriterContent();
                content.XmlWriter.WriteObjectValue(banana, "banana");
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<ListContainersResponse>> ListContainersAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.ListContainers");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/", false);
                request.Uri.AppendQuery("comp", "list", true);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            ListContainersResponse value = default;
                            var enumerationResults = document.Element("EnumerationResults");
                            if (enumerationResults != null)
                            {
                                value = ListContainersResponse.DeserializeListContainersResponse(enumerationResults);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<StorageServiceProperties>> GetServicePropertiesAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.GetServiceProperties");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/", false);
                request.Uri.AppendQuery("comp", "properties", true);
                request.Uri.AppendQuery("restype", "service", true);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            StorageServiceProperties value = default;
                            var storageServiceProperties = document.Element("StorageServiceProperties");
                            if (storageServiceProperties != null)
                            {
                                value = StorageServiceProperties.DeserializeStorageServiceProperties(storageServiceProperties);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> PutServicePropertiesAsync(StorageServiceProperties properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = clientDiagnostics.CreateScope("xml_service.PutServiceProperties");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/", false);
                request.Headers.Add("Content-Type", "application/xml");
                request.Uri.AppendQuery("comp", "properties", true);
                request.Uri.AppendQuery("restype", "service", true);
                using var content = new XmlWriterContent();
                content.XmlWriter.WriteObjectValue(properties, "StorageServiceProperties");
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<ICollection<SignedIdentifier>>> GetAclsAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.GetAcls");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/mycontainer", false);
                request.Uri.AppendQuery("comp", "acl", true);
                request.Uri.AppendQuery("restype", "container", true);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            ICollection<SignedIdentifier> value = default;
                            var signedIdentifiers = document.Element("SignedIdentifiers");
                            value = new List<SignedIdentifier>();
                            foreach (var e in signedIdentifiers.Elements("SignedIdentifier"))
                            {
                                SignedIdentifier value0 = default;
                                var signedIdentifier = e.Element("SignedIdentifier");
                                if (signedIdentifier != null)
                                {
                                    value0 = SignedIdentifier.DeserializeSignedIdentifier(signedIdentifier);
                                }
                                value.Add(value0);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> PutAclsAsync(IEnumerable<SignedIdentifier> properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = clientDiagnostics.CreateScope("xml_service.PutAcls");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
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
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        return message.Response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<ListBlobsResponse>> ListBlobsAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.ListBlobs");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/mycontainer", false);
                request.Uri.AppendQuery("comp", "list", true);
                request.Uri.AppendQuery("restype", "container", true);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = await XDocument.LoadAsync(message.Response.ContentStream, LoadOptions.PreserveWhitespace, cancellationToken).ConfigureAwait(false);
                            ListBlobsResponse value = default;
                            var enumerationResults = document.Element("EnumerationResults");
                            if (enumerationResults != null)
                            {
                                value = ListBlobsResponse.DeserializeListBlobsResponse(enumerationResults);
                            }
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response> JsonInputAsync(JSONInput properties, CancellationToken cancellationToken = default)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            using var scope = clientDiagnostics.CreateScope("xml_service.JsonInput");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Put;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/jsoninput", false);
                request.Headers.Add("Content-Type", "application/json");
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(properties);
                request.Content = content;
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        return message.Response;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        public async ValueTask<Response<JSONOutput>> JsonOutputAsync(CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("xml_service.JsonOutput");
            scope.Start();
            try
            {
                using var message = pipeline.CreateMessage();
                var request = message.Request;
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri($"{host}"));
                request.Uri.AppendPath("/xml/jsonoutput", false);
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
                        throw new Exception();
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
