// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Utilities;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests.Mgmt
{
    public class CodeModelValidatorTest
    {
        [Test]
        public void EmptyOperationGroupName()
        {
            var model = new CodeModel
            {
                OperationGroups = new System.Collections.ObjectModel.Collection<OperationGroup>
                {
                    // AutoRest will pass in operation group with empty name if `operationId` doesn't contain underscore
                    new OperationGroup { Key = ""}
                }
            };

            Assert.Throws<ErrorHelpers.ErrorException>(() => CodeModelValidator.Validate(model));
        }
    }
}
