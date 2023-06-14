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

namespace body_file_LowLevel.Samples
{
    public class Samples_FilesClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFile()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FilesClient(credential);

            Response response = client.GetFile();
            if (response.ContentStream != null)
            {
                using (Stream outFileStream = File.OpenWrite("<filePath>"))
                {
                    response.ContentStream.CopyTo(outFileStream);
                }
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFile_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FilesClient(credential);

            Response response = client.GetFile();
            if (response.ContentStream != null)
            {
                using (Stream outFileStream = File.OpenWrite("<filePath>"))
                {
                    response.ContentStream.CopyTo(outFileStream);
                }
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFile_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FilesClient(credential);

            Response response = await client.GetFileAsync();
            if (response.ContentStream != null)
            {
                using (Stream outFileStream = File.OpenWrite("<filePath>"))
                {
                    response.ContentStream.CopyTo(outFileStream);
                }
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFile_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FilesClient(credential);

            Response response = await client.GetFileAsync();
            if (response.ContentStream != null)
            {
                using (Stream outFileStream = File.OpenWrite("<filePath>"))
                {
                    response.ContentStream.CopyTo(outFileStream);
                }
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFileLarge()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FilesClient(credential);

            Response response = client.GetFileLarge();
            if (response.ContentStream != null)
            {
                using (Stream outFileStream = File.OpenWrite("<filePath>"))
                {
                    response.ContentStream.CopyTo(outFileStream);
                }
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetFileLarge_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FilesClient(credential);

            Response response = client.GetFileLarge();
            if (response.ContentStream != null)
            {
                using (Stream outFileStream = File.OpenWrite("<filePath>"))
                {
                    response.ContentStream.CopyTo(outFileStream);
                }
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFileLarge_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FilesClient(credential);

            Response response = await client.GetFileLargeAsync();
            if (response.ContentStream != null)
            {
                using (Stream outFileStream = File.OpenWrite("<filePath>"))
                {
                    response.ContentStream.CopyTo(outFileStream);
                }
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetFileLarge_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FilesClient(credential);

            Response response = await client.GetFileLargeAsync();
            if (response.ContentStream != null)
            {
                using (Stream outFileStream = File.OpenWrite("<filePath>"))
                {
                    response.ContentStream.CopyTo(outFileStream);
                }
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmptyFile()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FilesClient(credential);

            Response response = client.GetEmptyFile();
            if (response.ContentStream != null)
            {
                using (Stream outFileStream = File.OpenWrite("<filePath>"))
                {
                    response.ContentStream.CopyTo(outFileStream);
                }
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEmptyFile_AllParameters()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FilesClient(credential);

            Response response = client.GetEmptyFile();
            if (response.ContentStream != null)
            {
                using (Stream outFileStream = File.OpenWrite("<filePath>"))
                {
                    response.ContentStream.CopyTo(outFileStream);
                }
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmptyFile_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FilesClient(credential);

            Response response = await client.GetEmptyFileAsync();
            if (response.ContentStream != null)
            {
                using (Stream outFileStream = File.OpenWrite("<filePath>"))
                {
                    response.ContentStream.CopyTo(outFileStream);
                }
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEmptyFile_AllParameters_Async()
        {
            var credential = new AzureKeyCredential("<key>");
            var client = new FilesClient(credential);

            Response response = await client.GetEmptyFileAsync();
            if (response.ContentStream != null)
            {
                using (Stream outFileStream = File.OpenWrite("<filePath>"))
                {
                    response.ContentStream.CopyTo(outFileStream);
                }
            }
        }
    }
}
