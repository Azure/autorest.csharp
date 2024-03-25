// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


namespace Server.Path.Multiple
{
    public partial class MultipleClient
    {
        // Workaround of naming conflict with namespace `Server.Versions` in another test project
        private readonly Models.Versions? _apiVersion;
    }
}
