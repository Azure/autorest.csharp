// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.TestFramework
{
    public abstract class ManagementRecordedTestBase<TEnvironment>
    {

        public TestRecording Recording { get; private set; }
        protected ManagementRecordedTestBase(bool isAsync)
        {
            Recording = new TestRecording();
        }

        protected ManagementRecordedTestBase(bool isAsync, RecordedTestMode mode)
        {
            Recording = new TestRecording();
        }

        protected ArmClient GetArmClient(ArmClientOptions? clientOptions = default)
        {
            return new ArmClient(default);
        }
    }
}
