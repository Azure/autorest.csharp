// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using System.Xml;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Property.Optionality;
using _Type.Property.Optionality.Models;

namespace _Type.Property.Optionality.Samples
{
    public class Samples_Duration
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response response = client.GetAll(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response<DurationProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response<DurationProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_AllParameters()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response response = client.GetAll(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_AllParameters_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response response = await client.GetAllAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetAll_AllParameters_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response<DurationProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetAll_AllParameters_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response<DurationProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response response = client.GetDefault(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response<DurationProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response<DurationProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault_AllParameters()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response response = client.GetDefault(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_AllParameters_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response response = await client.GetDefaultAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDefault_AllParameters_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response<DurationProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDefault_AllParameters_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            Response<DurationProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            RequestContent content = RequestContent.Create(new object());
            Response response = client.PutAll(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            DurationProperty body = new DurationProperty();
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            DurationProperty body = new DurationProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll_AllParameters()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = client.PutAll(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_AllParameters_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = await client.PutAllAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutAll_AllParameters_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            DurationProperty body = new DurationProperty
            {
                Property = XmlConvert.ToTimeSpan("PT1H23M45S"),
            };
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutAll_AllParameters_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            DurationProperty body = new DurationProperty
            {
                Property = XmlConvert.ToTimeSpan("PT1H23M45S"),
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            RequestContent content = RequestContent.Create(new object());
            Response response = client.PutDefault(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            DurationProperty body = new DurationProperty();
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            DurationProperty body = new DurationProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault_AllParameters()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = client.PutDefault(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_AllParameters_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                property = "PT1H23M45S",
            });
            Response response = await client.PutDefaultAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDefault_AllParameters_Convenience()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            DurationProperty body = new DurationProperty
            {
                Property = XmlConvert.ToTimeSpan("PT1H23M45S"),
            };
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDefault_AllParameters_Convenience_Async()
        {
            Duration client = new OptionalClient().GetDurationClient("1.0.0");

            DurationProperty body = new DurationProperty
            {
                Property = XmlConvert.ToTimeSpan("PT1H23M45S"),
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
