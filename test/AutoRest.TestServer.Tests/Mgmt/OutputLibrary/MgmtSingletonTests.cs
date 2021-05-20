// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Mgmt.Decorator;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt.OutputLibrary
{
    internal class MgmtSingletonTests : OutputLibraryTestBase
    {
        public MgmtSingletonTests() : base("MgmtSingleton") { }

        [Test]
        public void TestSingletonDetection()
        {
            var result = Generate("MgmtSingleton").Result;
            var model = result.Model;
            var context = result.Context;
            foreach (var og in model.OperationGroups)
            {
                if (og.Key.Equals("SingletonResources"))
                    Assert.IsTrue(og.IsSingletonResource(context.Configuration.MgmtConfiguration));
                else
                    Assert.IsFalse(og.IsSingletonResource(context.Configuration.MgmtConfiguration));
            }
        }
    }
}
