// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Model.Visibility.Models;

namespace _Type.Model.Visibility.Tests
{
    public partial class VisibilityClientTests : _TypeModelVisibilityTestBase
    {
        public VisibilityClientTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_GetModel_ShortVersion()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                queryProp = 1234,
                createProp = new object[]
            {
"<createProp>"
            },
                updateProp = new object[]
            {
1234
            },
                deleteProp = true,
            });
            Response response = await client.GetModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_GetModel_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            VisibilityModel input = new VisibilityModel(1234, new string[] { "<createProp>" }, new int[] { 1234 }, true);
            Response<VisibilityModel> response = await client.GetModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_GetModel_AllParameters()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                queryProp = 1234,
                createProp = new object[]
            {
"<createProp>"
            },
                updateProp = new object[]
            {
1234
            },
                deleteProp = true,
            });
            Response response = await client.GetModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_GetModel_AllParameters_Convenience()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            VisibilityModel input = new VisibilityModel(1234, new string[] { "<createProp>" }, new int[] { 1234 }, true);
            Response<VisibilityModel> response = await client.GetModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_HeadModel_ShortVersion()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                queryProp = 1234,
                createProp = new object[]
            {
"<createProp>"
            },
                updateProp = new object[]
            {
1234
            },
                deleteProp = true,
            });
            Response response = await client.HeadModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_HeadModel_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            VisibilityModel input = new VisibilityModel(1234, new string[] { "<createProp>" }, new int[] { 1234 }, true);
            Response response = await client.HeadModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_HeadModel_AllParameters()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                queryProp = 1234,
                createProp = new object[]
            {
"<createProp>"
            },
                updateProp = new object[]
            {
1234
            },
                deleteProp = true,
            });
            Response response = await client.HeadModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_HeadModel_AllParameters_Convenience()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            VisibilityModel input = new VisibilityModel(1234, new string[] { "<createProp>" }, new int[] { 1234 }, true);
            Response response = await client.HeadModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PutModel_ShortVersion()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                queryProp = 1234,
                createProp = new object[]
            {
"<createProp>"
            },
                updateProp = new object[]
            {
1234
            },
                deleteProp = true,
            });
            Response response = await client.PutModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PutModel_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            VisibilityModel input = new VisibilityModel(1234, new string[] { "<createProp>" }, new int[] { 1234 }, true);
            Response response = await client.PutModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PutModel_AllParameters()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                queryProp = 1234,
                createProp = new object[]
            {
"<createProp>"
            },
                updateProp = new object[]
            {
1234
            },
                deleteProp = true,
            });
            Response response = await client.PutModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PutModel_AllParameters_Convenience()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            VisibilityModel input = new VisibilityModel(1234, new string[] { "<createProp>" }, new int[] { 1234 }, true);
            Response response = await client.PutModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PatchModel_ShortVersion()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                queryProp = 1234,
                createProp = new object[]
            {
"<createProp>"
            },
                updateProp = new object[]
            {
1234
            },
                deleteProp = true,
            });
            Response response = await client.PatchModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PatchModel_AllParameters()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                queryProp = 1234,
                createProp = new object[]
            {
"<createProp>"
            },
                updateProp = new object[]
            {
1234
            },
                deleteProp = true,
            });
            Response response = await client.PatchModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PostModel_ShortVersion()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                queryProp = 1234,
                createProp = new object[]
            {
"<createProp>"
            },
                updateProp = new object[]
            {
1234
            },
                deleteProp = true,
            });
            Response response = await client.PostModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PostModel_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            VisibilityModel input = new VisibilityModel(1234, new string[] { "<createProp>" }, new int[] { 1234 }, true);
            Response response = await client.PostModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PostModel_AllParameters()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                queryProp = 1234,
                createProp = new object[]
            {
"<createProp>"
            },
                updateProp = new object[]
            {
1234
            },
                deleteProp = true,
            });
            Response response = await client.PostModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PostModel_AllParameters_Convenience()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            VisibilityModel input = new VisibilityModel(1234, new string[] { "<createProp>" }, new int[] { 1234 }, true);
            Response response = await client.PostModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_DeleteModel_ShortVersion()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                queryProp = 1234,
                createProp = new object[]
            {
"<createProp>"
            },
                updateProp = new object[]
            {
1234
            },
                deleteProp = true,
            });
            Response response = await client.DeleteModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_DeleteModel_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            VisibilityModel input = new VisibilityModel(1234, new string[] { "<createProp>" }, new int[] { 1234 }, true);
            Response response = await client.DeleteModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_DeleteModel_AllParameters()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new
            {
                queryProp = 1234,
                createProp = new object[]
            {
"<createProp>"
            },
                updateProp = new object[]
            {
1234
            },
                deleteProp = true,
            });
            Response response = await client.DeleteModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_DeleteModel_AllParameters_Convenience()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            VisibilityModel input = new VisibilityModel(1234, new string[] { "<createProp>" }, new int[] { 1234 }, true);
            Response response = await client.DeleteModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PutReadOnlyModel_ShortVersion()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutReadOnlyModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PutReadOnlyModel_ShortVersion_Convenience()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            ReadOnlyModel input = new ReadOnlyModel();
            Response<ReadOnlyModel> response = await client.PutReadOnlyModelAsync(input);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PutReadOnlyModel_AllParameters()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutReadOnlyModelAsync(content);
        }

        [Test]
        [Ignore("Please remove the Ignore attribute to let the test method run")]
        public async Task Visibility_PutReadOnlyModel_AllParameters_Convenience()
        {
            Uri endpoint = null;
            VisibilityClient client = CreateVisibilityClient(endpoint);

            ReadOnlyModel input = new ReadOnlyModel();
            Response<ReadOnlyModel> response = await client.PutReadOnlyModelAsync(input);
        }
    }
}
