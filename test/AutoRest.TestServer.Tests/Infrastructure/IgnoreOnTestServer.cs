// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace AutoRest.TestServer.Tests
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public class IgnoreOnTestServer : NUnitAttribute, IApplyToTest
    {
        private readonly TestServerVersion _version;
        private readonly string _reason;

        public IgnoreOnTestServer(TestServerVersion version, string reason)
        {
            _version = version;
            _reason = reason;
        }

        #region IApplyToTest members

        /// <summary>
        /// Modifies a test by marking it as Ignored.
        /// </summary>
        /// <param name="test">The test to modify</param>
        public void ApplyToTest(Test test)
        {
            if (test.RunState != RunState.NotRunnable)
            {
                // This is an unfortunate implementation but it's the only one I was able to figure out
                string testParameters = test.FullName.Substring(test.ClassName.Length);
                if (testParameters.StartsWith("(" + _version))
                {
                    test.RunState = RunState.Ignored;
                    test.Properties.Set("_SKIPREASON", _reason);
                }
            }
        }

        #endregion
    }
}
