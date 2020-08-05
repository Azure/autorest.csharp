# C# code generator for AutoRest V3

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

<!-- TOC depthfrom:3 -->

- [Make a model internal](#make-a-model-internal)
- [Rename a model class](#rename-a-model-class)
- [Change a model namespace](#change-a-model-namespace)
- [Make model property internal](#make-model-property-internal)
- [Rename a model property](#rename-a-model-property)
- [Change a model property type](#change-a-model-property-type)
- [Preserve raw Json value of a property](#preserve-raw-json-value-of-a-property)
- [Changing member doc comment](#changing-member-doc-comment)
- [Customize serialization/deserialization methods](#customize-serializationdeserialization-methods)
- [Renaming an enum](#renaming-an-enum)
- [Renaming an enum member](#renaming-an-enum-member)
- [Make a client internal](#make-a-client-internal)
- [Rename a client](#rename-a-client)
- [Replace any generated member](#replace-any-generated-member)
- [Remove any generated member](#remove-any-generated-member)
- [Change model namespace or accessability in bulk](#change-model-namespace-or-accessability-in-bulk)

<!-- /TOC -->

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

### Change a model namespace

Define a class with a desired namespace and mark it with `[CodeGenModel("OriginalName")]`

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
namespace Azure.Service
{
    [CodeGenModel("Model")]
    public partial class Model { }
}
```

**Generated code after (Generated/Models/NewModelClassName.cs):**

``` diff
- namespace Azure.Service.Models
+ namespace Azure.Service
{
    public partial class Model { }
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

**NOTE:** you can also change a property to a field using this mapping.

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

### Preserve raw Json value of a property

Use the [Change a model property type](#Change-a-model-property-type) approach to change property type to `JsonElement`.

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
        public JsonElement Property { get; }
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
+        // Serialization code now reads and writes JsonElement value instead of string  
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

### Customize serialization/deserialization methods

Use the [Replace any generated member](#replace-any-generated-member) approach to replace Serialize/Deserialize method with a custom implementation.

<details>

**Generated code before (Generated/Models/Cat.Serialization.cs):**

``` C#
namespace Azure.Service.Models
{
  public partial class Cat
  {
      internal static Cat DeserializeCat(JsonElement element)
      {
          string color = default;
          string name = default;
          foreach (var property in element.EnumerateObject())
          {
              if (property.NameEquals("color"))
              {
                  if (property.Value.ValueKind == JsonValueKind.Null)
                  {
                      continue;
                  }
                  color = property.Value.GetString();
                  continue;
              }
              if (property.NameEquals("name"))
              {
                  if (property.Value.ValueKind == JsonValueKind.Null)
                  {
                      continue;
                  }
                  name = property.Value.GetString();
                  continue;
              }
          }
          return new Cat(id, name);
      }
  }
}
```

**Add customized model (Cat.cs)**

``` C#
namespace Azure.Service.Models
{
  public partial class Cat
  {
      internal static Cat DeserializeCat(JsonElement element)
      {
          string color = default;
          string name = default;
          foreach (var property in element.EnumerateObject())
          {
              if (property.NameEquals("name"))
              {
                  if (property.Value.ValueKind == JsonValueKind.Null)
                  {
                      continue;
                  }
                  name = property.Value.GetString();
                  continue;
              }
          }
          // WORKAROUND: server never sends color, default to black
          color = "black";
          return new Cat(name, color);
      }
  }
}
```

**Generated code after (Generated/Models/Model.cs):**

Generated code won't contain the DeserializeCat method and the custom one would be used for deserialization.

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

### Changing an enum to an extensible enum

Redefine an enum into an extensible enum by creating an empty struct with the same name as original enum.

<details>

**Generated code before (Generated/Models/Colors.cs):**

``` C#
namespace Azure.Service.Models
{
    public enum Colors
    {
        Red,
        Green
    }
}
```

**Add customized model (Colors.cs)**

``` C#
namespace Azure.Service.Models
{
    public partial struct Colors
    {
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

``` diff
namespace Azure.Service.Models
{
-    public enum Colors
-    {
-        Red,
-        Green
-    }
+    public readonly partial struct Colors : IEquatable<Colors>
+    {
+        private readonly string _value;

+        public Colors(string value)
+        {
+            _value = value ?? throw new ArgumentNullException(nameof(value));
+        }

+        private const string Red = "red";
+        private const string Green = "green";

+        public static Colors Red { get; } = new Colors(Red);
+        public static Colors Green { get; } = new Colors(Green);
+        public static bool operator ==(Colors left, Colors right) => left.Equals(right);
         ...
}
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

### Change model namespace or accessability in bulk

**Generated code before:**

``` C#
namespace Azure.Service.Models
{
    public partial class Model1 {}
    public partial class Model2 {}
    public partial class Model3 {}
    public partial class Model4 {}
}
```

**Add autorest.md transformation**

```
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Search.Documents.Indexes.Models"
    $["x-accessibility"] = "internal"
```

**Generated code after:**

``` diff
-namespace Azure.Service.Models
+namespace Azure.Search.Documents.Indexes.Models
{
-    public partial class Model1 {}
+    internal partial class Model1 {}
-    public partial class Model2 {}
+    internal partial class Model2 {}
-    public partial class Model3 {}
+    internal partial class Model3 {}
-    public partial class Model4 {}
+    internal partial class Model4 {}
}
```

</details>

## Configuration
```yaml
# autorest-core version
version: 3.0.6306
shared-source-folder: $(this-folder)/src/assets
save-inputs: true
use: $(this-folder)/artifacts/bin/AutoRest.CSharp.V3/Debug/netcoreapp3.0/
clear-output-folder: false
public-clients: true
pipeline:
  csharpproj:
    input: modelerfour/identity
  csharpproj/emitter:
    input: csharpproj
    scope: output-scope
```
