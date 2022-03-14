// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal static class LowLevelPageableHelpers
    {
        public static async ValueTask<Page<BinaryData>> ProcessMessageAsync(HttpPipeline pipeline, HttpMessage message, RequestContext? requestContext, string itemPropertyName = "value", string? nextLinkPropertyName = "nextLink", CancellationToken cancellationToken = default)
        {
            var response = await pipeline.ProcessMessageAsync(message, requestContext, cancellationToken).ConfigureAwait(false);
            var itemsAndNextLink = GetItemsAndNextLinkFromJson(response.Content, itemPropertyName, nextLinkPropertyName);
            return Page.FromValues(itemsAndNextLink.Items, itemsAndNextLink.NextLink!, response);
        }

        public static Page<BinaryData> ProcessMessage(HttpPipeline pipeline, HttpMessage message, RequestContext? requestContext, string itemPropertyName = "value", string? nextLinkPropertyName = "nextLink", CancellationToken cancellationToken = default)
        {
            var response = pipeline.ProcessMessage(message, requestContext, cancellationToken);
            var itemsAndNextLink = GetItemsAndNextLinkFromJson(response.Content, itemPropertyName, nextLinkPropertyName);
            return Page.FromValues(itemsAndNextLink.Items, itemsAndNextLink.NextLink!, response);
        }

        /// <summary>
        /// Returns a <see cref="Page{T}"/> for a given response.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="itemPropertyName"></param>
        /// <param name="nextLinkPropertyName"></param>
        /// <returns></returns>
        public static Page<BinaryData> BuildPageForResponse(Response response, string itemPropertyName = "value", string nextLinkPropertyName = "nextLink")
        {
            var itemsAndNextLink = GetItemsAndNextLinkFromJson(response.Content, itemPropertyName, nextLinkPropertyName);
            return Page.FromValues<BinaryData>(itemsAndNextLink.Items, itemsAndNextLink.NextLink!, response);
        }

        /// <summary>
        /// Reads a token, failing if it can't on the resulting token is of the wrong type,
        /// </summary>
        private static void MustRead(ref Utf8JsonReader r, JsonTokenType jsonTokenType)
        {
            if (!r.Read() || r.TokenType != jsonTokenType)
            {
                throw new InvalidOperationException("unexpected JSON token");
            }
        }

        /// <summary>
        /// Read an array of values from a <see cref="Utf8JsonReader"/>. The entire array is read and
        /// a <see cref="BinaryData"/> is formed over the JSON text for each item in the array.
        /// </summary>
        private static List<BinaryData> ReadArrayItems(ref Utf8JsonReader r, BinaryData jsonDocument)
        {
            ReadOnlyMemory<byte> content = jsonDocument.ToMemory();
            List<BinaryData> values = new List<BinaryData>();

            MustRead(ref r, JsonTokenType.StartArray);
            while (r.Read())
            {
                if (r.TokenType == JsonTokenType.EndArray)
                {
                    return values;
                }
                else if (r.TokenType == JsonTokenType.StartObject || r.TokenType == JsonTokenType.StartArray)
                {
                    int startIdx = (int)r.TokenStartIndex;
                    r.Skip();
                    int endIdx = (int)r.TokenStartIndex;
                    int length = endIdx - startIdx + 1;

                    values.Add(new BinaryData(content.Slice(startIdx, length)));
                }
                else if (r.TokenType == JsonTokenType.String)
                {
                    values.Add(new BinaryData(content.Slice((int)r.TokenStartIndex, r.ValueSpan.Length + 2 /* open and closing quotes are not captured in the value span */)));
                }
                else
                {
                    values.Add(new BinaryData(content.Slice((int)r.TokenStartIndex, r.ValueSpan.Length)));
                }
            }

            throw new InvalidOperationException("invalid JSON");
        }

        /// <summary>
        /// Reads the items and next link from a response for a pageable operation. The values returned are BinaryDatas formed over the underlying content.
        /// </summary>
        private static (IEnumerable<BinaryData> Items, string? NextLink) GetItemsAndNextLinkFromJson(BinaryData content, string itemPropertyName = "value", string? nextLinkPropertyName = "nextLink")
        {
            string? nextLink = null;
            IEnumerable<BinaryData> items = Array.Empty<BinaryData>();

            Utf8JsonReader r = new Utf8JsonReader(content.ToMemory().Span);
            MustRead(ref r, JsonTokenType.StartObject);
            while (r.Read())
            {
                switch (r.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        if (r.ValueTextEquals(nextLinkPropertyName))
                        {
                            r.Read();
                            nextLink = r.GetString();
                            continue;
                        }
                        else if (r.ValueTextEquals(itemPropertyName))
                        {
                            items = ReadArrayItems(ref r, content);
                        }
                        else
                        {
                            r.Skip();
                        }
                        break;
                    case JsonTokenType.EndObject:
                        break;

                    default:
                        throw new Exception("unknown type in object");
                }
            }

            return (items, nextLink);
        }
    }
}
