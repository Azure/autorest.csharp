// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using UnbrandedTypeSpec;

namespace UnbrandedProjects.Tests
{
    public class ClientUriBuilderTests
    {
        [TestCaseSource(nameof(AppendPathSource))]
        public void ValidateAppendPath_ToUri(Uri expected, Uri endpoint, params string[] paths)
        {
            var uriBuilder = new ClientUriBuilder();
            uriBuilder.Reset(endpoint);
            foreach (var path in paths)
            {
                uriBuilder.AppendPath(path, false);
            }

            var uri = uriBuilder.ToUri();
            Assert.AreEqual(expected, uri);
        }

        private static readonly object[] AppendPathSource =
        {
            new object[]
            {
                new Uri("https://api.openai.com/v1"), new Uri("https://api.openai.com/v1"), Array.Empty<string>()
            },
            new object[]
            {
                new Uri("https://api.openai.com/v1/"), new Uri("https://api.openai.com/v1/"), Array.Empty<string>()
            },
            new object[]
            {
                new Uri("https://api.openai.com/v1/doSomething"), new Uri("https://api.openai.com/v1"), new[] { "/doSomething" }
            },
            new object[]
            {
                new Uri("https://api.openai.com/v1/doSomething"), new Uri("https://api.openai.com/v1/"), new[] { "/doSomething" }
            },
            new object[]
            {
                new Uri("https://api.openai.com/v1/doSomething/"), new Uri("https://api.openai.com/v1"), new[] { "/doSomething/" }
            },
            new object[]
            {
                new Uri("https://api.openai.com/v1/doSomething/"), new Uri("https://api.openai.com/v1/"), new[] { "/doSomething/" }
            },
            new object[]
            {
                new Uri("https://api.openai.com/v1/doSomething/else"), new Uri("https://api.openai.com/v1"), new[] { "/doSomething", "/else" }
            },
            new object[]
            {
                new Uri("https://api.openai.com/v1/doSomething/else"), new Uri("https://api.openai.com/v1/"), new[] { "/doSomething", "/else" }
            },
            new object[]
            {
                new Uri("https://api.openai.com/v1/doSomething/else/"), new Uri("https://api.openai.com/v1/"), new[] { "/doSomething/", "/else/" }
            }
        };
    }
}
