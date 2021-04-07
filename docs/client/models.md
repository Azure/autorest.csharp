# <img align="center" src="../images/logo.png">  Accessing Models and Enums

## General

Models and enums are generated in the `Models` namespace. So, say you are using library `Azure.Pets`. To access model `Dog`, you would use the following `using`
statement

```csharp
using Azure.Pets.Models;

var dog = new Dog();
```

Enums are also listed in the `Models` namespace, so say you have enum class `DogTypes`. To access the `Dalmation` enum, your code would look like

```csharp
using Azure.Pets.Models;

DogTypes myDogType = DogTypes.Dalmation;
```
