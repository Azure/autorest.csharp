// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.TestServer.Tests.Infrastructure;
using NUnit.Framework;
using SerializationCustomization.Models;

namespace AutoRest.TestServer.Tests
{
    public class EmptyAsUndefinedTests
    {
        [Test]
        public void EmptyAsUndefinedListNotSerializedWhenEmpty()
        {
            var emptyAsUndefinedModel = new EmptyAsUndefinedTestModel();
            emptyAsUndefinedModel.EmptyAsUndefinedList = new List<Item>();

            JsonAsserts.AssertSerialization(@"{}", emptyAsUndefinedModel);
        }

        [Test]
        public void EmptyAsUndefinedListNotSerializedWhenNull()
        {
            var emptyAsUndefinedModel = new EmptyAsUndefinedTestModel();
            emptyAsUndefinedModel.EmptyAsUndefinedList = null;

            JsonAsserts.AssertSerialization(@"{}", emptyAsUndefinedModel);
        }

        [Test]
        public void EmptyAsUndefinedListNotSerializedWithItems()
        {
            var emptyAsUndefinedModel = new EmptyAsUndefinedTestModel();
            emptyAsUndefinedModel.EmptyAsUndefinedList = new List<Item>() { new Item() };

            JsonAsserts.AssertSerialization(@"{""EmptyAsUndefinedList"":[{}]}", emptyAsUndefinedModel);
        }
    }
}