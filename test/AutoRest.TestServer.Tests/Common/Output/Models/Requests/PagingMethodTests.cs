// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using NUnit.Framework;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Requests.Tests
{
    public class PagingMethodTests
    {
        [TestCase("maxpagesize", typeof(float), ExpectedResult = true)]
        [TestCase("pagesize", typeof(decimal), ExpectedResult = true)]
        [TestCase("PageSize", typeof(double), ExpectedResult = true)]
        [TestCase("max_page_size", typeof(int), ExpectedResult = true)]
        [TestCase("pageSize", typeof(string), ExpectedResult = true)]
        [TestCase("page_size", typeof(long), ExpectedResult = true)]
        [TestCase("pageSize", typeof(short), ExpectedResult = false)]
        [TestCase("maxpagesize", typeof(bool), ExpectedResult = false)]
        [TestCase("maxpagesize", typeof(object), ExpectedResult = false)]
        [TestCase("maxpagesize", typeof(int[]), ExpectedResult = false)]
        [TestCase("maxpage", typeof(float), ExpectedResult = false)]
        [TestCase("page", typeof(decimal), ExpectedResult = false)]
        [TestCase("size", typeof(double), ExpectedResult = false)]
        [TestCase("pageSizeInDestination", typeof(short), ExpectedResult = false)]
        [TestCase("page_size_of_container", typeof(long), ExpectedResult = false)]
        [TestCase("max_page_size_result", typeof(int), ExpectedResult = false)]
        public bool ValidateIsPageSizeParameter(string name, Type inputType)
        {
            return PagingMethod.IsPageSizeParameter(new Parameter(
                name,
                "test parameter",
                inputType,
                null,
                false,
                false
            ));
        }
    }
}
