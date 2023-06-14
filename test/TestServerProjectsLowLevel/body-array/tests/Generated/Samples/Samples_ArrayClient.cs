// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace body_array_LowLevel.Samples
{
    public class Samples_ArrayClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetInvalid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetInvalid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetInvalid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetInvalid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetInvalid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetInvalidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetInvalid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetInvalidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "<String>"
};

            Response response = client.PutEmpty(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "<String>"
};

            Response response = client.PutEmpty(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "<String>"
};

            Response response = await client.PutEmptyAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "<String>"
};

            Response response = await client.PutEmptyAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanTfft()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetBooleanTfft();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanTfft_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetBooleanTfft();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanTfft_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetBooleanTfftAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanTfft_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetBooleanTfftAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutBooleanTfft()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    true
};

            Response response = client.PutBooleanTfft(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutBooleanTfft_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    true
};

            Response response = client.PutBooleanTfft(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutBooleanTfft_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    true
};

            Response response = await client.PutBooleanTfftAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutBooleanTfft_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    true
};

            Response response = await client.PutBooleanTfftAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanInvalidNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetBooleanInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanInvalidNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetBooleanInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanInvalidNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetBooleanInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanInvalidNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetBooleanInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanInvalidString()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetBooleanInvalidString();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBooleanInvalidString_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetBooleanInvalidString();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanInvalidString_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetBooleanInvalidStringAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBooleanInvalidString_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetBooleanInvalidStringAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntegerValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetIntegerValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntegerValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetIntegerValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntegerValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetIntegerValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntegerValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetIntegerValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutIntegerValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    1234
};

            Response response = client.PutIntegerValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutIntegerValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    1234
};

            Response response = client.PutIntegerValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutIntegerValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    1234
};

            Response response = await client.PutIntegerValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutIntegerValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    1234
};

            Response response = await client.PutIntegerValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntInvalidNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetIntInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntInvalidNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetIntInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntInvalidNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetIntInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntInvalidNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetIntInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntInvalidString()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetIntInvalidString();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetIntInvalidString_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetIntInvalidString();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntInvalidString_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetIntInvalidStringAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetIntInvalidString_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetIntInvalidStringAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLongValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetLongValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLongValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetLongValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLongValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetLongValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLongValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetLongValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutLongValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    1234L
};

            Response response = client.PutLongValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutLongValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    1234L
};

            Response response = client.PutLongValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutLongValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    1234L
};

            Response response = await client.PutLongValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutLongValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    1234L
};

            Response response = await client.PutLongValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLongInvalidNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetLongInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLongInvalidNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetLongInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLongInvalidNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetLongInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLongInvalidNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetLongInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLongInvalidString()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetLongInvalidString();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetLongInvalidString_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetLongInvalidString();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLongInvalidString_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetLongInvalidStringAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetLongInvalidString_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetLongInvalidStringAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloatValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetFloatValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloatValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetFloatValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloatValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetFloatValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloatValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetFloatValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutFloatValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    123.45f
};

            Response response = client.PutFloatValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutFloatValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    123.45f
};

            Response response = client.PutFloatValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutFloatValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    123.45f
};

            Response response = await client.PutFloatValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutFloatValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    123.45f
};

            Response response = await client.PutFloatValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloatInvalidNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetFloatInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloatInvalidNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetFloatInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloatInvalidNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetFloatInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloatInvalidNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetFloatInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloatInvalidString()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetFloatInvalidString();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFloatInvalidString_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetFloatInvalidString();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloatInvalidString_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetFloatInvalidStringAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFloatInvalidString_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetFloatInvalidStringAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDoubleValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDoubleValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDoubleValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDoubleValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDoubleValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDoubleValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDoubleValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDoubleValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDoubleValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    123.45d
};

            Response response = client.PutDoubleValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDoubleValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    123.45d
};

            Response response = client.PutDoubleValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDoubleValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    123.45d
};

            Response response = await client.PutDoubleValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDoubleValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    123.45d
};

            Response response = await client.PutDoubleValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDoubleInvalidNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDoubleInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDoubleInvalidNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDoubleInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDoubleInvalidNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDoubleInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDoubleInvalidNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDoubleInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDoubleInvalidString()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDoubleInvalidString();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDoubleInvalidString_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDoubleInvalidString();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDoubleInvalidString_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDoubleInvalidStringAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDoubleInvalidString_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDoubleInvalidStringAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetStringValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetStringValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetStringValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetStringValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutStringValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "<String>"
};

            Response response = client.PutStringValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutStringValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "<String>"
};

            Response response = client.PutStringValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutStringValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "<String>"
};

            Response response = await client.PutStringValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutStringValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "<String>"
};

            Response response = await client.PutStringValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEnumValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetEnumValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEnumValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetEnumValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEnumValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetEnumValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEnumValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetEnumValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutEnumValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "foo1"
};

            Response response = client.PutEnumValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutEnumValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "foo1"
};

            Response response = client.PutEnumValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutEnumValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "foo1"
};

            Response response = await client.PutEnumValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutEnumValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "foo1"
};

            Response response = await client.PutEnumValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringEnumValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetStringEnumValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringEnumValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetStringEnumValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringEnumValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetStringEnumValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringEnumValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetStringEnumValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutStringEnumValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "foo1"
};

            Response response = client.PutStringEnumValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutStringEnumValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "foo1"
};

            Response response = client.PutStringEnumValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutStringEnumValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "foo1"
};

            Response response = await client.PutStringEnumValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutStringEnumValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "foo1"
};

            Response response = await client.PutStringEnumValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringWithNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetStringWithNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringWithNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetStringWithNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringWithNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetStringWithNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringWithNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetStringWithNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringWithInvalid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetStringWithInvalid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringWithInvalid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetStringWithInvalid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringWithInvalid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetStringWithInvalidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringWithInvalid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetStringWithInvalidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUuidValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetUuidValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUuidValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetUuidValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUuidValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetUuidValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUuidValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetUuidValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutUuidValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"
};

            Response response = client.PutUuidValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutUuidValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"
};

            Response response = client.PutUuidValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutUuidValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"
};

            Response response = await client.PutUuidValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutUuidValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "73f411fe-4f43-4b4b-9cbd-6828d8f4cf9a"
};

            Response response = await client.PutUuidValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUuidInvalidChars()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetUuidInvalidChars();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetUuidInvalidChars_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetUuidInvalidChars();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUuidInvalidChars_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetUuidInvalidCharsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetUuidInvalidChars_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetUuidInvalidCharsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDateValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "2022-05-10"
};

            Response response = client.PutDateValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDateValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "2022-05-10"
};

            Response response = client.PutDateValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDateValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "2022-05-10"
};

            Response response = await client.PutDateValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDateValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "2022-05-10"
};

            Response response = await client.PutDateValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateInvalidNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateInvalidNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateInvalidNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateInvalidNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateInvalidChars()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateInvalidChars();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateInvalidChars_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateInvalidChars();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateInvalidChars_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateInvalidCharsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateInvalidChars_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateInvalidCharsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateTimeValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateTimeValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateTimeValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateTimeValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateTimeValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateTimeValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateTimeValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateTimeValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDateTimeValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "2022-05-10T18:57:31.2311892Z"
};

            Response response = client.PutDateTimeValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDateTimeValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "2022-05-10T18:57:31.2311892Z"
};

            Response response = client.PutDateTimeValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDateTimeValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "2022-05-10T18:57:31.2311892Z"
};

            Response response = await client.PutDateTimeValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDateTimeValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "2022-05-10T18:57:31.2311892Z"
};

            Response response = await client.PutDateTimeValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateTimeInvalidNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateTimeInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateTimeInvalidNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateTimeInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateTimeInvalidNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateTimeInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateTimeInvalidNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateTimeInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateTimeInvalidChars()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateTimeInvalidChars();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateTimeInvalidChars_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateTimeInvalidChars();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateTimeInvalidChars_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateTimeInvalidCharsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateTimeInvalidChars_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateTimeInvalidCharsAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateTimeRfc1123Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateTimeRfc1123Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDateTimeRfc1123Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDateTimeRfc1123Valid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateTimeRfc1123Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateTimeRfc1123ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDateTimeRfc1123Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDateTimeRfc1123ValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDateTimeRfc1123Valid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "Tue, 10 May 2022 18:57:31 GMT"
};

            Response response = client.PutDateTimeRfc1123Valid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDateTimeRfc1123Valid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "Tue, 10 May 2022 18:57:31 GMT"
};

            Response response = client.PutDateTimeRfc1123Valid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDateTimeRfc1123Valid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "Tue, 10 May 2022 18:57:31 GMT"
};

            Response response = await client.PutDateTimeRfc1123ValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDateTimeRfc1123Valid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "Tue, 10 May 2022 18:57:31 GMT"
};

            Response response = await client.PutDateTimeRfc1123ValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDurationValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDurationValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDurationValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDurationValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDurationValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDurationValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDurationValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDurationValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDurationValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "PT1H23M45S"
};

            Response response = client.PutDurationValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDurationValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "PT1H23M45S"
};

            Response response = client.PutDurationValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDurationValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "PT1H23M45S"
};

            Response response = await client.PutDurationValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDurationValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    "PT1H23M45S"
};

            Response response = await client.PutDurationValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetByteValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetByteValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetByteValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetByteValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetByteValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetByteValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetByteValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetByteValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutByteValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new {}
};

            Response response = client.PutByteValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutByteValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new {}
};

            Response response = client.PutByteValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutByteValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new {}
};

            Response response = await client.PutByteValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutByteValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new {}
};

            Response response = await client.PutByteValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetByteInvalidNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetByteInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetByteInvalidNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetByteInvalidNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetByteInvalidNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetByteInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetByteInvalidNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetByteInvalidNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBase64Url()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetBase64Url();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetBase64Url_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetBase64Url();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBase64Url_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetBase64UrlAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetBase64Url_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetBase64UrlAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComplexNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetComplexNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComplexNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetComplexNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("integer").ToString());
            Console.WriteLine(result[0].GetProperty("string").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComplexNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetComplexNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComplexNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetComplexNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("integer").ToString());
            Console.WriteLine(result[0].GetProperty("string").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComplexEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetComplexEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComplexEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetComplexEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("integer").ToString());
            Console.WriteLine(result[0].GetProperty("string").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComplexEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetComplexEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComplexEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetComplexEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("integer").ToString());
            Console.WriteLine(result[0].GetProperty("string").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComplexItemNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetComplexItemNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComplexItemNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetComplexItemNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("integer").ToString());
            Console.WriteLine(result[0].GetProperty("string").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComplexItemNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetComplexItemNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComplexItemNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetComplexItemNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("integer").ToString());
            Console.WriteLine(result[0].GetProperty("string").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComplexItemEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetComplexItemEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComplexItemEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetComplexItemEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("integer").ToString());
            Console.WriteLine(result[0].GetProperty("string").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComplexItemEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetComplexItemEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComplexItemEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetComplexItemEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("integer").ToString());
            Console.WriteLine(result[0].GetProperty("string").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComplexValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetComplexValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetComplexValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetComplexValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("integer").ToString());
            Console.WriteLine(result[0].GetProperty("string").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComplexValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetComplexValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetComplexValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetComplexValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("integer").ToString());
            Console.WriteLine(result[0].GetProperty("string").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutComplexValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new {}
};

            Response response = client.PutComplexValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutComplexValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new {
        integer = 1234,
        @string = "<string>",
    }
};

            Response response = client.PutComplexValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutComplexValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new {}
};

            Response response = await client.PutComplexValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutComplexValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new {
        integer = 1234,
        @string = "<string>",
    }
};

            Response response = await client.PutComplexValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetArrayNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetArrayNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetArrayNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetArrayNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetArrayNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetArrayNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetArrayNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetArrayNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetArrayEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetArrayEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetArrayEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetArrayEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetArrayEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetArrayEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetArrayEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetArrayEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetArrayItemNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetArrayItemNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetArrayItemNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetArrayItemNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetArrayItemNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetArrayItemNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetArrayItemNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetArrayItemNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetArrayItemEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetArrayItemEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetArrayItemEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetArrayItemEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetArrayItemEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetArrayItemEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetArrayItemEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetArrayItemEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetArrayValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetArrayValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetArrayValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetArrayValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetArrayValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetArrayValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetArrayValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetArrayValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0][0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutArrayValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new[] {
        "<String>"
    }
};

            Response response = client.PutArrayValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutArrayValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new[] {
        "<String>"
    }
};

            Response response = client.PutArrayValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutArrayValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new[] {
        "<String>"
    }
};

            Response response = await client.PutArrayValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutArrayValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new[] {
        "<String>"
    }
};

            Response response = await client.PutArrayValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDictionaryNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDictionaryNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDictionaryNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDictionaryNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDictionaryNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDictionaryNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDictionaryNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDictionaryNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDictionaryEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDictionaryEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDictionaryEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDictionaryEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDictionaryEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDictionaryEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDictionaryEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDictionaryEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDictionaryItemNull()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDictionaryItemNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDictionaryItemNull_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDictionaryItemNull();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDictionaryItemNull_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDictionaryItemNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDictionaryItemNull_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDictionaryItemNullAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDictionaryItemEmpty()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDictionaryItemEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDictionaryItemEmpty_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDictionaryItemEmpty();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDictionaryItemEmpty_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDictionaryItemEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDictionaryItemEmpty_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDictionaryItemEmptyAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDictionaryValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDictionaryValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetDictionaryValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = client.GetDictionaryValid();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDictionaryValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDictionaryValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetDictionaryValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            Response response = await client.GetDictionaryValidAsync();

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result[0].GetProperty("<test>").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDictionaryValid()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new {
        key = "<String>",
    }
};

            Response response = client.PutDictionaryValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PutDictionaryValid_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new {
        key = "<String>",
    }
};

            Response response = client.PutDictionaryValid(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDictionaryValid_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new {
        key = "<String>",
    }
};

            Response response = await client.PutDictionaryValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PutDictionaryValid_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new ArrayClient(credential);

            var data = new[] {
    new {
        key = "<String>",
    }
};

            Response response = await client.PutDictionaryValidAsync(RequestContent.Create(data));
            Console.WriteLine(response.Status);
        }
    }
}
