// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;

namespace AutoRest.CSharp.MgmtTest.Output.Mock
{
    internal class MgmtMockTestProvider<T> : TypeProvider where T : MgmtTypeProvider
    {
        protected Parameter IsAsyncParameter => new(Name: "isAsync", Description: null, Type: typeof(bool), DefaultValue: null, ValidationType.None, null);

        public T Target { get; }
        public MgmtMockTestProvider(T provider, IEnumerable<MockTestCase> testCases) : base(MgmtContext.Context)
        {
            Target = provider;
            MockTestCases = testCases;
        }

        public IEnumerable<MockTestCase> MockTestCases { get; }
        public string Accessibility => DefaultAccessibility;
        protected override string DefaultAccessibility => "public";
        public virtual FormattableString Description => $"Test for {Target.Type.Name}";
        public string Namespace => DefaultNamespace;
        protected override string DefaultName => $"{Target.Type.Name}MockTests";
        protected override string DefaultNamespace => $"{Target.Type.Namespace}.Tests.Mock";
        public virtual CSharpType? BaseType => typeof(MockTestBase);

        private ConstructorSignature? _ctor;
        public ConstructorSignature? Ctor => _ctor ??= EnsureCtor();
        protected virtual ConstructorSignature? EnsureCtor()
        {
            return new ConstructorSignature(
                Name: Type.Name,
                Description: $"Initializes a new instance of the <see cref=\"{Type.Name}\"/> class for mocking.",
                Modifiers: MethodSignatureModifiers.Public,
                Parameters: new[] { IsAsyncParameter },
                Initializer: new ConstructorInitializer(
                    true,
                    new FormattableString[] { $"{IsAsyncParameter.Name:I}", $"{typeof(RecordedTestMode)}.Record" }));
        }
    }
}
