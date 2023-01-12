// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ModelsInCadl.Models;
using NUnit.Framework;
using AutoRest.TestServer.Tests.Infrastructure;
using System.Text.Json;
using System;

namespace AutoRest.LowLevel.Tests
{
    public class ModelsCadlTests
    {
        private static readonly DateTimeOffset PlainDateData = new DateTimeOffset(2022, 12, 12, 0, 0, 0, 0, new TimeSpan());
        private static readonly TimeSpan PlainTimeData = new TimeSpan(13, 06, 12);

        [Test]
        public void PlainDateTime()
        {
            var input = new RoundTripOptionalModel();
            input.OptionalPlainDate = PlainDateData;

            JsonAsserts.AssertSerialization("{\"optionalPlainDate\":\"2022-12-12\"}", input);

            var output = RoundTripOptionalModel.DeserializeRoundTripOptionalModel(JsonAsserts.Parse("{\"optionalPlainDate\":\"2022-12-12\"}"));
            Assert.AreEqual(PlainDateData, output.OptionalPlainDate);
        }

        [Test]
        public void PlainDateTimeOmittingTime()
        {
            var input = new RoundTripOptionalModel();
            input.OptionalPlainDate = new DateTimeOffset(2022, 12, 12, 13, 06, 0, 0, new TimeSpan());

            JsonAsserts.AssertSerialization("{\"optionalPlainDate\":\"2022-12-12\"}", input);

            var output = RoundTripOptionalModel.DeserializeRoundTripOptionalModel(JsonAsserts.Parse("{\"optionalPlainDate\":\"2022-12-12T13:06:00\"}"));
            var plainDate = output.OptionalPlainDate;
            Assert.IsNotNull(plainDate.Value);
            Assert.AreEqual(2022, plainDate.Value.Year);
            Assert.AreEqual(12, plainDate.Value.Month);
            Assert.AreEqual(12, plainDate.Value.Day);
            Assert.AreEqual(13, plainDate.Value.Hour);
            Assert.AreEqual(06, plainDate.Value.Minute);
            Assert.AreEqual(0, plainDate.Value.Millisecond);
        }

        [Test]
        public void PlainTime()
        {
            var input = new RoundTripOptionalModel();
            input.OptionalPlainTime = PlainTimeData;

            JsonAsserts.AssertSerialization("{\"optionalPlainTime\":\"13:06:12\"}", input);

            var output = RoundTripOptionalModel.DeserializeRoundTripOptionalModel(JsonAsserts.Parse("{\"optionalPlainTime\":\"13:06:12\"}"));
            Assert.AreEqual(PlainTimeData, output.OptionalPlainTime);
        }
    }
}
