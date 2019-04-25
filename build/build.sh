#!/bin/bash -xe 

echo "Clearing old packages"

npm install
npm install -g gulp 
npm install -g autorest

currentBranch=$(git rev-parse --abbrev-ref HEAD)
echo "Building branch $currentBranch"

testProject="agoda.csharp.client.test/agoda.csharp.client.test.csproj"

dotnet sln remove $testProject
dotnet build
# This will create a tar file that can be used in conjunction with the autorest generate command to generate clients for running tests
name=$(npm pack)
package=${name##*$'\n'}
echo "Package created $package"
dotnet sln add $testProject 
rm -rf ./agoda.csharp.client.test/Client
autorest --reset 
autorest --use=http://localhost:8085/$package --csharp --input-file=./swagger/swagger.json --output-folder=./agoda.csharp.client.test/Client --namespace=Agoda.Csharp.Client.Test
# good agent hk-unix59-19
dotnet restore -s https://bk-lib-nuget.agodadev.io/api/odata
dotnet build
dotnet test
