
# Agoda-autorest

This is the autorest extension for agoda which uses the roundrobin client.
The [AutoRest](https://github.com/Azure/autorest) tool generates client libraries for accessing RESTful web services.

### Usage

- Install nodejs > 10.11.5 on your machine
- `npm install -g autorest`
- `autorest --use=agoda-extension@1.0.2 --csharp --input-file=yourswagger.json --output-folder=./output-file-path --namespace=Agoda.Abc.YourName`

#### AutoRest extension configuration

``` yaml

skip-simplifier-on-namespace: 
  - System.Security.Permissions

pipeline:
  agoda-extension/emitter:
    scope: scope-agoda-extension/emitter 
    output-artifact: some-file-generated-by-agoda-extension
  
scope-agoda-extension/emitter:
  input-artifact: some-file-generated-by-agoda-extension

output-artifact:
- some-file-generated-by-agoda-extension
```

### Contribution

- Clone the repo. 
- `npm install -g http-server`
- `http-server -p 8085`
- You can test the extension by making changes and running `./build/build.sh`
- Use the above script because it clears the caches for you which may prevent changes from reflecting.

### Pre-requisites to tests

You need to have a working version of docker on your system.

### Build

```
./build/start-test-server.sh
# Linux (PowerShell)
pwsh ./build/build.ps1
```

### Test
```
# Run build.ps1 before test
./build/start-test-server.sh  
dotnet test
```
