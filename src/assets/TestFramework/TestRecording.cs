// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;

namespace Azure.Core.TestFramework
{
    public class TestRecording
    {

        public string GenerateAssetName(string prefix, [CallerMemberName] string callerMethodName = "testframework_failed")
        {
            return "Fake";
        }
    }
}
