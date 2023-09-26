// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Property.Nullable;
using _Type.Property.Nullable.Models;

namespace _Type.Property.Nullable.Samples
{
    public class Samples_CollectionsModel
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response response = client.GetNonNull(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_Async()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response response = await client.GetNonNullAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull_Convenience()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response<CollectionsModelProperty> response = client.GetNonNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_Convenience_Async()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response<CollectionsModelProperty> response = await client.GetNonNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull_AllParameters()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response response = client.GetNonNull(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_AllParameters_Async()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response response = await client.GetNonNullAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNonNull_AllParameters_Convenience()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response<CollectionsModelProperty> response = client.GetNonNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNonNull_AllParameters_Convenience_Async()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response<CollectionsModelProperty> response = await client.GetNonNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response response = client.GetNull(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_Async()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response response = await client.GetNullAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_Convenience()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response<CollectionsModelProperty> response = client.GetNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_Convenience_Async()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response<CollectionsModelProperty> response = await client.GetNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_AllParameters()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response response = client.GetNull(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_AllParameters_Async()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response response = await client.GetNullAsync(null);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetNull_AllParameters_Convenience()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response<CollectionsModelProperty> response = client.GetNull();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetNull_AllParameters_Convenience_Async()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            Response<CollectionsModelProperty> response = await client.GetNullAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNonNull()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = client.PatchNonNull(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNonNull_Async()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = await client.PatchNonNullAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNonNull_AllParameters()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = client.PatchNonNull(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNonNull_AllParameters_Async()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = await client.PatchNonNullAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNull()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = client.PatchNull(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNull_Async()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = await client.PatchNullAsync(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_PatchNull_AllParameters()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = client.PatchNull(content);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_PatchNull_AllParameters_Async()
        {
            CollectionsModel client = new NullableClient().GetCollectionsModelClient("1.0.0");

            RequestContent content = RequestContent.Create(new
            {
                requiredProperty = "<requiredProperty>",
                nullableProperty = new object[]
            {
new
{
property = "<property>",
}
            },
            });
            Response response = await client.PatchNullAsync(content);
        }
    }
}
