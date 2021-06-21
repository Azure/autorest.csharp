// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Utilities;
using NUnit.Framework;

namespace AutoRest.CSharp.Tests
{
    public class CodeModelValidatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyOperationGroupName()
        {
            var model = loadModel("Mgmt/AutoRest/EmptyOperationGroupName.yaml");
            try
            {
                CodeModelValidator.Validate(model);
            } catch (ErrorHelpers.ErrorException e)
            {
                Assert.IsNotNull(e);
                return;
            }
            Assert.Fail("ErrorHelpers.ErrorException expected");
        }

        private CodeModel loadModel(string filePath)
        {
            return CodeModelSerialization.DeserializeCodeModel(File.ReadAllText(filePath));
        }
    }
}
