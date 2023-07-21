import "@typespec/http";
import "@azure-tools/cadl-ranch-expect";

using TypeSpec.Http;

@doc("Illustrates inheritance and polymorphic model.")
@scenarioService("/type/model/inheritance")
namespace Type.Model.Inheritance;

@doc("This is base model for non-discriminator normal multiple levels inheritance.")
model Pet {
  name: string;
}

@doc("The second level model in the normal multiple levels inheritance.")
model Cat extends Pet {
  age: int32;
}

@doc("The third level model in the normal multiple levels inheritance.")
model Siamese extends Cat {
  smart: boolean;
}

@doc("This is base model for polymorphic multiple levels inheritance with a discriminator.")
@discriminator("kind")
model Fish {
  age: int32;
}

@doc("The second level model in polymorphic multiple levels inheritance and it defines a new discriminator.")
//@discriminator("sharktype")
model Shark extends Fish {
  kind: "shark";
}

@doc("The second level model in polymorphic multiple levels inheritance which contains references to other polymorphic instances.")
model Salmon extends Fish {
  kind: "salmon";
  friends?: Fish[];
  hate?: Record<Fish>;
  partner?: Fish;
}

@doc("Test duplicated discriminator declaration, see issue 3504")
@discriminator("kind")
model Turtle {
    kind: string;
}

@doc("See turtle")
model SeaTurtle extends Turtle {
    kind: "seeTurtle";
    swimmingSpeed: int32;
}

/*@doc("The third level model SawShark in polymorphic multiple levels inheritance.")
model SawShark extends Shark {
  sharktype: "saw";
}

@doc("The third level model GoblinShark in polymorphic multiple levels inheritance.")
model GoblinShark extends Shark {
  sharktype: "goblin";
}*/

@scenario
@scenarioDoc("""
Generate and send model.
Expected input body:
```json
{"name": "abc", "age": 32, "smart": true}
```
""")
@route("/valid")
@post
op postValid(@body input: Siamese): OkResponse;

@scenario
@scenarioDoc("""
Generate and receive model.
Expected response body:
```json
{"name": "abc", "age": 32, "smart": true}
```
""")
@route("/valid")
@get
op getValid(): Siamese;

@scenario
@scenarioDoc("Generate, send, and receive round-trip bottom model.")
@route("/valid")
@put
op putValid(@body input: Siamese): Siamese;

@scenario
@scenarioDoc("""
Test model with duplicated discriminator declaration
""")
@route("/duplicate")
@get
op getDuplicate(): Turtle;

@route("/discriminated")
interface Discriminated {
  @scenario
  @route("/model")
  @scenarioDoc("""
  Generate and receive polymorphic model in multiple levels inheritance with 2 discriminators.
  Expected response body:
  ```json
  {"age": 1, "kind": "shark",  "sharktype": "goblin"}
  ```
  """)
  @get
  getModel(): Fish;

  @scenario
  @route("/model")
  @scenarioDoc("""
  Generate and send polymorphic model in multiple levels inheritance with 2 discriminators.
  Expected input body:
  ```json
  {"age": 1, "kind": "shark",  "sharktype": "goblin"}
  ```
  """)
  @put
  putModel(@body input: Fish): OkResponse;

  @scenario
  @route("/recursivemodel")
  @scenarioDoc("""
  Generate and receive polymorphic models has collection and dictionary properties referring to other polymorphic models.
  Expected response body:
  ```json
  {
    "age": 1,
    "kind": "salmon",
    "partner": {
      "age": 2,
      "kind": "shark",
      "sharktype": "saw"
    },
    "friends": [
      {
        "age": 2,
        "kind": "salmon",
        "partner": {
          "age": 3,
          "kind": "salmon"
        },
        "hate": {
          "key1": {
            "age": 4,
            "kind": "salmon"
          },
          "key2": {
            "age": 2,
            "kind": "shark",
            "sharktype": "goblin"
          }
        }
      },
      {
        "age": 3,
        "kind": "shark",
        "sharktype": "goblin"
      }
    ],
    "hate": {
      "key3": {
        "age": 3,
        "kind": "shark",
        "sharktype": "saw"
      },
      "key4": {
        "age": 2,
        "kind": "salmon",
        "friends": [
          {
            "age": 1,
            "kind": "salmon"
          },
          {
            "age": 4,
            "kind": "shark",
            "sharktype": "goblin"
          }
        ]
      }
    }
  }
  ```
  """)
  @get
  getRecursiveModel(): Fish;

  @scenario
  @route("/recursivemodel")
  @scenarioDoc("""
  Generate and send polymorphic models has collection and dictionary properties referring to other polymorphic models.
  Expected input body:
  ```json
  {
    "age": 1,
    "kind": "salmon",
    "partner": {
      "age": 2,
      "kind": "shark",
      "sharktype": "saw"
    },
    "friends": [
      {
        "age": 2,
        "kind": "salmon",
        "partner": {
          "age": 3,
          "kind": "salmon"
        },
        "hate": {
          "key1": {
            "age": 4,
            "kind": "salmon"
          },
          "key2": {
            "age": 2,
            "kind": "shark",
            "sharktype": "goblin"
          }
        }
      },
      {
        "age": 3,
        "kind": "shark",
        "sharktype": "goblin"
      }
    ],
    "hate": {
      "key3": {
        "age": 3,
        "kind": "shark",
        "sharktype": "saw"
      },
      "key4": {
        "age": 2,
        "kind": "salmon",
        "friends": [
          {
            "age": 1,
            "kind": "salmon"
          },
          {
            "age": 4,
            "kind": "shark",
            "sharktype": "goblin"
          }
        ]
      }
    }
  }
  ```
  """)
  @put
  putRecursiveModel(@body input: Fish): OkResponse;

  @scenario
  @route("/missingdiscriminator")
  @scenarioDoc("""
  Get a model omitting the discriminator.
  Expected response body:
  ```json
  {"age": 1}
  ```
  """)
  @get
  getMissingDiscriminator(): Fish;

  @scenario
  @route("/wrongdiscriminator")
  @scenarioDoc("""
  Get a model containing discriminator value never defined.
  Expected response body:
  ```json
  {"age": 1, "kind": "wrongKind" }
  ```
  """)
  @get
  getWrongDiscriminator(): Fish;
}
