namespace AutoRest.CSharp.V3.CodeGen
{
    internal class CsProjWriter : StringWriter
    {
        public bool WriteCsProj()
        {
            Line(@"<Project Sdk=""Microsoft.NET.Sdk"">

  <PropertyGroup>
    <OutputType>Library</OutputType>
    <TargetFramework>netcoreapp3.0</TargetFramework>
    <AssemblyName>AutoRest.CSharp.V3.Test</AssemblyName>
    <RootNamespace>AutoRest.CSharp.V3.Test</RootNamespace>
    <AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>
    <OutputPath>bin</OutputPath>
    <PublishDir>$(OutputPath)</PublishDir>
    <!-- Some methods are marked async and don't have an await in them -->
    <NoWarn>1998</NoWarn>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <WarningsAsErrors />
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <PropertyGroup Condition=""'$(Configuration)|$(Platform)'=='Debug|AnyCPU'"">
    <DelaySign>false</DelaySign>
    <DefineConstants>TRACE;DEBUG;NETSTANDARD</DefineConstants>
  </PropertyGroup>

  <PropertyGroup Condition=""'$(Configuration)|$(Platform)'=='Release|AnyCPU'"">
    <SignAssembly>true</SignAssembly>
    <DelaySign>true</DelaySign>
    <AssemblyOriginatorKeyFile>MSSharedLibKey.snk</AssemblyOriginatorKeyFile>
    <DefineConstants>TRACE;RELEASE;NETSTANDARD;SIGN</DefineConstants>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Azure.Core"" Version=""1.0.0"" />
    <PackageReference Include=""NUnit"" Version=""3.12.0"" />
  </ItemGroup>

</Project>
");

            return true;
        }
    }
}
