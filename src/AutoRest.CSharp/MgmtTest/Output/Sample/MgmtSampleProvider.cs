// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.MgmtTest.Output.Sample
{
    internal class MgmtSampleProvider : MgmtTestProvider
    {
        public MockTestCase DataProvider { get; }
        public MgmtSampleProvider(MockTestCase testCase) : base()
        {
            DataProvider = testCase;
        }

        private string? _defaultName;
        protected override string DefaultName => _defaultName ??= $"SampleFor{DataProvider.Name.ToCleanName()}";

        // a sample class does not need a description
        public override FormattableString Description => $"";
    }
}
