// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.TestFramework
{
    public abstract class RecordedTestBase<TEnvironment> where TEnvironment : TestEnvironment, new()
    {
        protected RecordedTestBase(bool isAsync, RecordedTestMode? mode = null)
        {
        }
    }
}
