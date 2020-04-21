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

``` diff
namespace Azure.Service.Models
{
-    public partial class Model { }
+    public partial class NewModelClassName { }
}
```
</details>

### Make model property internal

Define a class with a property matching a generated property name but with desired accessibility.

<details>

**Generated code before (Generated/Models/Model.cs):**

``` C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public string Property { get; }
    }
}
```

**Add customized model (Model.cs)**

``` C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        internal string Property { get; } 
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

``` diff
namespace Azure.Service.Models
{
    public partial class Model
    {
-        public string Property { get; }
    }
}
```
</details>


### Rename a model property

Define a partial class with a new property name and mark it with `[CodeGenMember("OriginalName")]` attribute.

<details>

**Generated code before (Generated/Models/Model.cs):**

``` C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public string Property { get; }
    }
}
```

**Add customized model (Model.cs)**

``` C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        [CodeGenMember("Property")]
        public string RenamedProperty { get; } 
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

``` diff
namespace Azure.Service.Models
{
    public partial class Model
    {
-        public string Property { get; }
+        // All original Property usages would reference a RenamedProperty
    }
}
```
</details>

### Change a model property type

:warning:

**NOTE: This is supported for a narrow set of cases where the underlying serialized type doesn't change**

Scenarios that would work:
1. String <-> TimeSpan (both represented as string in JSON)
1. Float <-> Int (both are numbers)
1. String <-> Enums (both strings) 

Won't work:
1. String <-> Bool (different json type)
2. Changing model kinds

If you think you have a valid re-mapping scenario that's not supported file an issue.

:warning:

Define a property with different type than the generated one.

<details>

**Generated code before (Generated/Models/Model.cs):**

``` C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public string Property { get; }
    }
}
```

**Add customized model (Model.cs)**

``` C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public DateTime Property { get; } 
    }
}
```

**Generated code after (Generated/Models/Model.Serializer.cs):**

``` diff
namespace Azure.Service.Models
{
    public partial class Model
    {
-        public string Property { get; }
+        // Serialization code now reads and writes DateTime value instead of string  
    }
}
```
</details>

### Changing member doc comment

Redefine a member in partial class with a new doc comment.

<details>

**Generated code before (Generated/Models/Model.cs):**

``` C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        /// Subpar doc comment
        public string Property { get; }
    }
}
```

**Add customized model (Model.cs)**

``` C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        /// Great doc comment
        public string Property { get; } 
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

``` diff
namespace Azure.Service.Models
{
    public partial class Model
    {
-        /// Subpar doc comment
-        public string Property { get; }  
    }
}
```
</details>

### Renaming an enum

Redefine an enum with a new name and all the members mark it with `[CodeGenModel("OriginEnumName")]`.

**NOTE: because enums can't be partial all values have to be copied**

<details>

**Generated code before (Generated/Models/Colors.cs):**

``` C#
namespace Azure.Service.Models
{
    public enum Colors
    {
        Red,
        Green,
        Blue
    }
}
```

**Add customized model (WallColors.cs)**

``` C#
namespace Azure.Service.Models
{
    [CodeGenModel("Colors")]
    public enum WallColors
    {
        Red,
        Green,
        Blue
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

``` diff
-namespace Azure.Service.Models
-{
-    public enum Colors
-    {
-        Red,
-        Green,
-        Blue
-    }
-}
+// Serialization code uses the new WallColors type name
```
</details>

### Renaming an enum member

Redefine an enum with the same name and all the members, mark renamed member with `[CodeGenMember("OriginEnumMemberName")]`.

**NOTE: because enums can't be partial all values have to be copied but only the ones being renamed should be marked with an attributes**

<details>

**Generated code before (Generated/Models/Colors.cs):**

``` C#
namespace Azure.Service.Models
{
    public enum Colors
    {
        Red,
        Green,
        Blue
    }
}
```

**Add customized model (Colors.cs)**

``` C#
namespace Azure.Service.Models
{
    public enum Colors
    {
        Red,
        Green,
        [CodeGenMember("Blue")]
        SkyBlue
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

``` diff
-namespace Azure.Service.Models
-{
-    public enum Colors
-    {
-        Red,
-        Green,
-        Blue
-    }
-}
+// Serialization code uses the new SkyBlue member name
```
</details>

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

``` diff
namespace Azure.Service.Operations
{
-    public partial class ServiceClient { }
+    internal partial class ServiceClient { }
}
```
</details>


### Rename a client

Define a partial client class with a new name and mark it with `[CodeGenClient("OriginalName")]`

<details>

**Generated code before (Generated/Operations/ServiceClient.cs):**

``` C#
namespace Azure.Service.Operations
{
    public partial class ServiceClient {}
}
```

**Add customized model (Model.cs)**

``` C#
namespace Azure.Service.Operations
{
    [CodeGenClient("ServiceClient")]
    public partial class TableClient { }
}
```

**Generated code after (Generated/Operations/ServiceClient.cs):**

``` diff
namespace Azure.Service.Operations
{
-    public partial class ServiceClient { }
+    public partial class TableClient { }
}
```
</details>


### Replace any generated member

Works for model and client properties, methods, constructors etc.

Define a partial class with member with the same name and for methods same parameters.

<details>

**Generated code before (Generated/Models/Model.cs):**

``` C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public Model()
        {  
            Property = "a";
        }

        public string Property { get; set; }
    }
}
```

**Add customized model (Model.cs)**

``` C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        internal Model()
        {
            Property = "b";
        }
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

``` diff
namespace Azure.Service.Models
{
    public partial class Model
    {
-        public Model()
-        {  
-            Property = "a";
-        }
    }
}
```
</details>

### Remove any generated member

Works for model and client properties, methods, constructors etc.

Define a partial class with `[CodeGenSuppress("NameOfMember", typeof(Parameter1Type), typeof(Parameter2Type))]` attribute.

<details>

**Generated code before (Generated/Models/Model.cs):**

``` C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public Model()
        {  
            Property = "a";
        }
        
        public Model(string property)
        {  
            Property = property;
        }

        public string Property { get; set; }
    }
}
```

**Add customized model (Model.cs)**

``` C#
namespace Azure.Service.Models
{
    [CodeGenSuppress("Model", typeof(string))]
    public partial class Model
    {
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

``` diff
namespace Azure.Service.Models
{
    public partial class Model
    {
-        public Model(string property)
-        {  
-            Property = property;
-        }
    }
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
