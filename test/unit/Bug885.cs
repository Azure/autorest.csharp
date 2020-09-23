// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Bug885.Models;
using Xunit;

namespace AutoRest.CSharp.Unit.Tests
{
    public class Bug885
    {
        /// <summary>
        ///  https://github.com/Azure/autorest.csharp/issues/885
        ///  Validate optional properties successfully.
        /// </summary>
        [Fact]
        public async Task ValidateOptionalProperties()
        {
            var dateAfterModification = new DateAfterModification();
            dateAfterModification.Validate();
        }
    }
}