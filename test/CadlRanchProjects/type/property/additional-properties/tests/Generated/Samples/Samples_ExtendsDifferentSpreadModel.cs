// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Property.AdditionalProperties.Models;

namespace _Type.Property.AdditionalProperties.Samples
{
    public partial class Samples_ExtendsDifferentSpreadModel
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsDifferentSpreadModel_GetExtendsDifferentSpreadModel_ShortVersion()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            Response response = client.GetExtendsDifferentSpreadModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("derivedProp").GetProperty("state").ToString());
            Console.WriteLine(result.GetProperty("knownProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsDifferentSpreadModel_GetExtendsDifferentSpreadModel_ShortVersion_Async()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            Response response = await client.GetExtendsDifferentSpreadModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("derivedProp").GetProperty("state").ToString());
            Console.WriteLine(result.GetProperty("knownProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsDifferentSpreadModel_GetExtendsDifferentSpreadModel_ShortVersion_Convenience()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            Response<DifferentSpreadModelDerived> response = client.GetExtendsDifferentSpreadModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsDifferentSpreadModel_GetExtendsDifferentSpreadModel_ShortVersion_Convenience_Async()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            Response<DifferentSpreadModelDerived> response = await client.GetExtendsDifferentSpreadModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsDifferentSpreadModel_GetExtendsDifferentSpreadModel_AllParameters()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            Response response = client.GetExtendsDifferentSpreadModel(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("derivedProp").GetProperty("state").ToString());
            Console.WriteLine(result.GetProperty("knownProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsDifferentSpreadModel_GetExtendsDifferentSpreadModel_AllParameters_Async()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            Response response = await client.GetExtendsDifferentSpreadModelAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("derivedProp").GetProperty("state").ToString());
            Console.WriteLine(result.GetProperty("knownProp").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsDifferentSpreadModel_GetExtendsDifferentSpreadModel_AllParameters_Convenience()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            Response<DifferentSpreadModelDerived> response = client.GetExtendsDifferentSpreadModel();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsDifferentSpreadModel_GetExtendsDifferentSpreadModel_AllParameters_Convenience_Async()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            Response<DifferentSpreadModelDerived> response = await client.GetExtendsDifferentSpreadModelAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsDifferentSpreadModel_Put_ShortVersion()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            using RequestContent content = RequestContent.Create(new
            {
                derivedProp = new
                {
                    state = "<state>",
                },
                knownProp = "<knownProp>",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsDifferentSpreadModel_Put_ShortVersion_Async()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            using RequestContent content = RequestContent.Create(new
            {
                derivedProp = new
                {
                    state = "<state>",
                },
                knownProp = "<knownProp>",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsDifferentSpreadModel_Put_ShortVersion_Convenience()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            DifferentSpreadModelDerived body = new DifferentSpreadModelDerived("<knownProp>", new ModelForRecord("<state>"));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsDifferentSpreadModel_Put_ShortVersion_Convenience_Async()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            DifferentSpreadModelDerived body = new DifferentSpreadModelDerived("<knownProp>", new ModelForRecord("<state>"));
            Response response = await client.PutAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsDifferentSpreadModel_Put_AllParameters()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            using RequestContent content = RequestContent.Create(new
            {
                derivedProp = new
                {
                    state = "<state>",
                },
                knownProp = "<knownProp>",
            });
            Response response = client.Put(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsDifferentSpreadModel_Put_AllParameters_Async()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            using RequestContent content = RequestContent.Create(new
            {
                derivedProp = new
                {
                    state = "<state>",
                },
                knownProp = "<knownProp>",
            });
            Response response = await client.PutAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_ExtendsDifferentSpreadModel_Put_AllParameters_Convenience()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            DifferentSpreadModelDerived body = new DifferentSpreadModelDerived("<knownProp>", new ModelForRecord("<state>"));
            Response response = client.Put(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_ExtendsDifferentSpreadModel_Put_AllParameters_Convenience_Async()
        {
            ExtendsDifferentSpreadModel client = new AdditionalPropertiesClient().GetExtendsDifferentSpreadModelClient();

            DifferentSpreadModelDerived body = new DifferentSpreadModelDerived("<knownProp>", new ModelForRecord("<state>"));
            Response response = await client.PutAsync(body);
        }
    }
}
