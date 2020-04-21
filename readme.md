# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Setup
- [NodeJS](https://nodejs.org/en/) (13.x.x)
- `npm install` (at root)
- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core/3.0) (3.0.100)
- [PowerShell Core](https://github.com/PowerShell/PowerShell/releases/latest)
- [Java](https://www.java.com/en/download/) (for V2 testserver)

## Build
- `dotnet build` (at root)
- `./eng/Generate.ps1` (at root in PowerShell Core)

## Test
- `dotnet test` (at root)

## Customizing the generated code

### Make a model internal

Define a class with the same namespace and name as generated model and use the desired accessibility.

<details>

**Generated code before (Generated/Models/Model.cs):**

``` C#
namespace Azure.Service.Models
{
    public partial class Model { }
}
```

**Add customized model (Model.cs)**

``` C#
namespace Azure.Service.Models
{
    internal partial class Model { }
}
```

**Generated code after (Generated/Models/Model.cs):**

``` diff
namespace Azure.Service.Models
{
-    public partial class Model { }
+    internal partial class Model { }
}
```
</details>

### Rename a model class

Define a class with a desired name and mark it with `[CodeGenModel("OriginalName")]`

<details>

**Generated code before (Generated/Models/Model.cs):**

``` C#
namespace Azure.Service.Models
{
    public partial class Model { }
}
```

**Add customized model (NewModelClassName.cs)**

``` C#
namespace Azure.Service.Models
{
    [CodeGenModel("Model")]
    public partial class NewModelClassName { }
}
```

**Generated code after (Generated/Models/NewModelClassName.cs):**

``` C#
namespace Azure.Service.Models
{
    public partial class NewModelClassName { }
}
```
</details>

### Make model property internal



### Make a client internal

Define a class with the same namespace and name as generated client and use the desired accessibility.

<details>

**Generated code before (Generated/Operations/ServiceClient.cs):**

``` C#
namespace Azure.Service.Operations
{
    public partial class ServiceClient { }
}
```

**Add customized model (Model.cs)**

``` C#
namespace Azure.Service.Operations
{
    internal partial class ServiceClient { }
}
```

**Generated code after (Generated/Operations/ServiceClient.cs):**

``` C#
namespace Azure.Service.Operations
{
    internal partial class ServiceClient { }
}
```
</details>

## Configuration
```yaml
# autorest-core version
version: 3.0.6277
shared-source-folder: $(this-folder)/src/assets
save-inputs: true
use: $(this-folder)/artifacts/bin/AutoRest.CSharp.V3/Debug/netcoreapp3.0/
clear-output-folder: false

pipeline:
  csharpproj:
    input: modelerfour/identity
  csharpproj/emitter:
    input: csharpproj
    scope: output-scope
```
