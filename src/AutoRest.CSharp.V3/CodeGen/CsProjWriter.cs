// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class CsProjWriter : StringWriter
    {
        public bool WriteCsProj(Configuration configuration)
        {
            Line($@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <Nullable>annotations</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Azure.Core"" Version=""1.0.0"" />
    <PackageReference Include=""System.Text.Json"" Version=""4.6.0"" />
  </ItemGroup>

</Project>
");

            return true;
        }
    }
}
